
ALTER PROCEDURE [dbo].[spTRANGTHAIKHCHOXULY_Select_ByTimeAndByPhongOption]
(
	@TuNgay as datetime = '3/10/2015', 
	@DenNgay as datetime = '3/13/2015',
	@uId_Cuahang as varchar(50) = '24e1a59b-f645-4240-9a31-d91a90e58793',
	@uId_Phong AS VARCHAR(50) = '67be576f-54fe-43a3-bd33-27f42e88b3fe',
	@Step AS NVARCHAR(50) = '2',
	@keyword as nvarchar(200) = ''
)
AS
BEGIN
	if @uId_Cuahang is null
	SELECT
		[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
		[dbo].[CRM_DM_Khachhang].[v_Makhachang],
Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as int) as v_ma ,
		[dbo].[CRM_DM_Khachhang].[v_BarCode],
		[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
		CAST(CAST(DAY([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(2))+'/'+CAST(YEAR([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngaysinh],
		[dbo].[CRM_DM_Khachhang].[b_Gioitinh],
		[dbo].[CRM_DM_Khachhang].[nv_Diachi_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Diachi_en],
		[dbo].[CRM_DM_Khachhang].[nv_Nguyenquan_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Nguyenquan_en],
		[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD],
		[dbo].[CRM_DM_Khachhang].[v_Dienthoaikhac],
		[dbo].[CRM_DM_Khachhang].[v_Email],
		[dbo].[CRM_DM_Khachhang].[i_SoCMT],
		[dbo].[CRM_DM_Khachhang].[d_NgaycapCMT],
		[dbo].[CRM_DM_Khachhang].[nv_Noicap_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Noicap_en],
		CAST(CAST(DAY(dbo.CRM_DM_Khachhang.[d_Ngayden]) AS VARCHAR(2))+'/'+ CAST(MONTH(dbo.CRM_DM_Khachhang.[d_Ngayden] ) AS VARCHAR(2))+'/'+CAST(YEAR(dbo.CRM_DM_Khachhang.[d_Ngayden]) AS VARCHAR(4)) AS VARCHAR(20)) AS [d_Ngayden],
		[dbo].[CRM_DM_Khachhang].[uId_Nguonden],
		[dbo].[CRM_DM_Khachhang].[nv_Ghichu_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Ghichu_en],
		[dbo].[CRM_DM_NGUON].[nv_Nguon_vn],
		TNTP_DM_LOAITHE .nv_Tenloaithe_vn ,
		
		[dbo].[Get_SoduTK_KH](dbo.CRM_DM_Khachhang.[uId_Khachhang]) as soduTK
	FROM  dbo.TNTP_DM_LOAITHE INNER JOIN
                      dbo.TNTP_KHACHHANG_THE ON dbo.TNTP_DM_LOAITHE.uId_Loaithe = dbo.TNTP_KHACHHANG_THE.uId_Loaithe RIGHT OUTER JOIN
                      dbo.CRM_DM_Khachhang INNER JOIN
                      dbo.CRM_DM_NGUON ON dbo.CRM_DM_Khachhang.uId_Nguonden = dbo.CRM_DM_NGUON.uId_Nguon ON 
                      dbo.TNTP_KHACHHANG_THE.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
                      
	WHERE 
	
	CONVERT(Date,[dbo].[CRM_DM_Khachhang].[d_Ngayden]) <= @DenNgay
	and CONVERT(Date,[dbo].[CRM_DM_Khachhang].[d_Ngayden]) >= @TuNgay
	order by v_ma DESC
	ELSE
	IF @Step = '2'
	BEGIN
		IF @keyword = ''
		BEGIN
			SELECT DISTINCT
			[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
			[dbo].[CRM_DM_Khachhang].[v_Makhachang],
			Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as int) as v_ma ,
			[dbo].[CRM_DM_Khachhang].[v_BarCode],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
			[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD],
			qdp.nv_Tenphong_vn,
			pt.uId_Phieudichvu,
			pt.uId_TrangthaiKH,
			pt.uId_Trangthai,
			pt.uId_Phong,
			tp.v_Sophieu,
			pt.d_Ngay as d_Ngaylam,
			[dbo].[Get_TrangthaiHienTai](pt.uId_Phieudichvu) as trangthaicuoi,
			[dbo].[Get_PhongHienTai](pt.uId_Phieudichvu) as phongcuoi,
			pt.nv_Ghichu,
			qdp1.nv_Tenphong_vn as tenphongchuyen
			FROM 
						  dbo.CRM_DM_Khachhang
						  INNER JOIN TNTP_PHIEUDICHVU tp ON tp.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
						  INNER JOIN PQP_TRANGTHAIKHCHOXULY pt ON pt.uId_Phieudichvu = tp.uId_Phieudichvu
						  INNER JOIN QLP_DM_PHONG qdp ON qdp.uId_Phong = pt.uId_Phong
						  LEFT JOIN QLP_DM_PHONG qdp1 ON qdp1.uId_Phong = pt.uId_Phongchuyen
						  INNER JOIN CRM_DM_TRANGTHAI cdt ON cdt.uId_Trangthai = pt.uId_Trangthai
			WHERE 
			CONVERT(Date,pt.d_Ngay) <= @DenNgay
			and CONVERT(Date,pt.d_Ngay) >= @TuNgay
			and [dbo].[CRM_DM_Khachhang].[uId_Cuahang] = @uId_Cuahang 
			AND pt.uId_Phong = @uId_Phong
			order by d_Ngaylam DESC
		END
		ELSE
		BEGIN
			SELECT DISTINCT
			[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
			[dbo].[CRM_DM_Khachhang].[v_Makhachang],
			Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as int) as v_ma ,
			[dbo].[CRM_DM_Khachhang].[v_BarCode],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
			[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD],
			qdp.nv_Tenphong_vn,
			pt.uId_Phieudichvu,
			pt.uId_TrangthaiKH,
			pt.uId_Trangthai,
			pt.uId_Phong,
			tp.v_Sophieu,
			pt.d_Ngay as d_Ngaylam,
			[dbo].[Get_TrangthaiHienTai](pt.uId_Phieudichvu) as trangthaicuoi,
			[dbo].[Get_PhongHienTai](pt.uId_Phieudichvu) as phongcuoi,
			pt.nv_Ghichu
			FROM 
						  dbo.CRM_DM_Khachhang
						  INNER JOIN TNTP_PHIEUDICHVU tp ON tp.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
						  INNER JOIN PQP_TRANGTHAIKHCHOXULY pt ON pt.uId_Phieudichvu = tp.uId_Phieudichvu
						  INNER JOIN QLP_DM_PHONG qdp ON qdp.uId_Phong = pt.uId_Phong
						  INNER JOIN CRM_DM_TRANGTHAI cdt ON cdt.uId_Trangthai = pt.uId_Trangthai
			WHERE 
			CONVERT(Date,pt.d_Ngay) <= @DenNgay
			and CONVERT(Date,pt.d_Ngay) >= @TuNgay
			and [dbo].[CRM_DM_Khachhang].[uId_Cuahang] = @uId_Cuahang 
			AND pt.uId_Phong = @uId_Phong
			AND 
			(
				[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn] LIKE N'%'+ @keyword +'%'
				OR
				[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD] LIKE N'%'+ @keyword +'%'
			)
			order by d_Ngaylam DESC
		END
	END
	ELSE
	IF @Step = '3'
	BEGIN
		IF @keyword = ''
		BEGIN
			SELECT DISTINCT
			[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
			[dbo].[CRM_DM_Khachhang].[v_Makhachang],
			Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as int) as v_ma ,
			[dbo].[CRM_DM_Khachhang].[v_BarCode],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
			[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD],
			qdp.nv_Tenphong_vn,
			pt.uId_Phieudichvu,
			pt.uId_TrangthaiKH,
			pt.uId_Trangthai,
			pt.uId_Phong,
			tp.v_Sophieu,
			pt.d_Ngay as d_Ngaylam,
			[dbo].[Get_TrangthaiHienTai](pt.uId_Phieudichvu) as trangthaicuoi,
			[dbo].[Get_PhongHienTai](pt.uId_Phieudichvu) as phongcuoi,
			pt.nv_Ghichu
			FROM 
						  dbo.CRM_DM_Khachhang
						  INNER JOIN TNTP_PHIEUDICHVU tp ON tp.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
						  INNER JOIN PQP_TRANGTHAIKHCHOXULY pt ON pt.uId_Phieudichvu = tp.uId_Phieudichvu
						  INNER JOIN QLP_DM_PHONG qdp ON qdp.uId_Phong = pt.uId_Phong
						  INNER JOIN CRM_DM_TRANGTHAI cdt ON cdt.uId_Trangthai = pt.uId_Trangthai
			WHERE 
			pt.d_Ngay <= @DenNgay
			and pt.d_Ngay >= @TuNgay
			and [dbo].[CRM_DM_Khachhang].[uId_Cuahang] = @uId_Cuahang 
			AND pt.uId_Phong = @uId_Phong
			AND cdt.uId_Trangthai = 'd55b80ca-1001-49aa-80ae-9bb650c40a17'
			order by d_Ngaylam DESC
		END
		ELSE
		BEGIN
			SELECT DISTINCT
			[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
			[dbo].[CRM_DM_Khachhang].[v_Makhachang],
			Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as int) as v_ma ,
			[dbo].[CRM_DM_Khachhang].[v_BarCode],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
			[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
			[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD],
			qdp.nv_Tenphong_vn,
			pt.uId_Phieudichvu,
			pt.uId_TrangthaiKH,
			pt.uId_Trangthai,
			pt.uId_Phong,
			tp.v_Sophieu,
			pt.d_Ngay as d_Ngaylam,
			[dbo].[Get_TrangthaiHienTai](pt.uId_Phieudichvu) as trangthaicuoi,
			[dbo].[Get_PhongHienTai](pt.uId_Phieudichvu) as phongcuoi,
			pt.nv_Ghichu
			FROM 
						  dbo.CRM_DM_Khachhang
						  INNER JOIN TNTP_PHIEUDICHVU tp ON tp.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
						  INNER JOIN PQP_TRANGTHAIKHCHOXULY pt ON pt.uId_Phieudichvu = tp.uId_Phieudichvu
						  INNER JOIN QLP_DM_PHONG qdp ON qdp.uId_Phong = pt.uId_Phong
						  INNER JOIN CRM_DM_TRANGTHAI cdt ON cdt.uId_Trangthai = pt.uId_Trangthai
			WHERE 
			pt.d_Ngay <= @DenNgay
			and pt.d_Ngay >= @TuNgay
			and [dbo].[CRM_DM_Khachhang].[uId_Cuahang] = @uId_Cuahang 
			AND pt.uId_Phong = @uId_Phong
			AND cdt.uId_Trangthai = 'd55b80ca-1001-49aa-80ae-9bb650c40a17'
			AND 
			(
				[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn] LIKE N'%'+ @keyword +'%'
				OR
				[dbo].[CRM_DM_Khachhang].[v_DienthoaiDD] LIKE N'%'+ @keyword +'%'
			)
			order by d_Ngaylam DESC
		END
	END
END
