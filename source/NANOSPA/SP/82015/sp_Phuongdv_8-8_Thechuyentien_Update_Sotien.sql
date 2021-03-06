

create PROC [dbo].[sp_TTV_THECHUYENTIEN_Update_TT]	
	@uId_Khachhang nvarchar(50),
	@GT bigint
as
declare @i integer, @uId_Lichsuthechuyentien uniqueidentifier, @uId_Thechuyentien nvarchar(50), @uId_Khachhang_Goidichvu nvarchar(50)


DECLARE db_cursor CURSOR FOR 
select a.f_Giatrigoi,b.uId_Thechuyentien  from TNTP_KHACHHANG_GOIDICHVU as a 
inner join TTV_KH_THECHUYENTIEN as b on a.uId_Khachhang = b.uId_Khachhang
where a.f_Giatrigoi <@GT

OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @i,@uId_Thechuyentien
WHILE @@FETCH_STATUS = 0  
BEGIN   
  
		update TTV_KH_THECHUYENTIEN
		set	f_Sotien = f_Sotien+@i
		where uId_Thechuyentien=@uId_Thechuyentien
		
		if @i>0
		begin
		insert into TTV_KH_THECHUYENTIEN_LICHSU
		(	
			uId_Thechuyentien,f_Sotien,d_Ngaychuyen, nv_Tuthethanhtoan
		)
		values
		(@uId_Thechuyentien,@i,GETDATE(),N'Chuyển từ thẻ thanh toán')
		
		end

		
  
FETCH NEXT FROM db_cursor INTO @i,@uId_Thechuyentien
END  
CLOSE db_cursor 
DEALLOCATE db_cursor

	update TNTP_KHACHHANG_GOIDICHVU
	set f_Giatrigoi = 0
	where uId_Khachhang  =@uId_Khachhang 


--select uId_Khachhang_Goidichvu from TNTP_KHACHHANG_GOIDICHVU where uId_Khachhang='6a971899-3f97-4401-9dbf-0ff5fb5a7c12'