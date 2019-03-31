ALTER view V_DSNop AS
SELECT Ma_So_Phieu, [Sinh vien].Ma_SV, Ho_Ten, Ngay_Sinh, Gioi_Tinh, Khoa_Hoc, Lop.Ma_Lop,Lop.Ten_Lop, Nganh.Ma_Nganh, Ten_Nganh, So_Tien, Ngay_Nap FROM (([Phieu Nop] INNER JOIN [Sinh vien] ON [Phieu Nop].Ma_SV = [Sinh vien].Ma_SV)
INNER JOIN Lop ON LOP.Ma_Lop = [Sinh vien].Ma_Lop) INNER JOIN Nganh ON Nganh.Ma_Nganh = Lop.Ma_Nganh
select *from V_DSNop

CREATE view V_TongTienTheoLop AS
SELECT Lop.Ma_Lop, sum(So_Tien) as Tong_Tien FROM (([Phieu Nop] INNER JOIN [Sinh vien] ON [Phieu Nop].Ma_SV = [Sinh vien].Ma_SV)
INNER JOIN Lop ON LOP.Ma_Lop = [Sinh vien].Ma_Lop)
group by  Lop.Ma_Lop

Create view V_TongTienTheoNgay AS
SELECT Ngay_Nap, sum(So_Tien) as Tong_Tien FROM [Phieu Nop]
group by  Ngay_Nap

CREATE view V_TongTienTheoSinhVien AS
SELECT  [Sinh vien].Ma_SV, Ho_Ten, Ngay_Sinh, Gioi_Tinh, Khoa_Hoc, Ten_Lop, Ten_Nganh, Sum(So_Tien) as Tong_Tien FROM (([Phieu Nop] INNER JOIN [Sinh vien] ON [Phieu Nop].Ma_SV = [Sinh vien].Ma_SV)
INNER JOIN Lop ON LOP.Ma_Lop = [Sinh vien].Ma_Lop) INNER JOIN Nganh ON Nganh.Ma_Nganh = Lop.Ma_Nganh
group by  [Sinh vien].Ma_SV, Ho_Ten, Ngay_Sinh, Gioi_Tinh, Khoa_Hoc, Ten_Lop, Ten_Nganh

CREATE view V_TongTienTheoNganh AS
SELECT Ten_Nganh, Sum(So_Tien) as Tong_Tien FROM (([Phieu Nop] INNER JOIN [Sinh vien] ON [Phieu Nop].Ma_SV = [Sinh vien].Ma_SV)
INNER JOIN Lop ON LOP.Ma_Lop = [Sinh vien].Ma_Lop) INNER JOIN Nganh ON Nganh.Ma_Nganh = Lop.Ma_Nganh
group by  Ten_Nganh

