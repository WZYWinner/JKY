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
public partial class MzqOrderModify : System.Web.UI.Page
{
public MzqOrderDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.MzqOrderBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////MzqOrderModifyDataInit方法之前
DataInit();
////MzqOrderModifyDataInit方法之后
////MzqOrderModifyBind方法之前
{
Bind();
}
}
////初始化实体
////MzqOrderModifyInitEntity方法之前
InitEntity();
////MzqOrderModifyInitEntity方法之后
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
Response.Redirect("MzqOrder_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////MzqOrderModify初始化替换代码之前
tbGoodsId.Text=entity.GoodsId.ToStr();
tbSettlementMoney.Text=entity.SettlementMoney.ToStr();
tbFreight.Text=entity.Freight.ToStr();
tbSettlementTime.Text=entity.SettlementTime.ToStr();
tbSettlementState.Text=entity.SettlementState.ToStr();
tbAddressId.Text=entity.AddressId.ToStr();
tbUserId.Text=entity.UserId.ToStr();
tbBankName.Text=entity.BankName.ToStr();
tbBankNumber.Text=entity.BankNumber.ToStr();
tbPayWay.Text=entity.PayWay.ToStr();
tbEnterpriseNote.Text=entity.EnterpriseNote.ToStr();
////MzqOrderModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.MzqOrderBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////MzqOrderModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.MzqOrderBLL.GetCustomCode(entity);
}
}
//////MzqOrderModify自定义事件替换1
//////MzqOrderModify自定义事件替换2
//////MzqOrderModify自定义事件替换3
//////MzqOrderModify自定义事件替换4
//////MzqOrderModify自定义事件替换5
//////MzqOrderModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.MzqOrderBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////MzqOrderModify赋值之前保存
 entity.GoodsId=tbGoodsId.Text.ToString();
 entity.SettlementMoney=tbSettlementMoney.Text.ToDecimal();
 entity.Freight=tbFreight.Text.ToDecimal();
 entity.SettlementTime=tbSettlementTime.Text.ToDatetime();
 entity.SettlementState=tbSettlementState.Text.ToString();
 entity.AddressId=tbAddressId.Text.ToString();
 entity.UserId=tbUserId.Text.ToString();
 entity.BankName=tbBankName.Text.ToString();
 entity.BankNumber=tbBankNumber.Text.ToString();
 entity.PayWay=tbPayWay.Text.ToString();
 entity.EnterpriseNote=tbEnterpriseNote.Text.ToString();
////MzqOrderModify赋值之后保存
////MzqOrderModify保存的处理之前
{
////MzqOrderModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.MzqOrderBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='MzqOrder_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////MzqOrderModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////MzqOrderModifyDelete按钮赋值之前
////MzqOrderModify删除按钮处理之前
{
////MzqOrderModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.MzqOrderBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////MzqOrderModify删除按钮处理之后
}
}
}
