
ALTER PROCEDURE [dbo].[spAppointments_Insert]
(
	@Type as int = null,
	@StartDate as smalldatetime = null,
	@EndDate as smalldatetime = null,
	@AllDay as bit = null,
	@Subject as nvarchar(100) = null,
	@Location as nvarchar(100) = null,
	@Description as ntext = null,
	@Status as int = null,
	@Label as int = null,
	@ResourceID as int = null,
	@ResourceIDs as ntext = null,
	@ReminderInfo as ntext = null,
	@RecurrenceInfo as ntext = null,
	@CustomField1 as ntext = null,
	@uId_Nhanvien as varchar(50),
	@uId_Cuahang as varchar(50)
)
AS
BEGIN
	INSERT INTO [dbo].[Appointments]
	(
		[Type],
		[StartDate],
		[EndDate],
		[AllDay],
		[Subject],
		[Location],
		[Description],
		[Status],
		[Label],
		--[ResourceID],
		--[ResourceIDs],
		--[ReminderInfo],
		--[RecurrenceInfo],
		[CustomField1],
		uId_Nhanvien,
		uId_Cuahang
	) 
	VALUES
	(
		@Type,
		@StartDate,
		@EndDate,
		@AllDay,
		@Subject,
		@Location,
		@Description,
		@Status,
		@Label,
		--@ResourceID,
		--@ResourceIDs,
		--@ReminderInfo,
		--@RecurrenceInfo,
		@CustomField1,
		@uId_Nhanvien,
		@uId_Cuahang
	) 
END 
GO