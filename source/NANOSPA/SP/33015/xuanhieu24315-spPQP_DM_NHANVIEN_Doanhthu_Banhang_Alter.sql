

ALTER PROCEDURE [dbo].[spQT_DM_NHANVIEN_DoanhThu_Banhang] 
(
@TuNgay as datetime = '6/1/2014',
@DenNgay as datetime = '8/1/2014',
@uId_Nhanvien AS VARCHAR(50)
)
AS
BEGIN
		SELECT pct.uId_Dichvu, pct.uId_Nhanvien
		INTO #Tong1
		FROM TNTP_PHIEUDICHVU pdv 
		INNER JOIN TNTP_PHIEUDICHVU_CHITIET pct ON pdv.uId_Phieudichvu = pct.uId_Phieudichvu
		WHERE pdv.d_Ngay <= @DenNgay AND pdv.d_Ngay >=@TuNgay
		AND pct.uId_Nhanvien = (CASE @uId_Nhanvien WHEN '0' THEN pct.uId_Nhanvien ELSE @uId_Nhanvien END) 
		
		SELECT nv.v_Manhanvien, nv.nv_Hoten_vn,ndv.nv_TennhomDichvu_vn,dv.uId_Dichvu, dv.nv_Tendichvu_vn, dv.f_Gia,
		dv.f_PhantramHH_CTV, COUNT(dv.uId_Dichvu) as sluong,
		CASE WHEN f_PhantramHH_CTV > 100 THEN CAST( f_PhantramHH_CTV AS varchar) + ' VND' ELSE CAST (f_PhantramHH_CTV as varchar) + '%' END AS phantram,
		[dbo].[Get_HoaHong_DV](COUNT(dv.uId_Dichvu),f_PhantramHH_CTV,f_Gia) as f_HH
		FROM #Tong1
		INNER JOIN TNTP_DM_DICHVU dv ON dv.uId_Dichvu = #Tong1.uId_Dichvu
		INNER JOIN TNTP_DM_NHOMDICHVU ndv ON dv.uId_Nhomdichvu = ndv.uId_Nhomdichvu
		INNER JOIN QT_DM_NHANVIEN nv ON #Tong1.uId_Nhanvien = nv.uId_Nhanvien
		GROUP BY nv.v_Manhanvien, nv.nv_Hoten_vn,ndv.nv_TennhomDichvu_vn,dv.uId_Dichvu, dv.nv_Tendichvu_vn, dv.f_Gia,
		dv.f_PhantramHH_CTV
END 

select * from TNTP_DM_DICHVU