
ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_CHITIET_Insert]
(
	@uId_Phieudichvu as varchar(50) ,
	@uId_Dichvu as varchar(50) ,
	@uId_Ngoaite as varchar(50),
	@f_Solan as float = null,
	@f_Soluong as float = null,
	@f_Dongia as float = null,
	@f_Giamgia as float = null,
	@f_Tongtien as float = NULL,
	@uId_Nhanvien AS NVARCHAR(50),
	@b_BaoHanh AS BIT	
)
AS
BEGIN
set @f_Tongtien = @f_Dongia -@f_Giamgia
	INSERT INTO [dbo].[TNTP_PHIEUDICHVU_CHITIET]
	(
		[uId_Phieudichvu],
		[uId_Dichvu],
		[uId_Ngoaite],
		f_Solan,
		[f_Soluong],
		[f_Dongia],
		[f_Giamgia],
		[f_Tongtien],
		uId_Nhanvien,
		b_BaoHanh,
		b_Trangthai

	) 
	VALUES
	(
		@uId_Phieudichvu,
		@uId_Dichvu,
		@uId_Ngoaite,
		@f_Solan,
		@f_Soluong,
		@f_Dongia,
		@f_Giamgia,
		@f_Tongtien,
		@uId_Nhanvien,
		@b_BaoHanh,
		0
	) 
END
