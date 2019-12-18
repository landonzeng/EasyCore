namespace EasyCore.IEntity
{
    /// <summary>
    /// 删除标识
    /// </summary>
    public interface IDeleted
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        bool IsDeleted { get; set; }
    }
}