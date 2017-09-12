
ALTER proc [dbo].[spTTV_DM_THETICHDIEM_LICHSU_SelectAllTable]
@uId_KH_The as nvarchar(50)='688DAD77-308F-4D8C-993E-580CB79F1958'
as
begin
 select nv_Noidung,d_Ngaythuchien,
 case b_Luachon when 1 then N'Cộng Điểm' 
  else N'Trừ điểm'
  end as luachon,f_Diem,nv.nv_Hoten_vn, uId_Lichsutichdiem from TTV_KH_THETICDIEM_LICHSU ls, QT_DM_NHANVIEN nv
 where ls.uId_KH_The=@uId_KH_The and ls.uId_Nhanvien=nv.uId_Nhanvien
 end 
