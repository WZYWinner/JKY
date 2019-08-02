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
public partial class SysDepartmentCreate : System.Web.UI.Page
{
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
////SysDepartmentCreateDataInit方法之前
DataInit();
////SysDepartmentCreateDataInit方法之后
}
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
////只会执行一次
var entity = new SysDepartmentDALEntity();
////SysDepartmentCreate初始化替换代码之前
this.tbCorpId.Items.Add(""); ListItem[] listCorpId=SysCorpService.GetDropList(Session["CorpId"].ToStr(),"CORP_ID").Dict2ListItem(); this.tbCorpId.Items.AddRange(listCorpId);
////SysDepartmentCreate初始化替换代码之后
////SysDepartmentCreate初始化自动填充之前
////SysDepartmentCreate初始化自动填充之后
}
//////SysDepartmentCreate自定义事件替换1
//////SysDepartmentCreate自定义事件替换2
//////SysDepartmentCreate自定义事件替换3
//////SysDepartmentCreate自定义事件替换4
//////SysDepartmentCreate自定义事件替换5
//////SysDepartmentCreate自定义事件替换6
 protected void btn_Save_Click(object sender, EventArgs e)
 {
 SaveData();
 }
protected void SaveData()
{
//实体赋值
var entity = new SysDepartmentDALEntity();
////SysDepartmentCreate赋值之前保存
 entity.CorpId=tbCorpId.Text.ToString();
 entity.DepartmentCode=tbDepartmentCode.Text.ToString();
 entity.DepartmentName=tbDepartmentName.Text.ToString();
////SysDepartmentCreate赋值之后保存
////SysDepartmentCreate保存的处理之前
{
////SysDepartmentCreate保存Add方法之前
var ret = Yaohuasoft.Framework.BLL.SysAdmin.SysDepartmentBLL.Add(entity,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
////Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.href='SysDepartment_List.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id="+HttpUtility.UrlEncode(Request["id"])+"'</script>");
return;
}
errormsg.Text = "保存出现错误，请重新保存！";
}
////SysDepartmentCreate保存处理之后
}
}
}
