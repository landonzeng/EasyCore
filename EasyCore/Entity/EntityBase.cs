using EasyCore.IEntity;
using FreeSql.DataAnnotations;
using System;
using System.ComponentModel;

namespace EasyCore.Entity
{
    /// <summary>
    /// 基础实体类
    /// </summary>
    public abstract class EntityBase<TKey> :IEntityBase<TKey>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Description("主键Id")]
        [Column(IsIdentity =true,IsPrimary =true)]
        public TKey Id { get; set; }
        /// <summary>
        /// 删除标识符
        /// </summary>
        [Description("删除标识符")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        public Guid CompanyId { get; set; }
    }
}
