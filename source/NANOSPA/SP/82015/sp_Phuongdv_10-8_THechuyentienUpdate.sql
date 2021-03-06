
create PROC [dbo].[sp_TTV_KH_THECHUYENTIEN_Update]
			 @uId_Khachhang nvarchar(100)='83715F79-3E82-450D-B246-6F1954224AED',            
			@uId_Phieudichvuchitiet nvarchar(100)='C96F17BB-91C6-472F-8721-02C49C6A7E6D'
			
		
as
begin
declare 
@f_Sotien float, @uId_Thechuyentien nvarchar(100), @f_Dem float
set @f_Dem = (select COUNT(TNTP_QT_Dieutri.i_Lanthu) from TNTP_QT_Dieutri where TNTP_QT_Dieutri.uId_Phieudichvu_Chitiet = @uId_Phieudichvuchitiet)
select @f_Dem 
Set @uId_Thechuyentien = (Select uId_Thechuyentien from TTV_KH_THECHUYENTIEN where uId_Khachhang = @uId_Khachhang)
select @uId_Thechuyentien
set @f_Sotien= (select distinct(TNTP_PHIEUDICHVU_CHITIET.f_Dongia) - dbo.GetTienpdvchitiet(@uId_Phieudichvuchitiet)*
(f_Dongia/f_Solan)
from TNTP_PHIEUDICHVU_CHITIET
 where TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu_Chitiet=@uId_Phieudichvuchitiet
)

select @f_Sotien

UPDATE [dbo].[TTV_KH_THECHUYENTIEN]
   SET  [f_Sotien] = @f_Sotien + [f_Sotien]
 WHERE @uId_Thechuyentien=[uId_Thechuyentien]
BEGIN

	UPDATE [dbo].[TNTP_PHIEUDICHVU_CHITIET]
	SET
		b_Trangthai=1

	WHERE 
		[uId_Phieudichvu_Chitiet]=@uId_Phieudichvuchitiet
END
end
begin
declare @uId_Lichsuchuyentien uniqueidentifier ,  @v_Ghichu varchar(100), @d_Ngayden datetime
set @uId_Lichsuchuyentien = NEWID();
select @uId_Thechuyentien
insert into [dbo].[TTV_KH_THECHUYENTIEN_LICHSU]
	(uId_Lichsuchuyentien,
	uId_Thechuyentien,
	d_Ngaychuyen,
	f_Sotien
	,nv_Ghichu)
	values
	(@uId_Lichsuchuyentien,
	@uId_Thechuyentien,
	GETDATE(),
	@f_Sotien,
	@uId_Phieudichvuchitiet
	)
end
--select TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu_Chitiet from CRM_DM_Khachhang inner join TNTP_PHIEUDICHVU on CRM_DM_Khachhang.uId_Khachhang = TNTP_PHIEUDICHVU.uId_Khachhang
--inner join TNTP_PHIEUDICHVU_CHITIET on TNTP_PHIEUDICHVU.uId_Phieudichvu = TNTP_PHIEUDICHVU.uId_Phieudichvu where CRM_DM_Khachhang.uId_Khachhang ='e70fa1ee-137a-4170-9b77-5ce5d7cd49fb'
--select * from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet not in (select uId_Phieudichvu_Chitiet  from TNTP_QT_Dieutri)
--select * from TNTP_PHIEUDICHVU where uId_Phieudichvu='4DDFC342-F397-4103-A6AF-18CB8E450A40'
--select * from TTV_KH_THECHUYENTIEN where uId_Khachhang='83715F79-3E82-450D-B246-6F1954224AED'
--delete from TTV_KH_THECHUYENTIEN
--insert into TTV_KH_THECHUYENTIEN (uId_Khachhang,f_Sotien) values('83715F79-3E82-450D-B246-6F1954224AED',0)
