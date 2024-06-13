using System;
using System.Windows.Forms;

namespace FileManager
{
    // 文本编辑器窗体
    public partial class TxtEditor : Form
    {
        private BitMap _bitmap; // 用于管理文件数据块的位图
        private readonly File _txtFile; // 表示正在编辑的文件
        public DelegateMethod.DelegateFunction CallBack; // 回调函数委托

        // 默认构造函数
        public TxtEditor()
        {
            InitializeComponent();
        }

        // 带参数的构造函数，用于初始化文本编辑器并显示文件内容
        public TxtEditor(ref BitMap bitMap, ref File file)
        {
            InitializeComponent();
            _bitmap = bitMap;
            _txtFile = file;
            ShowContent(); // 显示文件内容
        }

        // 显示文件内容
        private void ShowContent()
        {
            richTextBox1.Text = _txtFile.getFileContent();
        }

        // 执行回调函数
        private void callBack()
        {
            CallBack?.Invoke();
        }

        // 保存按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            // 弹出确认保存对话框
            if (MessageBox.Show(@"保存更改?", @"提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 保存更改到文件
                _txtFile.writeFile(richTextBox1.Text, ref _bitmap);
                // 更新文件的修改时间
                _txtFile.updatedTime = DateTime.Now;
            }

            callBack(); // 执行回调函数
            Close(); // 关闭编辑窗口
        }

        // 取消按钮点击事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            Close(); // 关闭编辑窗口
        }
    }
}