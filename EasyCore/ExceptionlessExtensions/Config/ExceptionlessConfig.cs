using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace EasyCore.ExceptionlessExtensions.Config
{
    public class ExceptionlessConfig : IOptions<ExceptionlessConfig>
    {
        public ExceptionlessConfig Value => this;
        
        public string ApiKey { get; set; }

        public string ServerUrl { get; set; }
    }
}
