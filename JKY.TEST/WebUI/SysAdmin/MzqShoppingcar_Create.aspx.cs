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
public partial class MzqShoppingcarCreate : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.MzqShoppingcarBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////MzqShoppingcarCreateDataInit方法之前
DataInit();
////MzqShoppingcarCreateDataInit方法之后
}
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "购物车");
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
var entity = new MzqShoppingcarDALEntity();
////MzqShoppingcarCreate初始化替换代码之前
////MzqShoppingcarCreate初始化替换代码之后
////MzqShoppingcarCreate初始化自动填充之前
////MzqShoppingcarCreate初始化自动填充之后
}
//////MzqShoppingcarCreate自定义事件替换1
//////MzqShoppingcarCreate自定义事件替换2
//////MzqShoppingcarCreate自定义事件替换3
//////MzqShoppingcarCreate自定义事件替换4
//////MzqShoppingcarCreate自定义事件替换5
//////MzqShoppingcarCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new MzqShoppingcarDALEntity();
////MzqShoppingcarCreate赋值之前保存
 entity.MzqGoodsId=tbMzqGoodsId.Text.ToString();
 entity.MzqShoppingcarName=tbMzqShoppingcarName.Text.ToString();
 entity.MzqShoppingcarPrice=tbMzqShoppingcarPrice.Text.ToDecimal();
 entity.MzqShoppingcarPic = fileMzqShoppingcarPic.GetUploadUrl;
 entity.GoodsNumber=tbGoodsNumber.Text.ToInt();
 entity.CheckedSate=tbCheckedSate.Text.ToString();
////MzqShoppingcarCreate赋值之后保存
////MzqShoppingcarCreate保存的处理之前
{
////MzqShoppingcarCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.MzqShoppingcarBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='MzqShoppingcar_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////MzqShoppingcarCreate保存处理之后
}
}
}
