using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yaohuasoft.Framework.Web
{
    public partial class UC_PluploadSingle : System.Web.UI.UserControl
    {
        /// <summary>
        /// 判断页面类型(读写,只写，只读)
        /// </summary>
        private string pageType = "可写";

        public string PageType
        {
            get
            {
                switch (pageType)
                {
                    case "可写":
                    case "只读":
                        return pageType;
                    default:
                        return "可写";
                }
            }
            set { pageType = value; }
        }
        /// <summary>
        /// 是不是需要图片附加pdf
        /// </summary>
        private bool isPicPdf = false;

        public bool IsPicPdf
        {
            get
            {
                return isPicPdf;
            }
            set { isPicPdf = value; }
        }
        private string uploadUrl = "";

        public string UploadUrl
        {
            get { return uploadUrl; }
            set { uploadUrl = value; }
        }

        public string GetUploadUrl
        {
            get
            {
                return UploaderFileUrl.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //上传路径的初始化判断    
            if (string.IsNullOrEmpty(UploaderFileUrl.Value))
            {
                UploaderFileUrl.Value = UploadUrl;
            }
            else
            {
                UploadUrl = UploaderFileUrl.Value;
            }

            //页面类型的初始化判断
            if (string.IsNullOrEmpty(HiddenPageType.Value))
            {
                HiddenPageType.Value = PageType;
            }
            else
            {
                PageType = HiddenPageType.Value;
            }
        }
    }
}