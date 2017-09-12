drop proc spTNTP_QT_Dieutri_Hinhanh_Update
go
create proc spTNTP_QT_Dieutri_Hinhanh_Update
@uId_QT_Dieutri as nvarchar(50),
@nv_Hinhanh_vn as nvarchar(200),
@uId_Hinhanh_Congdoan as nvarchar(50)
as
begin 
	update TNTP_QT_Dieutri_Hinhanh set uId_QT_Dieutri=@uId_QT_Dieutri, nv_Hinhanh_vn=@nv_Hinhanh_vn
	where uId_Hinhanh_Congdoan=@uId_Hinhanh_Congdoan
end
go