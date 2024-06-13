using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FileManager : Form
    {
        private TreeNode _rootNode;
        private BitMap _bitmap = new BitMap();
        private Catalog _rootCatalog = new Catalog("root");
        private Catalog _curCatalog;
        private List<ListViewItem> _listViewItems = new List<ListViewItem>();
        private readonly string _dir = Application.StartupPath;

        public FileManager()
        {
            // 初始化组件
            InitializeComponent();

            // 注册树视图节点点击事件
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            
            // 检查存储目录是否存在，如果不存在则创建
            if (!Directory.Exists(Path.Combine(_dir, "storage")))
                Directory.CreateDirectory(Path.Combine(_dir, "storage"));

            // 创建一个二进制格式化器用于序列化和反序列化
            var bf = new BinaryFormatter();

            // 检查根目录和位图文件是否存在
            if (System.IO.File.Exists(Path.Combine(_dir, "storage/rootCatalog.txt")) &&
                System.IO.File.Exists(Path.Combine(_dir, "storage/bitMap.txt")))
            {
                // 打开根目录文件并反序列化为 Catalog 对象
                var f1 = new FileStream(Path.Combine(_dir, "storage/rootCatalog.txt"), FileMode.Open, FileAccess.Read,
                    FileShare.Read);
                _rootCatalog = bf.Deserialize(f1) as Catalog;
                f1.Close();

                // 打开位图文件并反序列化为 BitMap 对象
                var f2 = new FileStream(Path.Combine(_dir, "storage/bitMap.txt"), FileMode.Open, FileAccess.Read,
                    FileShare.Read);
                _bitmap = bf.Deserialize(f2) as BitMap;
                f2.Close();
            }

            // 将当前目录设为根目录
            _curCatalog = _rootCatalog;

            // 更新文本框显示当前路径
            textBox1.Text = TrimPath(_curCatalog.path);

            // 更新树视图和列表视图
            UpdateTreeView();
            UpdateListView();
        }

        private void FileManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 创建一个二进制格式化器用于序列化
            var bf = new BinaryFormatter();

            // 打开根目录文件，如果不存在则创建，并将 _rootCatalog 序列化写入文件
            var f1 = new FileStream(Path.Combine(_dir, "storage/rootCatalog.txt"), FileMode.Create);
            bf.Serialize(f1, _rootCatalog);
            f1.Close();

            // 打开位图文件，如果不存在则创建，并将 _bitmap 序列化写入文件
            var f2 = new FileStream(Path.Combine(_dir, "storage/bitMap.txt"), FileMode.Create);
            bf.Serialize(f2, _bitmap);
            f2.Close();
        }

        private string TrimPath(string path)
        {
            // 初始化修剪后的路径变量
            var trimedPath = path;

            // 如果路径长度小于或等于6，直接返回原路径
            if (path.Length <= 6) return trimedPath;

            // 获取路径的前5个字符作为根路径
            var root = path.Substring(0, 5);

            // 获取从第6个字符开始的路径详情
            var detail = path.Substring(5);

            // 重新组合根路径和路径详情
            trimedPath = root + detail;

            // 返回修剪后的路径
            return trimedPath;
        }

        //更新视图
        private void UpdateView()
        {
            UpdateTreeView();
            UpdateListView();
            textBox1.Text = TrimPath(_curCatalog.path);
        }

        // 更新文件目录树视图
        private void UpdateTreeView()
        {
            // 清空树视图的所有节点
            treeView1.Nodes.Clear();

            // 创建一个新的根节点并命名为 "root"
            _rootNode = new TreeNode("root") { Tag = _rootCatalog.path };

            // 递归添加子节点，从根目录开始
            AddTreeNode(_rootNode, _rootCatalog);

            // 将根节点添加到树视图的节点集合中
            treeView1.Nodes.Add(_rootNode);

            // 展开根节点下的所有子节点
            _rootNode.ExpandAll();
        }

        //更新视图目录
        private void UpdateListView()
        {
            _listViewItems = new List<ListViewItem>();
            listView1.Items.Clear();
            if (_curCatalog.nodelist != null)
            {
                foreach (var t in _curCatalog.nodelist)
                {
                    ListViewItem file;
                    if (t.nodeType == Node.NodeType.file)
                    {
                        file = new ListViewItem(new[]
                        {
                            t.file.name + ".txt",
                            t.file.updatedTime.ToString(CultureInfo.InvariantCulture),
                            "文本文件",
                            t.file.size + " B"
                        })
                        {
                            ImageIndex = 0
                        };
                    }
                    else
                    {
                        file = new ListViewItem(new[]
                        {
                            t.folder.name,
                            t.folder.updatedTime.ToString(CultureInfo.InvariantCulture),
                            "文件夹",
                            "-"
                        })
                        {
                            ImageIndex = 1
                        };
                    }

                    _listViewItems.Add(file);
                    listView1.Items.Add(file);
                }
            }

            textBox2.Text = @"  " + listView1.Items.Count + @"个项目";
        }
        
        //递归增加子结点
        private static void AddTreeNode(TreeNode node, Catalog dir)
        {
            if (dir.nodelist == null) return;
            foreach (var t in dir.nodelist)
            {
                if (t.nodeType != Node.NodeType.folder) continue;
                var newNode = new TreeNode(t.name) { Tag = t.folder.path };
                AddTreeNode(newNode, t.folder);
                node.Nodes.Add(newNode);
            }
        }

        // 树视图节点点击事件处理函数
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;

            // 获取点击的节点路径
            var nodePath = e.Node.Tag.ToString();

            // 在当前目录中查找匹配的节点并设置为当前目录
            var node = FindNodeByPath(_rootCatalog, nodePath);
            if (node == null || node.nodeType != Node.NodeType.folder) return;
            _curCatalog = node.folder;
            textBox1.Text = TrimPath(_curCatalog.path);
            UpdateListView();
        }

        // 获取树节点的完整路径
        private string GetFullPathFromNode(TreeNode node)
        {
            var path = node.Text;
            while (node.Parent != null)
            {
                node = node.Parent;
                path = node.Text + "\\" + path;
            }

            return path;
        }

        // 根据路径查找节点
        private Node FindNodeByPath(Catalog catalog, string path)
        {
            return catalog.path == path
                ? new Node(catalog.name, catalog.path) { folder = catalog, nodeType = Node.NodeType.folder }
                : (from node in catalog.nodelist
                    where node.nodeType == Node.NodeType.folder
                    select FindNodeByPath(node.folder, path)).FirstOrDefault(result => result != null);
        }

        // 视图项双击事件处理函数
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            // 获取选中的第一个项目
            var item = listView1.SelectedItems[0];

            // 遍历当前目录的节点列表，找到与选中项目匹配的节点
            for (var i = 0; i < _curCatalog.nodelist.Count; i++)
            {
                if (_listViewItems[i] != item) continue;
                var currentNode = _curCatalog.nodelist[i];
                OpenListViewItem(ref currentNode);
                break;
            }
        }

        //打开节点下视图
        private void OpenListViewItem(ref Node node)
        {
            if (node.nodeType == Node.NodeType.folder)
            {
                _curCatalog = node.folder;
                textBox1.Text = TrimPath(_curCatalog.path);
                UpdateListView();
            }
            else
            {
                var txtEditor = new TxtEditor(ref _bitmap, ref node.file);
                txtEditor.Show();
                txtEditor.CallBack = UpdateView;
            }
        }

        //检测重名
        private String nameCheck(String name, String type)
        {
            var counter = 0;
            if (type == "")
            {
                counter += (from t in _curCatalog.nodelist
                    where t.nodeType == Node.NodeType.folder
                    select t.folder.name.Split('(')).Count(sArray => sArray[0] == name);
            }
            else
            {
                counter += (from t in _curCatalog.nodelist
                    where t.nodeType == Node.NodeType.file
                    select t.file.name.Split('(')).Count(sArray => sArray[0] == name);
            }

            if (counter > 0)
                name += "(" + counter + ")";
            return name;
        }

        //返回按钮
        private void ReturnToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_curCatalog == _rootCatalog) return;
            _curCatalog = _curCatalog.parenCatalog;
            UpdateView();
        }

        //打开按钮
        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var item = listView1.SelectedItems[0];
            for (var i = 0; i < _curCatalog.nodelist.Count; i++)
            {
                if (_listViewItems[i] != item) continue;
                var curNode = _curCatalog.nodelist[i];
                OpenListViewItem(ref curNode);
                UpdataFolderSize(ref _curCatalog);
                break;
            }
        }

        private void UpdataFolderSize(ref Catalog curCatalog)
        {
            curCatalog.fileSize = 0;
            foreach (var t in curCatalog.nodelist)
            {
                if (t.nodeType == Node.NodeType.file)
                    curCatalog.fileSize += t.file.size;
                else
                    curCatalog.fileSize += t.folder.fileSize;
            }
        }

        private void FileToolStripMenuItem2Click(object sender, EventArgs e)
        {
            var fileName = @"新建文本文档";
            const string fileType = @"txt";
            fileName = nameCheck(fileName, fileType);
            var otype = FileCreator.OperationType.Newfile;
            var newfile = new FileCreator(ref _curCatalog, fileName, fileType, otype);
            newfile.Show();
            newfile.CallBack = UpdateView;
        }

        private void FolderToolStripMenuItem1Click(object sender, EventArgs e)
        {
            String fileName = @"新建文件夹";
            String fileType = "";
            fileName = nameCheck(fileName, fileType);
            var otype = FileCreator.OperationType.Newfile;
            var newfile = new FileCreator(ref _curCatalog, fileName, fileType, otype);
            newfile.Show();
            newfile.CallBack = UpdateView;
        }

        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            var fileType = @"txt";
            if (listView1.SelectedItems.Count == 0) return;
            var currentItem = listView1.SelectedItems[0];
            for (var i = 0; i < _curCatalog.nodelist.Count; i += 1)
            {
                if (_listViewItems[i] != currentItem) continue;
                if (_curCatalog.nodelist[i].nodeType == Node.NodeType.folder)
                {
                    fileType = "";
                }

                var op = FileCreator.OperationType.Rename;
                var newfile = new FileCreator(ref _curCatalog, _curCatalog.nodelist[i].name, fileType, op);
                newfile.Show();
                newfile.CallBack = UpdateView;
                break;
            }
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var item = listView1.SelectedItems[0];
            for (var i = 0; i < _curCatalog.nodelist.Count; i++)
            {
                if (_listViewItems[i] != item) continue;
                _curCatalog.updatedTime = DateTime.Now;
                Delete(ref _curCatalog.nodelist, i);
                UpdataFolderSize(ref _curCatalog);
                UpdateView();
                break;
            }
        }

        private void Delete(ref List<Node> nodelist, int i)
        {
            if (nodelist.Count <= 0) return;
            switch (nodelist[i].nodeType)
            {
                case Node.NodeType.file:
                    nodelist[i].file.setEmpty(ref _bitmap);
                    nodelist.RemoveAt(i);
                    break;
                case Node.NodeType.folder when nodelist[i].folder.nodelist != null:
                {
                    for (var j = 0; j < nodelist[i].folder.nodelist.Count; j++)
                    {
                        Delete(ref nodelist[i].folder.nodelist, j);
                    }

                    nodelist.RemoveAt(i);
                    break;
                }
                case Node.NodeType.folder:
                    nodelist.RemoveAt(i);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FormatToolStripMenuItemClick(object sender, EventArgs e)
        {
            Delete(ref _curCatalog.nodelist, 0);
            if (_rootCatalog.nodelist.Count != 0)
            {
                for (var i = 0; i < _rootCatalog.nodelist.Count; i++)
                {
                    Delete(ref _rootCatalog.nodelist, i);
                }
            }

            _rootCatalog = new Catalog("root");
            _curCatalog = _rootCatalog;
            UpdateView();
        }

        private void CausalityToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                var item = listView1.SelectedItems[0];
                for (var i = 0; i < _curCatalog.nodelist.Count; i++)
                {
                    if (_listViewItems[i] != item) continue;
                    var attributes = new FileAttributes(_curCatalog.nodelist[i]);
                    attributes.Show();
                }
            }
            else
            {
                if (_curCatalog.parenCatalog != null)
                {
                    foreach (var attributes in from t in _curCatalog.parenCatalog.nodelist
                             where t.name == _curCatalog.name
                             select new FileAttributes(t))
                    {
                        attributes.Show();
                    }
                }
                else
                {
                    MessageBox.Show(@"根目录");
                }
            }
        }

        private void RefreshToolStripMenuItemClick(object sender, EventArgs e)
        {
            UpdateView();
        }
    }

    [Serializable]
    public class File
    {
        public int size; // 大小
        public String name; // 文件名
        public DateTime createdTime; // 创建时间
        public DateTime updatedTime; // 修改时间
        public List<Block> blocklist; // 文件指针
        public String path;

        public File(String name, String type, String fatherPath)
        {
            this.name = name;
            createdTime = DateTime.Now;
            updatedTime = DateTime.Now;
            size = 0;
            blocklist = new List<Block>();
            path = fatherPath + "\\" + name;
        }

        public void setEmpty(ref BitMap bitmap)
        {
            for (int i = 0; i < blocklist.Count; i += 1)
            {
                bitmap.setFree(bitmap.findFreeBlock());
            }

            blocklist.Clear();
            size = 0;
        }

        public void writeFile(String data, ref BitMap bitmap)
        {
            setEmpty(ref bitmap);
            while (data.Length > 512)
            {
                bitmap.blocks[bitmap.findFreeBlock()] = new Block();
                bitmap.blocks[bitmap.findFreeBlock()].setData(data.Substring(0, 512));
                blocklist.Add(bitmap.blocks[bitmap.findFreeBlock()]);
                bitmap.setOccupy(bitmap.findFreeBlock());
                size += 512;
                data = data.Remove(0, 512);
            }

            bitmap.blocks[bitmap.findFreeBlock()] = new Block();
            bitmap.blocks[bitmap.findFreeBlock()].setData(data);
            blocklist.Add(bitmap.blocks[bitmap.findFreeBlock()]);
            bitmap.setOccupy(bitmap.findFreeBlock());
            size += data.Length;
            updatedTime = DateTime.Now;
        }

        public String getFileContent()
        {
            string content = "";
            for (int i = 0; i < blocklist.Count; i += 1)
            {
                content += blocklist[i].getData();
            }

            return content;
        }
    }

    [Serializable]
    public class BitMap
    {
        public const int BYTE_SIZE = 8;
        public const int MAX_CAPCITY = 100 * 100;
        public const int BYTENUMBER = 100 * 100 / 8;
        public Block[] blocks = new Block[MAX_CAPCITY];
        public bool[] bitMap = new bool[MAX_CAPCITY];

        public BitMap()
        {
            for (int i = 0; i < MAX_CAPCITY; i++)
            {
                bitMap[i] = true;
            }
        }

        public int findFreeBlock()
        {
            int bytePos = 0, bitPos = 0;
            while (bytePos < BYTENUMBER)
            {
                if (bitMap[bytePos * BYTE_SIZE + bitPos])
                {
                    return (bytePos * BYTE_SIZE + bitPos);
                }

                bitPos += 1;
                if (bitPos != BYTE_SIZE) continue;
                bitPos = bitPos % BYTE_SIZE;
                bytePos += 1;
            }

            return -1;
        }

        public void setFree(int i)
        {
            bitMap[i] = true;
        }

        public void setOccupy(int i)
        {
            bitMap[i] = false;
        }
    }

    [Serializable]
    public class Block
    {
        public const int BLOCKSIZE = 512;
        public char[] data = new char[BLOCKSIZE];
        public int length;

        public void setData(String newData)
        {
            length = (newData.Length > 512) ? 512 : newData.Length;
            for (var i = 0; i < length; i++)
            {
                data[i] = newData[i];
            }
        }

        public String getData()
        {
            String temp = new String(data);
            return temp;
        }
    }

    [Serializable]
    public class Catalog
    {
        public List<Node> nodelist;
        public int childrenNum;
        public String name;
        public String path;
        public int fileSize;
        public DateTime createdTime;
        public DateTime updatedTime;
        public Catalog parenCatalog;


        public Catalog(String namedata, String fatherPath)
        {
            nodelist = new List<Node>();
            name = namedata;
            path = fatherPath + '\\' + namedata;
            createdTime = DateTime.Now;
            updatedTime = DateTime.Now;
            fileSize = 0;
            childrenNum = 0;
        }


        public Catalog(String namedata)
        {
            nodelist = new List<Node>();
            name = namedata;
            path = namedata + ":";
            createdTime = DateTime.Now;
            updatedTime = DateTime.Now;
            fileSize = 0;
            childrenNum = 0;
        }


        public void addNode(Catalog catalog, String namedata, String fatherPath)
        {
            var node = new Node(namedata, fatherPath)
            {
                folder =
                {
                    parenCatalog = catalog
                }
            };
            nodelist.Add(node);
            childrenNum += 1;
            updatedTime = DateTime.Now;
        }


        public void addNode(String namedata, String fileType, String fatherPath)
        {
            var node = new Node(namedata, fileType, fatherPath);
            nodelist.Add(node);
            childrenNum += 1;
            updatedTime = DateTime.Now;
        }
    }

    [Serializable]
    public class Node
    {
        public enum NodeType
        {
            folder,
            file
        }

        public NodeType nodeType;
        public File file;
        public Catalog folder;
        public String path;
        public String name;

        public Node(String namedata, String fatherPath) //文件夹结点
        {
            nodeType = NodeType.folder;
            path = fatherPath + "\\" + namedata;
            name = namedata;
            folder = new Catalog(namedata, fatherPath);
        }

        public Node(String namedata, String fileType, String fatherPath) //文件结点
        {
            nodeType = NodeType.file;
            path = fatherPath + '\\' + namedata;
            name = namedata;
            file = new File(name, fileType, fatherPath);
        }

        public void ReName(String newName)
        {
            name = newName;
            if (nodeType == NodeType.folder)
            {
                folder.path = folder.path.Remove(folder.path.Length - folder.name.Length - 1, folder.name.Length + 1);
                folder.name = newName;
                folder.path = folder.path + "\\" + folder.name;
            }
            else
            {
                file.path = file.path.Remove(file.path.Length - file.name.Length - 1, file.name.Length + 1);
                file.name = newName;
                file.path = file.path + "\\" + file.name;
            }
        }
    }
}