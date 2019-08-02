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
    public static partial class SysAreaService
    {
        static private string[] spliter = { ",", "|", " ", "，", "　" };

        static public YaohuaDict<string, SysAreaDALEntity> _dict
            = new YaohuaDict<string, SysAreaDALEntity>();


        static private DateTime _LastUpdate = DateTime.MinValue;





        /// <summary>
        /// 获取跟目录的数据
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        static public YaohuaDict<string, string> GetDropList1(string corpId, string areaId)
        {

            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysAreaDALEntity[] result = (from item in _dict.Dict
                                         where item.Value.ParentId == "0"
                                         orderby item.Value.PowerIndex descending
                                         select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.AreaId, item.AreaName);
            }



            return dict;
        }


        /// <summary>
        /// 获取第二级
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        static public YaohuaDict<string, string> GetDropList2(string corpId, string areaId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();

            SysAreaDALEntity tmpEntity = _dict[areaId];
            string RootId = "";
            if (tmpEntity == null) RootId = "";
            else RootId = _dict[areaId].RootId;


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysAreaDALEntity[] result = (from item in _dict.Dict
                                         where item.Value.ParentId == RootId
                                         orderby item.Value.PowerIndex descending
                                         select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.AreaId, item.AreaName);
            }



            return dict;
        }


        /// <summary>
        /// 获取第三级
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        static public YaohuaDict<string, string> GetDropList3(string corpId, string areaId)
        {

            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            SysAreaDALEntity tmpEntity = _dict[areaId];
            string ParentId = "";
            if (tmpEntity == null) ParentId = "";
            else ParentId = _dict[areaId].ParentId;


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysAreaDALEntity[] result = (from item in _dict.Dict
                                         where item.Value.ParentId == ParentId
                                         orderby item.Value.PowerIndex descending
                                         select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.AreaId, item.AreaName);
            }



            return dict;
        }

        /// <summary>
        /// 获取第三级
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        static public YaohuaDict<string, string> GetDropListGetChild(string corpId, string areaId)
        {

            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            //SysAreaDALEntity tmpEntity = _dict[areaId];
            //string ParentId = "";
            //if (tmpEntity == null) ParentId = "";
            //else ParentId = _dict[areaId].ParentId;


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysAreaDALEntity[] result = (from item in _dict.Dict
                                         where item.Value.ParentId == areaId
                                         orderby item.Value.PowerIndex descending
                                         select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.AreaId, item.AreaName);
            }



            return dict;
        }





        static public string GetSelectedItem1(string areaId)
        {

            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();

            SysAreaDALEntity tmpEntity = _dict[areaId];
            string RootId = "";
            if (tmpEntity == null) RootId = "";
            else RootId = _dict[areaId].RootId;




            return RootId;
        }


        /// <summary>
        /// 获取第二级
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        static public string GetSelectedItem2(string areaId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();

            SysAreaDALEntity tmpEntity = _dict[areaId];
            string ParentId = "";
            if (tmpEntity == null) ParentId = "";
            else ParentId = _dict[areaId].ParentId;


            return ParentId;

        }





        /// <summary>
        /// 根据KEY取值
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="typeId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public string GetDispName(string corpId, string typeId, string key)
        {
            if (key == null) return null;


            Initialize();
            ////去头尾空格
            key = key.Trim();


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysAreaDALEntity result = (from item in _dict.Dict
                                       where item.Value.AreaId == key
                                       select item.Value).FirstOrDefault();
            if (result == null) return key;
            else return result.AreaFullName;

        }



        public static void Initialize()
        {
            ////如果最近60秒更新过
            if (_LastUpdate.AddSeconds(60 * 1) > DateTime.Now) return;

            YaohuaDict<string, SysAreaDALEntity> tmpDict
                = new YaohuaDict<string, SysAreaDALEntity>();


            SysAreaQueryParameter parm = new SysAreaQueryParameter();
            parm.Pager.Enable = false;

            var list = SysAreaDAL.Select(0, parm);

            foreach (var item in list)
                tmpDict.Add(item.AreaId, item);


            _dict = tmpDict;
            _LastUpdate = DateTime.Now;

        }

    }

}