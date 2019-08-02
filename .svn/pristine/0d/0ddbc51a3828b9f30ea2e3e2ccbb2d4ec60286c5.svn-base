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
    public class MCarouselHandler : BaseHanlder
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
                    //轮播图一
                    case "carouselOne":
                        {
                            #region 轮播图一获取
                            CarouselOneQueryParameter parm = new CarouselOneQueryParameter();
                            var carouselOneEntity = CarouselOneDAL.Select(0, parm);
                            if (carouselOneEntity.IsNullOrEmptys())
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "缺少轮播资源" });
                            }
                            List<CarouselEntity> list = new List<CarouselEntity>();
                            foreach (var item in carouselOneEntity)
                            {
                                var carouselEntity = new CarouselEntity();
                                carouselEntity.ID = item.Id;
                                carouselEntity.Seller = item.Seller;
                                carouselEntity.AddPic = item.AdPic;
                                carouselEntity.AdText = item.AdText;
                                list.Add(carouselEntity);

                            }
                            //输出获取的图片
                            output = JsonSerializer.Serialize(new { result_state = true, list });
                            #endregion
                        }
                        break;
                    //轮播图二   
                    case "carouselTwo":
                        {
                            #region 轮播图二获取
                            CarouselTwoQueryParameter parm = new CarouselTwoQueryParameter();
                            var carouselTwoEntity = CarouselTwoDAL.Select(0, parm);                            
                            if (carouselTwoEntity.IsNullOrEmptys())
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "缺少轮播资源" });
                            }
                            List<CarouselEntity> list = new List<CarouselEntity>();
                            foreach (var item in carouselTwoEntity)
                            {
                                var carouselEntity = new CarouselEntity();
                                carouselEntity.ID = item.Id;
                                carouselEntity.Seller = item.Seller;
                                carouselEntity.AddPic = item.AdPic;
                                carouselEntity.AdText = item.AdText;
                                list.Add(carouselEntity);

                            }
                            //输出获取的图片
                            output = JsonSerializer.Serialize(new { result_state = true, list });
                            #endregion
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

        public class CarouselEntity
        {
            #region 轮播图实体
            public string ID { get; set; }//ID
            public string Seller { get; set; }//卖家
            public string AddPic { get; set; }//轮播图片
            public string AdText { get; set; }//轮播文字
            #endregion


        }
    }
}