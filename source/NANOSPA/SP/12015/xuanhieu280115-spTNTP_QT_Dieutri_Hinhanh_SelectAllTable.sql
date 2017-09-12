drop proc spTNTP_QT_Dieutri_Hinhanh_SelectAllTable
go
create proc spTNTP_QT_Dieutri_Hinhanh_SelectAllTable
@uId_QT_Dieutri as nvarchar(50)
as
begin 
	select uId_Hinhanh_Congdoan,uId_QT_Dieutri,nv_Hinhanh_vn
	 from TNTP_QT_Dieutri_Hinhanh
	 where uId_QT_Dieutri=@uId_QT_Dieutri
end
go