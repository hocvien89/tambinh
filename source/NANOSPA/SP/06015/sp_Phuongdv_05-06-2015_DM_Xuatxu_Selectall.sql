USE [CHARMNGUYENSPA]
GO
/****** Object:  StoredProcedure [dbo].[spQLMH_DM_XUATXU_SelectAll]    Script Date: 06/05/2015 12:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[spQLMH_DM_XUATXU_SelectAll]
AS
BEGIN
	SELECT
		*
	FROM [dbo].[QLMH_DM_XUATXU]
order by [nv_Tenxuatxu_vn]
END 







