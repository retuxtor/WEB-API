using Microsoft.EntityFrameworkCore;

namespace PresentationService.Models
{
    public class PresentationContext : DbContext
    {
        public PresentationContext(DbContextOptions<PresentationContext> options) : base(options)
        {
        }

        public DbSet<Presentation> Presentation { get; set; }
        public DbSet<Visitors> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presentation>(p =>
            {
                p.ToTable("presentation");

                p.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                p.Property(e => e.Name)
                    .HasColumnName("name");

                p.Property(e => e.Time)
                    .HasColumnName("time");

                p.Property(e => e.Status)
                    .HasColumnName("status");

                p.Property(e => e.Description)
                    .HasColumnName("description");

                p.Property(e => e.QantityVisitors)
                    .HasColumnName("qantity_visitors");
            });

            modelBuilder.Entity<Visitors>(p =>
            {
                p.ToTable("visitors");

                p.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                p.Property(e => e.Name)
                    .HasColumnName("name");

                p.Property(e => e.DateOfBirth)
                    .HasColumnName("dateofbirth");

                p.Property(e => e.Gender)
                    .HasColumnName("gender");

                p.Property(e => e.PhoneNumber)
                    .HasColumnName("phonenumber");

                p.Property(e => e.Email)
                    .HasColumnName("email");
            });
        }
    }
}
