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
public partial class LanGoodsModify : System.Web.UI.Page
{
public LanGoodsDALEntity entity = null;
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
////LanGoodsModifyDataInit方法之前
DataInit();
////LanGoodsModifyDataInit方法之后
////LanGoodsModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LanGoodsModifyInitEntity方法之前
InitEntity();
////LanGoodsModifyInitEntity方法之后
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
if (string.IsNullOrEmpty(Request["id"]))
{
Response.Redirect("LanGoods_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LanGoodsModify初始化替换代码之前
tbGoodsName.Text=entity.GoodsName.ToStr();
tbLanMenuParentName.Text=entity.LanMenuParentName.ToStr();
tbLanMenuSubName.Text=entity.LanMenuSubName.ToStr();
tbGoodsPrice.Text=entity.GoodsPrice.ToStr();
tbGoodsMsg.Text=entity.GoodsMsg.ToStr();
tbGoodsNum.Text=entity.GoodsNum.ToStr();
tbGoodsType.Text=entity.GoodsType.ToStr();
fileGoodsShowimg.UploadUrl = entity.GoodsShowimg.ToStr();
filesGoodsMoreimg.UploadUrl = entity.GoodsMoreimg.ToStr();
////LanGoodsModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LanGoodsModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.GetCustomCode(entity);
}
}
//////LanGoodsModify自定义事件替换1
//////LanGoodsModify自定义事件替换2
//////LanGoodsModify自定义事件替换3
//////LanGoodsModify自定义事件替换4
//////LanGoodsModify自定义事件替换5
//////LanGoodsModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LanGoodsModify赋值之前保存
 entity.GoodsName=tbGoodsName.Text.ToString();
 entity.LanMenuParentName=tbLanMenuParentName.Text.ToString();
 entity.LanMenuSubName=tbLanMenuSubName.Text.ToString();
 entity.GoodsPrice=tbGoodsPrice.Text.ToDecimal();
 entity.GoodsMsg=tbGoodsMsg.Text.ToString();
 entity.GoodsNum=tbGoodsNum.Text.ToInt();
 entity.GoodsType=tbGoodsType.Text.ToString();
 entity.GoodsShowimg = fileGoodsShowimg.GetUploadUrl;
 entity.GoodsMoreimg = filesGoodsMoreimg.GetUploadUrl;
////LanGoodsModify赋值之后保存
////LanGoodsModify保存的处理之前
{
////LanGoodsModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LanGoods_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LanGoodsModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LanGoodsModifyDelete按钮赋值之前
////LanGoodsModify删除按钮处理之前
{
////LanGoodsModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanGoodsBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LanGoodsModify删除按钮处理之后
}
}
}
