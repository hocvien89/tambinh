ALTER PROCEDURE [dbo].[spBAOCAO_ThongkeKH_ByTime]
(
	@TuNgay as datetime ='2016-07-11', 
	@DenNgay as datetime='2016-08-11',
	@uId_Cuahang as varchar(50) ='24E1A59B-F645-4240-9A31-D91A90E58793'
)
AS
BEGIN
	if @uId_Cuahang is null
	SELECT
		[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
		[dbo].[CRM_DM_Khachhang].[v_Makhachang],
        Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as varchar(10)) as v_ma ,
		[dbo].[CRM_DM_Khachhang].[v_BarCode],
		[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
		--dbo.Get_ValueDate([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) as d_Ngaysinh,
		--CAST(CAST(DAY([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(2))+'/'+
		CAST(YEAR([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(4)),
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
		[dbo].[fc_Get_Nguon_By_Khachhang]([CRM_DM_Khachhang].[uId_Nguoigioithieu]) as nv_Nguon_vn,
		TNTP_DM_LOAITHE .nv_Tenloaithe_vn ,
		[dbo].[Get_SoduTK_KH](dbo.CRM_DM_Khachhang.[uId_Khachhang]) as soduTK
	FROM  dbo.TNTP_DM_LOAITHE INNER JOIN
                      dbo.TNTP_KHACHHANG_THE ON dbo.TNTP_DM_LOAITHE.uId_Loaithe = dbo.TNTP_KHACHHANG_THE.uId_Loaithe RIGHT OUTER JOIN
                      dbo.CRM_DM_Khachhang INNER JOIN
                      dbo.CRM_DM_NGUON ON dbo.CRM_DM_Khachhang.uId_Nguonden = dbo.CRM_DM_NGUON.uId_Nguon ON 
                      dbo.TNTP_KHACHHANG_THE.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
                      
	WHERE 
	
	[dbo].[CRM_DM_Khachhang].[d_Ngayden] <= @DenNgay
	and [dbo].[CRM_DM_Khachhang].[d_Ngayden] >= @TuNgay
	order by v_ma DESC
	else
	SELECT
		[dbo].[CRM_DM_Khachhang].[uId_Khachhang],
		[dbo].[CRM_DM_Khachhang].[v_Makhachang],
        Cast(substring([dbo].[CRM_DM_Khachhang].[v_Makhachang],3,len([dbo].[CRM_DM_Khachhang].[v_Makhachang])) as varchar(10)) as v_ma ,
		[dbo].[CRM_DM_Khachhang].[v_BarCode],
		[dbo].[CRM_DM_Khachhang].[nv_Hoten_vn],
		[dbo].[CRM_DM_Khachhang].[nv_Hoten_en],
		--dbo.Get_ValueDate([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) as d_Ngaysinh,
		--CAST(CAST(DAY([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(2))+'/'+
		CAST(YEAR([dbo].[CRM_DM_Khachhang].[d_Ngaysinh]) AS VARCHAR(4)) AS [d_Ngaysinh],
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
		[dbo].[fc_Get_Nguon_By_Khachhang]([CRM_DM_Khachhang].[uId_Nguoigioithieu]) as nv_Nguon_vn,
		TNTP_DM_LOAITHE .nv_Tenloaithe_vn,
		[dbo].[Get_SoduTK_KH](dbo.CRM_DM_Khachhang.[uId_Khachhang]) as soduTK
	FROM dbo.TNTP_DM_LOAITHE INNER JOIN
                      dbo.TNTP_KHACHHANG_THE ON dbo.TNTP_DM_LOAITHE.uId_Loaithe = dbo.TNTP_KHACHHANG_THE.uId_Loaithe RIGHT OUTER JOIN
                      dbo.CRM_DM_Khachhang INNER JOIN
                      dbo.CRM_DM_NGUON ON dbo.CRM_DM_Khachhang.uId_Nguonden = dbo.CRM_DM_NGUON.uId_Nguon ON 
                      dbo.TNTP_KHACHHANG_THE.uId_Khachhang = dbo.CRM_DM_Khachhang.uId_Khachhang
	WHERE 
	
	[dbo].[CRM_DM_Khachhang].[d_Ngayden] <= @DenNgay
	and [dbo].[CRM_DM_Khachhang].[d_Ngayden] >= @TuNgay
	and [dbo].[CRM_DM_Khachhang].[uId_Cuahang] = @uId_Cuahang 
	order by v_ma DESC
END 







