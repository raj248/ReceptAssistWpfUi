using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UiDesktopApp1.Models;

public partial class ZenexContext : DbContext
{
    public ZenexContext()
    {
    }

    public ZenexContext(DbContextOptions<ZenexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ComplainerRegistration> ComplainerRegistrations { get; set; }

    public virtual DbSet<ComplaintAllotment> ComplaintAllotments { get; set; }

    public virtual DbSet<ComplaintRegister> ComplaintRegisters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8T8G614\\SQLEXPRESS;Database=zenex;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMMENTS__3214EC0763153BDD");

            entity.ToTable("COMMENTS");

            entity.Property(e => e.CommentText)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("Comment_text");
            entity.Property(e => e.CommenterId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Commenter_id");
            entity.Property(e => e.ComplaintIdFk).HasColumnName("Complaint_id_fk");
            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Commenter).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CommenterId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__COMMENTS__Commen__656C112C");

            entity.HasOne(d => d.ComplaintIdFkNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ComplaintIdFk)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__COMMENTS__Compla__6477ECF3");
        });

        modelBuilder.Entity<ComplainerRegistration>(entity =>
        {
            entity.HasKey(e => e.ComplainerId).HasName("PK__COMPLAIN__B4C68B3A1BCECFC4");

            entity.ToTable("COMPLAINER_REGISTRATION");

            entity.Property(e => e.ComplainerId).HasColumnName("Complainer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Registration_datetime");
        });

        modelBuilder.Entity<ComplaintAllotment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMPLAIN__3214EC072A15542E");

            entity.ToTable("COMPLAINT_ALLOTMENT");

            entity.HasIndex(e => new { e.User, e.ComplaintIdFk }, "unq_Complaint").IsUnique();

            entity.Property(e => e.ComplaintIdFk).HasColumnName("Complaint_id_fk");
            entity.Property(e => e.Status)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ComplaintIdFkNavigation).WithMany(p => p.ComplaintAllotments)
                .HasForeignKey(d => d.ComplaintIdFk)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__COMPLAINT__Compl__6B24EA82");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.ComplaintAllotments)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__COMPLAINT___User__6A30C649");
        });

        modelBuilder.Entity<ComplaintRegister>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__COMPLAIN__03A69B9EA5257B85");

            entity.ToTable("COMPLAINT_REGISTER");

            entity.Property(e => e.ComplaintId).HasColumnName("Complaint_id");
            entity.Property(e => e.ComplainerIdFk).HasColumnName("Complainer_id_fk");
            entity.Property(e => e.ComplaintDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Complaint_datetime");
            entity.Property(e => e.ComplaintDetail)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("Complaint_detail");
            entity.Property(e => e.ComplaintTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Complaint_title");
            entity.Property(e => e.IsApprovedByAdmin)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Is_approved_by_admin");
            entity.Property(e => e.ProofImgFile)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Proof_img_file");

            entity.HasOne(d => d.ComplainerIdFkNavigation).WithMany(p => p.ComplaintRegisters)
                .HasForeignKey(d => d.ComplainerIdFk)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__COMPLAINT__Compl__619B8048");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__USERS__536C85E51EFA6001");

            entity.ToTable("USERS");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
