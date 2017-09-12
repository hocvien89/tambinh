alter proc spLichhen_SelectNhanvien_ByIdPhong
@uId_Phong as nvarchar(50)='',
@uId_Cuahang as nvarchar(50)='24E1A59B-F645-4240-9A31-D91A90E58793'
as
	begin
		if(@uId_Phong='')
			begin
				Select nv.uId_Nhanvien, nv_Hoten_vn, nv_Tenphong_vn from QT_DM_NHANVIEN nv, QLP_DM_PHONG dmp, PQP_NHANVIEN_PHONG nvp
				 where nv.uId_Nhanvien=nvp.uId_Nhanvien
				 and nvp.uId_Phongban=dmp.uId_Phong
				 and dmp.uId_Cuahang=@uId_Cuahang
			end
		else
			begin
				Select nv.uId_Nhanvien, nv_Hoten_vn, nv_Tenphong_vn from QT_DM_NHANVIEN nv, QLP_DM_PHONG dmp, PQP_NHANVIEN_PHONG nvp
				 where nv.uId_Nhanvien=nvp.uId_Nhanvien
				 and nvp.uId_Phongban=dmp.uId_Phong
				 and dmp.uId_Cuahang=@uId_Cuahang
				 and dmp.uId_Phong=@uId_Phong
			end
	end
go
