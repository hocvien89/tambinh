USE [NANOSPA2015]
GO
/****** Object:  StoredProcedure [dbo].[sp_Baocao_Hopdongchamsocbau]    Script Date: 06/23/2015 10:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_Baocao_Hopdongchamsocbau]
	@uId_Phieuchitiet nvarchar(50)='CC1F4C9A-6BFB-4EB1-9E3E-0DD8CDAA30B7',
	@uId_Khachhang nvarchar(50)
as
SELECT a.uId_Khachhang,
		a.v_Makhachang,
		a.nv_Diachi_vn,
		a.nv_Hoten_vn,
		a.d_Ngaysinh,
		a.v_Email,
		a.v_DienthoaiDD,
		d.nv_Tendichvu_vn,
		d.i_Solan_Dieutri,
		d.f_Gia,
		c.uId_Phieudichvu_Chitiet
		,b.uId_Phieudichvu
		
 from CRM_DM_Khachhang as a inner join TNTP_PHIEUDICHVU as b on	 a.uId_Khachhang = b.uId_Khachhang
				inner join TNTP_PHIEUDICHVU_CHITIET as	c on b.uId_Phieudichvu = c.uId_Phieudichvu
				inner join TNTP_DM_DICHVU as d on c.uId_Dichvu = d.uId_Dichvu
				inner join QT_DM_CUAHANG as e on a.uId_Cuahang = e.uId_Cuahang
				
				where  c.uId_Phieudichvu_Chitiet=@uId_Phieuchitiet and a.uId_Khachhang=@uId_Khachhang