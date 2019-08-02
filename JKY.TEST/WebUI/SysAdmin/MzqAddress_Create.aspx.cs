using System;
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
public partial class MzqAddressCreate : System.Web.UI.Page
{
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
////MzqAddressCreateDataInit方法之前
DataInit();
////MzqAddressCreateDataInit方法之后
}
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
////只会执行一次
var entity = new MzqAddressDALEntity();
////MzqAddressCreate初始化替换代码之前
this.tbRegionInfo1.Items.Add(new ListItem("请选择省份", ""));ListItem[] listRegionInfo1 = SysAreaService.GetDropList1(Session["CorpId"].ToStr(),entity.RegionInfo).Dict2ListItem();this.tbRegionInfo1.Items.AddRange(listRegionInfo1);
this.tbRegionInfo2.Items.Add(new ListItem("请选择城市", ""));ListItem[] listRegionInfo2 = SysAreaService.GetDropList2(Session["CorpId"].ToStr(),entity.RegionInfo).Dict2ListItem(); this.tbRegionInfo2.Items.AddRange(listRegionInfo2);
this.tbRegionInfo3.Items.Add(new ListItem("请选择地区", "")); ListItem[] listRegionInfo3 = SysAreaService.GetDropList3(Session["CorpId"].ToStr(),entity.RegionInfo).Dict2ListItem(); this.tbRegionInfo3.Items.AddRange(listRegionInfo3);
////MzqAddressCreate初始化替换代码之后
////MzqAddressCreate初始化自动填充之前
////MzqAddressCreate初始化自动填充之后
}
protected void tbRegionInfo1_SelectedIndexChanged(object sender, EventArgs e){
this.tbRegionInfo3.Items.Clear();this.tbRegionInfo2.Items.Clear();this.tbRegionInfo2.Items.Add(new ListItem("请选择城市", ""));
ListItem[] listRegionInfo2 = SysAreaService.GetDropList2(Session["CorpId"].ToStr(),this.tbRegionInfo1.SelectedValue).Dict2ListItem();
this.tbRegionInfo2.Items.AddRange(listRegionInfo2); }
protected void tbRegionInfo2_SelectedIndexChanged(object sender, EventArgs e){
this.tbRegionInfo3.Items.Clear();this.tbRegionInfo3.Items.Add(new ListItem("请选择城市", ""));
ListItem[] listRegionInfo3 = SysAreaService.GetDropListGetChild(Session["CorpId"].ToStr(),this.tbRegionInfo2.SelectedValue).Dict2ListItem();
this.tbRegionInfo3.Items.AddRange(listRegionInfo3);}
//////MzqAddressCreate自定义事件替换1
//////MzqAddressCreate自定义事件替换2
//////MzqAddressCreate自定义事件替换3
//////MzqAddressCreate自定义事件替换4
//////MzqAddressCreate自定义事件替换5
//////MzqAddressCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new MzqAddressDALEntity();
////MzqAddressCreate赋值之前保存
 entity.UserId=tbUserId.Text.ToString();
 entity.ConsigneeInfo=tbConsigneeInfo.Text.ToString();
 entity.ConsigneeRegion=tbConsigneeRegion.Text.ToString();
 entity.RegionInfo=tbRegionInfo3.Text.ToString();
 entity.ReceivingAddress=tbReceivingAddress.Text.ToString();
 entity.Telephone=tbTelephone.Text.ToString();
 entity.State=tbState.Text.ToString();
////MzqAddressCreate赋值之后保存
////MzqAddressCreate保存的处理之前
{
////MzqAddressCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.MzqAddressBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='MzqAddress_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////MzqAddressCreate保存处理之后
}
}
}
