using System;
using Yaohuasoft.Framework.Library;
using Yaohuasoft.Framework.DAL;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// 公用缓存
    /// </summary>
    public class CacheBase<T>
    {
        /// <summary>
        /// 缓存实体字典
        /// </summary>
        private static YaohuaDict<string, object> dic_Data;
        /// <summary>
        /// 关键字
        /// </summary>
        private static string _key = string.Empty;
        /// <summary>
        /// 关键字
        /// </summary>
        internal static string Key {
            set { _key = value; }
        }

        /// <summary>
        /// 公用缓存静态构造函数
        /// </summary>
        static CacheBase(){
            dic_Data = new YaohuaDict<string, object>() { CacheSecond = 60*60*24 };
        }

        /// <summary>
        /// 通过索引器获取某个对象
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public T this[int index]{
            get {
                return List[index];
            }
            set {
                List[index] = value;
            }
        }

        /// <summary>
        /// 获取所有列表
        /// </summary>
        public virtual T[] List
        {
            get {
                SetData();
                return dic_Data[_key] as T[];
            }
            private set {
                if (!dic_Data.ContainsKey(_key))
                    dic_Data.Add(_key, value);
                else
                    dic_Data[_key] = value;
            }
        }

        /// <summary>
        /// 判断是否/不存在赋值
        /// </summary>
        private void SetData() {
            if (!dic_Data.ContainsKey(_key)) dic_Data.Add(_key, Data);
        }

        /// <summary>
        /// 数据
        /// </summary>
        internal virtual T[] Data { get; private set; }

        /// <summary>
        /// 设置缓存时间
        /// </summary>
        internal static int SetCacheDate
        {
            set {
                if (value > 0) {
                    dic_Data.CacheSecond = value;
                }
            }
        }
    }
}