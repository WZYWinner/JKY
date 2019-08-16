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


namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class LiuGetGoodsHandler : BaseHanlder
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
                     // 获取商家分类
                    case "MerchantClassify":
                        {
                            //查询MerchantClassify数据库中的数据
                            MerchantClassifyQueryParameter merchantClassify = new MerchantClassifyQueryParameter();
                            //获取数据库中的数据
                            var merchantSort = MerchantClassifyDAL.Select(0, merchantClassify);
                            if (merchantSort.IsNullOrEmptys())
                            {
                                throw new Exception("商家分类不能为空");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, merchantSort = merchantSort });
                            }
                        }
                        break;
                        //商家列表
                    case "MerchantList":
                        {   
                            // 获取商家分类id
                            var merchantSortId = request["merchantSortId"] ?? "";
                            // 查询MerchantList数据库中的数据
                            MerchantListQueryParameter merchantList = new MerchantListQueryParameter();
                            merchantList.EqualTo.MerchantSortId = merchantSortId;
                            // 声明变量接收数据库中的数据
                            var merchantlist = MerchantListDAL.Select(0, merchantList);
                            if (merchantlist.Length <= 0)
                            {
                                throw new Exception("该商家列表为空");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, merchantlist = merchantlist });
                            }
                        }
                        break;
                        //商品分类
                    case "GoodsClassify":
                        {
                            // 获取商家ID
                            var merchantId = request["merchantId"] ?? "";
                            // 查询GoodsClassify数据库中的数据
                            GoodsClassifyQueryParameter goodsClassify = new GoodsClassifyQueryParameter();
                            // 查询数据库MerchantList数据库中的数据
                            MerchantListQueryParameter merchantList = new MerchantListQueryParameter();
                            merchantList.EqualTo.MerchantListId = merchantId;
                            goodsClassify.EqualTo.MerchantListId = merchantId;
                            var goodsclassify = GoodsClassifyDAL.Select(0, goodsClassify);
                            var merchantlist = MerchantListDAL.Select(0, merchantList);
                            if(goodsclassify.Length <= 0 && merchantlist.Length <= 0)
                            {
                                throw new Exception("该商品分类为空");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, goodsclassify = goodsclassify, merchantlist = merchantlist });
                            }
                        }
                        break;
                    case "GoodsList":
                        {
                            //获取商品分类Id
                            var goodsSortId= request["goodsSortId"] ?? "";
                            //查询GoodsList数据表中的数据
                            GoodsListQueryParameter goodsList = new GoodsListQueryParameter();
                            goodsList.EqualTo.GoodsSortId = goodsSortId;
                            var goodslist = GoodsListDAL.Select(0, goodsList);
                            if (goodslist.Length <= 0)
                            {
                                throw new Exception("该类商品为空！！！");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, goodslist = goodslist });
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