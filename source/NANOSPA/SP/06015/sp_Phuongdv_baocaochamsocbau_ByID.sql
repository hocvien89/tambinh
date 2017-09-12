
create PROC [dbo].[sp_Baocao_Hopdongchamsocbau_Byid]
	@uId_Phieuchitiet nvarchar(50)='CC1F4C9A-6BFB-4EB1-9E3E-0DD8CDAA30B7'

as
SELECT 

		d.nv_Tendichvu_vn,
		d.i_Solan_Dieutri,
		d.f_Gia
	
		
 from CRM_DM_Khachhang as a inner join TNTP_PHIEUDICHVU as b on	 a.uId_Khachhang = b.uId_Khachhang
				inner join TNTP_PHIEUDICHVU_CHITIET as	c on b.uId_Phieudichvu = c.uId_Phieudichvu
				inner join TNTP_DM_DICHVU as d on c.uId_Dichvu = d.uId_Dichvu
				inner join QT_DM_CUAHANG as e on a.uId_Cuahang = e.uId_Cuahang
				
				where  c.uId_Phieudichvu_Chitiet=@uId_Phieuchitiet 