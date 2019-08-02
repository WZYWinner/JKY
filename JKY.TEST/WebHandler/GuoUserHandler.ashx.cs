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
    public class GuoUserHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            //base.ExecuteRequest(context);
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空???????");
                }
                switch (type)
                {
                    ////获取子菜单
                    case "Registered":
                        {                           
                           //密码                        
                           string userPwd= request["password"] ?? "";
                            //手机号码
                            string userPhone = request["phone"] ?? "";
                            if (userPhone.IsNullOrEmptys() || userPhone == "undefined" || userPwd.IsNullOrEmptys() || userPwd == "undefined")
                           {
                               throw new Exception("手机号或密码不能为空");
                           }
                           else
                           {
                                //查询用户名判断用户是否已注册     //查询用户，判断用户是否存在
                                GuoUserQueryParameter GuoUser = new GuoUserQueryParameter();
                                GuoUser.EqualTo.Telephone = userPhone;
                                //存放查询到的用户信息
                                var user = GuoUserDAL.Select(0, GuoUser).FirstOrDefault();
                                //不存在用户
                                if (user.IsNullOrEmptys())
                                {
                                    //生成用户编号
                                    var userid = YaohuaID.NewID();
                                    //创建一个新的存储用户信息
                                    var entity = new GuoUserDALEntity();
                                    //用户ID
                                    entity.GuoUserId = userid;
                                    //密码
                                    entity.Password = userPwd;
                                    //手机号码
                                    entity.Telephone = userPhone;
                               


                                    GuoUserDAL.Merge(0, entity);
                                    output = JsonSerializer.Serialize(new { result_state = true, yourID = userid, yourTel= userPhone,msg = "注册成功"});
                                }
                                else
                                {
                                    //判断密码是否一致
                                    if (user.Password != userPwd)
                                    {
                                        throw new Exception("用户名或密码错误");
                                    }
                                    else
                                    {




                                        var mYID = user.GuoUserId;
                                        var mTEL = user.Telephone;
                                        output = JsonSerializer.Serialize(new { result_state = true,yourID=mYID,yourTel= mTEL, msg = "登录成功" });
                                    }
                                }
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