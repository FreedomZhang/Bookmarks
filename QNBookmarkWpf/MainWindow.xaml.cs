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
        private void Test_OnClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Users\z8489\Desktop\Bookmarks";
            string str = StringConvert.FileRead(filePath);
            ChromeBookmarks chromeBookmarks = (ChromeBookmarks)StringConvert.JsonToList<ChromeBookmarks>(str);
            BookmarksData bookmarksData = new BookmarksData();
            _myBookmarkses = bookmarksData.GetBookmarkses(chromeBookmarks);
            ConteView.ItemsSource = _myBookmarkses;
        }

        private void MenuVisit_OnClick(object sender, RoutedEventArgs e)
        {
            MyBookmarks myBookmarks = (MyBookmarks) ConteView.SelectedItems[0];

            System.Diagnostics.Process.Start(myBookmarks.Url);
        }

        private void Setting_OnClick(object sender, RoutedEventArgs e)
        {
            QNBookmarkWpf.Setting setting=new Setting();
            setting.ShowDialog();
        }
    }
}
