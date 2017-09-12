drop proc spTTV_KH_THETICHDIEM_SelectByIdKH
go
create proc spTTV_KH_THETICHDIEM_SelectByIdKH
@uId_Khachhang nvarchar(50)='4447EB5E-20E6-4916-A386-E69321BE5E45'
as
begin
 select uId_Thetichdiem,f_Diemhientai,f_Tongtichluy,uId_KH_The,
 b_Trangthai,b_Isdelete,d_Ngayhethan from TTV_KH_THETICHDIEM
 where uId_Khachhang=@uId_Khachhang and b_Isdelete='False'
end
go

