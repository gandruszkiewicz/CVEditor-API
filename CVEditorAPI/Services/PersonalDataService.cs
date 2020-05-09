using CVEditorAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public class PersonalDataService: Service<PersonalData>, IPersonalDataService
    { 
        public PersonalDataService(DataContext context): 
            base(context)
        {
           
        }
    }
    
}
