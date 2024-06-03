from PyQt5 import QtCore, QtWidgets

# 全局变量
ELEVATOR_NUM = 5  # 电梯总数目
ELEVATOR_FLOOR = 20  # 电梯总楼层数
TIME_PER_FLOOR = 1000  # 运行一层电梯所需时间 单位 毫秒
OPENING_DOOR_TIME = 1000  # 打开一扇门所需时间 单位 毫秒
OPEN_DOOR_TIME = 1000  # 门打开后维持的时间 单位 毫秒


# 电梯UI界面
class Ui_MainWindow(object):
    def __init__(self):
        # 初始化存储每个电梯楼层按钮的字典
        self.floor_buttons = {}

    def setupUi(self, MainWindow):
        # 设置主窗口属性
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(1600, 838)

        # 初始化中心部件
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        MainWindow.setCentralWidget(self.centralwidget)

        # 创建5个电梯控件
        self.elevators = {}
        for i in range(1, ELEVATOR_NUM + 1):  # 从1到5号电梯
            self.floor_buttons[i] = {}
            self.elevators[i] = self.create_elevator_controls(i, self.centralwidget)

        # 初始化字典，存储向上和向下的楼层按钮控件
        self.up_floor_buttons = {}
        self.down_floor_buttons = {}

        # 初始化第一个楼层按钮的y坐标位置
        y_position = 90  # 调整到底部的第一层

        # 初始化一个字典来存储楼层标签
        self.floor_labels = {}

        # 创建楼层按钮和标签的y坐标初始值
        y_position = 90  # 调整到底部的第一层按钮位置

        # 创建楼层的上下按钮和对应标签的循环
        for floor in range(1, ELEVATOR_FLOOR + 1):
            # 创建并设置楼层标签
            label = QtWidgets.QLabel(self.centralwidget)
            label.setGeometry(QtCore.QRect(30, y_position, 20, 21))  # 设置位置，与按钮对齐
            label.setObjectName(f"floor_labels_{floor}")
            self.floor_labels[floor] = label  # 将标签存储在字典中

            # 为每层创建向上的按钮
            up_floor_button = QtWidgets.QPushButton(self.centralwidget)
            up_floor_button.setGeometry(QtCore.QRect(50, y_position, 31, 28))  # 位置稍微向左
            up_floor_button.setObjectName(f"up_floor_buttons_{floor}")
            up_floor_button.setText("↑")
            self.up_floor_buttons[floor] = up_floor_button

            # 为每层创建向下的按钮
            down_floor_button = QtWidgets.QPushButton(self.centralwidget)
            down_floor_button.setGeometry(QtCore.QRect(90, y_position, 31, 28))  # 紧邻向上按钮
            down_floor_button.setObjectName(f"down_floor_buttons_{floor}")
            down_floor_button.setText("↓")
            self.down_floor_buttons[floor] = down_floor_button

            y_position += 30  # 为下一个按钮和标签组合增加y坐标位置

        # 设置主中心部件
        MainWindow.setCentralWidget(self.centralwidget)

        # 连接翻译和事件处理
        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def create_elevator_controls(self, elevator_number, parent_widget, list_widget=None):
        # 第一个电梯的起始x坐标位置，根据需要调整间距
        x_position = 190 + (elevator_number - 1) * 300

        # 为每个电梯创建LCD数字显示
        lcdNumber = QtWidgets.QLCDNumber(parent_widget)
        lcdNumber.setGeometry(QtCore.QRect(x_position, 10, 171, 71))
        lcdNumber.setObjectName(f"lcdNumber_{elevator_number}")

        # 箭头显示
        arrow_label = QtWidgets.QLabel(parent_widget)
        arrow_label.setGeometry(QtCore.QRect(x_position + 20, 30, 32, 32))  # 调整位置和尺寸
        arrow_label.setObjectName(f"arrow_{elevator_number}")

        # 围绕中心按钮的样式框架
        list_widget = QtWidgets.QListWidget(parent_widget)
        list_widget.setGeometry(QtCore.QRect(x_position - 10, 90, 191, 605))
        list_widget.setObjectName(f"list_widget_{elevator_number}")

        # 关门按钮
        self.close_door_button = QtWidgets.QPushButton(parent_widget)
        self.close_door_button.setGeometry(QtCore.QRect(x_position + 90, 740, 81, 31))
        self.close_door_button.setObjectName(f"close_door_button_{elevator_number}")

        # 开门按钮
        self.open_door_button = QtWidgets.QPushButton(parent_widget)
        self.open_door_button.setGeometry(QtCore.QRect(x_position, 740, 81, 31))
        self.open_door_button.setObjectName(f"open_door_button_{elevator_number}")

        # 报警按钮
        alarm_button = QtWidgets.QPushButton(parent_widget)
        alarm_button.setGeometry(QtCore.QRect(x_position + 25, 700, 121, 31))
        alarm_button.setObjectName(f"alarm_button_{elevator_number}")

        self.floor_buttons[elevator_number] = {}

        y_position = 90  # 每个电梯的楼层按钮起始y坐标
        for floor in range(20, 0, -1):
            button = QtWidgets.QPushButton(parent_widget)
            button.setGeometry(QtCore.QRect(x_position - 50, y_position, 31, 28))
            button.setObjectName(f"floor_button_{elevator_number}_{floor}")
            self.floor_buttons[elevator_number][floor] = button
            y_position += 30

        # 返回包含此电梯所有控件的字典或容器
        return {
            "lcdNumber": lcdNumber,
            'arrow_label': arrow_label,
            'list_widget': list_widget,
            "close_door_button": self.close_door_button,
            "open_door_button": self.open_door_button,
            "alarm_button": alarm_button,
            'floor_buttons': self.floor_buttons[elevator_number],
        }

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "电梯调度系统"))

        # 正确地遍历每个电梯及其楼层按钮
        for elevator_id, floors in self.floor_buttons.items():
            for floor, button in floors.items():
                button.setText(_translate("MainWindow", str(floor)))

        # 为电梯控制按钮设置文本
        for elevator_controls in self.elevators.values():
            elevator_controls['close_door_button'].setText(_translate("MainWindow", "关门"))
            elevator_controls['open_door_button'].setText(_translate("MainWindow", "开门"))
            elevator_controls['alarm_button'].setText(_translate("MainWindow", "报警"))

        # 为所有向上按钮设置文本
        for floor, button in self.up_floor_buttons.items():
            button.setText(_translate("MainWindow", "↑"))

        # 为所有向下按钮设置文本
        for floor, button in self.down_floor_buttons.items():
            button.setText(_translate("MainWindow", "↓"))

        # 为所有楼层标签设置文本
        for floor, label in self.floor_labels.items():
            label.setText(_translate("MainWindow", str(floor)))
