ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_SelectDVNo]
(
@uId_Khachhang as varchar(50)
)
AS
BEGIN
	SELECT
		TNTP_PHIEUDICHVU.[uId_Phieudichvu] ,
		[uId_Khachhang],
		[v_Sophieu],
		CAST(CAST(DAY([d_Ngay]) AS VARCHAR(2))+'/'+ CAST(MONTH([d_Ngay]) AS VARCHAR(2))+'/'+CAST(YEAR([d_Ngay]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngay],
		CAST(CAST(DAY([d_Ngayketthuc]) AS VARCHAR(2))+'/'+ CAST(MONTH([d_Ngayketthuc]) AS VARCHAR(2))+'/'+CAST(YEAR([d_Ngayketthuc]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngayketthuc],
		--[f_Tongtienthuc],
		[dbo].[Get_TongGia_PDV](TNTP_PHIEUDICHVU.uId_Phieudichvu)-coalesce(QLCN_CONGNO.[f_Sotien],0) as f_Tongtienthuc,
		QLCN_CONGNO.f_Sotien-[dbo].[Get_CongNoDV_ByIdPhieudv](TNTP_PHIEUDICHVU.uId_Phieudichvu) as f_Sotienno,
		[dbo].[TNTP_PHIEUDICHVU].nv_Ghichu_vn,
		[dbo].[Get_CongNoDV_ByIdPhieudv](TNTP_PHIEUDICHVU.uId_Phieudichvu) as f_Dathanhtoan
		
	FROM [dbo].[TNTP_PHIEUDICHVU]
	INNER JOIN QLCN_CONGNO on QLCN_CONGNO.uId_Phieudichvu = TNTP_PHIEUDICHVU.uId_Phieudichvu 
where [uId_Khachhang] = @uId_Khachhang
	and QLCN_CONGNO.f_Sotien-[dbo].[Get_CongNoDV_ByIdPhieudv](TNTP_PHIEUDICHVU.uId_Phieudichvu)>0
END

delete from QLTC_Phieuthuchi where uId_Thuchi in (select uId_Thuchi from QLCN_CONGNO_THANHTOAN)
delete from QLCN_CONGNO_THANHTOAN


