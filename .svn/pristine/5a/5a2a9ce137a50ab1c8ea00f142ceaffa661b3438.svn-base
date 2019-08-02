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
public partial class UserInfoModify : System.Web.UI.Page
{
public UserInfoDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.UserInfoBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////UserInfoModifyDataInit方法之前
DataInit();
////UserInfoModifyDataInit方法之后
////UserInfoModifyBind方法之前
{
Bind();
}
}
////初始化实体
////UserInfoModifyInitEntity方法之前
InitEntity();
////UserInfoModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "用户信息");
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
Response.Redirect("UserInfo_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////UserInfoModify初始化替换代码之前
tbName.Text=entity.Name.ToStr();
tbPwd.Text=entity.Pwd.ToStr();
fileHead.UploadUrl = entity.Head.ToStr();
tbTel.Text=entity.Tel.ToStr();
tbExperience.Text=entity.Experience.ToStr();
tbEditTime.Text=entity.EditTime.ToStr();
////UserInfoModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.UserInfoBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////UserInfoModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.UserInfoBLL.GetCustomCode(entity);
}
}
//////UserInfoModify自定义事件替换1
//////UserInfoModify自定义事件替换2
//////UserInfoModify自定义事件替换3
//////UserInfoModify自定义事件替换4
//////UserInfoModify自定义事件替换5
//////UserInfoModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.UserInfoBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////UserInfoModify赋值之前保存
 entity.Name=tbName.Text.ToString();
 entity.Pwd=tbPwd.Text.ToString();
 entity.Head = fileHead.GetUploadUrl;
 entity.Tel=tbTel.Text.ToString();
 entity.Experience=tbExperience.Text.ToInt();
 entity.EditTime=tbEditTime.Text.ToDatetime();
////UserInfoModify赋值之后保存
////UserInfoModify保存的处理之前
{
////UserInfoModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.UserInfoBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='UserInfo_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////UserInfoModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////UserInfoModifyDelete按钮赋值之前
////UserInfoModify删除按钮处理之前
{
////UserInfoModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.UserInfoBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////UserInfoModify删除按钮处理之后
}
}
}
