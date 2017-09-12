USE [NANOTMV2015]
GO
/****** Object:  StoredProcedure [dbo].[spPROCESS_ROOT_Step_SelectByRootID]    Script Date: 03/11/2015 11:31:09 ******/

ALTER PROCEDURE [dbo].[spPROCESS_ROOT_Step_SelectByRootID]
(
	@RootId AS NVARCHAR(50)
)
AS
BEGIN
	if @RootId <>''
	SELECT * FROM PROCESS_ROOT_STEP prs WHERE prs.Root_Id = @RootId
	else
	SELECT * FROM PROCESS_ROOT_STEP prs
END

select * from PROCESS_ROOT_STEP