drop proc spMKT_KHACHHANG_SelectUutien
go
create proc spMKT_KHACHHANG_SelectUutien
@Tungay as datetime='1/1/2012',
@Denngay as datetime='12/12/2015',
@type as varchar(10)= '1',
@uId_Cuahang as nvarchar(50)='24E1A59B-F645-4240-9A31-D91A90E58793'
as
	begin 
	if @type ='0'
		begin
		select	tn.uId_KH_Tiemnang, tn.uId_Khachhang,pdv.uId_Phieudichvu, kh.v_Makhachang as v_Makhachhang, 
		kh.nv_Hoten_vn, dt.d_Ngaydieutri as d_Ngay, kh.d_Ngaysinh, tn.v_DienthoaiDD, tn.v_Email, tn.Ghichu,
		tn.nv_Diachi_vn,cd.uId_Chuyendoi
		from CRM_DM_Khachhang kh, TNTP_PHIEUDICHVU pdv,MKT_KH_TIEMNANG tn,
			TNTP_PHIEUDICHVU_CHITIET pct, TNTP_QT_Dieutri dt, QT_DM_CUAHANG ch, MKT_Chuyendoi cd
		where  kh.uId_Khachhang=pdv.uId_Khachhang 
		and tn.uId_Khachhang=kh.uId_Khachhang
		and pdv.uId_Phieudichvu=pct.uId_Phieudichvu
		and pct.uId_Phieudichvu_Chitiet=dt.uId_Phieudichvu_Chitiet
		and cd.uId_KH_Tiemnang=tn.uId_KH_Tiemnang
		and @Tungay<=dt.d_Ngaydieutri and dt.d_Ngaydieutri<=@Denngay
		and tn.uId_Cuahang=ch.uId_Cuahang
		and tn.uId_Cuahang=@uId_Cuahang
		end
	else 
	if @type='1'
		begin
		select distinct tn.uId_KH_Tiemnang, tn.uId_Khachhang,	 tn.v_Makhachhang, tn.nv_Hoten_vn, pdv.d_Ngay,
		tn.d_Ngaysinh, tn.v_DienthoaiDD, tn.v_Email, tn.Ghichu, tn.nv_Diachi_vn,cd.uId_Chuyendoi
		from CRM_DM_Khachhang kh, TNTP_PHIEUDICHVU pdv,
		TNTP_PHIEUDICHVU_CHITIET pct, MKT_KH_TIEMNANG tn, QT_DM_CUAHANG ch, MKT_Chuyendoi cd
		where  kh.uId_Khachhang=pdv.uId_Khachhang 
		and tn.uId_Khachhang=kh.uId_Khachhang
		and tn.uId_Cuahang=ch.uId_Cuahang
		and cd.uId_KH_Tiemnang=tn.uId_KH_Tiemnang
		and @Tungay<=pdv.d_Ngay and pdv.d_Ngay<=@Denngay
		and tn.uId_Cuahang=@uId_Cuahang
		end
	end
go
				