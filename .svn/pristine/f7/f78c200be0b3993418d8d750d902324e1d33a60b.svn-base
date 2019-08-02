using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
namespace Yaohuasoft.Framework.WebUI.SysAdmin
{
public partial class LanMenuUpload : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
if (!IsPostBack)
{
CheckSession();
DataInit();
}
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
protected void DataInit()
{
}
 protected void btn_Import_Click(object sender, EventArgs e)
 {
 ImportData();
 }
 protected void ImportData()
 {
 string filePath = FileUploadService.UploadExcel(this.FileUpload1);
 DataTable dataTable = YaohuaExcel.Excel2DataTable(filePath);
 /////以下是有审批的业务逻辑
 /////以下是无审批的业务逻辑
 var result = Yaohuasoft.Framework.BLL.SysAdmin.LanMenuBLL.ImportExcel2Db(dataTable,ImportExcelType.UseImport,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
 lbMessage.Text = result;
 return;
 }
}
}
