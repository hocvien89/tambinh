
create proc [dbo].[sp_TTV_THECHUYENTIENLICHSU_SelectByIDKH]
@uId_Khachhang nvarchar(50)='C093F65B-D752-480B-9548-D5964DCDAADB'
as
begin
DECLARE @Banglichsuchuyentien table (uId_Lichsuchuyentien nvarchar(50),uId_Khachhang nvarchar(50),v_Makhachang varchar(50),f_Sotien float,d_Ngaychuyen datetime,nv_Lido nvarchar(50))
insert @Banglichsuchuyentien
select  a.uId_Lichsuchuyentien,
	b.uId_Khachhang,
	c.v_Makhachang,
	
	a.f_Sotien,
	a.d_Ngaychuyen,
	e.v_Sophieu	
	from TTV_KH_THECHUYENTIEN_LICHSU as a 
	inner join TTV_KH_THECHUYENTIEN as b on	 a.uId_Thechuyentien = b.uId_Thechuyentien
	inner join CRM_DM_Khachhang as c on b.uId_Khachhang = c.uId_Khachhang 
	left join TNTP_PHIEUDICHVU_CHITIET as d on a.nv_Ghichu= d.uId_Phieudichvu_Chitiet
	left join TNTP_PHIEUDICHVU as e on d.uId_Phieudichvu =e.uId_Phieudichvu
	where e.v_Sophieu <> 'NULL' 
	
insert @Banglichsuchuyentien
	select 		
	a.uId_Lichsuchuyentien,
	b.uId_Khachhang,
	c.v_Makhachang,
	a.f_Sotien,
	a.d_Ngaychuyen,
	a.nv_Tuthethanhtoan
	from TTV_KH_THECHUYENTIEN_LICHSU as a 
	inner join TTV_KH_THECHUYENTIEN as b on	 a.uId_Thechuyentien = b.uId_Thechuyentien
	inner join CRM_DM_Khachhang as c on b.uId_Khachhang = c.uId_Khachhang 
	left join TNTP_PHIEUDICHVU_CHITIET as d on a.nv_Ghichu= d.uId_Phieudichvu_Chitiet
	left join TNTP_PHIEUDICHVU as e on d.uId_Phieudichvu =e.uId_Phieudichvu
	where a.uId_Lichsuchuyentien in (select uId_Lichsuchuyentien from TTV_KH_THECHUYENTIEN_LICHSU where nv_Tuthethanhtoan=N'Chuyển từ thẻ thanh toán')
insert @Banglichsuchuyentien
	select 		
	a.uId_Lichsuchuyentien,
	b.uId_Khachhang,
	c.v_Makhachang,
	a.f_Sotien,
	a.d_Ngaychuyen,	
	a.nv_Lido
	from TTV_KH_THECHUYENTIEN_LICHSU as a 
	inner join TTV_KH_THECHUYENTIEN as b on	 a.uId_Thechuyentien = b.uId_Thechuyentien
	inner join CRM_DM_Khachhang as c on b.uId_Khachhang = c.uId_Khachhang 
	left join TNTP_PHIEUDICHVU_CHITIET as d on a.nv_Ghichu= d.uId_Phieudichvu_Chitiet
	left join TNTP_PHIEUDICHVU as e on d.uId_Phieudichvu =e.uId_Phieudichvu
	where a.uId_Lichsuchuyentien in (select uId_Lichsuchuyentien from TTV_KH_THECHUYENTIEN_LICHSU where nv_Lido=N'Nạp tiền' )
insert @Banglichsuchuyentien
select 
	a.uId_Lichsuchuyentien,
	b.uId_Khachhang,
	c.v_Makhachang,
	a.f_Sotien,
	a.d_Ngaychuyen,	
	a.nv_Thanhtoancho
	from TTV_KH_THECHUYENTIEN_LICHSU as a 
	inner join TTV_KH_THECHUYENTIEN as b on	 a.uId_Thechuyentien = b.uId_Thechuyentien
	inner join CRM_DM_Khachhang as c on b.uId_Khachhang = c.uId_Khachhang 
	left join TNTP_PHIEUDICHVU_CHITIET as d on a.nv_Ghichu= d.uId_Phieudichvu_Chitiet
	left join TNTP_PHIEUDICHVU as e on d.uId_Phieudichvu =e.uId_Phieudichvu
where a.uId_Lichsuchuyentien in (select uId_Lichsuchuyentien from TTV_KH_THECHUYENTIEN_LICHSU where a.nv_Thanhtoancho like N'%Thanh toán cho%' )
	select * from @Banglichsuchuyentien 
	where uId_Khachhang = @uId_Khachhang
	end