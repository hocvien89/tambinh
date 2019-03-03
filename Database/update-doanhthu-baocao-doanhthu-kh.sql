
ALTER function [dbo].[fc_Get_Tongtien_PX]
(
  @uId_Phieuxuat varchar(50)
)
Returns float
as
Begin
   Declare @f_Tongtien float 
   Declare @f_Giamgia float
   SET @f_Tongtien= ISNULL((Select SUM(px_ct.f_Tongtien) from QLMH_PHIEUXUAT px inner join QLMH_PHIEUXUAT_CHITIET px_ct on px.uId_Phieuxuat=px_ct.uId_Phieuxuat where px.uId_Phieuxuat= @uId_Phieuxuat),0)
   SET @f_Giamgia = ISNULL((Select f_Giamgia from QLMH_PHIEUXUAT where uId_Phieuxuat=@uId_Phieuxuat),0)
   SET @f_Tongtien= @f_Tongtien-@f_Giamgia
   Return @f_Tongtien
End
