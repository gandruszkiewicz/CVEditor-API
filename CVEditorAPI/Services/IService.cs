using CVEditorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Queryable();

        IEnumerable<TEntity> GetAll();

        TEntity Get(params object[] keyValues);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
