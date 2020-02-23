-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION getInterestRateInDay
(
	@uId_Mathang uniqueidentifier,
	@currentDay date,
	@uId_Kho varchar(50),
	@uId_Cuahang varchar(50)
)
RETURNS float
AS
BEGIN
	declare @f_GiaNhap float;
	declare @i_SoLuongXuatTrongNgay int;
	declare @f_GiaXuat float;
	declare @f_LaiSuat float;
	set @f_GiaNhap = (select top 1 f_Donggia
	from QLMH_PHIEUNHAP_CHITIET pnct
	inner join QLMH_PHIEUNHAP  pn on pnct.uId_Phieunhap = pn.uId_Phieunhap
	where pnct.uId_Mathang= @uId_Mathang 
	and pn.uId_Kho = Case @uId_Kho when '' then pn.uId_Kho else @uId_Kho END
	and pn.d_Ngaynhap <= @currentDay
	order by pn.d_Ngaynhap);
	select @i_SoLuongXuatTrongNgay =  sum(pxct.f_Soluongnhonhat), @f_GiaXuat = sum(pxct.f_Tongtien) 
	from QLMH_PHIEUXUAT_CHITIET pxct
	inner join QLMH_PHIEUXUAT px on pxct.uId_Phieuxuat= px.uId_Phieuxuat
	where pxct.uId_Mathang=@uId_Mathang 
	and px.uId_Kho=Case @uId_Kho when '' then px.uId_Kho else @uId_Kho END
	and px.d_Ngayxuat = @currentDay
	group by pxct.uId_Mathang
	set @f_LaiSuat = @f_GiaXuat -(@f_GiaNhap*@i_SoLuongXuatTrongNgay);
	return @f_LaiSuat;
END
GO

