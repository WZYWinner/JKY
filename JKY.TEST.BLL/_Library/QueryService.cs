using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;
using System.Text;

namespace Yaohuasoft.Framework.BLL
{
    /// <summary>
    /// 字符串相关特殊处理辅助类
    /// </summary>
    public static partial class QuerySerivce
    {

        /// <summary>
        /// 查询参数字典转化为字符串
        /// </summary>
        /// <param name="dropList"></param>
        /// <param name="textBox"></param>
        /// <param name="textBoxInOne"></param>
        /// <param name="sortList"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public static string QueryDict2String(YaohuaDict<string, string> dropList,
            YaohuaDict<string, string> textBox,
            YaohuaDict<string, string> textBoxInOne,
            YaohuaDict<string, string> sortList,
            int PageIndex)
        {
            YaohuaDict<string, string> result = new YaohuaDict<string, string>();

            result.Add(dropList.Dict);
            result.Add(textBox.Dict);
            result.Add(textBoxInOne.Dict);
            result.Add(sortList.Dict);
            result.Add("PageIndex", PageIndex.ToStr());

            return Dict2String(result);
        }


        /// <summary>
        /// 将YaohuaDict转换成字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Dict2String(YaohuaDict<string, string> input)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in input.Dict)
            {
                string tmpStr = item.Key + ":" + item.Value + "|";
                result.Append(tmpStr);
            }
            return result.ToString();
        }


        /// <summary>
        /// 将字符串转化为YaohuaDict
        /// </summary>
        /// <param name="QueryString"></param>
        /// <returns></returns>
        public static YaohuaDict<string, string> String2QueryParm(string QueryString)
        {

            YaohuaDict<string, string> result = new YaohuaDict<string, string>();

            if (QueryString.IsNullOrEmptys()) return result;


            string[] queryList = QueryString.Split2Str("|");

            foreach (string item in queryList)
            {
                string[] tmpList = item.Split2Str(":");
                if (tmpList.Length < 2) continue;
                result.Add(tmpList[0], tmpList[1]);
            }
            return result;
        }

    }

}