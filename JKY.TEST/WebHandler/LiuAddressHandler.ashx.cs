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
    public class LiuAddressHandler : BaseHanlder
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
                    case "newAddress":
                        {  
                            //获取用户Id
                            string userId = request["userId"] ?? "";
                            //获取收货人姓名
                            string receiver = request["receiver"] ?? "";
                            //获取收货人电话
                            string telephone = request["telephone"] ?? "";
                            //获取收货地址
                            string address = request["address"] ?? "";
                            //标签
                            string label = request["label"] ?? "";
                            // 省份
                            string province = request["province"] ?? "";
                            if (userId.IsNullOrEmptys() || receiver.IsNullOrEmptys() || address.IsNullOrEmptys() || telephone.IsNullOrEmptys() || label.IsNullOrEmptys() || province.IsNullOrEmptys())
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //创建存储空间，存放一条收货地址
                                var entity = new LiuAddressDALEntity();
                                //绑定用户的ID
                                entity.UserId = userId;
                                //存放收货人电话
                                entity.Telephone = telephone;
                                //存储收货地址
                                entity.Address = address;
                                //存储收货人的姓名
                                entity.Receiver = receiver;
                                //存储省份
                                entity.Province = province;
                                //存储标签
                                entity.Laber = label;
                                //添加一条新的记录
                                LiuAddressDAL.Merge(0, entity);                                
                                string sql = SystemConfig.SQL;
                                output=JsonSerializer.Serialize(new { result_state = true, msg = "收货地址添加成功！！！",userId=userId});
                            }
                        }
                        break;
                    case "getAddress":
                        {
                            //获取用户Id
                            string userId = request["userId"] ?? "";
                            //用户ID为空时
                            if (userId == "undefined" || userId.IsNullOrEmptys())
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //查询数据库中的记录
                                LiuAddressQueryParameter address = new LiuAddressQueryParameter();
                                address.EqualTo.UserId = userId;
                                var allAddress = LiuAddressDAL.Select(0, address);
                                if (allAddress.IsNullOrEmptys())
                                {
                                    throw new Exception("您还没有创建地址");
                                }
                                else
                                {
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "获取成功", allAddress = allAddress });
                                }
                            }
                        }
                        break;
                    case "getAddress1":
                        {
                            //获取地址Id
                            string addressId = request["addressId"] ?? "";
                            //地址Id为空时
                            if (addressId.IsNullOrEmptys())
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //查询数据库中的记录
                                LiuAddressQueryParameter address = new LiuAddressQueryParameter();
                                address.EqualTo.LiuAddressId = addressId;
                                var theAddress = LiuAddressDAL.Select(0, address);
                                if(theAddress.IsNullOrEmptys())
                                {
                                    throw new Exception("你还没有创建地址");
                                }
                                else
                                {
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "获取成功", theAddress = theAddress });
                                }
                            }
                        }
                        break;
                    case "updateAddress":
                        {
                            //获取用户Id
                            string userId = request["userId"] ?? "";
                            //获取地址Id                        
                            string addressId = request["addressId"] ?? "";
                            //获取收货人姓名
                            string receiver = request["receiver"] ?? "";
                            //获取收货人电话
                            string telephone = request["telephone"] ?? "";
                            //获取收货地址
                            string address = request["address"] ?? "";
                            //获取地址标签
                            string label = request["label"] ?? "";
                            //获取省份
                            string province = request["province"] ?? "";

                            if (userId.IsNullOrEmptys() || telephone.IsNullOrEmptys() || address.IsNullOrEmptys() || addressId.IsNullOrEmptys() || label.IsNullOrEmptys() || province.IsNullOrEmptys() )
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //查询数据库中的记录
                                LiuAddressQueryParameter address1 = new LiuAddressQueryParameter();
                                address1.EqualTo.UserId = userId;
                                address1.EqualTo.LiuAddressId = addressId;
                                var updateAddress = LiuAddressDAL.Select(0, address1).FirstOrDefault();


                                //收货人电话
                                updateAddress.Telephone = telephone;
                                //收货人的姓名
                                updateAddress.Receiver = receiver;
                                //收货地址
                                updateAddress.Address = address;
                                updateAddress.Province = province;
                                updateAddress.Laber = label;
                                //更新一条新的记录
                                LiuAddressDAL.Update(0, updateAddress);
                                string sql = SystemConfig.SQL;
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "收货地址修改成功！！！" });
                            }
                        }
                        break;
                    case "updateAddress1":
                        {
                            //获取用户Id
                            string userId = request["userId"] ?? "";

                            //获取收货人姓名
                            string userName = request["userName"] ?? "";
                            //获取收货人电话
                            string userPhone = request["userPhone"] ?? "";
                            //获取收货地址
                            string newaddress = request["newaddress"] ?? "";
                            
                                //查询数据库中的记录
                                LanAddressQueryParameter address = new LanAddressQueryParameter();
                                address.EqualTo.LanAddressId = userId;

                                var updateAddress = LanAddressDAL.Select(0, address).FirstOrDefault();


                                //收货人电话
                                updateAddress.LanAddressPhone = userPhone;
                                //收货人的姓名
                                updateAddress.LanAddressName = newaddress;
                                //收货地址
                                updateAddress.LanAddressUsername =  userName;
                                //更新一条新的记录
                                LanAddressDAL.Update(0, updateAddress);
                                string sql = SystemConfig.SQL;
                                output = JsonSerializer.Serialize(new { result_state = true, msg = "收货地址修改成功！！！" });
                  
                        }
                        break;
                    case "deleteAddress":
                        {
                            string addressId = request["addressId"] ?? "";
                            if (addressId == "undefined" || addressId.IsNullOrEmptys())
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //查询数据库中的记录
                                LiuAddressQueryParameter address = new LiuAddressQueryParameter();
                                address.EqualTo.LiuAddressId = addressId;
                                var deleteAddress = LiuAddressDAL.Select(0, address).FirstOrDefault();
                                if (deleteAddress.IsNullOrEmptys())
                                {
                                    throw new Exception("该地址不存在");
                                }
                                else
                                {
                                    //删除一条记录
                                    LiuAddressDAL.Delete(0, addressId);
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "地址删除成功！！！" });
                                }
                            }
                        }
                        break;
                    case "deleteAddress1":
                        {
                            string userId = request["userId"] ?? "";
                     
                                //查询数据库中的记录
                                LanAddressQueryParameter address = new LanAddressQueryParameter();
                                address.EqualTo.LanAddressId = userId;
                                var deleteAddress = LanAddressDAL.Select(0, address).FirstOrDefault();
                               
                                    //删除一条记录
                                    LanAddressDAL.Delete(0, userId);
                                    output = JsonSerializer.Serialize(new { result_state = true, msg = "地址删除成功！！！" });
                            
                        
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