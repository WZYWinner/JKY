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
public partial class LxcSubmitModify : System.Web.UI.Page
{
public LxcSubmitDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LxcSubmitBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LxcSubmitModifyDataInit方法之前
DataInit();
////LxcSubmitModifyDataInit方法之后
////LxcSubmitModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LxcSubmitModifyInitEntity方法之前
InitEntity();
////LxcSubmitModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "提交订单");
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
Response.Redirect("LxcSubmit_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LxcSubmitModify初始化替换代码之前
tbLxcSubmitName.Text=entity.LxcSubmitName.ToStr();
tbLxcSubmitPrice.Text=entity.LxcSubmitPrice.ToStr();
fileLxcSubmitPic.UploadUrl = entity.LxcSubmitPic.ToStr();
tbLxcSubmitNum.Text=entity.LxcSubmitNum.ToStr();
tbLxcSubmitAddressName.Text=entity.LxcSubmitAddressName.ToStr();
tbLxcSubmitAddressPhone.Text=entity.LxcSubmitAddressPhone.ToStr();
tbLxcSubmitAddressAdres.Text=entity.LxcSubmitAddressAdres.ToStr();
tbLxcSubmitAddressTime.Text=entity.LxcSubmitAddressTime.ToStr();
////LxcSubmitModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcSubmitBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LxcSubmitModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcSubmitBLL.GetCustomCode(entity);
}
}
//////LxcSubmitModify自定义事件替换1
//////LxcSubmitModify自定义事件替换2
//////LxcSubmitModify自定义事件替换3
//////LxcSubmitModify自定义事件替换4
//////LxcSubmitModify自定义事件替换5
//////LxcSubmitModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcSubmitBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LxcSubmitModify赋值之前保存
 entity.LxcSubmitName=tbLxcSubmitName.Text.ToString();
 entity.LxcSubmitPrice=tbLxcSubmitPrice.Text.ToDecimal();
 entity.LxcSubmitPic = fileLxcSubmitPic.GetUploadUrl;
 entity.LxcSubmitNum=tbLxcSubmitNum.Text.ToInt();
 entity.LxcSubmitAddressName=tbLxcSubmitAddressName.Text.ToString();
 entity.LxcSubmitAddressPhone=tbLxcSubmitAddressPhone.Text.ToString();
 entity.LxcSubmitAddressAdres=tbLxcSubmitAddressAdres.Text.ToString();
 entity.LxcSubmitAddressTime=tbLxcSubmitAddressTime.Text.ToDatetime();
////LxcSubmitModify赋值之后保存
////LxcSubmitModify保存的处理之前
{
////LxcSubmitModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LxcSubmitBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LxcSubmit_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LxcSubmitModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LxcSubmitModifyDelete按钮赋值之前
////LxcSubmitModify删除按钮处理之前
{
////LxcSubmitModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LxcSubmitBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LxcSubmitModify删除按钮处理之后
}
}
}
