namespace EasyCore.Repository.RESTful.HATEOAS
{
    /// <summary>
    /// Link资源
    /// </summary>
    public class LinkResource
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="href"></param>
        /// <param name="rel"></param>
        /// <param name="method"></param>
        public LinkResource(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
        /// <summary>
        /// 链接
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// 和资源的关系
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string Method { get; set; }
    }
}
