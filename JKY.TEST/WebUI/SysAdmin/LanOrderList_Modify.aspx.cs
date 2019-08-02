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
public partial class LanOrderListModify : System.Web.UI.Page
{
public LanOrderListDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LanOrderListModifyDataInit方法之前
DataInit();
////LanOrderListModifyDataInit方法之后
////LanOrderListModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LanOrderListModifyInitEntity方法之前
InitEntity();
////LanOrderListModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "LAN订单");
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
Response.Redirect("LanOrderList_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LanOrderListModify初始化替换代码之前
tbLanOrderListGoodsnum.Text=entity.LanOrderListGoodsnum.ToStr();
tbLanOrderListSumgoodsprice.Text=entity.LanOrderListSumgoodsprice.ToStr();
tbLanOrderListSentprice.Text=entity.LanOrderListSentprice.ToStr();
tbLanOrderListSumprice.Text=entity.LanOrderListSumprice.ToStr();
tbLanOrderListType.Text=entity.LanOrderListType.ToStr();
tbLanOrderListAddtime.Text=entity.LanOrderListAddtime.ToStr();
tbLanOrderListOktime.Text=entity.LanOrderListOktime.ToStr();
tbLanOrderListUserid.Text=entity.LanOrderListUserid.ToStr();
tbLanOrderListUsername.Text=entity.LanOrderListUsername.ToStr();
tbLanOrderListUsertel.Text=entity.LanOrderListUsertel.ToStr();
tbLanOrderListAddress.Text=entity.LanOrderListAddress.ToStr();
tbLanOrderListSenduser.Text=entity.LanOrderListSenduser.ToStr();
tbLanOrderListSendusertel.Text=entity.LanOrderListSendusertel.ToStr();
tbLanOrderType.Text=entity.LanOrderType.ToStr();
////LanOrderListModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LanOrderListModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.GetCustomCode(entity);
}
}
//////LanOrderListModify自定义事件替换1
//////LanOrderListModify自定义事件替换2
//////LanOrderListModify自定义事件替换3
//////LanOrderListModify自定义事件替换4
//////LanOrderListModify自定义事件替换5
//////LanOrderListModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LanOrderListModify赋值之前保存
 entity.LanOrderListGoodsnum=tbLanOrderListGoodsnum.Text.ToInt();
 entity.LanOrderListSumgoodsprice=tbLanOrderListSumgoodsprice.Text.ToDecimal();
 entity.LanOrderListSentprice=tbLanOrderListSentprice.Text.ToDecimal();
 entity.LanOrderListSumprice=tbLanOrderListSumprice.Text.ToDecimal();
 entity.LanOrderListType=tbLanOrderListType.Text.ToString();
 entity.LanOrderListAddtime=tbLanOrderListAddtime.Text.ToDatetime();
 entity.LanOrderListOktime=tbLanOrderListOktime.Text.ToDatetime();
 entity.LanOrderListUserid=tbLanOrderListUserid.Text.ToString();
 entity.LanOrderListUsername=tbLanOrderListUsername.Text.ToString();
 entity.LanOrderListUsertel=tbLanOrderListUsertel.Text.ToString();
 entity.LanOrderListAddress=tbLanOrderListAddress.Text.ToString();
 entity.LanOrderListSenduser=tbLanOrderListSenduser.Text.ToString();
 entity.LanOrderListSendusertel=tbLanOrderListSendusertel.Text.ToString();
 entity.LanOrderType=tbLanOrderType.Text.ToString();
////LanOrderListModify赋值之后保存
////LanOrderListModify保存的处理之前
{
////LanOrderListModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LanOrderList_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LanOrderListModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LanOrderListModifyDelete按钮赋值之前
////LanOrderListModify删除按钮处理之前
{
////LanOrderListModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LanOrderListModify删除按钮处理之后
}
}
}
