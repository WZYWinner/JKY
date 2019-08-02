using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.Library;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.DAL;
namespace Yaohuasoft.Framework.WebUI.GsfAdmin
{
public partial class SysUserList : System.Web.UI.Page
{
int CurrentPageIndex = 1;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();
if (Request["type"] == "back")
{
Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//LIST2绑定数据占位符
//绑定数据
if (!IsPostBack)
{
DataInit();
//数据绑定
Bind();
}
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
if(queryDict.ContainsKey("PageIndex"))CurrentPageIndex=queryDict["PageIndex"].ToInt();
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("GsfAdmin");
if (result == true)
result=check.CheckPower("GsfAdmin", "后台用户");
if (result == false)
{
Response.Write("<script> top.window.location.href = '/Logout.aspx?r='+Math.random() ;</script>");
////TODO 临时测试代码
Response.End();
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
protected void Bind()
{
int count = 0;
////设置分页条数
this.pager.PageSize = this.ddl_PageSize.SelectedValue.ToInt();
YaohuaDict<string, string> dropList = new YaohuaDict<string, string>();
YaohuaDict<string, string> textBox = new YaohuaDict<string, string>();
YaohuaDict<string, string> textBoxInOne = new YaohuaDict<string, string>();
YaohuaDict<string, string> sortList = new YaohuaDict<string, string>();
textBoxInOne.Add(this.ddlTextInOne.SelectedValue, this.txtTextInOne.Text);
sortList.Add("SortList", this.ddlSortList.Text);
if (IsPostBack) CurrentPageIndex = pager.CurrentPageIndex;////如果是回调的，用分页控件的页码
QueryString.Value=QuerySerivce.QueryDict2String(dropList,textBox,textBoxInOne,sortList,CurrentPageIndex);
var list =Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.GetList(dropList, textBox, textBoxInOne, sortList,
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
Response.Redirect("SysUser_Detail.aspx?&rnd="+YaohuaID.GenRandomInt()+"&query="+HttpUtility.UrlEncode(Request["query"])+"&id=" + list[0].SysUserId.ToStr());
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
/////////////////////以上以Bind()为准
 ////取实体列表
 var list = Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.GetList4Export(dropList, textBox, textBoxInOne,sortList,
 Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr(), out count);
 ////将实体列表变成DATATABLE
 DataTable dt = Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.EntityList2DataTableCn(list.ToArray());
 ////将DATATABLE导出成EXCEL并下载
 ExcelService.DownloadExcel(dt);
 }
protected void pager_PageChanged(object sender, EventArgs e)
{
Bind();
}
protected void btn_Search_Click(object sender, EventArgs e)
{
Bind();
}
 /// <summary>
 /// 删除按钮事件
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 protected void btn_Delete_Click(object sender, EventArgs e)
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
 ret+=Yaohuasoft.Framework.BLL.GsfAdmin.SysUserBLL.Delete(hiddenID.Value.ToString(),Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
 }
 }
 Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
 Bind();
 }
}
}
