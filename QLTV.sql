USE [master]
GO
/****** Object:  Database [QLTV]    Script Date: 4/13/2025 9:56:01 AM ******/
CREATE DATABASE [QLTV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLTV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLTV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLTV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLTV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLTV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLTV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLTV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLTV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLTV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLTV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLTV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLTV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLTV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLTV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLTV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLTV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLTV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLTV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLTV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLTV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLTV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLTV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLTV] SET RECOVERY FULL 
GO
ALTER DATABASE [QLTV] SET  MULTI_USER 
GO
ALTER DATABASE [QLTV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLTV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLTV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLTV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLTV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLTV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLTV', N'ON'
GO
ALTER DATABASE [QLTV] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLTV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLTV]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[MaDG] [nvarchar](10) NOT NULL,
	[TenDG] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SoDienThoai] [varchar](10) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Quyen] [nvarchar](20) NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSach]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSach](
	[MaLoai] [nvarchar](10) NOT NULL,
	[TenLoaiSach] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSach] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuonTraSach]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuonTraSach](
	[MaPhieuMuon] [int] IDENTITY(1,1) NOT NULL,
	[MaDG] [nvarchar](10) NOT NULL,
	[MaSach] [nvarchar](10) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayTra] [date] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_MuonTraSach] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[SoDienThoai] [varchar](10) NULL,
	[MatKhau] [nvarchar](10) NOT NULL,
	[Quyen] [nvarchar](20) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MaXB] [nvarchar](10) NOT NULL,
	[NhaXuatBan] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDatSach]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDatSach](
	[MaPhieuDat] [int] IDENTITY(1,1) NOT NULL,
	[MaDG] [nvarchar](10) NOT NULL,
	[MaSach] [nvarchar](10) NOT NULL,
	[NgayDat] [date] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuDat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nvarchar](10) NOT NULL,
	[TenSach] [nvarchar](50) NOT NULL,
	[MaTacGia] [nvarchar](10) NOT NULL,
	[MaXB] [nvarchar](10) NOT NULL,
	[MaLoai] [nvarchar](10) NOT NULL,
	[SoTrang] [int] NOT NULL,
	[GiaBan] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 4/13/2025 9:56:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [nvarchar](10) NOT NULL,
	[TacGia] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg1', N'Quỳnh Như', N'Nữ', N'TPHCM', N'0867573530', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg2', N'Minh Thư', N'Nữ', N'Đồng Tháp', N'0465123879', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg3', N'Ngọc Hân', N'Nữ', N'Tây Ninh', N'0154632879', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg4', N'Hoàng Anh', N'Nam', N'Long An', N'0123456213', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg5', N'Quang Minh', N'Nam', N'An Giang', N'0134516234', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg6', N'Quốc Đạt', N'Nam', N'Vũng Tàu', N'0134678132', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg7', N'Hoàng Nhật', N'Nam', N'Nha Trang', N'0123456789', N'123', N'User')
INSERT [dbo].[DocGia] ([MaDG], [TenDG], [GioiTinh], [DiaChi], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'dg8', N'Tuệ Nghi', N'Nữ', N'TPHCM', N'0123456789', N'123', N'User')
GO
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoaiSach], [GhiChu]) VALUES (N'loai1', N'Văn học', N'khong')
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoaiSach], [GhiChu]) VALUES (N'loai2', N'Khoa học công nghệ', N'khong')
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoaiSach], [GhiChu]) VALUES (N'loai3', N'Tâm lý', N'khong')
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoaiSach], [GhiChu]) VALUES (N'loai4', N'Kinh tế', N'ko')
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoaiSach], [GhiChu]) VALUES (N'loai5', N'Ngôn ngữ', N'ko')
GO
SET IDENTITY_INSERT [dbo].[MuonTraSach] ON 

INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (1, N'dg2', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (2, N'dg3', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-30' AS Date), N'cu', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (3, N'dg1', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (4, N'dg2', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-18' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (5, N'dg2', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-05-14' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (7, N'dg3', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-08' AS Date), N'moi', N'Quá hạn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (9, N'dg3', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2026-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (10, N'dg1', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-17' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (11, N'dg1', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (12, N'dg1', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (13, N'dg1', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (14, N'dg1', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-17' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (15, N'dg2', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (16, N'dg2', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (17, N'dg1', N'sach2', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-17' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (18, N'dg2', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (23, N'dg4', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (24, N'dg4', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-16' AS Date), N'moi', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (25, N'dg4', N'sach1', CAST(N'2025-04-07' AS Date), CAST(N'2025-04-12' AS Date), N'moi', N'Đã trả')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (29, N'dg5', N'sach3', CAST(N'2025-04-08' AS Date), CAST(N'2025-04-12' AS Date), N'moi', N'Đã trả')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (30, N'dg2', N'sach4', CAST(N'2025-04-12' AS Date), CAST(N'2025-05-12' AS Date), N'Đặt online', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (31, N'dg3', N'sach4', CAST(N'2025-04-12' AS Date), CAST(N'2025-05-12' AS Date), N'Đặt online', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (32, N'dg3', N'sach6', CAST(N'2025-04-12' AS Date), CAST(N'2025-05-12' AS Date), N'Đặt online', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (33, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), CAST(N'2025-04-12' AS Date), N'Đặt online', N'Đã trả')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (34, N'dg1', N'sach6', CAST(N'2025-04-12' AS Date), CAST(N'2025-05-12' AS Date), N'Đặt online', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (35, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), CAST(N'2025-04-12' AS Date), N'Đặt online', N'Đã trả')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (36, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), CAST(N'2025-05-12' AS Date), N'Đặt online', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (37, N'dg5', N'sach1', CAST(N'2025-04-12' AS Date), CAST(N'2025-05-12' AS Date), N'Đặt online', N'Đang mượn')
INSERT [dbo].[MuonTraSach] ([MaPhieuMuon], [MaDG], [MaSach], [NgayMuon], [NgayTra], [GhiChu], [TrangThai]) VALUES (38, N'dg7', N'sach6', CAST(N'2025-04-12' AS Date), CAST(N'2025-04-13' AS Date), N'moi', N'Đang mượn')
SET IDENTITY_INSERT [dbo].[MuonTraSach] OFF
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'han', N'Ngọc Hân', N'0797449934', N'123', N'Admin')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'trang', N'Xuân Trang', N'0156478932', N'1234', N'Admin')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'qnhu', N'Quỳnh Như', N'867573530', N'123', N'Admin')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SoDienThoai], [MatKhau], [Quyen]) VALUES (N'thu', N'Minh Thư', N'345311266', N'123', N'Admin')
GO
INSERT [dbo].[NhaXuatBan] ([MaXB], [NhaXuatBan], [GhiChu]) VALUES (N'nxb1', N'Nhà xuất bản Văn học', N'Không có')
INSERT [dbo].[NhaXuatBan] ([MaXB], [NhaXuatBan], [GhiChu]) VALUES (N'nxb2', N'Nhà xuất bản Khoa học và Kỹ thuật', N'Không có')
INSERT [dbo].[NhaXuatBan] ([MaXB], [NhaXuatBan], [GhiChu]) VALUES (N'nxb3', N'Nhà xuất bản Trẻ', N'Không có')
INSERT [dbo].[NhaXuatBan] ([MaXB], [NhaXuatBan], [GhiChu]) VALUES (N'nxb4', N'Messy', N'Không có')
INSERT [dbo].[NhaXuatBan] ([MaXB], [NhaXuatBan], [GhiChu]) VALUES (N'nxb5', N'SBooks', N'Không có')
GO
SET IDENTITY_INSERT [dbo].[PhieuDatSach] ON 

INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (1, N'dg1', N'sach5', CAST(N'2025-04-12' AS Date), N'Từ chối')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (2, N'dg2', N'sach4', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (3, N'dg3', N'sach4', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (4, N'dg3', N'sach6', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (5, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (6, N'dg1', N'sach6', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (7, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), N'Từ chối')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (8, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (9, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), N'Từ chối')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (10, N'dg4', N'sach6', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (11, N'dg5', N'sach1', CAST(N'2025-04-12' AS Date), N'Từ chối')
INSERT [dbo].[PhieuDatSach] ([MaPhieuDat], [MaDG], [MaSach], [NgayDat], [TrangThai]) VALUES (12, N'dg5', N'sach1', CAST(N'2025-04-12' AS Date), N'Đã duyệt')
SET IDENTITY_INSERT [dbo].[PhieuDatSach] OFF
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach1', N'Lập trình cơ sở dữ liệu', N'tg2', N'nxb1', N'loai1', 100, 40000, 26)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach2', N'Dự báo trong kinh doanh', N'tg1', N'nxb1', N'loai2', 60, 20000, 22)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach3', N'Kiểm thử phân mềm', N'tg3', N'nxb4', N'loai3', 50, 10000, 50)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach4', N'Văn học', N'tg4', N'nxb5', N'loai4', 50, 10000, 20)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach5', N'Tiếng Anh', N'tg4', N'nxb4', N'loai3', 60, 20000, 10)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach6', N'Trí tuệ cảm xúc', N'tg3', N'nxb3', N'loai4', 100, 20000, 17)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaTacGia], [MaXB], [MaLoai], [SoTrang], [GiaBan], [SoLuong]) VALUES (N'sach7', N'Toán rời rạc', N'tg4', N'nxb1', N'loai2', 100, 20000, 0)
GO
INSERT [dbo].[TacGia] ([MaTacGia], [TacGia], [GhiChu]) VALUES (N'tg1', N'huy', N'khong')
INSERT [dbo].[TacGia] ([MaTacGia], [TacGia], [GhiChu]) VALUES (N'tg2', N'hong', N'khong')
INSERT [dbo].[TacGia] ([MaTacGia], [TacGia], [GhiChu]) VALUES (N'tg3', N'sang', N'khong')
INSERT [dbo].[TacGia] ([MaTacGia], [TacGia], [GhiChu]) VALUES (N'tg4', N'vy', N'khong')
GO
ALTER TABLE [dbo].[DocGia] ADD  DEFAULT ('User') FOR [Quyen]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ('Admin') FOR [Quyen]
GO
ALTER TABLE [dbo].[PhieuDatSach] ADD  DEFAULT (N'Chờ duyệt') FOR [TrangThai]
GO
ALTER TABLE [dbo].[MuonTraSach]  WITH CHECK ADD  CONSTRAINT [FK_MuonTraSach_DocGia] FOREIGN KEY([MaDG])
REFERENCES [dbo].[DocGia] ([MaDG])
GO
ALTER TABLE [dbo].[MuonTraSach] CHECK CONSTRAINT [FK_MuonTraSach_DocGia]
GO
ALTER TABLE [dbo].[MuonTraSach]  WITH CHECK ADD  CONSTRAINT [FK_MuonTraSach_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[MuonTraSach] CHECK CONSTRAINT [FK_MuonTraSach_Sach]
GO
ALTER TABLE [dbo].[PhieuDatSach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDat_DocGia] FOREIGN KEY([MaDG])
REFERENCES [dbo].[DocGia] ([MaDG])
GO
ALTER TABLE [dbo].[PhieuDatSach] CHECK CONSTRAINT [FK_PhieuDat_DocGia]
GO
ALTER TABLE [dbo].[PhieuDatSach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDat_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[PhieuDatSach] CHECK CONSTRAINT [FK_PhieuDat_Sach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_LoaiSach] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSach] ([MaLoai])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_LoaiSach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([MaXB])
REFERENCES [dbo].[NhaXuatBan] ([MaXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
USE [master]
GO
ALTER DATABASE [QLTV] SET  READ_WRITE 
GO

ALTER TABLE DocGia
ADD Email NVARCHAR(100);
UPDATE DocGia SET Email = '2254050047nhu@ou.edu.vn' WHERE MaDG = 'dg1';
UPDATE DocGia SET Email = '2254050066thu@ou.edu.vn' WHERE MaDG = 'dg2';
UPDATE DocGia SET Email = '2254050014han@ou.edu.vn' WHERE MaDG = 'dg3';
UPDATE DocGia SET Email = 'thu024511@gmail.com' WHERE MaDG = 'dg4';
UPDATE DocGia SET Email = 'tranthiminhthu120504@gmail.com' WHERE MaDG = 'dg5';
UPDATE DocGia SET Email = 'jsbajcjnbcajk@gmail.com' WHERE MaDG = 'dg6';
UPDATE DocGia SET Email = 'fbuwsgsbciu3718@gmail.com' WHERE MaDG = 'dg7';
UPDATE DocGia SET Email = 'dhab193747@gmail.com' WHERE MaDG = 'dg8';