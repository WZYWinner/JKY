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
    public partial class SessionUtils : Page
    {
        /// <summary>
        /// 当前用户是否有登录XX系统的权限
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        public bool CheckPower(string system)
        {

            ////是否检验SESSION，用于数据库为空时创建初始数据
            if (ConfigService.IsCheckSession == false)
                return true;

            //Session["UserName"] = "";
            //Session["UserPowerList"] = "";
            //Session["SysType"] = "";
            //Session["Session"] = "";
            //Session["RealName"] = "";
            //Session["LastLoginTime"] = "";


            if (Session["UserName"] == null || Session["Session"] == null
                || Session["SysType"] == null || Session["UserPowerList"] == null
                || Session["CorpId"] == null )
            {
                return false;
            }


            string userName = Session["UserName"].ToString();
            string session = Session["Session"].ToString();
            string sysType = Session["SysType"].ToString();
            string corpId = Session["CorpId"].ToString();
            //string departmentId = Session["DepartmentId"].ToString();
          string userPowerList = Session["UserPowerList"].ToString();


            if (userName.IsNullOrEmptys() || session.IsNullOrEmptys()
                || sysType.IsNullOrEmptys() || userPowerList.IsNullOrEmptys())
            {
                return false;
            }

            SysUserLoginResult result =
                SysUserService.CheckSession(userName, session, userPowerList, corpId);


            if (false) { }
            else if (result.Result == false)
            {
                return false;
            }
            else if (result.SysType != system)
            {
                return false;
            }

            ////最后返回TRUE
            return true;
        }



        /// <summary>
        /// 当前用户是否有XX菜单的权限
        /// 不判断XX系统权限
        /// </summary>
        /// <param name="system"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool CheckPower(string system, string menu)
        {
            ////所有后台都不判断菜单权限，直接返回TRUE
            return true;

            ////是否检验SESSION，用于数据库为空时创建初始数据
            if (ConfigService.IsCheckSession == false)
                return true;


            string userPowerList = Session["UserPowerList"].ToString();
            menu = "," + menu + ",";


            ////如果不是系统管理员，则不需要权限控制
            if (system != "SysAdmin")
                return true;




            ////直接根据UserPowerList判断权限
            if (userPowerList.Contains(menu) == true)
                return true;
            else
                return false;


        }
    }


}