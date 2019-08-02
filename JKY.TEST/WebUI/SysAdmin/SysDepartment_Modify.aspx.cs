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
public partial class SysDepartmentModify : System.Web.UI.Page
{
public SysDepartmentDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////CheckSession();
////SysDepartmentModifyDataInit方法之前
DataInit();
////SysDepartmentModifyDataInit方法之后
////SysDepartmentModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SysDepartmentModifyInitEntity方法之前
InitEntity();
////SysDepartmentModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "部门");
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
Response.Redirect("SysDepartment_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"");
}
////初始化实体
InitEntity();
this.tbCorpId.Items.Add(""); ListItem[] listCorpId=SysCorpService.GetDropList(Session["CorpId"].ToStr(),"CORP_ID").Dict2ListItem(); this.tbCorpId.Items.AddRange(listCorpId);
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
////SysDepartmentModify初始化替换代码之前
tbCorpId.SelectedValue=entity.CorpId.ToStr();
tbDepartmentCode.Text=entity.DepartmentCode.ToStr();
tbDepartmentName.Text=entity.DepartmentName.ToStr();
////SysDepartmentModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SysDepartmentModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.GetCustomCode(entity);
}
}
//////SysDepartmentModify自定义事件替换1
//////SysDepartmentModify自定义事件替换2
//////SysDepartmentModify自定义事件替换3
//////SysDepartmentModify自定义事件替换4
//////SysDepartmentModify自定义事件替换5
//////SysDepartmentModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SysDepartmentModify赋值之前保存
 entity.CorpId=tbCorpId.Text.ToString();
 entity.DepartmentCode=tbDepartmentCode.Text.ToString();
 entity.DepartmentName=tbDepartmentName.Text.ToString();
////SysDepartmentModify赋值之后保存
////SysDepartmentModify保存的处理之前
{
////SysDepartmentModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysDepartment_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
}
////SysDepartmentModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SysDepartmentModifyDelete按钮赋值之前
////SysDepartmentModify删除按钮处理之前
{
////SysDepartmentModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SysDepartmentModify删除按钮处理之后
}
}
}
