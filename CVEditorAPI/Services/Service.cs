using CVEditorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public abstract class Service<T>: IService<T> where T: IEntity
    {
        public IDataContext _dataContext;

        public Service(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
    }
}
