drop proc [dbo].[spPQP_DM_PHONGBAN_SelectByID]
go
create proc [dbo].[spPQP_DM_PHONGBAN_SelectByID]
@uId_Phongban as nvarchar(50)='24e1a59b-f645-4240-9a31-d91a90e58793'
as
begin 
	declare @st  nvarchar(500)
	begin 
		set @st= 'select uId_Phong as uId_Phongban, 
		nv_Tenphong_vn as nv_Tenphongban_vn,
		nv_Tenphong_en as nv_Tenphongban_en,
		QT_DM_CUAHANG.uId_cuahang,
		v_Dienthoai,
		nv_Tencuahang_vn
		from QLP_DM_PHONG 
		inner join QT_DM_CUAHANG on QLP_DM_PHONG.uId_Cuahang = QT_DM_CUAHANG.uId_Cuahang'
	end
	begin
		if @uId_Phongban <> ''
		set @st+= ' where QLP_DM_PHONG.uId_Phong = '''+ @uId_Phongban+''''
	end
	print @st
	exec (@st)
end
