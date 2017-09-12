drop proc spTTV_DM_THETICHDIEM_CHUYENDOI_SelectByIdThe
go
create proc spTTV_DM_THETICHDIEM_CHUYENDOI_SelectByIdThe
@uId_Thetichdiem nvarchar(50)='1A5EFF28-14E9-4BF5-800F-3516E40E5D85'
as
	begin 
		if @uId_Thetichdiem='Tatca'
			select 
			uId_TTDChuyendoi,
			b_Trangthai,
			v_Machuyendoi from TTV_DM_THETICHDIEM_CHUYENDOI
		else
			select uId_TTDChuyendoi,
			b_Trangthai,
			f_Giatri,
			i_Diem,
			v_Machuyendoi from TTV_DM_THETICHDIEM_CHUYENDOI
			where uId_Thetichdiem=@uId_Thetichdiem
	end
go
