drop proc spTNTP_QT_Dieutri_Hinhanh_Insert
go
create proc spTNTP_QT_Dieutri_Hinhanh_Insert
@uId_QT_Dieutri as nvarchar(50),
@nv_Hinhanh_vn as nvarchar(200)
as
begin 
	declare @uId_QT_Hinhanh_Congdoan uniqueidentifier;
	set @uId_QT_Hinhanh_Congdoan = NEWID();
	insert into TNTP_QT_Dieutri_Hinhanh( uId_Hinhanh_Congdoan, uId_QT_Dieutri, nv_Hinhanh_vn)
			values (@uId_QT_Hinhanh_Congdoan,@uId_QT_Dieutri,@nv_Hinhanh_vn)
	select @uId_QT_Hinhanh_Congdoan
end
go