using System;
using System.Collections.Generic;

namespace EasyCore.IEntity
{
    /// <summary>
    /// 树形结构接口
    /// </summary>
    /// <typeparam name="TSourse"></typeparam>
    public interface ITreeEntity<TSourse>
        where TSourse : IEntityBase<int>
    {
        /// <summary>
        /// ParentId
        /// </summary>
        Guid? ParentId { get; set; }
        /// <summary>
        /// AncestorIds
        /// </summary>
        string AncestorIds { get; set; }
        /// <summary>
        /// IsAbstract
        /// </summary>
        bool IsAbstract { get; set; }
        /// <summary>
        /// Level
        /// </summary>
        int Level { get; }
        /// <summary>
        /// Parent
        /// </summary>
        TSourse Parent { get; set; }
        /// <summary>
        /// Children
        /// </summary>
        ICollection<TSourse> Children { get; set; }
    }
}
