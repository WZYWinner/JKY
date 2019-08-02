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
public partial class SysAreaModify : System.Web.UI.Page
{
public SysAreaDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysAreaBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////SysAreaModifyDataInit方法之前
DataInit();
////SysAreaModifyDataInit方法之后
////SysAreaModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SysAreaModifyInitEntity方法之前
InitEntity();
////SysAreaModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "地区");
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
Response.Redirect("SysArea_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////SysAreaModify初始化替换代码之前
tbAreaId.Text=entity.AreaId.ToStr();
tbAreaName.Text=entity.AreaName.ToStr();
tbAreaFullName.Text=entity.AreaFullName.ToStr();
tbParentId.Text=entity.ParentId.ToStr();
tbLevelIndex.Text=entity.LevelIndex.ToStr();
tbRootId.Text=entity.RootId.ToStr();
tbPowerIndex.Text=entity.PowerIndex.ToStr();
tbIsPri.Text=entity.IsPri.ToStr();
tbZipCode.Text=entity.ZipCode.ToStr();
////SysAreaModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysAreaBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SysAreaModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysAreaBLL.GetCustomCode(entity);
}
}
//////SysAreaModify自定义事件替换1
//////SysAreaModify自定义事件替换2
//////SysAreaModify自定义事件替换3
//////SysAreaModify自定义事件替换4
//////SysAreaModify自定义事件替换5
//////SysAreaModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysAreaBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SysAreaModify赋值之前保存
 entity.AreaId=tbAreaId.Text.ToString();
 entity.AreaName=tbAreaName.Text.ToString();
 entity.AreaFullName=tbAreaFullName.Text.ToString();
 entity.ParentId=tbParentId.Text.ToString();
 entity.LevelIndex=tbLevelIndex.Text.ToInt();
 entity.RootId=tbRootId.Text.ToString();
 entity.PowerIndex=tbPowerIndex.Text.ToInt();
 entity.IsPri=tbIsPri.Text.ToString();
 entity.ZipCode=tbZipCode.Text.ToString();
////SysAreaModify赋值之后保存
////SysAreaModify保存的处理之前
{
////SysAreaModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysAreaBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysArea_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysArea_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////SysAreaModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SysAreaModifyDelete按钮赋值之前
////SysAreaModify删除按钮处理之前
{
////SysAreaModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysAreaBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SysAreaModify删除按钮处理之后
}
}
}
