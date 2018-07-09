using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagement.Entities
{
    public class Grades
    {
        [Key] //Set primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //Set id auto increa
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual List<Classes> Classes { get; set; }
        public virtual List<CoursesGrades> CoursesGrades { get; set; }
    }
}
