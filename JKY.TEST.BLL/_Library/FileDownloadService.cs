using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Web;


namespace Yaohuasoft.Framework.BLL
{

    public partial class FileDownloadService
    {






        static public void MemoryStream2Client(MemoryStream ms, HttpContext context, string fileName)
        {
            if (context.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }





        static public void MemoryStream2File(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();

                data = null;
            }
        }










        static public void DownloadFile2Client (string fileName, string filePath,
            string clientFileName, HttpContext httpContext)
        {
            //以字符流的形式下载文件
            string fullName = filePath + fileName;
            FileStream fs = new FileStream(fullName, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            httpContext.Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            httpContext.Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(clientFileName, System.Text.Encoding.UTF8));
            httpContext.Response.BinaryWrite(bytes);
            httpContext.Response.Flush();
            httpContext.Response.End();

        }


    }


}