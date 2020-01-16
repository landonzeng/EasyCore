using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.NPOIExtensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NpoiIgnoreAttribute : Attribute
    {
        internal bool? _IsIgnore;

        /// <summary>
        /// 忽略此列，不导入、不导出
        /// </summary>
        public bool IsIgnore { get => _IsIgnore ?? false; set => _IsIgnore = value; }
    }
}