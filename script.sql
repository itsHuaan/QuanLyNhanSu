USE [master]
GO
/****** Object:  Database [qlynhansu]    Script Date: 27-Nov-23 00:37:17 ******/
CREATE DATABASE [qlynhansu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'qlynhansu', SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'qlynhansu_log', SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [qlynhansu] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qlynhansu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qlynhansu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qlynhansu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qlynhansu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qlynhansu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qlynhansu] SET ARITHABORT OFF 
GO
ALTER DATABASE [qlynhansu] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [qlynhansu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qlynhansu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qlynhansu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qlynhansu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qlynhansu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qlynhansu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qlynhansu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qlynhansu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qlynhansu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [qlynhansu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qlynhansu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qlynhansu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qlynhansu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qlynhansu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qlynhansu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qlynhansu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qlynhansu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [qlynhansu] SET  MULTI_USER 
GO
ALTER DATABASE [qlynhansu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qlynhansu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qlynhansu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qlynhansu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [qlynhansu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [qlynhansu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [qlynhansu] SET QUERY_STORE = OFF
GO
USE [qlynhansu]
GO
/****** Object:  UserDefinedFunction [dbo].[TinhLuong]    Script Date: 27-Nov-23 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TinhLuong] (@MaNhanVien NVARCHAR(10), @Thang INT, @Nam INT)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @Luong DECIMAL(18, 2);

    SELECT @Luong = (
        NhanVien.HeSoLuong * 1500000 +
        ChamCong.SoNgayLamViec * 200000 * ChucVu.HeSoPhuCap
    ) - IIF(ChamCong.SoNgayLamViec < 20, (20 - ChamCong.SoNgayLamViec) * 500000, 0)
    FROM NhanVien
    INNER JOIN ChamCong ON NhanVien.MaNhanVien = ChamCong.MaNhanVien
    INNER JOIN ChucVu ON NhanVien.MaChucVu = ChucVu.MaChucVu
    WHERE NhanVien.MaNhanVien = @MaNhanVien AND ChamCong.Thang = @Thang AND ChamCong.Nam = @Nam;

    RETURN @Luong;
END;
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 27-Nov-23 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[MaChamCong] [nvarchar](10) NOT NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[Thang] [int] NULL,
	[Nam] [int] NULL,
	[SoNgayLamViec] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChamCong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 27-Nov-23 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [nvarchar](10) NOT NULL,
	[TenChucVu] [nvarchar](255) NOT NULL,
	[HeSoPhuCap] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 27-Nov-23 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[MaLuong] [nvarchar](10) NOT NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[Thang] [int] NULL,
	[Nam] [int] NULL,
	[Luong] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 27-Nov-23 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](255) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[QueQuan] [nvarchar](255) NULL,
	[MaPhong] [nvarchar](10) NULL,
	[MaChucVu] [nvarchar](10) NULL,
	[MatKhau] [nvarchar](255) NULL,
	[LoaiNguoiDung] [nvarchar](20) NULL,
	[HeSoLuong] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 27-Nov-23 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [nvarchar](10) NOT NULL,
	[TenPhong] [nvarchar](255) NOT NULL,
	[DiaChiPhong] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC15211', N'NV98742', 8, 2023, 26)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC19572', N'NV19264', 5, 2019, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC22610', N'NV19091', 2, 2020, 29)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC23949', N'NV19091', 11, 2023, 26)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC27984', N'NV92200', 12, 2023, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC30602', N'NV47574', 11, 2019, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC38930', N'NV75025', 6, 2014, 24)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC39126', N'NV19091', 12, 2023, 30)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC39854', N'NV19091', 7, 2019, 30)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC46087', N'NV15596', 5, 2019, 16)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC47192', N'NV92200', 3, 2023, 26)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC53386', N'NV92200', 4, 2022, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC57004', N'NV98742', 12, 2023, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC57939', N'NV48178', 11, 2023, 24)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC61174', N'NV52852', 12, 2023, 23)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC63028', N'NV48178', 12, 2023, 19)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC69591', N'NV28956', 8, 2023, 21)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC70493', N'NV47574', 6, 2023, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC71774', N'NV47574', 12, 2023, 19)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC73884', N'NV28956', 12, 2023, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC82534', N'NV98742', 11, 2023, 20)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC86758', N'NV98742', 10, 2023, 21)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC95808', N'NV75025', 12, 2022, 25)
INSERT [dbo].[ChamCong] ([MaChamCong], [MaNhanVien], [Thang], [Nam], [SoNgayLamViec]) VALUES (N'CC97051', N'NV47574', 7, 2023, 15)
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (N'CV13893', N'Chức vụ D', CAST(1.60 AS Decimal(5, 2)))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (N'CV51085', N'Chức vụ C', CAST(1.10 AS Decimal(5, 2)))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (N'CV58723', N'Chức vụ A', CAST(1.50 AS Decimal(5, 2)))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (N'CV74707', N'Chức vụ B', CAST(1.40 AS Decimal(5, 2)))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (N'CV81281', N'Chức vụ E', CAST(1.20 AS Decimal(5, 2)))
GO
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L15211', N'NV98742', 8, 2023, CAST(10650000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L19572', N'NV19264', 5, 2019, CAST(8800000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L22610', N'NV19091', 2, 2020, CAST(11550000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L23949', N'NV19091', 11, 2023, CAST(10650000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L27984', N'NV92200', 12, 2023, CAST(8850000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L30602', N'NV47574', 11, 2019, CAST(9400000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L38930', N'NV75025', 6, 2014, CAST(8820000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L39126', N'NV19091', 12, 2023, CAST(11850000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L39854', N'NV19091', 7, 2019, CAST(11850000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L46087', N'NV15596', 5, 2019, CAST(3770000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L47192', N'NV92200', 3, 2023, CAST(9090000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L48009', N'NV98742', 11, 2023, CAST(10650000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L53386', N'NV92200', 4, 2022, CAST(8850000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L57004', N'NV98742', 12, 2023, CAST(10350000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L57939', N'NV48178', 11, 2023, CAST(9330000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L61174', N'NV52852', 12, 2023, CAST(7160000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L63028', N'NV48178', 12, 2023, CAST(7230000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L69591', N'NV28956', 8, 2023, CAST(6990000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L70493', N'NV47574', 6, 2023, CAST(9400000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L73884', N'NV28956', 12, 2023, CAST(7950000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L86758', N'NV98742', 10, 2023, CAST(9150000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L95808', N'NV75025', 12, 2022, CAST(9100000.00 AS Decimal(10, 2)))
INSERT [dbo].[Luong] ([MaLuong], [MaNhanVien], [Thang], [Nam], [Luong]) VALUES (N'L97051', N'NV47574', 7, 2023, CAST(4100000.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV12227', N'Nguyễn Thị G', N'Nữ', CAST(N'2002-06-01' AS Date), N'23 Quế Võ', N'59823742', N'Bắc Ninh', N'P87000', N'CV58723', N'pass9', N'admin', CAST(1.50 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV15596', N'Lê Thị D', N'Nữ', CAST(N'1980-03-04' AS Date), N'78 Đường PQR', N'1112223333', N'Hải Phòng', N'P53344', N'CV51085', N'pass4', N'user', CAST(1.50 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV19091', N'Đỗ Quang H', N'Nam', CAST(N'2001-09-19' AS Date), N'29 Đường 427', N'0338836098', N'Hà Nội', N'P53451', N'CV58723', N'QHuan1909!', N'admin', CAST(1.90 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV19264', N'Hà Tiến H', N'Nam', CAST(N'2002-09-29' AS Date), N'518 Kim Ngưu', N'98319283', N'Hà Nội', N'P73116', N'CV74707', N'pass7', N'user', CAST(1.20 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV28956', N'Phạm Văn C', N'Nam', CAST(N'1985-08-14' AS Date), N'56 Đường LMN', N'9998887777', N'Hà Nam', N'P87000', N'CV81281', N'pass3', N'user', CAST(1.30 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV47574', N'Nguyễn Văn E', N'Nam', CAST(N'1999-12-31' AS Date), N'90 Đường STU', N'4444444444', N'Thanh Hóa', N'P23970', N'CV74707', N'pass5', N'admin', CAST(1.60 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV48178', N'Nguyễn Văn Đ', N'Nam', CAST(N'2002-07-17' AS Date), N'56 Kinh Môn', N'032834712', N'Hải Dương', N'P73116', N'CV13893', N'pass8', N'admin', CAST(1.10 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV52852', N'Trần Quang L', N'Nam', CAST(N'2002-12-03' AS Date), N'34 Nam Sách', N'4278365', N'Hải Dương', N'P53344', N'CV51085', N'pass8', N'user', CAST(1.40 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV70747', N'Trần Thị B', N'Nữ', CAST(N'1985-03-23' AS Date), N'34 Đường XYZ', N'5556667777', N'Nam Định', N'P53344', N'CV58723', N'pass2', N'user', CAST(1.10 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV75025', N'Nguyễn Ngô D', N'Nam', CAST(N'2000-03-05' AS Date), N'78 Hữu Lũng', N'43454654', N'Lạng Sơn', N'P87000', N'CV74707', N'pass7', N'admin', CAST(1.40 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV92200', N'Lê Thị Phương L', N'Nữ', CAST(N'2001-05-02' AS Date), N'27 Yên Định', N'0961754909', N'Thanh Hóa', N'P53451', N'CV81281', N'pass9', N'admin', CAST(1.90 AS Decimal(5, 2)))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [QueQuan], [MaPhong], [MaChucVu], [MatKhau], [LoaiNguoiDung], [HeSoLuong]) VALUES (N'NV98742', N'Nguyễn Văn A', N'Nam', CAST(N'1990-09-15' AS Date), N'12 Đường KLM', N'0123456789', N'Hà Nội', N'P53451', N'CV58723', N'pass1', N'admin', CAST(1.90 AS Decimal(5, 2)))
GO
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [DiaChiPhong], [SoDienThoai]) VALUES (N'P23970', N'Phòng B', N'Địa chỉ B', N'1234823')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [DiaChiPhong], [SoDienThoai]) VALUES (N'P53344', N'Phòng D', N'Địa chỉ D', N'7538478')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [DiaChiPhong], [SoDienThoai]) VALUES (N'P53451', N'Phòng A', N'Địa chỉ A', N'42353433')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [DiaChiPhong], [SoDienThoai]) VALUES (N'P73116', N'Phòng E', N'Địa chỉ E', N'5476236')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [DiaChiPhong], [SoDienThoai]) VALUES (N'P87000', N'Phòng C', N'Địa chỉ C', N'0949321')
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[Luong]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[ChucVu]  WITH CHECK ADD CHECK  (([HeSoPhuCap]>(1) AND [HeSoPhuCap]<(2)))
GO
USE [master]
GO
ALTER DATABASE [qlynhansu] SET  READ_WRITE 
GO
