	--select * from CRM_DM_Khachhang where nv_Hoten_vn like '%test'
	--select * from TNTP_PHIEUDICHVU
ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_SelectByDate]
(
@uId_Khachhang as varchar(50) = 'D871F2C0-9F6F-47CB-8FE7-BB4C5D730E43',
@d_Tungay as datetime = '5/19/2015',
@d_Denngay as datetime = '5/19/2015'
)
AS
BEGIN
	SELECT
		TNTP_PHIEUDICHVU.uId_Phieudichvu,
		[uId_Khachhang],
		[v_Sophieu],
		CAST(CAST(DAY([d_Ngay]) AS VARCHAR(2))+'/'+ CAST(MONTH([d_Ngay]) AS VARCHAR(2))+'/'+CAST(YEAR([d_Ngay]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngay],
		[nv_Ghichu_vn],
		[nv_Ghichu_en],
		[f_Giamgia],
		([dbo].[Get_TongGia_PDV](TNTP_PHIEUDICHVU.uId_Phieudichvu)-coalesce(QLCN_CONGNO.[f_Sotien],0)- f_Giamgia + [dbo].[Get_CongNoDV_ByIdPhieudv](TNTP_PHIEUDICHVU.uId_Phieudichvu))  as f_Dathanhtoan,
		CAST(CAST(DAY(d_Ngayketthuc) AS VARCHAR(2))+'/'+ CAST(MONTH(d_Ngayketthuc) AS VARCHAR(2))+'/'+CAST(YEAR(d_Ngayketthuc) AS VARCHAR(4)) AS VARCHAR(20)) AS d_Ngayketthuc ,
		nv_Hoten_vn ,
		coalesce(QLCN_CONGNO.f_Sotien -[dbo].[Get_CongNoDV_ByIdPhieudv](TNTP_PHIEUDICHVU.uId_Phieudichvu),0) as tienno
	FROM [dbo].[TNTP_PHIEUDICHVU]
	LEFT JOIN QLCN_CONGNO on QLCN_CONGNO.uId_Phieudichvu = TNTP_PHIEUDICHVU.uId_Phieudichvu 
	LEFT JOIN QT_DM_NHANVIEN on QT_DM_NHANVIEN.uId_Nhanvien = TNTP_PHIEUDICHVU.uId_Nhanvien 
	where [uId_Khachhang] = @uId_Khachhang
		and @d_Tungay <= d_Ngay and d_Ngay <=@d_Denngay 
	order by TNTP_PHIEUDICHVU.d_Ngay DESC
END 


