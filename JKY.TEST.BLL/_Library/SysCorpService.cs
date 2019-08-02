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
    public static partial class SysCorpService
    {
        static private YaohuaDict<string, SysCorpDALEntity> _dict
            = new YaohuaDict<string, SysCorpDALEntity>();

        static private DateTime _LastUpdate = DateTime.MinValue;

        //static private bool HasInit = false;


        public static void Initialize()
        {
            ////如果最近60秒更新过
            if (_LastUpdate.AddSeconds(60 * 1) > DateTime.Now) return;

            YaohuaDict<string, SysCorpDALEntity> tmpDict
                = new YaohuaDict<string, SysCorpDALEntity>();


            SysCorpQueryParameter parm = new SysCorpQueryParameter();
            parm.Pager.Enable = false;


            var list = SysCorpDAL.Select(0, parm);

            foreach (var item in list)
                tmpDict.Add(item.CorpId, item);


            _dict = tmpDict;
            _LastUpdate = DateTime.Now;

        }



        static public YaohuaDict<string, string> GetDropList(string corpId, string typeId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            SysCorpDALEntity[] result = (from item in _dict.Dict
                                         select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.CorpId, item.CorpName);
            }



            return dict;
        }



        static public string GetValue(string corpId, string type, string key)
        {
            if (key == null) return null;

            Initialize();


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysCorpDALEntity result = (from item in _dict.Dict
                                       where item.Value.CorpId == key
                                       select item.Value).FirstOrDefault();
            if (result == null) return key;
            else return result.CorpName;

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
            SysCorpDALEntity result = (from item in _dict.Dict
                                       where item.Value.CorpName == Text
                                       select item.Value).FirstOrDefault();
            if (result == null) return Text;
            else return result.CorpId;

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
        static public YaohuaDict<string, string> GetDropList()
        {

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysCorpQueryParameter parm = new SysCorpQueryParameter();
            parm.Pager.Enable = false;
            SysCorpDALEntity[] result = SysCorpDAL.Select(0, parm);
            foreach (var item in result)
            {
                dict.Add(item.CorpId, item.CorpName);
            }
            return dict;
        }
        static public string GetValue(string typeId)
        {
            string CorpId = typeId;
            SysCorpDALEntity entity = SysCorpDAL.Select(0, CorpId);
            if (entity == null) return "";
            return entity.CorpName;
        }
        static public string GetCode(string typeId)
        {
            string CorpId = typeId;
            SysCorpDALEntity entity = SysCorpDAL.Select(0, CorpId);
            if (entity == null) return "";
            return entity.CoreCode;
        }

    }

}