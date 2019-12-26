using System;
using System.Collections.Generic;
using FreeSql;
using System.Text;
using EasyCore.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyCore.FreeSql.SimpleUseFreeSql
{
    public class BaseRepository<T, TKey> : IBaseRepository<T>, IRepositoryKey where T : EntityBase<TKey>
    {
        private BaseRepository<T> _baseRep;
        public BaseRepository(IServiceProvider service)
        {
            _baseRep = service.GetRequiredService<IFreeSql>().GetRepository<T>();
            _baseRep.UnitOfWork = service.GetRequiredService<IRepositoryUnitOfWork>();
        }

        public IUpdate<T> UpdateDiy => _baseRep.UpdateDiy;

        public IDataFilter<T> DataFilter => _baseRep.DataFilter;

        public ISelect<T> Select => _baseRep.Select;

        public Type EntityType => _baseRep.EntityType;

        public IUnitOfWork UnitOfWork { get; set; }

        public IFreeSql Orm => _baseRep.Orm;

        public DbContextOptions DbContextOptions { get => _baseRep.DbContextOptions; set => _baseRep.DbContextOptions = value; }

        public void AsType(Type entityType) => _baseRep.AsType(entityType);

        public void Attach(T entity) => _baseRep.Attach(entity);

        public void Attach(IEnumerable<T> entity) => _baseRep.Attach(entity);

        public IBasicRepository<T> AttachOnlyPrimary(T data) => _baseRep.AttachOnlyPrimary(data);

        public int Delete(Expression<Func<T, bool>> predicate) => _baseRep.Delete(predicate);

        public int Delete(T entity)
        {
            return _baseRep.Delete(entity);
        }

        public int Delete(IEnumerable<T> entitys)
        {
            return _baseRep.Delete(entitys);
        }

        public Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return _baseRep.DeleteAsync(predicate);
        }

        public Task<int> DeleteAsync(T entity)
        {
            return _baseRep.DeleteAsync(entity);
        }

        public Task<int> DeleteAsync(IEnumerable<T> entitys)
        {
            return _baseRep.DeleteAsync(entitys);
        }

        public void Dispose()
        {
            _baseRep.Dispose();
        }

        public void FlushState()
        {
            _baseRep.FlushState();
        }

        public T Insert(T entity)
        {
            return _baseRep.Insert(entity);
        }

        public List<T> Insert(IEnumerable<T> entitys)
        {
            return _baseRep.Insert(entitys);
        }

        public Task<T> InsertAsync(T entity)
        {
            return _baseRep.InsertAsync(entity);
        }

        public Task<List<T>> InsertAsync(IEnumerable<T> entitys)
        {
            return _baseRep.InsertAsync(entitys);
        }

        public T InsertOrUpdate(T entity)
        {
            return _baseRep.InsertOrUpdate(entity);
        }

        public Task<T> InsertOrUpdateAsync(T entity)
        {
            return _baseRep.InsertOrUpdateAsync(entity);
        }

        public void SaveMany(T entity, string propertyName)
        {
            _baseRep.SaveMany(entity, propertyName);
        }

        public Task SaveManyAsync(T entity, string propertyName)
        {
            return _baseRep.SaveManyAsync(entity, propertyName);
        }

        public int Update(T entity)
        {
            return _baseRep.Update(entity);
        }

        public int Update(IEnumerable<T> entitys)
        {
            return _baseRep.Update(entitys);
        }

        public Task<int> UpdateAsync(T entity)
        {
            return _baseRep.UpdateAsync(entity);
        }

        public Task<int> UpdateAsync(IEnumerable<T> entitys)
        {
            return _baseRep.UpdateAsync(entitys);
        }

        public ISelect<T> Where(Expression<Func<T, bool>> exp)
        {
            return _baseRep.Where(exp);
        }

        public ISelect<T> WhereIf(bool condition, Expression<Func<T, bool>> exp)
        {
            return _baseRep.WhereIf(condition, exp);
        }
    }
}
