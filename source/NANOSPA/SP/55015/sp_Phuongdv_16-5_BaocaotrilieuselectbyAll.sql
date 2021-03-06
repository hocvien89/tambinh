USE [CHARMNGUYENSPA]
GO
/****** Object:  StoredProcedure [dbo].[spBAOCAO_Lichsu_Khachhangsudung_DV_SelectAll]    Script Date: 05/16/2015 12:36:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[spBAOCAO_Lichsu_Khachhangsudung_DV_SelectAll]
	@TuNgay as datetime, @DenNgay as datetime
AS
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
a.uId_Khachhang
FROM CRM_DM_Khachhang as a INNER JOIN TNTP_PHIEUDICHVU AS b ON a.uId_Khachhang=b.uId_Khachhang
	INNER JOIN TNTP_PHIEUDICHVU_CHITIET AS c ON b.uId_Phieudichvu= c.uId_Phieudichvu 
	INNER JOIN TNTP_QT_Dieutri AS d ON c.uId_Phieudichvu_Chitiet = d.uId_Phieudichvu_Chitiet
	INNER JOIN QT_DM_NHANVIEN AS e ON d.uId_Nhanvien = e.uId_Nhanvien
	
	INNER JOIN TNTP_DM_DICHVU AS G on c.uId_Dichvu = g.uId_Dichvu
	,TNTP_CHECKINCHECKOUT AS f 
	WHERE D.d_Ngaydieutri >=@TuNgay and d.d_Ngaydieutri<=@DenNgay
	ORDER BY d.d_Ngaydieutri
	