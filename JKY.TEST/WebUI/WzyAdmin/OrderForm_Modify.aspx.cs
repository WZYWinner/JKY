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
public partial class OrderFormModify : System.Web.UI.Page
{
public OrderFormDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.WzyAdmin.OrderFormBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////OrderFormModifyDataInit方法之前
DataInit();
////OrderFormModifyDataInit方法之后
////OrderFormModifyBind方法之前
{
Bind();
}
}
////初始化实体
////OrderFormModifyInitEntity方法之前
InitEntity();
////OrderFormModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("WzyAdmin");
if (result == true)
result=check.CheckPower("WzyAdmin", "订单管理");
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
Response.Redirect("OrderForm_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////OrderFormModify初始化替换代码之前
tbOrderUser.Text=entity.OrderUser.ToStr();
tbOrderTime.Text=entity.OrderTime.ToStr();
tbOrderTotalPrice.Text=entity.OrderTotalPrice.ToStr();
tbOrderDiscounts.Text=entity.OrderDiscounts.ToStr();
tbOrderRealPeice.Text=entity.OrderRealPeice.ToStr();
tbOrderTel.Text=entity.OrderTel.ToStr();
tbOrderAddress.Text=entity.OrderAddress.ToStr();
tbOrderMerchants.Text=entity.OrderMerchants.ToStr();
tbOrderNote.Text=entity.OrderNote.ToStr();
tbOrderStatus.Text=entity.OrderStatus.ToStr();
////OrderFormModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.WzyAdmin.OrderFormBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////OrderFormModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.WzyAdmin.OrderFormBLL.GetCustomCode(entity);
}
}
//////OrderFormModify自定义事件替换1
//////OrderFormModify自定义事件替换2
//////OrderFormModify自定义事件替换3
//////OrderFormModify自定义事件替换4
//////OrderFormModify自定义事件替换5
//////OrderFormModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.WzyAdmin.OrderFormBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////OrderFormModify赋值之前保存
 entity.OrderUser=tbOrderUser.Text.ToString();
 entity.OrderTime=tbOrderTime.Text.ToString();
 entity.OrderTotalPrice=tbOrderTotalPrice.Text.ToString();
 entity.OrderDiscounts=tbOrderDiscounts.Text.ToString();
 entity.OrderRealPeice=tbOrderRealPeice.Text.ToString();
 entity.OrderTel=tbOrderTel.Text.ToString();
 entity.OrderAddress=tbOrderAddress.Text.ToString();
 entity.OrderMerchants=tbOrderMerchants.Text.ToString();
 entity.OrderNote=tbOrderNote.Text.ToString();
 entity.OrderStatus=tbOrderStatus.Text.ToString();
////OrderFormModify赋值之后保存
////OrderFormModify保存的处理之前
{
////OrderFormModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.WzyAdmin.OrderFormBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='OrderForm_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='OrderForm_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////OrderFormModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////OrderFormModifyDelete按钮赋值之前
////OrderFormModify删除按钮处理之前
{
////OrderFormModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.WzyAdmin.OrderFormBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////OrderFormModify删除按钮处理之后
}
}
}