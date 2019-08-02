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
    public class LxcGoods : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {
            //base.ExecuteRequest(context);
            try
            {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    ////获取商品表
                    case "ShowGoods":
                        {
                            //获取数据库中的用户密码,数据库名称为SysUser
                            LxcGoodsQueryParameter Parm = new LxcGoodsQueryParameter();
                            var Goods = LxcGoodsDAL.Select(0, Parm);
                            //判断获取的用户名是否存在

                            output = JsonSerializer.Serialize(new { result_state = true, msg = "请求成功", Goods = Goods});

                        }
                        break;
                    ////获取收货地址
                    case "SelectAddress":
                        {
                            //获取数据库中的用户密码,数据库名称为SysUser
                            LxcAddressQueryParameter Parm = new LxcAddressQueryParameter();
                            var Address = LxcAddressDAL.Select(0, Parm);
                            //判断获取的用户名是否存在

                            output = JsonSerializer.Serialize(new { result_state = true, msg = "请求成功", Address = Address });
                        }
                        break;
                    ////添加收货地址
                    case "AddAdres":
                        {
                            string name = request["name"] ?? "";
                            string phone = request["phone"] ?? "";
                            string adres = request["adres"] ?? "";
                            string status = request["status"] ?? "";

                            LxcAddressQueryParameter Parm = new LxcAddressQueryParameter();
                            var entity = new LxcAddressDALEntity();
                            entity.LxcAddressName = name;
                            entity.LxcAddressPhone = phone;
                            entity.LxcAddressAdres = adres;
                            entity.LxcAddressStatus = status;
                            LxcAddressDAL.Merge(0, entity);
                            string sql = SystemConfig.SQL;
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "添加收货地址成功" });
                        }
                        break;
                    case "updateAddress":
                        {
                            string id = request["id"] ?? "";
                            string name = request["name"] ?? "";
                            string phone = request["phone"] ?? "";
                            string adres = request["address"] ?? "";

                            LxcAddressDALEntity address = new LxcAddressDALEntity();
                            address.LxcAddressId = id;
                            address.LxcAddressName = name;
                            address.LxcAddressPhone = phone;
                            address.LxcAddressAdres = adres;
                            var update = LxcAddressDAL.Merge(0, address);

                            output = JsonSerializer.Serialize(new { result_state = true, msg = "111" });
                        }
                        break;
                    ////将提交商品添加到订单表内
                    case "Submit":
                        {
                            string Submit = request["Submit"] ?? "";

                            Submit =Submit.Replace("\"\"", "null");
                            Submit[] submit= JsonSerializer.Deserialize<Submit[]>(Submit);
                            LxcSubmitQueryParameter Parm = new LxcSubmitQueryParameter();
                            var NewTime = DateTime.Now;
                            var entity = new LxcSubmitDALEntity();
                            foreach (var item in submit)
                            {
                                var submitEntity = new LxcSubmitDALEntity();
                                //商品名称
                                submitEntity.LxcSubmitName = item.Name;
                                //商品价格
                                submitEntity.LxcSubmitPrice = item.Price;
                                //商品图片
                                submitEntity.LxcSubmitPic = item.Pic;
                                //商品数量
                                submitEntity.LxcSubmitNum = item.Num;
                                //下单用户
                                submitEntity.LxcSubmitAddressName = item.AddressName;
                                //手机号
                                submitEntity.LxcSubmitAddressPhone = item.AddressPhone;
                                //下单地址
                                submitEntity.LxcSubmitAddressAdres = item.AddressAdres;
                                //下单时间
                                submitEntity.LxcSubmitAddressTime = NewTime;
                                //添加到表中
                                LxcSubmitDAL.Merge(0, submitEntity);
                            }
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "订单提交成功" });
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
    public class Submit
    {
        //商品名称
        public string Name { get; set; }
        //商品价格
        public decimal Price { get; set; }
        //商品图片
        public string Pic { get; set; }
        //商品数量
        public int Num { get; set; }
        //下单用户
        public string AddressName { get; set; }
        //手机号
        public string AddressPhone { get; set; }
        //下单地址
        public string AddressAdres { get; set; }
    }
}