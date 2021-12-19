create database BachHoaXanh_Store
use BachHoaXanh_Store
--drop database BachHoaXanh_Store

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
	NguoiLapPhieu nvarchar (30),
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
	MaSP nvarchar(30) not null,
	NgayKM date,
	NgayHetHan date,
	SoLuong int,
	constraint PK_KhoHangKM primary key (MaST,MaSP),
	constraint FK_KhoHangKM_SieuThi foreign key (MaST) references SieuThi(MaST),
	constraint FK_KhoHangKM_SanPham foreign key (MaSP) references SanPham(MaSP)
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
	MaDH int not null,
	MaSP nvarchar(30) not null,
	SoLuong int,
	ThanhTien int,
	constraint PK_CTDDH primary key (MaDH,MaSP),
	constraint FK_CTDDH_SanPham foreign key (MaSP) references SanPham(MaSP),
	constraint FK_CTDDH_DonDatHang foreign key (MaDH) references DonDatHang(MaDH)
)

create table PhieuXuatKho
(
	MaPXK int IDENTITY(1,1) not null,
	MaDH int,
	MaST int,
	NguoiLapPhieu nvarchar (30),
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
	MaNCC int,
	NguoiLapPhieu nvarchar (30),
	NgayTra date,
	TongTien int,
	Isdeleted bit,
	TinhTrang int,
	constraint PK_PhieuTraHang primary key (MaPTH)
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
	MaNV int IDENTITY (1,1) primary key,
	HoTen nvarchar (30),
	TenDN nvarchar (30),
	MatKhau nvarchar (30),
	MaST int,
	Quyen int --  1:Quản lí kho, 2:Cửa hàng trưởng, 3:Nhân viên
)

Create Table HoaDonBanHang
(
	MaHD char(30) not null primary key,
	MaST int,
	MaNV int,
	NgayTao date,
	Isdeleted bit,
	TongSP int,
	ThanhTien int,
	Constraint FK_HoaDonBanHang_SieuThi foreign key (MaST) references SieuThi(MaST),
	Constraint FK_HoaDonBanHang_NhanVien foreign key (MaNV) references NhanVien(MaNV)
)

Create Table CTHoaDonBanHang
(
	MaHD char(30) not null,
	MaSP nvarchar(30) not null,
	SoLuong int,
	ThanhTien int,
	constraint PK_CTHoaDonBanHang primary key (MaHD,MaSP),
	Constraint FK_CTHoaDonBanHang_HoaDonBanHang foreign key (MaHD) references HoaDonBanHang(MaHD),
	constraint FK_CTHoaDonBanHang_SanPham foreign key (MaSP) references SanPham(MaSP)
)



update SanPham
set Isdeleted = 'false'

update LoaiSP
set Isdeleted = 'false'

update SanPham
set SoLuong = 50 where MaSP = '1012841000006'



select * from HoaDonDatNCC
select * from CTHoaDonDatNCC
select * from SanPham where SoLuong <= 10
select * from CTDonDatHang

select * from PhieuTraHang

select * from PhieuTraHang

select * from KhoSieuThi where MaST = 1 and MaSP = '9932979000030'
select * from SanPham Where MaSP = '1053156000001'
select * from SanPham Where MaSP = '1053156000002'
select * from HoaDonDatNCC
select * from NhanVien

update NhanVien
set TenDN = '090900' where MaNV = 3

select * from PhieuXuatKho
select * from CTPhieuXuatKho
select * from DonDatHang
select * from CTDonDatHang
SELECT * FROM KhoHangKM

select * from KhoSieuThi where MaSP = '9932848000036'