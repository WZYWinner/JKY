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
using System.Collections;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class LanGetCarouselHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            //base.ExecuteRequest(context);
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    ////获取子菜单
                    case "Carousel":
                        {
                            LanCarouselQueryParameter getCarousel = new LanCarouselQueryParameter();
                            var Carousels = LanCarouselDAL.Select(0, getCarousel);
                            if (Carousels.IsNullOrEmptys())
                            {
                                throw new Exception("系统还未添加轮播图");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "获取轮播图成功",carousels=Carousels });
                            }
                        }
                        break;                                
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                 output = JsonSerializer.Serialize(new { result_state = false, msg=ex.Message });
            }
        }
    }
}