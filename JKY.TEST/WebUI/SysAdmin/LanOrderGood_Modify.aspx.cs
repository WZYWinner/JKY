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
public partial class LanOrderGoodModify : System.Web.UI.Page
{
public LanOrderGoodDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LanOrderGoodBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LanOrderGoodModifyDataInit方法之前
DataInit();
////LanOrderGoodModifyDataInit方法之后
////LanOrderGoodModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LanOrderGoodModifyInitEntity方法之前
InitEntity();
////LanOrderGoodModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "LAN订单明细");
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
Response.Redirect("LanOrderGood_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LanOrderGoodModify初始化替换代码之前
tbGoodsMsg.Text=entity.GoodsMsg.ToStr();
fileGoodsShowimg.UploadUrl = entity.GoodsShowimg.ToStr();
tbGoodsPrice.Text=entity.GoodsPrice.ToStr();
tbLanOrderGoodNum.Text=entity.LanOrderGoodNum.ToStr();
tbLanOrderGoodsSumprice.Text=entity.LanOrderGoodsSumprice.ToStr();
////LanOrderGoodModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderGoodBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LanOrderGoodModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderGoodBLL.GetCustomCode(entity);
}
}
//////LanOrderGoodModify自定义事件替换1
//////LanOrderGoodModify自定义事件替换2
//////LanOrderGoodModify自定义事件替换3
//////LanOrderGoodModify自定义事件替换4
//////LanOrderGoodModify自定义事件替换5
//////LanOrderGoodModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderGoodBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LanOrderGoodModify赋值之前保存
 entity.GoodsMsg=tbGoodsMsg.Text.ToString();
 entity.GoodsShowimg = fileGoodsShowimg.GetUploadUrl;
 entity.GoodsPrice=tbGoodsPrice.Text.ToDecimal();
 entity.LanOrderGoodNum=tbLanOrderGoodNum.Text.ToInt();
 entity.LanOrderGoodsSumprice=tbLanOrderGoodsSumprice.Text.ToDecimal();
////LanOrderGoodModify赋值之后保存
////LanOrderGoodModify保存的处理之前
{
////LanOrderGoodModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderGoodBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LanOrderGood_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LanOrderGoodModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LanOrderGoodModifyDelete按钮赋值之前
////LanOrderGoodModify删除按钮处理之前
{
////LanOrderGoodModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanOrderGoodBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LanOrderGoodModify删除按钮处理之后
}
}
}
