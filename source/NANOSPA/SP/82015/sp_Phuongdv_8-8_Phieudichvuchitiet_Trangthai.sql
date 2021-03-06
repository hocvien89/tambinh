USE [KIMLOAN_SALON]
GO
/****** Object:  StoredProcedure [dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID_PDVCT]    Script Date: 08/08/2015 11:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID_PDVCT]
-- NMT: Sua Them so lan dich vu trong Phieu chi tiet
-- Bo i_TongSL thang bang [f_Solan]
-- 
(
	@uId_Phieudichvu_Chitiet as varchar(50) = '6505a278-b936-4a8d-bcc4-b641b145ecc9'
)
AS
BEGIN
	SELECT 
		pdv_ct.[uId_Phieudichvu_Chitiet],
		pdv_ct.[uId_Phieudichvu],
		CAST(pdv_ct.[uId_Dichvu] as varchar(50)) as uId_Dichvu,
		pdv_ct.[uId_Ngoaite],
		pdv_ct.[f_Solan] ,--Manhtt Sua
		dbo.Get_TongSolan_daDT(pdv_ct.uId_Phieudichvu_Chitiet) as i_Landasudung,
		dbo.Get_TongSolan_daDT(pdv_ct.uId_Phieudichvu_Chitiet) as i_SL_daDieutri,
		pdv_ct.[f_Soluong],
		pdv_ct.[f_Dongia],
		pdv_ct.[f_Tongtien],
		pdv_ct.[f_Giamgia],
		dv.[nv_Tendichvu_vn],
		 pdv.d_Ngayketthuc,
		dv.i_SoLan_Dieutri,b_Trangthai,
		pdv_ct.f_Solan -dbo.Get_TongSolan_daDT(pdv_ct.uId_Phieudichvu_Chitiet) as i_Lanconlai,
		-- dv.i_Solan_Dieutri*pdv_ct.[f_Soluong] as i_TongSL, NMT Tai sao?
		--Coalesce(pdv_ct.[f_Tongtien]*coalesce(1-(pdv.f_Giamgia/coalesce(dbo.Get_TongGia_PDV(pdv_ct.uId_Phieudichvu),1)),1)/coalesce(pdv_ct.[f_Solan]*pdv_ct.[f_Soluong],1),0) as f_Gia1lan
		Coalesce(pdv_ct.[f_Tongtien]*coalesce(1-(pdv.f_Giamgia/(CASE dbo.Get_TongGia_PDV(pdv_ct.uId_Phieudichvu) WHEN 0 THEN 1 ELSE dbo.Get_TongGia_PDV(pdv_ct.uId_Phieudichvu) END )),1)/(CASE coalesce(pdv_ct.[f_Solan]*pdv_ct.[f_Soluong],1) WHEN 0 THEN 1 END),0) as f_Gia1lan
		
	FROM TNTP_PHIEUDICHVU_CHITIET pdv_ct
	INNER JOIN [dbo].[TNTP_DM_DICHVU] dv on pdv_ct.[uId_Dichvu] = dv.[uId_Dichvu]
	INNER JOIN TNTP_PHIEUDICHVU pdv on pdv.uId_Phieudichvu = pdv_ct.uId_Phieudichvu 
	
	WHERE pdv_ct.[uId_Phieudichvu_Chitiet] =@uId_Phieudichvu_Chitiet
	select
	
		qtdt.i_Lanthu,
		qtdt.nv_Ghichu_vn,
		qtdt.nv_Ghichu_cc_vn
		 from TNTP_QT_Dieutri qtdt left join TNTP_CHECKINCHECKOUT ck on qtdt.uId_QT_Dieutri = ck.uId_QT_Dieutri
	where qtdt.uId_QT_Dieutri = (select top (1) uId_QT_Dieutri from TNTP_QT_Dieutri where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet order by i_Lanthu desc)
END 
