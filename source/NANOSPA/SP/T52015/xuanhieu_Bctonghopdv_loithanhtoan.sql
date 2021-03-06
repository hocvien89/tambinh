
ALTER PROCEDURE [dbo].[spBAOCAO_DoanhThuTongHop]
(
	@TuNgay as datetime ='5/19/2015', 
	@DenNgay as datetime= '5/19/2015',
	@uId_Cuahang as varchar(50)= '24e1a59b-f645-4240-9a31-d91a90e58793'
)
AS
BEGIN
	Select 
		TNTP_PHIEUDICHVU.uId_Phieudichvu ,
		TNTP_PHIEUDICHVU.uId_Khachhang ,
		CRM_DM_Khachhang.v_Makhachang,
		CRM_DM_Khachhang.nv_Hoten_vn ,
		TNTP_PHIEUDICHVU.d_Ngay ,
		dbo.Get_Tongtienthanhtoan_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) as tongdongia,
		(dbo.Get_Tonggiamgia_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) + dbo.Get_TongGiamGia_PDV_KH(TNTP_PHIEUDICHVU.uId_Phieudichvu)) as tonggiamgia,
		(dbo.Get_Tongtienthanhtoan_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) - (dbo.Get_Tonggiamgia_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) + dbo.Get_TongGiamGia_PDV_KH(TNTP_PHIEUDICHVU.uId_Phieudichvu))) as tongthanhtien,
		(ISNULL(TNTP_PHIEUDICHVU.f_Tongtienthuc,0) + ISNULL([dbo].[Get_TraNo_DV_Theongay](TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0)) as f_Tongtienthuc,
		--(((dbo.Get_Tongtienthanhtoan_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) - (dbo.Get_Tonggiamgia_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) + dbo.Get_TongGiamGia_PDV_KH(TNTP_PHIEUDICHVU.uId_Phieudichvu)))) - (ISNULL(TNTP_PHIEUDICHVU.f_Tongtienthuc,0) + ISNULL([dbo].[Get_TraNo_DV_Theongay](TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0)) - ISNULL(dbo.Get_Thanhtoankhac_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0)) as tienno,
		(((dbo.Get_Tongtienthanhtoan_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) - (dbo.Get_Tonggiamgia_PDVChitiet(TNTP_PHIEUDICHVU.uId_Phieudichvu) + dbo.Get_TongGiamGia_PDV_KH(TNTP_PHIEUDICHVU.uId_Phieudichvu)))) - (ISNULL(TNTP_PHIEUDICHVU.f_Tongtienthuc,0) + ISNULL([dbo].[Get_TraNo_DV_Theongay](TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0))) as tienno,
		(ISNULL(dbo.Get_Thanhtoantienmat_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu,@TuNgay, @DenNgay),0)) as tienmat,
		(ISNULL(dbo.Get_Thanhtoanchuyenkhoan_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu,@TuNgay, @DenNgay),0)) as chuyenkhoan,
		(ISNULL(dbo.Get_Thanhtoankhac_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0)) as ttkhac
	INTO #A
	From TNTP_PHIEUDICHVU 
	Inner join CRM_DM_Khachhang on CRM_DM_Khachhang.uId_Khachhang = TNTP_PHIEUDICHVU.uId_Khachhang 
	Left join QLCN_CONGNO on QLCN_CONGNO.uId_Phieudichvu = TNTP_PHIEUDICHVU.uId_Phieudichvu 
	Where @TuNgay <=d_Ngay  and d_Ngay<=@DenNgay
	AND TNTP_PHIEUDICHVU.uId_Cuahang = (CASE @uId_Cuahang when null then TNTP_PHIEUDICHVU.uId_Cuahang else @uId_Cuahang END)
	and TNTP_PHIEUDICHVU.b_IsPayed=1
	Order by d_Ngay desc,v_Sophieu desc
	
	Select uId_Khachhang,v_Makhachang,nv_Hoten_vn,Sum(tongdongia)As tongdongia, Sum(tonggiamgia) As tonggiamgia,Sum(tongthanhtien)As tongthanhtien, Sum(tienno)As tienno,Sum(f_Tongtienthuc) as f_Tongtienthuc,
	Sum(tienmat) as tienmat, Sum(chuyenkhoan) as chuyenkhoan, Sum(ttkhac) as ttkhac
	From #A
	Group by uId_Khachhang,nv_Hoten_vn,v_Makhachang
	order by v_Makhachang
END
