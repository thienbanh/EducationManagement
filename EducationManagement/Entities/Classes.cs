using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagement.Entities
{
    public class Classes
    {
        [Key] //Set primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //Set id auto increa
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradesId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Grades Grades { get; set; }
        public virtual List<Students> Students { get; set; }
    }
}
