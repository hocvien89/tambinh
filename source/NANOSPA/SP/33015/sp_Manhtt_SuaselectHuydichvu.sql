
ALTER PROCEDURE [dbo].[spMKT_HuyDv_SelectKHHuyDV]
(
	@tungay AS DATETIME='1-1-2010',
	@denngay AS DATETIME='1-1-2015',
	@uid_khachanng as nvarchar(50) ='762db321-237a-4232-9d6b-6bf8f73721f7'
)
AS
BEGIN
create table #KHHuyDV
	(
	v_Makhachhang varchar(50),
	nv_Tenkhachhang nvarchar(100),
	nv_Diachi nvarchar(200),
	v_Sodienthoai varchar(15),
	nv_Chitiet nvarchar(2000)
	)
insert into #KHHuyDV(v_Makhachhang,nv_Tenkhachhang,nv_Diachi,v_Sodienthoai,nv_Chitiet)
SELECT 
	cdk.v_Makhachang,cdk.nv_Hoten_vn, cdk.nv_Diachi_vn, cdk.v_DienthoaiDD,
	dbo.GetDVHuyById(cdk.uId_Khachhang) as Dichvu
			FROM MKT_HUYDICHVU mh 
		INNER JOIN CRM_DM_Khachhang cdk ON cdk.uId_Khachhang = mh.uId_Khachhang
		INNER JOIN QT_DM_NHANVIEN qdn ON qdn.uId_Nhanvien = mh.uId_Nhanvien
		INNER JOIN TNTP_DM_DICHVU tdd ON tdd.uId_Dichvu = mh.uId_Dichvu
		INNER JOIN TNTP_PHIEUDICHVU tp ON tp.uId_Phieudichvu = mh.uId_Phieudichvu 
	WHERE CONVERT(DATE, mh.[Date]) >= @tungay AND CONVERT(DATE, mh.[Date]) <= @denngay  and mh.uId_HuyDV IS NOT NULL
select v_Makhachhang,nv_Tenkhachhang,nv_Diachi,nv_Chitiet,v_Sodienthoai from #KHHuyDV	
END