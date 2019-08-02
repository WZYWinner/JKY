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
public partial class ActivityModify : System.Web.UI.Page
{
public ActivityDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.ActivityBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////ActivityModifyDataInit方法之前
DataInit();
////ActivityModifyDataInit方法之后
////ActivityModifyBind方法之前
{
Bind();
}
}
////初始化实体
////ActivityModifyInitEntity方法之前
InitEntity();
////ActivityModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "门店活动");
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
Response.Redirect("Activity_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////ActivityModify初始化替换代码之前
tbTitle.Text=entity.Title.ToStr();
tbSeller.Text=entity.Seller.ToStr();
tbActivityIntegral.Text=entity.ActivityIntegral.ToStr();
fileActivityPic.UploadUrl = entity.ActivityPic.ToStr();
tbActivityDetailed.Text=entity.ActivityDetailed.ToStr();
tbActivityLength.Text=entity.ActivityLength.ToStr();
tbActivityBeginTime.Text=entity.ActivityBeginTime.ToStr();
tbActivityEndTime.Text=entity.ActivityEndTime.ToStr();
////ActivityModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.ActivityBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////ActivityModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.ActivityBLL.GetCustomCode(entity);
}
}
//////ActivityModify自定义事件替换1
//////ActivityModify自定义事件替换2
//////ActivityModify自定义事件替换3
//////ActivityModify自定义事件替换4
//////ActivityModify自定义事件替换5
//////ActivityModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.ActivityBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////ActivityModify赋值之前保存
 entity.Title=tbTitle.Text.ToString();
 entity.Seller=tbSeller.Text.ToString();
 entity.ActivityIntegral=tbActivityIntegral.Text.ToInt();
 entity.ActivityPic = fileActivityPic.GetUploadUrl;
 entity.ActivityDetailed=tbActivityDetailed.Text.ToString();
 entity.ActivityLength=tbActivityLength.Text.ToInt();
 entity.ActivityBeginTime=tbActivityBeginTime.Text.ToDatetime();
 entity.ActivityEndTime=tbActivityEndTime.Text.ToDatetime();
////ActivityModify赋值之后保存
////ActivityModify保存的处理之前
{
////ActivityModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.ActivityBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='Activity_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////ActivityModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////ActivityModifyDelete按钮赋值之前
////ActivityModify删除按钮处理之前
{
////ActivityModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.ActivityBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////ActivityModify删除按钮处理之后
}
}
}
