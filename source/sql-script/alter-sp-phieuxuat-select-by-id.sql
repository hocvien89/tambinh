
ALTER PROCEDURE [dbo].[spQLMH_PHIEUXUAT_SelectByID]
(
	@uId_Phieuxuat as uniqueidentifier = '82cec466-9c98-4e3d-9f41-15682cdac587'
)
AS
BEGIN
	SELECT
		[dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat],
		[dbo].[QLMH_PHIEUXUAT].[uId_Khachhang],
		[dbo].[QLMH_PHIEUXUAT].[uId_Kho],
		[dbo].[QLMH_PHIEUXUAT].[uId_Nhanvien],
		[dbo].[QLMH_PHIEUXUAT].[v_Maphieuxuat],
[dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat] as [d_Ngayxuat1],
		CAST(CAST(DAY([dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat]) AS VARCHAR(2))+'/'+ CAST(MONTH([dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat]) AS VARCHAR(2))+'/'+CAST(YEAR([dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat]) AS VARCHAR(4)) AS VARCHAR(20)) as [d_Ngayxuat],
		[dbo].[QLMH_PHIEUXUAT].[nv_Noidungxuat_vn],		
		[dbo].[QLMH_PHIEUXUAT].[f_Giamgia],
		[dbo].[QLMH_PHIEUXUAT].[f_Tongtienthuc],
		--[dbo].[Get_TienPhieuxuatTTThe]([dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat]) as f_Tongtienthuc,
		[dbo].[QLCN_CONGNO_SP].[f_Sotien] as f_Sotien,
		[dbo].[QLMH_PHIEUXUAT].b_IsKhoa,
		[dbo].[QLMH_PHIEUXUAT].b_Kedon,
		--([dbo].[Get_TongGia_PX]([dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat]) + [dbo].[Get_Tonggiamgia_PXChitiet]([dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat])) as nv_Noidungxuat_en,
		[dbo].[Get_TongDonGia_PX]([dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat]) as nv_Noidungxuat_en,
		[dbo].[QLMH_PHIEUXUAT].uId_LoaiTT,
		i_Sothang,
		f_Giathang
	FROM [dbo].[QLMH_PHIEUXUAT]  LEFT JOIN [dbo].[QLCN_CONGNO_SP]
on [dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat] = [dbo].[QLCN_CONGNO_SP].[uId_Phieuxuat] 
where [dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat]=@uId_Phieuxuat 
END
