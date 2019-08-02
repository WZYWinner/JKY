using System;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class GetMenuHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            //base.ExecuteRequest(context);
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    ////获取子菜单
                    case "Menu":
                        {                           
                            LanMenuQueryParameter Menu = new LanMenuQueryParameter();                                
                            var MenuList = LanMenuDAL.Select(0, Menu);
                            if (MenuList.IsNullOrEmptys())
                            {
                                throw new Exception("该内容为空");
                            }
                            else
                            {
                                //存放全部菜单
                                ArrayList list = new ArrayList();
                                for (var i = 0; i < MenuList.Length; i++)
                                {
                                    LanSecondMenuQueryParameter secondMenu = new LanSecondMenuQueryParameter();
                                    secondMenu.EqualTo.LanMenuId = MenuList[i].LanMenuId;
                                    var secondmenu = LanSecondMenuDAL.Select(0,secondMenu);
                                    
                                    list.Add(new { menuName=MenuList[i].LanMenuName,menuPost=MenuList[i].LanMenuPostImg,secondmenu=secondmenu});
                                }
                                output = JsonSerializer.Serialize(new { result_state = true,MenuList= list });
                            }                           
                        }
                        break;
                    case "HomeMenu":
                        {
                            //查询全部菜单
                            LanMenuQueryParameter Menu = new LanMenuQueryParameter();
                            var MenuList = LanMenuDAL.Select(0, Menu);
                            if (MenuList.IsNullOrEmptys())
                            {
                                throw new Exception("该内容为空");
                            }
                            else
                            {
                                //创建存储菜单的空间
                                ArrayList list = new ArrayList();
                                //只获取14个菜单名称
                                for (var i=0;i<14;i++)
                                {
                                    list.Add(MenuList[i]);
                                }
                                output = JsonSerializer.Serialize(new { result_state = true, MenuList = list });
                            }
                        }
                        break;                  
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                 output = JsonSerializer.Serialize(new { result_state = false, msg=ex.Message });
            }
        }
    }
}