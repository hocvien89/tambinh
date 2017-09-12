--ALTER TABLE QLMH_PHIEUXUAT
--ADD b_DaThanhToan bit
DROP PROC [dbo].[spQLMH_PHIEUXUAT_DSChoThanhToan]
GO
CREATE PROCEDURE [dbo].[spQLMH_PHIEUXUAT_DSChoThanhToan]
(
	@b_DaThanhToan BIT = 'FALSE',
	@uId_Kho as varchar(50) = '0',
	@TuNgay as DATETIME ='08/26/2014', 
	@DenNgay as DATETIME = '08/26/2014',
	@uId_Cuahang AS VARCHAR(50) = ''
)
AS
BEGIN
	SELECT
		[uId_Phieuxuat],
		[QLMH_PHIEUXUAT].[uId_Khachhang],
		[QLMH_PHIEUXUAT].[uId_Kho],
		[uId_Nhanvien],
		[v_Maphieuxuat],
		CAST(CAST(DAY([d_Ngayxuat]) AS VARCHAR(2))+'/'+ CAST(MONTH([d_Ngayxuat]) AS VARCHAR(2))+'/'+CAST(YEAR([d_Ngayxuat]) AS VARCHAR(4)) AS VARCHAR(20)) as [d_Ngayxuat],
		[nv_Noidungxuat_vn],
		[nv_Noidungxuat_en],		
		[f_Giamgia],
		[f_Tongtienthuc],
		nv_Hoten_vn 
	FROM [dbo].[QLMH_PHIEUXUAT]
	INNER JOIN CRM_DM_Khachhang on CRM_DM_Khachhang.uId_Khachhang = QLMH_PHIEUXUAT.uId_Khachhang 
	INNER JOIN QLMH_DM_KHO qdk ON qdk.uId_Kho = [dbo].[QLMH_PHIEUXUAT].uId_Kho
	INNER JOIN QT_DM_CUAHANG qdc ON qdc.uId_Cuahang = qdk.uId_Cuahang
	where 
	[dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat] >= @TuNgay 
	and [dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat] <= @DenNgay
	and [QLMH_PHIEUXUAT].uId_Kho = case @uId_Kho when '0' then [QLMH_PHIEUXUAT].uId_Kho else @uId_Kho END
	AND [QLMH_PHIEUXUAT].b_DaThanhToan = ISNULL(@b_DaThanhToan, 'FALSE')
	AND qdc.uId_Cuahang = (CASE @uId_Cuahang WHEN '' THEN qdc.uId_Cuahang ELSE @uId_Cuahang END)
	order by [dbo].[QLMH_PHIEUXUAT].[d_Ngayxuat] DESC,v_Maphieuxuat DESC
END 
GO

ALTER PROCEDURE [dbo].[spQLMH_PHIEUXUAT_Insert]
(
	@uId_Khachhang as uniqueidentifier,
	@uId_Kho as uniqueidentifier,
	@uId_Nhanvien as uniqueidentifier,
	@v_Maphieuxuat as varchar(30) = null,
	@d_Ngayxuat as datetime = null,
	@nv_Noidungxuat_vn as nvarchar(100) = null,
	@nv_Noidungxuat_en as nvarchar(100) = null,
	@f_Tongtien as float = null,
	@f_Giamgia as float = null,
	@f_Tongtienthuc as float = null
)
AS
BEGIN
	Declare @uId_Phieuxuat uniqueidentifier;
	set @uId_Phieuxuat  = NEWID();
	INSERT INTO [dbo].[QLMH_PHIEUXUAT]
	(
		[uId_Phieuxuat],
		[uId_Khachhang],
		[uId_Kho],
		[uId_Nhanvien],
		[v_Maphieuxuat],
		[d_Ngayxuat],
		[nv_Noidungxuat_vn],
		[nv_Noidungxuat_en],
		[f_Giamgia],
		[f_Tongtienthuc],
		[b_IsKhoa],
		b_DaThanhToan
	) 
	VALUES
	(
		@uId_Phieuxuat,
		@uId_Khachhang,
		@uId_Kho,
		@uId_Nhanvien,
		@v_Maphieuxuat,
		@d_Ngayxuat,
		@nv_Noidungxuat_vn,
		@nv_Noidungxuat_en,
	
		@f_Giamgia,
		@f_Tongtienthuc,
		'0',
		'0'
	) 
select @uId_Phieuxuat
END 
GO

ALTER PROCEDURE [dbo].[spQLMH_PHIEUXUAT_Update]
(
	@uId_Phieuxuat as uniqueidentifier,
	@uId_Khachhang as uniqueidentifier,
	@uId_Kho as uniqueidentifier,
	@uId_Nhanvien as uniqueidentifier,
	@v_Maphieuxuat as varchar(30) = null,
	@d_Ngayxuat as datetime = null,
	@nv_Noidungxuat_vn as nvarchar(100) = null,
	@nv_Noidungxuat_en as nvarchar(100) = null,
	@f_Giamgia as float = null,
	@f_Tongtienthuc as float = null,
	@uId_LoaiTT as varchar(50),
	@b_IsKhoa as bit
)
AS
BEGIN
	Declare @dathanhtoan varchar(10);
	IF @nv_Noidungxuat_en = 'TT'
	SET @dathanhtoan = '1'
	ELSE
	SET @dathanhtoan = '0'
	UPDATE [dbo].[QLMH_PHIEUXUAT]
	SET
		uId_Kho=@uId_Kho,
		uId_Nhanvien=@uId_Nhanvien,
		[v_Maphieuxuat] = @v_Maphieuxuat,
		[d_Ngayxuat] = @d_Ngayxuat,
		[nv_Noidungxuat_vn] = @nv_Noidungxuat_vn,
		[nv_Noidungxuat_en] = @nv_Noidungxuat_en,
		[f_Giamgia] = @f_Giamgia,
		[f_Tongtienthuc] = @f_Tongtienthuc,
		uId_LoaiTT = @uId_LoaiTT,
		b_IsKhoa = @b_IsKhoa,
		b_DaThanhToan = @dathanhtoan
	WHERE 
		[uId_Phieuxuat] = @uId_Phieuxuat
END 
GO