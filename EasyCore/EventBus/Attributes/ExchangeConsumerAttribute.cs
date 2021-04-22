using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.EventBus.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class ExchangeConsumerAttribute : Attribute
    {
        public string ExchangeName
        {
            get { return _exchangeName; }
        }

        private string _exchangeName { get; set; }

        public ExchangeConsumerAttribute(string exchangeName)
        {
            _exchangeName = exchangeName;
        }
    }
}