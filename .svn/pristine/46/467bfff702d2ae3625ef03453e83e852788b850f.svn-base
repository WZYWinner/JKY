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
public partial class GuoAddressModify : System.Web.UI.Page
{
public GuoAddressDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.GuoAddressBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////GuoAddressModifyDataInit方法之前
DataInit();
////GuoAddressModifyDataInit方法之后
////GuoAddressModifyBind方法之前
{
Bind();
}
}
////初始化实体
////GuoAddressModifyInitEntity方法之前
InitEntity();
////GuoAddressModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "郭地址");
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
Response.Redirect("GuoAddress_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
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
////GuoAddressModify初始化替换代码之前
tbProvince.Text=entity.Province.ToStr();
tbAddress.Text=entity.Address.ToStr();
tbHouseNumber.Text=entity.HouseNumber.ToStr();
tbReceiver.Text=entity.Receiver.ToStr();
tbTelephone.Text=entity.Telephone.ToStr();
tbLaber.Text=entity.Laber.ToStr();
////GuoAddressModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoAddressBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////GuoAddressModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoAddressBLL.GetCustomCode(entity);
}
}
//////GuoAddressModify自定义事件替换1
//////GuoAddressModify自定义事件替换2
//////GuoAddressModify自定义事件替换3
//////GuoAddressModify自定义事件替换4
//////GuoAddressModify自定义事件替换5
//////GuoAddressModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.GuoAddressBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////GuoAddressModify赋值之前保存
 entity.Province=tbProvince.Text.ToString();
 entity.Address=tbAddress.Text.ToString();
 entity.HouseNumber=tbHouseNumber.Text.ToString();
 entity.Receiver=tbReceiver.Text.ToString();
 entity.Telephone=tbTelephone.Text.ToString();
 entity.Laber=tbLaber.Text.ToString();
////GuoAddressModify赋值之后保存
////GuoAddressModify保存的处理之前
{
////GuoAddressModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GuoAddressBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GuoAddress_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='GuoAddress_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////GuoAddressModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////GuoAddressModifyDelete按钮赋值之前
////GuoAddressModify删除按钮处理之前
{
////GuoAddressModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.GuoAddressBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////GuoAddressModify删除按钮处理之后
}
}
}
