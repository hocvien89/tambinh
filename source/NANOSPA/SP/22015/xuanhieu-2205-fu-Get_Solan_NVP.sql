drop function Get_Solan_NVP
go
create function Get_Solan_NVP(@uId_Nhanvien nvarchar(50), @uId_Dichvu nvarchar(50))
returns float
as
	begin
		declare @value float =0
		declare @temp as table(uId_Nhanvien nvarchar(50))
		begin
		insert into @temp 
		select dt.nv_Noidung from TNTP_QT_Dieutri dt, TNTP_PHIEUDICHVU_CHITIET pct
						where dt.uId_Phieudichvu_Chitiet=pct.uId_Phieudichvu_Chitiet
						and dt.nv_Noidung=@uId_Nhanvien
						and pct.uId_Dichvu=@uId_Dichvu
		select @value= COUNT(*) from @temp 
		end
	return @value
	end
go
select uId_Nhanvien from TNTP_QT_Dieutri