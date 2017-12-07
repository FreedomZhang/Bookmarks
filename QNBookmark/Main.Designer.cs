namespace QNBookmark
{
    partial class man
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
            this.dataG_Man = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_save = new System.Windows.Forms.Button();
            this.s_FileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lab_path = new System.Windows.Forms.Label();
            this.lab_serc = new System.Windows.Forms.Label();
            this.txt_serc = new System.Windows.Forms.TextBox();
            this.btn_serc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataG_Man)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // o_FileDialog
            // 
            this.o_FileDialog.FileName = "选择文件";
            // 
            // file_textpath
            // 
            this.file_textpath.Location = new System.Drawing.Point(83, 9);
            this.file_textpath.Name = "file_textpath";
            this.file_textpath.Size = new System.Drawing.Size(262, 21);
            this.file_textpath.TabIndex = 0;
            this.file_textpath.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(360, 7);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(75, 23);
            this.btn_Read.TabIndex = 1;
            this.btn_Read.Text = "读取文件";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // dataG_Man
            // 
            this.dataG_Man.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataG_Man.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataG_Man.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataG_Man.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataG_Man.Location = new System.Drawing.Point(0, 0);
            this.dataG_Man.Name = "dataG_Man";
            this.dataG_Man.RowTemplate.Height = 23;
            this.dataG_Man.Size = new System.Drawing.Size(638, 199);
            this.dataG_Man.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Url";
            this.Column2.HeaderText = "地址";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Type";
            this.Column3.HeaderText = "分类";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Source";
            this.Column4.HeaderText = "来源";
            this.Column4.Name = "Column4";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_serc);
            this.splitContainer1.Panel1.Controls.Add(this.txt_serc);
            this.splitContainer1.Panel1.Controls.Add(this.lab_serc);
            this.splitContainer1.Panel1.Controls.Add(this.lab_path);
            this.splitContainer1.Panel1.Controls.Add(this.btn_save);
            this.splitContainer1.Panel1.Controls.Add(this.file_textpath);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Read);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataG_Man);
            this.splitContainer1.Size = new System.Drawing.Size(638, 282);
            this.splitContainer1.SplitterDistance = 79;
            this.splitContainer1.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(460, 7);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "保存文件";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // s_FileDialog
            // 
            this.s_FileDialog.Filter = "|*.json";
            // 
            // lab_path
            // 
            this.lab_path.AutoSize = true;
            this.lab_path.Location = new System.Drawing.Point(12, 12);
            this.lab_path.Name = "lab_path";
            this.lab_path.Size = new System.Drawing.Size(65, 12);
            this.lab_path.TabIndex = 3;
            this.lab_path.Text = "选择文件：";
            // 
            // lab_serc
            // 
            this.lab_serc.AutoSize = true;
            this.lab_serc.Location = new System.Drawing.Point(14, 37);
            this.lab_serc.Name = "lab_serc";
            this.lab_serc.Size = new System.Drawing.Size(65, 12);
            this.lab_serc.TabIndex = 4;
            this.lab_serc.Text = "名称查询：";
            // 
            // txt_serc
            // 
            this.txt_serc.Location = new System.Drawing.Point(83, 37);
            this.txt_serc.Name = "txt_serc";
            this.txt_serc.Size = new System.Drawing.Size(262, 21);
            this.txt_serc.TabIndex = 5;
            // 
            // btn_serc
            // 
            this.btn_serc.Location = new System.Drawing.Point(360, 34);
            this.btn_serc.Name = "btn_serc";
            this.btn_serc.Size = new System.Drawing.Size(75, 23);
            this.btn_serc.TabIndex = 6;
            this.btn_serc.Text = "查询";
            this.btn_serc.UseVisualStyleBackColor = true;
            this.btn_serc.Click += new System.EventHandler(this.btn_serc_Click);
            // 
            // man
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 282);
            this.Controls.Add(this.splitContainer1);
            this.Name = "man";
            this.Text = "书签处理";
            ((System.ComponentModel.ISupportInitialize)(this.dataG_Man)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog o_FileDialog;
        private System.Windows.Forms.TextBox file_textpath;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.DataGridView dataG_Man;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.SaveFileDialog s_FileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btn_serc;
        private System.Windows.Forms.TextBox txt_serc;
        private System.Windows.Forms.Label lab_serc;
        private System.Windows.Forms.Label lab_path;
    }
}

