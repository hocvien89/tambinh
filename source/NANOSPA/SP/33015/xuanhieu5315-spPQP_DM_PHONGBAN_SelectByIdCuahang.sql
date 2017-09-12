drop proc spPQP_DM_PHONGBAN_SelectByIdCuahang
go
create proc spPQP_DM_PHONGBAN_SelectByIdCuahang
@uId_Cuahang as nvarchar(50)='24e1a59b-f645-4240-9a31-d91a90e58793'
as
begin 
	declare @st  nvarchar(500)
	begin 
		set @st= 'select uId_Phong, 
		nv_Tenphong_vn,
		nv_Tencuahang_vn
		from QLP_DM_PHONG 
		inner join QT_DM_CUAHANG on QLP_DM_PHONG.uId_Cuahang = QT_DM_CUAHANG.uId_Cuahang'
	end
	begin
		if @uId_Cuahang <> ''
		set @st+= ' where QLP_DM_PHONG.uId_Cuahang = '''+ @uId_Cuahang+''''
	end
	print @st
	exec (@st)
end
go