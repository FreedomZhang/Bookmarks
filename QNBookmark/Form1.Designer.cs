namespace QNBookmark
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.o_FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.file_textpath = new System.Windows.Forms.TextBox();
            this.btn_Read = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // o_FileDialog
            // 
            this.o_FileDialog.FileName = "选择文件";
            // 
            // file_textpath
            // 
            this.file_textpath.Location = new System.Drawing.Point(34, 21);
            this.file_textpath.Name = "file_textpath";
            this.file_textpath.Size = new System.Drawing.Size(262, 21);
            this.file_textpath.TabIndex = 0;
            this.file_textpath.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(329, 21);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(75, 23);
            this.btn_Read.TabIndex = 1;
            this.btn_Read.Text = "读取文件";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 282);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.file_textpath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog o_FileDialog;
        private System.Windows.Forms.TextBox file_textpath;
        private System.Windows.Forms.Button btn_Read;
    }
}

