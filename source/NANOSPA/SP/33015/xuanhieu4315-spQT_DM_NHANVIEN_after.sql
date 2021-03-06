
ALTER PROCEDURE [dbo].[spQT_DM_NHANVIEN_SelectAll]
(
	@uId_Cuahang as varchar(50) = '24e1a59b-f645-4240-9a31-d91a90e58793'
)
AS
BEGIN
	if @uId_Cuahang is null
	SELECT
		[dbo].[QT_DM_NHANVIEN].[uId_Nhanvien],
		[dbo].[QT_DM_NHANVIEN].[v_Barcode],
		[dbo].[QT_DM_NHANVIEN].[v_Manhanvien],
		[dbo].[QT_DM_NHANVIEN].[nv_Hoten_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Hoten_en],
		CAST(CAST(DAY([dbo].[QT_DM_NHANVIEN].[d_Ngaysinh]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[QT_DM_NHANVIEN].[d_Ngaysinh]) AS VARCHAR(2))+'/'+CAST(YEAR([dbo].[QT_DM_NHANVIEN].[d_Ngaysinh]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngaysinh],
		[dbo].[QT_DM_NHANVIEN].[nv_Chucvu_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Chucvu_en],
		[dbo].[QT_DM_NHANVIEN].[nv_Diachi_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Diachi_en],
		[dbo].[QT_DM_NHANVIEN].[nv_Quequan_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Quequan_en],
		[dbo].[QT_DM_NHANVIEN].[v_Dienthoai],
		[dbo].[QT_DM_NHANVIEN].[v_Email],
		[dbo].[QT_DM_NHANVIEN].[v_Tendangnhap],
		[dbo].[QT_DM_NHANVIEN].[v_Matkhau],
		[dbo].[QT_DM_NHANVIEN].[b_ActiveLogin],
		CAST(CAST(DAY([dbo].[QT_DM_NHANVIEN].[d_Ngayvaolam]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[QT_DM_NHANVIEN].[d_Ngayvaolam]) AS VARCHAR(2))+'/'+CAST(YEAR([dbo].[QT_DM_NHANVIEN].[d_Ngayvaolam]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngayvaolam],
		[dbo].[QT_DM_NHANVIEN].[b_Danglamviec],
		QLP_DM_PHONG.nv_Tenphong_vn

	FROM [dbo].[QT_DM_NHANVIEN]
	INNER JOIN CUAHANG_NHANVIEN on CUAHANG_NHANVIEN.uId_Nhanvien = QT_DM_NHANVIEN.uId_Nhanvien 
	inner join PQP_NHANVIEN_PHONG on PQP_NHANVIEN_PHONG.uId_Nhanvien= QT_DM_NHANVIEN.uId_Nhanvien
	inner join QLP_DM_PHONG on QLP_DM_PHONG.uId_Phong=PQP_NHANVIEN_PHONG.uId_Phongban
	WHERE  v_Tendangnhap<>'superadmin' 
	order by CUAHANG_NHANVIEN.uId_Cuahang,[dbo].[QT_DM_NHANVIEN].[nv_Hoten_vn] ASC  
	else
	SELECT
		[dbo].[QT_DM_NHANVIEN].[uId_Nhanvien],
		[dbo].[QT_DM_NHANVIEN].[v_Barcode],
		[dbo].[QT_DM_NHANVIEN].[v_Manhanvien],
		[dbo].[QT_DM_NHANVIEN].[nv_Hoten_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Hoten_en],
		CAST(CAST(DAY([dbo].[QT_DM_NHANVIEN].[d_Ngaysinh]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[QT_DM_NHANVIEN].[d_Ngaysinh]) AS VARCHAR(2))+'/'+CAST(YEAR([dbo].[QT_DM_NHANVIEN].[d_Ngaysinh]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngaysinh],
		[dbo].[QT_DM_NHANVIEN].[nv_Chucvu_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Chucvu_en],
		[dbo].[QT_DM_NHANVIEN].[nv_Diachi_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Diachi_en],
		[dbo].[QT_DM_NHANVIEN].[nv_Quequan_vn],
		[dbo].[QT_DM_NHANVIEN].[nv_Quequan_en],
		[dbo].[QT_DM_NHANVIEN].[v_Dienthoai],
		[dbo].[QT_DM_NHANVIEN].[v_Email],
		[dbo].[QT_DM_NHANVIEN].[v_Tendangnhap],
		[dbo].[QT_DM_NHANVIEN].[v_Matkhau],
		[dbo].[QT_DM_NHANVIEN].[b_ActiveLogin],
		CAST(CAST(DAY([dbo].[QT_DM_NHANVIEN].[d_Ngayvaolam]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[QT_DM_NHANVIEN].[d_Ngayvaolam]) AS VARCHAR(2))+'/'+CAST(YEAR([dbo].[QT_DM_NHANVIEN].[d_Ngayvaolam]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngayvaolam],
		[dbo].[QT_DM_NHANVIEN].[b_Danglamviec],
		QLP_DM_PHONG.nv_Tenphong_vn
	FROM [dbo].[QT_DM_NHANVIEN]
	INNER JOIN CUAHANG_NHANVIEN on CUAHANG_NHANVIEN.uId_Nhanvien = QT_DM_NHANVIEN.uId_Nhanvien 
	left outer join PQP_NHANVIEN_PHONG on PQP_NHANVIEN_PHONG.uId_Nhanvien= QT_DM_NHANVIEN.uId_Nhanvien
	left outer join QLP_DM_PHONG on QLP_DM_PHONG.uId_Phong=PQP_NHANVIEN_PHONG.uId_Phongban
	WHERE 
	--v_Tendangnhap not like '%admin%' 	and 
	CUAHANG_NHANVIEN.uId_Cuahang = @uId_Cuahang 
	order by [dbo].[QT_DM_NHANVIEN].[nv_Hoten_vn] ASC
END
