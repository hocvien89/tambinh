
create PROC [dbo].[sp_TTV_KH_Thechuyentien_Lichsu]
as
SELECT
	 a.uId_Lichsuchuyentien,
	c.v_Makhachang,
	a.f_Sotien,
	a.d_Ngaychuyen,
	e.v_Sophieu,
	a.nv_Lido
	
  FROM TTV_KH_THECHUYENTIEN_LICHSU as a inner join TTV_KH_THECHUYENTIEN as b on	 a.uId_Thechuyentien = b.uId_Thechuyentien
		inner join CRM_DM_Khachhang as c on b.uId_Khachhang = c.uId_Khachhang left join TNTP_PHIEUDICHVU_CHITIET as d on a.nv_Ghichu= d.uId_Phieudichvu_Chitiet left join TNTP_PHIEUDICHVU as e on d.uId_Phieudichvu =e.uId_Phieudichvu
		
