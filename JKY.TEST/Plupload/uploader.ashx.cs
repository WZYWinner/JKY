using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.Library;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// 上传文件的一般处理程序
    /// </summary>
    public class uploader : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {
            base.ExecuteRequest(context);
            output = UploadFile();
        }

        private string UploadFile()
        {
            string output = "";
            if (request.Files.Count > 0)
            {
                ////随机路径
                string rndFilePath = "/_UploadImage/" + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";
                string rndFilePath2 = "/_UploadZip/" + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";
                //创建文件夹时用
                string dirPath = string.Empty;//SystemConfig.RootPath + rndFilePath;
                string extension = string.Empty;
                string serverFileName = string.Empty;
                string serverFilePath = string.Empty;
                List<string> list = new List<string>();
                var file_type = request["file_type"] ?? "";
                try
                {
                    for (int i = 0; i < request.Files.Count; i++)
                    {
                        HttpPostedFile uploadFile = request.Files[i];
                        int offset = Convert.ToInt32(request["chunk"]);
                        int total = Convert.ToInt32(request["chunks"]);
                        //文件没有分块
                        if (uploadFile.ContentLength > 0)
                        {
                            extension = Path.GetExtension(uploadFile.FileName);
                            string dirPathReal = string.Empty;
                            if (uploadFile.ContentType.Contains("image") || file_type == "img")
                            {
                                dirPathReal = rndFilePath;
                            }
                            else
                            {
                                dirPathReal = rndFilePath2;
                            }
                            dirPath = SystemConfig.RootPath + dirPathReal;
                            if (!System.IO.Directory.Exists(dirPath))
                            {
                                //创建文件夹
                                System.IO.Directory.CreateDirectory(dirPath);
                            }
                            ////服务端文件名
                            serverFileName = YaohuaID.NewID() + (string.IsNullOrEmpty(extension) ? (uploadFile.ContentType.Contains("image") || file_type == "img" ? ".jpg" : ".rar") : extension);
                            serverFilePath = dirPath + serverFileName;
                            uploadFile.SaveAs(serverFilePath);
                            if (uploadFile.ContentType.Contains("image") || file_type == "img")
                            {
                                if (extension.Equals(".pdf"))
                                {
                                    //Yaohuasoft.Framework.BLL.ExportWordTool<object>.ConvertPdfToImage(serverFilePath);
                                }
                            }
                            list.Add(dirPathReal + serverFileName);
                        }
                    }
                    output = JsonSerializer.Serialize(new { result_state = true, msg = "上传成功", list = list });
                }
                catch (Exception ex)
                {
                    output = JsonSerializer.Serialize(new { result_state = false, msg = ex.Message });
                }
            }
            else
            {
                output = JsonSerializer.Serialize(new { result_state = false, msg = "上传问题" });
            }

            return output;
        }
    }
}