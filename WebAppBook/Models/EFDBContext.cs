using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppBook.Models
{
    public partial class EFDBContext : DbContext
    {
        public EFDBContext()
        {
        }

        public EFDBContext(DbContextOptions<EFDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=EFDB;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOK");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("BOOK_ID");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .HasColumnName("AUTHOR");

                entity.Property(e => e.BookName)
                    .HasMaxLength(100)
                    .HasColumnName("BOOK_NAME");

                entity.Property(e => e.Price).HasColumnName("PRICE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
