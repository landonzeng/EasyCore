using System;

namespace EasyCore.IEntity
{
    /// <summary>
    /// 基础实体
    /// </summary>
    public interface IEntityBase<TKey> : IDeleted
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey Id { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        Guid CompanyId { get; set; }
    }
}
