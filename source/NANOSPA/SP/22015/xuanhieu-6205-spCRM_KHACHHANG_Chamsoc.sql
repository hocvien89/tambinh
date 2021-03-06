drop proc spMKT_KH_ChamsocKH
go
create proc spMKT_KH_ChamsocKH
(
	@Tungay as datetime='2013-1-1',
	@Denngay as datetime='2015-12-12',
	@uId_Cuahang as nvarchar(50)='24E1A59B-F645-4240-9A31-D91A90E58793',
	@Loaikh as nvarchar(50)='hethong',
	@thamso as nvarchar(50)='notauto'
)
AS
BEGIN
if @thamso='auto' -- tu dong phan tiemnang va he thong
	begin
	if @Loaikh='tiemnang'
	begin
		SELECT v_Makhachhang,kh.nv_Hoten_vn,mkt.uId_KH_Tiemnang,kh.uId_Khachhang,
		convert(varchar,kh.d_Ngaysinh,103)as d_Ngaysinh,
		case kh.b_Gioitinh
		when 0 then N'Nữ'
		else N'Nam'
		end as Gioitinh,
		mkt.v_Email,
		Ghichu,
		uId_Chuyendoi,
		ch.nv_Tencuahang_vn,
		mkt.nv_Diachi_vn, kh.v_DienthoaiDD,d_Ngaynhap
		 FROM [MKT_KH_TIEMNANG] mkt
		INNER JOIN MKT_Chuyendoi mc ON mc.uId_KH_Tiemnang = mkt.uId_KH_Tiemnang
		inner join QT_DM_CUAHANG ch on ch.uId_Cuahang= mkt.uId_Cuahang
		inner join CRM_DM_Khachhang kh on mkt.uId_Khachhang=kh.uId_Khachhang
		WHERE @Tungay <= d_Ngaynhap AND d_Ngaynhap <=+ @Denngay
		and mkt.uId_Cuahang= (case @uId_Cuahang when ''then mkt.uId_Cuahang else @uId_Cuahang end)
		and dbo.funMKT_GetTrangthaiKHTL(kh.uId_Khachhang)=0
	end
else if @Loaikh='hethong'
	begin
		SELECT v_Makhachang as v_Makhachhang,kh.nv_Hoten_vn,kh.uId_Khachhang , mkt.uId_KH_Tiemnang ,
		convert(varchar,kh.d_Ngaysinh,103)as d_Ngaysinh,
		case kh.b_Gioitinh
		when 0 then N'Nữ'
		else N'Nam'
		end as Gioitinh,
		kh.v_Email,
		nv_Ghichu_vn as Ghichu,
		nv_Tencuahang_vn,
		kh.nv_Diachi_vn, kh.v_DienthoaiDD,d_Ngayden as d_Ngaynhap, uId_Chuyendoi
		 FROM CRM_DM_Khachhang kh
		 inner join QT_DM_CUAHANG ch on ch.uId_Cuahang=kh.uId_Cuahang
		 inner join MKT_KH_TIEMNANG mkt on mkt.uId_Khachhang= kh.uId_Khachhang
		 inner join MKT_Chuyendoi cd on cd.uId_KH_Tiemnang=mkt.uId_KH_Tiemnang
		WHERE @Tungay <= d_Ngayden AND d_Ngayden <= @Denngay
		and kh.uId_Cuahang= (case @uId_Cuahang when ''then kh.uId_Cuahang else @uId_Cuahang end)
		and dbo.funMKT_GetTrangthaiKHTL(kh.uId_Khachhang)=1
	end
	end
else
	begin
	if @Loaikh='tiemnang'
	begin
		SELECT v_Makhachhang,kh.nv_Hoten_vn,mkt.uId_KH_Tiemnang,mkt.uId_Khachhang,
		convert(varchar,kh.d_Ngaysinh,103)as d_Ngaysinh,
		case kh.b_Gioitinh
		when 0 then N'Nữ'
		else N'Nam'
		end as Gioitinh,
		mkt.v_Email,
		Ghichu,
		uId_Chuyendoi,
		ch.nv_Tencuahang_vn,
		mkt.nv_Diachi_vn, kh.v_DienthoaiDD,d_Ngaynhap
		 FROM [MKT_KH_TIEMNANG] mkt
		INNER JOIN MKT_Chuyendoi mc ON mc.uId_KH_Tiemnang = mkt.uId_KH_Tiemnang
		inner join QT_DM_CUAHANG ch on ch.uId_Cuahang= mkt.uId_Cuahang
		inner join CRM_DM_Khachhang kh on mkt.uId_Khachhang=kh.uId_Khachhang
		WHERE @Tungay <= d_Ngaynhap AND d_Ngaynhap <=+ @Denngay
		and cast(mkt.uId_Cuahang as nvarchar(50))= (case @uId_Cuahang when ''then mkt.uId_Cuahang else @uId_Cuahang end)
		and cast(mkt.uId_KH_Tiemnang as nvarchar(50)) in (select uId_KH_Tiemnang from MKT_Chuyendoi where uId_TrangthaiKH='E7EB1051-54A3-4915-BB7C-0971BE06BE33')
	end
else if @Loaikh='hethong'
	begin
		SELECT v_Makhachang as v_Makhachhang,mkt.nv_Hoten_vn,kh.uId_Khachhang , mkt.uId_KH_Tiemnang ,
		convert(varchar,mkt.d_Ngaysinh,103)as d_Ngaysinh,
		case mkt.b_Gioitinh
		when 0 then N'Nữ'
		else N'Nam'
		end as Gioitinh,
		kh.v_Email,
		nv_Ghichu_vn as Ghichu,
		nv_Tencuahang_vn,
		kh.nv_Diachi_vn, mkt.v_DienthoaiDD,d_Ngayden as d_Ngaynhap, uId_Chuyendoi
		 FROM CRM_DM_Khachhang kh
		 inner join QT_DM_CUAHANG ch on ch.uId_Cuahang=kh.uId_Cuahang
		 inner join MKT_KH_TIEMNANG mkt on kh.uId_Khachhang=mkt.uId_KH_Tiemnang
		  inner join MKT_Chuyendoi cd on cd.uId_KH_Tiemnang=mkt.uId_KH_Tiemnang
		WHERE @Tungay <= d_Ngayden AND d_Ngayden <= @Denngay
		and cast(kh.uId_Cuahang as nvarchar(50))= (case @uId_Cuahang when ''then kh.uId_Cuahang else @uId_Cuahang end)
		and cast(mkt.uId_KH_Tiemnang as nvarchar(50)) not in (select uId_KH_Tiemnang from MKT_Chuyendoi where uId_TrangthaiKH='E7EB1051-54A3-4915-BB7C-0971BE06BE33')
	end
	end

END
go
