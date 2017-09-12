USE [CHARMNGUYENSPA]
GO
/****** Object:  StoredProcedure [dbo].[spQLMH_DM_XUATXU_Update]    Script Date: 06/04/2015 09:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[spQLMH_DM_XUATXU_Update]
(
	@uid_Xuatxu as varchar(50),
	@v_Maxuatxu as varchar(50),
	@nv_Tenxuatxu_vn as nvarchar(100) = null,
	@nv_Tenxuatxu_en as nvarchar(100) = null
)
AS
BEGIN
	UPDATE [dbo].[QLMH_DM_XUATXU]
	SET
		[nv_Tenxuatxu_vn] = @nv_Tenxuatxu_vn,
		[nv_Tenxuatxu_en] = @nv_Tenxuatxu_en,
		[v_Maxuatxu]=@v_Maxuatxu
	WHERE 
		[uid_Xuatxu] = @uid_Xuatxu
END 




