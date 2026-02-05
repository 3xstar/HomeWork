import sys
import os
from PyQt5 import QtWidgets
from track_widget import TrackWidget

class MainWindow(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()
        
        # Получаем путь к папке с картинками
        base_dir = os.path.dirname(os.path.abspath(__file__))
        images_dir = os.path.join(base_dir, "images")
        
        # Создаем центральный виджет
        central_widget = QtWidgets.QWidget()
        self.setCentralWidget(central_widget)
        
        # Основной layout
        main_layout = QtWidgets.QVBoxLayout(central_widget)
        
        # ScrollArea
        scroll_area = QtWidgets.QScrollArea()
        scroll_area.setWidgetResizable(True)
        
        # Контейнер для треков
        tracks_container = QtWidgets.QWidget()
        self.tracks_layout = QtWidgets.QVBoxLayout(tracks_container)
        self.tracks_layout.setSpacing(0)  # Убираем отступы между треками
        
        # Данные треков с путями к картинкам
        tracks_data = [
            {
                "title": "Crocodiles never die", 
                "artist": "Bombardillo Crocodillo",
                "cover": os.path.join(images_dir, "queen_cover.jpg")
            },
            {
                "title": "Cat but human hut fish", 
                "artist": "Trulimero Trulichina",
                "cover": os.path.join(images_dir, "led_zeppelin.jpg")
            },
            {
                "title": "Smooth boys", 
                "artist": "MACAN",
                "cover": os.path.join(images_dir, "eagles_cover.jpg")
            },
            {
                "title": "Symbol of sex", 
                "artist": "Arthur Pirozhkov",
                "cover": os.path.join(images_dir, "nirvana.jpg")
            },
            {
                "title": "OH MY GOD", 
                "artist": "Mellstroy",
                "cover": os.path.join(images_dir, "lennon_cover.jpg")
            },
        ]
        
        # Создаем виджеты треков
        for track_info in tracks_data:
            track_widget = TrackWidget(
                title=track_info["title"],
                artist=track_info["artist"],
                cover_path=track_info["cover"]
            )
            self.tracks_layout.addWidget(track_widget)
        
        # Растягивающий элемент в конец
        self.tracks_layout.addStretch()
        
        # Устанавливаем контейнер
        scroll_area.setWidget(tracks_container)
        main_layout.addWidget(scroll_area)
        
        # Настройки окна
        self.setWindowTitle("Музыкальный плеер")
        self.setGeometry(100, 100, 400, 500)

if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    window = MainWindow()
    window.show()
    sys.exit(app.exec_())