using DataOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataOperation.Model;
using QiNiuWork;

namespace QNBookmarkWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<MyBookmarks> _myBookmarkses;
        private ConfigModel _configModel = ConfigDataService.ConfigData;

        private void Test_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_configModel?.FilePath))
            {
                ChromeBookmarks chromeBookmarks =
                    (ChromeBookmarks)StringConvert.JsonToList<ChromeBookmarks>(
                        StringConvert.FileRead(_configModel.FilePath));
                BookmarksData bookmarksData = new BookmarksData();
                _myBookmarkses = bookmarksData.GetBookmarkses(chromeBookmarks);
                ConteView.ItemsSource = _myBookmarkses;
            }
            else
            {
                MessageBox.Show("请先设置书签文件地址");
            }

        }

        private void MenuVisit_OnClick(object sender, RoutedEventArgs e)
        {
            MyBookmarks myBookmarks = (MyBookmarks)ConteView.SelectedItems[0];

            System.Diagnostics.Process.Start(myBookmarks.Url);
        }

        private void Setting_OnClick(object sender, RoutedEventArgs e)
        {
            QNBookmarkWpf.Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void SysT_OnClick(object sender, RoutedEventArgs e)
        {
            if (QiNiuWorkUtil.HttpDownload(_configModel.DownloadUrl, "data.js"))
            {
                if (BookmarksData.ContrastBookmarks(_myBookmarkses))
                {
                    QiNiuWork.QiNiuWorkUtil qiNiuWork = new QiNiuWork.QiNiuWorkUtil();
                    QiNiuConfig qiNiuConfig = new QiNiuConfig();
                    qiNiuConfig.AK = _configModel.QiNiuAccessKey;
                    qiNiuConfig.SK = _configModel.QiNiuSecretKey;
                    qiNiuConfig.Bucket = _configModel.QiNiuSpace;
                    qiNiuConfig.UploadH = UploadFileMessge;
                    qiNiuWork.UploadFile(qiNiuConfig);
                }
            }
        }

        private void UploadFileMessge()
        {
            MessageBox.Show("上传完成");
        }

        private void Download_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(QiNiuWorkUtil.HttpDownload(_configModel.DownloadUrl, "data.js")
                ? "下载完成"
                : "下载失败");
        }
    }
}
