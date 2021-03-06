

ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID]
(
	@uId_Phieudichvu as varchar(50) = 'b4484c3c-7315-4e44-8e3d-2bdf685f6682'
)
AS
BEGIN
	SELECT
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Phieudichvu_Chitiet],
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Phieudichvu],
		CAST([dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Dichvu] as varchar(50)) as uId_Dichvu,
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Ngoaite],
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Solan],
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Soluong],
		(TNTP_PHIEUDICHVU_CHITIET.f_Dongia-TNTP_PHIEUDICHVU_CHITIET.f_Giamgia )as f_Dongia,
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Tongtien],
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Giamgia],
		pdv.f_Giamgia as Giamgia,
		pdv.f_Tongtienthuc,
		pdv.nv_Ghichu_en,
		ISNULL([dbo].[TNTP_PHIEUDICHVU_CHITIET].b_BaoHanh,'False') AS b_BaoHanh,
		[dbo].[TNTP_DM_DICHVU].[nv_Tendichvu_vn],
		TNTP_DM_DICHVU.i_Solan_Dieutri*[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Soluong] as i_TongSL,
		dbo.Get_TongSolan_daDT(TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu_Chitiet) as i_SL_daDieutri,
		TNTP_DM_DICHVU.i_Solan_Dieutri*[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Soluong] - dbo.Get_TongSolan_daDT(TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu_Chitiet) as i_SL_Conlai,
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].uId_Nhanvien,
		qdn.nv_Hoten_vn,
		ndv.vType,
		pdv.uId_Khachhang	
	FROM [dbo].[TNTP_PHIEUDICHVU_CHITIET],[dbo].[TNTP_DM_DICHVU], QT_DM_NHANVIEN qdn, TNTP_DM_NHOMDICHVU ndv,
	TNTP_PHIEUDICHVU pdv
	WHERE 
			[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Dichvu] = [dbo].[TNTP_DM_DICHVU].[uId_Dichvu] AND
			[dbo].[TNTP_PHIEUDICHVU_CHITIET].uId_Nhanvien = qdn.uId_Nhanvien AND
			pdv.uId_Phieudichvu = TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu AND
			[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Phieudichvu]=@uId_Phieudichvu AND
			ndv.uId_Nhomdichvu =  [dbo].[TNTP_DM_DICHVU].uId_Nhomdichvu
	ORDER BY [dbo].[TNTP_DM_DICHVU].[nv_Tendichvu_vn] ASC
END
