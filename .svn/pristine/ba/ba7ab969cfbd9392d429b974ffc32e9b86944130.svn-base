using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;

namespace Yaohuasoft.Framework.DAL
{
    /// <summary>
    /// 建设单位Service
    /// </summary>
    public static partial class UnitConstructionService
    {
        

        static public YaohuaDict<string, string> GetDropList()
        {


            YaohuaDict<string, string> dict = new YaohuaDict<string, string>();
            UnitConstructionQueryParameter parm = new UnitConstructionQueryParameter();
            parm.Pager.Enable = false;



            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            UnitConstructionDALEntity[] result = UnitConstructionDAL.Select(0,parm);
            foreach (var item in result)
            {
                dict.Add(item.ConstructionUnitId, item.ConstructionUnitName);
            }



            return dict;
        }
        static public string GetValue(string typeId)
        {
            ////去头尾空格


            ////使用LINQ从ID映射表中查询需要删除的CACHE ID
            UnitConstructionDALEntity result = UnitConstructionDAL.Select(0, typeId);
            if (result == null) return "";
            else return result.ConstructionUnitName;

        }
    }

}