Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.CM
Imports LogError
Imports System.Data.Common

Public Class QLP_DM_GIUONGDA

    Implements IQLP_DM_GIUONGDA



    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLP_DM_GIUONGEntity) Implements IQLP_DM_GIUONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLP_DM_GIUONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLP_DM_GIUONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLP_DM_GIUONGEntity)
                With lstobj(i)
                    .uId_Giuong = IIf(IsDBNull(objReader("uId_Giuong")) = True, "", Convert.ToString(objReader("uId_Giuong")))
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .nv_TenGiuong_vn = IIf(IsDBNull(objReader("nv_TenGiuong_vn")) = True, "", objReader("nv_TenGiuong_vn"))
                End With
                i += 1
            End While
            objReader.Close()
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLP_DM_GIUONGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLP_DM_GIUONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Giuong As String) As CM.QLP_DM_GIUONGEntity Implements IQLP_DM_GIUONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLP_DM_GIUONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Giuong", System.Data.DbType.String, uId_Giuong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLP_DM_GIUONGEntity
            If objReader.Read Then
                With obj
                    .uId_Giuong = IIf(IsDBNull(objReader("uId_Giuong")) = True, "", Convert.ToString(objReader("uId_Giuong")))
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .nv_TenGiuong_vn = IIf(IsDBNull(objReader("nv_TenGiuong_vn")) = True, "", objReader("nv_TenGiuong_vn"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLP_DM_GIUONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLP_DM_GIUONGEntity) As Boolean Implements IQLP_DM_GIUONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenGiuong_vn", DbType.String, obj.nv_TenGiuong_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Giuong As String) As Boolean Implements IQLP_DM_GIUONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Giuong", DbType.String, uId_Giuong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLP_DM_GIUONGEntity) As Boolean Implements IQLP_DM_GIUONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Giuong", DbType.String, obj.uId_Giuong)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, obj.uId_Phong)
            db.AddInParameter(objCmd, "@nv_TenGiuong_vn", DbType.String, obj.nv_TenGiuong_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectGiuongtrongtheophong(uId_Phong As String) As DataTable Implements IQLP_DM_GIUONGDA.SelectGiuongtrongtheophong
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_SelectGiuongtrongtheophong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function UpdateTrangThai(uId_Giuong As String, Status As Boolean) As Boolean Implements IQLP_DM_GIUONGDA.UpdateTrangThai
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_UpdateTrangThai]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Giuong", DbType.String, uId_Giuong)
            db.AddInParameter(objCmd, "@Status", DbType.Boolean, Status)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectGiuongtheophong(uId_Phong As String) As DataTable Implements IQLP_DM_GIUONGDA.SelectGiuongtheophong
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_GIUONG_SelectGiuongtheophong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    'xuanhieu 220415 thong tin giuong tai thoi diem kiem tra 
    Public Function SelectInfoGiuong(uId_Giuong As String, d_time As Date) As DataTable Implements IQLP_DM_GIUONGDA.SelectInfoGiuong
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_SelectByIdandTime]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Giuong", DbType.String, uId_Giuong)
            db.AddInParameter(objCmd, "@d_Checkin", DbType.DateTime, d_time)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class