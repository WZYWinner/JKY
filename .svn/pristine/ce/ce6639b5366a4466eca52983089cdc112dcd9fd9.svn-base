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
public partial class GuoGoodsModify : System.Web.UI.Page
{
public GuoGoodsDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.GuoGoodsBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////GuoGoodsModifyDataInit方法之前
DataInit();
////GuoGoodsModifyDataInit方法之后
////GuoGoodsModifyBind方法之前
{
Bind();
}
}
////初始化实体
////GuoGoodsModifyInitEntity方法之前
InitEntity();
////GuoGoodsModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "商品");
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
Response.Redirect("GuoGoods_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////GuoGoodsModify初始化替换代码之前
tbGoodsName.Text=entity.GoodsName.ToStr();
tbGoodsPrice.Text=entity.GoodsPrice.ToStr();
tbGoodsNum.Text=entity.GoodsNum.ToStr();
tbGoodsImg.Text=entity.GoodsImg.ToStr();
tbLaber.Text=entity.Laber.ToStr();
////GuoGoodsModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoGoodsBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////GuoGoodsModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoGoodsBLL.GetCustomCode(entity);
}
}
//////GuoGoodsModify自定义事件替换1
//////GuoGoodsModify自定义事件替换2
//////GuoGoodsModify自定义事件替换3
//////GuoGoodsModify自定义事件替换4
//////GuoGoodsModify自定义事件替换5
//////GuoGoodsModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoGoodsBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////GuoGoodsModify赋值之前保存
 entity.GoodsName=tbGoodsName.Text.ToString();
 entity.GoodsPrice=tbGoodsPrice.Text.ToString();
 entity.GoodsNum=tbGoodsNum.Text.ToString();
 entity.GoodsImg=tbGoodsImg.Text.ToString();
 entity.Laber=tbLaber.Text.ToString();
////GuoGoodsModify赋值之后保存
////GuoGoodsModify保存的处理之前
{
////GuoGoodsModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GuoGoodsBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GuoGoods_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GuoGoods_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////GuoGoodsModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////GuoGoodsModifyDelete按钮赋值之前
////GuoGoodsModify删除按钮处理之前
{
////GuoGoodsModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GuoGoodsBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////GuoGoodsModify删除按钮处理之后
}
}
}
