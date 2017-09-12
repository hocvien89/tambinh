Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports LogError
Imports System.Data.Common

Public Class AppointmentsDA

    Implements IAppointmentsDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.AppointmentsEntity) Implements IAppointmentsDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.AppointmentsEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.AppointmentsEntity)
            While (objReader.Read())
                lstobj.Add(New CM.AppointmentsEntity)
                With lstobj(i)
                    .UniqueID = IIf(IsDBNull(objReader("UniqueID")) = True, 0, objReader("UniqueID"))
                    .Type = IIf(IsDBNull(objReader("Type")) = True, 0, objReader("Type"))
                    .StartDate = IIf(IsDBNull(objReader("StartDate")) = True, Nothing, objReader("StartDate"))
                    .EndDate = IIf(IsDBNull(objReader("EndDate")) = True, Nothing, objReader("EndDate"))
                    .AllDay = IIf(IsDBNull(objReader("AllDay")) = True, False, objReader("AllDay"))
                    .Subject = IIf(IsDBNull(objReader("Subject")) = True, "", objReader("Subject"))
                    .Location = IIf(IsDBNull(objReader("Location")) = True, "", objReader("Location"))
                    .Description = IIf(IsDBNull(objReader("Description")) = True, "", objReader("Description"))
                    .Status = IIf(IsDBNull(objReader("Status")) = True, 0, objReader("Status"))
                    .Label = IIf(IsDBNull(objReader("Label")) = True, 0, objReader("Label"))
                    .ResourceID = IIf(IsDBNull(objReader("ResourceID")) = True, 0, objReader("ResourceID"))
                    .ResourceIDs = IIf(IsDBNull(objReader("ResourceIDs")) = True, "", objReader("ResourceIDs"))
                    .ReminderInfo = IIf(IsDBNull(objReader("ReminderInfo")) = True, "", objReader("ReminderInfo"))
                    .RecurrenceInfo = IIf(IsDBNull(objReader("RecurrenceInfo")) = True, "", objReader("RecurrenceInfo"))
                    .CustomField1 = IIf(IsDBNull(objReader("CustomField1")) = True, "", objReader("CustomField1"))
                End With
                i += 1
            End While
            objReader.Close()
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.AppointmentsEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IAppointmentsDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal UniqueID As Int32) As CM.AppointmentsEntity Implements IAppointmentsDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.AppointmentsEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", System.Data.DbType.Int32, UniqueID)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.AppointmentsEntity
            If objReader.Read Then
                With obj
                    .UniqueID = IIf(IsDBNull(objReader("UniqueID")) = True, 0, objReader("UniqueID"))
                    .Type = IIf(IsDBNull(objReader("Type")) = True, 0, objReader("Type"))
                    .StartDate = IIf(IsDBNull(objReader("StartDate")) = True, Nothing, objReader("StartDate"))
                    .EndDate = IIf(IsDBNull(objReader("EndDate")) = True, Nothing, objReader("EndDate"))
                    .AllDay = IIf(IsDBNull(objReader("AllDay")) = True, False, objReader("AllDay"))
                    .Subject = IIf(IsDBNull(objReader("Subject")) = True, "", objReader("Subject"))
                    .Location = IIf(IsDBNull(objReader("Location")) = True, "", objReader("Location"))
                    .Description = IIf(IsDBNull(objReader("Description")) = True, "", objReader("Description"))
                    .Status = IIf(IsDBNull(objReader("Status")) = True, 0, objReader("Status"))
                    .Label = IIf(IsDBNull(objReader("Label")) = True, 0, objReader("Label"))
                    .ResourceID = IIf(IsDBNull(objReader("ResourceID")) = True, 0, objReader("ResourceID"))
                    .ResourceIDs = IIf(IsDBNull(objReader("ResourceIDs")) = True, "", objReader("ResourceIDs"))
                    .ReminderInfo = IIf(IsDBNull(objReader("ReminderInfo")) = True, "", objReader("ReminderInfo"))
                    .RecurrenceInfo = IIf(IsDBNull(objReader("RecurrenceInfo")) = True, "", objReader("RecurrenceInfo"))
                    .CustomField1 = IIf(IsDBNull(objReader("CustomField1")) = True, "", objReader("CustomField1"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.AppointmentsEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.AppointmentsEntity) As Boolean Implements IAppointmentsDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Type", DbType.Int32, obj.Type)
            If (obj.StartDate <> Nothing And obj.StartDate <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@StartDate", DbType.DateTime, obj.StartDate)
            End If
            If (obj.EndDate <> Nothing And obj.EndDate <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@EndDate", DbType.DateTime, obj.EndDate)
            End If
            db.AddInParameter(objCmd, "@AllDay", DbType.Boolean, obj.AllDay)
            db.AddInParameter(objCmd, "@Subject", DbType.String, obj.Subject)
            db.AddInParameter(objCmd, "@Location", DbType.String, obj.Location)
            db.AddInParameter(objCmd, "@Description", DbType.String, obj.Description)
            db.AddInParameter(objCmd, "@Status", DbType.Int32, obj.Status)
            db.AddInParameter(objCmd, "@Label", DbType.Int32, obj.Label)
            db.AddInParameter(objCmd, "@ResourceID", DbType.Int32, obj.ResourceID)
            db.AddInParameter(objCmd, "@ResourceIDs", DbType.String, obj.ResourceIDs)
            db.AddInParameter(objCmd, "@ReminderInfo", DbType.String, obj.ReminderInfo)
            db.AddInParameter(objCmd, "@RecurrenceInfo", DbType.String, obj.RecurrenceInfo)
            db.AddInParameter(objCmd, "@UniqueID", DbType.String, obj.UniqueID)
            db.AddInParameter(objCmd, "@CustomField1", DbType.String, obj.CustomField1)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal UniqueID As Int32) As Boolean Implements IAppointmentsDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", DbType.Int32, UniqueID)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.AppointmentsEntity) As Boolean Implements IAppointmentsDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", DbType.Int32, obj.UniqueID)
            db.AddInParameter(objCmd, "@Type", DbType.Int32, obj.Type)
            If (obj.StartDate <> Nothing And obj.StartDate <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@StartDate", DbType.DateTime, obj.StartDate)
            End If
            If (obj.EndDate <> Nothing And obj.EndDate <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@EndDate", DbType.DateTime, obj.EndDate)
            End If
            db.AddInParameter(objCmd, "@AllDay", DbType.Boolean, obj.AllDay)
            db.AddInParameter(objCmd, "@Subject", DbType.String, obj.Subject)
            db.AddInParameter(objCmd, "@Location", DbType.String, obj.Location)
            db.AddInParameter(objCmd, "@Description", DbType.String, obj.Description)
            db.AddInParameter(objCmd, "@Status", DbType.Int32, obj.Status)
            db.AddInParameter(objCmd, "@Label", DbType.Int32, obj.Label)
            db.AddInParameter(objCmd, "@ResourceID", DbType.Int32, obj.ResourceID)
            db.AddInParameter(objCmd, "@ResourceIDs", DbType.String, obj.ResourceIDs)
            db.AddInParameter(objCmd, "@ReminderInfo", DbType.String, obj.ReminderInfo)
            db.AddInParameter(objCmd, "@RecurrenceInfo", DbType.String, obj.RecurrenceInfo)
            db.AddInParameter(objCmd, "@CustomField1", DbType.String, obj.CustomField1)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectWarming(ByVal NumOfTime As Integer) As DataTable Implements IAppointmentsDA.SelectWarming
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_SelectWarming]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Time", DbType.Int32, NumOfTime)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByDate(TuNgay As String, DenNgay As String, uId_Cuahang As String, ByVal Trangthai As Integer, nv_Tenkhachhang As String, uId_Phong As String) As DataTable Implements IAppointmentsDA.SelectByDate
        Dim db As Database
        Dim sp As String = "[dbo].[spAppointments_SelectByDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.Date, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.Date, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Trangthai", DbType.Int16, Trangthai)
            db.AddInParameter(objCmd, "@nv_Tenkhachhang_vn", DbType.String, nv_Tenkhachhang)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID_Table(UniqueID As String) As DataTable Implements IAppointmentsDA.SelectByID_Table
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Appointments_By_UniqueID_Table]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", DbType.Int16, UniqueID)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Kiemtralichhentrung(Resource As String, dStart As Date, dEnd As Date, uId_Nhanvien As String) As DataTable Implements IAppointmentsDA.Kiemtralichhentrung
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Kiemtralichhentrung_By_Nhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Resource", DbType.String, Resource)
            db.AddInParameter(objCmd, "@dStart", DbType.DateTime, dStart)
            db.AddInParameter(objCmd, "@dEnd", DbType.DateTime, dEnd)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Kiemtratrungphongdichvu(Resource As String, dStart As Date, dEnd As Date) As Boolean Implements IAppointmentsDA.Kiemtratrungphongdichvu
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Kiemtralichhentrung_By_Phong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Resource", DbType.String, Resource)
            db.AddInParameter(objCmd, "@dStart", DbType.DateTime, dStart)
            db.AddInParameter(objCmd, "@dEnd", DbType.DateTime, dEnd)
            objDs = db.ExecuteDataSet(objCmd)
            If Convert.ToInt16(objDs.Tables(0).Rows(0).Item("b_Return").ToString) = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Kiemtralichhentrung_Kythuat(Resource As String, dStart As Date, dEnd As Date, uId_Nhanvien As String) As DataTable Implements IAppointmentsDA.Kiemtralichhentrung_Kythuat
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Kiemtralichhentrung_By_Nhanvien_Kythuat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Resource", DbType.String, Resource)
            db.AddInParameter(objCmd, "@dStart", DbType.DateTime, dStart)
            db.AddInParameter(objCmd, "@dEnd", DbType.DateTime, dEnd)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class