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
public partial class SignInprizeModify : System.Web.UI.Page
{
public SignInprizeDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SignInprizeBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////SignInprizeModifyDataInit方法之前
DataInit();
////SignInprizeModifyDataInit方法之后
////SignInprizeModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SignInprizeModifyInitEntity方法之前
InitEntity();
////SignInprizeModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "签到有奖");
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
Response.Redirect("SignInprize_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////SignInprizeModify初始化替换代码之前
tbUserId.Text=entity.UserId.ToStr();
tbSignGrade.Text=entity.SignGrade.ToStr();
tbSignCount.Text=entity.SignCount.ToStr();
tbContinuityDay.Text=entity.ContinuityDay.ToStr();
tbSignDayCount.Text=entity.SignDayCount.ToStr();
tbIntegral.Text=entity.Integral.ToStr();
tbSignTime.Text=entity.SignTime.ToStr();
////SignInprizeModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SignInprizeBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SignInprizeModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SignInprizeBLL.GetCustomCode(entity);
}
}
//////SignInprizeModify自定义事件替换1
//////SignInprizeModify自定义事件替换2
//////SignInprizeModify自定义事件替换3
//////SignInprizeModify自定义事件替换4
//////SignInprizeModify自定义事件替换5
//////SignInprizeModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SignInprizeBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SignInprizeModify赋值之前保存
 entity.UserId=tbUserId.Text.ToString();
 entity.SignGrade=tbSignGrade.Text.ToInt();
 entity.SignCount=tbSignCount.Text.ToInt();
 entity.ContinuityDay=tbContinuityDay.Text.ToInt();
 entity.SignDayCount=tbSignDayCount.Text.ToInt();
 entity.Integral=tbIntegral.Text.ToDatetime();
 entity.SignTime=tbSignTime.Text.ToDatetime();
////SignInprizeModify赋值之后保存
////SignInprizeModify保存的处理之前
{
////SignInprizeModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SignInprizeBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SignInprize_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////SignInprizeModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SignInprizeModifyDelete按钮赋值之前
////SignInprizeModify删除按钮处理之前
{
////SignInprizeModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SignInprizeBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SignInprizeModify删除按钮处理之后
}
}
}
