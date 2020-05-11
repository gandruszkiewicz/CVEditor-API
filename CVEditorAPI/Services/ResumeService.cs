using CVEditorAPI.Data.Model;
using CVEditorAPI.Services.Interfaces;

namespace CVEditorAPI.Services
{
    public class ResumeService: Service<Resume>, IResumeService
    { 
        public ResumeService(DataContext context): 
            base(context)
        {
           
        }
    }
    
}
