using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Web;

namespace DICOS.PRINT.ADMIN
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["autoLogin"] != null || Request.Cookies["psd"] != null)
                {
                    string username = Cookie.Cookie_Get_One("userName");
                    string pwd = Cookie.Cookie_Get_One("psd");
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
                    {
                        return;
                    }
                    SysUserLoginResult result = SysUserService.UserLogin(username, pwd);
                    //SysUserLoginResult result = SysUserService.UserLogin("admin", "admin");
                    Session["UserName"] = result.UserName;
                    Session["UserId"] = result.UserId;
                    Session["UserPowerList"] = result.UserPowerList;
                    Session["SysType"] = result.SysType;
                    Session["Session"] = result.Session;
                    Session["RealName"] = result.RealName;
                    Session["CorpId"] = result.CorpId;
                    Session["DepartmentId"] = result.DepartmentId;
                    Session["LastLoginTime"] = result.LastLoginTime;
                    if (Request.Cookies["autoLogin"] != null)
                    {
                        string SysType = result.SysType;
                        string[] arrSysType = SysType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Response.Redirect("Index/" + arrSysType[0] + ".aspx");
                    }
                }
            }

        }

       protected void btn_Login_Click(object sender, EventArgs e)
        {
            // 验证码。
            string code = Session["login"] == null ? null : Session["login"].ToString().ToLower();
            // 验证码正确或者是自动登录.
            if ((txt_code.Value).ToLower() == code)
            {
                // 记住密码
                if (Request.Cookies["psd"] != null)
                {

                    txtPassword.Value = SecurityUtils.Decrypt(hd_password.Value);
                }
                SysUserLoginResult result =
                SysUserService.UserLogin(txtUserName.Value, txtPassword.Value);
                if (result.Result == false)
                {
                    this.divErrMsg.Visible = true;
                    this.lbErrMsg.Text = result.ErrMsg;
                }
                else
                {
                    Session["UserName"] = result.UserName;
                    Session["UserId"] = result.UserId;
                    Session["UserPowerList"] = result.UserPowerList;
                    Session["SysType"] = result.SysType;
                    Session["Session"] = result.Session;
                    Session["RealName"] = result.RealName;
                    Session["CorpId"] = result.CorpId;
                    Session["DepartmentId"] = result.DepartmentId;
                    Session["LastLoginTime"] = result.LastLoginTime;

                    // 记住密码是否选中
                    if (cb_rememberPsd.Checked || cb_autoLogin.Checked)
                    {
                        // 写入客户端cookie
                        Cookie.Cookie_Set_One("userName", txtUserName.Value);
                        Cookie.Cookie_Set_One("psd", SecurityUtils.Encrypt(txtPassword.Value));
                        // 自动登录(每次自动登录后重置时间期限)
                        if (cb_autoLogin.Checked)
                        {
                            Cookie.Cookie_Set_One("autoLogin", "true");
                        }
                    }
                    else// 清除cookie
                    {
                        Cookie.Cookie_Clear("userName");
                        Cookie.Cookie_Clear("psd");
                    }
                    string SysType = result.SysType;
                    string[] arrSysType = SysType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Response.Redirect("Index/" + arrSysType[0] + ".aspx");

                }
            }
            else
            {
                this.divErrMsg.Visible = true;
                this.lbErrMsg.Text = "验证码错误";
            }

        }
    }
}