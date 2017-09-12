
create PROC [dbo].[sp_TTV_KH_THECHUYENTIEN_Update_NT]

			( @uId_Thechuyentien nvarchar(100)
			
           ,@f_Sotien float)
           as
           begin
UPDATE [dbo].[TTV_KH_THECHUYENTIEN]
   SET
     
      [f_Sotien] = @f_Sotien + [f_Sotien]
 WHERE uId_Thechuyentien = @uId_Thechuyentien


declare @uId_Lichsuchuyentien uniqueidentifier ,   @d_Ngayden datetime
set @uId_Lichsuchuyentien = NEWID();
select @uId_Thechuyentien
select @f_Sotien
insert into [dbo].[TTV_KH_THECHUYENTIEN_LICHSU]
	(uId_Lichsuchuyentien,
	uId_Thechuyentien,
	d_Ngaychuyen,
	f_Sotien
	,nv_Lido)
	values
	(@uId_Lichsuchuyentien,
	@uId_Thechuyentien,
	GETDATE(),
	@f_Sotien,
	N'Nạp tiền'
	)

end