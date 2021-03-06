


ALTER PROCEDURE [dbo].[spMKT_KH_TIEMNANG_SELECTALL_V1]
(
	@Tungay as datetime = '1/1/2012',
	@Denngay as datetime = '12/12/2015',
	@Type as varchar(10) = '1',
	@uId_Phong as nvarchar(50)='4586B88C-794B-4277-A661-101B5A00EE43'
)
AS
BEGIN
	IF @Type = '1'
	BEGIN
		SELECT mkt.uId_KH_Tiemnang,
		mkt.uId_Khachhang,
		mkt.v_Makhachhang,
		mkt.nv_Hoten_vn,
		mkt.d_Ngaysinh,
		mkt.nv_Diachi_vn,
		mkt.v_DienthoaiDD,
		mkt.v_Email,
		mkt.d_Ngaynhap,
		mkt.Ghichu
		, dbo.Fn_MKT_GETIDTangThai(mkt.uId_KH_Tiemnang) as uId_Chuyendoi, ch.nv_Tencuahang_vn ,pb.nv_Tenphong_vn
		FROM MKT_KH_TIEMNANG mkt,
		QT_DM_CUAHANG ch,
		QT_DM_NHANVIEN nv,
		QLP_DM_PHONG pb,
		PQP_NHANVIEN_PHONG nvp
		WHERE @Tungay <= mkt.d_Ngaynhap AND mkt.d_Ngaynhap <= @Denngay 
		and mkt.uId_Cuahang=ch.uId_Cuahang
		and mkt.nv_Diachi_en= nv.uId_Nhanvien
		and nv.uId_Nhanvien=nvp.uId_Nhanvien
		and pb.uId_Phong=nvp.uId_Phongban
		and pb.uId_Phong=@uId_Phong
		ORDER BY mkt.d_Ngaynhap
	END
END
