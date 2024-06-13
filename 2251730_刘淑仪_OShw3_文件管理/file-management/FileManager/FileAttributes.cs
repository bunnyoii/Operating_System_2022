using System;
using System.Globalization;
using System.Windows.Forms;

namespace FileManager
{
    // 文件属性窗口类
    public partial class FileAttributes : Form
    {
        // 构造函数，初始化文件或文件夹的属性显示
        public FileAttributes(Node node)
        {
            InitializeComponent();
            // 判断节点类型是文件还是文件夹，并据此显示不同的属性
            if (node.nodeType == Node.NodeType.file)
            {
                pictureBox1.Image = imageList1.Images[0];  // 文件图标
                textBox1.Text = node.file.name + @".txt";  // 文件全名
                textBox2.Text = @".txt";                   // 文件类型
                textBox3.Text = node.file.path.Substring(0, node.file.path.Length - node.file.name.Length);  // 文件路径
                textBox4.Text = node.file.size + @" B";    // 文件大小
                textBox5.Text = node.file.createdTime.ToString(CultureInfo.InvariantCulture);  // 创建时间
                textBox6.Text = node.file.updatedTime.ToString(CultureInfo.InvariantCulture);  // 更新时间
            }
            else
            {
                pictureBox1.Image = imageList1.Images[1];  // 文件夹图标
                textBox1.Text = node.folder.name;          // 文件夹名称
                textBox2.Text = @"文件夹";                  // 类型为文件夹
                textBox3.Text = node.folder.path.Substring(0, node.folder.path.Length - node.folder.name.Length);  // 文件夹路径
                textBox4.Text = node.folder.childrenNum + @"个子项";  // 子项数量
                textBox5.Text = node.folder.createdTime.ToString(CultureInfo.InvariantCulture);  // 创建时间
                textBox6.Text = node.folder.updatedTime.ToString(CultureInfo.InvariantCulture);  // 更新时间
            }
        }

        // 关闭按钮事件处理
        private void button6_Click(object sender, EventArgs e)
        {
            Close();  // 关闭窗口
        }

        // 另一个关闭按钮事件处理
        private void button7_Click(object sender, EventArgs e)
        {
            Close();  // 关闭窗口
        }
    }
}