
ALTER proc [dbo].[spBaocao_QLMH_Tonghopxuat]
@d_Tungay as datetime='11/29/2014',
@d_Denngay as datetime='12/1/2015',
@uId_Kho as nvarchar(50)=''
as
begin
select  mh.v_MaMathang,
				mh.nv_TenMathang_vn, 
				[dbo].[get_SoluongXuat](pxct.uId_Mathang, px.d_Ngayxuat) as soluong,tendonvi,
				pxct.f_Dongia,
				[dbo].[get_ThanhtienXuat](pxct.uId_Mathang, px.d_Ngayxuat) as thanhtien,
				convert(nvarchar(10),px.d_Ngayxuat,103) as d_Ngayxuat
	from QLMH_PHIEUXUAT_CHITIET pxct, QLMH_DM_MATHANG mh, QLMH_PHIEUXUAT px, DMDonvi dv,
		 DMQuyDoiDonVi qddv, CRM_DM_Khachhang kh
	where pxct.uId_Phieuxuat=px.uId_Phieuxuat
			and dv.madonvi=qddv.MaDonVi1 and qddv.MaVatTu=pxct.uId_Mathang
			and pxct.uId_Mathang=mh.uId_Mathang 
			and px.uId_Kho=(case @uId_Kho when '' then px.uId_Kho else @uId_Kho end)
			and @d_Tungay <= px.d_Ngayxuat and px.d_Ngayxuat <= @d_Denngay  			
	group by d_Ngayxuat, v_MaMathang, nv_TenMathang_vn, pxct.uId_Mathang, tendonvi, f_Dongia
	order by d_Ngayxuat
end
