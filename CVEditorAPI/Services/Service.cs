using CVEditorAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public abstract class Service<TEntity>: IService<TEntity> where TEntity: class
    {
        public readonly DataContext _dataContext;

        public readonly DbSet<TEntity> _set;

        public Service(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IQueryable<TEntity> Queryable()
        {
            return _set;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Queryable();
        }

        public TEntity Get(params object[] keyValues)
        {
            return this._dataContext.Find<TEntity>(keyValues);
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            _dataContext.Add<TEntity>(entity);

            return await _dataContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dataContext.Update<TEntity>(entity);
            _dataContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChangesAsync();
        }
    }
}
