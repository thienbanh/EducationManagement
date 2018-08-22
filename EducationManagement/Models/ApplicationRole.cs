using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EducationManagement.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        //custom property
        public string DefaultPage { get; set; }
        public virtual List<ApplicationUserRole> Users { get; set; } = new List<ApplicationUserRole>();
    }
}
