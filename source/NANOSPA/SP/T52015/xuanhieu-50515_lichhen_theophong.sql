alter proc spLichhen_SelectByPhong
@nv_Tenphong_vn as nvarchar(50)=N'Phòng Laser'
as
	begin
		if (@nv_Tenphong_vn='tatca')
			begin
				select * from Appointments
			end
		else
			begin
				select *,nv_Tenphong_vn from Appointments app, QLP_DM_PHONG dmp, PQP_NHANVIEN_PHONG pnv, QT_DM_NHANVIEN nv
				where app.uId_Nhanvien=pnv.uId_Nhanvien
				and pnv.uId_Nhanvien=nv.uId_Nhanvien
				and pnv.uId_Phongban=dmp.uId_Phong
				and dmp.nv_Tenphong_vn=@nv_Tenphong_vn
			end
	end
go
