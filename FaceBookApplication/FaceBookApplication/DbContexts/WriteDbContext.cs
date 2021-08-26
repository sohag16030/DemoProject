using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FaceBookApplication.Models.Write;

#nullable disable

namespace FaceBookApplication.DbContexts
{
    public partial class WriteDbContext : DbContext
    {
        public WriteDbContext()
        {
        }

        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEndUser> TblEndUser { get; set; }
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
                entity.HasKey(e => e.EndUserId);

                entity.ToTable("tblEndUser");

                entity.Property(e => e.EndUserConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EndUserName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EndUserPassword)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EndUserRoleName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastActionDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblPost");

                entity.Property(e => e.LastActionDateTime).HasColumnType("datetime");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.PostDescription)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
