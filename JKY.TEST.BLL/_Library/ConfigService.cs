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
    public static partial class ConfigService
    {
        /// <summary>
        /// 是否检验SESSION，用于数据库为空时创建初始数据
        /// </summary>
        static public bool IsCheckSession = true;

    }

}