drop proc spQLMH_DM_KHO_UpdatePhongsudung
go
create proc spQLMH_DM_KHO_UpdatePhongsudung
@Id_Phongsudung as nvarchar(700),
@uId_Kho as nvarchar(50),
@uId_Cuahang as nvarchar(50)
as
 begin 
  update QLMH_DM_KHO set Id_Phongsudung=@Id_Phongsudung, uId_Cuahang=@uId_Cuahang
  where uId_Kho=@uId_Kho
 end
go