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
public partial class LxcAddressModify : System.Web.UI.Page
{
public LxcAddressDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LxcAddressBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////LxcAddressModifyDataInit方法之前
DataInit();
////LxcAddressModifyDataInit方法之后
////LxcAddressModifyBind方法之前
{
Bind();
}
}
////初始化实体
////LxcAddressModifyInitEntity方法之前
InitEntity();
////LxcAddressModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "收货地址");
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
Response.Redirect("LxcAddress_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
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
////LxcAddressModify初始化替换代码之前
tbLxcAddressName.Text=entity.LxcAddressName.ToStr();
tbLxcAddressPhone.Text=entity.LxcAddressPhone.ToStr();
tbLxcAddressAdres.Text=entity.LxcAddressAdres.ToStr();
tbLxcAddressStatus.Text=entity.LxcAddressStatus.ToStr();
////LxcAddressModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcAddressBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LxcAddressModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcAddressBLL.GetCustomCode(entity);
}
}
//////LxcAddressModify自定义事件替换1
//////LxcAddressModify自定义事件替换2
//////LxcAddressModify自定义事件替换3
//////LxcAddressModify自定义事件替换4
//////LxcAddressModify自定义事件替换5
//////LxcAddressModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.LxcAddressBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////LxcAddressModify赋值之前保存
 entity.LxcAddressName=tbLxcAddressName.Text.ToString();
 entity.LxcAddressPhone=tbLxcAddressPhone.Text.ToString();
 entity.LxcAddressAdres=tbLxcAddressAdres.Text.ToString();
 entity.LxcAddressStatus=tbLxcAddressStatus.Text.ToString();
////LxcAddressModify赋值之后保存
////LxcAddressModify保存的处理之前
{
////LxcAddressModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LxcAddressBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='LxcAddress_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////LxcAddressModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////LxcAddressModifyDelete按钮赋值之前
////LxcAddressModify删除按钮处理之前
{
////LxcAddressModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.LxcAddressBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LxcAddressModify删除按钮处理之后
}
}
}
