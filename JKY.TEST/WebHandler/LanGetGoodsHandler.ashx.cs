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
    public class LanGetGoodsHandler : BaseHanlder
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
                    case "Goods":
                        {
                            //获取父级菜单
                            string parentMenu = request["parentMenu"] ?? "";
                            //获取子级菜单
                            string subMenu = request["subMenu"] ?? "";
                            if (subMenu == "undefined" || parentMenu=="undefined" ||subMenu.IsNullOrEmptys() || parentMenu.IsNullOrEmptys())
                            {
                                throw new Exception("菜单不能为空");
                            }
                            else
                            {
                                //如果查询全部商品
                                if (subMenu=="null")
                                {
                                    LanGoodsQueryParameter good = new LanGoodsQueryParameter();
                                    good.EqualTo.LanMenuParentName = parentMenu;
                                    var Goods=LanGoodsDAL.Select(0, good);
                                    if(Goods.Length<=0)
                                    {
                                        throw new Exception("该菜单下商品为空");
                                    }
                                    else
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = true, Goods = Goods});
                                    }
                                    
                                }
                                else
                                {
                                    LanGoodsQueryParameter good = new LanGoodsQueryParameter();
                                    good.EqualTo.LanMenuSubName = subMenu;
                                    good.EqualTo.LanMenuParentName = parentMenu;
                                    var Goods = LanGoodsDAL.Select(0, good);
                                    if (Goods.Length<=0)
                                    {
                                        throw new Exception("该菜单下商品为空");
                                    }
                                    else
                                    {
                                        output = JsonSerializer.Serialize(new { result_state = true, Goods = Goods});
                                    }
                                }
                            }
                        }
                        break;
                    case "all_goods":
                        {
                            LanGoodsQueryParameter good = new LanGoodsQueryParameter();

                            var Goods = LanGoodsDAL.Select(0, good);
                            if (Goods.Length <= 0)
                            {
                                throw new Exception("该菜单下商品为空");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, Goods = Goods });
                            }
                        }
                        break;
                    case "point_goods":
                        {
                            string subMenu = request["subMenu"] ?? "";
                            LanGoodsQueryParameter good = new LanGoodsQueryParameter();
                            good.EqualTo.LanMenuSubName = subMenu;
                            var Goods = LanGoodsDAL.Select(0, good);
                            if (Goods.Length <= 0)
                            {
                                throw new Exception("该菜单下商品为空");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, Goods = Goods });
                            }
                        }
                        break;
                    case "Good":
                        {
                            string goodId= request["GoodId"] ?? "";
                            if (goodId.IsNullOrEmptys())
                            {
                                throw new Exception("商品编号不能为空！！！");
                            }
                            else
                            {
                                LanGoodsQueryParameter good = new LanGoodsQueryParameter();
                                good.EqualTo.GoodsId = goodId;
                                var Good= LanGoodsDAL.Select(0, good);
                                if (Good.Length <= 0)
                                {
                                    throw new Exception("该商品不存在！！！");
                                }
                                else
                                {
                                    //获取父级菜单名称
                                    string ParentName = Good[0].LanMenuParentName;
                                    //获取该商品的子菜单名称
                                    string SubName = Good[0].LanMenuSubName;
                                    //获取该菜单下的推荐商品
                                    LanGoodsQueryParameter recommendOne = new LanGoodsQueryParameter();
                                    recommendOne.EqualTo.LanMenuSubName = SubName;
                                    recommendOne.NotEqual.GoodsId = goodId;
                                    //获取全部商品
                                    var recGoodOne = LanGoodsDAL.Select(0, recommendOne);
                                    if (recGoodOne.IsNullOrEmptys()) {
                                        //获取该菜单下的推荐商品
                                        LanGoodsQueryParameter recommendTwo = new LanGoodsQueryParameter();
                                        recommendTwo.EqualTo.LanMenuParentName = ParentName;
                                        recommendTwo.NotEqual.GoodsId = goodId;
                                        //获取6条推荐商品
                                        var recGoodTwo = LanGoodsDAL.Select(5, recommendTwo);
                                        output = JsonSerializer.Serialize(new { result_state = true, Good = Good, RecommendGoods = recGoodTwo });
                                    }
                                    else {
                                        output = JsonSerializer.Serialize(new { result_state = true, Good = Good, RecommendGoods = recGoodOne});
                                    }
                                }
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