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
    public static partial class UnitWitnessService
    {
        static public YaohuaDict<string, string> GetDropList()
        {

            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();
            UnitWitnessQueryParameter parm = new UnitWitnessQueryParameter();
            parm.Pager.Enable = false;


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            UnitWitnessDALEntity[] result = UnitWitnessDAL.Select(0, parm);



            foreach (var item in result)
            {
                dict.Add(item.WitnessUnitId, item.WitnessUnitName);
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
        static public string GetValue(string typeId)
        {
            ////去头尾空格


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            UnitWitnessDALEntity result = UnitWitnessDAL.Select(0, typeId);
            if (result == null) return "";
            else return result.WitnessUnitName;

        }
    }

}