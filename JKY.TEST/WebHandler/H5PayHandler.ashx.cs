using System;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Web;
using Yaohuasoft.Framework.Library;
using Yaohuasoft.Framework.BLL;
using System.Runtime.Serialization;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// H5PayHandler 的摘要说明
    /// </summary>
    public class H5PayHandler : BaseHanlder
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
                #region

                /* var str_user = request["user"] ?? "";
                 SysUserDALEntity user = new SysUserDALEntity();
                 SysUserDALEntity tempUser = new SysUserDALEntity();
                 //验证账号
                 if (!str_user.IsNullOrEmptys())
                 {
                     user = JsonSerializer.Deserialize<SysUserDALEntity>(str_user);
                     SysUserQueryParameter UserParam = new SysUserQueryParameter();
                     if (user.UserName.IsNullOrEmptys())
                     {
                         throw new CommonException("请登录！");
                     }
                     UserParam.EqualTo.UserName = user.UserName;
                     tempUser = SysUserDAL.Select(0, UserParam).FirstOrDefault();
                     if (tempUser == null)
                     {
                         throw new CommonException("不存在该用户,请重新登录！");
                     }
                     if (tempUser.UserState == "失效")
                     {
                         throw new CommonException("该帐号已失效！");
                     }
                     if (tempUser.UserState == "停用")
                     {
                         throw new CommonException("该帐号已停用！");
                     }
                 }
                 else
                 {
                     throw new CommonException("请登录！");
                 }*/
                #endregion
                switch (type)
                {
                    //H5Pay
                    #region
                    case "H5Pay":
                        {
                            #region 生成充值订单记录，签名参数生成支付form 调起支付
                            //var amount = request["amount"] ?? "";
                            //var AppLogId = request["AppLogId"] ?? "";

                            var orderNo = request["orderId"] ?? "";//订单ID



                            LanOrderListDALEntity entity = new LanOrderListDALEntity();

                            //查询订单
                            if (orderNo.IsNullOrEmptys() || orderNo == "undefined")
                            {
                                throw new Exception("订单号不存在");
                            }
                            else
                            {
                                LanOrderListQueryParameter param = new LanOrderListQueryParameter();
                                param.EqualTo.LanOrderType = "待付款";
                                param.EqualTo.LanOrderListId = orderNo;//订单ID

                                var Order = LanOrderListDAL.Select(0, param).FirstOrDefault();
                                if (Order.IsNullOrEmptys())
                                {
                                    throw new Exception("订单不存在");
                                }
                                else
                                {

                                    H5Pay data = new H5Pay();
                                    //string KeyPublic = PayConfig.KeyPublic;//公钥
                                    //string PrivateKey = PayConfig.PrivateKey;//私钥
                                    data.requestNo = (new DateTime()).ToString("yyyyMMdd") + orderNo;//流水号
                                    data.version = PayConfig.version;//版本号
                                    data.productId = "0126";//产品类型
                                    data.transId = "12";//交易类型
                                    data.merNo = PayConfig.merNo;//商户号
                                    data.orderDate = DateTime.Now.Date.ToString("yyyyMMdd");//订单日期
                                    data.orderNo = Order.LanOrderListId;//订单号
                                    data.returnUrl = PayConfig.returnUrl;//页面通知地址
                                    data.notifyUrl = PayConfig.notifyUrl;//异步通知地址
                                    data.transAmt = (Order.LanOrderListSumprice * 100).ToString().Replace(".00", null);//交易金额
                                    data.commodityName = "test";//商品名称
                                    
                                    //对数据签名
                                    data.signature = RSAHelper.requestPay(data).UrlEncode();
                                    var resdata = RSAHelper.requestPay1(data);
                                    //string body = "requestNo=" + data.requestNo + "&version=" + data.version + "&productId=" + data.productId + "&transId=" + data.transId +
                                    //    "&merNo=" + data.merNo + "&orderDate=" + data.orderDate + "&orderNo=" + data.orderNo + "&returnUrl=" + data.returnUrl +
                                    //    "&notifyUrl=" + data.notifyUrl + "&transAmt=" + data.transAmt + "&commodityName=" + data.commodityName + "&signature=" + data.signature;


                                    var url = "http://13.127.174.232/payment-gate-web/gateway/api/backTransReq?" + resdata +"";

                                    var result = CommonMethod.ApiGet(url, "");

                                    //var data1 = JsonSerializer.Deserialize<H5Pay>(result);

                                    ////构建form 返回提交
                                    //var form = "<form id='myform' action = 'http://13.127.174.232/payment-gate-web/gateway/api/backTransReq'accept-charset='utf-8' enctype='application/x-www-form-urlencoded' onsubmit='return false' method = 'POST'  name = 'myform'>" +
                                    //            " <input type = 'text' id='requestNo' class='form-control' name ='requestNo' value ='" + data.requestNo + "' ng-model='$parent.requestNo'>" +
                                    //            " <input type = 'text' id='version' class='form-control' name='version' value='" + data.version + "' ng-model='$parent.version'>" +
                                    //            " <input type = 'text' id='productId' class='form-control' name='productId' value='" + data.productId + "' ng-model='$parent.productId'>" +
                                    //            " <input type = 'text' id='transId' class='form-control' name='transId' value='" + data.transId + "' ng-model='$parent.transId'>" +
                                    //            " <input type = 'text' id='merNo' class='form-control' name='merNo' value='" + data.merNo + "' ng-model='$parent.merNo'>" +
                                    //            " <input type = 'text' id='orderDate' class='form-control' name='orderDate' value='" + data.orderDate + "' ng-model='$parent.orderDate'>" +
                                    //            " <input type = 'text' id='orderNo' class='form-control' name='orderNo'  value='" + data.orderNo + "' ng-model='$parent.orderNo'>" +
                                    //             " <input type = 'text' id='returnUrl' class='form-control' name='returnUrl' value='" + data.returnUrl + "' ng-model='$parent.returnUrl'>" +
                                    //            " <input type = 'text' id='notifyUrl' class='form-control' name='notifyUrl' value='" + data.notifyUrl + "' ng-model='$parent.notifyUrl'>" +
                                    //            " <input type = 'text' id='transAmt' class='form-control' name='transAmt' value='" + data.transAmt + "' ng-model='$parent.transAmt'>" +
                                    //            " <input type = 'text' id='commodityName' class='form-control' name='commodityName' value='" + data.commodityName + "' ng-model='$parent.commodityName'>" +
                                    //            " <input type = 'text' id='signature' class='form-control' name='signature' value='" + data.signature + "' ng-model='$parent.signature'>" +
                                    //            "<input id='submit' type = 'submit' class='btn btn-success' ng-click='login()'  value='提交'>" +
                                    //            "</form>";
                                    output = JsonSerializer.Serialize(new { result_state = true, result = result });
                                }
                            }
                            #endregion                            
                        }
                        break;
                    #endregion
                    //余额待付（银行转账）
                    #region
                    case "BalancePay":
                        {
                            var transAmt = request["transAmt"] ?? "";//转账金额（分）
                            var Compay = request["Compay"] ?? "";//对公对私（0为对私，1为对公）
                            var customerName = request["customerName"] ?? "";//代付账户名
                            var acctNo = request["acctNo"] ?? "";//银行卡号
                            //var orderNo = request["orderId"] ?? "";//订单ID

                            BalancePay data = new BalancePay();
                            //string KeyPublic = PayConfig.KeyPublic;//公钥
                            //string PrivateKey = PayConfig.PrivateKey;//私钥
                            data.requestNo = YaohuaID.NewID();//流水号
                            data.version = PayConfig.version;//版本号
                            data.productId = "0201";//产品类型
                            data.transId = "07";//交易类型
                            data.merNo = PayConfig.merNo;//商户号
                            data.orderDate = DateTime.Now.Date.ToString("yyyyMMdd");//交易日期
                            data.orderNo = YaohuaID.NewID();//商户订单号
                            data.notifyUrl = PayConfig.notifyUrl;//异步通知地址
                            data.transAmt = transAmt;//代付金额(分)
                            data.isCompay = Compay;//对公对私
                            data.customerName = customerName;//代付账户名称
                            data.acctNo = acctNo;//银行号      
                            //签名数据设置
                            //var resdata = RSAHelper.BalancePay(data);
                            //对数据签名
                            data.signature = RSAHelper.BalancePay(data).UrlEncode();

                            var resdata = RSAHelper.requestPay2(data);
                            var url = "http://13.127.174.232/payment-gate-web/gateway/api/backTransReq?" + resdata;

                            var result = CommonMethod.ApiGet(url, "");

                            //var url = "http://13.127.174.232/payment-gate-web/gateway/api/backTransReq?" + resdata + "&signature=" + data.signature;
                            ////构建form 返回提交
                            //var form = "<form id='myform' action = 'http://13.127.174.232/payment-gate-web/gateway/api/backTransReq'accept-charset='utf-8' enctype='application/x-www-form-urlencoded' onsubmit='document.charset='utf-8;' method = 'POST'  name = 'myform'>" +
                            //            " <input type = 'text' id='requestNo' class='form-control' name ='requestNo' value =" + data.requestNo + " >" +
                            //            " <input type = 'text' id='version' class='form-control' name='version' value=" + data.version + ">" +
                            //            " <input type = 'text' id='productId' class='form-control' name='productId' value=" + data.productId + ">" +
                            //            " <input type = 'text' id='transId' class='form-control' name='transId' value=" + data.transId + ">" +
                            //            " <input type = 'text' id='merNo' class='form-control' name='merNo' value=" + data.merNo + ">" +
                            //            " <input type = 'text' id='orderDate' class='form-control' name='orderDate' value=" + data.orderDate + ">" +
                            //            " <input type = 'text' id='orderNo' class='form-control' name='orderNo'  value=" + data.orderNo + ">" +
                            //            " <input type = 'text' id='notifyUrl' class='form-control' name='notifyUrl' value=" + data.notifyUrl + ">" +
                            //            " <input type = 'text' id='transAmt' class='form-control' name='transAmt' value=" + data.transAmt + ">" +
                            //            " <input type = 'text' id='isCompay' class='form-control' name='isCompay' value=" + data.isCompay + ">" +
                            //            " <input type = 'text' id='commodityName' class='form-control' name='commodityName' value=" + data.commodityName + ">" +
                            //            " <input type = 'text' id='signature' class='form-control' name='signature' value=" + data.signature + ">" +
                            //            "<input type = 'submit' class='btn btn-success'  value='提交'>" +
                            //            "</form>";
                            output = JsonSerializer.Serialize(new { result_state = true, result = result });
                        }
                        break;
                    #endregion



                    //////支付
                    #region
                    case "MyH5Pay":
                        {
                            string money = request["money"] ?? "";//金额
                            string payMethod = request["payMethod"] ?? "";//付款方式
                            //string acc_no = request["acc_no"] ?? "";//收款人账号
                            //string phone = request["phone"] ?? "";//银行预留手机号
                            //string bank_settle_no = request["bank_settle_no"] ?? "";//开户行行号，对公必要
                            string remark = request["remark"] ?? "";//商品描述
                            if (money.IsNullOrEmptys() || payMethod.IsNullOrEmptys() || remark.IsNullOrEmptys())
                            {
                                throw new CommonException("请输入完整的信息");
                            }
                            else
                            {
                                if (payMethod == "微信APP支付") payMethod = "10009";
                                if (payMethod == "微信扫码") payMethod = "10001";
                                if (payMethod == "支付宝H5") payMethod = "10008";
                                if (payMethod == "支付宝扫码") payMethod = "10003";
                                if (payMethod == "银联二维码") payMethod = "10012";
                                if (payMethod == "QQ扫码") payMethod = "10011";

                                MyPay data = new MyPay();
                                data.merchantNo = NewPayConfig.merchant_code;
                                data.requestNo = RSAHelper.GetTimeStamp();//流水号
                                data.money = money;
                                data.payDate = data.requestNo;//时间戳
                                data.payMethod = payMethod;
                                //data.pageUrl = "www.baidu.com/";
                                //data.backUrl = "http://192.168.1.8:8022/WebHandler/PayGetHandler.ashx";
                                data.remark = remark;

                                //ascii数据
                                var resdata = RSAHelper.OnePaymentPay(data);
                                var To_be_encrypted = resdata + "key=" + NewPayConfig.key;


                                //私钥
                                //var xmlPrivateKeys = RSAHelper.RSAPrivateKeyJava2DotNet(NewPayConfig.priKey);
                                //公钥
                                //var xmlPublicKey = RSAHelper.RSAPublicKeyJava2DotNet(NewPayConfig.pubKey);
                                //data.sign = RSAHelper.SignData(To_be_encrypted);
                                data.sign = To_be_encrypted.MD5_Encode32();

                                var body = resdata + "sign=" + data.sign;
                                var url = "http://pay.yifubaopay.com/ownPay/pay?" + body;
                                //data.sign = RSAHelper.sign1(xmlPrivateKeys, To_be_encrypted);
                                //var boolcheck = RSAHelper.verify(xmlPublicKey, resdata, data.sign);
                                ////构建form 返回提交
                                //Post请求
                                //var result = CommonMethod.ApiPost("http://pay.yifubaopay.com/ownPay/pay", body, null, encoding_name: "utf-8");
                                var result = CommonMethod.ApiGet(url, "");                               

                                output = JsonSerializer.Serialize(new { result_state = true, result = result, requestNo = data.requestNo }); /*,form = form, merchantNo= data.merchantNo, requestNo=data.requestNo, money=data.money, payMethod=data.payMethod,remark=data.remark,sign=data.sign });*/
                            }
                        }
                        break;
                    #endregion

                    ///单笔代付
                    #region
                    case "OnePayment":
                        {
                            int money = (request["money"] ?? "").ToInt();//金额
                            string acct_name = request["acct_name"] ?? "";//收款人姓名
                            string acct_no = request["acc_no"] ?? "";//收款人账号
                            string phone = request["phone"] ?? "";//银行预留手机号
                            //string bank_settle_no = request["bank_settle_no"] ?? "";//开户行行号，对公必要
                            string remark = request["remark"] ?? "";//附言
                            if (money.IsNullOrEmptys() || acct_name.IsNullOrEmptys() || phone.IsNullOrEmptys() || remark.IsNullOrEmptys())
                            {
                                throw new CommonException("请输入完整的信息");
                            }
                            else
                            {
                                string requestno = YaohuaID.NewID();


                                OnePayment data = new OnePayment();
                                data.version = NewPayConfig.version;
                                data.merchant_code = NewPayConfig.merchant_code;
                                data.requestno = requestno;//流水号
                                data.money = money;
                                data.money_type = NewPayConfig.money_type;
                                data.product_type = NewPayConfig.product_type;
                                data.acct_name = acct_name;
                                data.acct_no = acct_no;
                                data.acct_type = NewPayConfig.acct_type;
                                data.phone = phone;
                                //data.bank_settle_no = bank_settle_no;
                                data.remark = remark;

                                //ascii数据
                                var resdata = RSAHelper.OnePaymentPay(data);
                                var To_be_encrypted = resdata + "key=" + NewPayConfig.key;

                                //私钥
                                var xmlPrivateKeys = RSAHelper.RSAPrivateKeyJava2DotNet(NewPayConfig.priKey);
                                //公钥
                                //var xmlPublicKey = RSAHelper.RSAPublicKeyJava2DotNet(NewPayConfig.pubKey);

                                data.sign = RSAHelper.sign(xmlPrivateKeys, To_be_encrypted);

                                var body = resdata + "sign=" + data.sign;

                                var url = "http://api_pay.yifubaopay.com/payment/paymentApi?" + body;
                                //var boolcheck = RSAHelper.verify(xmlPublicKey, resdata, data.sign);

                                var result = CommonMethod.ApiGet(url, "");
                                //var result = CommonMethod.ApiPost("http://api_pay.yifubaopay.com/payment/paymentApi", body, null, encoding_name: "utf-8");

                                ////构建form 返回提交
                                //var form = "<form id='myform' action = 'http://api_pay.yifubaopay.com/payment/paymentApi' method = 'GET'  name = 'myform'>" +
                                //            " <input type = 'text' id='version' class='form-control' name ='version' value =" + data.version + " >" +
                                //            " <input type = 'text' id='merchant_code' class='form-control' name='merchant_code' value=" + data.merchant_code + ">" +
                                //            " <input type = 'text' id='requestno' class='form-control' name='requestno' value=" + data.requestno + ">" +
                                //            " <input type = 'text' id='money' class='form-control' name='money' value=" + data.money + ">" +
                                //            " <input type = 'text' id='money_type' class='form-control' name='money_type' value=" + data.money_type + ">" +
                                //            " <input type = 'text' id='product_type' class='form-control' name='product_type' value=" + data.product_type + ">" +
                                //            " <input type = 'text' id='acct_name' class='form-control' name='acct_name'  value=" + data.acct_name + ">" +
                                //            " <input type = 'text' id='acct_no' class='form-control' name='acct_no' value=" + data.acct_no + ">" +
                                //            " <input type = 'text' id='acct_type' class='form-control' name='acct_type' value=" + data.acct_type + ">" +
                                //            " <input type = 'text' id='phone' class='form-control' name='phone' value=" + data.phone + ">" +
                                //            " <input type = 'text' id='remark' class='form-control' name='remark' value=" + data.remark + ">" +
                                //            " <input type = 'text' id='sign' class='form-control' name='sign' value=" + data.sign + ">" +
                                //            "<input type = 'submit' class='btn btn-success'  value='提交'>" +
                                //            "</form>";
                                output = JsonSerializer.Serialize(new { result_state = true, result = result });
                            }
                        }
                        break;
                    #endregion

                    ////查询订单结果

                    ///支付的结果
                    #region
                    case "GetOrderType":
                        {
                            string merchantNo = NewPayConfig.merchant_code;//商户号
                            string requestNo = request["requestNo"] ?? "";//请求流水号
                            var To_be_encrypted = "merchantNo=" + merchantNo + "&requerstNo=" + requestNo + "&key=" + NewPayConfig.key;
                            string sign = To_be_encrypted.MD5_Encode32();//签名
                            var body = "merchantNo=" + merchantNo + "&requerstNo=" + requestNo + "&sign=" + sign;

                            var result = CommonMethod.ApiPost("http://query.yifubaopay.com/own/business/orderInquiry", body, null, encoding_name: "utf-8");

                            output = JsonSerializer.Serialize(new { result_state = true, result = result });
                        }
                        break;
                        #endregion
                }
            }
            catch (Exception ex)
            {
                output = JsonSerializer.Serialize(new
                {
                    result_state = false,
                    msg = ex.Message
                });
            }
        }

    }

    [Serializable]
    internal class CommonException : Exception
    {
        public CommonException()
        {
        }

        public CommonException(string message) : base(message)
        {
        }

        public CommonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}