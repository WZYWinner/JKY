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
public partial class SysUserModify : System.Web.UI.Page
{
public SysUserDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
////SysUserModifyDataInit方法之前
DataInit();
////SysUserModifyDataInit方法之后
////SysUserModifyBind方法之前
{
Bind();
}
}
////初始化实体
////SysUserModifyInitEntity方法之前
InitEntity();
////SysUserModifyInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "后台用户");
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
Response.Redirect("SysUser_Detail.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"");
}
////初始化实体
InitEntity();
this.tbSex.Items.Add(""); ListItem[] listSex=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"SEX").Dict2ListItem(); this.tbSex.Items.AddRange(listSex);
this.tbRoleId.Items.Add(""); ListItem[] listRoleId=SysRoleService.GetDropList(Session["CorpId"].ToStr(),"ROLE_ID").Dict2ListItem(); this.tbRoleId.Items.AddRange(listRoleId);
this.tbSysType.Items.Add(""); ListItem[] listSysType=SysConfigService.GetDropList(Session["CorpId"].ToStr(),"SYS_TYPE").Dict2ListItem(); this.tbSysType.Items.AddRange(listSysType);
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
////SysUserModify初始化替换代码之前
tbUserName.Text=entity.UserName.ToStr();
tbSex.SelectedValue=entity.Sex.ToStr();
tbRealName.Text=entity.RealName.ToStr();
tbTelephone.Text=entity.Telephone.ToStr();
tbQq.Text=entity.Qq.ToStr();
tbEmail.Text=entity.Email.ToStr();
tbPassword.Text=entity.Password.ToStr();
tbRoleId.SelectedValue=entity.RoleId.ToStr();
tbSysType.SelectedValue=entity.SysType.ToStr();
tbLastLoginTime.Text=entity.LastLoginTime.ToStr();
////SysUserModify初始化替换代码之后
}
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////SysUserModify初始化InitEntity
////添加附加按钮代码
if (entity._CustomCode == null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.GetCustomCode(entity);
}
}
//////SysUserModify自定义事件替换1
//////SysUserModify自定义事件替换2
//////SysUserModify自定义事件替换3
//////SysUserModify自定义事件替换4
//////SysUserModify自定义事件替换5
//////SysUserModify自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
string id = hiddenID.Value.ToString();
//实体赋值
if(entity==null)
entity = Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.GetEntity(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (entity == null) {
errormsg.Text = "实体为空！" + id;
}
else
{
////SysUserModify赋值之前保存
 entity.UserName=tbUserName.Text.ToString();
 entity.Sex=tbSex.Text.ToString();
 entity.RealName=tbRealName.Text.ToString();
 entity.Telephone=tbTelephone.Text.ToString();
 entity.Qq=tbQq.Text.ToString();
 entity.Email=tbEmail.Text.ToString();
 entity.Password=tbPassword.Text.ToString();
 entity.RoleId=tbRoleId.Text.ToString();
 entity.SysType=tbSysType.Text.ToString();
 entity.LastLoginTime=tbLastLoginTime.Text.ToDatetime();
////SysUserModify赋值之后保存
////SysUserModify保存的处理之前
{
////SysUserModify保存Save方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.Save(entity ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0){
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysUser_List.aspx?&id="+HttpUtility.UrlEncode(Request["id"])+"&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"'</script>");
return;
}
}
////SysUserModify保存的处理之后
errormsg.Text = "保存出错，请重新保存！";
}
}
 protected void btn_Delete_Click(object sender, EventArgs e)
 {
 string id = hiddenID.Value.ToString();
 ////SysUserModifyDelete按钮赋值之前
////SysUserModify删除按钮处理之前
{
////SysUserModify删除方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysUserBLL.Delete(id ,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////SysUserModify删除按钮处理之后
}
}
}
