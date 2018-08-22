using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagement.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        //custom property
        public string StaffId { get; set; }
        public string Name { get; set; }
        public string OtherEmail { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        //foreignkey
        public virtual List<ApplicationUserRole> Roles { get; set; } = new List<ApplicationUserRole>();
    }
}
