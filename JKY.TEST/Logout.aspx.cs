using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.DEMO
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Session["UserPowerList"] = "";
            Session["SysType"] = "";
            Session["Session"] = "";
            Session["RealName"] = "";
            Session["LastLoginTime"] = "";

            Response.Redirect("Index.aspx");
        }
    }
}