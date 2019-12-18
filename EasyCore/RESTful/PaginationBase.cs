using EasyCore.IEntity;

namespace EasyCore.Repository.RESTful
{
    /// <summary>
    /// 分页基类
    /// </summary>
    public class PaginationBase
    {
        /// <summary>
        /// 默认页号10
        /// </summary>
        private int _pageSize = 10;
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; } = 0;
        /// <summary>
        /// 页号（最大值默认100笔数据）
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        /// <summary>
        /// 排序字段 （实体的实际字段名（若与数据库中不同请与后端沟通））
        /// </summary>
        public string OrderBy { get; set; } = "Id";
        /// <summary>
        /// RESTful三级保留字段（暂未开发此功能）
        /// </summary>
        public string Fields { get; set; }
        /// <summary>
        /// 最大页号
        /// </summary>
        protected int MaxPageSize { get; set; } = 100;
    }
}