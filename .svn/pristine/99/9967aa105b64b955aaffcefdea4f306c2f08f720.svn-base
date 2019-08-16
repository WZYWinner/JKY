using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
namespace Yaohuasoft.Framework.WebUI.LqAdmin
{
public partial class GoodsClassifyModify : System.Web.UI.Page
{
public GoodsClassifyDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.LqAdmin.GoodsClassifyBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////GoodsClassifyModifyDataInit方法之前
DataInit();
////GoodsClassifyModifyDataInit方法之后
////GoodsClassifyModifyBind方法之前
{
Bind();
}
}
////初始化实体
////GoodsClassifyModifyInitEntity方法之前
InitEntity();
////GoodsClassifyModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("LqAdmin");
if (result == true)
result=check.CheckPower("LqAdmin", "商品分类");
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
Response.Redirect("GoodsClassify_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////GoodsClassifyModify初始化替换代码之前
tbSortName.Text=entity.SortName.ToStr();
tbMerchantListId.Text=entity.MerchantListId.ToStr();
////GoodsClassifyModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.LqAdmin.GoodsClassifyBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////GoodsClassifyModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.LqAdmin.GoodsClassifyBLL.GetCustomCode(entity);
}
}
//////GoodsClassifyModify自定义事件替换1
//////GoodsClassifyModify自定义事件替换2
//////GoodsClassifyModify自定义事件替换3
//////GoodsClassifyModify自定义事件替换4
//////GoodsClassifyModify自定义事件替换5
//////GoodsClassifyModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.LqAdmin.GoodsClassifyBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////GoodsClassifyModify赋值之前保存
 entity.SortName=tbSortName.Text.ToString();
 entity.MerchantListId=tbMerchantListId.Text.ToString();
////GoodsClassifyModify赋值之后保存
////GoodsClassifyModify保存的处理之前
{
////GoodsClassifyModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.LqAdmin.GoodsClassifyBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GoodsClassify_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GoodsClassify_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////GoodsClassifyModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////GoodsClassifyModifyDelete按钮赋值之前
////GoodsClassifyModify删除按钮处理之前
{
////GoodsClassifyModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.LqAdmin.GoodsClassifyBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////GoodsClassifyModify删除按钮处理之后
}
}
}
