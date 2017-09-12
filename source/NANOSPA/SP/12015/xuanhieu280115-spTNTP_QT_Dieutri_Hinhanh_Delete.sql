drop proc spTNTP_QT_Dieutri_Hinhanh_Delete
go
create proc spTNTP_QT_Dieutri_Hinhanh_Delete
@uId_Dieutri_Hinhanh as nvarchar(50)
as
begin 
delete from TNTP_QT_Dieutri_Hinhanh 
where uId_Hinhanh_Congdoan=@uId_Dieutri_Hinhanh
end
go