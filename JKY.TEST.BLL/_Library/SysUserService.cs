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
    /// 字符串相关特殊处理辅助类
    /// </summary>
    public static partial class SysUserService
    {



        static public SysUserLoginResult UserLogin(string userName, string password)
        {

            /////用于默认帐号创建
            ////是否检验SESSION，用于数据库为空时创建初始数据
            if (ConfigService.IsCheckSession == false)
                if (userName == "admin" && password == "admin")
                {
                    SysUserQueryParameter parm2 = new SysUserQueryParameter();
                    int cnt = SysUserDAL.Count(0, parm2);
                    if (cnt == 0)
                    {
                        SysUserDALEntity entity2 = new SysUserDALEntity()
                        {
                            UserName = "admin",
                            Password = "admin".MD5_Encode32(),
                            Session = "admin",
                            CorpId = "SysAdmin",
                            SysType = "SysAdmin",
                            UserPowerList = "admin",
                        };
                        SysUserDAL.Insert(0, entity2);
                        return new SysUserLoginResult();
                    }
                }












            SysUserLoginResult result = new SysUserLoginResult();
            ////生成一个随机ID
            string session = YaohuaID.NewID();
            ////最近登录时间
            DateTime lastLoginTime = DateTime.Now;
            ////密码MD5
            password = password.MD5_Encode32();






            SysUserQueryParameter parm = new SysUserQueryParameter();
            parm.EqualTo.UserName = userName;


            string ttt = SystemConfig.GetDbServerEntity(0).DbConnString;

            ////TODO 后台用户名需要唯一
            SysUserDALEntity entity = SysUserDAL.Select(0, parm).FirstOrDefault();


            if (false) { }
            else if (entity == null)
            {
                result = new SysUserLoginResult()
                {
                    Result = false,
                    ErrMsg = "没有这个用户"
                };
            }
            else if (entity.Password != password)
            {
                result = new SysUserLoginResult()
                {
                    Result = false,
                    ErrMsg = "用户名或者密码不正确"
                };
            }
            else
            {

                ////将信息填值后，保存进数据库
                entity.Session = session;
                entity.LastLoginTime = lastLoginTime;
                SysUserDAL.Update(0, entity);


                result = new SysUserLoginResult()
                {
                    Result = true,
                    ErrMsg = "登录成功",
                    RealName = entity.RealName,
                    UserName = entity.UserName,
                    UserId = entity.SysUserId,
                    CorpId = entity.CorpId,
                    DepartmentId = entity.DepartmentId,
                    SysType = entity.SysType,
                    UserPowerList = entity.UserPowerList,
                    LastLoginTime = lastLoginTime,
                    Session = session,
                };
            }



            return result;
        }

        static public SysUserLoginResult CheckSession(string userName, string session, string userPowerList, string corpId)
        {
            SysUserLoginResult result = new SysUserLoginResult();
            ////最近登录时间
            DateTime lastLoginTime = DateTime.Now;


            SysUserQueryParameter parm = new SysUserQueryParameter();
            parm.EqualTo.UserName = userName;


            ////TODO 后台用户名需要唯一
            SysUserDALEntity entity = SysUserDAL.Select(0, parm).FirstOrDefault();


            if (false) { }
            else if (entity == null)
            {
                result = new SysUserLoginResult()
                {
                    Result = false,
                    ErrMsg = "没有这个用户"
                };
            }
            ////如果开启则一个帐号只能一个人登录
            ////////else if (entity.Session != session)
            ////////{
            ////////    result = new SysUserLoginResult()
            ////////    {
            ////////        Result = false,
            ////////        ErrMsg = "用户名或者密码不正确"
            ////////    };
            ////////}
            else if (entity.UserPowerList != userPowerList)
            {
                result = new SysUserLoginResult()
                {
                    Result = false,
                    ErrMsg = "权限信息不对"
                };
            }
            else if (entity.CorpId != corpId)
            {
                result = new SysUserLoginResult()
                {
                    Result = false,
                    ErrMsg = "公司信息不对"
                };
            }
            else
            {
                ////将信息填值后，保存进数据库
                //entity.Session = session;
                //entity.LastLoginTime = lastLoginTime;
                //SysUserDAL.Update(0, entity);

                result = new SysUserLoginResult()
                {
                    Result = true,
                    ErrMsg = "登录成功",
                    RealName = entity.RealName,
                    UserName = entity.UserName,
                    UserId = entity.SysUserId,
                    LastLoginTime = lastLoginTime,
                    CorpId = entity.CorpId,
                    DepartmentId = entity.DepartmentId,
                    SysType = entity.SysType,
                    UserPowerList = entity.UserPowerList,
                    Session = session,
                };
            }






            return result;
        }



    }


    public class SysUserLoginResult
    {
        public bool Result;
        public string ErrMsg;
        public string UserName;
        public string UserId;
        public string RealName;
        public string RoleId;
        public string Session;
        public string SysType;
        public string CorpId;
        public string DepartmentId;
        public string UserPowerList;
        public DateTime LastLoginTime;
    }

}