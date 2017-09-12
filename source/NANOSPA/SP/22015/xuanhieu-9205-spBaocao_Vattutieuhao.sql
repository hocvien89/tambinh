drop proc spBaocao_Vattutieuhao
go
create proc spBaocao_Vattutieuhao
@Tungay as datetime ='1/1/2014',
@Denngay as datetime ='1/1/2016',
@uId_Kho as nvarchar(50)=''
as
begin
	select v_Makhachang, nv_Hoten_vn, v_Sophieu,
	nv_Tendichvu_vn, nv_TenMathang_vn,
	nv_Tenkho_vn,
	convert(varchar(10),d_Ngaydieutri,103) as d_Ngaydieutri,
	f_SLTieuhao, tendonvi
	from CRM_DM_Khachhang kh, TNTP_PHIEUDICHVU pdv, TNTP_PHIEUDICHVU_CHITIET pct, 
	TNTP_QT_Dieutri dt, QLMH_VATTUTIEUHAO_QT_DIEUTRI vtth,
	QLMH_DM_MATHANG mh, TNTP_DM_DICHVU dv,
	DMDonvi dmdv,
	QLMH_DM_KHO kho
	where kh.uId_Khachhang=pdv.uId_Khachhang
	and pdv.uId_Phieudichvu=pct.uId_Phieudichvu
	and pct.uId_Phieudichvu_Chitiet=dt.uId_Phieudichvu_Chitiet
	and dt.uId_QT_Dieutri=vtth.uId_QT_Dieutri
	and pct.uId_Dichvu=dv.uId_Dichvu
	and vtth.uId_Mathang=mh.uId_Mathang
	and dmdv.madonvi=vtth.MADONVI
	and kho.uId_Kho=vtth.uId_Kho
	and @Tungay<=dt.d_Ngaydieutri and dt.d_Ngaydieutri<=@Denngay
	and vtth.uId_Kho=(case @uId_Kho when '' then vtth.uId_Kho else @uId_Kho end)
	order by nv_Hoten_vn, v_Sophieu, nv_Tendichvu_vn, nv_TenMathang_vn
end
go