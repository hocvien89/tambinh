
ALTER proc [dbo].[spTTV_DM_THETICHDIEM_Insert]
@nv_Tenthetichdiem as nvarchar(100),
@f_Diemkichhoat as float,
@uId_Cuahang as nvarchar(50),
@v_Mathetichdiem as varchar(50),
@f_Sotiendoi as float,
@i_Sodiemdoi as integer
as
begin 
	insert into TTV_DM_THETICHDIEM
	(
		nv_Tenthetichdiem,
		f_Diemkichhoat,
		uId_Cuahang,
		v_Mathetichdiem,
		f_Sotiendoi,
		i_Sodiemdoi
		)
		values
		(
		@nv_Tenthetichdiem,
		@f_Diemkichhoat,
		@uId_Cuahang,
		@v_Mathetichdiem,
		@f_Sotiendoi,
		@i_Sodiemdoi)
end
