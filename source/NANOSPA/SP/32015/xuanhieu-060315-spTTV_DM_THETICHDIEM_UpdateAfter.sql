
ALTER proc [dbo].[spTTV_DM_THETICHDIEM_Update]
@uId_Thetichdiem as nvarchar(50),
@nv_Tenthetichdiem as nvarchar(100),
@f_Diemkichhoat as float,
@uId_Cuahang as nvarchar(50),
@v_Mathetichdiem as varchar(20),
@f_Sotiendoi as float,
@i_Sodiemdoi as integer
as
begin 
	update TTV_DM_THETICHDIEM set nv_Tenthetichdiem=@nv_Tenthetichdiem,
	f_Diemkichhoat=@f_Diemkichhoat,
	uId_Cuahang=@uId_Cuahang,
	v_Mathetichdiem = @v_Mathetichdiem,
	f_Sotiendoi=@f_Sotiendoi,
	i_Sodiemdoi =@i_Sodiemdoi
	where uId_Thetichdiem=@uId_Thetichdiem
end
