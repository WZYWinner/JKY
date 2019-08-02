using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;
using Yaohuasoft.Framework.BLL;

namespace Yaohuasoft.Framework.Library
{
    public static class RSAHelper
    {
        /// <summary>  
        /// RSA产生密钥  
        /// </summary>  
        /// <param name="xmlKeys">私钥</param>  
        /// <param name="xmlPublicKey">公钥</param>  
        public static void RSAKey(out string xmlKeys, out string xmlPublicKey)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                xmlKeys = rsa.ToXmlString(true);
                xmlPublicKey = rsa.ToXmlString(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>    
        /// RSA私钥格式转换，java->.net    
        /// </summary>    
        /// <param name="privateKey">java生成的RSA私钥</param>    
        /// <returns></returns>   
        public static string RSAPrivateKeyJava2DotNet(this string privateKey)
        {
            RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
            Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
            Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        /// <summary>    
        /// RSA私钥格式转换，.net->java    
        /// </summary>    
        /// <param name="privateKey">.net生成的私钥</param>    
        /// <returns></returns>   
        public static string RSAPrivateKeyDotNet2Java(this string privateKey)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(privateKey);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger exp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            BigInteger d = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("D")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("P")[0].InnerText));
            BigInteger q = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Q")[0].InnerText));
            BigInteger dp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DP")[0].InnerText));
            BigInteger dq = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DQ")[0].InnerText));
            BigInteger qinv = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("InverseQ")[0].InnerText));
            RsaPrivateCrtKeyParameters privateKeyParam = new RsaPrivateCrtKeyParameters(m, exp, d, p, q, dp, dq, qinv);
            PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);
            byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();
            return Convert.ToBase64String(serializedPrivateBytes);
        }
        /// <summary>
        /// RSA公钥格式转换，java->.net
        /// </summary>
        /// <param name="publicKey">java生成的公钥</param>
        /// <returns></returns>
        public static string RSAPublicKeyJava2DotNet(string publicKey)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }
        /// <summary>  
        /// RSA的加密函数  
        /// </summary>  
        /// <param name="xmlPublicKey">公钥</param>  
        /// <param name="encryptString">待加密的字符串</param>  
        /// <returns></returns>  
        public static string RSAEncrypt(string xmlPublicKey, string encryptString)
        {
            try
            {
                byte[] PlainTextBArray;
                byte[] CypherTextBArray;
                string Result;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlPublicKey);
                PlainTextBArray = (new UnicodeEncoding()).GetBytes(encryptString);
                CypherTextBArray = rsa.Encrypt(PlainTextBArray, false);
                Result = Convert.ToBase64String(CypherTextBArray);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// RSA的解密函数  
        /// </summary>  
        /// <param name="xmlPrivateKey">私钥</param>  
        /// <param name="decryptString">待解密的字符串</param>  
        /// <returns></returns>  
        public static string RSADecrypt(string xmlPrivateKey, string decryptString)
        {
            try
            {
                byte[] PlainTextBArray;
                byte[] DypherTextBArray;
                string Result;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlPrivateKey);
                PlainTextBArray = Convert.FromBase64String(decryptString);
                DypherTextBArray = rsa.Decrypt(PlainTextBArray, false);
                Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 公钥解密
        /// </summary>
        /// <param name="xmlPublicKey">C#格式公钥</param>
        /// <param name="strEncryptString">密文</param>
        /// <returns></returns>
        public static string RSADecryptByPublicKey(string xmlPublicKey, string strEncryptString)
        {
            //得到公钥
            RsaKeyParameters keyParams = RSAPublicKeyDotNet2Java(xmlPublicKey);

            //参数与Java中加密解密的参数一致
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");

            //第一个参数 true-加密，false-解密；第二个参数表示密钥
            c.Init(false, keyParams);

            //对密文进行base64解码
            byte[] dataFromEncrypt = Convert.FromBase64String(strEncryptString);

            //加密
            byte[] outBytes = c.DoFinal(dataFromEncrypt);

            //明文      
            string clearText = Encoding.Default.GetString(outBytes);

            return clearText;
        }
        /// <summary>
        /// 公钥加密按117分割数据
        /// </summary>
        /// <param name="xmlPublicKey">C#格式公钥</param>
        /// <param name="strEncryptString">密文</param>
        /// <returns></returns>
        public static string RSAEncryptByPublicKey(string xmlPublicKey, string strEncryptString)
        {
            //得到公钥
            RsaKeyParameters keyParams = RSAPublicKeyDotNet2Java(xmlPublicKey);

            //参数与Java中加密解密的参数一致
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");

            //第一个参数 true-加密，false-解密；第二个参数表示密钥
            c.Init(true, keyParams);

            var text = strEncryptString;
            string Result = "";
            //将字符串转为UTF8编码
            text = Convert.ToBase64String(Encoding.GetEncoding("utf-8").GetBytes(text));
            //text = text.Replace("\r", "").Replace("\n", "");
            int len = 117;

            int m = text.Length / len;
            if (m * len != text.Length)
            {
                m = m + 1;
            }
            for (int i = 0; i < m; i++)
            {
                string temp = "";

                if (i < m - 1)
                {
                    temp = text.Substring(i * len, len);//(i + 1) * len
                }
                else
                {
                    temp = text.Substring(i * len);
                }
                var cache = c.DoFinal(Encoding.GetEncoding("utf-8").GetBytes(temp));
                System.IO.MemoryStream aMS = new System.IO.MemoryStream();
                aMS.Write(cache, 0, cache.Length);
                //temp = temp.Replace("\r", "").Replace("\n", "");
                Result += Convert.ToBase64String(aMS.ToArray());
            }

            return Result;
        }
        /// <summary>
        /// 公钥加密
        /// </summary>
        /// <param name="xmlPublicKey">C#格式公钥</param>
        /// <param name="strEncryptString">密文</param>
        /// <returns></returns>
        public static string RSAEncryptByPublicKey1(string xmlPublicKey, string strEncryptString)
        {
            //得到公钥
            RsaKeyParameters keyParams = RSAPublicKeyDotNet2Java(xmlPublicKey);

            //参数与Java中加密解密的参数一致
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");

            //第一个参数 true-加密，false-解密；第二个参数表示密钥
            c.Init(true, keyParams);

            //对密文进行base64解码
            byte[] dataFromEncrypt = (new UnicodeEncoding()).GetBytes(strEncryptString);

            //加密
            byte[] outBytes = c.DoFinal(dataFromEncrypt);

            string Result = Convert.ToBase64String(outBytes);

            return Result;
        }
        /// <summary>
        /// RSA加密+base64
        /// </summary>
        /// <param name="publickey">公钥</param>
        /// <param name="content">原文</param>
        /// <returns>加密后的密文字符串</returns>
        public static string RSAEncrypt1(string publickey, string content)
        {
            //最大文件加密块
            int MAX_ENCRYPT_BLOCK = 245;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publickey);
            byte[] contentByte = Encoding.UTF8.GetBytes(content);
            int inputLen = contentByte.Length;

            int offSet = 0;
            byte[] cache;
            int i = 0;
            System.IO.MemoryStream aMS = new System.IO.MemoryStream();
            // 对数据分段加密
            while (inputLen - offSet > 0)
            {
                byte[] temp = new byte[MAX_ENCRYPT_BLOCK];
                if (inputLen - offSet > MAX_ENCRYPT_BLOCK)
                {
                    Array.Copy(contentByte, offSet, temp, 0, MAX_ENCRYPT_BLOCK);
                    cache = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
                }
                else
                {
                    Array.Copy(contentByte, offSet, temp, 0, inputLen - offSet);
                    cache = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
                }
                aMS.Write(cache, 0, cache.Length);
                i++;
                offSet = i * MAX_ENCRYPT_BLOCK;
            }

            cipherbytes = aMS.ToArray();
            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privatekey">私钥</param>
        /// <param name="content">密文（RSA+base64）</param>
        /// <returns>解密后的字符串</returns>
        public static string RSADecrypt1(string privatekey, string content)
        {
            //最大文件解密块
            int MAX_DECRYPT_BLOCK = 256;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privatekey);
            byte[] contentByte = Convert.FromBase64String(content);
            int inputLen = contentByte.Length;

            // 对数据分段解密
            int offSet = 0;
            int i = 0;
            byte[] cache;
            System.IO.MemoryStream aMS = new System.IO.MemoryStream();
            while (inputLen - offSet > 0)
            {
                byte[] temp = new byte[MAX_DECRYPT_BLOCK];
                if (inputLen - offSet > MAX_DECRYPT_BLOCK)
                {
                    Array.Copy(contentByte, offSet, temp, 0, MAX_DECRYPT_BLOCK);
                    cache = rsa.Decrypt(temp, false);
                }
                else
                {
                    Array.Copy(contentByte, offSet, temp, 0, inputLen - offSet);
                    cache = rsa.Decrypt(temp, false);
                }
                aMS.Write(cache, 0, cache.Length);
                i++;
                offSet = i * MAX_DECRYPT_BLOCK;
            }
            cipherbytes = aMS.ToArray();

            return Encoding.UTF8.GetString(cipherbytes);
        }
        /// <summary>
        /// 将C#格式公钥转成Java格式公钥
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static RsaKeyParameters RSAPublicKeyDotNet2Java(string publicKey)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publicKey);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            RsaKeyParameters pub = new RsaKeyParameters(false, m, p);

            return pub;
        }
        /// <summary>  
        /// 对MD5加密后的长度为32的密文进行签名  
        /// </summary>  
        /// <param name="strPrivateKey">私钥</param>  
        /// <param name="strContent">密文</param>  
        /// <returns></returns>  
        public static string sign(string strPrivateKey, string strContent)
        {
            byte[] btContent = Encoding.UTF8.GetBytes(strContent);
            //byte[] btContent = Convert.FromBase64String(strContent);
            byte[] hv = MD5.Create().ComputeHash(btContent);
            RSACryptoServiceProvider rsp = new RSACryptoServiceProvider();
            rsp.FromXmlString(strPrivateKey);
            RSAPKCS1SignatureFormatter rf = new RSAPKCS1SignatureFormatter(rsp);
            rf.SetHashAlgorithm("MD5");
            byte[] signature = rf.CreateSignature(hv);
            return Convert.ToBase64String(signature);
        }
        public static string sign1(string strPrivateKey, string strContent)
        {
            //byte[] btContent = Encoding.UTF8.GetBytes(strContent);
            //byte[] btContent = Convert.FromBase64String(strContent);
            byte[] result;
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strContent));

            //byte[] hv = MD5.Create().ComputeHash(btContent);
            RSACryptoServiceProvider rsp = new RSACryptoServiceProvider();
            rsp.FromXmlString(strPrivateKey);
            RSAPKCS1SignatureFormatter rf = new RSAPKCS1SignatureFormatter(rsp);
            rf.SetHashAlgorithm("SHA1");
           
            return System.Convert.ToBase64String(rf.CreateSignature(result)).ToString();

            //byte[] signature = rf.CreateSignature(hv);
            //return Convert.ToBase64String(signature);
        }
        public static string SignData(string content)
        {
           
            X509Certificate2 cert = new X509Certificate2("D:/JKY.TEST/JKY.TEST/key/800320058122351.pfx", "927343883681", X509KeyStorageFlags.MachineKeySet);
            RSACryptoServiceProvider rsapri = (RSACryptoServiceProvider)cert.PrivateKey;
            RSAPKCS1SignatureFormatter f = new RSAPKCS1SignatureFormatter(rsapri);
            byte[] result;
            f.SetHashAlgorithm("SHA1");
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(content));
            return System.Convert.ToBase64String(f.CreateSignature(result)).ToString();
        }
        
        /// <summary>  
        /// RSA签名验证  
        /// </summary>  
        /// <param name="strKeyPublic">公钥</param>  
        /// <param name="strContent">密文</param>  
        /// <param name="strDeformatterData">签名后的结果</param>  
        /// <returns></returns>  
        public static bool verify(string strKeyPublic, string strContent, string sign)
        {
            try
            {
                byte[] DeformatterData;
                byte[] HashbyteDeformatter;
                //HashbyteDeformatter = Convert.FromBase64String(strContent);
                HashbyteDeformatter = Encoding.UTF8.GetBytes(strContent);
                byte[] hv = MD5.Create().ComputeHash(HashbyteDeformatter);
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPublic);
                RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5   
                RSADeformatter.SetHashAlgorithm("MD5");
                DeformatterData = Convert.FromBase64String(sign);
                //DeformatterData = Encoding.UTF8.GetBytes(sign);
                if (RSADeformatter.VerifySignature(hv, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 构建request请求参数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string requestPay1(H5Pay data)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("requestNo", data.requestNo);
            dics.Add("version", data.version);
            dics.Add("productId", data.productId);
            dics.Add("transId", data.transId);
            dics.Add("merNo", data.merNo);
            dics.Add("orderDate", data.orderDate);
            dics.Add("orderNo", data.orderNo);
            dics.Add("returnUrl", data.returnUrl);
            dics.Add("notifyUrl", data.notifyUrl);
            dics.Add("transAmt", data.transAmt);
            dics.Add("commodityName", data.commodityName);
            dics.Add("signature", data.signature);
            //dics.Add("remark", data.remark);
            var param = "";
            foreach (var item in dics.Keys)
            {
                param += item + "=" + dics[item] + "&";
            }
            return param;
        }

        public static string requestPay2(BalancePay data)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("requestNo", data.requestNo);
            dics.Add("version", data.version);
            dics.Add("productId", data.productId);
            dics.Add("transId", data.transId);
            dics.Add("merNo", data.merNo);
            dics.Add("orderDate", data.orderDate);
            dics.Add("orderNo", data.orderNo);
            dics.Add("notifyUrl", data.notifyUrl);
            dics.Add("transAmt", data.transAmt);
            dics.Add("isCompay", data.isCompay);
            dics.Add("customerName", data.customerName);
            dics.Add("acctNo", data.acctNo);
            dics.Add("signature", data.signature);
            //dics.Add("remark", data.remark);
            var param = "";
            foreach (var item in dics.Keys)
            {
                param += item + "=" + dics[item] + "&";
            }
            return param;
        }
        /// <summary>
        /// 构建签名数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string requestPay(H5Pay data)
        {
            SortedList<string, string> dics = new SortedList<string, string>();
            dics.Add("requestNo", data.requestNo);
            dics.Add("version", data.version);
            dics.Add("productId", data.productId);
            dics.Add("transId", data.transId);
            dics.Add("merNo", data.merNo);
            dics.Add("orderDate", data.orderDate);
            dics.Add("orderNo", data.orderNo);
            dics.Add("returnUrl", data.returnUrl);
            dics.Add("notifyUrl", data.notifyUrl);
            dics.Add("transAmt", data.transAmt);
            dics.Add("commodityName", data.commodityName);
            //dics.Add("signature", data.signature);
            //dics.Add("remark", data.remark);
            return signature(dics);
        }
        public static string BalancePay(BalancePay data)
        {
            SortedList<string, string> dics = new SortedList<string, string>();
            dics.Add("requestNo", data.requestNo);
            dics.Add("version", data.version);
            dics.Add("productId", data.productId);
            dics.Add("transId", data.transId);
            dics.Add("merNo", data.merNo);
            dics.Add("orderDate", data.orderDate);
            dics.Add("orderNo", data.orderNo);
            //dics.Add("returnUrl", data.returnUrl);
            dics.Add("notifyUrl", data.notifyUrl);
            dics.Add("transAmt", data.transAmt);
            dics.Add("isCompay", data.isCompay);
            //dics.Add("phoneNo", data.phoneNo);
            dics.Add("customerName", data.customerName);
            //dics.Add("cerdType", data.cerdType);
            //dics.Add("cerdId", data.cerdId);
            //dics.Add("accBankNo", data.accBankNo);
            //dics.Add("accBankName", data.accBankName);
            dics.Add("acctNo", data.acctNo);
            //dics.Add("note", data.note);
            //dics.Add("storeId", data.storeId);            
            //dics.Add("signature", data.signature);
            //dics.Add("remark", data.remark);
            return signature(dics);
        }
        /// <summary> 
        /// 获取时间戳 
        /// </summary> 
        /// <returns></returns> 
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        /// <summary>
        /// 单笔代付数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string OnePaymentPay(OnePayment data)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("version", data.version);
            dics.Add("merchant_code", data.merchant_code);
            dics.Add("requestno", data.requestno);
            dics.Add("money", data.money.ToString());
            dics.Add("money_type", data.money_type);
            dics.Add("product_type", data.product_type.ToString());
            dics.Add("acct_name", data.acct_name);
            dics.Add("acct_no", data.acct_no);
            dics.Add("acct_type", data.acct_type);
            dics.Add("phone", data.phone);
            //dics.Add("bank_settle_no", data.bank_settle_no);
            //dics.Add("bank_branch_name", data.bank_branch_name);
            dics.Add("remark", data.remark);
            //dics.Add("province", data.province);
            //dics.Add("city", data.city);
            //dics.Add("signature", data.signature);
            //dics.Add("remark", data.remark);
            return GetParamSrc(dics);
        }
        public static string OnePaymentPay(MyPay data)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("merchantNo", data.merchantNo);
            dics.Add("requestNo", data.requestNo);
            dics.Add("money", data.money);
            dics.Add("payDate", data.payDate);
            dics.Add("payMethod", data.payMethod);
            //dics.Add("pageUrl", data.pageUrl);
            //dics.Add("backUrl", data.backUrl);
            dics.Add("remark", data.remark);
            //dics.Add("signature", data.signature);
            //dics.Add("remark", data.remark);
            return GetParamSrc(dics);
        }
        public static string signature(SortedList<string, string> dictReq)
        {
            string postData = "";
            string signStr = "";
            foreach (KeyValuePair<string, string> kvp in dictReq)
            {
                if (kvp.Value == "") continue;
                if (kvp.Key != "signature") postData += kvp.Key + "=" + kvp.Value + "&";
                if (kvp.Value != "") signStr += kvp.Key + "=" + kvp.Value + "&";
            }
            string signatureData = SignData(signStr.TrimEnd('&'));
            //Tools.WriteLog("签名前：" + signStr.TrimEnd('&') + "\r\n签名后字符串：" + signatureData, "sign");
            return signatureData;
        }
        /// <summary>
        /// 构建回调签名数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string requestPay(H5Payresult data)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("merId", data.merId);
            dics.Add("orderNo", data.orderNo);
            dics.Add("amount", data.amount);
            dics.Add("mp", data.mp);
            dics.Add("status", data.status);
            dics.Add("trxNo", data.trxNo);
            dics.Add("payTime", data.payTime);
            return GetParamSrc(dics);
        }
        /// <summary>
        /// 参数按照参数名ASCII码从小到大排序（字典序）
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        public static string GetParamSrc(Dictionary<string, string> paramsMap)
        {

            var vDic = paramsMap.OrderBy(x => x.Key, new ComparerString()).ToDictionary(x => x.Key, y => y.Value);

            StringBuilder str = new StringBuilder();

            foreach (KeyValuePair<string, string> kv in vDic)
            {
                string pkey = kv.Key;
                string pvalue = kv.Value;
                str.Append(pkey + "=" + pvalue + "&");
                //str.Append(pvalue);
            }

            string result = str.ToString().Substring(0, str.ToString().Length);

            return result;
        }
        public class ComparerString : IComparer<String>
        {
            public int Compare(String x, String y)
            {
                return string.CompareOrdinal(x, y);
            }
        }
        
        /// <summary>
        /// 解决PHP Base64编码后回车问题 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String decode64(String text)
        {
            String value = "";

            try
            {
                text = string.IsNullOrEmpty(text) ? "" : text;

                int len = 64;
                int m = text.Length / len;
                if (m * len != text.Length)
                {
                    m = m + 1;
                }

                for (int i = 0; i < m; i++)
                {
                    String temp = "";
                    if (i < m - 1)
                    {
                        temp = text.Substring(i * len, len);//(i + 1) * len
                        value += temp + "\r\n";
                    }
                    else
                    {
                        temp = text.Substring(i * len);
                        value += temp;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return value;
        }
    }

}
