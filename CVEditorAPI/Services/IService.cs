using CVEditorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public interface IService<T> where T: IEntity
    {
    }
}
