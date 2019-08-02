﻿using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;

namespace Yaohuasoft.Framework.DAL
{
    /// <summary>
    /// 委托单位Service
    /// </summary>
    public static partial class UnitEntrustService
    {

        static public YaohuaDict<string, string> GetDropList()
        {


            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();
            UnitEntrustQueryParameter parm = new UnitEntrustQueryParameter();
            parm.Pager.Enable = false;



            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            UnitEntrustDALEntity[] result = UnitEntrustDAL.Select(0,parm);



            foreach (var item in result)
            {
                dict.Add(item.EntrustUnitId, item.EntrustUnitName);
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
        static public string GetValue( string typeId)
        {


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            UnitEntrustDALEntity result = UnitEntrustDAL.Select(0, typeId);
            if (result == null) return "";
            else return result.EntrustUnitName;

        }






    }

}