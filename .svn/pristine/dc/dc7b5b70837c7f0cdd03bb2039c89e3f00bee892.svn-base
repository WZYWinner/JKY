using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;

namespace Yaohuasoft.Framework.BLL
{
    /// <summary>
    /// 字符串相关特殊处理辅助类
    /// </summary>
    public static partial class DateTimeService
    {
        static private YaohuaDict<string, string> _dict
            = new YaohuaDict<string, string>();

        static private DateTime _LastUpdate = DateTime.MinValue;

        public static void Initialize()
        {
            ////如果最近60秒更新过
            if (_LastUpdate.AddSeconds(60 * 1) > DateTime.Now) return;

            YaohuaDict<string, string> tmpDict
                = new YaohuaDict<string, string>();


            //SysRoleQueryParameter parm = new SysRoleQueryParameter();


            //var list = SysRoleDAL.Select(0, parm);

            //foreach (var item in list)
            //    tmpDict.Add(item.RoleId, item);


            _dict = tmpDict;
            _LastUpdate = DateTime.Now;

        }

        static public YaohuaDict<string, string> GetTimeDropList1(DateTime dt)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();

            for (int i = 0; i < 24; i++)
            {
                string value = (i).ToStr();
                dict.Add(value, value);
            }



            return dict;
        }
        static public YaohuaDict<string, string> GetTimeDropList2(DateTime dt)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();

            for (int i = 0; i < 12; i++)
            {
                string value = (i * 5).ToStr();
                dict.Add(value, value);
            }



            return dict;
        }


        static public string GetSelectedItem1(DateTime  dt)
        {
            int value = 0;
            value = dt .Hour;
            return value.ToStr();
        }
        static public string GetSelectedItem2(DateTime  dt)
        {
            int value = 0;
            value = dt.Minute / 5 * 5;
            return value.ToStr();
        }




        static public DateTime GetDateTime(string hour, string minue)
        {
            DateTime result = new DateTime(2000, 1, 1, hour.ToInt(), minue.ToInt(), 0);
            return result;
        }



        static public YaohuaDict<string, string> GetDropList(string typeId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();

            dict.Add("今天", "今天");
            dict.Add("最近三天", "最近三天");
            dict.Add("最近七天", "最近七天");
            dict.Add("最近一个月", "最近一个月");
            dict.Add("最近三个月", "最近三个月");
            dict.Add("本月", "本月");
            dict.Add("上月", "上月");
            dict.Add("今年", "今年");
            dict.Add("去年", "去年");



            return dict;
        }


        /// <summary>
        /// 大等于本值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public string GetMinValue(string type, string key)
        {
            Initialize();

            DateTime result = DateTime.Today;

            switch (key)
            {
                case "今天":
                    result = result.AddDays(0);
                    break;
                case "最近三天":
                    result = result.AddDays(-3);
                    break;
                case "最近七天":
                    result = result.AddDays(-7);
                    break;
                case "最近一个月":
                    result = result.AddDays(-30);
                    break;
                case "最近三个月":
                    result = result.AddDays(-90);
                    break;
                case "本月":
                    result = result.GetDate("MONTH");
                    break;
                case "上月":
                    result = result.GetDate("MONTH").AddMonths(-1);
                    break;
                case "今年":
                    result = result.GetDate("YEAR");
                    break;
                case "去年":
                    result = result.GetDate("YEAR").AddYears(-1);
                    break;
                default:
                    break;
            }


            return result.ToString();
        }

        /// <summary>
        /// 小于本值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public string GetMaxValue(string type, string key)
        {
            Initialize();

            DateTime result = DateTime.Today;


            switch (key)
            {
                case "今天":
                    result = result.AddDays(0).AddDays(1);
                    break;
                case "最近三天":
                    result = result.AddDays(3).AddDays(1);
                    break;
                case "最近七天":
                    result = result.AddDays(7).AddDays(1);
                    break;
                case "最近一个月":
                    result = result.AddDays(30).AddDays(1);
                    break;
                case "最近三个月":
                    result = result.AddDays(90).AddDays(1);
                    break;
                case "本月":
                    result = result.GetDate("MONTH").AddMonths(1);
                    break;
                case "上月":
                    result = result.GetDate("MONTH");
                    break;
                case "今年":
                    result = result.GetDate("YEAR").AddYears(1);
                    break;
                case "去年":
                    result = result.GetDate("YEAR");
                    break;
                default:
                    break;
            }


            return result.ToString();
        }

    }

}