using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;

namespace Yaohuasoft.Framework.Web
{
    public class BaseHanlder : System.Web.SessionState.IRequiresSessionState, IHttpHandler
    {

        protected HttpContext context { get; set; }
        /// <summary>
        /// 获取请求对象
        /// </summary>
        protected System.Web.HttpRequest request
        {
            get
            {
                return context.Request;
            }
        }
        /// <summary>
        /// 获取输入对象
        /// </summary>
        protected HttpResponse response
        {
            get
            {
                return context.Response;
            }
        }
        /// <summary>
        /// 获取session
        /// </summary>
        protected HttpSessionState session
        {
            get
            {
                return context.Session;
            }
        }
        /// <summary>
        /// 输出内容
        /// </summary>
        protected string output = string.Empty;
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public virtual void ProcessRequest(HttpContext context)
        {
            this.context = context;
            //context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //context.Response.AddHeader("Content-Security-Policy", "upgrade-insecure-requests");
            ExecuteRequestExt(context);
            ExecuteRequest(context);
            response.Write(JsonExtend(output));
        }
        /// <summary>
        /// 执行请求
        /// </summary>
        /// <param name="context"></param>
        protected virtual void ExecuteRequestExt(HttpContext context) { }
        /// <summary>
        /// 执行请求
        /// </summary>
        /// <param name="context"></param>
        protected virtual void ExecuteRequest(HttpContext context) { }

        /// <summary>
        /// 处理json字符串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public string JsonExtend(string json)
        {
            return Regex.Replace(json, @"(\,\""\w+\"":(null|undefined|\{\}|""{2}|\""\\\/date[^\/]+\/\"")|\""\w+\"":(null|undefined|\{\}|""{2}|\""\\\/date[^\/]+\/\"")\,)", "", RegexOptions.IgnoreCase);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 当where为真的时候，szOutput参数接收szErrorMsg
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="szErrorMsg">错误的信息</param>
        /// <param name="szOutput">接收返回错误的信息</param>
        /// <returns>直接返回where</returns>
        protected bool Validate(bool where, string szErrorMsg, out string szOutput)
        {
            szOutput = where ? szErrorMsg : "";
            return where;
        }
    }
}