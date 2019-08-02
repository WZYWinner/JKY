using System;
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
public partial class OrderDetailModify : System.Web.UI.Page
{
public OrderDetailDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.WzyAdmin.OrderDetailBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////OrderDetailModifyDataInit方法之前
DataInit();
////OrderDetailModifyDataInit方法之后
////OrderDetailModifyBind方法之前
{
Bind();
}
}
////初始化实体
////OrderDetailModifyInitEntity方法之前
InitEntity();
////OrderDetailModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("WzyAdmin");
if (result == true)
result=check.CheckPower("WzyAdmin", "订单明细");
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
Response.Redirect("OrderDetail_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////OrderDetailModify初始化替换代码之前
tbOrderId.Text=entity.OrderId.ToStr();
tbOrderName.Text=entity.OrderName.ToStr();
tbOrderUnitPrice.Text=entity.OrderUnitPrice.ToStr();
tbOrderNum.Text=entity.OrderNum.ToStr();
tbOrderSubtotal.Text=entity.OrderSubtotal.ToStr();
////OrderDetailModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.WzyAdmin.OrderDetailBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////OrderDetailModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.WzyAdmin.OrderDetailBLL.GetCustomCode(entity);
}
}
//////OrderDetailModify自定义事件替换1
//////OrderDetailModify自定义事件替换2
//////OrderDetailModify自定义事件替换3
//////OrderDetailModify自定义事件替换4
//////OrderDetailModify自定义事件替换5
//////OrderDetailModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.WzyAdmin.OrderDetailBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////OrderDetailModify赋值之前保存
 entity.OrderId=tbOrderId.Text.ToString();
 entity.OrderName=tbOrderName.Text.ToString();
 entity.OrderUnitPrice=tbOrderUnitPrice.Text.ToString();
 entity.OrderNum=tbOrderNum.Text.ToString();
 entity.OrderSubtotal=tbOrderSubtotal.Text.ToString();
////OrderDetailModify赋值之后保存
////OrderDetailModify保存的处理之前
{
////OrderDetailModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.WzyAdmin.OrderDetailBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='OrderDetail_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='OrderDetail_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////OrderDetailModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////OrderDetailModifyDelete按钮赋值之前
////OrderDetailModify删除按钮处理之前
{
////OrderDetailModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.WzyAdmin.OrderDetailBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////OrderDetailModify删除按钮处理之后
}
}
}
