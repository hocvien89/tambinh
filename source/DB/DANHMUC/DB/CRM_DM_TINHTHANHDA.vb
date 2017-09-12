Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_TINHTHANHDA
    Implements ICRM_DM_TINHTHANHDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_TINHTHANHEntity) Implements ICRM_DM_TINHTHANHDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_TINHTHANHEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_TINHTHANHEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_TINHTHANHEntity)
                With lstobj(i)
                    .uId_Tinhthanh = IIf(IsDBNull(objReader("uId_Tinhthanh")) = True, "", Convert.ToString(objReader("uId_Tinhthanh")))
                    .uId_Quocgia = IIf(IsDBNull(objReader("uId_Quocgia")) = True, "", Convert.ToString(objReader("uId_Quocgia")))
                    .v_MaTinhthanh = IIf(IsDBNull(objReader("v_MaTinhthanh")) = True, "", objReader("v_MaTinhthanh"))
                    .nv_Tentinhthanh = IIf(IsDBNull(objReader("nv_Tentinhthanh")) = True, "", objReader("nv_Tentinhthanh"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_TINHTHANHEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Quocgia As String) As System.Data.DataTable Implements ICRM_DM_TINHTHANHDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_SelectAllTable]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quocgia", System.Data.DbType.String, uId_Quocgia)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Tinhthanh As String) As CM.CRM_DM_TINHTHANHEntity Implements ICRM_DM_TINHTHANHDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_TINHTHANHEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", System.Data.DbType.String, uId_Tinhthanh)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_TINHTHANHEntity
            If objReader.Read Then
                With obj
                    .uId_Tinhthanh = IIf(IsDBNull(objReader("uId_Tinhthanh")) = True, "", Convert.ToString(objReader("uId_Tinhthanh")))
                    .uId_Quocgia = IIf(IsDBNull(objReader("uId_Quocgia")) = True, "", Convert.ToString(objReader("uId_Quocgia")))
                    .v_MaTinhthanh = IIf(IsDBNull(objReader("v_MaTinhthanh")) = True, "", objReader("v_MaTinhthanh"))
                    .nv_Tentinhthanh = IIf(IsDBNull(objReader("nv_Tentinhthanh")) = True, "", objReader("nv_Tentinhthanh"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_TINHTHANHEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_TINHTHANHEntity) As Boolean Implements ICRM_DM_TINHTHANHDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quocgia", DbType.String, obj.uId_Quocgia)
            db.AddInParameter(objCmd, "@v_MaTinhthanh", DbType.String, obj.v_MaTinhthanh)
            db.AddInParameter(objCmd, "@nv_Tentinhthanh", DbType.String, obj.nv_Tentinhthanh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Tinhthanh As String) As Boolean Implements ICRM_DM_TINHTHANHDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", DbType.String, uId_Tinhthanh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_TINHTHANHEntity) As Boolean Implements ICRM_DM_TINHTHANHDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", DbType.String, obj.uId_Tinhthanh)
            db.AddInParameter(objCmd, "@uId_Quocgia", DbType.String, obj.uId_Quocgia)
            db.AddInParameter(objCmd, "@v_MaTinhthanh", DbType.String, obj.v_MaTinhthanh)
            db.AddInParameter(objCmd, "@nv_Tentinhthanh", DbType.String, obj.nv_Tentinhthanh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function


End Class