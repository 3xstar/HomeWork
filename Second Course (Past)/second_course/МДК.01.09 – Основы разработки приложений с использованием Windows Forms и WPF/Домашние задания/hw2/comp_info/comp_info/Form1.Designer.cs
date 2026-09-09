namespace comp_info
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pbCpu = new ProgressBar();
            pbGpu = new ProgressBar();
            lblCpuVal = new Label();
            lblGpuVal = new Label();
            lblRamVal = new Label();
            lblDiskVal = new Label();
            pbDisk = new ProgressBar();
            pbRam = new ProgressBar();
            timerUpdate = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 2, 1);
            tableLayoutPanel1.Controls.Add(label4, 4, 1);
            tableLayoutPanel1.Controls.Add(label5, 6, 1);
            tableLayoutPanel1.Controls.Add(pbCpu, 1, 2);
            tableLayoutPanel1.Controls.Add(pbGpu, 3, 2);
            tableLayoutPanel1.Controls.Add(lblCpuVal, 0, 2);
            tableLayoutPanel1.Controls.Add(lblGpuVal, 2, 2);
            tableLayoutPanel1.Controls.Add(lblRamVal, 4, 2);
            tableLayoutPanel1.Controls.Add(lblDiskVal, 6, 2);
            tableLayoutPanel1.Controls.Add(pbDisk, 7, 2);
            tableLayoutPanel1.Controls.Add(pbRam, 5, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(pictureBox2, 2, 3);
            tableLayoutPanel1.Controls.Add(pictureBox3, 4, 3);
            tableLayoutPanel1.Controls.Add(pictureBox4, 6, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5555553F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7777777F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.2222214F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.4444427F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 8);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Variable Display", 20F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(794, 52);
            label1.TabIndex = 0;
            label1.Text = "COMPINFO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Light", 18F, FontStyle.Bold);
            label2.Location = new Point(3, 52);
            label2.Name = "label2";
            label2.Size = new Size(194, 53);
            label2.TabIndex = 1;
            label2.Text = "CPU usage";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label3, 2);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Light", 18F, FontStyle.Bold);
            label3.Location = new Point(203, 52);
            label3.Name = "label3";
            label3.Size = new Size(194, 53);
            label3.TabIndex = 2;
            label3.Text = "GPU usage";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label4, 2);
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Light", 18F, FontStyle.Bold);
            label4.Location = new Point(403, 52);
            label4.Name = "label4";
            label4.Size = new Size(194, 53);
            label4.TabIndex = 3;
            label4.Text = "RAM usage";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label5, 2);
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Light", 18F, FontStyle.Bold);
            label5.Location = new Point(603, 52);
            label5.Name = "label5";
            label5.Size = new Size(194, 53);
            label5.TabIndex = 4;
            label5.Text = "Disk usage";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbCpu
            // 
            pbCpu.Dock = DockStyle.Fill;
            pbCpu.Location = new Point(103, 108);
            pbCpu.Name = "pbCpu";
            pbCpu.Size = new Size(94, 103);
            pbCpu.TabIndex = 5;
            // 
            // pbGpu
            // 
            pbGpu.Dock = DockStyle.Fill;
            pbGpu.Location = new Point(303, 108);
            pbGpu.Name = "pbGpu";
            pbGpu.Size = new Size(94, 103);
            pbGpu.TabIndex = 6;
            // 
            // lblCpuVal
            // 
            lblCpuVal.AutoSize = true;
            lblCpuVal.Dock = DockStyle.Fill;
            lblCpuVal.Font = new Font("Segoe UI", 20F);
            lblCpuVal.Location = new Point(3, 105);
            lblCpuVal.Name = "lblCpuVal";
            lblCpuVal.Size = new Size(94, 109);
            lblCpuVal.TabIndex = 8;
            lblCpuVal.Text = "0";
            lblCpuVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGpuVal
            // 
            lblGpuVal.AutoSize = true;
            lblGpuVal.Dock = DockStyle.Fill;
            lblGpuVal.Font = new Font("Segoe UI", 20F);
            lblGpuVal.Location = new Point(203, 105);
            lblGpuVal.Name = "lblGpuVal";
            lblGpuVal.Size = new Size(94, 109);
            lblGpuVal.TabIndex = 9;
            lblGpuVal.Text = "0";
            lblGpuVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRamVal
            // 
            lblRamVal.AutoSize = true;
            lblRamVal.Dock = DockStyle.Fill;
            lblRamVal.Font = new Font("Segoe UI", 20F);
            lblRamVal.Location = new Point(403, 105);
            lblRamVal.Name = "lblRamVal";
            lblRamVal.Size = new Size(94, 109);
            lblRamVal.TabIndex = 10;
            lblRamVal.Text = "0";
            lblRamVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDiskVal
            // 
            lblDiskVal.AutoSize = true;
            lblDiskVal.Dock = DockStyle.Fill;
            lblDiskVal.Font = new Font("Segoe UI", 20F);
            lblDiskVal.Location = new Point(603, 105);
            lblDiskVal.Name = "lblDiskVal";
            lblDiskVal.Size = new Size(94, 109);
            lblDiskVal.TabIndex = 11;
            lblDiskVal.Text = "0";
            lblDiskVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbDisk
            // 
            pbDisk.Dock = DockStyle.Fill;
            pbDisk.Location = new Point(703, 108);
            pbDisk.Name = "pbDisk";
            pbDisk.Size = new Size(94, 103);
            pbDisk.TabIndex = 12;
            // 
            // pbRam
            // 
            pbRam.Dock = DockStyle.Fill;
            pbRam.Location = new Point(503, 108);
            pbRam.Name = "pbRam";
            pbRam.Size = new Size(94, 103);
            pbRam.TabIndex = 7;
            // 
            // timerUpdate
            // 
            timerUpdate.Enabled = true;
            timerUpdate.Interval = 1000;
            // 
            // pictureBox1
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.cpu;
            pictureBox1.Location = new Point(3, 217);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 230);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBox2, 2);
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.gpu;
            pictureBox2.Location = new Point(203, 217);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(194, 230);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBox3, 2);
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = Properties.Resources.ram;
            pictureBox3.Location = new Point(403, 217);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(194, 230);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBox4, 2);
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = Properties.Resources.disk;
            pictureBox4.Location = new Point(603, 217);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(194, 230);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 16;
            pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ProgressBar pbCpu;
        private ProgressBar pbGpu;
        private ProgressBar pbRam;
        private Label lblCpuVal;
        private Label lblGpuVal;
        private Label lblRamVal;
        private Label lblDiskVal;
        private ProgressBar pbDisk;
        private System.Windows.Forms.Timer timerUpdate;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}
