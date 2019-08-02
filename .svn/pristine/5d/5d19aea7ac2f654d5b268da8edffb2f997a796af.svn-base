using System;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// MActivityHandler 的摘要说明
    /// </summary>
    public class MActivityHandler : BaseHanlder
    {
        protected override void ExecuteRequest(HttpContext context)
        {
            try
            {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    //获取活动券信息   
                    case "GetCoupon":
                        {
                         
                        }
                        break;
                    //用户获取活动券  
                    case "UserGetCoupon":
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                output = JsonSerializer.Serialize(new { result_state = false, msg = ex.Message });
            }
        }
    }
}