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
public partial class GuoOrderFormModify : System.Web.UI.Page
{
public GuoOrderFormDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.GuoOrderFormBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////GuoOrderFormModifyDataInit方法之前
DataInit();
////GuoOrderFormModifyDataInit方法之后
////GuoOrderFormModifyBind方法之前
{
Bind();
}
}
////初始化实体
////GuoOrderFormModifyInitEntity方法之前
InitEntity();
////GuoOrderFormModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "订单");
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
Response.Redirect("GuoOrderForm_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////GuoOrderFormModify初始化替换代码之前
////GuoOrderFormModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
int id = HttpUtility.UrlDecode(Request["id"]).ToInt();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoOrderFormBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////GuoOrderFormModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoOrderFormBLL.GetCustomCode(entity);
}
}
//////GuoOrderFormModify自定义事件替换1
//////GuoOrderFormModify自定义事件替换2
//////GuoOrderFormModify自定义事件替换3
//////GuoOrderFormModify自定义事件替换4
//////GuoOrderFormModify自定义事件替换5
//////GuoOrderFormModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
int id = hiddenID.Value.ToInt();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoOrderFormBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////GuoOrderFormModify赋值之前保存
////GuoOrderFormModify赋值之后保存
////GuoOrderFormModify保存的处理之前
{
////GuoOrderFormModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GuoOrderFormBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GuoOrderForm_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GuoOrderForm_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////GuoOrderFormModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 int id = hiddenID.Value.ToInt();
 ////GuoOrderFormModifyDelete按钮赋值之前
////GuoOrderFormModify删除按钮处理之前
{
////GuoOrderFormModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GuoOrderFormBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////GuoOrderFormModify删除按钮处理之后
}
}
}