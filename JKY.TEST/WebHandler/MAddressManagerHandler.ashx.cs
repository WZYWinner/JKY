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
    public class MAddressManagerHandler : BaseHanlder
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
                    //添加收货地址
                    case "AddAddress":
                        {
                            #region 添加收货地址
                            #region 参数获取
                            //获取用户名
                            string UserID = request["UserID"] ?? "";
                            //地址状态
                            string State = request["State"] ?? "";
                            //收货人姓名
                            string ConsigneeInfo = request["ConsigneeInfo"] ?? "";
                            //收货人电话 
                            string Telephone = request["Telephone"] ?? "";
                            // 收货人区域
                            string ConsigneeRegion = request["ConsigneeRegion"] ?? "";
                            //收货人详细地址
                            string ReceivingAddress = request["ReceivingAddress"] ?? "";
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("参1数不能为空");
                            }
                            if (State.IsNullOrEmptys())
                            {
                                throw new Exception("参2数不能为空");
                            }
                            if (ConsigneeInfo.IsNullOrEmptys())
                            {
                                throw new Exception("参3数不能为空");
                            }
                            if (Telephone.IsNullOrEmptys())
                            {
                                throw new Exception("参4数不能为空");
                            }
                            if (ConsigneeRegion.IsNullOrEmptys())
                            {
                                throw new Exception("参5数不能为空");
                            }
                            if (ReceivingAddress.IsNullOrEmptys())
                            {
                                throw new Exception("参6数不能为空");
                            }
                            //如果订单选择状态为空，则给其赋值为false
                            if (State == "undefined")
                            {
                                State = "false";
                            }
                            #endregion
                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            var entity = MzqAddressDAL.Select(0, parm);
                            var entity1 = new MzqAddressDALEntity();
                            entity1.UserId = UserID;
                            entity1.State = State;
                            entity1.ConsigneeInfo = ConsigneeInfo;
                            entity1.Telephone = Telephone;
                            entity1.ConsigneeRegion = ConsigneeRegion;
                            entity1.ReceivingAddress  = ReceivingAddress;
                            //将用户地址添加到数据库中
                            MzqAddressDAL.Merge(0, entity1);
                            output = JsonSerializer.Serialize(new { result_state = true,msg = "地址添加成功！"});
                            #endregion
                        }
                        break;
                    //修改收货地址  
                    case "ModifyAddress":
                        {                           
                            #region 修改收货地址
                            #region 参数获取
                            //获取用户名
                            string UserID = request["UserID"] ?? "";
                            //用户地址ID
                            string AddressID = request["AddressID"] ?? "";
                            //地址状态
                            string State = request["State"] ?? "";
                            //收货人姓名
                            string ConsigneeInfo = request["ConsigneeInfo"] ?? "";
                            //收货人电话 
                            string Telephone = request["Telephone"] ?? "";
                            // 收货人区域
                            string ConsigneeRegion = request["ConsigneeRegion"] ?? "";
                            //收货人详细地址
                            string ReceivingAddress = request["ReceivingAddress"] ?? "";
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("参1数不能为空");
                            }
                            if (State.IsNullOrEmptys())
                            {
                                throw new Exception("参2数不能为空");
                            }
                            if (AddressID.IsNullOrEmptys())
                            {
                                throw new Exception("参3数不能为空");
                            }
                            if (ConsigneeInfo.IsNullOrEmptys())
                            {
                                throw new Exception("参4数不能为空");
                            }
                            if (Telephone.IsNullOrEmptys())
                            {
                                throw new Exception("参5数不能为空");
                            }
                            if (ConsigneeRegion.IsNullOrEmptys())
                            {
                                throw new Exception("参6数不能为空");
                            }
                            if (ReceivingAddress.IsNullOrEmptys())
                            {
                                throw new Exception("参7数不能为空");
                            }
                            #endregion
                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            //用户ID
                            parm.EqualTo.UserId = UserID;
                            //收货地址ID
                            parm.EqualTo.AddressId = AddressID;

                            var entity = MzqAddressDAL.Select(0, parm);

                            var entity1 = new MzqAddressDALEntity();
                            entity1.State = State;
                            entity1.ConsigneeInfo = ConsigneeInfo;
                            entity1.Telephone = Telephone;
                            entity1.ConsigneeRegion = ConsigneeRegion;
                            entity1.ReceivingAddress = ReceivingAddress;
                            //将用户地址添加到数据库中
                            MzqAddressDAL.Merge(0, entity1);
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "地址修改成功！" });
                            #endregion
                        }
                        break;
                    //删除收货地址
                    case "DeleteAddress":
                        {
                            #region 删除收货地址
                            //用户ID
                            string UserID = request["UserID"] ?? "";
                            //收货地址ID
                            string AddressID = request["AddressID"] ?? "";
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID参数为空！");
                            }
                            if (AddressID.IsNullOrEmptys())
                            {
                                throw new Exception("用户地址ID参数为空！");
                            }

                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            //用户ID
                            parm.EqualTo.UserId = UserID;
                            //收货地址ID
                            parm.EqualTo.AddressId = AddressID;
                            //删除此用户下此条地址
                            MzqAddressDAL.Delete(0, parm);
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "地址删除成功！" });
                            #endregion
                        }
                        break;
                    //获取收货地址
                    case "GetAddress":
                        {
                            #region 获取收货地址
                            //用户ID
                            string UserID = request["UserID"] ?? "";
                            if (UserID.IsNullOrEmptys())
                            {
                                throw new Exception("用户ID参数为空！");
                            }
                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            //查找此用户下所有的收货地址
                            parm.EqualTo.UserId = UserID;
                            var entity = MzqAddressDAL.Select(0, parm);
                            List<AddressEntity> list = new List<AddressEntity>();
                            foreach (var item in entity)
                            {
                                var entity1 = new AddressEntity();
                                entity1.AddressID = item.AddressId;
                                entity1.UserID = item.UserId;
                                entity1.RegionInfo = item.RegionInfo;
                                entity1.ReceivingAddress = item.ReceivingAddress;
                                if (item.State == "true")
                                {
                                    item.State = "默认";
                                }
                                else {
                                    item.State = "普通";
                                }
                                entity1.State = item.State;
                                entity1.Telephone = item.Telephone;
                                entity1.ConsigneeRegion = item.ConsigneeRegion;
                                entity1.ConsigneeInfo = item.ConsigneeInfo;
                                list.Add(entity1);
                            }
                            output = JsonSerializer.Serialize(new { result_state = true,msg = "用户地址获取成功！" ,list });
                            #endregion
                        }
                        break;
                    case "GetOneAddress":
                        {
                            #region 获取选中的地址信息
                            //用户地址ID
                            string AddressID = request["AddressID"] ?? "";
                            if (AddressID.IsNullOrEmptys())
                            {
                                throw new Exception("用户地址ID参数不能为空");
                            }
                            //获取该地址信息
                            MzqAddressQueryParameter parm = new MzqAddressQueryParameter();
                            parm.EqualTo.AddressId = AddressID;
                            var entity = MzqAddressDAL.Select(0, parm).FirstOrDefault();
                            output = JsonSerializer.Serialize(new { result_state = true, msg = "用户地址获取成功！",entity});
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

        public class AddressEntity
        {
            #region 收货地址实体
            public string AddressID { get; set; }//收货地址ID
            public string UserID { get; set; }//用户ID
            public string ConsigneeInfo { get; set; }//收货人
            public string ConsigneeRegion { get; set; }//收货区域
            public string RegionInfo { get; set; }//地区
            public string ReceivingAddress { get; set; }//详细地址
            public string Telephone { get; set; }//手机号码
            public string State { get; set; }//地址状态
            #endregion

        }
    }
}