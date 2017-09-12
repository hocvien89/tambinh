
create function [dbo].[GetTienpdvchitiet](@uId_Phieudichvu_Chitiet as nvarchar(50))
returns float
as
begin
declare @value float
set @value =(select count(TNTP_QT_Dieutri.uId_Phieudichvu_Chitiet) from TNTP_QT_Dieutri where uId_Phieudichvu_Chitiet=@uId_Phieudichvu_Chitiet)
return isnull(@value,0)
end

