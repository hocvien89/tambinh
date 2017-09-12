
ALTER FUNCTION [dbo].[Get_CongNoSP_KH_Notime](@uId_Khachhang uniqueidentifier)
RETURNS float
as
Begin
Declare @ValReturn float

select @ValReturn =sum([dbo].[QLCN_CONGNO_SP].[f_Sotien])
	FROM [dbo].[QLCN_CONGNO_SP],[dbo].[QLMH_PHIEUXUAT]
where [dbo].[QLCN_CONGNO_SP].[uId_Phieuxuat] = [dbo].[QLMH_PHIEUXUAT].[uId_Phieuxuat]
and [dbo].[QLMH_PHIEUXUAT].[uId_Khachhang] =@uId_Khachhang
return isnull(@ValReturn,0)
End



