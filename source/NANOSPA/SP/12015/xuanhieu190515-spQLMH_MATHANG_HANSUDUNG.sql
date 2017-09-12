
drop proc spQLMH_MATHANG_HANSUDUNG
go
create proc spQLMH_MATHANG_HANSUDUNG
@uId_Cuahang nvarchar(50)='24E1A59B-F645-4240-9A31-D91A90E58793',
@uId_Kho nvarchar(50)='18A906D7-E63C-459C-BA81-B85D1A01F2EA'
as
begin
	if @uId_Cuahang=''
		if @uId_Kho =''
			select uId_Phieunhap_Chitiet, mh.nv_TenMathang_vn, dv.tendonvi,mh.v_MaMathang, 
					pnct.d_NgayhethanSD, pn.v_Maphieunhap,pn.d_Ngaynhap
			from QLMH_PHIEUNHAP pn, QLMH_PHIEUNHAP_CHITIET pnct, DMDonvi dv, QLMH_DM_MATHANG mh, QLMH_DM_KHO kho
			where pn.uId_Phieunhap=pnct.uId_Phieunhap and pnct.uId_Mathang=mh.uId_Mathang
			and dv.madonvi=pnct.MADONVI and kho.uId_Kho=pn.uId_Kho
		else
			select uId_Phieunhap_Chitiet, mh.nv_TenMathang_vn, dv.tendonvi,mh.v_MaMathang, 
					pnct.d_NgayhethanSD, pn.v_Maphieunhap,pn.d_Ngaynhap
			from QLMH_PHIEUNHAP pn, QLMH_PHIEUNHAP_CHITIET pnct, DMDonvi dv, QLMH_DM_MATHANG mh, QLMH_DM_KHO kho
			where pn.uId_Phieunhap=pnct.uId_Phieunhap and pnct.uId_Mathang=mh.uId_Mathang
			and dv.madonvi=pnct.MADONVI and kho.uId_Kho=pn.uId_Kho and pn.uId_Kho=@uId_Kho
	else
		if @uId_Kho =''
			select uId_Phieunhap_Chitiet, mh.nv_TenMathang_vn, dv.tendonvi,mh.v_MaMathang, 
					pnct.d_NgayhethanSD, pn.v_Maphieunhap,pn.d_Ngaynhap
			from QLMH_PHIEUNHAP pn, QLMH_PHIEUNHAP_CHITIET pnct, DMDonvi dv, QLMH_DM_MATHANG mh, 
			QLMH_DM_KHO kho, QT_DM_CUAHANG ch
			where pn.uId_Phieunhap=pnct.uId_Phieunhap and pnct.uId_Mathang=mh.uId_Mathang
			and dv.madonvi=pnct.MADONVI and kho.uId_Kho=pn.uId_Kho and kho.uId_Cuahang=ch.uId_Cuahang
			and ch.uId_Cuahang=@uId_Cuahang
		else
			select uId_Phieunhap_Chitiet, mh.nv_TenMathang_vn, dv.tendonvi,mh.v_MaMathang, 
					pnct.d_NgayhethanSD, pn.v_Maphieunhap,pn.d_Ngaynhap
			from QLMH_PHIEUNHAP pn, QLMH_PHIEUNHAP_CHITIET pnct, DMDonvi dv, QLMH_DM_MATHANG mh, 
			QLMH_DM_KHO kho, QT_DM_CUAHANG ch
			where pn.uId_Phieunhap=pnct.uId_Phieunhap and pnct.uId_Mathang=mh.uId_Mathang
			and dv.madonvi=pnct.MADONVI and kho.uId_Kho=pn.uId_Kho and pn.uId_Kho=@uId_Kho
			and ch.uId_Cuahang=kho.uId_Cuahang and pn.uId_Kho=@uId_Kho and ch.uId_Cuahang=@uId_Cuahang
			
end
go