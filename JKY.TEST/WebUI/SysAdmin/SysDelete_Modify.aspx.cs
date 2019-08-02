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
public partial class SysDeleteModify : System.Web.UI.Page
{
public SysDeleteDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysDeleteBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////SysDeleteModifyDataInit方法之前
DataInit();
////SysDeleteModifyDataInit方法之后
////SysDeleteModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SysDeleteModifyInitEntity方法之前
InitEntity();
////SysDeleteModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "数据回收站");
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
Response.Redirect("SysDelete_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
}
////初始化实体
InitEntity();
this.tbDataType.Items.Add(""); ListItem[] listDataType=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"DATA_TYPE").Dict2ListItem(); this.tbDataType.Items.AddRange(listDataType);
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
////SysDeleteModify初始化替换代码之前
tbDelId.Text=entity.DelId.ToStr();
tbDataId.Text=entity.DataId.ToStr();
tbDataType.SelectedValue=entity.DataType.ToStr();
tbDataJson.Text=entity.DataJson.ToStr();
tbDelTime.Text=entity.DelTime.ToStr();
////SysDeleteModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysDeleteBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SysDeleteModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysDeleteBLL.GetCustomCode(entity);
}
}
//////SysDeleteModify自定义事件替换1
//////SysDeleteModify自定义事件替换2
//////SysDeleteModify自定义事件替换3
//////SysDeleteModify自定义事件替换4
//////SysDeleteModify自定义事件替换5
//////SysDeleteModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysDeleteBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SysDeleteModify赋值之前保存
 entity.DelId=tbDelId.Text.ToString();
 entity.DataId=tbDataId.Text.ToString();
 entity.DataType=tbDataType.Text.ToString();
 entity.DataJson=tbDataJson.Text.ToString();
 entity.DelTime=tbDelTime.Text.ToDatetime();
////SysDeleteModify赋值之后保存
////SysDeleteModify保存的处理之前
{
////SysDeleteModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysDeleteBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysDelete_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////SysDeleteModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SysDeleteModifyDelete按钮赋值之前
////SysDeleteModify删除按钮处理之前
{
////SysDeleteModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysDeleteBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SysDeleteModify删除按钮处理之后
}
}
}
