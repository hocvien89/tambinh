
CREATE PROC [dbo].[sp_SelectDVBYIDKhachhang]
	@uId_Khachhang nvarchar(50)='17DB4502-CAD9-464A-B5A7-57ABEC7FBDD2'

as
SELECT 

		a.nv_Hoten_vn,
		c.uId_Phieudichvu_Chitiet,
		d.nv_Tendichvu_vn
	
		
 from CRM_DM_Khachhang as a inner join TNTP_PHIEUDICHVU as b on	 a.uId_Khachhang = b.uId_Khachhang
				inner join TNTP_PHIEUDICHVU_CHITIET as	c on b.uId_Phieudichvu = c.uId_Phieudichvu
				inner join TNTP_DM_DICHVU as d on c.uId_Dichvu = d.uId_Dichvu
				inner join QT_DM_CUAHANG as e on a.uId_Cuahang = e.uId_Cuahang
				
				where  a.uId_Khachhang = @uId_Khachhang