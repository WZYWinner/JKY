using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;

namespace UI.DEMO
{
    public partial class SysAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////验证登录权限
                SessionUtils check = new SessionUtils();
                bool result = check.CheckPower("SysAdmin");
                if (result == false)
                {
                   Response.Redirect("/Logout.aspx");
                }

                ////////////////////

                
            }
            //获取待办事项条数和数据集
            //int iCount = 0;
            //MessageManagementDALEntity[] message_list = MessageManagementBLL.GetCount(out iCount);
            //repMesaage.DataSource = message_list;
            //repMesaage.DataBind();
        }
    }
}