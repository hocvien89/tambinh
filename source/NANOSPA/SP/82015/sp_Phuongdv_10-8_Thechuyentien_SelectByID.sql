
ALTER PROC [dbo].[sp_TTV_THECHUYENTIEN_SELECTBYID]
	@uId_Khachhang nvarchar(50)
	as
SELECT [uId_Thechuyentien]
      ,[uId_Khachhang]
      ,[f_Sotien]
  FROM [dbo].[TTV_KH_THECHUYENTIEN]
  where uId_Khachhang=@uId_Khachhang
