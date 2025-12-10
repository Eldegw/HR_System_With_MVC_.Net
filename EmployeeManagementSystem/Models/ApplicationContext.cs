using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext():base()
        {
            
        }

        public ApplicationContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=.;Initial Catalog=EmployeeManagementSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        public DbSet<Employee> Employees { get; set; }
      public  DbSet<Department> departments { get; set; }


    }
}
