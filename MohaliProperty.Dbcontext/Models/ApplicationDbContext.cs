using Microsoft.EntityFrameworkCore;
using Mohali_Property_Model;
using MohaliProperty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MohaliProperty.Dbcontext.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<LoginVM> LoginVMs { get; set; }

        public DbSet<Company_profile> Company_profiles { get; set; }
        public DbSet<Company_profileVM> Company_profileVMs { get; set; }
        public DbSet<KothiModel> kothis { get; set; }
        public DbSet<TokenModel> tokens { get; set; }
        public DbSet<TokenVM> tokenVMs { get; set; }
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<UserModel> users { get; set; }
        public DbSet<UserVM> userVMs { get; set; }
        public DbSet<BookingModel> bookings { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModel>().ToTable("Login");
            modelBuilder.Entity<LoginVM>().HasNoKey();
            modelBuilder.Entity<Company_profile>().ToTable("company_profile ");
            modelBuilder.Entity<Company_profileVM>().HasNoKey();
            modelBuilder.Entity<KothiModel>().ToTable("Kothi");
            modelBuilder.Entity<TokenModel>().ToTable("Tokens");
            modelBuilder.Entity<TokenVM>().HasNoKey();
            modelBuilder.Entity<CustomerModel>().HasNoKey();
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity <UserVM>().HasNoKey();
            modelBuilder.Entity <BookingModel>().HasNoKey();



        }
    }
}