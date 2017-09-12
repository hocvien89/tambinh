drop function Get_Solan_NVC
go
create function Get_Solan_NVC(@uId_Nhanvien nvarchar(50), @uId_Dichvu nvarchar(50))
returns float
as
	begin
		declare @value float =0
		begin
		select @value= COUNT(dt.uId_Nhanvien) from TNTP_QT_Dieutri dt, TNTP_PHIEUDICHVU_CHITIET pct
						where pct.uId_Phieudichvu_Chitiet= dt.uId_Phieudichvu_Chitiet and dt.uId_Nhanvien=@uId_Nhanvien 
						and pct.uId_Dichvu=@uId_Dichvu
		end
	return @value
	end
go
