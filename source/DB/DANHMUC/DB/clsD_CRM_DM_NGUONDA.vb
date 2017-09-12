Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_NGUONDA

    Implements ICRM_DM_NGUONDA


    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_NGUONEntity) Implements ICRM_DM_NGUONDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_NGUON_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_NGUONEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_NGUONEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_NGUONEntity)
                With lstobj(i)
                    .uId_Nguon = IIf(IsDBNull(objReader("uId_Nguon")) = True, "", Convert.ToString(objReader("uId_Nguon")))
                    .nv_Nguon_vn = IIf(IsDBNull(objReader("nv_Nguon_vn")) = True, "", objReader("nv_Nguon_vn"))
                    .nv_Nguon_en = IIf(IsDBNull(objReader("nv_Nguon_en")) = True, "", objReader("nv_Nguon_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_NGUONEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ICRM_DM_NGUONDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_NGUON_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Nguon As String) As CM.CRM_DM_NGUONEntity Implements ICRM_DM_NGUONDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_NGUON_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_NGUONEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nguon", System.Data.DbType.String, uId_Nguon)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_NGUONEntity
            If objReader.Read Then
                With obj
                    .uId_Nguon = IIf(IsDBNull(objReader("uId_Nguon")) = True, "", Convert.ToString(objReader("uId_Nguon")))
                    .nv_Nguon_vn = IIf(IsDBNull(objReader("nv_Nguon_vn")) = True, "", objReader("nv_Nguon_vn"))
                    .nv_Nguon_en = IIf(IsDBNull(objReader("nv_Nguon_en")) = True, "", objReader("nv_Nguon_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_NGUONEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_NGUONEntity) As Boolean Implements ICRM_DM_NGUONDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_NGUON_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Nguon_vn", DbType.String, obj.nv_Nguon_vn)
            db.AddInParameter(objCmd, "@nv_Nguon_en", DbType.String, obj.nv_Nguon_en)
            db.AddInParameter(objCmd, "@vType", DbType.String, obj.vType)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Nguon As String) As Boolean Implements ICRM_DM_NGUONDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_NGUON_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nguon", DbType.String, uId_Nguon)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_NGUONEntity) As Boolean Implements ICRM_DM_NGUONDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_NGUON_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nguon", DbType.String, obj.uId_Nguon)
            db.AddInParameter(objCmd, "@nv_Nguon_vn", DbType.String, obj.nv_Nguon_vn)
            db.AddInParameter(objCmd, "@vType", DbType.String, obj.vType)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable_ByvType(ByVal vType As String) As System.Data.DataTable Implements ICRM_DM_NGUONDA.SelectAllTable_ByvType
        Dim db As Database

        Dim sp As String = "Select * from CRM_DM_NGUON"
        If Len(vType) > 0 Then
            sp = sp & " where vType='" & Trim(vType) & "'"
        End If

        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetSqlStringCommand(sp)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable_vType() As System.Data.DataTable Implements ICRM_DM_NGUONDA.SelectAllTable_vType
        Dim db As Database
        Dim sp As String = "Select distinct vType from CRM_DM_NGUON"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetSqlStringCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class