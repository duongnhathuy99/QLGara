Use Master
go
if Exists(select *From Sys.databases Where name='QLGara')
Drop database QLGara
go
create database QLGara
go
use QLGara
go
SET DATEFORMAT dmy;

go
create table KhachHang(
   maKH varchar(6) Primary Key,
   tenKH Nvarchar(50),
   sdt Nvarchar(11),
   diaChi Nvarchar(100),
   hieuXe Nvarchar(50),
   bienSo Nvarchar(10),
);

go
create table ChucVu(
   maCV varchar(6) Primary Key,
   tenCV Nvarchar(20),
);

go
create table PhuTung(
   maPT varchar(6) Primary Key,
   tenPT Nvarchar(100),
   xuatXu Nvarchar(20),
   thuongHieu Nvarchar(40),
   giaNhap bigint,
   giaBan bigint,
   soLuong int,
);

go
create table DichVu(
   maDV varchar(6) Primary Key,
   tenDV Nvarchar(100),
   thuongHieu Nvarchar(40),
   tienDV bigint,
   moTa Nvarchar(300),
);

go
create table NhaCungCap(
   maNCC varchar(6) Primary Key,
   tenNCC Nvarchar(100),
   sdt Nvarchar(11),
   diaChi Nvarchar(200),
);

go
create table NhanVien(
  taiKhoan varchar(20) Primary Key,
  matKhau varchar(10),
  tenNV Nvarchar(50),
  sdt varchar(11),
  diaChi Nvarchar(100),
  email varchar(50),
  maCV varchar(6) FOREIGN KEY (maCV) REFERENCES ChucVu(maCV),
);

go
create table PhieuSuaChua(
  MaPSC varchar(6) Primary Key,
  ngayLapPhieu datetime,
  ngayBanGiao datetime,
  ghiChu varchar(11),
  tienSuaChua varchar(100),
  TrangThaiThanhToan Nvarchar(50),
  taiKhoan varchar(20) FOREIGN KEY (taiKhoan) REFERENCES NhanVien(taiKhoan),
  maKH varchar(6) FOREIGN KEY (maKH) REFERENCES KhachHang(maKH),
);

go
create table HoaDon(
  MaHD varchar(6) Primary Key,
  ngayThanhToan datetime,
  hinhThucThanhToan Nvarchar(10),
  taiKhoan varchar(20) FOREIGN KEY (taiKhoan) REFERENCES NhanVien(taiKhoan),
  maPSC varchar(6) FOREIGN KEY (maPSC) REFERENCES PhieuSuaChua(maPSC),
);

go
create table CTPT_PhieuSuaChua(
  soLuong int,
  maPT varchar(6) FOREIGN KEY (maPT) REFERENCES PhuTung(maPT),
  maPSC varchar(6) FOREIGN KEY (maPSC) REFERENCES PhieuSuaChua(maPSC),
);

go
create table CTDV_PhieuSuaChua(
  maDV varchar(6) FOREIGN KEY (maDV) REFERENCES DichVu(maDV),
  maPSC varchar(6) FOREIGN KEY (maPSC) REFERENCES PhieuSuaChua(maPSC),
);

go
create table NhapPhuTung(
  maNhap varchar(6) Primary Key,
  ngayNhap datetime,
  tienNhap bigint,
  taiKhoan varchar(20) FOREIGN KEY (taiKhoan) REFERENCES NhanVien(taiKhoan),
  maNCC varchar(6) FOREIGN KEY (maNCC) REFERENCES NhaCungCap(maNCC),
);

go
create table CT_Nhap(
  soLuongNhap int,
  maPT varchar(6) FOREIGN KEY (maPT) REFERENCES PhuTung(maPT),
  maNhap varchar(6) FOREIGN KEY (maNhap) REFERENCES NhapPhuTung(maNhap),
);

create table SoLuongID(
  soLuongKH int,
  soLuongDV int,
  soLuongPT int,
  soLuongPSC int,
  soLuongNCC int,
  soLuongNPT int,
  soLuongHD int,
);


go
insert into KhachHang values('KH1',N'Bảo','09654157985',N'Sài Gòn','Toyota','45a48928'); 
insert into KhachHang values('KH2',N'Huy','035457157',N'Hà Nội','Toyota','60f23245');
insert into KhachHang values('KH3',N'Đạt','0915457541',N'Đà Nẵng','Toyota','34h42342'); 
insert into KhachHang values('KH4',N'Nam','0266548792',N'Bình Dương','Toyota','45g1657');  

go
insert into NhaCungCap values('NCC1',N'CÔNG TY CP ĐẦU TƯ THƯƠNG MẠI VÀ DỊCH VỤ Ô TÔ LIÊN VIỆT','0698445675',N'Cụm Công Nghiệp Lai Xá, Xã Kim Chung, Huyện Hoài Đức, TP Hà Nội ');
insert into NhaCungCap values('NCC2',N'CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ DƯƠNG DUY','0965464987',N'Số 212A3 Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1, TP. Hồ Chí Minh ');
insert into NhaCungCap values('NCC3',N'CÔNG TY CỔ PHẦN KENT VIỆT NAM','09654751647',N'Số 779, Tầng 2, Tòa CT3, KĐT Mỹ Đình, TP Hà Nội ');

go
insert into ChucVu values('CV1',N'Admin');
insert into ChucVu values('CV2',N'Lễ tân');
insert into ChucVu values('CV3',N'Kho');
insert into ChucVu values('CV4',N'Thu ngân');

go
insert into NhanVien values('admin','123456',N'admin','0931564974',N'Đồng Nai','admin@gmail.com','CV1');
insert into NhanVien values('lananh1','123456',N'Nguyễn Thị Lan Anh','0946579858',N'Đà Nẵng','lananh@gmail.com','CV2');

--KH,DV,PT,PSC,NCC,NPT,HD
go
insert into SoLuongID values('4','4','7','0','3','0','0');

go
insert into PhuTung values('PT1',N'ĐÈN HẬU NGOÀI PHẢI CÓ LED - SEDAN MAZDA MAZDA 3',N'Nhật Bản','MAZDA','4000000','4600000','10');
insert into PhuTung values('PT2',N'CÀNG A TRÁI DAEWOO LACETTI',N'Trung Quốc','GM-GN OEM','1200000','1500000','15');
insert into PhuTung values('PT3',N'XI NHAN GƯƠNG TRÁI TOYOTA CAMRY',N'Đài Loan','LEXUS','150000','180000','5');
insert into PhuTung values('PT4',N'Ổ KHÓA NGẬM CỬA SAU PHẢI FORD EVEREST',N'Thái Lan','FORD','2000000','2300000','7');
insert into PhuTung values('PT5',N'CÀNG A PHẢI HYUNDAI ACCENT',N'Hàn Quốc','HYUNDAI','900000','950000','13');
insert into PhuTung values('PT6',N'QUẠT KÉT NƯỚC KIA MORNING/PICANTOT',N'Trung Quốc','YOONSHAN OEM','800000','850000','17');
insert into PhuTung values('PT7',N'CẢM BIẾN VAN KHÔNG TẢI / CẢM BIẾN BÙ GA CHEVROLET AVEO',N'Hàn Quốc','PART SMALL OEM','680000','750000','20');

go
insert into DichVu values('DV1',N'Sơn ốp bảo vệ babule phải',N'Honda Civic','500000','');
insert into DichVu values('DV2',N'Gò nắn chỉnh phần dưới cửa sau phải + góc BĐS sau phải',N'Honda City','300000','');
insert into DichVu values('DV3',N'Cân chỉnh độ chụm',N'Honda City','450000','');
insert into DichVu values('DV4',N'Đánh bóng sonax cả xe',N'Kia','1300000','');

--select nv.taiKhoan,nv.tenNV,nv.sdt,nv.diaChi,nv.email ,cv.TenCV
--from NhanVien nv,ChucVu cv
--where nv.maCV= cv.maCV 




--select nhap.MaSP, COALESCE(nhap.SoLuong - xuat.SoLuong,nhap.SoLuong) as SoLuong,sp.TenSP
--        from SanPham sp, view_TongSPXuat xuat right join view_TongSPNhap nhap on nhap.MaSP = xuat.MaSP
--         where nhap.MaSP = sp.MaSP
--         group by nhap.MaSP,xuat.SoLuong,nhap.SoLuong,sp.TenSP

--go

--select MAX(CAST(RIGHT(mahd,LEN(mahd)-2) as INT)) as sohd
--from hoadon

--select hd.MaHD, hd.NgayLap , sum((ct.SoLuong*sp.GiaNhap)) as TongNhap, sum((ct.SoLuong*sp.GiaBan)) as TongBan
--from HoaDon hd,ChiTietHD ct,SanPham sp
--where hd.MaHD=ct.MaHD and ct.MaSP = sp.MaSP and hd.NgayLap >='2-3-2017' and hd.NgayLap<= '3-5-2017'
--group by hd.MaHD,hd.NgayLap 

--select * from Sanpham


--select k.*, sp.TenSP, n.MaNguon
-- from Kho k, SanPham sp, NguonCungCap n
-- where k.MaSP = sp.MaSP and sp.MaNguon = n.MaNguon and k.TrangThai =N'Nhập';

--select tk.HoTen,hd.MaHD, hd.NgayLap,ct.MaSP, ct.SoLuong, sp.DonViTinh,sp.GiaBan, (ct.SoLuong*sp.GiaBan) as ThanhTien
--from TaiKhoan tk,HoaDon hd, ChiTietHD ct,SanPham sp
--where tk.MaTaiKhoan= hd.MaTaiKhoan and hd.MaHD = ct.MaHD and ct.MaSP = sp.MaSP 


--select k.MaSP, sp.TenSP, n.TenNguon , sum(k.SoLuong) as SL
--from Kho k, SanPham sp, NguonCungCap n
--where k.MaSP = sp.MaSP and sp.MaNguon = n.MaNguon and k.TrangThai = N'Xuất'
--group by k.MaSP,sp.TenSP,n.TenNguon
--ORDER BY SL DESC

--select Q.*,F.TenBtn, F.TenForm
--from Quyen Q, DMform F
--where Q.IDform=F.IDform 

--select hd.* , tk.HoTen
--from HoaDon hd , TaiKhoan tk
--where hd.MaTaiKhoan = tk.MaTaiKhoan

--select * from ChiTietHD

--select hd.*, sp.GiaBan, sp.TenSP
--from ChiTietHD hd, SANPHAM sp
--where hd.MaHD = 'HD1' and hd.MaSP = sp.MaSP
--INSERT INTO TaiKhoan VALUES('TK999','nguyentinh','1234',N'Nguyễn Tính','01212181202','341672915',N'Vũ Trụ',N'Sao hỏa','..\..\..\resource\image\nhanvien\IMG_0825.JPG')

