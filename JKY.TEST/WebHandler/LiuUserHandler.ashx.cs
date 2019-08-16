﻿using System;
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
    public class LiuUserHandler : BaseHanlder
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
                            string name = request["counter"] ?? "";
                            ////获取用户输入的密码
                            string pwd = request["pwd"] ?? "";
                            //判断输入用户名密码是否为空
                            if (name == "undefined" || pwd == "undefined")
                            {
                                throw new Exception("用户名或密码不能为空");
                            }
                            else
                            {
                                //获取数据库中的用户密码,数据库名称为SysUser
                                LiuUserQueryParameter UserParm = new LiuUserQueryParameter();
                                UserParm.EqualTo.LiuName = name;
                                var user = LiuUserDAL.Select(0, UserParm).FirstOrDefault();
                                //判断获取的用户名是否存在
                                if (user.IsNullOrEmptys())
                                {
                                    output = JsonSerializer.Serialize(new { result_state = "0", msg = "用户名不存在", user = user });
                                }
                                else
                                {
                                    //判断密码是否一致
                                    if (user.Password != pwd)
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = "1", msg = "用户名或密码错误", user = user });
                                    }
                                    else
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = "2", msg = "登录成功", user = user });
                                    }
                                }
                            }
                        }
                        break;
                    //修改用户信息
                    case "updateuser":
                        {
                            string phone = request["phone"] ?? "";
                            string lx = request["state"] ?? "";
                            string value = request["value"] ?? "";
                            if (phone.IsNullOrEmptys())
                            {
                                throw new Exception("用户名或密码不能为空");
                            }
                            switch (lx)
                            {
                                case "name":
                                    {
                                        HuangUserQueryParameter UserParm = new HuangUserQueryParameter();
                                        UserParm.EqualTo.UserPhone = phone;
                                        var user = HuangUserDAL.Select(0, UserParm).FirstOrDefault();
                                        user.UserName = value;
                                        HuangUserDAL.Update(0, user);
                                        string sql = SystemConfig.SQL;
                                        output = JsonSerializer.Serialize(new { result_state = true, msg = "昵称修改成功", user = user });
                                    }
                                    break;
                                case "relname":
                                    {
                                        HuangUserQueryParameter UserParm = new HuangUserQueryParameter();
                                        UserParm.EqualTo.UserPhone = phone;
                                        var user = HuangUserDAL.Select(0, UserParm).FirstOrDefault();
                                        user.UserRealname = value;
                                        HuangUserDAL.Update(0, user);
                                        string sql = SystemConfig.SQL;
                                        output = JsonSerializer.Serialize(new { result_state = true, msg = "真实姓名修改成功", user = user });
                                    }
                                    break;
                                case "sex":
                                    {
                                        HuangUserQueryParameter UserParm = new HuangUserQueryParameter();
                                        UserParm.EqualTo.UserPhone = phone;
                                        var user = HuangUserDAL.Select(0, UserParm).FirstOrDefault();
                                        user.UserSex = value;
                                        HuangUserDAL.Update(0, user);
                                        string sql = SystemConfig.SQL;
                                        output = JsonSerializer.Serialize(new { result_state = true, msg = "性别修改成功", user = user });
                                    }
                                    break;
                            }
                        }
                        break;
                    ///用户名是否存在
                    case "username":
                        {
                            string phone = request["phone"] ?? "";
                            if (phone.IsNullOrEmptys())
                            {
                                throw new Exception("手机号码不为空");
                            }
                            HuangUserQueryParameter UserParm = new HuangUserQueryParameter();
                            UserParm.EqualTo.UserPhone = phone;
                            var user = HuangUserDAL.Select(0, UserParm);
                            if (user.Length <= 0)
                            {
                                output = JsonSerializer.Serialize(new { result_state = "0", msg = "可注册", phone = phone });
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = "1", msg = "手机号已存在", user = user, phone = phone });
                            }
                        }
                        break;
                    ///注册    
                    case "register":
                        {
                            string name = request["counter"] ?? "";
                            string pwd = request["pwd"] ?? "";
                            string telepone = request["telephone"] ?? "";
                            if (name.IsNullOrEmptys()|| pwd.IsNullOrEmptys()|| telepone.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            LiuUserQueryParameter UserParm = new LiuUserQueryParameter();
                            UserParm.EqualTo.LiuName = name;
                            var user = LiuUserDAL.Select(0, UserParm).FirstOrDefault();
                            //判断获取的用户名是否存在
                            if (user.IsNullOrEmptys())
                            {
                                var entity = new LiuUserDALEntity();
                                entity.LiuName = name;
                                entity.Password = pwd;
                                entity.Telephone = telepone;
                                 LiuUserDAL.Merge(0, entity);
                                string sql = SystemConfig.SQL;
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "注册成功" });
                            }
                            else
                            {
                                throw new Exception("用户名已存在");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                output = JsonSerializer.Serialize(new { result_state = false, msg = ex.Message});
            }
        }
    }
}