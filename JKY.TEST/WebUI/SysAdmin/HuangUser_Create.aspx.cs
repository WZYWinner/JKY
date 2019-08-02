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
public partial class HuangUserCreate : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.HuangUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////HuangUserCreateDataInit方法之前
DataInit();
////HuangUserCreateDataInit方法之后
}
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "HUANG用户");
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
var entity = new HuangUserDALEntity();
////HuangUserCreate初始化替换代码之前
////HuangUserCreate初始化替换代码之后
////HuangUserCreate初始化自动填充之前
////HuangUserCreate初始化自动填充之后
}
//////HuangUserCreate自定义事件替换1
//////HuangUserCreate自定义事件替换2
//////HuangUserCreate自定义事件替换3
//////HuangUserCreate自定义事件替换4
//////HuangUserCreate自定义事件替换5
//////HuangUserCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new HuangUserDALEntity();
////HuangUserCreate赋值之前保存
 entity.UserName=tbUserName.Text.ToString();
 entity.UserRealname=tbUserRealname.Text.ToString();
 entity.UserPhone=tbUserPhone.Text.ToString();
 entity.UserSex=tbUserSex.Text.ToString();
 entity.UserPwd=tbUserPwd.Text.ToString();
 entity.UserQuestion=tbUserQuestion.Text.ToString();
 entity.UserQanswer=tbUserQanswer.Text.ToString();
////HuangUserCreate赋值之后保存
////HuangUserCreate保存的处理之前
{
////HuangUserCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.HuangUserBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='HuangUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////HuangUserCreate保存处理之后
}
}
}
