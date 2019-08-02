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
    public class LanAddressHandler : BaseHanlder
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
                            string userName = request["userName"] ?? "";
                            //获取收货人电话
                            string userPhone = request["userPhone"] ?? "";
                            //获取收货地址
                            string newaddress = request["newaddress"] ?? "";
                            if (userId == "undefined" || userId.IsNullOrEmptys() || userPhone == "undefined" || userPhone.IsNullOrEmptys() || newaddress == "undefined" || newaddress.IsNullOrEmptys())
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //创建存储空间，存放一条收货地址
                                var entity = new LanAddressDALEntity();
                                //绑定用户的ID
                                entity.SysUserId = userId;
                                //存放收货人电话
                                entity.LanAddressPhone = userPhone;
                                //存储收货地址
                                entity.LanAddressName = newaddress;
                                //存储收货人的姓名
                                entity.LanAddressUsername = userName;
                                //添加一条新的记录
                                LanAddressDAL.Merge(0, entity);                                
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
                                LanAddressQueryParameter address = new LanAddressQueryParameter();
                                address.EqualTo.SysUserId = userId;
                                var allAddress = LanAddressDAL.Select(0, address);
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
                    case "updateAddress":
                        {
                            //获取用户Id
                            string userId = request["userId"] ?? "";
                            //获取地址Id                        
                            string addressId = request["addressId"] ?? "";
                            //获取收货人姓名
                            string userName = request["userName"] ?? "";
                            //获取收货人电话
                            string userPhone = request["userPhone"] ?? "";
                            //获取收货地址
                            string newaddress = request["newaddress"] ?? "";
                            if (userId == "undefined" || userId.IsNullOrEmptys() || userPhone == "undefined" || userPhone.IsNullOrEmptys() || newaddress == "undefined" || newaddress.IsNullOrEmptys() || addressId.IsNullOrEmptys() || addressId=="undefined")
                            {
                                throw new Exception("内容不能为空");
                            }
                            else
                            {
                                //查询数据库中的记录
                                LanAddressQueryParameter address = new LanAddressQueryParameter();
                                address.EqualTo.SysUserId = userId;
                                address.EqualTo.LanAddressId = addressId;
                                var updateAddress = LanAddressDAL.Select(0, address).FirstOrDefault();


                                //收货人电话
                                updateAddress.LanAddressPhone = userPhone;
                                //收货人的姓名
                                updateAddress.LanAddressName = userName;
                                //收货地址
                                updateAddress.LanAddressUsername = newaddress;
                                //更新一条新的记录
                                LanAddressDAL.Update(0, updateAddress);
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
                                LanAddressQueryParameter address = new LanAddressQueryParameter();
                                address.EqualTo.LanAddressId = addressId;
                                var deleteAddress = LanAddressDAL.Select(0, address).FirstOrDefault();
                                if (deleteAddress.IsNullOrEmptys())
                                {
                                    throw new Exception("该地址不存在");
                                }
                                else
                                {
                                    //删除一条记录
                                    LanAddressDAL.Delete(0, addressId);
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