using System;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;




namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class MUserModifyHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    //用户头像修改
                    case "headModify":
                        {
                            #region 用户头像修改
                            var UserId = request["UserId"] ?? "";
                            var Head = request["Head"] ?? "";
                            if (UserId.IsNullOrEmptys())
                            {
                                throw new Exception("参数1不能为空");
                            }
                            if (Head.IsNullOrEmptys())
                            {
                                throw new Exception("参数2不能为空");
                            }
                            //头像格式转换
                            //将逗号之前的内容都删除掉
                            Head = Head.Substring(Head.IndexOf(",") + 1);
                            byte[] arr = Convert.FromBase64String(Head);//将纯净资源Base64转换成等效的8位无符号整形数组
                            //日期
                            string time = DateTime.Now.ToString("yyyy-MM-dd");

                            //时                                            
                            int hour = DateTime.Now.Hour;
                            //分
                            int minute = DateTime.Now.Minute;
                            //秒
                            int second = DateTime.Now.Second;
                            //保存图片路径
                            string Is_path = HttpContext.Current.Server.MapPath(@"~/_UploadImage/" + time + "/");

                            //文件不存在时，创建文件
                            if (!Directory.Exists(Is_path))
                                Directory.CreateDirectory(Is_path);

                            MemoryStream ms = new MemoryStream(arr);

                            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                            img.Save(Is_path + UserId + hour + minute + second + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            ms.Dispose();
                            ms.Close();

                            Head = Is_path + UserId + hour + minute + second + ".jpg";
                            //地址格式为D:\JKY.TEST\JKY.TEST\_UploadImage\时间\...
                            //rreplace将\替换成/
                            Head = Head.Replace(@"\", @"/");
                            //去除D:\JKY.TEST\JKY.TEST
                            Head = Head.Substring(20);

                            //将获取的头像更新到数据库中
                            UserInfoQueryParameter parm = new UserInfoQueryParameter();
                            var userInfoEntity = UserInfoDAL.Select(0, parm).FirstOrDefault();
                            userInfoEntity.Head = Head;
                            UserInfoDAL.Merge(0,userInfoEntity);
                            //查找数据库中是否有此头像
                            parm.EqualTo.Head = Head;
                            var userInfoEntity1 = UserInfoDAL.Select(0, parm).FirstOrDefault();
                            if (userInfoEntity1.IsNullOrEmptys())
                            {
                                throw new Exception("头像修改失败");
                            }
                            output = JsonSerializer.Serialize(new { result_state = false, msg = "修改成功" });
                            #endregion
                        }
                        break;
                    //用户名修改   
                    case "nameModify":
                        {
                            #region 用户名修改 
                            //用户ID
                            var UserId = request["UserId"] ?? "";
                            //用户需要修改的用户名
                            string Name = request["Name"] ?? "";
                            if (UserId.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID参数不能为空");
                            }
                            if (Name.IsNullOrEmptys())
                            {
                                throw new Exception("用户需要修改的用户名参数不能为空");
                            }
                            //将获取的用户名更新到数据库中
                            UserInfoQueryParameter parm = new UserInfoQueryParameter();
                            parm.EqualTo.Id = UserId;
                            var userInfoEntity = UserInfoDAL.Select(0, parm).FirstOrDefault();
                            userInfoEntity.Name = Name;
                            UserInfoDAL.Merge(0, userInfoEntity);
                            //查找数据库中是否有此用户名
                            UserInfoQueryParameter parm1 = new UserInfoQueryParameter();
                            parm1.EqualTo.Name = Name;
                            var userInfoEntity1 = UserInfoDAL.Select(0, parm1).FirstOrDefault();
                            if (userInfoEntity1.IsNullOrEmptys())
                            {
                                throw new Exception("用户名修改失败！");
                            }
                            output = JsonSerializer.Serialize(new { result_state = false, msg = "修改成功！"});
                            #endregion
                        }
                        break;
                     //用户密码修改
                    case "pwdModify":
                        {
                            #region 用户密码修改
                            //用户ID
                            var UserId = request["UserId"] ?? "";
                            //用户需要修改的密码
                            string Pwd = request["Pwd"] ?? "";
                            if (Pwd.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID参数不能为空");
                            }
                            if (Pwd.IsNullOrEmptys())
                            {
                                throw new Exception("用户需要修改的密码参数不能为空");
                            }
                            //将获取的用户密码更新到数据库中
                            UserInfoQueryParameter parm = new UserInfoQueryParameter();
                            parm.EqualTo.Id = UserId;
                            var userInfoEntity = UserInfoDAL.Select(0, parm).FirstOrDefault();
                            userInfoEntity.Pwd = Pwd;
                            UserInfoDAL.Merge(0, userInfoEntity);
                            //查找数据库中是否有此用户密码
                            UserInfoQueryParameter parm1 = new UserInfoQueryParameter();
                            parm1.EqualTo.Pwd = Pwd;
                            var userInfoEntity1 = UserInfoDAL.Select(0, parm1).FirstOrDefault();
                            if (userInfoEntity1.IsNullOrEmptys())
                            {
                                throw new Exception("头像修改失败!");
                            }
                            output = JsonSerializer.Serialize(new { result_state = false, msg = "修改成功!" });
                            #endregion
                        }
                        break;                   
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                 output = JsonSerializer.Serialize(new { result_state = false, msg=ex.Message });
            }

            /// <summary>
            /// 将blob格式转变成image图片
            /// </summary>
       
        }
    }
}