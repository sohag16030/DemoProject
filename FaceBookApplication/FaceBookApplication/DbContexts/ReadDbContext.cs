using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FaceBookApplication.Models.Read;

#nullable disable

namespace FaceBookApplication.DbContexts
{
    public partial class ReadDbContext : DbContext
    {
        public ReadDbContext()
        {
        }

        public ReadDbContext(DbContextOptions<ReadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEndUser> TblEndUser { get; set; }
        public virtual DbSet<TblEndUserType> TblEndUserType { get; set; }
        public virtual DbSet<TblPost> TblPost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q0CV5UU;Database=SocialMediaDB;Trusted_Connection=True;MultipleActiveResultSets=true;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblEndUser>(entity =>
            {
                entity.HasKey(e => e.IntEndUserId);

                entity.ToTable("tblEndUser");

                entity.Property(e => e.IntEndUserId).HasColumnName("intEndUserId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntEndUserRoleId).HasColumnName("intEndUserRoleId");

                entity.Property(e => e.StrEndUserConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserConfirmPassword");

                entity.Property(e => e.StrEndUserGender)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserGender");

                entity.Property(e => e.StrEndUserName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserName");

                entity.Property(e => e.StrEndUserPassword)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserPassword");

                entity.Property(e => e.StrEndUserPhoneNo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserPhoneNo");

                entity.Property(e => e.StrEndUserRoleName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserRoleName");

                entity.HasOne(d => d.IntEndUserRole)
                    .WithMany(p => p.TblEndUser)
                    .HasForeignKey(d => d.IntEndUserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEndUser_tblEndUserType");
            });

            modelBuilder.Entity<TblEndUserType>(entity =>
            {
                entity.HasKey(e => e.IntEndUserRoleId)
                    .HasName("PK_tblEndUserType_1");

                entity.ToTable("tblEndUserType");

                entity.Property(e => e.IntEndUserRoleId).HasColumnName("intEndUserRoleId");

                entity.Property(e => e.StrEndUserRoleName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strEndUserRoleName");
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.HasKey(e => e.IntPostId);

                entity.ToTable("tblPost");

                entity.Property(e => e.IntPostId).HasColumnName("intPostId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("dteLastActionDateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtePostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePostDate");

                entity.Property(e => e.IntEndUserId).HasColumnName("intEndUserId");

                entity.Property(e => e.StrPostDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("strPostDescription");

                entity.HasOne(d => d.IntEndUser)
                    .WithMany(p => p.TblPost)
                    .HasForeignKey(d => d.IntEndUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPost_tblEndUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
