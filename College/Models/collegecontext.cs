using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace College.Models
{
    public class collegecontext :IdentityDbContext<IdentityUser>
    {

        //[2] step two
        public collegecontext() 
        { }
        // injection services need this constructor
        public collegecontext(DbContextOptions<collegecontext>options):base(options) 
        { }


        public DbSet<Instructore> Instructores { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CorsResult> CorsResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(@"server = DESKTOP-DR5LS6Q ;Initial catalog = Dbcolloge ;Integrated security = true ; Encrypt = True; Trust Server Certificate = True");
            
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          




            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();










            modelBuilder.Entity<Instructore>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructores)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructore>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Instructores)
                .HasForeignKey(i => i.CrsId) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CorsResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CorsResults)
                .HasForeignKey(cr => cr.TranId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CorsResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CorsResults)
                .HasForeignKey(cr => cr.CrsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    }


