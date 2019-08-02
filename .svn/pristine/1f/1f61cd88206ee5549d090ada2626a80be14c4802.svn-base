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
using System.Collections.Generic;


namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class LxcShoppingCart : BaseHanlder
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
                    //登录
                    case "ShoppingCart":
                        {
                            //获取数据库中的用户密码,数据库名称为SysUser
                            LxcShoppingcartQueryParameter Parm = new LxcShoppingcartQueryParameter();
                            var Shopping = LxcShoppingcartDAL.Select(0, Parm);
                            //判断获取的用户名是否存在

                            output = JsonSerializer.Serialize(new { result_state = true, msg = "请求成功", Shopping=Shopping });

                        }
                        break;
                    //提交    
                    case "Submit":
                        {
                            LxcShoppingcartQueryParameter Parm = new LxcShoppingcartQueryParameter();
                            var Shopping = LxcShoppingcartDAL.Select(0, Parm);
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