using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public abstract class MQPublishJsonDto
    {
        public virtual string Data { get; set; }
    }
}