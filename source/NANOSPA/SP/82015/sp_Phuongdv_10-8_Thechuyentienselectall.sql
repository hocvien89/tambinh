
create PROC	[dbo].[sp_TTV_KH_Thechuyentien_SelectAll]
as
Select TTV_KH_THECHUYENTIEN.uId_Thechuyentien, 
CRM_DM_Khachhang.v_Makhachang,
CRM_DM_Khachhang.uId_Khachhang,
		CRM_DM_Khachhang.nv_Hoten_vn,
		TTV_KH_THECHUYENTIEN.f_Sotien
 from CRM_DM_Khachhang inner join TTV_KH_THECHUYENTIEN on CRM_DM_Khachhang.uId_Khachhang = TTV_KH_THECHUYENTIEN.uId_Khachhang
