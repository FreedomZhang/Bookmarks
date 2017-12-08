using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            file_textpath.Text = @"C:\Users\Geekray\AppData\Local\Google\Chrome\User Data\Default\Bookmarks";
        }

        private List<MyBookmarks> _myBookmarkses;
        private void textBox1_Click(object sender, EventArgs e)
        {
            o_FileDialog.ShowDialog();
            file_textpath.Text = o_FileDialog.FileName;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            string filePath = file_textpath.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("请选择书签文件");
            }
            else
            {
                if (File.Exists(filePath))
                {
                    string str = StringConvert.FileRead(filePath);
                    ChromeBookmarks chromeBookmarks = (ChromeBookmarks)StringConvert.JsonToList<ChromeBookmarks>(str);
                    BookmarksData bookmarksData = new BookmarksData();
                    _myBookmarkses = bookmarksData.GetBookmarkses(chromeBookmarks);
                    dataG_Man.DataSource = _myBookmarkses;
                }
                else
                {
                    MessageBox.Show("当前文件不存在");
                }


            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            s_FileDialog.ShowDialog();
            string savePath = s_FileDialog.FileName;
            if (!string.IsNullOrEmpty(savePath))
            {
                //if (File.Exists(savePath) && MessageBox.Show("当前文件已存在将会被覆盖是否继续？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //{
                //    return;
                //}
                MessageBox.Show(BookmarksData.SaveMyBookmarksToJsonFile(_myBookmarkses, savePath)
                    ? "保存成功"
                    : "保存失败");
            }
            else
            {
                MessageBox.Show("请选择保存位置");
            }
        }

        private void btn_serc_Click(object sender, EventArgs e)
        {
            if (_myBookmarkses == null || _myBookmarkses.Count == 0)
            {
                MessageBox.Show("请先加载文件");
            }
            else
            {
                string src = txt_serc.Text.Trim();
                if (!string.IsNullOrEmpty(src))
                {
                    var list = _myBookmarkses.Where(a => a.Name.Contains(src)).ToList();
                    dataG_Man.DataSource = list;
                }
                else
                {
                    dataG_Man.DataSource = _myBookmarkses;
                }
            }
        }

        private void t_Menu_del_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂无");
        }

        private void t_Menu_Visit_Click(object sender, EventArgs e)
        {
            string str = dataG_Man.SelectedRows[0].Cells["Url"].Value.ToString();
            System.Diagnostics.Process.Start(str);
        }


    }
}
