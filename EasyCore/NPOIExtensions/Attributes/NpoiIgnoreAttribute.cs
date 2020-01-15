using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.NPOIExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NpoiIgnoreAttribute : Attribute
    {
        internal bool? _NpoiIsIgnore;

        /// <summary>
        /// 忽略此列，不导入、不导出
        /// </summary>
        public bool NpoiIsIgnore { get => _NpoiIsIgnore ?? false; set => _NpoiIsIgnore = value; }
    }
}