using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreeSql;
using Util.Dependency;

namespace EasyCore.FreeSql.UseUnitOfWork.IRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public interface IRepositoryBase<TEntity, TContext> : IBaseRepository<TEntity>, IScopeDependency
    where TEntity : class
    {
        #region Uow CUD操作拓展

        /// <summary>
        /// 插入异步 单体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UowInsertAsync<T>(T entity) where T : class;
        /// <summary>
        /// 插入同步 单体 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UowInsert<T>(T entity) where T : class;
        /// <summary>
        /// 插入 异步 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<int> UowInsertAsync<T>(IEnumerable<T> entitys) where T : class;
        /// <summary>
        /// 插入 同步 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        int UowInsert<T>(IEnumerable<T> entitys) where T : class;
        /// <summary>
        /// 删除单体异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UowDeleteAsync<T>(T entity) where T : class;
        /// <summary>
        /// 删除 同步 单体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UowDelete<T>(T entity) where T : class;
        /// <summary>
        /// 删除 异步 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<int> UowDeleteAsync<T>(IEnumerable<T> entitys) where T : class;
        /// <summary>
        /// 删除同步 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        int UowDelete<T>(IEnumerable<T> entitys) where T : class;

        /// <summary>
        /// 更新 集合 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<int> UowUpdateAsync<T>(IEnumerable<T> entitys) where T : class;
        /// <summary>
        /// 更新 异步 单体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UowUpdateAsync<T>(T entity) where T : class;
        /// <summary>
        /// 更新 同步 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        int UowUpdate<T>(IEnumerable<T> entitys) where T : class;
        /// <summary>
        /// 更新 同步 单体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UowUpdate<T>(T entity) where T : class;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEnumerable<TEntity> SelectDbOrMemory(Expression<Func<TEntity, bool>> condition = null);
    }
}
