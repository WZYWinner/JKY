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
public partial class LxcShoppingcarModify : System.Web.UI.Page
{
public LxcShoppingcarDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LxcShoppingcarBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LxcShoppingcarModifyDataInit方法之前
DataInit();
////LxcShoppingcarModifyDataInit方法之后
////LxcShoppingcarModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LxcShoppingcarModifyInitEntity方法之前
InitEntity();
////LxcShoppingcarModifyInitEntity方法之后
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
if (string.IsNullOrEmpty(Request["id"]))
{
Response.Redirect("LxcShoppingcar_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LxcShoppingcarModify初始化替换代码之前
tbLxcShoppingcarName.Text=entity.LxcShoppingcarName.ToStr();
tbLxcShoppingcarPrice.Text=entity.LxcShoppingcarPrice.ToStr();
fileLxcShoppingcarPic.UploadUrl = entity.LxcShoppingcarPic.ToStr();
tbLxcShoppingcarNum.Text=entity.LxcShoppingcarNum.ToStr();
////LxcShoppingcarModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcShoppingcarBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LxcShoppingcarModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcShoppingcarBLL.GetCustomCode(entity);
}
}
//////LxcShoppingcarModify自定义事件替换1
//////LxcShoppingcarModify自定义事件替换2
//////LxcShoppingcarModify自定义事件替换3
//////LxcShoppingcarModify自定义事件替换4
//////LxcShoppingcarModify自定义事件替换5
//////LxcShoppingcarModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcShoppingcarBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LxcShoppingcarModify赋值之前保存
 entity.LxcShoppingcarName=tbLxcShoppingcarName.Text.ToString();
 entity.LxcShoppingcarPrice=tbLxcShoppingcarPrice.Text.ToDecimal();
 entity.LxcShoppingcarPic = fileLxcShoppingcarPic.GetUploadUrl;
 entity.LxcShoppingcarNum=tbLxcShoppingcarNum.Text.ToInt();
////LxcShoppingcarModify赋值之后保存
////LxcShoppingcarModify保存的处理之前
{
////LxcShoppingcarModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LxcShoppingcarBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LxcShoppingcar_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LxcShoppingcarModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LxcShoppingcarModifyDelete按钮赋值之前
////LxcShoppingcarModify删除按钮处理之前
{
////LxcShoppingcarModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LxcShoppingcarBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LxcShoppingcarModify删除按钮处理之后
}
}
}
