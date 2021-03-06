drop proc [dbo].[spQT_DM_NHANVIEN_HoaHong_Phieudichvu]
go
create PROCEDURE [dbo].[spQT_DM_NHANVIEN_HoaHong_Phieudichvu] 
(
	@TuNgay as datetime = '6/1/2014',
	@DenNgay as datetime = '8/1/2014',
	@uId_Nhanvien AS NVARCHAR(50) = '0'
)
AS
BEGIN
		SELECT pct.uId_Dichvu, pdv.uId_Nhanvien, pdv.uId_Phieudichvu, pdv.v_Sophieu, pdv.d_Ngay,
		pdv.HHPhieu
		INTO #Tong1
		FROM TNTP_PHIEUDICHVU pdv 
		INNER JOIN TNTP_PHIEUDICHVU_CHITIET pct ON pdv.uId_Phieudichvu = pct.uId_Phieudichvu
		WHERE pdv.d_Ngay <= @DenNgay AND pdv.d_Ngay >=@TuNgay
		AND pdv.uId_Nhanvien = (CASE @uId_Nhanvien WHEN '0' THEN pdv.uId_Nhanvien ELSE @uId_Nhanvien END) 
		
		SELECT nv.v_Manhanvien, nv.nv_Hoten_vn, #Tong1.v_Sophieu, #Tong1.d_Ngay,
		dv.uId_Dichvu, dv.nv_Tendichvu_vn, dv.f_Gia,
		CAST (#Tong1.HHPhieu as varchar) + '%' AS phantram,
		([dbo].[Get_DonGia_PDV](#Tong1.uId_Phieudichvu) - ([dbo].[Get_Tonggiamgia_PDVChitiet](#Tong1.uId_Phieudichvu) + dbo.Get_TongGiamGia_PDV_KH(#Tong1.uId_Phieudichvu))) AS dongiaPDV,
		(([dbo].[Get_DonGia_PDV](#Tong1.uId_Phieudichvu) - ([dbo].[Get_Tonggiamgia_PDVChitiet](#Tong1.uId_Phieudichvu) + dbo.Get_TongGiamGia_PDV_KH(#Tong1.uId_Phieudichvu))) * #Tong1.HHPhieu / 100) AS f_HH
		FROM #Tong1
		INNER JOIN TNTP_DM_DICHVU dv ON dv.uId_Dichvu = #Tong1.uId_Dichvu
		INNER JOIN QT_DM_NHANVIEN nv ON #Tong1.uId_Nhanvien = nv.uId_Nhanvien
		order by v_Sophieu
END