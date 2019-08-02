using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace Yaohuasoft.Framework.BLL
{
    /// <summary>
    /// 文件上传处理类
    /// </summary>
    public partial class FileUploadService
    {


        static public string UploadExcel(FileUpload fileUpload)
        {
            //获取文件名
            string localFileName = fileUpload.FileName;
            //获取完整客户端文件路径
            string localFilePath = fileUpload.PostedFile.FileName;
            //上传文件类型
            string mimeType = fileUpload.PostedFile.ContentType;
            //上传文件大小
            string fileSize = fileUpload.PostedFile.ContentLength.ToString();
            //上传文件后缀名
            string fileType = localFileName.Substring(localFileName.LastIndexOf(".") + 1);

            ////服务端文件名
            string serverFileName = YaohuaID.NewID() + "." + fileType;

            ////随机路径
            string rndFilePath = "/_UploadExcel/" + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";

            ////上传到服务器上后的路径(实际路径)
            string serverFilePath = SystemConfig.RootPath + rndFilePath + serverFileName;

            //创建文件夹时用
            string dirPath = SystemConfig.RootPath + rndFilePath;
            //虚拟路径
            string urlPath = rndFilePath + serverFileName;
            //根据后缀名来限制上传类型
            if (fileType == "xls" || fileType == "xlsx")
            {
                //判断文件夹是否已经存在
                if (!System.IO.Directory.Exists(dirPath))
                {
                    //创建文件夹
                    System.IO.Directory.CreateDirectory(dirPath);
                }

                //上传文件到ipath这个路径里
                fileUpload.SaveAs(serverFilePath);

                return serverFilePath;
            }

            return "";

        }




        static public string UploadImage(FileUpload fileUpload)
        {
            //获取文件名
            string localFileName = fileUpload.FileName;
            //获取完整客户端文件路径
            string localFilePath = fileUpload.PostedFile.FileName;
            //上传文件类型
            string mimeType = fileUpload.PostedFile.ContentType;
            //上传文件大小
            string fileSize = fileUpload.PostedFile.ContentLength.ToString();
            //上传文件后缀名
            string fileType = localFileName.Substring(localFileName.LastIndexOf(".") + 1);

            ////服务端文件名
            string serverFileName = YaohuaID.NewID() + "." + fileType;

            ////随机路径
            string rndFilePath = "/_UploadImage/" + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";

            ////上传到服务器上后的路径(实际路径)
            string serverFilePath = SystemConfig.RootPath + rndFilePath + serverFileName;

            //创建文件夹时用
            string dirPath = SystemConfig.RootPath + rndFilePath;
            //虚拟路径
            string urlPath = rndFilePath + serverFileName;
            //根据后缀名来限制上传类型
            if (fileType == "jpg" || fileType == "gif" || fileType == "png")
            {
                //判断文件夹是否已经存在
                if (!System.IO.Directory.Exists(dirPath))
                {
                    //创建文件夹
                    System.IO.Directory.CreateDirectory(dirPath);
                }

                //上传文件到ipath这个路径里
                fileUpload.SaveAs(serverFilePath);

                return urlPath;
            }

            return "";

        }






        static public string UploadZip(FileUpload fileUpload)
        {
            //获取文件名
            string localFileName = fileUpload.FileName;
            //获取完整客户端文件路径
            string localFilePath = fileUpload.PostedFile.FileName;
            //上传文件类型
            string mimeType = fileUpload.PostedFile.ContentType;
            //上传文件大小
            string fileSize = fileUpload.PostedFile.ContentLength.ToString();
            //上传文件后缀名
            string fileType = localFileName.Substring(localFileName.LastIndexOf(".") + 1);

            ////服务端文件名
            string serverFileName = YaohuaID.NewID() + "." + fileType;

            ////随机路径
            string rndFilePath = "/_UploadZip/" + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";

            ////上传到服务器上后的路径(实际路径)
            string serverFilePath = SystemConfig.RootPath + rndFilePath + serverFileName;

            //创建文件夹时用
            string dirPath = SystemConfig.RootPath + rndFilePath;
            //虚拟路径
            string urlPath = rndFilePath + serverFileName;
            //根据后缀名来限制上传类型
            if (fileType == "zip" || fileType == "rar")
            {
                //判断文件夹是否已经存在
                if (!System.IO.Directory.Exists(dirPath))
                {
                    //创建文件夹
                    System.IO.Directory.CreateDirectory(dirPath);
                }

                //上传文件到ipath这个路径里
                fileUpload.SaveAs(serverFilePath);

                return urlPath;
            }

            return "";

        }




    }
}