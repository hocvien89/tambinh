USE [NANOSPAFULL2015]
GO
/****** Object:  StoredProcedure [dbo].[spAppointments_SelectByDate]    Script Date: 02/06/2015 09:47:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[spAppointments_SelectByDate]
(
	@TuNgay as datetime = '11/02/2014',
	@DenNgay as datetime = '11/04/2015',
	@uId_Cuahang as varchar(50) = '24e1a59b-f645-4240-9a31-d91a90e58793',
	@Trangthai as int = 0,
	@nv_Tenkhachhang_vn as nvarchar(100)='%ngọc%'
)
AS
BEGIN
declare @sql nvarchar(200)
set @sql ='N'
	if @nv_Tenkhachhang_vn=''
	SELECT
		[UniqueID],
		[Type],
		(CONVERT(VARCHAR(10), StartDate, 103)+ ' ' + CONVERT(VARCHAR(8), StartDate, 108)) as StartDate,
		(CONVERT(VARCHAR(10), EndDate, 103)+ ' ' + CONVERT(VARCHAR(8), EndDate, 108)) as EndDate,
		[AllDay],
		[Subject],
		[Location],
		[Description],
		[Status],
		[Label],
		[ResourceID],
		[ResourceIDs],
		[ReminderInfo],
		[RecurrenceInfo],
		Appointments.uId_Cuahang,
		[CustomField1],
		kh.nv_Hoten_vn,
		nv.nv_Hoten_vn as nv_HotenNhanvien,
		(CASE Appointments.Label
		WHEN 0 THEN '--'
		WHEN 1 THEN N'Hẹn lịch' 
		WHEN 2 THEN N'Chuyển lịch' 
		WHEN 3 THEN N'Đã thực hiện'
		WHEN 4 THEN N'Lỡ hẹn' END) as trangthai
	FROM [dbo].[Appointments]
	LEFT JOIN CRM_DM_Khachhang kh ON Appointments.CustomField1 = kh.uId_Khachhang
	LEFT JOIN QT_DM_NHANVIEN nv ON Appointments.uId_Nhanvien = nv.uId_Nhanvien
	WHERE CONVERT(DATE, StartDate) >= CONVERT(DATE,@TuNgay) AND  CONVERT(DATE, StartDate) <= CONVERT(DATE,@DenNgay)
	AND CAST(ISNULL(Appointments.uId_Cuahang, '') as varchar(50)) LIKE N'%'+ @uId_Cuahang +'%'
	AND Label = (CASE @Trangthai WHEN 0 THEN Label ELSE @Trangthai END)
	ORDER BY StartDate, kh.nv_Hoten_vn ASC
	else
	SELECT
		[UniqueID],
		[Type],
		(CONVERT(VARCHAR(10), StartDate, 103)+ ' ' + CONVERT(VARCHAR(8), StartDate, 108)) as StartDate,
		(CONVERT(VARCHAR(10), EndDate, 103)+ ' ' + CONVERT(VARCHAR(8), EndDate, 108)) as EndDate,
		[AllDay],
		[Subject],
		[Location],
		[Description],
		[Status],
		[Label],
		[ResourceID],
		[ResourceIDs],
		[ReminderInfo],
		[RecurrenceInfo],
		Appointments.uId_Cuahang,
		[CustomField1],
		kh.nv_Hoten_vn,
		nv.nv_Hoten_vn as nv_HotenNhanvien,
		(CASE Appointments.Label
		WHEN 0 THEN '--'
		WHEN 1 THEN N'Hẹn lịch' 
		WHEN 2 THEN N'Chuyển lịch' 
		WHEN 3 THEN N'Đã thực hiện'
		WHEN 4 THEN N'Lỡ hẹn' END) as trangthai
	FROM [dbo].[Appointments]
	LEFT JOIN CRM_DM_Khachhang kh ON Appointments.CustomField1 = kh.uId_Khachhang
	LEFT JOIN QT_DM_NHANVIEN nv ON Appointments.uId_Nhanvien = nv.uId_Nhanvien
	WHERE CONVERT(DATE, StartDate) >= CONVERT(DATE,@TuNgay) AND  CONVERT(DATE, StartDate) <= CONVERT(DATE,@DenNgay)
	AND CAST(ISNULL(Appointments.uId_Cuahang, '') as varchar(50)) LIKE N'%'+ @uId_Cuahang +'%'
	AND Label = (CASE @Trangthai WHEN 0 THEN Label ELSE @Trangthai END)
	and kh.nv_Hoten_vn like N'%'+@nv_Tenkhachhang_vn+'%'
	
	ORDER BY StartDate, kh.nv_Hoten_vn ASC
END 
