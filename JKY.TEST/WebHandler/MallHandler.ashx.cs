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
    /// Handler1 的摘要说明
    /// </summary>
    public class MallHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {
            base.ExecuteRequest(context);
            try
            {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    /// <summary>
                    /// ！！！！！！！购物车缺少用户ID,用户不登录也可以查看购物车！！！！！待解决
                    /// </summary>

                    //获取商品
                    case "getGoods":
                        {
                            #region 从数据库中获取商品信息                           
                            MzqGoodsQueryParameter goodsParm = new MzqGoodsQueryParameter();
                            var goodsEntity = MzqGoodsDAL.Select(0, goodsParm);
                            List<GoodsEntity> goodsList = new List<GoodsEntity>();
                            //！！！！！！！！！！！！！！！！！！！！缺少分页！！！！！！！！！                      
                            foreach (var goods_entity in goodsEntity)
                            {
                                var  goods = new GoodsEntity();
                                goods.GoodsID = goods_entity.MzqGoodsId;
                                goods.GoodsName = goods_entity.MzqGoodsName;
                                goods.GoodsPrice = Convert.ToDecimal(goods_entity.MzqGoodsPrice);
                                goods.GoodsPic = goods_entity.MzqGoodsPic;

                                goodsList.Add(goods);

                            }
                            output = JsonSerializer.Serialize(new { result_state = true, goodsList  });
                            #endregion
                        }
                        break;
                   
                        //向购物车添加商品 如果购物车中有该商品只做数量上的增加
                    case "addCart":
                        {
                            #region 根据商城中传过来的商品ID 查找相关商品信息 并添加到购物车表中
                            string GoodsID = request["GoodsID"] ?? "";
                            if (GoodsID.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            //根据商品ID获取商品信息
                            MzqGoodsQueryParameter goodsParm = new MzqGoodsQueryParameter();
                            goodsParm.EqualTo.MzqGoodsId = GoodsID;
                            var goodsDal = MzqGoodsDAL.Select(0, goodsParm).FirstOrDefault();

                            //查询购物车表是否存在此商品ID 
                            MzqShoppingcarQueryParameter carParm = new MzqShoppingcarQueryParameter();
                            carParm.EqualTo.MzqGoodsId = GoodsID;                          
                            var cartEntity = MzqShoppingcarDAL.Select(0, carParm).FirstOrDefault();
                            
                            List<CarEntity> goodsList = new List<CarEntity>();
                            var entity = new MzqShoppingcarDALEntity();
                            //var goods = new CarEntity();
                            //如果购物车中没有改商品，则添加该商品
                            if (cartEntity == null)
                            {

                                entity.MzqGoodsId = goodsDal.MzqGoodsId;
                                entity.MzqShoppingcarName = goodsDal.MzqGoodsName;
                                entity.MzqShoppingcarPrice = Convert.ToDecimal(goodsDal.MzqGoodsPrice);
                                entity.MzqShoppingcarPic = goodsDal.MzqGoodsPic;
                                entity.GoodsNumber = 1;
                                entity.CheckedSate = "false";
                               
                                //goods.GoodsID = goodsDal.MzqGoodsId;
                                //goods.GoodsName = goodsDal.MzqGoodsName;
                                //goods.GoodsPrice = Convert.ToDecimal(goodsDal.MzqGoodsPrice);
                                //goods.GoodsPic = goodsDal.MzqGoodsPic;
                                //如果有则获取商品信息并存进购物车表里
                                MzqShoppingcarDAL.Insert(0, entity);
                                //goodsList.Add(goods);
                                }
                                else
                                {
                                //如果购物车中有该商品只做数量上的增加 
                                var GoodsEntity = MzqShoppingcarDAL.Select(0, carParm).FirstOrDefault();
                                GoodsEntity.GoodsNumber = GoodsEntity.GoodsNumber + 1;
                                MzqShoppingcarDAL.Merge(0, GoodsEntity);

                              }

                            output = JsonSerializer.Serialize(new { result_state = true,msg = "成功向购物车添加商品" });
                            #endregion
                        }
                        break;
                    //获取购物车商品
                    case "getCartGoods":
                        {
                            #region 获取购物车商品
                            MzqShoppingcarQueryParameter carParm = new MzqShoppingcarQueryParameter();
                            var cartEntity = MzqShoppingcarDAL.Select(0, carParm);
                            //如果购物车没有商品就返回购物车为空
                            if (cartEntity.IsNullOrEmptys())
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "购物车为空" });
                            }
                            List<CarEntity> list = new List<CarEntity>();
                            //遍历购物车商品
                            foreach (var item in cartEntity)
                            {
                                var carEntity = new CarEntity();
                                //不强制转换获取不到商品ID
                                carEntity.GoodsID = Convert.ToString(item.MzqGoodsId);
                                carEntity.GoodsName = item.MzqShoppingcarName;
                                carEntity.GoodsPrice = Convert.ToDecimal(item.MzqShoppingcarPrice);
                                carEntity.GoodsPic = item.MzqShoppingcarPic;
                                carEntity.GoodsNumber = Convert.ToInt32(item.GoodsNumber);
                                carEntity.CheckState = item.CheckedSate;                            
                                list.Add(carEntity);

                            }
                            //输出购物车中的商品
                            output = JsonSerializer.Serialize(new { result_state = true, list });
                            #endregion

                        }
                        break;
                        //购物车商品数量增加
                    case "addNum":
                        {
                            #region 购物车商品数量增加
                            string GoodsID = request["GoodsID"] ?? "";
                            if (GoodsID.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            MzqShoppingcarQueryParameter parm = new MzqShoppingcarQueryParameter();
                            parm.EqualTo.MzqGoodsId = GoodsID;
                            var cartEntity = MzqShoppingcarDAL.Select(0, parm).FirstOrDefault();
                            //购物车商品数量加1
                            cartEntity.GoodsNumber = cartEntity.GoodsNumber + 1;
                            //更新数据库
                            MzqShoppingcarDAL.Merge(0, cartEntity);
                            #endregion
                        }
                        break;
                        //购物车商品减少
                    case "reduceNum":
                        {
                            #region 购物车商品减少
                            string GoodsID = request["GoodsID"] ?? "";
                            if (GoodsID.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            MzqShoppingcarQueryParameter parm = new MzqShoppingcarQueryParameter();
                            parm.EqualTo.MzqGoodsId = GoodsID;
                            var cartEntity = MzqShoppingcarDAL.Select(0, parm).FirstOrDefault();
                            //购物车商品数量减1
                            cartEntity.GoodsNumber = cartEntity.GoodsNumber - 1;
                            //最少为1
                            if (cartEntity.GoodsNumber <= 1) cartEntity.GoodsNumber = 1;
                            //更新数据库
                            MzqShoppingcarDAL.Merge(0, cartEntity);
                            #endregion
                        }
                        break;
                   
                    //删除商品
                    case "deleteGoods":
                        {
                            #region 获取需要删除的商品ID 进行删除商品   
                            //获取不到ID
                            string GoodsID = request["GoodsID"] ?? "";
                            if (GoodsID.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空");
                            }
                            //在购物侧中删除此商品    删除并没有成功
                            // MzqShoppingcarDAL.Delete(0, GoodsID);
                            //在购物侧中删除此商品    删除成功
                            MzqShoppingcarQueryParameter parm = new MzqShoppingcarQueryParameter();
                            parm.EqualTo.MzqGoodsId = GoodsID;
                            MzqShoppingcarDAL.Delete(0, parm);

                            //查找购物车数据库，如果该商品不存在，则返回删除成功   
                            var cartEntity = MzqShoppingcarDAL.Select(0, GoodsID);                            

                            if (cartEntity.IsNullOrEmptys())
                            {
                                output = JsonSerializer.Serialize(new { result_state = true,msg = "商品删除成功"});
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "商品删除失败"});
                            }
                               
                            #endregion

                        }
                        break;
                        //商品搜索
                    case "SeleteGoods":
                        {
                            #region 商品搜索
                            //获取前台传来的搜索词
                            string SeleteInfo = request["SeleteInfo"] ?? "";
                            if (SeleteInfo.IsNullOrEmptys())
                            {
                                throw new Exception("参数不能为空！");
                            }
                            //根据获取的值在商城商品表里进行模糊查询
                            MzqGoodsQueryParameter parm = new MzqGoodsQueryParameter();
                            parm.Like.MzqGoodsName = SeleteInfo;
                            var goodsEntity = MzqGoodsDAL.Select(0, parm);
                            List<GoodsEntity> list = new List<GoodsEntity>();                         
                            foreach (var item in goodsEntity)
                            {
                                var entity = new GoodsEntity();
                                entity.GoodsID = item.MzqGoodsId;
                                entity.GoodsName = item.MzqGoodsName;
                                entity.GoodsPrice = Convert.ToDecimal(item.MzqGoodsPrice);
                                entity.GoodsPic = item.MzqGoodsPic;
                                list.Add(entity);
                            }
                            //！！！！！！！！！！！！！！！！！！！！缺少分页！！！！！！！！！
                            output = JsonSerializer.Serialize(new {result_state = true,msg = "已查询", list });
                            #endregion
                        }
                        break;
                    //商品详细
                    case "GoodsDetails":
                        { 
                        #region 根据ID查询返回商品详细信息
                        string GoodsID = request["GoodsID"] ?? "";
                        if (GoodsID.IsNullOrEmptys())
                        {
                            throw new Exception("参数不能为空！");
                        }
                        MzqGoodsQueryParameter parm = new MzqGoodsQueryParameter();
                        parm.EqualTo.MzqGoodsId = GoodsID;
                        var goodsEntity = MzqGoodsDAL.Select(0, parm).FirstOrDefault();
                            if (goodsEntity.IsNullOrEmptys())
                            {
                                throw new Exception("未找到此商品！");
                            }
                            List<GoodsEntity> list = new List<GoodsEntity>();
                            var entity = new GoodsEntity();
                            entity.GoodsID = goodsEntity.MzqGoodsId;
                            entity.GoodsName = goodsEntity.MzqGoodsName;
                            entity.GoodsPrice = Convert.ToDecimal(goodsEntity.MzqGoodsPrice);
                            entity.Seller = goodsEntity.MzqGoodsSeller;
                            entity.GoodsPic = goodsEntity.MzqGoodsPic;
                            list.Add(entity);
                        output = JsonSerializer.Serialize(new { result_state = true, msg = "已查询", list });
                            #endregion
                        }
                        break;
                     //全球购
                    case "GetGlobalGoods":
                        {
                            #region 全球购商品展示
                            string NameInfo = "全球购";
                            //根据获取的值在商城商品表里进行模糊查询
                            MzqGoodsQueryParameter parm = new MzqGoodsQueryParameter();
                            parm.Like.MzqGoodsName = NameInfo;
                            var goodsEntity = MzqGoodsDAL.Select(0, parm);
                            if (goodsEntity.IsNullOrEmptys())
                            {
                                throw new Exception("商城商品为空！");
                            }
                            List<GoodsEntity> list = new List<GoodsEntity>();
                            foreach (var item in goodsEntity)
                            {
                                var entity = new GoodsEntity();
                                entity.GoodsID = item.MzqGoodsId;
                                entity.GoodsName = item.MzqGoodsName;
                                entity.GoodsPrice = Convert.ToDecimal(item.MzqGoodsPrice);
                                entity.GoodsPic = item.MzqGoodsPic;
                                list.Add(entity);
                            }
                            //！！！！！！！！！！！！！！！！！！！！缺少分页！！！！！！！！！
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "已查询", list });
                            #endregion
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

    public class GoodsEntity
    {
        #region 商品实体
        public string GoodsID { get; set; }//商品ID
        public string Seller { get; set; }//卖家
        public string GoodsName { get; set; }//商品名
        public Decimal GoodsPrice { get; set; }//商品价格
        public string GoodsPic { get; set; }//商品图片
        #endregion
    }
    public class CarEntity
    {
        #region 购物车实体
        public string ShoppingCarID { get; set; }//购物车ID
        public string GoodsID { get; set; }//商品ID
        public string GoodsName { get; set; }//商品名
        public Decimal GoodsPrice { get; set; }//商品价格
        public string GoodsPic { get; set; }//商品图片
        public int GoodsNumber { get; set; }//商品数量
        public string CheckState { get; set; }//商品选择状态
        #endregion
    }
}