﻿using System;
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
    public class LanOrderHandler : BaseHanlder
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
                    ////创建收货地址
                    case "newOrder":
                        {
                            //获取用户编号
                            string userId = request["userId"] ?? "";
                            //获取地址Id
                            string addressId = request["addressId"] ?? "";
                            //获取商品列表
                            string  goodsList = request["goodsList"] ?? "";
                            goodsList = goodsList.Replace("\"\"", "null");

                            goodsList[] goods = JsonSerializer.Deserialize<goodsList[]>(goodsList);                                                      
                           
                            //获取订单商品总数量
                            string allNum = request["allNum"] ?? "";
                            //获取订单商品总金额
                            string allMoney = request["allMoney"] ?? "";
                            //获取配送费
                            string sendMoney = request["sendMoney"] ?? "";

                            if (userId.IsNullOrEmptys() || userId == "undefined" || addressId.IsNullOrEmptys() || addressId == "undefined" || goodsList.IsNullOrEmptys() || goodsList == "undefined"
                                || allNum.IsNullOrEmptys() || allNum == "undefined" || allMoney.IsNullOrEmptys() || allMoney == "undefined" || sendMoney.IsNullOrEmptys() || sendMoney == "undefined")
                            {
                                throw new Exception("参数不能为空");
                            }
                            //创建新的订单
                            else
                            {
                                //设置订单状态
                                var orderType = "待付款";
                                //订单的生成时间
                                var addTime = DateTime.Now;
                                //生成订单编号
                                var orderId = YaohuaID.NewID();
                                //获取收货地址信息
                                LanAddressQueryParameter address = new LanAddressQueryParameter();
                                address.EqualTo.SysUserId = userId;
                                address.EqualTo.LanAddressId = addressId;
                                //存放获取到的地址信息
                                var allAddress = LanAddressDAL.Select(0, address).FirstOrDefault();

                                if (allAddress.IsNullOrEmptys())
                                {
                                    throw new Exception("收货信息不存在");
                                }
                                //存放订单信息
                                var entity = new LanOrderListDALEntity();
                                //订单编号
                                entity.LanOrderListId = orderId;
                                //用户编号
                                entity.LanOrderListUserid = userId;
                                //收货地址
                                entity.LanOrderListAddress = allAddress.LanAddressName;
                                //收货人
                                entity.LanOrderListUsername = allAddress.LanAddressUsername;
                                //收货人电话
                                entity.LanOrderListUsertel = allAddress.LanAddressPhone;
                                //商品总数
                                entity.LanOrderListGoodsnum = allNum.ToInt();
                                //商品总金额
                                entity.LanOrderListSumgoodsprice = allMoney.ToDecimal();
                                //配送费
                                entity.LanOrderListSentprice = sendMoney.ToDecimal();
                                //订单总金额
                                entity.LanOrderListSumprice = allMoney.ToDecimal() + sendMoney.ToDecimal();
                                //订单添加时间
                                entity.LanOrderListAddtime = addTime;
                                //订单状态
                                entity.LanOrderType = orderType;
                                //添加订单到订单表中
                                LanOrderListDAL.Merge(0, entity);

                                foreach (var item in goods)
                                {
                                    var ordergoodsEntity = new LanOrderGoodDALEntity();
                                    //订单编号
                                    ordergoodsEntity.LanOrderListId = orderId;
                                    //商品id
                                    ordergoodsEntity.GoodsId = item.GoodsId;
                                    //商品名称                        
                                    ordergoodsEntity.GoodsMsg = item.GoodsName;
                                    //商品图标
                                    ordergoodsEntity.GoodsShowimg = item.GoodsShowimg;
                                    //商品单价
                                    ordergoodsEntity.GoodsPrice = item.GoodsPrice;
                                    //商品数量
                                    ordergoodsEntity.LanOrderGoodNum = item.num;
                                    //商品总计金额
                                    ordergoodsEntity.LanOrderGoodsSumprice = item.GoodsPrice * item.num;
                                    //添加到表中
                                    LanOrderGoodDAL.Merge(0,ordergoodsEntity);
                                }

                                output = JsonSerializer.Serialize(new { result_state = true, msg = "订单添加成功！！！",orderId=orderId});
                            }
                        }
                        break;
                    case "newOrder1":
                        {
                            //获取用户编号（完成）
                            string userId = request["userId"] ?? "";
                            //需要找（完成）
                            string goodsname = request["goodsname"] ?? "";
                            //配送姓名（完成）
                            string username = request["name"] ?? "";
                            string img = request["img"] ?? "";
                            //配送手机号（完成）
                            string phone = request["phone"] ?? "";
                            //获取地址（完成）
                            string address = request["address"] ?? "";
                            //获取订单商品总数量（完成）
                            string allNum = request["allNum"] ?? "";
                            //需要找（完成）
                            string amoney = request["amoney"] ?? "";
                            //获取订单商品总金额（完成）
                            string allMoney = request["allMoney"] ?? "";
                            //获取配规格（完成）
                            string sendMoney = request["sendMoney"] ?? "";
                            //设置订单状态（完成）
                            var orderType = "待付款";
                            //订单的生成时间（完成）
                            var addTime = DateTime.Now;
                            //生成订单编号（完成）
                             var orderId = YaohuaID.NewID();
                             //存放订单信息
                             var entity = new LanOrderListDALEntity();
                             //订单编号
                             entity.LanOrderListId = orderId;
                             //用户编号
                             entity.LanOrderListUserid = userId;
                             //收货地址
                             entity.LanOrderListAddress = address;
                             //收货人
                             entity.LanOrderListUsername = username;
                             //收货人电话
                             entity.LanOrderListUsertel = phone;
                             //商品总数
                             entity.LanOrderListGoodsnum = allNum.ToInt();
                             //商品总金额
                             entity.LanOrderListSumgoodsprice = allMoney.ToDecimal();
                            //配送费
                             entity.LanOrderListSenduser = sendMoney;
                            //订单总金额
                             entity.LanOrderListType = goodsname;
                             //订单添加时间
                             entity.LanOrderListAddtime = addTime;
                             //订单状态
                             entity.LanOrderType = amoney;
                             entity.LanOrderListSendusertel = img;
                            //添加订单到订单表中
                            LanOrderListDAL.Merge(0, entity);                        
                             output = JsonSerializer.Serialize(new { result_state = true, msg = "订单添加成功！！！" });
                            
                        }
                        break;
                    case "getOrder1":
                        {
                            //用户ID
                            string userId = request["userId"] ?? "";
                          
                           
                                //查询订单
                                LanOrderListQueryParameter order = new LanOrderListQueryParameter();
                                order.EqualTo.LanOrderListUserid = userId;
                                var allOrder = LanOrderListDAL.Select(0, order);

                                if (allOrder.IsNullOrEmptys())
                                {
                                    throw new Exception("订单为空");
                                }
                                else
                                {  
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "订单获取成功！！！", orders =allOrder });
                                }       
                        }
                        break;
                    case "getOrder":
                        {
                            //用户ID
                            string userId = request["userId"] ?? "";
                            if (userId == "undefined" || userId.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID不能为空");
                            }
                            else
                            {
                                //查询订单
                                LanOrderListQueryParameter order = new LanOrderListQueryParameter();
                                order.EqualTo.LanOrderListUserid = userId;
                                var allOrder = LanOrderListDAL.Select(0, order);

                                if (allOrder.IsNullOrEmptys())
                                {
                                    throw new Exception("订单为空");
                                }
                                else
                                {
                                    //创建一个存放订单的列表                                    
                                    ArrayList list = new ArrayList();
                                    
                                    //遍历获取到的订单
                                    for (var i = 0; i < allOrder.Length; i++)
                                    {                                                              
                                        //从订单明细中获取商品信息
                                        LanOrderGoodQueryParameter goodsOrder = new LanOrderGoodQueryParameter();
                                        goodsOrder.EqualTo.LanOrderListId = allOrder[i].LanOrderListId;
                                        //查询该条订单下的商品明细信息
                                        var goodList = LanOrderGoodDAL.Select(0, goodsOrder);

                                        list.Add(new {order=allOrder[i],goods=goodList });
                                        
                                        
                                    }
                                    
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "订单获取成功！！！", orders = list });
                                }
                            }                      
                        }
                        break;
                    case "delete":
                        {
                            string userId = request["orderId"] ?? "";

                            //查询数据库中的记录
                            LanOrderListQueryParameter order = new LanOrderListQueryParameter();
                            order.EqualTo.LanOrderListId = userId;
                            var deleteAddress = LanOrderListDAL.Select(0, order).FirstOrDefault();

                            //删除一条记录
                            LanOrderListDAL.Delete(0, userId);
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "删除成功！！！" });


                        }
                        break;
                    case "getOneOrder":
                        {
                            //用户ID
                            string userId = request["userId"] ?? "";
                            //订单ID
                            string orderId = request["orderId"] ?? "";
                            if (userId == "undefined" || userId.IsNullOrEmptys() || orderId == "undefined" || orderId.IsNullOrEmptys())
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //创建查询，查询一条订单
                                LanOrderListQueryParameter getoneOrder = new LanOrderListQueryParameter();
                                getoneOrder.EqualTo.LanOrderListId = orderId;
                                getoneOrder.EqualTo.LanOrderListUserid = userId;
                                //存储订单记录
                                var oneorder = LanOrderListDAL.Select(0, getoneOrder);
                                //判断订单是否存在
                                if (oneorder.IsNullOrEmptys())
                                {
                                    throw new Exception("订单为空");
                                }
                                else
                                {
                                    //创建一个存储该条订单的空间，存储订单及订单明细
                                    ArrayList list = new ArrayList();
                                    //查询该订单的订单明细
                                    LanOrderGoodQueryParameter getOrderGoods = new LanOrderGoodQueryParameter();
                                    getOrderGoods.EqualTo.LanOrderListId = orderId;
                                    //存放订单明细
                                    var orderGoods = LanOrderGoodDAL.Select(0, getOrderGoods);
                                    //将订单及订单明细添加到数组中
                                    list.Add(new { oneorder = oneorder, goods = orderGoods });

                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "订单获取成功！！！", oneOrder = list });
                                }
                                
                            }
                        }
                        break;
                    case "updateOrder":
                        {
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
    public class goodsList
    {
        //商品编号
        public string GoodsId { get; set; }
        //商品名称
        public string GoodsName { get; set; }
        //商品数量
        public int num { get; set; }
        //商品单价
        public decimal GoodsPrice { get; set; }
        //商品图标
        public string GoodsShowimg { get; set; }
    }
  
}