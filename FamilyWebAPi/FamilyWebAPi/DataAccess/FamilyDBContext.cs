using DNPAssigment1.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyWebAPi.DataAccess
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Families.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChildInterest>()
                .HasKey(sc =>
                    new
                    {
                        sc.InterestId,
                        sc.ChildId
                    }
                );
            modelBuilder.Entity<ChildInterest>()
                .HasOne(childInterest => childInterest.Interest)
                .WithMany(course => course.ChildInterests)
                .HasForeignKey(childInterest => childInterest.InterestId);

            modelBuilder.Entity<ChildInterest>()
                .HasOne(childInterest => childInterest.Child)
                .WithMany(child => child.ChildInterests)
                .HasForeignKey(childInterest => childInterest.ChildId);
        }
    }
}