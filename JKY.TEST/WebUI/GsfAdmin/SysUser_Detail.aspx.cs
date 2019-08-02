﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
namespace Yaohuasoft.Framework.WebUI.GsfAdmin
{
public partial class SysUserDetail : System.Web.UI.Page
{
public SysUserDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"]== "back")
{
Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
Bind();
}
////SysUserDetailInitEntity方法之前
////初始化实体
InitEntity();
////SysUserDetailInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("GsfAdmin");
if (result == true)
result=check.CheckPower("GsfAdmin", "后台用户");
if (result == false)
{
Response.Write("<script> top.window.location.href = '/Logout.aspx?r='+Math.random() ;</script>");
////TODO 临时测试代码
Response.End();
}
}
protected void Bind()
{
if (string.IsNullOrEmpty(Request["id"]))
{
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
////初始化实体
InitEntity();
}
//////SysUserDetail自定义事件替换1
//////SysUserDetail自定义事件替换2
//////SysUserDetail自定义事件替换3
//////SysUserDetail自定义事件替换4
//////SysUserDetail自定义事件替换5
//////SysUserDetail自定义事件替换6
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity =Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SysUserDetail初始化替换代码
////添加附加按钮代码
if (entity._CustomCode == null)
entity =Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.GetCustomCode(entity);
}
}
protected void btn_Delete_Click(object sender, EventArgs e)
{
string id = hiddenID.Value.ToString();
////SysUserDetailDelete按钮赋值之前
////SysUserDetail删除按钮处理之前
{
////SysUserDetail删除方法之前
var ret =Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.Delete(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SysUserDetail删除按钮处理之后
}
}
}