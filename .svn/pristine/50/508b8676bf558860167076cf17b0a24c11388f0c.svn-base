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
public partial class LanOrderListCreate : System.Web.UI.Page
{
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
////LanOrderListCreateDataInit方法之前
DataInit();
////LanOrderListCreateDataInit方法之后
}
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
////只会执行一次
var entity = new LanOrderListDALEntity();
////LanOrderListCreate初始化替换代码之前
////LanOrderListCreate初始化替换代码之后
////LanOrderListCreate初始化自动填充之前
////LanOrderListCreate初始化自动填充之后
}
//////LanOrderListCreate自定义事件替换1
//////LanOrderListCreate自定义事件替换2
//////LanOrderListCreate自定义事件替换3
//////LanOrderListCreate自定义事件替换4
//////LanOrderListCreate自定义事件替换5
//////LanOrderListCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new LanOrderListDALEntity();
////LanOrderListCreate赋值之前保存
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
////LanOrderListCreate赋值之后保存
////LanOrderListCreate保存的处理之前
{
////LanOrderListCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderListBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LanOrderList_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////LanOrderListCreate保存处理之后
}
}
}
