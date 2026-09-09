using System;
using System.Diagnostics;
using System.Windows.Forms;
using LibreHardwareMonitor.Hardware;

namespace comp_info
{
    public partial class Form1 : Form
    {
        // Объект для мониторинга оборудования (GPU)
        private Computer _computer;
        private ISensor _gpuLoadSensor = null;

        // Переменные для хранения последних значений GPU, чтобы не искать их каждый тик таймера
        private float _gpuLoad = 0;
        private bool _gpuFound = false;

        public Form1()
        {
            InitializeComponent();
            InitializeHardwareMonitor();

            // Настройка таймера
            timerUpdate.Tick += TimerUpdate_Tick;
            timerUpdate.Start();
        }

        private void InitializeHardwareMonitor()
        {
            _computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true, // Иногда RAM лучше брать через PerformanceCounter, но тут попробуем через либу
                IsStorageEnabled = true
            };
            _computer.Open();

            // Подписываемся на событие обновления датчиков
            _computer.HardwareAdded += HardwareAdded;
            _computer.HardwareRemoved += HardwareRemoved;
        }

        private void HardwareAdded(IHardware hardware)
        {
            hardware.SensorAdded += SensorAdded;
            hardware.SensorRemoved += SensorRemoved;
        }

        private void HardwareRemoved(IHardware hardware)
        {
            hardware.SensorAdded -= SensorAdded;
            hardware.SensorRemoved -= SensorRemoved;
        }

        private void SensorAdded(ISensor sensor)
        {
            // Ищем датчик загрузки GPU
            if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
            {
                _gpuFound = true;
            }
        }

        private void SensorRemoved(ISensor sensor) { }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateCpu();
            UpdateRam();
            UpdateDisk();
            UpdateGpu();
        }

        // 1. CPU Usage
        private void UpdateCpu()
        {
            try
            {
                // Используем PerformanceCounter для CPU
                // Важно: CounterName может отличаться в зависимости от языка ОС. 
                // Для английской Windows: "% Processor Time", "_Total"
                // Для русской Windows: "% времени процессора", "_Общее"

                // Универсальный способ через Process class (менее точный, но работает везде)
                // Или лучше использовать PerformanceCounter с правильными именами.

                // Пример с PerformanceCounter (стандартный путь):
                using (var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
                {
                    cpuCounter.NextValue(); // Первый вызов всегда 0
                    System.Threading.Thread.Sleep(50); // Небольшая задержка для точности
                    float cpuValue = cpuCounter.NextValue();

                    pbCpu.Value = (int)cpuValue;
                    lblCpuVal.Text = $"{cpuValue:F1}%";
                }
            }
            catch (Exception ex)
            {
                lblCpuVal.Text = "Error";
            }
        }

        // 2. RAM Usage
        private void UpdateRam()
        {
            try
            {
                var gcMemoryInfo = GC.GetGCMemoryInfo();
                // Более точный способ через PerformanceCounter
                using (var ramCounter = new PerformanceCounter("Memory", "Available MBytes"))
                {
                    float availableMB = ramCounter.NextValue();

                    // Получаем общий объем физической памяти
                    ulong totalPhysicalMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (1024 * 1024);

                    float usedMB = totalPhysicalMemory - availableMB;
                    float percent = (usedMB / totalPhysicalMemory) * 100;

                    pbRam.Value = (int)percent;
                    lblRamVal.Text = $"{percent:F1}%";
                }
            }
            catch (Exception ex)
            {
                lblRamVal.Text = "Error";
            }
        }

        // 3. Disk Usage (Активность диска)
        private void UpdateDisk()
        {
            try
            {
                // Мониторим диск C:
                using (var diskCounter = new PerformanceCounter("LogicalDisk", "% Disk Time", "C:"))
                {
                    diskCounter.NextValue();
                    System.Threading.Thread.Sleep(50);
                    float diskValue = diskCounter.NextValue();

                    // Ограничиваем 100%, так как % Disk Time может превышать 100% на многоядерных системах с RAID и т.д.
                    if (diskValue > 100) diskValue = 100;

                    pbDisk.Value = (int)diskValue;
                    lblDiskVal.Text = $"{diskValue:F1}%";
                }
            }
            catch (Exception ex)
            {
                lblDiskVal.Text = "Error";
            }
        }

        // 4. GPU Usage (через LibreHardwareMonitor)
        // --- ИСПРАВЛЕННЫЙ МЕТОД ДЛЯ GPU ---
        private void UpdateGpu()
        {
            // 1. Если сенсор еще не найден, пытаемся найти его
            if (_gpuLoadSensor == null)
            {
                foreach (var hardware in _computer.Hardware)
                {
                    // Проверяем, что это видеокарта
                    if (hardware.HardwareType == HardwareType.GpuNvidia ||
                        hardware.HardwareType == HardwareType.GpuAmd ||
                        hardware.HardwareType == HardwareType.GpuIntel)
                    {
                        hardware.Update(); // Обновляем данные

                        // Ищем первый попавшийся сенсор типа Load (Загрузка)
                        // Обычно это "GPU Core", "D3D 3D" или просто "Load"
                        foreach (var sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Load)
                            {
                                // Берем первый подходящий сенсор загрузки
                                _gpuLoadSensor = sensor;
                                break;
                            }
                        }

                        if (_gpuLoadSensor != null) break; // Если нашли, выходим из цикла
                    }
                }
            }

            // 2. Если сенсор найден, считываем данные
            if (_gpuLoadSensor != null)
            {
                // Важно: нужно вызывать Update у родительского оборудования или самого сенсора
                _gpuLoadSensor.Hardware.Update();

                if (_gpuLoadSensor.Value.HasValue)
                {
                    float value = _gpuLoadSensor.Value.Value;

                    // Защита от некорректных значений
                    if (value < 0) value = 0;
                    if (value > 100) value = 100;

                    pbGpu.Value = (int)value;
                    lblGpuVal.Text = $"{value:F1}%";

                    // Для отладки можно вывести имя сенсора в заголовок формы один раз
                    // this.Text = $"Sensor: {_gpuLoadSensor.Name}"; 
                }
                else
                {
                    lblGpuVal.Text = "No Value";
                }
            }
            else
            {
                // Если после нескольких попыток сенсор не найден
                lblGpuVal.Text = "No GPU Found";

                // Опционально: Можно попробовать принудительно обновить все железо
                // _computer.Accept(new UpdateVisitor()); 
            }
        }


        // Не забываем освободить ресурсы при закрытии формы
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _computer.Close();
            base.OnFormClosing(e);
        }
    }
}