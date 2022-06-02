using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolvaBot.Models
{
    public partial class SOLVABOTContext : DbContext
    {
        public SOLVABOTContext()
        {
        }

        public SOLVABOTContext(DbContextOptions<SOLVABOTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblComAddfiles> TblComAddfiles { get; set; }
        public virtual DbSet<TblComCategory> TblComCategory { get; set; }
        public virtual DbSet<TblComCompany> TblComCompany { get; set; }
        public virtual DbSet<TblComDtlcodes> TblComDtlcodes { get; set; }
        public virtual DbSet<TblComMenu> TblComMenu { get; set; }
        public virtual DbSet<TblComMenuDetail> TblComMenuDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data Source=121.78.112.116;Initial Catalog=SOLVABOT;User ID=solvatech;Password=solva17$$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblComAddfiles>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__TBL_COM_ADDFILES__06D7F1EF");

                entity.ToTable("TBL_COM_ADDFILES");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30)
                    .HasComment("채번코드");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(50)
                    .HasComment("회사코드");

                entity.Property(e => e.Pcode)
                   .HasColumnName("PCODE")
                   .HasMaxLength(50)
                   .HasComment("상세코드");

                entity.Property(e => e.Fext)
                    .HasColumnName("FEXT")
                    .HasMaxLength(200)
                    .HasComment("파일형식");

                entity.Property(e => e.Floc)
                    .HasColumnName("FLOC")
                    .HasMaxLength(500)
                    .HasComment("파일경로");

                entity.Property(e => e.Fn)
                    .HasColumnName("FN")
                    .HasMaxLength(300)
                    .HasComment("파일명");

                entity.Property(e => e.OriginFn)
                    .HasColumnName("ORIGINFN")
                    .HasMaxLength(300)
                    .HasComment("원래파일명");

                entity.Property(e => e.Fsize)
                    .HasColumnName("FSIZE")
                    .HasComment("파일사이즈");

                entity.Property(e => e.Role)
                    .HasColumnName("ROLE")
                    .HasComment("역할");

                entity.Property(e => e.Wdate)
                    .HasColumnName("WDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("등록일");
            });

            modelBuilder.Entity<TblComCategory>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("TBL_COM_CATEGORY");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(100);

                entity.Property(e => e.Wdate)
                    .HasColumnName("WDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblComCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyCode);

                entity.ToTable("TBL_COM_COMPANY");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.Wdate)
                    .HasColumnName("WDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblComDtlcodes>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__TBL_COM_DTLCODES__66603565");

                entity.ToTable("TBL_COM_DTLCODES");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("채번구분상수");

                entity.Property(e => e.Num)
                    .HasColumnName("NUM")
                    .HasComment("일련번호");

                entity.Property(e => e.Wdate)
                    .HasColumnName("WDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("등록일");

                entity.Property(e => e.Ymd)
                    .IsRequired()
                    .HasColumnName("YMD")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("년월일");
            });

            modelBuilder.Entity<TblComMenu>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("TBL_COM_MENU");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.CategoryCode)
                    .IsRequired()
                    .HasColumnName("CATEGORY_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(100);

                entity.Property(e => e.Wdate)
                    .HasColumnName("WDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblComMenuDetail>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("TBL_COM_MENU_DETAIL");

                entity.Property(e => e.Code)
                     .HasColumnName("CODE")
                     .HasMaxLength(30);

                entity.Property(e => e.Content).HasColumnName("CONTENT");

                entity.Property(e => e.MenuCode)
                    .IsRequired()
                    .HasColumnName("MENU_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(100);

                entity.Property(e => e.Wdate)
                    .HasColumnName("WDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.SubTitle)
                    .HasColumnName("SUBTITLE")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
