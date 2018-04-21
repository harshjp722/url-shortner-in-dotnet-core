using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace URLShortnerDotnetCore.Models
{
    public partial class URLShortnerContext : DbContext
    {
        public virtual DbSet<ShortUrllog> ShortUrllog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=HPS;Database=URLShortnerDotnetCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortUrllog>(entity =>
            {
                entity.ToTable("ShortURLLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LongUrl)
                    .IsRequired()
                    .HasColumnName("LongURL");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
    }
}
