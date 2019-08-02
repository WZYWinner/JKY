using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
namespace Yaohuasoft.Framework.WebUI.SysAdmin
{
public partial class LanMenuDetail : System.Web.UI.Page
{
public LanMenuDALEntity entity = null;
int CurrentPageIndex = 1;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"]== "back")
{
Yaohuasoft.Framework.BLL.SysAdmin.LanMenuBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
DataInit();
Bind();
}
Session["id"] = Request["id"];
////初始化实体
InitEntity();
////LanMenuDetailInitEntity方法之后
}
protected void Page_LoadComplete(object sender, EventArgs e)
{
if (!IsPostBack)
{
////获取查询参数
YaohuaDict<string, string> queryDict = QuerySerivce.String2QueryParm(HttpUtility.UrlDecode(Request["query"]));
pager.CurrentPageIndex=CurrentPageIndex;
}
}
protected void DataInit()
{
////如果排序的项就1个，则隐藏掉
if (this.ddlSortList.Items.Count <= 1) this.ddlSortList.Visible = false;
////如果集成查询没有项则隐藏
if (this.ddlTextInOne.Items.Count ==0) { this.ddlTextInOne.Visible = false; this.txtTextInOne.Visible = false; }
////初始化分页选择
this.ddl_PageSize.SelectedValue = Session["PageSize"].ToStr();
////获取查询参数
YaohuaDict<string, string> queryDict = QuerySerivce.String2QueryParm(HttpUtility.UrlDecode(Request["query"]));
////if(queryDict.ContainsKey("PageIndex"))CurrentPageIndex=queryDict["PageIndex"].ToInt();
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("SysAdmin");
if (result == true)
result=check.CheckPower("SysAdmin", "菜单分类");
if (result == false)
{
Response.Write("<script> top.window.location.href = '/Logout.aspx?r='+Math.random() ;</script>");
////TODO 临时测试代码
Response.End();
}
}
protected void pager_PageChanged(object sender, EventArgs e)
{
Bind();
}
protected void btn_Search_Click(object sender, EventArgs e)
{
Bind();
}
protected void Bind4Detail()
{
int count = 0;
////设置分页条数
this.pager.PageSize = this.ddl_PageSize.SelectedValue.ToInt();
YaohuaDict<string, string> dropList = new YaohuaDict<string, string>();
YaohuaDict<string, string> textBox = new YaohuaDict<string, string>();
YaohuaDict<string, string> textBoxInOne = new YaohuaDict<string, string>();
YaohuaDict<string, string> sortList = new YaohuaDict<string, string>();
textBoxInOne.Add(this.ddlTextInOne.SelectedValue, this.txtTextInOne.Text);
////通过主表ID取附表
textBox.Add("LanMenuId",HttpUtility.UrlDecode(Request["id"]).ToString());
sortList.Add("SortList", this.ddlSortList.Text);
if (IsPostBack) CurrentPageIndex = pager.CurrentPageIndex;////如果是回调的，用分页控件的页码
QueryString.Value=QuerySerivce.QueryDict2String(dropList,textBox,textBoxInOne,sortList,CurrentPageIndex);
var list =Yaohuasoft.Framework.BLL.SysAdmin.LanSecondMenuBLL.GetList(dropList, textBox, textBoxInOne, sortList,
CurrentPageIndex, pager.PageSize,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr(), out count);
UiDataList.DataSource= list;
UiDataList.DataBind();
pager.RecordCount = count;
listcount.Text = count.ToString();
/////////////如果不允许列表的处理逻辑
return;
////如果不允许列表
////如果数据超过1条则跳转到第一条去
if (list.Count >= 1)
Response.Redirect("LanSecondMenu_Detail.aspx?rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id=" + list[0].LanSecondMenuId.ToStr());
}
protected void Bind()
{
Bind4Detail();
if (string.IsNullOrEmpty(Request["id"]))
{
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
////初始化实体
InitEntity();
this.fileLanMenuImg.UploadUrl=entity.LanMenuImg.ToStr();
this.fileLanMenuPostImg.UploadUrl=entity.LanMenuPostImg.ToStr();
}
//////LanMenuDetail自定义事件替换1
//////LanMenuDetail自定义事件替换2
//////LanMenuDetail自定义事件替换3
//////LanMenuDetail自定义事件替换4
//////LanMenuDetail自定义事件替换5
//////LanMenuDetail自定义事件替换6
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity =Yaohuasoft.Framework.BLL.SysAdmin.LanMenuBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////LanMenuDetail初始化替换代码
////添加附加按钮代码
if (entity._CustomCode == null)
entity =Yaohuasoft.Framework.BLL.SysAdmin.LanMenuBLL.GetCustomCode(entity);
}
}
protected void ddl_PageSize_SelectedIndexChanged(object sender, EventArgs e)
{
Session["PageSize"] = this.ddl_PageSize.SelectedValue;
Bind();
}
protected void txt_TextChanged(object sender, EventArgs e)
{
Bind();
}
 /// <summary>
 /// 删除按钮事件
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 protected void btn_Delete_B_Click(object sender, EventArgs e)
 {
 DeleteData();
 }
 /// <summary>
 /// 删除数据，并刷新列表
 /// </summary>
 protected void DeleteData()
 {
 int ret=0;
 foreach (RepeaterItem item in UiDataList.Items)
 {
 var checkBox = item.FindControl("chkSelect") as CheckBox;
 var hiddenID = item.FindControl("hiddenID") as HiddenField;
 if (checkBox.Checked)
 {
 ret+=Yaohuasoft.Framework.BLL.SysAdmin.LanSecondMenuBLL.Delete(hiddenID.Value.ToString(),Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
 }
 }
 Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
 Bind();
 }
 protected void btn_Export_Click(object sender, EventArgs e)
 {
 Export2Excel();
 }
 /// <summary>
 /// 绑定数据
 /// </summary>
 protected void Export2Excel()
 {
/////////////////////以下以Bind()为准
 int count = 0;
 ////设置分页条数
 this.pager.PageSize = this.ddl_PageSize.SelectedValue.ToInt();
 YaohuaDict<string, string> dropList = new YaohuaDict<string, string>();
 YaohuaDict<string, string> textBox = new YaohuaDict<string, string>();
 YaohuaDict<string, string> textBoxInOne = new YaohuaDict<string, string>();
 YaohuaDict<string, string> sortList = new YaohuaDict<string, string>();
 textBoxInOne.Add(this.ddlTextInOne.SelectedValue, this.txtTextInOne.Text);
 sortList.Add("SortList", this.ddlSortList.Text);
////通过主表ID取附表
textBox.Add("LanMenuId",HttpUtility.UrlDecode(Request["id"]).ToString());
/////////////////////以上以Bind()为准
 ////取实体列表
 var list = Yaohuasoft.Framework.BLL.SysAdmin.LanSecondMenuBLL.GetList4Export(dropList, textBox, textBoxInOne,sortList,
 Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr(), out count);
 ////将实体列表变成DATATABLE
 DataTable dt = Yaohuasoft.Framework.BLL.SysAdmin.LanSecondMenuBLL.EntityList2DataTableCn(list.ToArray());
 ////将DATATABLE导出成EXCEL并下载
 ExcelService.DownloadExcel(dt);
 }
protected void btn_Delete_Click(object sender, EventArgs e)
{
string id = hiddenID.Value.ToString();
////LanMenuDetailDelete按钮赋值之前
////LanMenuDetail删除按钮处理之前
{
////LanMenuDetail删除方法之前
var ret =Yaohuasoft.Framework.BLL.SysAdmin.LanMenuBLL.Delete(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////LanMenuDetail删除按钮处理之后
}
}
}
