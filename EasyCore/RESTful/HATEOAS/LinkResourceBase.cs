using System.Collections.Generic;

namespace EasyCore.Repository.RESTful.HATEOAS
{
    /// <summary>
    /// Link资源基类
    /// </summary>
    public abstract class LinkResourceBase
    {
        /// <summary>
        /// 链接集合
        /// </summary>
        public List<LinkResource> Links { get; set; } = new List<LinkResource>();
    }
}
