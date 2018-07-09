using EducationManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationManagement.Repository
{
    public class EducationManagementContext : DbContext
    {
        public EducationManagementContext(DbContextOptions<EducationManagementContext> options)
            : base(options)
        { }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesGrades> CoursesGrades { get; set; }
    }
}
