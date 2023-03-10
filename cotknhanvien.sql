USE [master]
GO
/****** Object:  Database [DoAnCoSo]    Script Date: 23/06/2022 9:37:57 SA ******/
CREATE DATABASE [DoAnCoSo]
 
GO
USE [DoAnCoSo]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHangHoa] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHangHoa] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaHangHoa] [int] NOT NULL,
	[MaPhieuNhap] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaNhap] [money] NOT NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaHangHoa] ASC,
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHangHoa] [int] IDENTITY(1,1) NOT NULL,
	[TenHangHoa] [nvarchar](50) NOT NULL,
	[MaThuongHieu] [int] NULL,
	[MaLoaiHang] [int] NULL,
	[SoLuongCon] [int] NULL,
	[GiaBan] [money] NULL,
	[MaKhuyenMai] [int] NULL,
	[AnhSanPham] [nvarchar](100) NULL,
 CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED 
(
	[MaHangHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[NgayBan] [smalldatetime] NULL,
	[TongTien] [money] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[GioiTinh] [nchar](10) NULL,
	[Email] [varchar](20) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKhuyenMai] [int] IDENTITY(1,1) NOT NULL,
	[PhanTramGiam] [int] NOT NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiHangHoa]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHangHoa](
	[MaLoaiHang] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoaiHangHoa] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[GioiTinh] [nchar](10) NOT NULL,
	[MaChucVu] [int] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhapHang]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapHang](
	[MaPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [smalldatetime] NULL,
	[MaNhanVien] [int] NOT NULL,
	[MaNCC] [int] NOT NULL,
 CONSTRAINT [PK_PhieuNhapHang] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoanKhachHang]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoanKhachHang](
	[Email] [varchar](20) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[TenHienThi] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoanKhachHang] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoanNhanVien]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoanNhanVien](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoanNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 23/06/2022 9:37:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaThuongHieu] [int] IDENTITY(1,1) NOT NULL,
	[TenThuongHieu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietHoaDon] ([MaHangHoa], [MaHoaDon], [SoLuong]) VALUES (2194, 13, 1)
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHangHoa], [MaHoaDon], [SoLuong]) VALUES (2194, 14, 1)
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHangHoa], [MaHoaDon], [SoLuong]) VALUES (2195, 14, 1)
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHangHoa], [MaHoaDon], [SoLuong]) VALUES (2196, 13, 1)
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (1, N'quản lí')
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (2, N'nhân viên')
GO
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HangHoa] ON 

GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2194, N'Android Tivi Casper 43 inch ', 8, 3, 10, 5990.0000, 1, N'Android Tivi Casper 43 inch 43FG5200.jpg')
GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2195, N'Smart Tivi Samsung Crystal UHD 4K 50 inch ', 9, 3, 10, 17890000.0000, 1, N'Smart Tivi Samsung Crystal UHD 4K 50 inch.jpg')
GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2196, N'Android Tivi TCL 4K 50 inch ', 8, 3, 10, 10990000.0000, 1, N'Android Tivi TCL 4K 50 inch 50P618.jpg')
GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2217, N'HP Gaming VICTUS 16 i7 11800H ', 1, 1, 10, 28499000.0000, 1, N'HP Gaming VICTUS 16 d0198TX i7 11800H.jpg')
GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2218, N'Gaming G5 i5 10500H', 4, 1, 10, 25990000.0000, 1, N'Gaming G5 i5 10500H.jpg')
GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2219, N'MSI Gaming GE66 Raider 11UG i7 11800H ', 4, 1, 10, 49720000.0000, 1, N'MSI Gaming GE66 Raider 11UG i7 11800H .jpg')
GO
INSERT [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaThuongHieu], [MaLoaiHang], [SoLuongCon], [GiaBan], [MaKhuyenMai], [AnhSanPham]) VALUES (2220, N'msi-gaming-gf63', 4, 1, 10, 20680000.0000, 1, N'msi-gaming-gf63.jpg')
GO
SET IDENTITY_INSERT [dbo].[HangHoa] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayBan], [TongTien]) VALUES (13, 1, CAST(N'2022-06-13 22:15:00' AS SmallDateTime), 10995990.0000)
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [NgayBan], [TongTien]) VALUES (14, 1, CAST(N'2022-06-17 05:08:00' AS SmallDateTime), 17895990.0000)
GO
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [Email]) VALUES (1, N'KhachHang', N'Nu        ', N'admin')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [Email]) VALUES (3, N'haonek', N'hehe      ', N'hao')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [Email]) VALUES (4, N'tên', N'Nam       ', N'qhao74154@gmail.com')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [Email]) VALUES (5, N'1', N'2         ', N'haonek')
GO
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[KhuyenMai] ON 

GO
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [PhanTramGiam]) VALUES (1, 10)
GO
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [PhanTramGiam]) VALUES (2, 20)
GO
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [PhanTramGiam]) VALUES (3, 30)
GO
SET IDENTITY_INSERT [dbo].[KhuyenMai] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiHangHoa] ON 

GO
INSERT [dbo].[LoaiHangHoa] ([MaLoaiHang], [TenLoai]) VALUES (1, N'Laptop')
GO
INSERT [dbo].[LoaiHangHoa] ([MaLoaiHang], [TenLoai]) VALUES (2, N'Điện thoại')
GO
INSERT [dbo].[LoaiHangHoa] ([MaLoaiHang], [TenLoai]) VALUES (3, N'Tivi')
GO
SET IDENTITY_INSERT [dbo].[LoaiHangHoa] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [MaChucVu]) VALUES (2, N'trần văn a', N'nam       ', 1)
GO
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[TaiKhoanKhachHang] ([Email], [MatKhau], [TenHienThi]) VALUES (N'admin', N'admin', N'cxladmin')
GO
INSERT [dbo].[TaiKhoanKhachHang] ([Email], [MatKhau], [TenHienThi]) VALUES (N'hao', N'hao', NULL)
GO
INSERT [dbo].[TaiKhoanKhachHang] ([Email], [MatKhau], [TenHienThi]) VALUES (N'haonek', N'haonek', N'haoenk')
GO
INSERT [dbo].[TaiKhoanKhachHang] ([Email], [MatKhau], [TenHienThi]) VALUES (N'qhao1245@gmail.com', N'2', N'5')
GO
INSERT [dbo].[TaiKhoanKhachHang] ([Email], [MatKhau], [TenHienThi]) VALUES (N'qhao74154@gmail.com', N'123456', N'hehe')
GO
SET IDENTITY_INSERT [dbo].[TaiKhoanNhanVien] ON 

GO
INSERT [dbo].[TaiKhoanNhanVien] ([MaTaiKhoan], [MatKhau], [MaNhanVien]) VALUES (1, N'quanli', 2)
GO
SET IDENTITY_INSERT [dbo].[TaiKhoanNhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (1, N'HP')
GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (4, N'MSI')
GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (8, N'Android')
GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (9, N'Samsung')
GO
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HangHoa] FOREIGN KEY([MaHangHoa])
REFERENCES [dbo].[HangHoa] ([MaHangHoa])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_HangHoa] FOREIGN KEY([MaHangHoa])
REFERENCES [dbo].[HangHoa] ([MaHangHoa])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhapHang] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhapHang] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhapHang]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_KhuyenMai] FOREIGN KEY([MaKhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([MaKhuyenMai])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_KhuyenMai]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_LoaiHangHoa] FOREIGN KEY([MaLoaiHang])
REFERENCES [dbo].[LoaiHangHoa] ([MaLoaiHang])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_LoaiHangHoa]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_ThuongHieu] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_ThuongHieu]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_TaiKhoanKhachHang] FOREIGN KEY([Email])
REFERENCES [dbo].[TaiKhoanKhachHang] ([Email])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_TaiKhoanKhachHang]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[PhieuNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapHang_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhapHang] CHECK CONSTRAINT [FK_PhieuNhapHang_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapHang_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhapHang] CHECK CONSTRAINT [FK_PhieuNhapHang_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoanNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoanNhanVien_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoanNhanVien] CHECK CONSTRAINT [FK_TaiKhoanNhanVien_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [DoAnCoSo] SET  READ_WRITE 
GO
