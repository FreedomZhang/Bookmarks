using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataOperation;
using DataOperation.Model;

namespace QNBookmarkWpf
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
            LoadData();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            if (_configModel != null)
            {
                filePath.Text = _configModel.FilePath;
                qinAK.Text = _configModel.QiNiuAccessKey;
                qinSK.Text = _configModel.QiNiuSecretKey;
                qinfilework.Text = _configModel.QiNiuSpace;
            }
        }

        private ConfigModel _configModel = ConfigDataService.ConfigData;

        private void FilePath_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath.Text = openFileDialog1.FileName;
                _configModel.FilePath = filePath.Text;
            }
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            _configModel.QiNiuAccessKey = qinAK.Text;
            _configModel.QiNiuSecretKey = qinSK.Text;
            _configModel.QiNiuSpace = qinfilework.Text;
            MessageBox.Show(ConfigDataService.SaveConfigData() ? "保存成功" : "保存失败");
        }
    }
}
