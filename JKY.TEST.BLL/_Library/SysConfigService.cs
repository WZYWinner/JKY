using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;

namespace Yaohuasoft.Framework.DAL
{
    /// <summary>
    /// 字符串相关特殊处理辅助类
    /// </summary>
    public static partial class SysConfigService
    {
        static public YaohuaDict<string, SysConfigDALEntity> _dict
            = new YaohuaDict<string, SysConfigDALEntity>();


        static private DateTime _LastUpdate = DateTime.MinValue;

        //static private bool HasInit = false;


        static public ListItem[] Dict2ListItem(this YaohuaDict<string, string> dict)
        {
            List<ListItem> result = new List<ListItem>();
            foreach (var item in dict.Dict)
            {
                result.Add(new ListItem(item.Value, item.Key));
            }

            return result.ToArray();
        }

        public static void Initialize()
        {
            ////如果最近60秒更新过
            if (_LastUpdate.AddSeconds(60 * 1) > DateTime.Now) return;

            YaohuaDict<string, SysConfigDALEntity> tmpDict
                = new YaohuaDict<string, SysConfigDALEntity>();


            SysConfigQueryParameter parm = new SysConfigQueryParameter();
            parm.Pager.Enable = false;

            var list = SysConfigDAL.Select(0, parm);

            foreach (var item in list)
                tmpDict.Add(item.ConfigId, item);


            _dict = tmpDict;
            _LastUpdate = DateTime.Now;

        }



        static public YaohuaDict<string, string> GetDropList(string corpId, string typeId)
        {

            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysConfigDALEntity[] result = (from item in _dict.Dict
                                           where item.Value.TypeId == typeId
                                           orderby item.Value.PowerIndex descending
                                           select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.Code, item.Name);
            }



            return dict;
        }


        /// <summary>
        /// 根据KEY取值
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="typeId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public string GetValue(string corpId, string typeId, string key)
        {
            if (key == null) return null;

            
            Initialize();
            ////去头尾空格
            key = key.Trim();


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysConfigDALEntity result = (from item in _dict.Dict
                                         where item.Value.TypeId == typeId && item.Value.Code == key
                                         select item.Value).FirstOrDefault();
            if (result == null) return key;
            else return result.Name;

        }


        /// <summary>
        /// 根据值来取KEY
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="typeId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public string GetKey(string corpId, string typeId, string Text)
        {
            if (Text == null) return null;

            Initialize();
            Text = Text.Trim();

            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysConfigDALEntity result = (from item in _dict.Dict
                                         where item.Value.TypeId == typeId && item.Value.Name == Text
                                         select item.Value).FirstOrDefault();
            if (result == null) return Text;
            else return result.Code;

        }

        static private string[] spliter = { ",", "|", "，" };

        /// <summary>
        /// 文字列表转成KEY列表（主要用于导入时使用）
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="typeId"></param>
        /// <param name="textList"></param>
        /// <returns></returns>
        static public string TextList2KeyList(string corpId, string typeId, string textList)
        {
            if (textList == null) return null;

            Initialize();

            string[] result = textList.Split(spliter, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < result.Length; i++)
                result[i] = GetKey(corpId, typeId, result[i]);


            return "," + YaohuaCollection<string>.ToString(result, ",") + ",";
        }






    }

}