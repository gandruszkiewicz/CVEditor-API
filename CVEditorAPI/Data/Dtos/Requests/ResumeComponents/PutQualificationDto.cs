using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Dtos.Requests.ResumeComponents
{
    public class PutQualificationDto: BaseRequestResumeComponentDto
    {
        public int Id { get; set; }

        public string SchoolName { get; set; }

        public string City { get; set; }

        public string AcademicDegree { get; set; }

        public string FieldOfStudy { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string Description { get; set; }
    }
}
