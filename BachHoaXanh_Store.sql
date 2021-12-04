create database BachHoaXanh_Store
use BachHoaXanh_Store
--drop database BachHoaXanh_Store

create table NhanVien
(
	Username char(30) not null,
	pPassword char(30),
	Permission int,--  1:Quản lí kho, 2:Cửa hàng trưởng, 3:Nhân viên 
	UserType nvarchar(30),-- Quản lí kho || Quản lí cửa hàng || Nhân viên bán hàng
	NameofUser nvarchar(30),
	constraint PK_NhanVien primary key (Username),
)

create table LoaiSP
(
	MaLoaiSP int IDENTITY(1,1),
	TenLoaiSP nvarchar(30),
	Isdeleted bit,
	constraint PK_LoaiSP primary key (MaLoaiSP)
)
create table NhaCungCap
(
	MaNCC int IDENTITY(1,1) not null,
	TenNCC nvarchar(100),
	DiaChi nvarchar(100),
	constraint PK_NhaCungCap primary key (MaNCC),
)


create table SanPham
(
	MaSP nvarchar(30) not null,
	TenSP nvarchar(30),
	MaLoaiSP int,
	MaNCC int,
	DVT nvarchar(20),
	GiaBan int,
	GiaVon int,
	SoLuong int,
	Isdeleted bit,
	constraint PK_SanPham primary key (MaSP),
	constraint FK_SanPham_NCC foreign key (MaNCC) references NhaCungCap(MaNCC),
	constraint FK_SanPham_LoaiSP foreign key (MaLoaiSP) references LoaiSP(MaLoaiSP)
)


create table HoaDonDatNCC
(
	MaHDDat int IDENTITY(1,1),
	MaNCC int,
	TongTien int,
	NgayDat date,
	TinhTrang int,
	Isdeleted bit,
	constraint PK_HoaDonDatNCC primary key (MaHDDat),
	constraint FK_HoaDonDatNCC_NhaCungCap foreign key (MaNCC) references NhaCungCap(MaNCC)
)

create table CTHoaDonDatNCC
(
	MaHDDat int,
	MaSP nvarchar(30),
	SoLuong int,
	ThanhTien int,
	constraint PK_CTHDD primary key (MaHDDat,MaSP),
	constraint FK_CTHHD_HDDat foreign key (MaHDDat) references HoaDonDatNCC(MaHDDat),
	constraint FK_CTHDD_SanPham foreign key (MaSP) references SanPham(MaSP)
)

create table SieuThi
(
	MaST int IDENTITY(1,1),
	TenST nvarchar (50),
	DiaChi nvarchar(50),
	SDT varchar(15),
	constraint PK_SieuThi primary key (MaST)
)

create table KhoSieuThi
(
	MaST int not null,
	MaSP nvarchar(30) not null, 
	SoLuong int,
	constraint PK_KhoSieuThi primary key (MaST,MaSP),
	constraint FK_KhoSieuThi_SieuThi foreign key (MaST) references SieuThi(MaST),
	constraint FK_KhoSieuThi_SanPham foreign key (MaSP) references SanPham(MaSP)
)

create table KhoHangKM
(
	MaST int not null,
	MaKhoKM nvarchar(30) not null,
	constraint PK_KhoHangKM primary key (MaKhoKM),
	constraint FK_KhoHangKM_SieuThi foreign key (MaST) references SieuThi(MaST)
)

create table CTKhoHangKM
(
	MaKhoKM nvarchar(30) not null, 
	MaSP nvarchar(30) not null,
	NgayKM date,
	NgayHetHan date,
	SoLuong int, 
	constraint PK_CTKhoKM primary key (MaKhoKM,MaSP),
	constraint FK_CTKhoKM_KhoHangKM foreign key (MaKhoKM) references KhoHangKM(MaKhoKM),
	constraint FK_CTKhoKM_SanPham foreign key (MaSP) references SanPham(MaSP)
)

create table DonDatHang
(
	MaDH int IDENTITY(1,1),
	MaST int,
	NguoiLapPhieu nvarchar (30),
	NgayDat date,
	TinhTrang int,
	TongTien int,
	Isdeleted bit,
	constraint PK_DonDatHang primary key (MaDH),
	constraint FK_DonDatHang_SieuThi foreign key (MaST) references SieuThi(MaST)
)


create table CTDonDatHang 
(
	MaCTDDH int IDENTITY(1,1),
	MaSP nvarchar(30),
	MaDH int,
	SoLuong int,
	ThanhTien int,
	constraint PK_CTDDH primary key (MaCTDDH,MaSP),
	constraint FK_CTDDH_SanPham foreign key (MaSP) references SanPham(MaSP),
	constraint FK_CTDDH_DonDatHang foreign key (MaDH) references DonDatHang(MaDH)
)

create table PhieuXuatKho
(
	MaPXK int IDENTITY(1,1) not null,
	MaST int,
	NguoiLapPhieu nvarchar (30),
	MaDH int,
	TongTien int,
	NgayXuat date,
	Isdeleted bit,
	constraint PK_PhieuXuatKho primary key (MaPXK),
	constraint FK_PhieuXuatKho_SieuThi foreign key (MaST) references SieuThi(MaST),
	constraint FK_PhieuXuatKho_DonDatHang foreign key (MaDH) references DonDatHang(MaDH)
)

create table CTPhieuXuatKho
(
	MaPXK int,
	MaSP nvarchar(30),
	SoLuong int,
	ThanhTien int,
	constraint PK_CTPhieuXuatKho primary key (MaPXK,MaSP),
	constraint FK_CTPhieuXuatKho_SanPham foreign key (MaSP) references SanPham(MaSP),
	constraint FK_CTPhieuXuatKho_PhieuXuatKho foreign key (MaPXK) references PhieuXuatKho(MaPXK)
)

create table PhieuTraHang
(
	MaPTH int IDENTITY (1,1),
	MaST int,
	NguoiLapPhieu nvarchar (30),
	NgayTra date,
	TongTien int,
	Isdeleted bit,
	TinhTrang int,
	constraint PK_PhieuTraHang primary key (MaPTH),
	constraint FK_PhieuTraHang_SieuThi foreign key(MaST) references SieuThi(MaST)
)

create table CTPhieuTraHang
(
	MaPTH int,
	MaSP nvarchar(30),
	SoLuong int,
	NgayHetHan date,
	constraint PK_CTPhieuTraHang primary key (MaPTH,MaSP),
	constraint FK_CTPhieuTraHang_PhieuTraHang foreign key (MaPTH) references PhieuTraHang(MaPTh),
	constraint FK_CTPhieuTraHang_SanPham foreign key (MaSP) references SanPham(MaSP)
)

Create table NhanVien
(
	UserId int IDENTITY (1,1) primary key,
	FullName nvarchar (30),
	UserName nvarchar (30),
	Pass nvarchar (30),
	StoreId int,
	Permisson nvarchar (30)
)


update SanPham
set Isdeleted = 'false'

update LoaiSP
set Isdeleted = 'false'