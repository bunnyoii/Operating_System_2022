
using System.ComponentModel;
using System.Windows.Forms;

namespace FileManager
{
    partial class FileManager
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CausalityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReturnToolStripMenuItem,
            this.FormatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ReturnToolStripMenuItem
            // 
            this.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem";
            this.ReturnToolStripMenuItem.Size = new System.Drawing.Size(38, 24);
            this.ReturnToolStripMenuItem.Text = "⬅️";
            this.ReturnToolStripMenuItem.Click += new System.EventHandler(this.ReturnToolStripMenuItemClick);
            // 
            // FormatToolStripMenuItem
            // 
            this.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem";
            this.FormatToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.FormatToolStripMenuItem.Text = "格式化";
            this.FormatToolStripMenuItem.Click += new System.EventHandler(this.FormatToolStripMenuItemClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.NewToolStripMenuItem1,
            this.DeleteToolStripMenuItem,
            this.RenameToolStripMenuItem,
            this.CausalityToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip3";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 196);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.OpenToolStripMenuItem.Text = "打开";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.RefreshToolStripMenuItem.Text = "刷新";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // NewToolStripMenuItem1
            // 
            this.NewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FolderToolStripMenuItem1,
            this.FileToolStripMenuItem2});
            this.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1";
            this.NewToolStripMenuItem1.Size = new System.Drawing.Size(123, 24);
            this.NewToolStripMenuItem1.Text = "新建";
            // 
            // FolderToolStripMenuItem1
            // 
            this.FolderToolStripMenuItem1.Name = "FolderToolStripMenuItem1";
            this.FolderToolStripMenuItem1.Size = new System.Drawing.Size(152, 26);
            this.FolderToolStripMenuItem1.Text = "文件夹";
            this.FolderToolStripMenuItem1.Click += new System.EventHandler(this.FolderToolStripMenuItem1Click);
            // 
            // FileToolStripMenuItem2
            // 
            this.FileToolStripMenuItem2.Name = "FileToolStripMenuItem2";
            this.FileToolStripMenuItem2.Size = new System.Drawing.Size(152, 26);
            this.FileToolStripMenuItem2.Text = "文本文件";
            this.FileToolStripMenuItem2.Click += new System.EventHandler(this.FileToolStripMenuItem2Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.DeleteToolStripMenuItem.Text = "删除";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.RenameToolStripMenuItem.Text = "重命名";
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItemClick);
            // 
            // CausalityToolStripMenuItem
            // 
            this.CausalityToolStripMenuItem.Name = "CausalityToolStripMenuItem";
            this.CausalityToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.CausalityToolStripMenuItem.Text = "属性";
            this.CausalityToolStripMenuItem.Click += new System.EventHandler(this.CausalityToolStripMenuItemClick);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(12, 61);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(205, 368);
            this.treeView1.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "txt.jpg");
            this.imageList1.Images.SetKeyName(1, "folder.jpg");
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(214, 61);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(620, 368);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "修改日期";
            this.columnHeader2.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "大小";
            this.columnHeader4.Width = 156;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前路径：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(683, 25);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(12, 435);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(822, 18);
            this.textBox2.TabIndex = 5;
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 460);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileManager_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem RenameToolStripMenuItem;
        private TreeView treeView1;
        private ToolStripMenuItem FormatToolStripMenuItem;
        private ListView listView1;
        private ImageList imageList1;
        private ToolStripMenuItem NewToolStripMenuItem1;
        private ToolStripMenuItem FileToolStripMenuItem2;
        private ToolStripMenuItem FolderToolStripMenuItem1;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private Label label1;
        private TextBox textBox1;
        private ToolStripMenuItem ReturnToolStripMenuItem;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox textBox2;
        private ToolStripMenuItem CausalityToolStripMenuItem;
        private ToolStripMenuItem RefreshToolStripMenuItem;
        private ToolStripMenuItem 复制ToolStripMenuItem;
        private ToolStripMenuItem 粘贴ToolStripMenuItem;
    }
}
