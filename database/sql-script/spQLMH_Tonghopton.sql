USE [tambinh]
GO
/****** Object:  StoredProcedure [dbo].[spQLMH_TongHopTon]    Script Date: 3/9/2019 9:08:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create or ALTER PROCEDURE [dbo].[spQLMH_TongHopTon] 
(	
	@DenNgay as datetime = '12/12/2016',
	@uId_Kho as nvarchar(50) ='863E6794-35F4-4A81-9F13-DA95F7D25439',
	@uId_Cuahang as varchar(50) = '24e1a59b-f645-4240-9a31-d91a90e58793'
)
AS
BEGIN
	IF @uId_Kho = ''
	BEGIN
	delete from DMQuyDoiDonVi where MaVatTu not in(select cast(uId_Mathang as nvarchar(50)) from QLMH_DM_MATHANG)
	Select 
		mh.uId_Mathang ,
		v_MaMathang, 
		nv_TenMathang_vn, 
		nv_DVT_vn,
		dv.tendonvi,
		f_Hanmuc_Ton,
		[dbo].[Get_SL_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_Sl_Nhap,
		[dbo].[Get_GT_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_GT_Nhap,
		[dbo].[Get_SL_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_Sl_Xuat,
		[dbo].[Get_GT_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_GT_Xuat,
		--[dbo].[Get_SLMH_Tieuhao](QLMH_DM_MATHANG.uId_Mathang,@uId_Kho,@DenNgay) ,
		--dbo.Get_SL_Tieuhao_Thucong(QLMH_DM_MATHANG.uId_Mathang,@uId_Kho,@DenNgay) ,
		isnull([dbo].[Get_SLMH_Tieuhao](mh.uId_Mathang,@uId_Kho,@DenNgay),0) + isnull(dbo.Get_SL_Tieuhao_Thucong(mh.uId_Mathang,@uId_Kho,@DenNgay),0) as f_SLTieuhao,
		[dbo].[Get_SL_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) - [dbo].[Get_SL_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang)-isnull(dbo.Get_SL_Tieuhao_Thucong(mh.uId_Mathang,@uId_Kho,@DenNgay),0) - [dbo].[Get_SLMH_Tieuhao](mh.uId_Mathang,@uId_Kho,@DenNgay) as f_SL_Ton,
		[dbo].[Get_GT_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) - [dbo].[Get_GT_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_GT_Ton,
		kho.nv_Tenkho_vn
	From QLMH_DM_MATHANG mh
	LEFT JOIN DMQuyDoiDonVi qddv ON mh.uId_Mathang = qddv.MaVatTu
	LEFT JOIN DMDonvi dv ON qddv.MaDonVi1 = dv.madonvi
	INNER JOIN QLMH_DINHMUC_GIAMATHANG dmg ON mh.uId_Mathang = dmg.uId_Mathang
	--inner join QLMH_PHIEUNHAP_CHITIET pnct on pnct.uId_Mathang = mh.uId_Mathang
	--inner join QLMH_PHIEUNHAP pn on pn.uId_Phieunhap = pnct.uId_Phieunhap
	INNER JOIN QLMH_DM_KHO kho ON dmg.uId_Kho = kho.uId_Kho
	--Where [dbo].[Get_SL_Nhap_Phuongnm](uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) +[dbo].[Get_SL_Xuat_Phuongnm](uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang)+dbo.Get_SL_Tieuhao(uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang)>0
	Order by nv_TenMathang_vn
	END
	ELSE
	BEGIN
	delete from DMQuyDoiDonVi where MaVatTu not in(select cast(uId_Mathang as nvarchar(50)) from QLMH_DM_MATHANG)
	Select 
		mh.uId_Mathang ,
		v_MaMathang, 
		nv_TenMathang_vn, 
		nv_DVT_vn,
		dv.tendonvi,
		f_Hanmuc_Ton,
		[dbo].[Get_SL_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_Sl_Nhap,
		[dbo].[Get_GT_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_GT_Nhap,
		[dbo].[Get_SL_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_Sl_Xuat,
		[dbo].[Get_GT_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_GT_Xuat,
		isnull([dbo].[Get_SLMH_Tieuhao](mh.uId_Mathang,@uId_Kho,@DenNgay),0) + isnull(dbo.Get_SL_Tieuhao_Thucong(mh.uId_Mathang,@uId_Kho,@DenNgay),0) as f_SLTieuhao,
		[dbo].[Get_SL_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) - [dbo].[Get_SL_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) - (isnull([dbo].[Get_SLMH_Tieuhao](mh.uId_Mathang,@uId_Kho,@DenNgay),0) + isnull(dbo.Get_SL_Tieuhao_Thucong(mh.uId_Mathang,@uId_Kho,@DenNgay),0)) as f_SL_Ton,
		[dbo].[Get_GT_Nhap_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) - [dbo].[Get_GT_Xuat_Phuongnm](mh.uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) as f_GT_Ton,
		kho.nv_Tenkho_vn
	From QLMH_DM_MATHANG mh
	LEFT JOIN DMQuyDoiDonVi qddv ON mh.uId_Mathang = qddv.MaVatTu
	LEFT JOIN DMDonvi dv ON qddv.MaDonVi1 = dv.madonvi
	INNER JOIN QLMH_DINHMUC_GIAMATHANG dmg ON mh.uId_Mathang = dmg.uId_Mathang
	INNER JOIN QLMH_DM_KHO kho ON dmg.uId_Kho = kho.uId_Kho
	WHERE dmg.uId_Kho = @uId_Kho
	--Where [dbo].[Get_SL_Nhap_Phuongnm](uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang) +[dbo].[Get_SL_Xuat_Phuongnm](uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang)+dbo.Get_SL_Tieuhao(uId_Mathang,@DenNgay,@uId_Kho,@uId_Cuahang)>0
	Order by nv_TenMathang_vn
	END
end

