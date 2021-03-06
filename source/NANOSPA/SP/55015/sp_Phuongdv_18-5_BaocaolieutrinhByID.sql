USE [CHARMNGUYENSPA]
GO
/****** Object:  StoredProcedure [dbo].[spBAOCAO_Lichsu_Khachhangsudung_DV_SelectByID]    Script Date: 05/18/2015 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[spBAOCAO_Lichsu_Khachhangsudung_DV_SelectByID]
	@TuNgay AS datetime,
	@DenNgay AS datetime,
	@uId_Khachhang as varchar(50),
	@uId_Dichvu as varchar(50),
	@Chon as integer
AS
if @Chon =0
	Begin
		SELECT
a.nv_Hoten_vn,
a.nv_Diachi_vn,
a.v_DienthoaiDD,
a.v_Email,
e.nv_Hoten_vn as Nhanvien,
f.dt_checkin,
f.dt_checkout,
d.nv_Ghichu,
D.i_Lanthu,
g.nv_Tendichvu_vn,
b.v_Sophieu,
d.d_Ngaydieutri
,c.uId_Dichvu,
a.uId_Khachhang,
g.i_Solan_Dieutri
FROM CRM_DM_Khachhang as a INNER JOIN TNTP_PHIEUDICHVU AS b ON a.uId_Khachhang=b.uId_Khachhang
	INNER JOIN TNTP_PHIEUDICHVU_CHITIET AS c ON b.uId_Phieudichvu= c.uId_Phieudichvu 
	INNER JOIN TNTP_QT_Dieutri AS d ON c.uId_Phieudichvu_Chitiet = d.uId_Phieudichvu_Chitiet
	INNER JOIN QT_DM_NHANVIEN AS e ON d.uId_Nhanvien = e.uId_Nhanvien
	
	INNER JOIN TNTP_DM_DICHVU AS G on c.uId_Dichvu = g.uId_Dichvu
	LEFT JOIN TNTP_CHECKINCHECKOUT AS f ON f.uId_QT_Dieutri=d.uId_QT_Dieutri
	WHERE b.d_Ngay>= @TuNgay and b.d_Ngay<=@DenNgay 
	
	end
	else
	if @Chon =1
	Begin
	SELECT
a.nv_Hoten_vn,
a.nv_Diachi_vn,
a.v_DienthoaiDD,
a.v_Email,
e.nv_Hoten_vn as Nhanvien,
f.dt_checkin,
f.dt_checkout,
d.nv_Ghichu,
D.i_Lanthu,
g.nv_Tendichvu_vn,
b.v_Sophieu,
d.d_Ngaydieutri
,c.uId_Dichvu,
a.uId_Khachhang,
g.i_Solan_Dieutri
FROM CRM_DM_Khachhang as a INNER JOIN TNTP_PHIEUDICHVU AS b ON a.uId_Khachhang=b.uId_Khachhang
	INNER JOIN TNTP_PHIEUDICHVU_CHITIET AS c ON b.uId_Phieudichvu= c.uId_Phieudichvu 
	INNER JOIN TNTP_QT_Dieutri AS d ON c.uId_Phieudichvu_Chitiet = d.uId_Phieudichvu_Chitiet
	INNER JOIN QT_DM_NHANVIEN AS e ON d.uId_Nhanvien = e.uId_Nhanvien	
	INNER JOIN TNTP_DM_DICHVU AS G on c.uId_Dichvu = g.uId_Dichvu
	LEFT JOIN TNTP_CHECKINCHECKOUT AS f ON f.uId_QT_Dieutri=d.uId_QT_Dieutri
	WHERE b.d_Ngay>= @TuNgay and b.d_Ngay<=@DenNgay and @uId_Khachhang=A.uId_Khachhang
	ORDER BY d.d_Ngaydieutri	
	end
	else
	if @Chon= 2
	begin
	select
	a.nv_Hoten_vn,
a.nv_Diachi_vn,
a.v_DienthoaiDD,
a.v_Email,
e.nv_Hoten_vn as Nhanvien,
f.dt_checkin,
f.dt_checkout,
d.nv_Ghichu,
D.i_Lanthu,
g.nv_Tendichvu_vn,
b.v_Sophieu,
d.d_Ngaydieutri
,c.uId_Dichvu,
a.uId_Khachhang,
g.i_Solan_Dieutri
FROM CRM_DM_Khachhang as a INNER JOIN TNTP_PHIEUDICHVU AS b ON a.uId_Khachhang=b.uId_Khachhang
	INNER JOIN TNTP_PHIEUDICHVU_CHITIET AS c ON b.uId_Phieudichvu= c.uId_Phieudichvu 
	INNER JOIN TNTP_QT_Dieutri AS d ON c.uId_Phieudichvu_Chitiet = d.uId_Phieudichvu_Chitiet
	INNER JOIN QT_DM_NHANVIEN AS e ON d.uId_Nhanvien = e.uId_Nhanvien

	INNER JOIN TNTP_DM_DICHVU AS G on c.uId_Dichvu = g.uId_Dichvu
	LEFT JOIN TNTP_CHECKINCHECKOUT AS f ON f.uId_QT_Dieutri=d.uId_QT_Dieutri
	WHERE b.d_Ngay>= @TuNgay and b.d_Ngay<=@DenNgay and @uId_Dichvu = c.uId_Dichvu 
	end
	else if @Chon=3
	begin
	select
	a.nv_Hoten_vn,
a.nv_Diachi_vn,
a.v_DienthoaiDD,
a.v_Email,
e.nv_Hoten_vn as Nhanvien,
f.dt_checkin,
f.dt_checkout,
d.nv_Ghichu,
D.i_Lanthu,
g.nv_Tendichvu_vn,
b.v_Sophieu,
d.d_Ngaydieutri
,c.uId_Dichvu,
a.uId_Khachhang,
g.i_Solan_Dieutri
FROM CRM_DM_Khachhang as a INNER JOIN TNTP_PHIEUDICHVU AS b ON a.uId_Khachhang=b.uId_Khachhang
	INNER JOIN TNTP_PHIEUDICHVU_CHITIET AS c ON b.uId_Phieudichvu= c.uId_Phieudichvu 
	INNER JOIN TNTP_QT_Dieutri AS d ON c.uId_Phieudichvu_Chitiet = d.uId_Phieudichvu_Chitiet
	INNER JOIN QT_DM_NHANVIEN AS e ON d.uId_Nhanvien = e.uId_Nhanvien

	INNER JOIN TNTP_DM_DICHVU AS G on c.uId_Dichvu = g.uId_Dichvu
	LEFT JOIN TNTP_CHECKINCHECKOUT AS f ON f.uId_QT_Dieutri=d.uId_QT_Dieutri
	WHERE b.d_Ngay>= @TuNgay and b.d_Ngay<=@DenNgay and @uId_Dichvu = c.uId_Dichvu  and @uId_Khachhang=a.uId_Khachhang
	end