﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
namespace Yaohuasoft.Framework.WebUI.SysAdmin
{
public partial class SysUserCreate : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////SysUserCreateDataInit方法之前
DataInit();
////SysUserCreateDataInit方法之后
}
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "后台用户");
if (result == false)
{
Response.Write("<script> top.window.location.href = '/Logout.aspx?r='+Math.random() ;</script>");
////TODO 临时测试代码
Response.End();
}
}
protected void DataInit()
{
////只会执行一次
var entity = new SysUserDALEntity();
////SysUserCreate初始化替换代码之前
this.tbSex.Items.Add(""); ListItem[] listSex=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"SEX").Dict2ListItem(); this.tbSex.Items.AddRange(listSex);
this.tbRoleId.Items.Add(""); ListItem[] listRoleId=SysRoleService.GetDropList(Session["CorpId"].ToStr(),"ROLE_ID").Dict2ListItem(); this.tbRoleId.Items.AddRange(listRoleId);
this.tbSysType.Items.Add(""); ListItem[] listSysType=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"SYS_TYPE").Dict2ListItem(); this.tbSysType.Items.AddRange(listSysType);
////SysUserCreate初始化替换代码之后
////SysUserCreate初始化自动填充之前
////SysUserCreate初始化自动填充之后
}
//////SysUserCreate自定义事件替换1
//////SysUserCreate自定义事件替换2
//////SysUserCreate自定义事件替换3
//////SysUserCreate自定义事件替换4
//////SysUserCreate自定义事件替换5
//////SysUserCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new SysUserDALEntity();
////SysUserCreate赋值之前保存
 entity.UserName=tbUserName.Text.ToString();
 entity.Sex=tbSex.Text.ToString();
 entity.RealName=tbRealName.Text.ToString();
 entity.Telephone=tbTelephone.Text.ToString();
 entity.Qq=tbQq.Text.ToString();
 entity.Email=tbEmail.Text.ToString();
 entity.Password=tbPassword.Text.ToString();
 entity.RoleId=tbRoleId.Text.ToString();
 entity.SysType=tbSysType.Text.ToString();
////SysUserCreate赋值之后保存
////SysUserCreate保存的处理之前
{
////SysUserCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////SysUserCreate保存处理之后
}
}
}