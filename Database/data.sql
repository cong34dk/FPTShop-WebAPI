USE master
DROP DATABASE IF EXISTS [BanDienThoai_NguyenDinhCong]
GO
-----Tạo database
CREATE DATABASE [BanDienThoai_NguyenDinhCong]
USE [BanDienThoai_NguyenDinhCong]
GO

CREATE TABLE [dbo].[CaiDats](
	[Id] [int] NOT NULL,
	[Logo] [nvarchar](max) NULL,
	[GioLamViec] [nvarchar](50) NULL,
	[GiaoHang] [nvarchar](50) NULL,
	[HoanTien] [nvarchar](50) NULL,
	[SDTLienHe] [nvarchar](50) NULL,
	[EmailLienHe] [nvarchar](50) NULL,
	[FaceBook] [nvarchar](max) NULL,
	[GooglePlus] [nvarchar](max) NULL,
	[Twiter] [nvarchar](max) NULL,
	[YouTube] [nvarchar](max) NULL,
	[Instargram] [nvarchar](max) NULL,
	[GoogleMap] [nvarchar](max) NULL,
	[MatKhauMail] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ChiTietHoaDonNhaps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NULL,
	[MaSanPham] [int] NULL,
	[SoLuong] [int] NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[TongTien] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ChiTietHoaDons](
	[MaChiTietHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NULL,
	[MaSanPham] [int] NULL,
	[SoLuong] [int] NULL,
	[TongGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_DetailBill] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ChiTietSanPhams](
	[MaChiTietSanPham] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NULL,
	[MaNhaSanXuat] [int] NULL,
	[MoTa] [nvarchar](350) NOT NULL,
	[ChiTiet] [nvarchar](max) NULL,
 CONSTRAINT [PK_DetailProducts] PRIMARY KEY CLUSTERED 
(
	[MaChiTietSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ChiTietTaiKhoans](
	[MaChitietTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MaTaiKhoan] [int] NULL,
	[HoTen] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](11) NULL,
	[AnhDaiDien] [nvarchar](500) NULL,
 CONSTRAINT [PK_InformationAccounts] PRIMARY KEY CLUSTERED 
(
	[MaChitietTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ChuyenMucs](
	[MaChuyenMuc] [int] IDENTITY(1,1) NOT NULL,
	[MaChuyenMucCha] [int] NULL,
	[TenChuyenMuc] [nvarchar](50) NULL,
	[DacBiet] [bit] NOT NULL,
	[NoiDung] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[MaChuyenMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[DKBanTins](
	[Id] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HangSanXuats](
	[MaHang] [int] IDENTITY(1,1) NOT NULL,
	[TenHang] [nvarchar](50) NULL,
	[LinkWeb] [nvarchar](max) NULL,
	[AnhDaiDien] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[HoaDonNhaps](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaNhaPhanPhoi] [int] NULL,
	[NgayTao] [datetime] NULL,
	[KieuThanhToan] [nvarchar](max) NULL,
	[MaTaiKhoan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[HoaDons](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[TrangThai] [bit] NULL,
	[NgayTao] [datetime] NULL,
	[NgayDuyet] [datetime] NULL,
	[TongGia] [decimal](18, 0) NULL,
	[TenKH] [nvarchar](50) NULL,
	[GioiTinh] [bit] NOT NULL,
	[Diachi] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[DiaChiGiaoHang] [nvarchar](350) NULL,
	[ThoiGianGiaoHang] [datetime] NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[KhachHangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SDT] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LoaiTaiKhoans](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[MoTa] [nvarchar](250) NULL,
 CONSTRAINT [PK_TypeAccounts] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NhaPhanPhois](
	[MaNhaPhanPhoi] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaPhanPhoi] [nvarchar](250) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaPhanPhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[QuangCaos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnhDaiDien] [nvarchar](max) NULL,
	[LinkQuangCao] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[SanPhams](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[MaChuyenMuc] [int] NULL,
	[TenSanPham] [nvarchar](150) NULL,
	[AnhDaiDien] [nvarchar](350) NULL,
	[Gia] [decimal](18, 0) NULL,
	[GiaGiam] [decimal](18, 0) NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [bit] NULL,
	[LuotXem] [int] NULL,
	[DacBiet] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SanPhams_NhaPhanPhois](
	[MaSanPham] [int] NOT NULL,
	[MaNhaPhanPhoi] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaPhanPhoi] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Slide](
	[MaAnh] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](250) NULL,
	[TieuDe1] [nvarchar](250) NULL,
	[TieuDe2] [nvarchar](250) NULL,
	[MoTa1] [nvarchar](250) NULL,
	[MoTa2] [nvarchar](250) NULL,
	[MoTa3] [nvarchar](250) NULL,
	[MoTa4] [nvarchar](250) NULL,
	[LinkAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[TaiKhoans](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTaiKhoan] [int] NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TinTucs](
	[MaTinTuc] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](250) NULL,
	[AnhDaiDien] [nvarchar](max) NULL,
	[MoTa] [nvarchar](250) NULL,
	[NgayTao] [datetime] NULL,
	[ChiTiet] [nvarchar](max) NULL,
	[LuotXem] [int] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[MaTinTuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[HoaDons] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SanPhams] ADD  DEFAULT ((0)) FOR [GiaGiam]
GO
ALTER TABLE [dbo].[SanPhams] ADD  DEFAULT ((0)) FOR [LuotXem]
GO
ALTER TABLE [dbo].[SanPhams] ADD  DEFAULT ((0)) FOR [DacBiet]
GO
ALTER TABLE [dbo].[TinTucs] ADD  CONSTRAINT [DF_TinTucs_LuotXem]  DEFAULT ((0)) FOR [LuotXem]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhaps]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonNhaps_HoaDonNhaps] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonNhaps] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhaps] CHECK CONSTRAINT [FK_ChiTietHoaDonNhaps_HoaDonNhaps]
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhaps]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonNhaps_SanPhams] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPhams] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhaps] CHECK CONSTRAINT [FK_ChiTietHoaDonNhaps_SanPhams]
GO
ALTER TABLE [dbo].[ChiTietHoaDons]  WITH CHECK ADD  CONSTRAINT [FK_DetailBill_Bills] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDons] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDons] CHECK CONSTRAINT [FK_DetailBill_Bills]
GO
ALTER TABLE [dbo].[ChiTietHoaDons]  WITH CHECK ADD  CONSTRAINT [FK_DetailBill_Products] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPhams] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDons] CHECK CONSTRAINT [FK_DetailBill_Products]
GO
ALTER TABLE [dbo].[ChiTietSanPhams]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSanPhams_NhaSanXuats] FOREIGN KEY([MaNhaSanXuat])
REFERENCES [dbo].[HangSanXuats] ([MaHang])
GO
ALTER TABLE [dbo].[ChiTietSanPhams] CHECK CONSTRAINT [FK_ChiTietSanPhams_NhaSanXuats]
GO
ALTER TABLE [dbo].[ChiTietSanPhams]  WITH CHECK ADD  CONSTRAINT [FK_DetailProducts_Products] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPhams] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietSanPhams] CHECK CONSTRAINT [FK_DetailProducts_Products]
GO
ALTER TABLE [dbo].[ChiTietTaiKhoans]  WITH CHECK ADD  CONSTRAINT [FK_InformationAccounts_Accounts] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoans] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[ChiTietTaiKhoans] CHECK CONSTRAINT [FK_InformationAccounts_Accounts]
GO
ALTER TABLE [dbo].[HoaDonNhaps]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhaps_NhaPhanPhois] FOREIGN KEY([MaNhaPhanPhoi])
REFERENCES [dbo].[NhaPhanPhois] ([MaNhaPhanPhoi])
GO
ALTER TABLE [dbo].[HoaDonNhaps] CHECK CONSTRAINT [FK_HoaDonNhaps_NhaPhanPhois]
GO
ALTER TABLE [dbo].[HoaDonNhaps]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhaps_TaiKhoans] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoans] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[HoaDonNhaps] CHECK CONSTRAINT [FK_HoaDonNhaps_TaiKhoans]
GO
ALTER TABLE [dbo].[SanPhams]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([MaChuyenMuc])
REFERENCES [dbo].[ChuyenMucs] ([MaChuyenMuc])
GO
ALTER TABLE [dbo].[SanPhams] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[SanPhams_NhaPhanPhois]  WITH CHECK ADD  CONSTRAINT [FK_SanPhams_NhaPhanPhois_NhaPhanPhois] FOREIGN KEY([MaNhaPhanPhoi])
REFERENCES [dbo].[NhaPhanPhois] ([MaNhaPhanPhoi])
GO
ALTER TABLE [dbo].[SanPhams_NhaPhanPhois] CHECK CONSTRAINT [FK_SanPhams_NhaPhanPhois_NhaPhanPhois]
GO
ALTER TABLE [dbo].[SanPhams_NhaPhanPhois]  WITH CHECK ADD  CONSTRAINT [FK_SanPhams_NhaPhanPhois_SanPhams] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPhams] ([MaSanPham])
GO
ALTER TABLE [dbo].[SanPhams_NhaPhanPhois] CHECK CONSTRAINT [FK_SanPhams_NhaPhanPhois_SanPhams]
GO
ALTER TABLE [dbo].[TaiKhoans]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_TypeAccounts] FOREIGN KEY([LoaiTaiKhoan])
REFERENCES [dbo].[LoaiTaiKhoans] ([MaLoai])
GO
ALTER TABLE [dbo].[TaiKhoans] CHECK CONSTRAINT [FK_Accounts_TypeAccounts]
GO

ALTER TABLE ChuyenMucs ADD Link nvarchar(max);

ALTER TABLE dbo.TaiKhoans
ADD CONSTRAINT UQ_TenTaiKhoan UNIQUE (TenTaiKhoan);


-----Insert data

----Insert table LoaiTaiKhoans
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoans] ON 

INSERT [dbo].[LoaiTaiKhoans] ([MaLoai], [TenLoai], [MoTa]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[LoaiTaiKhoans] ([MaLoai], [TenLoai], [MoTa]) VALUES (2, N'KhachHang', NULL)
INSERT [dbo].[LoaiTaiKhoans] ([MaLoai], [TenLoai], [MoTa]) VALUES (3, N'QuanLy', NULL)
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoans] OFF
GO

----Insert table TaiKhoans
SET IDENTITY_INSERT [dbo].[TaiKhoans] ON 
INSERT [dbo].[TaiKhoans] ([MaTaiKhoan], [LoaiTaiKhoan], [TenTaiKhoan], [MatKhau], [Email]) VALUES (1, 1, N'admin', N'123', N'bandienthoai@gmail.com')
INSERT [dbo].[TaiKhoans] ([MaTaiKhoan], [LoaiTaiKhoan], [TenTaiKhoan], [MatKhau], [Email]) VALUES (2, 1, N'cong', N'123', N'cong@gmail.com')
SET IDENTITY_INSERT [dbo].[TaiKhoans] OFF

GO

----Insert table HoaDons
INSERT INTO HoaDons (TrangThai, NgayTao, NgayDuyet, TongGia, TenKH, GioiTinh, Diachi, Email, SDT, DiaChiGiaoHang, ThoiGianGiaoHang)
VALUES (1, GETDATE(), GETDATE(), 1000, 'Nguyen Van A', 1, '123 Duong ABC, Quan XYZ', 'email1@example.com', '1234567890', 'DiaChi1', GETDATE());

INSERT INTO HoaDons (TrangThai, NgayTao, NgayDuyet, TongGia, TenKH, GioiTinh, Diachi, Email, SDT, DiaChiGiaoHang, ThoiGianGiaoHang)
VALUES (0, GETDATE(), NULL, 750, 'Nguyen Thi B', 0, '456 Duong XYZ, Quan ABC', 'email2@example.com', '9876543210', 'DiaChi2', NULL);

INSERT INTO HoaDons (TrangThai, NgayTao, NgayDuyet, TongGia, TenKH, GioiTinh, Diachi, Email, SDT, DiaChiGiaoHang, ThoiGianGiaoHang)
VALUES (1, GETDATE(), GETDATE(), 1200, 'Tran Van C', 1, '789 Duong DEF, Quan XYZ', 'email3@example.com', '1112223333', 'DiaChi3', GETDATE());

----Insert table SanPhams
INSERT INTO [dbo].[SanPhams] (MaChuyenMuc, TenSanPham, AnhDaiDien, Gia, GiaGiam, SoLuong, TrangThai, LuotXem, DacBiet)
VALUES
    (31, N'Điện thoại iPhone 12', N'iphone_12.png', 20000000, 19000000, 50, 1, 100, 0),
    (31, N'Điện thoại Samsung Galaxy S21', N'samsung_s21.png', 18000000, 17000000, 30, 1, 150, 1),
    (31, N'Điện thoại Xiaomi Mi 11', N'xiaomi_mi11.png', 15000000, 14000000, 40, 1, 200, 0);

----Insert table ChuyenMucs
INSERT INTO dbo.ChuyenMucs (MaChuyenMucCha, TenChuyenMuc, DacBiet, NoiDung, Link)
VALUES
    (1, N'Điện thoại', 0, N'./assets/img/category-container/phone.png', N'./iPhone14Pro.html'),
	(NULL, N'Laptop', 0, N'./assets/img/category-container/laptop.webp', N''),
	(NULL, N'PC - Lắp ráp', 0, N'./assets/img/category-container/pc.webp', N''),
	(NULL, N'Máy tính bảng', 0, N'./assets/img/category-container/mtb.webp', N''),
	(NULL, N'Thiết bị thông minh', 0, N'./assets/img/category-container/smart.webp', N''),
	(NULL, N'Gia dụng', 0, N'./assets/img/category-container/houseware.webp', N''),
	(NULL, N'Apple', 0, N'./assets/img/category-container/apple.webp', N''),
	(NULL, N'Samsung', 0, N'./assets/img/category-container/samsung.webp', N''),
	(NULL, N'Đồng hồ thông minh', 0, N'./assets/img/category-container/smartwatch.webp', N''),
	(NULL, N'Phụ kiện', 0, N'./assets/img/category-container/accessories.webp', N''),
	(NULL, N'Màn hình', 0, N'./assets/img/category-container/screen.webp', N''),
	(NULL, N'Máy cũ', 0, N'./assets/img/category-container/tcdm.webp', N'')

GO

----Insert table Slide
INSERT INTO [dbo].[Slide] (TieuDe, TieuDe1, TieuDe2, MoTa1, MoTa2, MoTa3, MoTa4, LinkAnh)
VALUES
(NULL, NULL, NULL, NULL, NULL, NULL, NULL, './assets/img/banner-left/1.webp'),
(NULL, NULL, NULL, NULL, NULL, NULL, NULL, './assets/img/banner-left/2.webp'),
(NULL, NULL, NULL, NULL, NULL, NULL, NULL, './assets/img/banner-left/3.webp'),
(NULL, NULL, NULL, NULL, NULL, NULL, NULL, './assets/img/banner-left/4.webp'),
(NULL, NULL, NULL, NULL, NULL, NULL, NULL, './assets/img/banner-left/5.webp')

GO

----Insert table QuangCaos
INSERT INTO [dbo].[QuangCaos] (AnhDaiDien, LinkQuangCao, MoTa)
VALUES
('./assets/img/banner-sale/laptop.webp', NULL, 'Laptop gaming H7')


select * from KhachHangs

select * from LoaiTaiKhoans

select * from TaiKhoans

select * from ChiTietTaiKhoans

select * from HoaDons

select * from ChiTietHoaDons

select * from SanPhams

select * from ChuyenMucs

select * from DKBanTins

select * from QuangCaos

select * from Slide

select * from TinTucs


DELETE FROM ChuyenMucs;
DELETE FROM Slide;

DELETE FROM SanPhams WHERE MaChuyenMuc IN (SELECT MaChuyenMuc FROM ChuyenMucs);
DELETE FROM QuangCaos;
