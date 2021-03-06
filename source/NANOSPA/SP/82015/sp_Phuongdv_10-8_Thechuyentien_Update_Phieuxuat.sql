

create PROC [dbo].[sp_TTV_KH_THECHUYENTIEN_Update_TT_Phieuxuat]
	
	@uId_Khachhang as nvarchar(50)='2fe5ba9f-9276-4e74-b88c-97b89743270a',
	@uId_Phieuxuat as nvarchar(50)='fe6d01f3-5c34-4579-8655-2a05a3a25093'
as
declare @f_Sotien as int
set @f_Sotien = (select f_Sotien from TTV_KH_THECHUYENTIEN where uId_Khachhang =@uId_Khachhang) - (select f_Sotien from QLMH_PHIEUXUAT_LOAITT where uId_Phieuxuat = @uId_Phieuxuat)
if @uId_Phieuxuat=''
Update TTV_KH_THECHUYENTIEN
set f_Sotien=f_Sotien
where uId_Khachhang=@uId_Khachhang
else
UPDATE .[TTV_KH_THECHUYENTIEN]
   SET
      [f_Sotien] = @f_Sotien
 WHERE uId_Khachhang = @uId_Khachhang
insert into TTV_KH_THECHUYENTIEN_LICHSU
(uId_Thechuyentien,f_Sotien,d_Ngaychuyen,nv_TTPhieuxuat)
values
((select uId_Thechuyentien from TTV_KH_THECHUYENTIEN where uId_Khachhang=@uId_Khachhang),(select f_Sotien from QLMH_PHIEUXUAT_LOAITT where uId_Phieuxuat = @uId_Phieuxuat),GETDATE(),N'Thanh toán cho phiếu sản phẩm '+(select v_Maphieuxuat from QLMH_PHIEUXUAT where uId_Phieuxuat =@uId_Phieuxuat) )