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
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class WangUserHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            //base.ExecuteRequest(context);
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    ////登录
                    case "login":
                        {
                            ////获取用户输入用户名
                            string username = request["username"] ?? "";
                            ////获取用户输入的密码
                            string password = request["password"] ?? "";
                            //判断输入用户名密码是否为空
                            if (username == "undefined" || password == "undefined")
                            {
                                throw new Exception("用户名或密码不能为空");
                            }
                            else
                            {
                                //获取数据库中的用户密码,数据库名称为SysUser
                                WangUserQueryParameter UserParm = new WangUserQueryParameter();
                                UserParm.EqualTo.UserName = username;
                                var user = WangUserDAL.Select(0, UserParm).FirstOrDefault();
                                //判断获取的用户名是否存在
                                if (user.IsNullOrEmptys())
                                {
                                    output = JsonSerializer.Serialize(new { result_state = "0", msg = "用户名不存在", user = user });
                                }
                                else
                                {
                                    //判断密码是否一致
                                    if (user.Password != password)
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = "1", msg = "用户名或密码错误", user = user });
                                    }
                                    else
                                    {
                                        var ID = user.WangUserId;
                                        var UN = user.UserName;
                                        output = JsonSerializer.Serialize(new { result_state = "2",yourID=ID,youUN=UN, msg = "登录成功", user = user });
                                        
                                    }
                                }
                            }
                        }
                        break;

                    ////获取子菜单
                    case "Register":
                
                        {                           
                           //用户名
                           string userName= request["username"] ?? "";
                          
                           //密码                        
                           string userPwd= request["password"] ?? "";
                           
                            if (userName.IsNullOrEmptys() || userName == "undefined" || userPwd.IsNullOrEmptys() || userPwd == "undefined")
                           {
                               throw new Exception("用户名或密码不能为空");
                           }
                           else
                           {
                               

                                //查询用户名判断用户是否已注册
                                WangUserQueryParameter selectUser = new WangUserQueryParameter();
                                selectUser.EqualTo.UserName = userName;
                                var user = WangUserDAL.Select(0, selectUser).FirstOrDefault();
                              

                                
                                //不存在用户
                                if (user.IsNullOrEmptys())
                                {
                                    //生成用户编号
                                    var userid = YaohuaID.NewID();


                                    //创建一个新的存储用户信息
                                    var entity = new WangUserDALEntity();
                                    //用户ID
                                    entity.WangUserId = userid;
                                    //用户名
                                    entity.UserName = userName;
                                    entity.Password = userPwd;
                                    //真实姓名
                                    //entity.LanUserRealname = userRealname;
                                    ////密码
                                    //entity.LanUserPwd = userPwd;
                                    ////注册时间
                                    //entity.LanUserAddtime= DateTime.Now;
                                    ////头像
                                    //entity.LanUserImg = userImg;
                                    ////手机号码
                                    //entity.LanUserPhone = userPhone;
                                    ////性别
                                    //entity.LanUserSex = sex;
                                    WangUserDAL.Merge(0, entity);


                                    output = JsonSerializer.Serialize(new { result_state = true,yourID=userid, msg = "注册成功" });

                                }
                                else
                                {
                                    throw new Exception("用户名已存在");
                                }
                            }
                        }
                        break;
                    case "UpdateImg":
                        {
                            string userId = request["userId"] ?? "";
                            string userImg = request["image"] ?? "";
                            if (userId == "undefined" || userId.IsNullOrEmptys() || userImg == "undefined" || userImg.IsNullOrEmptys())
                            {
                                throw new Exception("用户或图片不存在");
                            }
                            else
                            {
                                //将逗号之前的内容都删除掉
                                userImg = userImg.Substring(userImg.IndexOf(",") + 1);
                                byte[] arr = Convert.FromBase64String(userImg);//将纯净资源Base64转换成等效的8位无符号整形数组
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

                                img.Save(Is_path + userId + hour + minute + second + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                ms.Dispose();
                                ms.Close();

                                userImg = Is_path + userId + hour + minute + second + ".jpg";
                                //地址格式为D:\JKY.TEST\JKY.TEST\_UploadImage\时间\...
                                //rreplace将\替换成/
                                userImg = userImg.Replace(@"\", @"/");
                                //去除D:\JKY.TEST\JKY.TEST
                                userImg = userImg.Substring(20);

                                //查询用户是否存在
                                LanUserQueryParameter getUser = new LanUserQueryParameter();
                                getUser.EqualTo.LanUserId = userId;
                                var user = LanUserDAL.Select(0, getUser).FirstOrDefault();

                                //修改图片地址
                                user.LanUserImg = userImg;
                                //更新
                                LanUserDAL.Update(0, user);
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "头像修改成功！！！",imgSrc = userImg });
                            }
                        }
                        break;
                    case "UpdateRealname":
                        {
                            //获取用户ID
                            string userId = request["userId"] ?? "";
                            //获取用户修改后的真实姓名
                            string realName = request["realName"] ?? "";
                            //判断参数是否为空
                            if (userId.IsNullOrEmptys() || userId == "undefined" || realName.IsNullOrEmptys() || realName.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            else
                            {
                                //查询用户，判断用户是否存在
                                LanUserQueryParameter getUser = new LanUserQueryParameter();
                                getUser.EqualTo.LanUserId = userId;
                                //存放查询到的用户信息
                                var user = LanUserDAL.Select(0, getUser).FirstOrDefault();
                                //判断用户是否存在
                                if (user.IsNullOrEmptys())
                                {
                                    throw new Exception("用户不存在");
                                }
                                //用户存在
                                else
                                {                                    
                                    //修改用户的真实姓名
                                    user.LanUserRealname = realName;
                                    //更新保存用户信息
                                    LanUserDAL.Update(0, user);
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "真实姓名修改成功！！！" });
                                }
                            }
                        }
                        break;
                    case "UpdatePhone":
                        {
                            //获取用户ID
                            string userId = request["userId"] ?? "";
                            //获取用户修改后的手机号码
                            string userPhone = request["userPhone"] ?? "";
                            //判断参数是否为空
                            if (userId.IsNullOrEmptys() || userId == "undefined" || userPhone.IsNullOrEmptys() || userPhone.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            else
                            {
                                //查询用户，判断用户是否存在
                                LanUserQueryParameter getUser = new LanUserQueryParameter();
                                getUser.EqualTo.LanUserId = userId;
                                //存放查询到的用户信息
                                var user = LanUserDAL.Select(0, getUser).FirstOrDefault();
                                //判断用户是否存在
                                if (user.IsNullOrEmptys())
                                {
                                    throw new Exception("用户不存在");
                                }
                                //用户存在
                                else
                                {
                                    //修改用户的手机号码
                                    user.LanUserPhone = userPhone;
                                    //更新保存用户信息
                                    LanUserDAL.Update(0, user);
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "手机号码修改成功！！！" });
                                }
                            }
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
        }
    }
}