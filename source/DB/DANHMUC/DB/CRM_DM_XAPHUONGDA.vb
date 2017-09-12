Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_XAPHUONGDA

    Implements ICRM_DM_XAPHUONGDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_XAPHUONGEntity) Implements ICRM_DM_XAPHUONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_XAPHUONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_XAPHUONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_XAPHUONGEntity)
                With lstobj(i)
                    .uId_Xaphuong = IIf(IsDBNull(objReader("uId_Xaphuong")) = True, "", Convert.ToString(objReader("uId_Xaphuong")))
                    .uId_Quanhuyen = IIf(IsDBNull(objReader("uId_Quanhuyen")) = True, "", Convert.ToString(objReader("uId_Quanhuyen")))
                    .v_MaXaphuong = IIf(IsDBNull(objReader("v_MaXaphuong")) = True, "", objReader("v_MaXaphuong"))
                    .nv_TenXaphuong = IIf(IsDBNull(objReader("nv_TenXaphuong")) = True, "", objReader("nv_TenXaphuong"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_XAPHUONGEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Quanhuyen As String) As System.Data.DataTable Implements ICRM_DM_XAPHUONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_SelectAllTable]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", System.Data.DbType.String, uId_Quanhuyen)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectDiaDanhbyID(ByVal uId_Xaphuong As String) As System.Data.DataTable Implements ICRM_DM_XAPHUONGDA.SelectDiaDanhByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_SelectDiaDanhByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Xaphuong", System.Data.DbType.String, uId_Xaphuong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByID(ByVal uId_Xaphuong As String) As CM.CRM_DM_XAPHUONGEntity Implements ICRM_DM_XAPHUONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_XAPHUONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Xaphuong", System.Data.DbType.String, uId_Xaphuong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_XAPHUONGEntity
            If objReader.Read Then
                With obj
                    .uId_Xaphuong = IIf(IsDBNull(objReader("uId_Xaphuong")) = True, "", Convert.ToString(objReader("uId_Xaphuong")))
                    .uId_Quanhuyen = IIf(IsDBNull(objReader("uId_Quanhuyen")) = True, "", Convert.ToString(objReader("uId_Quanhuyen")))
                    .v_MaXaphuong = IIf(IsDBNull(objReader("v_MaXaphuong")) = True, "", objReader("v_MaXaphuong"))
                    .nv_TenXaphuong = IIf(IsDBNull(objReader("nv_TenXaphuong")) = True, "", objReader("nv_TenXaphuong"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_XAPHUONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_XAPHUONGEntity) As Boolean Implements ICRM_DM_XAPHUONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", DbType.String, obj.uId_Quanhuyen)
            db.AddInParameter(objCmd, "@v_MaXaphuong", DbType.String, obj.v_MaXaphuong)
            db.AddInParameter(objCmd, "@nv_TenXaphuong", DbType.String, obj.nv_TenXaphuong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Xaphuong As String) As Boolean Implements ICRM_DM_XAPHUONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Xaphuong", DbType.String, uId_Xaphuong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_XAPHUONGEntity) As Boolean Implements ICRM_DM_XAPHUONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_XAPHUONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Xaphuong", DbType.String, obj.uId_Xaphuong)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", DbType.String, obj.uId_Quanhuyen)
            db.AddInParameter(objCmd, "@v_MaXaphuong", DbType.String, obj.v_MaXaphuong)
            db.AddInParameter(objCmd, "@nv_TenXaphuong", DbType.String, obj.nv_TenXaphuong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class