USE [CHARMNGUYENSPA]
GO
/****** Object:  StoredProcedure [dbo].[sp_QLMH_DM_XUATXU_INSERT]    Script Date: 06/04/2015 09:23:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_QLMH_DM_XUATXU_INSERT]
	
           (@v_Maxuatxu varchar(50)
           ,@nv_Tenxuatxu_vn nvarchar(50)
           ,@nv_Tenxuatxu_en nvarchar(50))
as
INSERT INTO [CHARMNGUYENSPA].[dbo].[QLMH_DM_XUATXU]
           (
           [v_Maxuatxu]
           ,[nv_Tenxuatxu_vn]
           ,[nv_Tenxuatxu_en])
     VALUES
           (
           @v_Maxuatxu
           ,@nv_Tenxuatxu_vn
           ,@nv_Tenxuatxu_en)
