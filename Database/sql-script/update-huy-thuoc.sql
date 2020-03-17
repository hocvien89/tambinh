alter table QLMH_Phieuxuat_chitiet 
add b_Hoanthuoc bit

create proc udp_phieu_xuat_chi_tiet_hoan_thuoc
@uId_Phieuxuat_Chitiet varchar(50),
@uId_Nhanvien varchar(50)
as
begin
	declare @Tongtien float;
	set @Tongtien = (select f_Tongtien from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet);
	update QLMH_PHIEUXUAT_CHITIET set b_Hoanthuoc = 1 where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet;
	update QLMH_PHIEUXUAT set f_Tongtienthuc = f_Tongtienthuc- @Tongtien 
	where uId_Phieuxuat in (select uId_Phieuxuat from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet)
	and f_Tongtienthuc > @Tongtien;
end

ALTER PROCEDURE [dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectByIDPX]
(
	@uId_Phieuxuat as uniqueidentifier
)
AS
BEGIN
	SELECT    dbo.QLMH_PHIEUXUAT_CHITIET.uId_Phieuxuat_Chitiet, 
			  dbo.QLMH_DM_MATHANG.nv_TenMathang_vn, 
			  dbo.QLMH_DM_MATHANG.nv_DVT_vn, 
              dbo.QLMH_PHIEUXUAT_CHITIET.f_Soluong, 
			  dbo.QLMH_PHIEUXUAT_CHITIET.f_Dongia,
              dbo.QLMH_PHIEUXUAT_CHITIET.f_Giamgia, 
              dbo.QLMH_PHIEUXUAT_CHITIET.f_Tongtien, 
              ISNULL(dbo.QLMH_PHIEUXUAT_CHITIET.nv_Ghichu,'') as nv_Ghichu,
			  nv_Ghichu_vn,
              dv.tendonvi,
			  case when b_Hoanthuoc is null then 0 else b_Hoanthuoc end as b_Hoanthuoc
FROM         dbo.QLMH_PHIEUXUAT_CHITIET INNER JOIN
             dbo.QLMH_DM_MATHANG ON dbo.QLMH_PHIEUXUAT_CHITIET.uId_Mathang = dbo.QLMH_DM_MATHANG.uId_Mathang
			LEFT JOIN DMDonvi dv ON  dbo.QLMH_PHIEUXUAT_CHITIET.MADONVI = dv.madonvi
	WHERE 
		[uId_Phieuxuat]=@uId_Phieuxuat
END 
