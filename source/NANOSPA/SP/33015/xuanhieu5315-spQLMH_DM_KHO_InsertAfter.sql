
ALTER PROCEDURE [dbo].[spQLMH_DM_KHO_Insert]
(
	@uId_Cuahang as varchar(50) ,
	@v_Makho as varchar(30) = null,
	@nv_Tenkho_vn as nvarchar(100) = null,
	@nv_Tenkho_en as nvarchar(100) = NULL,
	@Id_Phongsudung AS NVARCHAR(500) = ''
)
AS
BEGIN
	declare @uId_kho uniqueidentifier
	set @uId_kho= NEWID()
	INSERT INTO [dbo].[QLMH_DM_KHO]
	(
		uId_Kho,
		[uId_Cuahang],		
		[v_Makho],
		[nv_Tenkho_vn],
		[nv_Tenkho_en],
		[Id_Phongsudung]
	) 
	VALUES
	(
		@uId_kho,
		@uId_Cuahang,
		@v_Makho,
		@nv_Tenkho_vn,
		@nv_Tenkho_en,
		@Id_Phongsudung
	) 
	select @uId_kho
END 
