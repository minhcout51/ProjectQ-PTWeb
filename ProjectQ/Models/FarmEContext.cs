
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjectQ.Models
{
    public partial class FarmEContext : DbContext
    {
        public FarmEContext()
        {
        }

        public FarmEContext(DbContextOptions<FarmEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DiaChiCuaHang> DiaChiCuaHangs { get; set; }
        public virtual DbSet<DiaChiGiaoHang> DiaChiGiaoHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<ThongTinDonHang> ThongTinDonHangs { get; set; }
        public virtual DbSet<ThongTinSanPham> ThongTinSanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=NgocMinh\\SQLEXPRESS;user ID=sa;password=1;database=FarmE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Ten);

                entity.ToTable("Category");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<DiaChiCuaHang>(entity =>
            {
                entity.ToTable("DiaChiCuaHang");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Duong).HasMaxLength(50);

                entity.Property(e => e.Huyen).HasMaxLength(50);

                entity.Property(e => e.Phuong).HasMaxLength(50);

                entity.Property(e => e.Quan).HasMaxLength(50);

                entity.Property(e => e.ThanhPho).HasMaxLength(50);

                entity.Property(e => e.Xa).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.DiaChiCuaHang)
                    .HasForeignKey<DiaChiCuaHang>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiaChiCuaHang_DiaChiGiaoHang");
            });

            modelBuilder.Entity<DiaChiGiaoHang>(entity =>
            {
                entity.ToTable("DiaChiGiaoHang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duong).HasMaxLength(50);

                entity.Property(e => e.Huyen).HasMaxLength(50);

                entity.Property(e => e.Phuong).HasMaxLength(50);

                entity.Property(e => e.Quan).HasMaxLength(50);

                entity.Property(e => e.ThanhPho).HasMaxLength(50);

                entity.Property(e => e.Xa).HasMaxLength(50);
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoVaTen).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CongViec).HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.HoVaTen).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TrangThai).HasMaxLength(50);
            });

            modelBuilder.Entity<ThongTinDonHang>(entity =>
            {
                entity.ToTable("ThongTinDonHang");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DiaChiCuaHang).HasMaxLength(50);

                entity.Property(e => e.IdSanPham).HasColumnName("idSanPham");

                entity.Property(e => e.LoaiSanPham).HasMaxLength(50);

                entity.Property(e => e.TenKhachHang).HasMaxLength(50);

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ThongTinDonHang)
                    .HasForeignKey<ThongTinDonHang>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThongTinDonHang_DiaChiCuaHang");

                entity.HasOne(d => d.LoaiSanPhamNavigation)
                    .WithMany(p => p.ThongTinDonHangs)
                    .HasForeignKey(d => d.LoaiSanPham)
                    .HasConstraintName("FK_ThongTinDonHang_Category");
            });

            modelBuilder.Entity<ThongTinSanPham>(entity =>
            {
                entity.ToTable("ThongTinSanPham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LoaiSanPham).HasMaxLength(50);

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasMaxLength(50);
                entity.Property(e => e.HinhAnh).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
