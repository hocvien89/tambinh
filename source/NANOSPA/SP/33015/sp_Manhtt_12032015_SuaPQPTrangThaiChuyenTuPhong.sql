--ALTER TABLE PQP_TRANGTHAIKHCHOXULY
--ADD uId_Phongchuyen uniqueidentifier
--GO

ALTER PROCEDURE [dbo].[spPQP_TRANGTHAIKHCHOXULY_Insert]
(
	@uId_Trangthai as nvarchar(50) ,
	@d_Ngay as datetime = null,
	@uId_Phong as nvarchar(50) ,
	@uId_Phieudichvu AS NVARCHAR(50),
	@nv_GhiChu as nvarchar(1000),
	@uId_Phongchuyen as varchar(50)
)
AS
BEGIN
	INSERT INTO PQP_TRANGTHAIKHCHOXULY
	(
		uId_Trangthai,
		d_Ngay,
		uId_Phong,
		uId_Phieudichvu,
		nv_GhiChu,
		uId_Phongchuyen
	)
	VALUES
	(
		@uId_Trangthai,
		@d_Ngay,
		@uId_Phong,
		@uId_Phieudichvu,
		@nv_GhiChu,
		@uId_Phongchuyen
	) 
END 
GO