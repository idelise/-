
namespace 数据库实验3
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
            this.tableshow = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.access路径 = new System.Windows.Forms.TextBox();
            this.sqlite路径 = new System.Windows.Forms.TextBox();
            this.格式转换 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.entityConnection1 = new System.Data.Entity.Core.EntityClient.EntityConnection();
            this.选择要转换的表 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sqltalk = new System.Windows.Forms.RichTextBox();
            this.sql语句 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableshow)).BeginInit();
            this.SuspendLayout();
            // 
            // tableshow
            // 
            this.tableshow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableshow.Location = new System.Drawing.Point(22, 459);
            this.tableshow.Name = "tableshow";
            this.tableshow.RowHeadersWidth = 82;
            this.tableshow.RowTemplate.Height = 40;
            this.tableshow.Size = new System.Drawing.Size(1021, 291);
            this.tableshow.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(874, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(874, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // access路径
            // 
            this.access路径.Location = new System.Drawing.Point(177, 38);
            this.access路径.Name = "access路径";
            this.access路径.Size = new System.Drawing.Size(659, 38);
            this.access路径.TabIndex = 3;
            // 
            // sqlite路径
            // 
            this.sqlite路径.Location = new System.Drawing.Point(177, 103);
            this.sqlite路径.Name = "sqlite路径";
            this.sqlite路径.Size = new System.Drawing.Size(659, 38);
            this.sqlite路径.TabIndex = 4;
            // 
            // 格式转换
            // 
            this.格式转换.Location = new System.Drawing.Point(445, 266);
            this.格式转换.Name = "格式转换";
            this.格式转换.Size = new System.Drawing.Size(150, 46);
            this.格式转换.TabIndex = 5;
            this.格式转换.Text = "格式转换";
            this.格式转换.UseVisualStyleBackColor = true;
            this.格式转换.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Access路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "SQLite路径";
            // 
            // 选择要转换的表
            // 
            this.选择要转换的表.FormattingEnabled = true;
            this.选择要转换的表.Location = new System.Drawing.Point(372, 151);
            this.选择要转换的表.Name = "选择要转换的表";
            this.选择要转换的表.Size = new System.Drawing.Size(309, 109);
            this.选择要转换的表.TabIndex = 8;
            this.选择要转换的表.SelectedIndexChanged += new System.EventHandler(this.选择要转换的表_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "选择要转换的表";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // sqltalk
            // 
            this.sqltalk.Location = new System.Drawing.Point(22, 318);
            this.sqltalk.Name = "sqltalk";
            this.sqltalk.Size = new System.Drawing.Size(659, 135);
            this.sqltalk.TabIndex = 10;
            this.sqltalk.Text = "";
            this.sqltalk.TextChanged += new System.EventHandler(this.sqltalk_TextChanged);
            // 
            // sql语句
            // 
            this.sql语句.AutoSize = true;
            this.sql语句.Location = new System.Drawing.Point(25, 274);
            this.sql语句.Name = "sql语句";
            this.sql语句.Size = new System.Drawing.Size(94, 31);
            this.sql语句.TabIndex = 11;
            this.sql语句.Text = "sql语句";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(687, 407);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 46);
            this.button3.TabIndex = 12;
            this.button3.Text = "查询";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(445, 763);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(150, 46);
            this.change.TabIndex = 13;
            this.change.Text = "更改";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 821);
            this.Controls.Add(this.change);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sql语句);
            this.Controls.Add(this.sqltalk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.选择要转换的表);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.格式转换);
            this.Controls.Add(this.sqlite路径);
            this.Controls.Add(this.access路径);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableshow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tableshow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableshow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox access路径;
        private System.Windows.Forms.TextBox sqlite路径;
        private System.Windows.Forms.Button 格式转换;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Data.Entity.Core.EntityClient.EntityConnection entityConnection1;
        private System.Windows.Forms.CheckedListBox 选择要转换的表;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox sqltalk;
        private System.Windows.Forms.Label sql语句;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button change;
    }
}

