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
public partial class MzqAddressModify : System.Web.UI.Page
{
public MzqAddressDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////MzqAddressModifyDataInit方法之前
DataInit();
////MzqAddressModifyDataInit方法之后
////MzqAddressModifyBind方法之前
{
Bind();
}
}
////初始化实体
////MzqAddressModifyInitEntity方法之前
InitEntity();
////MzqAddressModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "收货地址");
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
Response.Redirect("MzqAddress_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
}
////初始化实体
InitEntity();
this.tbRegionInfo1.Items.Add(new ListItem("请选择省份", ""));ListItem[] listRegionInfo1 = SysAreaService.GetDropList1(Session["CorpId"].ToStr(),entity.RegionInfo).Dict2ListItem();this.tbRegionInfo1.Items.AddRange(listRegionInfo1);
this.tbRegionInfo2.Items.Add(new ListItem("请选择城市", ""));ListItem[] listRegionInfo2 = SysAreaService.GetDropList2(Session["CorpId"].ToStr(),entity.RegionInfo).Dict2ListItem(); this.tbRegionInfo2.Items.AddRange(listRegionInfo2);
this.tbRegionInfo3.Items.Add(new ListItem("请选择地区", "")); ListItem[] listRegionInfo3 = SysAreaService.GetDropList3(Session["CorpId"].ToStr(),entity.RegionInfo).Dict2ListItem(); this.tbRegionInfo3.Items.AddRange(listRegionInfo3);
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
////MzqAddressModify初始化替换代码之前
tbUserId.Text=entity.UserId.ToStr();
tbConsigneeInfo.Text=entity.ConsigneeInfo.ToStr();
tbConsigneeRegion.Text=entity.ConsigneeRegion.ToStr();
tbRegionInfo1.SelectedValue=SysAreaService.GetSelectedItem1(entity.RegionInfo.ToStr());
tbRegionInfo2.SelectedValue=SysAreaService.GetSelectedItem2(entity.RegionInfo.ToStr());
tbRegionInfo3.SelectedValue=entity.RegionInfo.ToStr();
tbReceivingAddress.Text=entity.ReceivingAddress.ToStr();
tbTelephone.Text=entity.Telephone.ToStr();
tbState.Text=entity.State.ToStr();
////MzqAddressModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////MzqAddressModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.GetCustomCode(entity);
}
}
protected void tbRegionInfo1_SelectedIndexChanged(object sender, EventArgs e){
this.tbRegionInfo3.Items.Clear();this.tbRegionInfo2.Items.Clear();this.tbRegionInfo2.Items.Add(new ListItem("请选择城市", ""));
ListItem[] listRegionInfo2 = SysAreaService.GetDropList2(Session["CorpId"].ToStr(),this.tbRegionInfo1.SelectedValue).Dict2ListItem();
this.tbRegionInfo2.Items.AddRange(listRegionInfo2); }
protected void tbRegionInfo2_SelectedIndexChanged(object sender, EventArgs e){
this.tbRegionInfo3.Items.Clear();this.tbRegionInfo3.Items.Add(new ListItem("请选择城市", ""));
ListItem[] listRegionInfo3 = SysAreaService.GetDropListGetChild(Session["CorpId"].ToStr(),this.tbRegionInfo2.SelectedValue).Dict2ListItem();
this.tbRegionInfo3.Items.AddRange(listRegionInfo3);}
//////MzqAddressModify自定义事件替换1
//////MzqAddressModify自定义事件替换2
//////MzqAddressModify自定义事件替换3
//////MzqAddressModify自定义事件替换4
//////MzqAddressModify自定义事件替换5
//////MzqAddressModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////MzqAddressModify赋值之前保存
 entity.UserId=tbUserId.Text.ToString();
 entity.ConsigneeInfo=tbConsigneeInfo.Text.ToString();
 entity.ConsigneeRegion=tbConsigneeRegion.Text.ToString();
 entity.RegionInfo=tbRegionInfo3.Text.ToString();
 entity.ReceivingAddress=tbReceivingAddress.Text.ToString();
 entity.Telephone=tbTelephone.Text.ToString();
 entity.State=tbState.Text.ToString();
////MzqAddressModify赋值之后保存
////MzqAddressModify保存的处理之前
{
////MzqAddressModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='MzqAddress_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////MzqAddressModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////MzqAddressModifyDelete按钮赋值之前
////MzqAddressModify删除按钮处理之前
{
////MzqAddressModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////MzqAddressModify删除按钮处理之后
}
}
}
