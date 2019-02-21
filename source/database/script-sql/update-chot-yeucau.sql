-- xoa ma don vi de lai thang,kg,gram
delete from dmdonvi where madonvi <>'gam' and madonvi<>'kg'
insert into DMDonvi(madonvi,tendonvi) values('thang','thang')

-- update bao cao chi tiet mat hang
ALTER PROCEDURE [dbo].[spBAOCAO_DoanhThu_Chitiet_SP]
(
	@uId_Khachhang as varchar(50) = '',
	@TuNgay as datetime = '2013-01-01', 
	@DenNgay as datetime = '2018-12-12',
	@uId_Cuahang as varchar(50)= '24E1A59B-F645-4240-9A31-D91A90E58793'
)
AS
BEGIN
	Select 
		px.uId_Phieuxuat ,
		px.uId_Khachhang ,
		px.v_Maphieuxuat as v_Sophieu ,
		px.d_Ngayxuat ,
		px.nv_Noidungxuat_vn  as nv_Ghichu_vn,
		CRM_DM_Khachhang.v_Makhachang,
		CRM_DM_Khachhang.nv_Hoten_vn ,
		CRM_DM_Khachhang.nv_Diachi_vn ,
		CRM_DM_Khachhang.v_DienthoaiDD ,
		CRM_DM_Khachhang .d_Ngaysinh ,
		ng.nv_Nguon_vn,
		QLMH_DM_MATHANG.nv_TenMathang_vn as dichvu, 
		QLMH_PHIEUXUAT_CHITIET.f_Dongia ,
		QLMH_PHIEUXUAT_CHITIET.f_Soluong ,
		QLMH_PHIEUXUAT_CHITIET.f_Tongtien * px.i_Sothang AS f_Tongtien ,
	   (px.f_Giamgia+QLMH_PHIEUXUAT_CHITIET.f_Giamgia+ ISNULL([dbo].[fc_Get_Giamgiathe_Tichdiem_PX](px.uId_Phieuxuat),0)) as tonggiamgia,
		px.f_Tongtienthuc,
		(dbo.Get_TongTiennhan_PXChitiet(px.uId_Phieuxuat) - (px.f_Tongtienthuc + px.f_Giamgia+ISNULL([dbo].[fc_Get_Giamgiathe_Tichdiem_PX](px.uId_Phieuxuat),0))) as tienno
		
	From QLMH_PHIEUXUAT px 
	Inner join QLMH_PHIEUXUAT_CHITIET on QLMH_PHIEUXUAT_CHITIET.uId_Phieuxuat = px.uId_Phieuxuat 
	Inner join QLMH_DM_MATHANG on QLMH_DM_MATHANG.uId_Mathang = QLMH_PHIEUXUAT_CHITIET.uId_Mathang
	INNER JOIN QLMH_DM_KHO kho ON px.uId_Kho = kho.uId_Kho
	Inner join CRM_DM_Khachhang on CRM_DM_Khachhang.uId_Khachhang = px.uId_Khachhang 
	inner join CRM_DM_Nguon ng on CRM_DM_Khachhang.uId_Nguonden= ng.uId_Nguon
	Left join QLCN_CONGNO_SP on QLCN_CONGNO_SP.uId_Phieuxuat = px.uId_Phieuxuat 
	Where @TuNgay <= px.d_Ngayxuat  and px.d_Ngayxuat<=@DenNgay 
	AND px.uId_Khachhang  = (case @uId_Khachhang when '' then px.uId_Khachhang else @uId_Khachhang END)
	AND kho.uId_Cuahang = (CASE @uId_Cuahang when null then kho.uId_Cuahang else @uId_Cuahang END)
	Order by d_Ngayxuat desc,px.v_Maphieuxuat desc
END

-- update ly do giam giam
alter table tntp_phieudichvu add nv_Lydogiamgia nvarchar(100)

ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_Update]
(
@uId_Phieudichvu as varchar(50),
@v_Sophieu as varchar(20) = null,
@d_Ngay as datetime = null,
@f_Tongtienthuc as float = null,
@f_Giamgia as float= null,
@d_Ngayketthuc as datetime =null,
@uId_LoaiTT as varchar(50),
@nv_Ghichu_vn as nvarchar(500) = null,
@uId_Nhanvien as varchar(50),
@HHPhieu as float,
@Id_Nhomphieu as int,
@b_IsKhoa as bit,
@b_IsPayed as bit,
@uId_Tuvan1 as nvarchar(50),
@uId_Tuvan2 as nvarchar(50),
@uId_Tuvan3 as nvarchar(50),
@uId_Tuvan varchar(50),
@f_Tuvan1 float ,
@f_Tuvan2 float ,
@f_Tuvan3 float,
@f_Hoahong float,
@uId_Dichvu1 as varchar(50),
@uId_Dichvu2 as varchar(50),
@uId_Dichvu3 as varchar(50),
@nv_Lydogiamgia as nvarchar(100)
)
AS
BEGIN
	UPDATE [dbo].[TNTP_PHIEUDICHVU]
	SET
		[v_Sophieu]=@v_Sophieu,
		[d_Ngay]=@d_Ngay,
		[f_Giamgia] = @f_Giamgia,
		[f_Tongtienthuc] = @f_Tongtienthuc,
		[d_Ngayketthuc] = @d_Ngayketthuc ,
		[uId_LoaiTT] = @uId_LoaiTT ,
		nv_Ghichu_vn = @nv_Ghichu_vn,
		[uId_Nhanvien] = @uId_Nhanvien,
		[HHPhieu] = @HHPhieu,
		[Id_Nhomphieu] = @Id_Nhomphieu,
		b_IsKhoa = @b_IsKhoa,
		b_IsPayed = @b_IsPayed,
		uId_Tuvan1=@uId_Tuvan1,
		uId_Tuvan2=@uId_Tuvan2,
		uId_Tuvan3=@uId_Tuvan3,
		uId_Nhanvien_Tuvan= @uId_Tuvan,
	    f_Tuvan1 =  @f_Tuvan1,
	    f_Tuvan2 =  @f_Tuvan2,
	    f_Tuvan3 =  @f_Tuvan3,
	    f_Hoahong_Tuvan=@f_Hoahong,
	    uId_Dichvu_1= @uId_Dichvu1,
	    uId_Dichvu_2 = @uId_Dichvu2,
	    uId_Dichvu_3=@uId_Dichvu3,
		nv_Lydogiamgia=@nv_Lydogiamgia
	WHERE 
		[uId_Phieudichvu] = @uId_Phieudichvu
END 

ALTER PROCEDURE [dbo].[spTNTP_PHIEUDICHVU_SelectByID]
(
	@uId_Phieudichvu as varchar(50) = '96D10513-3AE7-47DC-9E29-21751EA23030'
)
AS

BEGIN

	SELECT
		pdv.[uId_Phieudichvu],
		pdv.[uId_Khachhang],
		pdv.[v_Sophieu],
		pdv.[d_Ngay],
		pdv.[d_Ngayketthuc],
		pdv.[nv_Ghichu_vn],
		(str([dbo].[Get_TongDonGia_PDV](pdv.[uId_Phieudichvu])) + '$' + pdv.nv_Ghichu_en) as  nv_Ghichu_en,
		([dbo].[Get_Tonggiamgia_PDVChitiet](pdv.[uId_Phieudichvu]) + [dbo].[Get_TongGiamGia_PDV_KH](pdv.[uId_Phieudichvu]))as [f_Giamgia],
		ISNULL(f_Giamgia,0) as f_Giamgia_PDV,
		ISNULL(pdv.f_Tongtienthuc,0)+ ISNULL([dbo].[fc_Get_Congno_Thanhtoan_By_PDV](pdv.uId_Phieudichvu),0) as f_Tongthanhtoan,
		pdv.f_Tongtienthuc,
		pdv.uId_LoaiTT,
		pdv.uId_Nhanvien ,
		HHPhieu,
		Id_Nhomphieu,
		b_IsKhoa,
		b_IsPayed,
		nv_Lydogiamgia
	FROM [dbo].[TNTP_PHIEUDICHVU] pdv
	WHERE 
		pdv.[uId_Phieudichvu]=@uId_Phieudichvu 
end


-- UPDATE TEN CUA HANG VA DIA CHI
update QT_DM_CUAHANG 
set nv_Tencuahang_vn='PHÒNG KHÁM ĐÔNG Y TÂM BÌNH', 
nv_Diachi_vn='349 Kim Mã - Q. Ba Đình - Hà Nội',
v_Macuahang='BN'

