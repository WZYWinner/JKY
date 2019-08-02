﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
namespace Yaohuasoft.Framework.WebUI.WzyAdmin
{
public partial class WangUserModify : System.Web.UI.Page
{
public WangUserDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.WzyAdmin.WangUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////WangUserModifyDataInit方法之前
DataInit();
////WangUserModifyDataInit方法之后
////WangUserModifyBind方法之前
{
Bind();
}
}
////初始化实体
////WangUserModifyInitEntity方法之前
InitEntity();
////WangUserModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("WzyAdmin");
if (result == true)
result=check.CheckPower("WzyAdmin", "王用户");
if (result == false)
{
Response.Write("<script> top.window.location.href = '/Logout.aspx?r='+Math.random() ;</script>");
////TODO 临时测试代码
Response.End();
}
}
protected void DataInit()
{
if (string.IsNullOrEmpty(Request["id"]))
{
Response.Redirect("WangUser_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
}
////初始化实体
InitEntity();
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
////WangUserModify初始化替换代码之前
tbUserName.Text=entity.UserName.ToStr();
tbPassword.Text=entity.Password.ToStr();
////WangUserModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.WzyAdmin.WangUserBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////WangUserModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.WzyAdmin.WangUserBLL.GetCustomCode(entity);
}
}
//////WangUserModify自定义事件替换1
//////WangUserModify自定义事件替换2
//////WangUserModify自定义事件替换3
//////WangUserModify自定义事件替换4
//////WangUserModify自定义事件替换5
//////WangUserModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.WzyAdmin.WangUserBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////WangUserModify赋值之前保存
 entity.UserName=tbUserName.Text.ToString();
 entity.Password=tbPassword.Text.ToString();
////WangUserModify赋值之后保存
////WangUserModify保存的处理之前
{
////WangUserModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.WzyAdmin.WangUserBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='WangUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='WangUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////WangUserModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////WangUserModifyDelete按钮赋值之前
////WangUserModify删除按钮处理之前
{
////WangUserModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.WzyAdmin.WangUserBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////WangUserModify删除按钮处理之后
}
}
}
