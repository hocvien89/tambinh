---ALTER FUNCTION [dbo].[Get_TongDonGia_PDV](@uId_Phieudichvu uniqueidentifier)
RETURNS float
as
Begin
Declare @ValReturn float
declare @uIdgoi nvarchar(50)
set @uIdgoi=(select distinct isnull(cast(uId_Ngoaite as nvarchar(50)),'') from TNTP_PHIEUDICHVU_CHITIET where CAST(uId_Phieudichvu as nvarchar(50))=@uId_Phieudichvu )
begin
SELECT @ValReturn = sum(TNTP_PHIEUDICHVU_CHITIET.f_Tongtien)
	FROM TNTP_PHIEUDICHVU_CHITIET 
where TNTP_PHIEUDICHVU_CHITIET.uId_Phieudichvu = @uId_Phieudichvu
end
return @ValReturn 
End
go
-- bao cao chi tiet mat hang
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
		QLMH_PHIEUXUAT_CHITIET.f_Soluong * px.i_Sothang as f_Soluong ,
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
go
-- bao cao tong hop xuat
ALTER function [dbo].[get_SoluongXuat](@uId_Mathang as nvarchar(50), @d_Ngayxuat as datetime)
returns float
as
begin
declare @value float
select @value= SUM(f_Soluongnhonhat* i_Sothang) from QLMH_PHIEUXUAT_CHITIET pxct, QLMH_PHIEUXUAT px	
where uId_Mathang=@uId_Mathang and px.uId_Phieuxuat = pxct.uId_Phieuxuat and px.d_Ngayxuat=@d_Ngayxuat
return @value
end
go

ALTER function [dbo].[get_ThanhtienXuat](@uId_Mathang as nvarchar(50), @d_Ngayxuat as datetime)
returns float
as
begin
declare @value float
select @value= SUM(f_Tongtien * i_Sothang) from QLMH_PHIEUXUAT_CHITIET pxct, QLMH_PHIEUXUAT px	
where uId_Mathang=@uId_Mathang and px.uId_Phieuxuat = pxct.uId_Phieuxuat and px.d_Ngayxuat=@d_Ngayxuat
return @value
end
go