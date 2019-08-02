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


namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class LoginHandler : BaseHanlder
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
                            if (username=="undefined" || password=="undefined")
                            {
                                throw new Exception("用户名或密码不能为空");
                            }
                            else
                            {
                                //获取数据库中的用户密码,数据库名称为SysUser
                                LanUserQueryParameter UserParm = new LanUserQueryParameter();
                                UserParm.EqualTo.LanUserName = username;
                                var user = LanUserDAL.Select(0, UserParm).FirstOrDefault();
                                //判断获取的用户名是否存在
                                if (user.IsNullOrEmptys())
                                {
                                    throw new Exception("用户名不存在");
                                }
                                else
                                {
                                    //判断密码是否一致
                                    if (user.LanUserPwd != password)
                                    {
                                        throw new Exception("用户名或密码错误");
                                    }
                                    else
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = true, msg = "登录成功", user = user });
                                    }
                                }
                            }
                        }
                        break;
                    ///注册    
                    case "register":
                        {

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