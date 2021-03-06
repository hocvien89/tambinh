



ALTER PROCEDURE [dbo].[spQT_DM_NHANVIEN_Insert]
(

	@v_Barcode as varchar(20) = null,
	@v_Manhanvien as varchar(20) = null,
	@nv_Hoten_vn as nvarchar(100) = null,
	@nv_Hoten_en as nvarchar(100) = null,
	@d_Ngaysinh as datetime = null,
	@nv_Chucvu_vn as nvarchar(100) = null,
	@nv_Chucvu_en as nvarchar(100) = null,
	@nv_Diachi_vn as nvarchar(100) = null,
	@nv_Diachi_en as nvarchar(100) = null,
	@nv_Quequan_vn as nvarchar(100) = null,
	@nv_Quequan_en as nvarchar(100) = null,
	@v_Dienthoai as varchar(30) = null,
	@v_Email as varchar(30) = null,
	@v_Tendangnhap as varchar(30) = null,
	@v_Matkhau as varchar(30) = null,
	@b_ActiveLogin as bit = null,
	@d_Ngayvaolam as datetime = null,
	@b_Danglamviec as bit = null,
	@b_Loai as bit
)
AS
if	@b_Loai=1
BEGIN
	Declare @uId_Nhanvien uniqueidentifier;
	set @uId_Nhanvien  = NEWID();
	INSERT INTO [dbo].[QT_DM_NHANVIEN]
	(
		[uId_Nhanvien] ,
		[v_Barcode],
		[v_Manhanvien],
		[nv_Hoten_vn],
		[nv_Hoten_en],
		[d_Ngaysinh],
		[nv_Chucvu_vn],
		[nv_Chucvu_en],
		[nv_Diachi_vn],
		[nv_Diachi_en],
		[nv_Quequan_vn],
		[nv_Quequan_en],
		[v_Dienthoai],
		[v_Email],
		[v_Tendangnhap],
		[v_Matkhau],
		[b_ActiveLogin],
		[d_Ngayvaolam],
		[b_Danglamviec]
	) 
	VALUES
	(
		@uId_Nhanvien ,
		@v_Barcode,
		@v_Manhanvien,
		@nv_Hoten_vn,
		@nv_Hoten_en,
		@d_Ngaysinh,
		@nv_Chucvu_vn,
		@nv_Chucvu_en,
		@nv_Diachi_vn,
		@nv_Diachi_en,
		@nv_Quequan_vn,
		@nv_Quequan_en,
		@v_Dienthoai,
		@v_Email,
		@v_Tendangnhap,
		@v_Matkhau,
		@b_ActiveLogin,
		@d_Ngayvaolam,
		@b_Danglamviec
	) 
	select @uId_Nhanvien
	INSERT INTO [dbo].[Resources]
           ([ResourceID]
           ,[ResourceName]
         
           ,[CustomField1])
     VALUES
           (isnull((select MAX(ResourceID) from Resources),0) +1
           ,@nv_Hoten_vn
           
           ,@uId_Nhanvien)
END 
else 
BEGIN
	
	set @uId_Nhanvien  = NEWID();
	INSERT INTO [dbo].[QT_DM_NHANVIEN]
	(
		[uId_Nhanvien] ,
		[v_Barcode],
		[v_Manhanvien],
		[nv_Hoten_vn],
		[nv_Hoten_en],
		[d_Ngaysinh],
		[nv_Chucvu_vn],
		[nv_Chucvu_en],
		[nv_Diachi_vn],
		[nv_Diachi_en],
		[nv_Quequan_vn],
		[nv_Quequan_en],
		[v_Dienthoai],
		[v_Email],
		[v_Tendangnhap],
		[v_Matkhau],
		[b_ActiveLogin],
		[d_Ngayvaolam],
		[b_Danglamviec]
	) 
	VALUES
	(
		@uId_Nhanvien ,
		@v_Barcode,
		@v_Manhanvien,
		@nv_Hoten_vn,
		@nv_Hoten_en,
		@d_Ngaysinh,
		@nv_Chucvu_vn,
		@nv_Chucvu_en,
		@nv_Diachi_vn,
		@nv_Diachi_en,
		@nv_Quequan_vn,
		@nv_Quequan_en,
		@v_Dienthoai,
		@v_Email,
		@v_Tendangnhap,
		@v_Matkhau,
		@b_ActiveLogin,
		@d_Ngayvaolam,
		@b_Danglamviec
	) 
	select @uId_Nhanvien
	end







