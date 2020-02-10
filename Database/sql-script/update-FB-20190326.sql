Create function [dbo].[fc_Get_Hoahong_Kythuat_Tuvan_By_Dichvu]
(
  @uId_Dichvu varchar(50)
)
Returns float
as
Begin
  declare @result float
  set @result = ISNULL((select f_PhantramHH_TVV from TNTP_DM_DICHVU where uId_Dichvu = @uId_Dichvu),0)
  Return @result
End

Go

alter table TNTP_PHIEUDICHVU_CHITIET add f_hoahong_tuvan float
Go

ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_Update]
(
@uId_Phieudichvu as varchar(50),
@v_Sophieu as varchar(20) = null,
@d_Ngay as datetime = null,
@f_Tongtienthuc as float = null,
@f_Giamgia as float= null,
@d_Ngayketthuc as datetime =null,
@uId_LoaiTT as varchar(50),
@nv_Ghichu_vn as nvarchar(500) = null,
@uId_Nhanvien as varchar(50),
@HHPhieu as float,
@Id_Nhomphieu as int,
@b_IsKhoa as bit,
@b_IsPayed as bit,
@uId_Tuvan1 as nvarchar(50),
@uId_Tuvan2 as nvarchar(50),
@uId_Tuvan3 as nvarchar(50),
@uId_Tuvan varchar(50),
@f_Tuvan1 float ,
@f_Tuvan2 float ,
@f_Tuvan3 float,
@f_Hoahong float,
@uId_Dichvu1 as varchar(50),
@uId_Dichvu2 as varchar(50),
@uId_Dichvu3 as varchar(50),
@nv_Lydogiamgia as nvarchar(100)
)
AS
BEGIN
	if @b_IsPayed = 1
			update TNTP_PHIEUDICHVU_CHITIET set f_hoahong_tuvan = ROUND([dbo].[fc_Get_Hoahong_Kythuat_Tuvan_By_Dichvu](uId_Dichvu),0)
			where uId_Phieudichvu = @uId_Phieudichvu
		UPDATE [dbo].[TNTP_PHIEUDICHVU]
	SET
		[v_Sophieu]=@v_Sophieu,
		[d_Ngay]=@d_Ngay,
		[f_Giamgia] = @f_Giamgia,
		[f_Tongtienthuc] = @f_Tongtienthuc,
		[d_Ngayketthuc] = @d_Ngayketthuc ,
		[uId_LoaiTT] = @uId_LoaiTT ,
		nv_Ghichu_vn = @nv_Ghichu_vn,
		[uId_Nhanvien] = @uId_Nhanvien,
		[HHPhieu] = @HHPhieu,
		[Id_Nhomphieu] = @Id_Nhomphieu,
		b_IsKhoa = @b_IsKhoa,
		b_IsPayed = @b_IsPayed,
		uId_Tuvan1=@uId_Tuvan1,
		uId_Tuvan2=@uId_Tuvan2,
		uId_Tuvan3=@uId_Tuvan3,
		uId_Nhanvien_Tuvan= @uId_Tuvan,
	    f_Tuvan1 =  @f_Tuvan1,
	    f_Tuvan2 =  @f_Tuvan2,
	    f_Tuvan3 =  @f_Tuvan3,
	    f_Hoahong_Tuvan=@f_Hoahong,
	    uId_Dichvu_1= @uId_Dichvu1,
	    uId_Dichvu_2 = @uId_Dichvu2,
	    uId_Dichvu_3=@uId_Dichvu3,
		nv_Lydogiamgia=@nv_Lydogiamgia
	WHERE 
		[uId_Phieudichvu] = @uId_Phieudichvu
END 
GO

ALTER function [dbo].[fc_Get_Luongtuvan_Nhanvien_Kythuat]
(
  @uId_Nhanvien varchar(50),
  @uId_Phieudichvu varchar(50),
  @Luachon int
)
Returns float
as
Begin
  Declare @f_Doanhso float
  Declare @_Check float
  set @f_Doanhso = ISNULL((select sum(pct.f_Tongtien)
  from TNTP_PHIEUDICHVU pdv 
  inner join TNTP_PHIEUDICHVU_CHITIET pct on pdv.uId_Phieudichvu = pct.uId_Phieudichvu 
  and pdv.uId_Phieudichvu =@uId_Phieudichvu 
  and pdv.uId_Nhanvien = @uId_Nhanvien),0)
  If @Luachon=1
  SET @_Check = @f_Doanhso
  if @Luachon=2 
  SET @_Check = 0
  Return @_Check
End
Go

ALTER function [dbo].[fc_Get_Hoahong_Kythuat_Tuvan_Dichvu]
(
  @uId_Nhanvien varchar(50),
  @uId_Phieudichvu varchar(50),
  @uId_Dichvu varchar(50),
  @Luachon int
)
Returns float
as
Begin
   Declare @f_Doanhso float
  Declare @_Check float
  set @f_Doanhso = ISNULL((select sum(pct.f_Tongtien)
  from TNTP_PHIEUDICHVU pdv 
  inner join TNTP_PHIEUDICHVU_CHITIET pct on pdv.uId_Phieudichvu = pct.uId_Phieudichvu 
  and pdv.uId_Phieudichvu =@uId_Phieudichvu 
  and pdv.uId_Nhanvien = @uId_Nhanvien
  and pct.uId_Dichvu =@uId_Dichvu),0)
  If @Luachon=1
  SET @_Check = @f_Doanhso
  if @Luachon=2 
  SET @_Check = 0
  Return @_Check
End

Go