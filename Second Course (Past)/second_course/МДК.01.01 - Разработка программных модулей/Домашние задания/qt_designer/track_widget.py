from PyQt5 import QtWidgets, QtGui, QtCore
import os

class TrackWidget(QtWidgets.QWidget):
    # Сигналы для кнопок
    play_clicked = QtCore.pyqtSignal()  # Сигнал для кнопки play
    add_clicked = QtCore.pyqtSignal()   # Сигнал для кнопки add
    
    def __init__(self, title="", artist="", cover_path=None, parent=None):
        super().__init__(parent)
        
        layout = QtWidgets.QHBoxLayout(self)
        
        # 1. Картинка
        self.coverLabel = QtWidgets.QLabel()
        self.coverLabel.setFixedSize(50, 50)
        self.coverLabel.setScaledContents(True)
        
        if cover_path and os.path.exists(cover_path):
            pixmap = QtGui.QPixmap(cover_path)
        else:
            pixmap = QtGui.QPixmap(50, 50)
            pixmap.fill(QtGui.QColor(200, 200, 200))
        self.coverLabel.setPixmap(pixmap)
        layout.addWidget(self.coverLabel)
        
        # 2. Текст
        text_layout = QtWidgets.QVBoxLayout()
        self.titleLabel = QtWidgets.QLabel(title)
        self.titleLabel.setStyleSheet("font-weight: bold;")
        
        self.artistLabel = QtWidgets.QLabel(artist)
        self.artistLabel.setStyleSheet("color: gray; font-size: 11px;")
        
        text_layout.addWidget(self.titleLabel)
        text_layout.addWidget(self.artistLabel)
        layout.addLayout(text_layout)
        
        # 3. Растягивающий элемент между текстом и кнопками
        layout.addStretch()
        
        # 4. Кнопки (pushButton и pushButton_2)
        self.playButton = QtWidgets.QPushButton("▶")
        self.playButton.setFixedSize(30, 30)
        self.playButton.setStyleSheet("""
            QPushButton {
                border: none;
                border-radius: 15px;
                background-color: #4CAF50;
                color: white;
                font-weight: bold;
            }
            QPushButton:hover {
                background-color: #45a049;
            }
        """)
        self.playButton.clicked.connect(self.on_play_clicked)
        
        self.addButton = QtWidgets.QPushButton("+")
        self.addButton.setFixedSize(30, 30)
        self.addButton.setStyleSheet("""
            QPushButton {
                border: none;
                border-radius: 15px;
                background-color: #2196F3;
                color: white;
                font-weight: bold;
            }
            QPushButton:hover {
                background-color: #0b7dda;
            }
        """)
        self.addButton.clicked.connect(self.on_add_clicked)
        
        # Добавляем кнопки в layout
        layout.addWidget(self.playButton)
        layout.addWidget(self.addButton)
        
        self.setFixedHeight(70)
        self.setStyleSheet("""
            TrackWidget {
                border-bottom: 1px solid #eee;
                padding: 10px;
            }
            TrackWidget:hover {
                background-color: #f5f5f5;
            }
        """)
    
    def on_play_clicked(self):
        """Обработка клика по кнопке воспроизведения"""
        self.play_clicked.emit()
        print(f"Play clicked for: {self.titleLabel.text()}")
    
    def on_add_clicked(self):
        """Обработка клика по кнопке добавления"""
        self.add_clicked.emit()
        print(f"Add clicked for: {self.titleLabel.text()}")
    
    def set_cover(self, cover_path):
        """Обновить обложку трека"""
        if os.path.exists(cover_path):
            pixmap = QtGui.QPixmap(cover_path)
            pixmap = pixmap.scaled(50, 50, QtCore.Qt.KeepAspectRatio, 
                                   QtCore.Qt.SmoothTransformation)
            self.coverLabel.setPixmap(pixmap)