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
public partial class GoodsRecommendModify : System.Web.UI.Page
{
public GoodsRecommendDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.GoodsRecommendBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////GoodsRecommendModifyDataInit方法之前
DataInit();
////GoodsRecommendModifyDataInit方法之后
////GoodsRecommendModifyBind方法之前
{
Bind();
}
}
////初始化实体
////GoodsRecommendModifyInitEntity方法之前
InitEntity();
////GoodsRecommendModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "商品推荐");
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
Response.Redirect("GoodsRecommend_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////GoodsRecommendModify初始化替换代码之前
tbGoodsId.Text=entity.GoodsId.ToStr();
tbGoodsName.Text=entity.GoodsName.ToStr();
fileGoodsPic.UploadUrl = entity.GoodsPic.ToStr();
tbLength.Text=entity.Length.ToStr();
tbPosition.Text=entity.Position.ToStr();
////GoodsRecommendModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.GoodsRecommendBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////GoodsRecommendModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GoodsRecommendBLL.GetCustomCode(entity);
}
}
//////GoodsRecommendModify自定义事件替换1
//////GoodsRecommendModify自定义事件替换2
//////GoodsRecommendModify自定义事件替换3
//////GoodsRecommendModify自定义事件替换4
//////GoodsRecommendModify自定义事件替换5
//////GoodsRecommendModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GoodsRecommendBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////GoodsRecommendModify赋值之前保存
 entity.GoodsId=tbGoodsId.Text.ToString();
 entity.GoodsName=tbGoodsName.Text.ToString();
 entity.GoodsPic = fileGoodsPic.GetUploadUrl;
 entity.Length=tbLength.Text.ToInt();
 entity.Position=tbPosition.Text.ToString();
////GoodsRecommendModify赋值之后保存
////GoodsRecommendModify保存的处理之前
{
////GoodsRecommendModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GoodsRecommendBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GoodsRecommend_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////GoodsRecommendModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////GoodsRecommendModifyDelete按钮赋值之前
////GoodsRecommendModify删除按钮处理之前
{
////GoodsRecommendModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GoodsRecommendBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////GoodsRecommendModify删除按钮处理之后
}
}
}
