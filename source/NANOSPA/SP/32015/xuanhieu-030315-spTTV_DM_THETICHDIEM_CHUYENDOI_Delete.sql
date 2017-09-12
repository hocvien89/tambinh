drop proc spTTV_DM_THETICHDIEM_CHUYENDOI_Delete
go 
create proc spTTV_DM_THETICHDIEM_CHUYENDOI_Delete
@uId_TTDChuyendoi as nvarchar(50)
as
begin 
	delete from TTV_DM_THETICHDIEM_CHUYENDOI
	where uId_TTDChuyendoi=@uId_TTDChuyendoi
end
go