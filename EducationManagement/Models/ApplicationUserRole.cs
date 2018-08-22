using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EducationManagement.Models
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
