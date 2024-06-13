
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FileManager
{
    partial class FileAttributes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FileAttributes));
            this.textBox1 = new TextBox();
            this.pictureBox1 = new PictureBox();
            this.imageList1 = new ImageList(this.components);
            this.textBox2 = new TextBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.textBox3 = new TextBox();
            this.button3 = new Button();
            this.textBox4 = new TextBox();
            this.button4 = new Button();
            this.textBox5 = new TextBox();
            this.button5 = new Button();
            this.textBox6 = new TextBox();
            this.button6 = new Button();
            this.button7 = new Button();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = BorderStyle.FixedSingle;
            this.textBox1.ForeColor = SystemColors.WindowText;
            this.textBox1.Location = new Point(102, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(262, 25);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Location = new Point(12, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(35, 32);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "txt.jpg");
            this.imageList1.Images.SetKeyName(1, "folder.jpg");
            // 
            // textBox2
            // 
            this.textBox2.Location = new Point(102, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(262, 25);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Location = new Point(9, 72);
            this.button1.Margin = new Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(90, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "文件类型:";
            this.button1.TextAlign = ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.Location = new Point(9, 119);
            this.button2.Margin = new Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new Size(90, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "位置：";
            this.button2.TextAlign = ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(102, 122);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(262, 25);
            this.textBox3.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.Location = new Point(9, 166);
            this.button3.Margin = new Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new Size(90, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "大小:";
            this.button3.TextAlign = ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Point(102, 169);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(262, 25);
            this.textBox4.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = FlatStyle.Flat;
            this.button4.Location = new Point(9, 207);
            this.button4.Margin = new Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new Size(90, 28);
            this.button4.TabIndex = 11;
            this.button4.Text = "创建时间:";
            this.button4.TextAlign = ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new Point(102, 210);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Size(262, 25);
            this.textBox5.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = FlatStyle.Flat;
            this.button5.Location = new Point(9, 249);
            this.button5.Margin = new Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new Size(90, 28);
            this.button5.TabIndex = 13;
            this.button5.Text = "修改时间:";
            this.button5.TextAlign = ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new Point(102, 252);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Size(262, 25);
            this.textBox6.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new Point(182, 314);
            this.button6.Name = "button6";
            this.button6.Size = new Size(75, 30);
            this.button6.TabIndex = 14;
            this.button6.Text = "确定";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new Point(272, 314);
            this.button7.Name = "button7";
            this.button7.Size = new Size(75, 30);
            this.button7.TabIndex = 15;
            this.button7.Text = "取消";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(this.button7_Click);
            // 
            // FileAttributes
            // 
            this.AutoScaleDimensions = new SizeF(8F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(370, 349);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "FileAttributes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "FileAttributes";
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private Button button3;
        private TextBox textBox4;
        private Button button4;
        private TextBox textBox5;
        private Button button5;
        private TextBox textBox6;
        private Button button6;
        private Button button7;
    }
}