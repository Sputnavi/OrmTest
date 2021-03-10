using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrmTest
{
    public partial class OrmTestContext : DbContext
    {
        public OrmTestContext()
        {
        }

        public OrmTestContext(DbContextOptions<OrmTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OrmTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("Record");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
