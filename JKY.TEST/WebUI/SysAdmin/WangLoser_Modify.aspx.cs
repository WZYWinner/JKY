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
public partial class WangLoserModify : System.Web.UI.Page
{
public WangLoserDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.WangLoserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////WangLoserModifyDataInit方法之前
DataInit();
////WangLoserModifyDataInit方法之后
////WangLoserModifyBind方法之前
{
Bind();
}
}
////初始化实体
////WangLoserModifyInitEntity方法之前
InitEntity();
////WangLoserModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "王用户");
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
Response.Redirect("WangLoser_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////WangLoserModify初始化替换代码之前
tbWangLoserId.Text=entity.WangLoserId.ToStr();
tbWangLoserName.Text=entity.WangLoserName.ToStr();
tbWangLoserPassword.Text=entity.WangLoserPassword.ToStr();
tbWangLoserAddress.Text=entity.WangLoserAddress.ToStr();
tbWangLoserTel.Text=entity.WangLoserTel.ToStr();
////WangLoserModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.WangLoserBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////WangLoserModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.WangLoserBLL.GetCustomCode(entity);
}
}
//////WangLoserModify自定义事件替换1
//////WangLoserModify自定义事件替换2
//////WangLoserModify自定义事件替换3
//////WangLoserModify自定义事件替换4
//////WangLoserModify自定义事件替换5
//////WangLoserModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.WangLoserBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////WangLoserModify赋值之前保存
 entity.WangLoserId=tbWangLoserId.Text.ToString();
 entity.WangLoserName=tbWangLoserName.Text.ToString();
 entity.WangLoserPassword=tbWangLoserPassword.Text.ToString();
 entity.WangLoserAddress=tbWangLoserAddress.Text.ToString();
 entity.WangLoserTel=tbWangLoserTel.Text.ToString();
////WangLoserModify赋值之后保存
////WangLoserModify保存的处理之前
{
////WangLoserModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.WangLoserBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='WangLoser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='WangLoser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////WangLoserModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////WangLoserModifyDelete按钮赋值之前
////WangLoserModify删除按钮处理之前
{
////WangLoserModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.WangLoserBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////WangLoserModify删除按钮处理之后
}
}
}
