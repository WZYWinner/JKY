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
public partial class LanGoodsCreate : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LanGoodsCreateDataInit方法之前
DataInit();
////LanGoodsCreateDataInit方法之后
}
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "全部商品");
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
var entity = new LanGoodsDALEntity();
////LanGoodsCreate初始化替换代码之前
this.tbLanMenuParentName.Items.Add(""); ListItem[] listLanMenuParentName=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"LAN_MENU_PARENT_NAME").Dict2ListItem(); this.tbLanMenuParentName.Items.AddRange(listLanMenuParentName);
this.tbLanMenuSubName.Items.Add(""); ListItem[] listLanMenuSubName=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"LAN_MENU_SUB_NAME").Dict2ListItem(); this.tbLanMenuSubName.Items.AddRange(listLanMenuSubName);
////LanGoodsCreate初始化替换代码之后
////LanGoodsCreate初始化自动填充之前
////LanGoodsCreate初始化自动填充之后
}
//////LanGoodsCreate自定义事件替换1
//////LanGoodsCreate自定义事件替换2
//////LanGoodsCreate自定义事件替换3
//////LanGoodsCreate自定义事件替换4
//////LanGoodsCreate自定义事件替换5
//////LanGoodsCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new LanGoodsDALEntity();
////LanGoodsCreate赋值之前保存
 entity.GoodsName=tbGoodsName.Text.ToString();
 entity.LanMenuParentName=tbLanMenuParentName.Text.ToString();
 entity.LanMenuSubName=tbLanMenuSubName.Text.ToString();
 entity.GoodsPrice=tbGoodsPrice.Text.ToDecimal();
 entity.GoodsMsg=tbGoodsMsg.Text.ToString();
 entity.GoodsNum=tbGoodsNum.Text.ToInt();
 entity.GoodsType=tbGoodsType.Text.ToString();
 entity.GoodsShowimg = fileGoodsShowimg.GetUploadUrl;
 entity.GoodsMoreimg = filesGoodsMoreimg.GetUploadUrl;
////LanGoodsCreate赋值之后保存
////LanGoodsCreate保存的处理之前
{
////LanGoodsCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LanGoods_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////LanGoodsCreate保存处理之后
}
}
}
