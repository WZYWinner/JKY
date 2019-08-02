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
    public class MOrderHandler : BaseHanlder
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
                    //获取单个商品下单的订单
                    case "GetOrder":
                        {
                            #region 用户下单，将订单信息加支付表中。 
                            #region 获取参数
                            //获取用户ID
                            string UserID = request["UserID"] ?? "";
                            //获取商品列表 （一串商品ID）
                            var  GoodsIdList = request["GoodsIdList"] ?? "";
                            //获取订单商品总数量 （将会出现数据沉余）
                            string AllNum = request["AllNum"] ?? "";
                            //获取订单商品总金额  （将会出现数据沉余）
                            string AllMoney = request["AllMoney"] ?? "";

                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("参数1不能为空！");
                            }                            
                            if (GoodsIdList.IsNullOrEmptys())
                            {
                                throw new Exception("参数2不能为空！");
                            }
                            if (AllNum.IsNullOrEmptys())
                            {
                                throw new Exception("参数3不能为空！");
                            }
                            if (AllMoney.IsNullOrEmptys())
                            {
                                throw new Exception("参数4不能为空！");
                            }
                            #endregion                         
                            GoodsIdEntity[] goodsIdList = JsonSerializer.Deserialize<GoodsIdEntity[]>(GoodsIdList);
                            //选取默认地址
                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            parm.EqualTo.UserId = UserID;
                            parm.EqualTo.State = "true";
                            var AddressEntity = MzqAddressDAL.Select(0, parm).FirstOrDefault();
                            //如果没有默认地址则随便选取第一条地址
                            if(AddressEntity.IsNullOrEmptys())
                            {
                                MzqAddressQueryParameter parm1 = new MzqAddressQueryParameter();
                                parm.EqualTo.UserId = UserID;
                                AddressEntity = MzqAddressDAL.Select(0, parm1).FirstOrDefault();
                            }
                            var list = new List<MzqPayDALEntity>();
                            //根据商品ID个数遍历  
                            for (var i = 0; i < goodsIdList.Length; i++)
                                {
                                #region 向订单表中添加订单
                                var entity = new MzqOrderDALEntity();
                                //订单ID
                                entity.BillId = YaohuaID.NewID();
                                //商品ID
                                entity.GoodsId = goodsIdList[i].GoodsId;
                                //订单时间
                                entity.SettlementTime = DateTime.Now;
                                //订单状态
                                entity.SettlementState = "待付款";
                                //付款总金额
                                entity.SettlementMoney = Convert.ToDecimal(AllMoney);
                                //用户ID
                                entity.UserId = UserID;
                                //收货地址ID
                                entity.AddressId = AddressEntity.AddressId;
                                //配送费 此为定值 尚未完善此功能 (商品表里缺少,购物车缺少)
                                entity.Freight = 10;

                                //向订单表中添加订单
                                MzqOrderDAL.Merge(0, entity);
                                #endregion
                                #region 根据订单表中商品ID 获取购物车的商品信息 并向支付表加订单
                                //购物车中的商品信息
                                MzqShoppingcarQueryParameter ShoppingCarParm = new MzqShoppingcarQueryParameter();
                                ShoppingCarParm.EqualTo.MzqGoodsId = goodsIdList[i].GoodsId;
                                var entity1 = MzqShoppingcarDAL.Select(0, ShoppingCarParm);
                                //支付订单
                                var PayEntity = new MzqPayDALEntity();                               
                                foreach (var item1 in entity1)
                                {
                                    PayEntity.UserId = UserID;
                                    PayEntity.BillId = entity.BillId;
                                    PayEntity.AddressId = AddressEntity.AddressId;
                                    PayEntity.SettlementState = "待付款";
                                    PayEntity.SettlementTime = DateTime.Now;
                                    PayEntity.GoodsId = item1.MzqGoodsId;
                                    PayEntity.GoodsName = item1.MzqShoppingcarName;
                                    PayEntity.GoodsNumber = Convert.ToInt32(item1.GoodsNumber);
                                    PayEntity.GoodsPic = item1.MzqShoppingcarPic;
                                    PayEntity.GoodsPrice = Convert.ToDecimal(item1.MzqShoppingcarPrice);
                                    //将数据添加到支付表中
                                    MzqPayDAL.Merge(0, PayEntity);
                                    list.Add(PayEntity);
                                }
                                
                                #endregion

                            }

                            for (var  i = 0; i < goodsIdList.Length; i++)
                            {
                                //商品添加后，清空购物车
                                MzqShoppingcarQueryParameter ShoppingCarParm1 = new MzqShoppingcarQueryParameter();
                                ShoppingCarParm1.EqualTo.MzqGoodsId = goodsIdList[i].GoodsId;                                
                                MzqShoppingcarDAL.Delete(0, ShoppingCarParm1);
                                var entity2 = MzqShoppingcarDAL.Select(0, ShoppingCarParm1).FirstOrDefault();
                                if (!entity2.IsNullOrEmptys())
                                {
                                    throw new Exception("购物车未清除成功！");
                                }
                            }
                            output = JsonSerializer.Serialize(new { result_state = true,msg = "订单添加成功！" ,list});
                            #endregion
                        }
                        break;
                    case "GetMyAddress":
                        {
                            #region 获取当前结算的商品信息
                            //用户名
                            String  UserID = request["UserID"] ?? "";                          
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("参数1不能为空！");
                            }
                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            parm.EqualTo.UserId = UserID;
                            //没有做选择地址功能，默认选择默认地址
                            parm.EqualTo.State = "true";
                            var entity1 = MzqAddressDAL.Select(0, parm).FirstOrDefault();
                            //如果没有默认地址就随便选第一个
                            if (entity1.IsNullOrEmptys())
                            {
                                MzqAddressQueryParameter parm1 = new MzqAddressQueryParameter();
                                parm1.EqualTo.UserId = UserID;
                                entity1 = MzqAddressDAL.Select(0, parm1).FirstOrDefault();
                            }
                            var list = new List<OrderEntity>();
                            var entity = new OrderEntity();
                            entity.ConsigneeInfo = entity1.ConsigneeInfo;//收货人
                            entity.ReceivingAddress = entity1.ReceivingAddress;//详细收货地址
                            entity.ConsigneeRegion = entity1.ConsigneeRegion;//收货地区
                            entity.Telephone = entity1.Telephone;
                            entity.State = "默认";
                            list.Add(entity);
                           output = JsonSerializer.Serialize(new { result_state = true, msg = "收货地址获取成功！",list });
                            #endregion

                        }
                        break;
                    //展示历史中所有的订单  
                    case "ShowOrder":
                        {
                            #region 展示订单获取表中的订单
                            //获取用户ID
                            string UserID = request["UserID"] ?? "";
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID参数为空！");
                            }
                            //查找所有商品
                            MzqPayQueryParameter parm = new MzqPayQueryParameter();
                            parm.EqualTo.UserId = UserID;
                            var entity = MzqPayDAL.Select(0, parm);
                            //将得到的商品信息装进list传出
                            List<ShowOrderEntity> list = new List<ShowOrderEntity>();                          
                            foreach (var item in entity)
                            {
                                //这个放遍历外面将会获取重复的数据
                                var showOrder = new ShowOrderEntity();

                                showOrder.AddressId = item.AddressId;
                                showOrder.GoodsID = item.GoodsId;
                                showOrder.GoodsName = item.GoodsName;
                                showOrder.GoodsNumber = Convert.ToInt32(item.GoodsNumber);
                                showOrder.GoodsPic = item.GoodsPic;
                                showOrder.GoodsPrice = Convert.ToDecimal(item.GoodsPrice);
                                showOrder.SettlementState = item.SettlementState;
                                showOrder.SettlementTime = Convert.ToDateTime( item.SettlementTime);
                                showOrder.UserId = item.UserId;
                                list.Add(showOrder);
                            }
                            if(list.IsNullOrEmptys())
                            {
                                throw new Exception("该用户下，尚不存在订单。");
                            }
                            output = JsonSerializer.Serialize(new { result_state = true , msg= "获取订单成功！", list });
                            #endregion
                        }
                        break;
                    //查找所有订单中相关订单   
                    case "SelectAllOrder":
                        {
                            #region 查找所有订单 用于我的订单中订单搜索
                            //用户ID
                            string UserID = request["UserID"] ?? "";
                            //搜索信息
                            string SelectInfo = request["SelectInfo"] ?? "";
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID参数为空！");
                            }
                            if (SelectInfo.IsNullOrEmptys())
                            {
                                throw new Exception("查询信息参数为空！");
                            }
                            //在支付中得到看，相关的订单信息
                            MzqPayQueryParameter parm = new MzqPayQueryParameter();
                            parm.EqualTo.UserId = UserID;
                            parm.Like.GoodsName = SelectInfo;

                           
                            var entity = MzqPayDAL.Select(0, parm);
                            //将得到的商品信息装进list传出
                            List<ShowOrderEntity> list = new List<ShowOrderEntity>();
                            var showOrder = new ShowOrderEntity();
                            foreach (var item in entity)
                            {
                                showOrder.AddressId = item.AddressId;
                                showOrder.GoodsID = item.GoodsId;
                                showOrder.GoodsName = item.GoodsName;
                                showOrder.GoodsNumber = Convert.ToInt32(item.GoodsNumber);
                                showOrder.GoodsPic = item.GoodsPic;
                                showOrder.GoodsPrice = Convert.ToDecimal(item.GoodsPrice);
                                showOrder.SettlementState = item.SettlementState;
                                showOrder.SettlementTime = Convert.ToDateTime(item.SettlementTime);
                                showOrder.UserId = item.UserId;
                                list.Add(showOrder);
                            }


                            output = JsonSerializer.Serialize(new { result_state = true,msg = "查询成功！",list});
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
        public class GoodsIdEntity
        {
            #region 商品ID 商品名实体
            public string GoodsId { get; set; }//商品ID
            public string GoodsName { get; set; }//商品名称
            #endregion
        }
        public class OrderEntity
        {
            #region 订单实体
            public string ID { get; set; }//ID
            public string CoupName { get; set; }//卖家
            public string SettlementMoney { get; set; }//结算总金额
            public DateTime SettlementTime { get; set; }//结算时间
            public string SettlementState { get; set; }//结算状态
            public string NameInfo { get; set; }//收货人姓名
            public string ConsigneeRegion { get; set; }//收货区域
            public string ConsigneeInfo { get; set; }//收货人
            public string RegionInfo { get; set; }//地区
            public string ReceivingAddress { get; set; }//详细地址
            public string State { get; set; }//收货地址状态
            public string Telephone { get; set; }//手机号码
            #endregion

        }
        public class GoodsEntity
        {
            #region 商品实体
            public string GoodsID { get; set; }//商品ID
            public string GoodsName { get; set; }//商品名
            public Decimal GoodsPrice { get; set; }//商品价格
            public string GoodsPic { get; set; }//商品图片
            public int GoodsNumber { get; set; }//商品数量
            #endregion
        }
        public class ShowOrderEntity
        {           
            #region 展示订单商品实体
            public string UserId { get; set; }//用户ID
            public string GoodsID { get; set; }//商品ID
            public string GoodsName { get; set; }//商品名
            public Decimal GoodsPrice { get; set; }//商品价格
            public string GoodsPic { get; set; }//商品图片
            public int GoodsNumber { get; set; }//商品数量
            public string ID { get; set; }//订单ID
            public string SettlementState { get; set; }//结算状态
            public string AddressId { get; set; }//收货地址ID
            public DateTime SettlementTime { get; set; }//结算时间
            #endregion
        }      
    }
}