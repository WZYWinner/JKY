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
public partial class SysConfigModify : System.Web.UI.Page
{
public SysConfigDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysConfigBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////SysConfigModifyDataInit方法之前
DataInit();
////SysConfigModifyDataInit方法之后
////SysConfigModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SysConfigModifyInitEntity方法之前
InitEntity();
////SysConfigModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "通用配置信息");
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
Response.Redirect("SysConfig_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////SysConfigModify初始化替换代码之前
tbTypeId.Text=entity.TypeId.ToStr();
tbPowerIndex.Text=entity.PowerIndex.ToStr();
tbCode.Text=entity.Code.ToStr();
tbName.Text=entity.Name.ToStr();
tbDescript.Text=entity.Descript.ToStr();
////SysConfigModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysConfigBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SysConfigModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysConfigBLL.GetCustomCode(entity);
}
}
//////SysConfigModify自定义事件替换1
//////SysConfigModify自定义事件替换2
//////SysConfigModify自定义事件替换3
//////SysConfigModify自定义事件替换4
//////SysConfigModify自定义事件替换5
//////SysConfigModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysConfigBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SysConfigModify赋值之前保存
 entity.TypeId=tbTypeId.Text.ToString();
 entity.PowerIndex=tbPowerIndex.Text.ToInt();
 entity.Code=tbCode.Text.ToString();
 entity.Name=tbName.Text.ToString();
 entity.Descript=tbDescript.Text.ToString();
////SysConfigModify赋值之后保存
////SysConfigModify保存的处理之前
{
////SysConfigModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysConfigBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysConfig_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysConfig_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////SysConfigModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SysConfigModifyDelete按钮赋值之前
////SysConfigModify删除按钮处理之前
{
////SysConfigModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysConfigBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SysConfigModify删除按钮处理之后
}
}
}