

ALTER PROCEDURE [dbo].[spQLTC_Phieuthuchi_Update]
(
	@uId_Phieuthuchi as varchar(50),
	@uId_Nhanvien as varchar(50),
	@uId_Thuchi as varchar(50),
	@v_Maphieu as varchar(30) = null,
	@d_Ngay as datetime = null,
	@f_Sotien as float = null,
	@nv_Lydo_vn as nvarchar(100) = null,
	@nv_Lydo_en as nvarchar(100) = null,
	@nv_Ghichu as nvarchar(200)
)
AS
BEGIN
	UPDATE [dbo].[QLTC_Phieuthuchi]
	SET
		[v_Maphieu] = @v_Maphieu,
		[d_Ngay] = @d_Ngay,
		[f_Sotien] = @f_Sotien,
		[nv_Lydo_vn] = @nv_Lydo_vn,
		[nv_Lydo_en] = @nv_Lydo_en,
		uId_Nhanvien = @uId_Nhanvien,
		uId_Thuchi= @uId_Thuchi,
		nv_Ghichu=@nv_Ghichu
	WHERE 
		[uId_Phieuthuchi] = @uId_Phieuthuchi
END 
