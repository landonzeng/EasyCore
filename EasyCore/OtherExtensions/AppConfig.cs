using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EasyCore.OtherExtensions
{
    public class AppConfig
    {
        public static IConfigurationRoot Configuration { get; internal set; }
        public static IConfigurationSection GetSection(string name)
        {
            return Configuration?.GetSection(name);
        }
    }
}
