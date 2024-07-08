using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LMS.Model.Models;

public partial class LmsContext : DbContext
{
    public LmsContext()
    {
    }

    public LmsContext(DbContextOptions<LmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookDetail> BookDetails { get; set; }

    public virtual DbSet<Borrowed> Borroweds { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Fine> Fines { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<MemberDetail> MemberDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KARTHIK\\LOCALHOST;Database=LMS;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookDeta__3214EC0712AAB7FA");

            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.BookId)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.PubYear).HasColumnType("date");
            entity.Property(e => e.Title).IsRequired();

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.BookDetails)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookDetai__Categ__2E1BDC42");
        });

        modelBuilder.Entity<Borrowed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Borrowed__3214EC07DFBCD573");

            entity.ToTable("Borrowed");

            entity.Property(e => e.BorrowedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.Book).WithMany(p => p.Borroweds)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Borrowed__BookId__300424B4");

            entity.HasOne(d => d.Member).WithMany(p => p.Borroweds)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Borrowed__Member__30F848ED");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0726BC1F89");

            entity.ToTable("Category");

            entity.Property(e => e.CatName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Fine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fine__3214EC07D0DA26C8");

            entity.ToTable("Fine");

            entity.Property(e => e.FineDate).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Fines)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fine__MemberId__31EC6D26");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libraria__3214EC07F1AE26B7");

            entity.ToTable("Librarian");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MemberDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberDe__3214EC07F242380C");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.JoinedDate).HasColumnType("date");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
