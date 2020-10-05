USE [PK_SCC]
GO
/****** Object:  StoredProcedure [dbo].[sp_Select_Appointments_By_UniqueID_Table]    Script Date: 9/17/2020 9:31:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_Select_Appointments_By_UniqueID_Table]
@UniqueID int='207'
as
Begin
  Select 
       lh.[UniqueID]
      ,lh.[Type]
      ,lh.[StartDate]
      ,lh.[EndDate]
      ,lh.[AllDay]
      ,lh.[Subject]
      ,lh.[Location]
      ,lh.[Description]
      ,lh.[Status]
      ,lh.[Label]
      ,lh.[ResourceID]
      ,lh.[ResourceIDs]
      ,lh.[ReminderInfo]
      ,lh.[CustomField1]
      ,lh.[uId_Nhanvien]
      ,lh.[uId_Cuahang]
      ,lh.[dt_Sys]
      ,kh.nv_Hoten_vn 
      ,nv.nv_Hoten_vn as nv_Nhanvien_vn,
	  kh.v_Makhachang, kh.v_DienthoaiDD,
      (Select nv_Hoten_vn from QT_DM_NHANVIEN where uId_Nhanvien= lh.uId_Nhanvien_Kythuat) as nv_Kythuat_vn
      ,dv.nv_Tendichvu_vn
      From [Appointments] lh inner join CRM_DM_Khachhang kh on lh.CustomField1= kh.uId_Khachhang
      inner join QT_DM_NHANVIEN nv on lh.uId_Nhanvien= nv.uId_Nhanvien
      left join TNTP_DM_DICHVU dv on lh.uId_Dichvu = dv.uId_Dichvu
      where lh.UniqueID=@UniqueID 
End

