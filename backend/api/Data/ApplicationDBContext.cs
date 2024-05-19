using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using api.DTO.Account;


namespace api.Data
{
    public class ApplicationDBContext: IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions){}
        public DbSet<AdministratorAccount> AdministratorAccounts { get; set; }
        public DbSet<AdvisorAccount> AdvisorAccounts { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<LecturerAccount> LecturerAccounts { get; set; }
        public DbSet<University> Universities{ get; set; }
        public DbSet<Faculty> Faculties{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseExplanation> CourseExplanations { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            List<IdentityRole> roles = [
                new IdentityRole{
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole{
                    Name = "Lecturer",
                    NormalizedName = "LECTURER"
                },
                new IdentityRole{
                    Name = "Advisor",
                    NormalizedName = "ADVISOR"
                },
                new IdentityRole{
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            ];
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.User)
                .WithOne(ua => ua.UserAccount)
                .HasForeignKey<UserAccount>(ua => ua.UserId)
                .IsRequired();

            modelBuilder.Entity<UserAccount>().UseTpcMappingStrategy();

            modelBuilder.Entity<University>()
                .HasOne(u => u.Rector)
                .WithOne(uni => uni.University)
                .HasForeignKey<University>(uni => uni.RectorId)
                .IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}