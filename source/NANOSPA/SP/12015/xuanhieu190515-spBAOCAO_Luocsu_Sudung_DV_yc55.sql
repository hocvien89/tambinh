drop proc [dbo].[spBAOCAO_Luocsu_Sudung_DV]
go
create PROCEDURE [dbo].[spBAOCAO_Luocsu_Sudung_DV]
(
	@uId_Khachhang as varchar(50)='',
	@TuNgay as datetime='1/1/2014', 
	@DenNgay as datetime ='1/1/2015',
	@uId_Cuahang as varchar(50)=null
)
AS
BEGIN
	Select 
		TNTP_PHIEUDICHVU.uId_Phieudichvu ,
		TNTP_PHIEUDICHVU.uId_Khachhang ,
		TNTP_PHIEUDICHVU.v_Sophieu ,
		TNTP_PHIEUDICHVU.d_Ngay ,
		TNTP_PHIEUDICHVU.nv_Ghichu_vn ,
		CRM_DM_Khachhang.v_Makhachang,
		CRM_DM_Khachhang.nv_Hoten_vn ,
		CRM_DM_Khachhang.nv_Diachi_vn ,
		CRM_DM_Khachhang.v_DienthoaiDD ,
		CRM_DM_Khachhang .d_Ngaysinh ,
		TNTP_DM_DICHVU.nv_Tendichvu_vn as dichvu, 
		TNTP_PHIEUDICHVU_CHITIET.f_Dongia ,
		TNTP_PHIEUDICHVU_CHITIET.f_Soluong ,
		TNTP_PHIEUDICHVU_CHITIET.f_Giamgia ,
		TNTP_PHIEUDICHVU_CHITIET.f_Soluong* TNTP_PHIEUDICHVU_CHITIET.f_Dongia as f_Tongtien,
		TNTP_PHIEUDICHVU.f_Giamgia as giam,

		(isnull(dbo.Get_Tonggiamgia_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu),0)) as tonggiamgia,
		--(ISNULL(TNTP_PHIEUDICHVU.f_Tongtienthuc,0) + ISNULL([dbo].[Get_TraNo_PDV](TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0)) as f_Tongtienthuc,
		--([dbo].[Get_Tongtienthanhtoan_PDVChitiet](TNTP_PHIEUDICHVU.uId_Phieudichvu) - 
		--(isnull(dbo.Get_Tonggiamgia_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu),0) + 
		--ISNULL(TNTP_PHIEUDICHVU.f_Tongtienthuc,0) + 
		--ISNULL([dbo].[Get_TraNo_PDV](TNTP_PHIEUDICHVU.uId_Phieudichvu, @TuNgay, @DenNgay),0))) as tienno
			QLCN_CONGNO.f_Sotien as tienno,
		isnull([dbo].[Get_Tongtienthanhtoan_PDVChitiet](TNTP_PHIEUDICHVU.uId_Phieudichvu),0)-(isnull(QLCN_CONGNO.f_Sotien,0) +isnull(dbo.Get_Tonggiamgia_PDV(TNTP_PHIEUDICHVU.uId_Phieudichvu),0))  as f_Tongtienthuc
	From TNTP_PHIEUDICHVU 
	Inner join TNTP_PHIEUDICHVU_CHITIET on TNTP_PHIEUDICHVU_CHITIET .uId_Phieudichvu = TNTP_PHIEUDICHVU.uId_Phieudichvu 
	Inner join TNTP_DM_DICHVU on TNTP_DM_DICHVU.uId_Dichvu = TNTP_PHIEUDICHVU_CHITIET.uId_Dichvu 
	Inner join CRM_DM_Khachhang on CRM_DM_Khachhang.uId_Khachhang = TNTP_PHIEUDICHVU.uId_Khachhang
	Left join QLCN_CONGNO on QLCN_CONGNO.uId_Phieudichvu = TNTP_PHIEUDICHVU.uId_Phieudichvu 
	Where @TuNgay <=d_Ngay  and d_Ngay<=@DenNgay 
	AND TNTP_PHIEUDICHVU.uId_Khachhang  = (case @uId_Khachhang when '' then TNTP_PHIEUDICHVU.uId_Khachhang else @uId_Khachhang END)
	AND TNTP_PHIEUDICHVU.uId_Cuahang = (CASE @uId_Cuahang when null then TNTP_PHIEUDICHVU.uId_Cuahang else @uId_Cuahang END)
	Order by d_Ngay desc,v_Sophieu desc
END