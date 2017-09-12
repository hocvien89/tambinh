Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_QUANHUYENDA

    Implements ICRM_DM_QUANHUYENDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_QUANHUYENEntity) Implements ICRM_DM_QUANHUYENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUANHUYEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_QUANHUYENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_QUANHUYENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_QUANHUYENEntity)
                With lstobj(i)
                    .uId_Quanhuyen = IIf(IsDBNull(objReader("uId_Quanhuyen")) = True, "", Convert.ToString(objReader("uId_Quanhuyen")))
                    .uId_Tinhthanh = IIf(IsDBNull(objReader("uId_Tinhthanh")) = True, "", Convert.ToString(objReader("uId_Tinhthanh")))
                    .v_MaQuanhuyen = IIf(IsDBNull(objReader("v_MaQuanhuyen")) = True, "", objReader("v_MaQuanhuyen"))
                    .nv_Tenquanhuyen = IIf(IsDBNull(objReader("nv_Tenquanhuyen")) = True, "", objReader("nv_Tenquanhuyen"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_QUANHUYENEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Tinhthanh As String) As System.Data.DataTable Implements ICRM_DM_QUANHUYENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUANHUYEN_SelectAllTable]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", System.Data.DbType.String, uId_Tinhthanh)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Quanhuyen As String) As CM.CRM_DM_QUANHUYENEntity Implements ICRM_DM_QUANHUYENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUANHUYEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_QUANHUYENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", System.Data.DbType.String, uId_Quanhuyen)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_QUANHUYENEntity
            If objReader.Read Then
                With obj
                    .uId_Quanhuyen = IIf(IsDBNull(objReader("uId_Quanhuyen")) = True, "", Convert.ToString(objReader("uId_Quanhuyen")))
                    .uId_Tinhthanh = IIf(IsDBNull(objReader("uId_Tinhthanh")) = True, "", Convert.ToString(objReader("uId_Tinhthanh")))
                    .v_MaQuanhuyen = IIf(IsDBNull(objReader("v_MaQuanhuyen")) = True, "", objReader("v_MaQuanhuyen"))
                    .nv_Tenquanhuyen = IIf(IsDBNull(objReader("nv_Tenquanhuyen")) = True, "", objReader("nv_Tenquanhuyen"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_QUANHUYENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_QUANHUYENEntity) As Boolean Implements ICRM_DM_QUANHUYENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUANHUYEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", DbType.String, obj.uId_Tinhthanh)
            db.AddInParameter(objCmd, "@v_MaQuanhuyen", DbType.String, obj.v_MaQuanhuyen)
            db.AddInParameter(objCmd, "@nv_Tenquanhuyen", DbType.String, obj.nv_Tenquanhuyen)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Quanhuyen As String) As Boolean Implements ICRM_DM_QUANHUYENDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUANHUYEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", DbType.String, uId_Quanhuyen)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_QUANHUYENEntity) As Boolean Implements ICRM_DM_QUANHUYENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUANHUYEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", DbType.String, obj.uId_Quanhuyen)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", DbType.String, obj.uId_Tinhthanh)
            db.AddInParameter(objCmd, "@v_MaQuanhuyen", DbType.String, obj.v_MaQuanhuyen)
            db.AddInParameter(objCmd, "@nv_Tenquanhuyen", DbType.String, obj.nv_Tenquanhuyen)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class