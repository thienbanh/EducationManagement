using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagement.Models
{
    public class ImportExcelModel
    {
        public string STT { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string ClassName { get; set; }
        public string GradeName { get; set; }
        public string Gender { get; set; }
    }
}
