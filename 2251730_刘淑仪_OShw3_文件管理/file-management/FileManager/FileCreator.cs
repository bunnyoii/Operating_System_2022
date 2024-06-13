using System;
using System.Windows.Forms;

namespace FileManager
{
    // 文件创建和重命名的窗体类
    public partial class FileCreator : Form
    {
        private readonly Catalog _curCatalog; // 当前目录对象
        private readonly string _fileName; // 文件名
        private readonly string _fileType; // 文件类型
        public enum OperationType { Newfile, Rename } // 操作类型枚举：新建文件或重命名

        private readonly OperationType _operationType; // 操作类型
        public DelegateMethod.DelegateFunction CallBack; // 委托回调函数

        // 构造函数初始化
        public FileCreator(ref Catalog currentCatalog, string name, string type, OperationType otype)
        {
            InitializeComponent();
            _curCatalog = currentCatalog; // 设置当前目录
            textBox1.Text = name; // 初始化文本框为传入的名称
            _fileName = name; // 设置文件名
            _fileType = type; // 设置文件类型
            _operationType = otype; // 设置操作类型
        }

        // 执行回调函数，更新父目录时间戳
        private void callBack()
        {
            if (CallBack == null) return;
            if (_curCatalog.parenCatalog != null)
            {
                _curCatalog.parenCatalog.updatedTime = DateTime.Now;
            }
            CallBack();
        }

        // 名称重复检查，如果存在重复，则加上计数后缀
        private string NameCheck(string name, string type)
        {
            var counter = 0;
            if (type == "")
            {
                for (var i = 0; i < _curCatalog.nodelist.Count; i += 1)
                {
                    if (_curCatalog.nodelist[i].nodeType != Node.NodeType.folder) continue;
                    var sArray = _curCatalog.nodelist[i].folder.name.Split('(');
                    if (sArray[0] == name)
                    {
                        counter++;
                    }
                }
            }
            else
            {
                for (var i = 0; i < _curCatalog.nodelist.Count; i += 1)
                {
                    if (_curCatalog.nodelist[i].nodeType != Node.NodeType.file) continue;
                    var sArray = _curCatalog.nodelist[i].file.name.Split('(');
                    if (sArray[0] == name)
                    {
                        counter++;
                    }
                }
            }
            if (counter > 0)
                name += "(" + counter + ")";
            return name;
        }

        // 保存按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            var fatherPath = _curCatalog.path;
            
            textBox1.Text = NameCheck(textBox1.Text, _fileType); // 检查并更新名称以避免重名
            switch (_operationType)
            {
                case OperationType.Newfile when _fileType == "":
                    _curCatalog.addNode(_curCatalog, textBox1.Text, fatherPath);
                    break;
                case OperationType.Newfile:
                    _curCatalog.addNode(textBox1.Text, _fileType, fatherPath);
                    break;
                case OperationType.Rename:
                    switch (_fileType)
                    {
                        case "":
                        {
                            for (var i = 0; i < _curCatalog.nodelist.Count; i += 1)
                            {
                                if (_curCatalog.nodelist[i].name != _fileName ||
                                    _curCatalog.nodelist[i].nodeType != Node.NodeType.folder) continue;
                                _curCatalog.nodelist[i].ReName(textBox1.Text);
                                break;
                            }

                            break;
                        }
                        case "txt":
                        {
                            for (var i = 0; i < _curCatalog.nodelist.Count; i += 1)
                            {
                                if (_curCatalog.nodelist[i].name != _fileName ||
                                    _curCatalog.nodelist[i].nodeType != Node.NodeType.file) continue;
                                _curCatalog.nodelist[i].ReName(textBox1.Text);
                                break;
                            }

                            break;
                        }
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
         
            callBack(); // 执行回调
            Close(); // 关闭窗口
        }
    }

    // 委托方法类
    public abstract class DelegateMethod
    {
        public delegate void DelegateFunction(); // 委托函数定义
    }
}
