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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class GuoUserHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            //base.ExecuteRequest(context);
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空???????");
                }
                switch (type)
                {
                    ////获取子菜单
                    case "Registered":
                        {                           
                           //密码                        
                           string userPwd= request["password"] ?? "";
                            //手机号码
                            string userPhone = request["phone"] ?? "";
                            if (userPhone.IsNullOrEmptys() || userPhone == "undefined" || userPwd.IsNullOrEmptys() || userPwd == "undefined")
                           {
                               throw new Exception("手机号或密码不能为空");
                           }
                           else
                           {
                                //查询用户名判断用户是否已注册     //查询用户，判断用户是否存在
                                GuoUserQueryParameter GuoUser = new GuoUserQueryParameter();
                                GuoUser.EqualTo.Telephone = userPhone;
                                //存放查询到的用户信息
                                var user = GuoUserDAL.Select(0, GuoUser).FirstOrDefault();
                                //不存在用户
                                if (user.IsNullOrEmptys())
                                {
                                    //生成用户编号
                                    var userid = YaohuaID.NewID();
                                    //创建一个新的存储用户信息
                                    var entity = new GuoUserDALEntity();
                                    //用户ID
                                    entity.GuoUserId = userid;
                                    //密码
                                    entity.Password = userPwd;
                                    //手机号码
                                    entity.Telephone = userPhone;
                               


                                    GuoUserDAL.Merge(0, entity);
                                    output = JsonSerializer.Serialize(new { result_state = true, yourID = userid, yourTel= userPhone,msg = "注册成功"});
                                }
                                else
                                {
                                    //判断密码是否一致
                                    if (user.Password != userPwd)
                                    {
                                        throw new Exception("用户名或密码错误");
                                    }
                                    else
                                    {
                                        var mYID = user.GuoUserId;
                                        var mTEL = user.Telephone;
                                        output = JsonSerializer.Serialize(new { result_state = true,yourID=mYID,yourTel= mTEL, msg = "登录成功" });
                                    }
                                }
                            }
                        }
                        break;

                    ////创建收货地址
                    case "newAddress":
                        {
                            //获取用户Id
                            string userId = request["userId"] ?? "";
                            //获取收货人省份
                            string userProvince = request["userProvince"] ?? "";
                            //获取收货地址
                            string newAddress = request["newAddress"] ?? "";
                            //获取收货人门牌号
                            string userHouseNumber = request["userHouseNumber"] ?? "";
                            //获取收货人姓名
                            string userName = request["userName"] ?? "";
                            //获取收货人电话
                            string userPhone = request["userPhone"] ?? "";
                            //获取地址ID方便查询，可以不获取，忽略新建
                            string guoaddressid = request["guoaddressid"] ?? "";
                            //获取收货标签头
                            string labertittle = request["labertittle"]??"";
                            if (labertittle == "0")
                            {
                                labertittle = "家";
                            }else if (labertittle=="1")
                            {
                                labertittle = "公司";
                            }
                            else
                            {
                                labertittle = "学校";
                            }
                            GuoAddressQueryParameter GuoAddress = new GuoAddressQueryParameter();
                            GuoAddress.EqualTo.GuoAddressId = guoaddressid;
                            var dAddress = GuoAddressDAL.Select(0, GuoAddress);
                            var fAddress = GuoAddressDAL.Select(0, GuoAddress).FirstOrDefault();
                            if (fAddress.IsNullOrEmptys())
                            {
                                if (labertittle == "undefined" || labertittle.IsNullOrEmptys() || userId == "undefined" || userId.IsNullOrEmptys() || userName == "undefined" || userName.IsNullOrEmptys() || userProvince == "undefined" || userProvince.IsNullOrEmptys() || userHouseNumber == "undefined" || userHouseNumber.IsNullOrEmptys() || userPhone == "undefined" || userPhone.IsNullOrEmptys() || newAddress == "undefined" || newAddress.IsNullOrEmptys())
                                {
                                    throw new Exception("内容不能为空");
                                }
                                else
                                {
                                    var useraddressid = YaohuaID.NewID();
                                    //创建存储空间，存放一条收货地址
                                    var entity = new GuoAddressDALEntity();
                                    //绑定用户的ID
                                    entity.Laber = userId;
                                    //存放收货人省份
                                    entity.Province = userProvince;
                                    //存放收货地址
                                    entity.Address = newAddress;
                                    //存放收货门牌号
                                    entity.HouseNumber = userHouseNumber;
                                    //存放收货人名字
                                    entity.Receiver = userName;
                                    //存储收货人电话
                                    entity.Telephone = userPhone;
                                    //新建收货地址ID
                                    entity.GuoAddressId = useraddressid;
                                    //新建标签头
                                    entity.LaberTittle = labertittle;
                                    //添加一条新的记录
                                    GuoAddressDAL.Merge(0, entity);
                                    string sql = SystemConfig.SQL;
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "收货地址添加成功", addressid = useraddressid });
                                }
                            }
                            else
                            {
                                var entity = new GuoAddressDALEntity();
                                //绑定用户的ID
                                entity.Laber = userId;
                                //存放收货人省份
                                entity.Province = userProvince;
                                //存放收货地址
                                entity.Address = newAddress;
                                //存放收货门牌号
                                entity.HouseNumber = userHouseNumber;
                                //存放收货人名字
                                entity.Receiver = userName;
                                //存储收货人电话
                                entity.Telephone = userPhone;
                                //新建收货地址ID
                                entity.GuoAddressId = guoaddressid;
                                //新建标签头
                                entity.LaberTittle = labertittle;
                                //添加一条新的记录
                                GuoAddressDAL.Merge(0, entity);
                                string sql = SystemConfig.SQL;
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "收货地址修改成功" });
                                //output = JsonSerializer.Serialize(new { result_state = true, msg = "地址成功", address = dAddress });
                            }

                          
                        }
                        break;
                    case "findUserAddress":
                        {
                            string userId = request["userId"] ?? "";
                            //查询数据库中的记录
                            GuoAddressQueryParameter GuoAddress = new GuoAddressQueryParameter();
                            GuoAddress.EqualTo.Laber = userId;
                            var dAddress = GuoAddressDAL.Select(0, GuoAddress);
                            var fAddress = GuoAddressDAL.Select(0, GuoAddress).FirstOrDefault();
                            if (fAddress.IsNullOrEmptys())
                            {
                                throw new Exception("该地址不存在");
                            }
                            else
                            {
                                 output = JsonSerializer.Serialize(new { result_state = true, msg = "地址成功", address=dAddress });
                            }
                           
                        }
                        

                        break;
                    case "findAddress":
                        {
                            string useraddressid = request["useraddressid"] ?? "";
                            //查询数据库中的记录
                            GuoAddressQueryParameter GuoAddress = new GuoAddressQueryParameter();
                            GuoAddress.EqualTo.GuoAddressId = useraddressid;
                            var dAddress = GuoAddressDAL.Select(0, GuoAddress);
                            var fAddress = GuoAddressDAL.Select(0, GuoAddress).FirstOrDefault();
                            if (fAddress.IsNullOrEmptys())
                            {
                                throw new Exception("该地址不存在");
                            }
                            else
                            {
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "地址成功", address = dAddress });
                            }

                        }


                        break;
                    case "deleteAddress":
                        {
                            string guoaddressid = request["guoaddressid"] ?? "";

                            //查询数据库中的记录
                            GuoAddressQueryParameter address = new GuoAddressQueryParameter();
                            address.EqualTo.GuoAddressId = guoaddressid;
                            var deleteAddress = GuoAddressDAL.Select(0, address).FirstOrDefault();

                            //删除一条记录
                            GuoAddressDAL.Delete(0, guoaddressid);
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "地址删除成功" });


                        }
                        break;
                    case "merchant_sort":
                        {
                            MerchantSortQueryParameter sortname = new MerchantSortQueryParameter();

                            var merchantsort = MerchantSortDAL.Select(0, sortname);
                     
                            output = JsonSerializer.Serialize(new { result_state = true, allmerchantsort = merchantsort,msg= "OJBK" });
    
                        }
                        break;
                    case "findMerchant":
                        {
                            string merchantLaber = request["merchantLaber"] ?? "";
                            //查询数据库中的记录
                            GuoMerchantQueryParameter GuoMerchant = new GuoMerchantQueryParameter();
                            GuoMerchant.EqualTo.Laber = merchantLaber;
                            var dAddress = GuoMerchantDAL.Select(0, GuoMerchant);
                            var fAddress = GuoMerchantDAL.Select(0, GuoMerchant).FirstOrDefault();


                          
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "查找商家分类下的商家成功", address = dAddress });
                            

                        }


                        break;
                    case "findMerchant2":
                        {
                            string merchantid = request["merchantId"] ?? "";
                            //查询数据库中的记录
                            GuoMerchantQueryParameter GuoMerchant = new GuoMerchantQueryParameter();
                            GuoMerchant.EqualTo.MerchantId = merchantid;
                            var fAddress = GuoMerchantDAL.Select(0, GuoMerchant).FirstOrDefault();



                            output = JsonSerializer.Serialize(new { result_state = true, msg = "查找这个商家成功", address = fAddress });


                        }


                        break;
                    case "findGoodsSort":
                        {
                            string merchantid = request["merchantId"] ?? "";
                            //查询数据库中的记录
                            GoodsSortQueryParameter GuoGoodsSort = new GoodsSortQueryParameter();
                            GuoGoodsSort.EqualTo.Laber = merchantid;
                            var dAddress = GoodsSortDAL.Select(0, GuoGoodsSort);

                            output = JsonSerializer.Serialize(new { result_state = true, msg = "查找这个商家的商品分类成功", address = dAddress });


                        }


                        break;
                    case "findGoods":
                        {
                            string goodlaber = request["goodlaber"] ?? "";
                            //查询数据库中的记录
                            GuoGoodsQueryParameter GuoGood = new GuoGoodsQueryParameter();
                            GuoGood.EqualTo.Laber = goodlaber;
                            var dAddress = GuoGoodsDAL.Select(0, GuoGood);

                            output = JsonSerializer.Serialize(new { result_state = true, msg = "查找这个商品分类下的商品成功", address = dAddress });


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