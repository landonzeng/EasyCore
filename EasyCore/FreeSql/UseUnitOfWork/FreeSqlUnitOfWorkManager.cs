using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreeSql;

namespace EasyCore.FreeSql.UseUnitOfWork
{
    /// <summary>
    /// FreeSql工作单元管理器
    /// </summary>
    public class FreeSqlUnitOfWorkManager : IFreeSqlUnitOfWorkManager
    {
        /// <summary>
        /// 工作单元集合
        /// </summary>
        private readonly List<IUnitOfWork> _unitOfWorks;

        /// <summary>
        /// 初始化工作单元管理器
        /// </summary>
        public FreeSqlUnitOfWorkManager()
        {
            _unitOfWorks = new List<IUnitOfWork>();
        }
        //提交
        public void Commit()
        {
            foreach (var unitOfWork in _unitOfWorks)
                unitOfWork.Commit();
        }
        //异步提交
        public Task CommitAsync()
        {
            foreach (var unitOfWork in _unitOfWorks)
                unitOfWork.Commit();
            return Task.CompletedTask;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~FreeSqlUnitOfWorkManager()
        // {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释下行代码
            // GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork"></param>
        public void Register(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            else
            {
                if (_unitOfWorks.Contains(unitOfWork) == false)
                    _unitOfWorks.Add(unitOfWork);
            }
        }
    }
}
