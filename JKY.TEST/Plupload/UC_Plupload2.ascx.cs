using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yaohuasoft.Framework.Web
{
    public partial class UC_Plupload2 : System.Web.UI.UserControl
    {
        /// <summary>
        /// 判断页面类型(读写,只写，只读)
        /// </summary>
        private string pageType = "只写";

        public string PageType
        {
            get
            {
                switch (pageType)
                {
                    case "读写":
                    case "只写":
                    case "只读":
                        return pageType;
                    default:
                        return "读写";
                }
            }
            set { pageType = value; }
        }
        /// <summary>
        /// 是否为图片模式
        /// </summary>
        private bool isPicMode = false;

        public bool IsPicMode
        {
            get { return isPicMode; }
            set { isPicMode = value; }
        }
        /// <summary>
        /// 是不是需要图片附加pdf
        /// </summary>
        private bool isPicPdf = false;

        public bool IsPicPdf
        {
            get
            {
                return isPicMode ? isPicPdf : false;
            }
            set { isPicPdf = value; }
        }

        /// <summary>
        /// 上传图片路径
        /// </summary>
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