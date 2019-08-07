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
namespace Yaohuasoft.Framework.WebUI.GsfAdmin
{
public partial class GuoGoodsDetail : System.Web.UI.Page
{
public GuoGoodsDALEntity entity = null;
protected void Page_Load(object sender, EventArgs e)
{
////身份验证
CheckSession();//WEB
if (Request["type"]== "back")
{
Yaohuasoft.Framework.BLL.GsfAdmin.GuoGoodsBLL.DealCustomCode(Request["id"], Request["btnId"]);
////Response.Write("<script>alert('" + msg + "');</script>");
}
//绑定数据
if (!IsPostBack)
{
Bind();
}
////GuoGoodsDetailInitEntity方法之前
////初始化实体
InitEntity();
////GuoGoodsDetailInitEntity方法之后
}
protected void CheckSession()
{
////验证登录权限
SessionUtils check = new SessionUtils();
bool result = check.CheckPower("GsfAdmin");
if (result == true)
result=check.CheckPower("GsfAdmin", "商品");
if (result == false)
{
Response.Write("<script> top.window.location.href = '/Logout.aspx?r='+Math.random() ;</script>");
////TODO 临时测试代码
Response.End();
}
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
}
//////GuoGoodsDetail自定义事件替换1
//////GuoGoodsDetail自定义事件替换2
//////GuoGoodsDetail自定义事件替换3
//////GuoGoodsDetail自定义事件替换4
//////GuoGoodsDetail自定义事件替换5
//////GuoGoodsDetail自定义事件替换6
private void InitEntity()
{
if (entity == null)
{
string id = HttpUtility.UrlDecode(Request["id"]).ToString();
hiddenID.Value = id.ToString();
entity =Yaohuasoft.Framework.BLL.GsfAdmin.GuoGoodsBLL.GetEntity(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
////必须克隆不然会影响缓存数据
entity = entity.Clone();
////GuoGoodsDetail初始化替换代码
////添加附加按钮代码
if (entity._CustomCode == null)
entity =Yaohuasoft.Framework.BLL.GsfAdmin.GuoGoodsBLL.GetCustomCode(entity);
}
}
protected void btn_Delete_Click(object sender, EventArgs e)
{
string id = hiddenID.Value.ToString();
////GuoGoodsDetailDelete按钮赋值之前
////GuoGoodsDetail删除按钮处理之前
{
////GuoGoodsDetail删除方法之前
var ret =Yaohuasoft.Framework.BLL.GsfAdmin.GuoGoodsBLL.Delete(id,Session["CorpId"].ToStr(),Session["DepartmentId"].ToStr(),Session["UserName"].ToStr());
if (ret > 0)
{
Response.Write("<script>alert('成功处理"+ret.ToString()+"条数据');</script>");
Response.Write("<script>var obj; if(top==parent)obj=self;else obj=parent;obj.location.reload();</script>");
return;
}
Bind();
errormsg.Text = "操作失败！";
}
////GuoGoodsDetail删除按钮处理之后
}
}
}
