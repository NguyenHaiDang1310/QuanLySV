CREATE DATABASE quanlysv;
GO
USE quanlysv;
GO
CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(50) PRIMARY KEY,  -- Mã sinh viên là khóa chính
    HoTen NVARCHAR(100),                  -- Họ tên
    NgaySinh DATE,                        -- Ngày sinh
    GioiTinh NVARCHAR(10),                -- Giới tính
    DiemTB FLOAT,                         -- Điểm trung bình
    Khoa NVARCHAR(100)                    -- Khoa của sinh viên
);
GO
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY, -- Tên đăng nhập là khóa chính
    MatKhau NVARCHAR(100),                -- Mật khẩu
    Keypass NVARCHAR(100)                 -- Khóa bảo mật
);
GO
CREATE TABLE Khoa (
    MaKhoa NVARCHAR(50) PRIMARY KEY,  -- Mã khoa là khóa chính
    TenKhoa NVARCHAR(100)             -- Tên khoa
);
GO

INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('CNTT', 'Công nghệ thông tin');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('KT', 'Kế Toán');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('NN', 'Ngoại Ngữ');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('DT', 'Điện tử');
GO

GO
SELECT * FROM SinhVien;
SELECT * FROM Khoa;
SELECT * FROM TaiKhoan;
SELECT TenKhoa FROM Khoa;



INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('CNTT', N'Công nghệ thông tin');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('KT', N'Kế Toán');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('NN', N'Ngoại Ngữ');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('DT', N'Điện tử');



EXEC sp_help 'SinhVien';
EXEC sp_help 'Khoa';
ALTER TABLE SinhVien ALTER COLUMN Khoa NVARCHAR(100);
ALTER TABLE Khoa ALTER COLUMN TenKhoa NVARCHAR(100);

