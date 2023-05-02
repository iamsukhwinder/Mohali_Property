using Mohali_Property_Model;
using Microsoft.EntityFrameworkCore;

namespace Mohali_Property_API.Modal
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<LoginVM> LoginVMs { get; set; }
        
        public DbSet<Company_profile> Company_profiles { get; set; }
        public DbSet<Company_profileVM> Company_profileVMs { get; set; }
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModel>().ToTable("Login");
            modelBuilder.Entity<LoginVM>().HasNoKey();
            
            modelBuilder.Entity<Company_profile>().ToTable("company_profile ");
            modelBuilder.Entity<Company_profileVM>().HasNoKey();

			

		}
    }
}
