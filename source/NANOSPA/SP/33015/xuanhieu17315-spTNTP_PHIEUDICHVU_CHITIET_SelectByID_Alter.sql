

ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID]
(
	@uId_Phieudichvu as varchar(50) = '2D02208F-AC7F-45E9-8381-3F0F8F45701C'
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
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Dongia],
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Tongtien],
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Giamgia],
		ISNULL([dbo].[TNTP_PHIEUDICHVU_CHITIET].b_BaoHanh,'False') AS b_BaoHanh,
		[dbo].[TNTP_DM_DICHVU].[nv_Tendichvu_vn],
		TNTP_DM_DICHVU.i_Solan_Dieutri*[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Soluong] as i_TongSL,
		dbo.Get_TongSolan_daDT(TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu_Chitiet) as i_SL_daDieutri,
		TNTP_DM_DICHVU.i_Solan_Dieutri*[dbo].[TNTP_PHIEUDICHVU_CHITIET].[f_Soluong] - dbo.Get_TongSolan_daDT(TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu_Chitiet) as i_SL_Conlai,
		[dbo].[TNTP_PHIEUDICHVU_CHITIET].uId_Nhanvien,
		qdn.nv_Hoten_vn,
		ndv.vType,
		pdv.uId_Khachhang	,
		kh.nv_Hoten_vn as khachhang
	FROM [dbo].[TNTP_PHIEUDICHVU_CHITIET],[dbo].[TNTP_DM_DICHVU], QT_DM_NHANVIEN qdn, TNTP_DM_NHOMDICHVU ndv,
	TNTP_PHIEUDICHVU pdv, CRM_DM_Khachhang kh
	WHERE 
			[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Dichvu] = [dbo].[TNTP_DM_DICHVU].[uId_Dichvu] AND
			[dbo].[TNTP_PHIEUDICHVU_CHITIET].uId_Nhanvien = qdn.uId_Nhanvien AND
			pdv.uId_Phieudichvu = TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu AND
			[dbo].[TNTP_PHIEUDICHVU_CHITIET].[uId_Phieudichvu]=@uId_Phieudichvu AND
			ndv.uId_Nhomdichvu =  [dbo].[TNTP_DM_DICHVU].uId_Nhomdichvu and
			pdv.uId_Khachhang=kh.uId_Khachhang
	ORDER BY [dbo].[TNTP_DM_DICHVU].[nv_Tendichvu_vn] ASC
END
