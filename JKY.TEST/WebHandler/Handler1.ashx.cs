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
    public class Handler1 : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {
            //base.ExecuteRequest(context);
            try
            {
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
                                LxcUserQueryParameter UserParm = new LxcUserQueryParameter();
                                UserParm.EqualTo.UserName = username;
                                var user = LxcUserDAL.Select(0, UserParm).FirstOrDefault();
                                //判断获取的用户名是否存在
                                if (user.IsNullOrEmptys())
                                {
                                    throw new Exception("用户名不存在");
                                }
                                else
                                {
                                    //判断密码是否一致
                                    if (user.UserPasswd != password)
                                    {
                                        throw new Exception("用户名或密码错误");
                                    }
                                    else
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = true, msg = "登录成功" });
                                    }
                                }
                            }
                        }
                        break;
                    ///注册    
                    case "register":
                        {
                            ////获取用户输入用户名
                            string username = request["username"] ?? "";
                            ////获取用户输入的密码1
                            string password1 = request["password1"] ?? "";
                            ////获取用户输入的密码2
                            string password2 = request["password2"] ?? "";
                            ////获取当前时间
                            var NewTime = DateTime.Now;
                            //判断输入用户名密码是否为空
                            if (username == "undefined" || password1 == "undefined" || password2 == "undefined")
                            {
                                throw new Exception("用户名或密码不能为空");
                            }
                            else
                            {
                                if(password1==password2)
                                {
                                    //获取数据库中的用户密码,数据库名称为SysUser
                                    LxcUserQueryParameter UserParm = new LxcUserQueryParameter();
                                    UserParm.EqualTo.UserName = username;
                                    var user = LxcUserDAL.Select(0, UserParm).FirstOrDefault();
                                    //判断获取的用户名是否存在
                                    if (user.IsNullOrEmptys())
                                    {
                                        var entity = new LxcUserDALEntity();
                                        entity.UserName = username;
                                        entity.UserPasswd = password1;
                                        entity.UserTime = NewTime;
                                        LxcUserDAL.Merge(0, entity);
                                        string sql = SystemConfig.SQL;
                                        output = JsonSerializer.Serialize(new { result_state = true, msg = "注册成功" });
                                    }
                                    else
                                    {
                                        throw new Exception("用户名已存在");
                                    }
                                }
                                else
                                {
                                    throw new Exception("两次输入的密码不一致");
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
                output = JsonSerializer.Serialize(new { result_state = false, msg = ex.Message });
            }
        }
    }
}


 