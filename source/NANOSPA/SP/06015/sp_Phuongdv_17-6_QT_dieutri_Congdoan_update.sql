alter PROC sp_QT_Dieutri_Congdoan_Update
		@uId_Congdoan nvarchar(50),
		@nv_Tencongdoan_vn nvarchar(100),
		
		@v_Macongdoan varchar(50)
as
UPDATE [JOLIE].[dbo].[TNTP_QT_DIEUTRI_CONGDOAN]
   SET [uId_Congdoan] = @uId_Congdoan
      ,[nv_Tencongdoan_vn] = @nv_Tencongdoan_vn
      
      ,[v_Macongdoan] = @v_Macongdoan
 WHERE  uId_Congdoan=@uId_Congdoan
GO


