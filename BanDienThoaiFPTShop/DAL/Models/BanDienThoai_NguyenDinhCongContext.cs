using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class BanDienThoai_NguyenDinhCongContext : DbContext
    {
        public BanDienThoai_NguyenDinhCongContext()
        {
        }

        public BanDienThoai_NguyenDinhCongContext(DbContextOptions<BanDienThoai_NguyenDinhCongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaiDat> CaiDats { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; } = null!;
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; } = null!;
        public virtual DbSet<ChiTietTaiKhoan> ChiTietTaiKhoans { get; set; } = null!;
        public virtual DbSet<ChuyenMuc> ChuyenMucs { get; set; } = null!;
        public virtual DbSet<DkbanTin> DkbanTins { get; set; } = null!;
        public virtual DbSet<HangSanXuat> HangSanXuats { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; } = null!;
        public virtual DbSet<NhaPhanPhoi> NhaPhanPhois { get; set; } = null!;
        public virtual DbSet<QuanTri> QuanTris { get; set; } = null!;
        public virtual DbSet<QuangCao> QuangCaos { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<Slide> Slides { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<TinTuc> TinTucs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-BUMQSK20\\SQLEXPRESS;Database=BanDienThoai_NguyenDinhCong;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaiDat>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailLienHe).HasMaxLength(50);

                entity.Property(e => e.GiaoHang).HasMaxLength(50);

                entity.Property(e => e.GioLamViec).HasMaxLength(50);

                entity.Property(e => e.HoanTien).HasMaxLength(50);

                entity.Property(e => e.MatKhauMail).HasMaxLength(50);

                entity.Property(e => e.SdtlienHe)
                    .HasMaxLength(50)
                    .HasColumnName("SDTLienHe");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => e.MaChiTietHoaDon)
                    .HasName("PK_DetailBill");

                entity.Property(e => e.TongGia).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaHoaDon)
                    .HasConstraintName("FK_DetailBill_Bills");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_DetailBill_Products");
            });

            modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
            {
                entity.Property(e => e.DonViTinh).HasMaxLength(50);

                entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaHoaDon)
                    .HasConstraintName("FK_ChiTietHoaDonNhaps_HoaDonNhaps");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_ChiTietHoaDonNhaps_SanPhams");
            });

            modelBuilder.Entity<ChiTietSanPham>(entity =>
            {
                entity.HasKey(e => e.MaChiTietSanPham)
                    .HasName("PK_DetailProducts");

                entity.Property(e => e.MoTa).HasMaxLength(350);

                entity.HasOne(d => d.MaNhaSanXuatNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaNhaSanXuat)
                    .HasConstraintName("FK_ChiTietSanPhams_NhaSanXuats");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_DetailProducts_Products");
            });

            modelBuilder.Entity<ChiTietTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaChitietTaiKhoan)
                    .HasName("PK_InformationAccounts");

                entity.Property(e => e.AnhDaiDien).HasMaxLength(500);

                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.SoDienThoai).HasMaxLength(11);

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.ChiTietTaiKhoans)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .HasConstraintName("FK_InformationAccounts_Accounts");
            });

            modelBuilder.Entity<ChuyenMuc>(entity =>
            {
                entity.HasKey(e => e.MaChuyenMuc)
                    .HasName("PK_Categories");

                entity.Property(e => e.TenChuyenMuc).HasMaxLength(50);
            });

            modelBuilder.Entity<DkbanTin>(entity =>
            {
                entity.ToTable("DKBanTins");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<HangSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaHang)
                    .HasName("PK__HangSanX__19C0DB1D3605F819");

                entity.Property(e => e.TenHang).HasMaxLength(50);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK_Bills");

                entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(350);

                entity.Property(e => e.Diachi).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NgayDuyet).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");

                entity.Property(e => e.ThoiGianGiaoHang).HasColumnType("datetime");

                entity.Property(e => e.TongGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDonNh__835ED13B78056CF4");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhaPhanPhoiNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNhaPhanPhoi)
                    .HasConstraintName("FK_HoaDonNhaps_NhaPhanPhois");

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .HasConstraintName("FK_HoaDonNhaps_TaiKhoans");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<LoaiTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK_TypeAccounts");

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaPhanPhoi>(entity =>
            {
                entity.HasKey(e => e.MaNhaPhanPhoi)
                    .HasName("PK__NhaPhanP__794D666300510EE5");

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.SoDienThoai).HasMaxLength(50);

                entity.Property(e => e.TenNhaPhanPhoi).HasMaxLength(250);

                entity.HasMany(d => d.MaSanPhams)
                    .WithMany(p => p.MaNhaPhanPhois)
                    .UsingEntity<Dictionary<string, object>>(
                        "SanPhamsNhaPhanPhoi",
                        l => l.HasOne<SanPham>().WithMany().HasForeignKey("MaSanPham").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SanPhams_NhaPhanPhois_SanPhams"),
                        r => r.HasOne<NhaPhanPhoi>().WithMany().HasForeignKey("MaNhaPhanPhoi").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SanPhams_NhaPhanPhois_NhaPhanPhois"),
                        j =>
                        {
                            j.HasKey("MaNhaPhanPhoi", "MaSanPham").HasName("PK__SanPhams__B6E11221F22BB2A5");

                            j.ToTable("SanPhams_NhaPhanPhois");
                        });
            });

            modelBuilder.Entity<QuanTri>(entity =>
            {
                entity.ToTable("QuanTri");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(250)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(30)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(150)
                    .HasColumnName("hoten");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(100)
                    .HasColumnName("matkhau");

                entity.Property(e => e.Taikhoan)
                    .HasMaxLength(100)
                    .HasColumnName("taikhoan");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK_Products");

                entity.Property(e => e.AnhDaiDien).HasMaxLength(350);

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GiaGiam)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LuotXem).HasDefaultValueSql("((0))");

                entity.Property(e => e.TenSanPham).HasMaxLength(150);

                entity.HasOne(d => d.MaChuyenMucNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaChuyenMuc)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.HasKey(e => e.MaAnh)
                    .HasName("PK__Slide__356240DF77F3F107");

                entity.ToTable("Slide");

                entity.Property(e => e.MoTa1).HasMaxLength(250);

                entity.Property(e => e.MoTa2).HasMaxLength(250);

                entity.Property(e => e.MoTa3).HasMaxLength(250);

                entity.Property(e => e.MoTa4).HasMaxLength(250);

                entity.Property(e => e.TieuDe).HasMaxLength(250);

                entity.Property(e => e.TieuDe1).HasMaxLength(250);

                entity.Property(e => e.TieuDe2).HasMaxLength(250);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoan)
                    .HasName("PK_Accounts");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.TenTaiKhoan).HasMaxLength(50);

                entity.HasOne(d => d.LoaiTaiKhoanNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.LoaiTaiKhoan)
                    .HasConstraintName("FK_Accounts_TypeAccounts");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.HasKey(e => e.MaTinTuc)
                    .HasName("PK_News");

                entity.Property(e => e.LuotXem).HasDefaultValueSql("((0))");

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TieuDe).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
