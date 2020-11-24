    using CVEditorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Queryable();

        public IEnumerable<TEntity> GetWhere(Func<TEntity, bool> condition);

        TEntity GetFirstOrDefault(Func<TEntity, bool> condiction);

        Task<int> CreateAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);
    }
}
