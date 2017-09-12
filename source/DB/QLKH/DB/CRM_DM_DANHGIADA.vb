Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_DANHGIADA

    Implements ICRM_DM_DANHGIADA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_DANHGIAEntity) Implements ICRM_DM_DANHGIADA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_DANHGIA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_DANHGIAEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_DANHGIAEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_DANHGIAEntity)
                With lstobj(i)
                    .uId_Danhgia = IIf(IsDBNull(objReader("uId_Danhgia")) = True, "", Convert.ToString(objReader("uId_Danhgia")))
                    .nv_Cauhoi_vn = IIf(IsDBNull(objReader("nv_Cauhoi_vn")) = True, "", objReader("nv_Cauhoi_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_DANHGIAEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ICRM_DM_DANHGIADA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_DANHGIA_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Danhgia As String) As CM.CRM_DM_DANHGIAEntity Implements ICRM_DM_DANHGIADA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_DANHGIA_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_DANHGIAEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Danhgia", System.Data.DbType.String, uId_Danhgia)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_DANHGIAEntity
            If objReader.Read Then
                With obj
                    .uId_Danhgia = IIf(IsDBNull(objReader("uId_Danhgia")) = True, "", Convert.ToString(objReader("uId_Danhgia")))
                    .nv_Cauhoi_vn = IIf(IsDBNull(objReader("nv_Cauhoi_vn")) = True, "", objReader("nv_Cauhoi_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_DANHGIAEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_DANHGIAEntity) As Boolean Implements ICRM_DM_DANHGIADA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_DANHGIA_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Cauhoi_vn", DbType.String, obj.nv_Cauhoi_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Danhgia As String) As Boolean Implements ICRM_DM_DANHGIADA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_DANHGIA_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Danhgia", DbType.String, uId_Danhgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_DANHGIAEntity) As Boolean Implements ICRM_DM_DANHGIADA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_DANHGIA_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Danhgia", DbType.String, obj.uId_Danhgia)
            db.AddInParameter(objCmd, "@nv_Cauhoi_vn", DbType.String, obj.nv_Cauhoi_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class