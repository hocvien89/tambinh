
create proc [dbo].[spThechuyentien_SelectByIdKH]
@uId_Khachhang nvarchar(50)
as
begin
	select * from TTV_KH_THECHUYENTIEN
	where uId_Khachhang=@uId_Khachhang
end
