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
public partial class SecuritiesCentreModify : System.Web.UI.Page
{
public SecuritiesCentreDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SecuritiesCentreBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////SecuritiesCentreModifyDataInit方法之前
DataInit();
////SecuritiesCentreModifyDataInit方法之后
////SecuritiesCentreModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SecuritiesCentreModifyInitEntity方法之前
InitEntity();
////SecuritiesCentreModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "领劵中心");
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
Response.Redirect("SecuritiesCentre_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////SecuritiesCentreModify初始化替换代码之前
tbNum.Text=entity.Num.ToStr();
tbGoodsId.Text=entity.GoodsId.ToStr();
fileTicketPic.UploadUrl = entity.TicketPic.ToStr();
tbSeller.Text=entity.Seller.ToStr();
tbUserId.Text=entity.UserId.ToStr();
tbTicketInfo.Text=entity.TicketInfo.ToStr();
tbEndTime.Text=entity.EndTime.ToStr();
tbSecuritiesCentreTime.Text=entity.SecuritiesCentreTime.ToStr();
tbDisable.Text=entity.Disable.ToStr();
////SecuritiesCentreModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SecuritiesCentreBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SecuritiesCentreModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SecuritiesCentreBLL.GetCustomCode(entity);
}
}
//////SecuritiesCentreModify自定义事件替换1
//////SecuritiesCentreModify自定义事件替换2
//////SecuritiesCentreModify自定义事件替换3
//////SecuritiesCentreModify自定义事件替换4
//////SecuritiesCentreModify自定义事件替换5
//////SecuritiesCentreModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SecuritiesCentreBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SecuritiesCentreModify赋值之前保存
 entity.Num=tbNum.Text.ToInt();
 entity.GoodsId=tbGoodsId.Text.ToString();
 entity.TicketPic = fileTicketPic.GetUploadUrl;
 entity.Seller=tbSeller.Text.ToString();
 entity.UserId=tbUserId.Text.ToString();
 entity.TicketInfo=tbTicketInfo.Text.ToString();
 entity.EndTime=tbEndTime.Text.ToDatetime();
 entity.SecuritiesCentreTime=tbSecuritiesCentreTime.Text.ToDatetime();
 entity.Disable=tbDisable.Text.ToString();
////SecuritiesCentreModify赋值之后保存
////SecuritiesCentreModify保存的处理之前
{
////SecuritiesCentreModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SecuritiesCentreBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SecuritiesCentre_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////SecuritiesCentreModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SecuritiesCentreModifyDelete按钮赋值之前
////SecuritiesCentreModify删除按钮处理之前
{
////SecuritiesCentreModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SecuritiesCentreBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SecuritiesCentreModify删除按钮处理之后
}
}
}
