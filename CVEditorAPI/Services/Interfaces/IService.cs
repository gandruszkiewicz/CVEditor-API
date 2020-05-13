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

        IEnumerable<TEntity> GetAll(params object[] keyValues);

        TEntity Get(params object[] keyValues);

        Task<int> CreateAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
