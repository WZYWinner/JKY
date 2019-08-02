using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// 列表
    /// </summary>
    public class ChannelList
    {
        [XmlArrayItem("Channel")]
        public List<Channel> List = new List<Channel>();
    }

    /// <summary>
    /// 子项
    /// </summary>
    public class Channel
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Data { get; set; }
    }
}