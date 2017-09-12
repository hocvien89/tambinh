USE [JOLIE]
GO
/****** Object:  StoredProcedure [dbo].[spTNTP_QT_DIEUTRI_CONGDOAN_Insert]    Script Date: 06/17/2015 14:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spTNTP_QT_DIEUTRI_CONGDOAN_Insert]
(
	@nv_Tencongdoan_vn nvarchar(100),
	
	@v_Macongdoan varchar(50)
)
AS
BEGIN
	Declare @uId_Congdoan as uniqueidentifier;
	set @uId_Congdoan   = NEWID();
	INSERT INTO [TNTP_QT_DIEUTRI_CONGDOAN]
	(
		uId_Congdoan,
		v_Macongdoan,
		nv_Tencongdoan_vn
	
	)
	VALUES
	(
		@uId_Congdoan,
		@v_Macongdoan,
		@nv_Tencongdoan_vn
		
	)
	Select @uId_Congdoan
END