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
public partial class SysRoleCreate : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysRoleBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////SysRoleCreateDataInit方法之前
DataInit();
////SysRoleCreateDataInit方法之后
}
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "后台角色");
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
var entity = new SysRoleDALEntity();
////SysRoleCreate初始化替换代码之前
this.tbSysType.Items.Add(""); ListItem[] listSysType=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"SYS_TYPE").Dict2ListItem(); this.tbSysType.Items.AddRange(listSysType);
ListItem[] listUserPowerList=SysMenuService.GetDropList(Session["CorpId"].ToStr(),"USER_POWER_LIST").Dict2ListItem(); this.tbUserPowerList.Items.AddRange(listUserPowerList);
////SysRoleCreate初始化替换代码之后
////SysRoleCreate初始化自动填充之前
////SysRoleCreate初始化自动填充之后
}
//////SysRoleCreate自定义事件替换1
//////SysRoleCreate自定义事件替换2
//////SysRoleCreate自定义事件替换3
//////SysRoleCreate自定义事件替换4
//////SysRoleCreate自定义事件替换5
//////SysRoleCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new SysRoleDALEntity();
////SysRoleCreate赋值之前保存
 entity.RoleName=tbRoleName.Text.ToString();
 entity.SysType=tbSysType.Text.ToString();
 entity.UserPowerList=tbUserPowerList.CheckBox2StringByText();
////SysRoleCreate赋值之后保存
////SysRoleCreate保存的处理之前
{
////SysRoleCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysRoleBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysRole_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysRole_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////SysRoleCreate保存处理之后
}
}
}