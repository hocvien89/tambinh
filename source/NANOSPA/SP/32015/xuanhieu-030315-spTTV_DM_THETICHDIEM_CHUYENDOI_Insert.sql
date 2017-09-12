drop proc spTTV_DM_THETICHDIEM_CHUYENDOI_Insert
go 
create proc spTTV_DM_THETICHDIEM_CHUYENDOI_Insert
@v_Machuyendoi as varchar(50),
@f_Giatri as float,
@i_Diem as integer,
@uId_Thetichdiem as nvarchar(50),
@nv_Tenchuyendoi as nvarchar(100),
@b_Trangthai as bit
as
begin 
	declare @uId_TTDChuyendoi uniqueidentifier;
	set @uId_TTDChuyendoi=NEWID();
	
	insert into TTV_DM_THETICHDIEM_CHUYENDOI
	(
		uId_TTDChuyendoi,
		v_Machuyendoi,
		f_Giatri,
		i_Diem,
		uId_Thetichdiem,
		nv_Tenchuyendoi,
		b_Trangthai
	)
	values
	(
		@uId_TTDChuyendoi,
		@v_Machuyendoi,
		@f_Giatri,
		@i_Diem,
		@uId_Thetichdiem,
		@nv_Tenchuyendoi,
		@b_Trangthai
	) 
	
	select @uId_TTDChuyendoi
end
go

	
	
	