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
    public class MLoginHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            base.ExecuteRequest(context);
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    //登录
                    case "login":
                        {
                            #region 用户登录
                            //获取用户输入用户名
                            string UserName = request["loginUser"] ?? "";
                            //获取用户输入的密码
                            string Password = request["loginPwd"] ?? "";
                            //判断输入用户名密码是否为空
                            if (UserName.IsNullOrEmptys() || Password.IsNullOrEmptys())
                            {
                                throw new Exception("用户名或密码不能为空");
                            }
                            //获取数据库user表中的用户密码                          
                            UserInfoQueryParameter UserParam = new UserInfoQueryParameter();
                            //查找属于当前登录者的信息
                            UserParam.EqualTo.Name = UserName;                          
                            //获取当前登录者数据
                            var user = UserInfoDAL.Select(0, UserParam).FirstOrDefault();
                            //判断获取的用户名是否存在
                            if (user == null)
                            {
                                throw new Exception("用户名不存在,你输入了"+UserName);
                               
                            }
                            else
                            {
                                //判断密码是否一致 .MD5_Encode32()
                                if (user.Pwd != Password)
                                {
                                    throw new Exception("密码错误");
                                }
                                else
                                {
                                    string UserID = user.Id;
                                    output = JsonSerializer.Serialize( new {result_state =true, UserName, UserID });
                                   
                                }
                            }
                            #endregion
                        }
                        break;
                    ///注册    
                    case "register":
                        {
                            #region 用户注册 头像为默认头像 注册成功后可以在我的信息中修改
                            #region 入参判断
                            //用户名
                            string UserName = request["RegistName"] ?? "";
                            //用户密码
                            string Password = request["Password"] ?? "";
                            //第二次用户密码
                            string PasswordAgian = request["RPassword"] ?? "";
                            //用户密码非空判断
                            if (Password.IsNullOrEmptys() || PasswordAgian.IsNullOrEmptys())
                            {
                                throw new Exception("请先完善密码,你输入了，用户名："+UserName+"密码1："+ Password +"和密码2：" + PasswordAgian);
                            }
                            if (Password != PasswordAgian)
                            {
                                throw new Exception("两次密码输入不一样");
                            }
                            #endregion                                                     
                            #region 判断用户表里是否存在此用户
                            UserInfoQueryParameter UserInfoParam = new UserInfoQueryParameter();
                            //查找用户数据表中用户名=当前用户的
                            UserInfoParam.EqualTo.Name = UserName;
                            var user = UserInfoDAL.Select(0, UserInfoParam).FirstOrDefault();                           
                            if (user != null)
                            {
                                throw new Exception("该用户名已存在");
                            }
                            #endregion
                            #region 添加用户  
                            //申明用户表的数据并填充
                            UserInfoDALEntity UserInfoEntity = new UserInfoDALEntity();
                            UserInfoEntity.Name = UserName;
                            UserInfoEntity.Pwd = Password;
                            //向用户数据表库添加用户
                            UserInfoDAL.Merge(0, UserInfoEntity);

                            //更新后的用户数据表
                            UserInfoQueryParameter UserInfoParam1 = new UserInfoQueryParameter();
                            //查找用户数据表中用户名 = 当前用户的
                            UserInfoParam1.EqualTo.Name = UserName;
                            var user1 = UserInfoDAL.Select(0, UserInfoParam1).FirstOrDefault();
                            #endregion
                                                       
                            if (user1 == null)
                            {
                                throw new Exception("未找到此用户！");
                            }
                            string UserID = user1.Id;
                            //如果注册成功就返回用户名                          
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "注册成功", UserName , UserID });
                            #endregion
                        }
                        break;                    
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                output = JsonSerializer.Serialize(new { result_state = false, msg=ex.Message});
            }
        }
    }
    public class UserEntity
    {
        public string UserID { get; set;  }//用户ID
        public string UserName { get; set; }//用户名
    }
 

}