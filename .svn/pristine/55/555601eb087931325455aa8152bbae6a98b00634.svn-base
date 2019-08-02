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
    public static partial class SysDepartmentService
    {
        static private YaohuaDict<string, SysDepartmentDALEntity> _dict
            = new YaohuaDict<string, SysDepartmentDALEntity>();

        static private DateTime _LastUpdate = DateTime.MinValue;

        //static private bool HasInit = false;


        public static void Initialize()
        {
            ////如果最近60秒更新过
            if (_LastUpdate.AddSeconds(60 * 1) > DateTime.Now) return;

            YaohuaDict<string, SysDepartmentDALEntity> tmpDict
                = new YaohuaDict<string, SysDepartmentDALEntity>();


            SysDepartmentQueryParameter parm = new SysDepartmentQueryParameter();
            parm.Pager.Enable = false;


            var list = SysDepartmentDAL.Select(0, parm);

            foreach (var item in list)
                tmpDict.Add(item.DepartmentId, item);


            _dict = tmpDict;
            _LastUpdate = DateTime.Now;

        }



        static public YaohuaDict<string, string> GetDropList(string corpId, string typeId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            SysDepartmentDALEntity[] result = (from item in _dict.Dict
                                               select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.DepartmentId, item.DepartmentName);
            }



            return dict;
        }



        static public string GetValue(string corpId, string type, string key)
        {
            if (key == null) return null;

            Initialize();


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysDepartmentDALEntity result = (from item in _dict.Dict
                                             where item.Value.DepartmentId == key
                                             select item.Value).FirstOrDefault();
            if (result == null) return key;
            else return result.DepartmentName;

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
            SysDepartmentDALEntity result = (from item in _dict.Dict
                                             where item.Value.DepartmentName == Text
                                             select item.Value).FirstOrDefault();
            if (result == null) return Text;
            else return result.DepartmentId;

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
        static public YaohuaDict<string, string> GetDropList(string corpId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();
            SysDepartmentQueryParameter parm = new SysDepartmentQueryParameter();
            parm.Pager.Enable = false;
            parm.EqualTo.CorpId = corpId;
            SysDepartmentDALEntity[] result = SysDepartmentDAL.Select(0, parm);
            foreach (var item in result)
            {
                dict.Add(item.DepartmentId, item.DepartmentName);
            }
            return dict;
        }
        static public string GetValue(string typeId)
        {
            string CorpId = typeId;
            SysDepartmentDALEntity entity = SysDepartmentDAL.Select(0, CorpId);
            if (entity == null) return "";
            return entity.DepartmentName;
        }
        static public string GetCode(string typeId)
        {
            string CorpId = typeId;
            SysDepartmentDALEntity entity = SysDepartmentDAL.Select(0, CorpId);
            if (entity == null) return "";
            return entity.DepartmentCode;
        }
    }

}