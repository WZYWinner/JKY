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
public partial class LanUserModify : System.Web.UI.Page
{
public LanUserDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LanUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LanUserModifyDataInit方法之前
DataInit();
////LanUserModifyDataInit方法之后
////LanUserModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LanUserModifyInitEntity方法之前
InitEntity();
////LanUserModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "LAN用户");
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
Response.Redirect("LanUser_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LanUserModify初始化替换代码之前
tbLanUserName.Text=entity.LanUserName.ToStr();
tbLanUserPwd.Text=entity.LanUserPwd.ToStr();
tbLanUserRealname.Text=entity.LanUserRealname.ToStr();
tbLanUserPhone.Text=entity.LanUserPhone.ToStr();
fileLanUserImg.UploadUrl = entity.LanUserImg.ToStr();
tbLanUserSex.Text=entity.LanUserSex.ToStr();
tbLanUserAddtime.Text=entity.LanUserAddtime.ToStr();
////LanUserModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanUserBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LanUserModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanUserBLL.GetCustomCode(entity);
}
}
//////LanUserModify自定义事件替换1
//////LanUserModify自定义事件替换2
//////LanUserModify自定义事件替换3
//////LanUserModify自定义事件替换4
//////LanUserModify自定义事件替换5
//////LanUserModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LanUserBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LanUserModify赋值之前保存
 entity.LanUserName=tbLanUserName.Text.ToString();
 entity.LanUserPwd=tbLanUserPwd.Text.ToString();
 entity.LanUserRealname=tbLanUserRealname.Text.ToString();
 entity.LanUserPhone=tbLanUserPhone.Text.ToString();
 entity.LanUserImg = fileLanUserImg.GetUploadUrl;
 entity.LanUserSex=tbLanUserSex.Text.ToString();
 entity.LanUserAddtime=tbLanUserAddtime.Text.ToDatetime();
////LanUserModify赋值之后保存
////LanUserModify保存的处理之前
{
////LanUserModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanUserBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LanUser_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LanUserModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LanUserModifyDelete按钮赋值之前
////LanUserModify删除按钮处理之前
{
////LanUserModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LanUserBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LanUserModify删除按钮处理之后
}
}
}
