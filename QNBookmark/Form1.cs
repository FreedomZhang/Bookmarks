using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataOperation;
using DataOperation.Model;

namespace QNBookmark
{
    public partial class man : Form
    {
        public man()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            o_FileDialog.ShowDialog();
            file_textpath.Text = o_FileDialog.FileName;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(file_textpath.Text))
            {
                MessageBox.Show("请选择书签文件");
            }
            else
            {
                string str = StringConvert.FileRead(file_textpath.Text);
                ChromeBookmarks chromeBookmarks = (ChromeBookmarks)StringConvert.JsonToList<ChromeBookmarks>(str);

                BookmarksData bookmarksData = new BookmarksData();
                var list = bookmarksData.GetBookmarkses(chromeBookmarks);

                dataG_Man.DataSource = list;
                

                MessageBox.Show(list.Count.ToString());
            }

        }
    }
}
