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
    public static partial class MultiSelectService
    {
        static private string[] spliter = { ",", "|", " ", "，", "　" };

        static public string CheckBox2String(this   CheckBoxList input)
        {
            string result = ",";
            for (int i = 0; i < input.Items.Count; i++)
            {
                if (input.Items[i].Selected)
                    result += input.Items[i].Value + ",";
            }
            return result;
        }

        static public string CheckBox2StringByText(this   CheckBoxList input)
        {
            string result = ",";
            for (int i = 0; i < input.Items.Count; i++)
            {
                if (input.Items[i].Selected)
                    result += input.Items[i].Text + ",";
            }
            return result;
        }



        static public void Fill2CheckBox(this   CheckBoxList input, string selectText)
        {
            string[] list = selectText.Split(spliter, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in list)
            {
                ListItem tmp = input.Items.FindByValue(item);
                if (tmp != null) tmp.Selected = true;
            }
        }

        static public void Fill2CheckBoxByText(this   CheckBoxList input, string selectText)
        {
            string[] list = selectText.Split(spliter, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in list)
            {
                ListItem tmp = input.Items.FindByText (item);
                if (tmp != null) tmp.Selected = true;
            }
        }

        static public string GetValue(string corpId, string typeId, string key)
        {

            List<string> result = new List<string>();

            string[] list = key.Split(spliter, StringSplitOptions.RemoveEmptyEntries);


            foreach (var item in list)
            {
                result.Add(SysConfigService.GetValue(corpId, typeId, item));
            }

            return YaohuaCollection<string>.ToString(result, ",");
        }

         

    }

}