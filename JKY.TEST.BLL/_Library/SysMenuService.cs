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
    public static partial class SysMenuService
    {
        static private YaohuaDict<string, SysMenuDALEntity> _dict
            = new YaohuaDict<string, SysMenuDALEntity>();

        static private DateTime _LastUpdate = DateTime.MinValue;

        //static private bool HasInit = false;


        public static void Initialize()
        {
            ////如果最近60秒更新过
            if (_LastUpdate.AddSeconds(60 * 1) > DateTime.Now) return;

            YaohuaDict<string, SysMenuDALEntity> tmpDict
                = new YaohuaDict<string, SysMenuDALEntity>();


            SysMenuQueryParameter parm = new SysMenuQueryParameter();
            parm.Pager.Enable = false;

            var list = SysMenuDAL.Select(0, parm);

            foreach (var item in list)
                tmpDict.Add(item.MenuId, item);


            _dict = tmpDict;
            _LastUpdate = DateTime.Now;

        }



        static public YaohuaDict<string, string> GetDropList(string corpId, string typeId)
        {
            Initialize();

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();



            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            SysMenuDALEntity[] result = (from item in _dict.Dict
                                         select item.Value).ToArray();



            foreach (var item in result)
            {
                dict.Add(item.MenuId, item.CnName);
            }



            return dict;
        }



        //static public string GetValue(string type, string key)
        //{
        //    Initialize();


        //    ////使用LINQ从ID映射表中查询需要删除的CACHE ID
        //    SysPowerDALEntity result = (from item in _dict.Dict
        //                                where item.Value.PowerItem == key
        //                                select item.Value).FirstOrDefault();
        //    if (result == null) return key;
        //    else return result.CnName;

        //}



    }

}