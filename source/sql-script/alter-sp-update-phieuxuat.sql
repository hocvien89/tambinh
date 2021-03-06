

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
	@b_IsKhoa as bit,
	@b_Kedon as bit,
	@i_Sothang as int,
	@f_Giathang as int
)
AS
BEGIN
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
		b_Kedon=@b_Kedon,
		i_Sothang=@i_Sothang,
		f_Giathang=@f_Giathang
	WHERE 
		[uId_Phieuxuat] = @uId_Phieuxuat
END 
