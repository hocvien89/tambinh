
alter PROC [dbo].[sp_CSKH_DM_KhachhangdadungDVSelectAll]
as
select distinct a.uId_Khachhang,a.nv_Hoten_vn from CRM_DM_Khachhang as a left join TNTP_PHIEUDICHVU as b on	a.uId_Khachhang = b.uId_Khachhang 
left join TNTP_PHIEUDICHVU_CHITIET as c on b.uId_Phieudichvu = c.uId_Phieudichvu inner join TNTP_DM_DICHVU as d on c.uId_Dichvu = d.uId_Dichvu
where

 a.uId_Khachhang in ( select TNTP_PHIEUDICHVU.uId_Khachhang from TNTP_PHIEUDICHVU)
