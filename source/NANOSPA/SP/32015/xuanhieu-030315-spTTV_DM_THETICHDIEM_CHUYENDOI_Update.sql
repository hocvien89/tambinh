drop proc spTTV_DM_THETICHDIEM_CHUYENDOI_Update
go 
create proc spTTV_DM_THETICHDIEM_CHUYENDOI_Update
@uId_TTDChuyendoi as nvarchar(50),
@v_Machuyendoi as varchar(50),
@f_Giatri as float,
@i_Diem as integer,
@uId_Thetichdiem as nvarchar(50),
@nv_Tenchuyendoi as nvarchar(100),
@b_Trangthai as bit
as
begin 
	update  TTV_DM_THETICHDIEM_CHUYENDOI
	set v_Machuyendoi=@v_Machuyendoi,
	f_Giatri=@f_Giatri,
	i_Diem=@i_Diem,
	uId_Thetichdiem=@uId_Thetichdiem,
	nv_Tenchuyendoi =@nv_Tenchuyendoi,
	b_Trangthai=@b_Trangthai
	where uId_TTDChuyendoi=@uId_TTDChuyendoi
end
go