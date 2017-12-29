using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using DataOperation;
using DataOperation.Model;
using QiNiuWork;

namespace BookmarkWindowsService
{
    public partial class BookmarkService : ServiceBase
    {
        public BookmarkService()
        {
            InitializeComponent();
        }
        private ConfigModel _configModel = ConfigDataService.ConfigData;
        protected override void OnStart(string[] args)
        {
            QiNiuWork.QiNiuWorkUtil qiNiuWork = new QiNiuWork.QiNiuWorkUtil();
            QiNiuConfig qiNiuConfig = new QiNiuConfig();
            qiNiuConfig.AK = _configModel.QiNiuAccessKey;
            qiNiuConfig.SK = _configModel.QiNiuSecretKey;
            qiNiuConfig.Bucket = _configModel.QiNiuSpace;
            //qiNiuConfig.LocalFile = @"C:\Users\z8489\Documents\GitHub\Bookmarks\QNBookmarkWpf\bin\Debug\config.json";
            qiNiuConfig.UploadH = UploadFileMessge;
            qiNiuWork.UploadFile(qiNiuConfig);
        }

        protected override void OnStop()
        {
        }
        private void UploadFileMessge()
        {
            
        }
    }
}
