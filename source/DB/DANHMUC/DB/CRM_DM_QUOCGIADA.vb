Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_QUOCGIADA

	Implements ICRM_DM_QUOCGIADA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_QUOCGIAEntity) Implements ICRM_DM_QUOCGIADA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUOCGIA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_QUOCGIAEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_QUOCGIAEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_QUOCGIAEntity)
                With lstobj(i)
                    .uId_Quocgia = IIf(IsDBNull(objReader("uId_Quocgia")) = True, "", Convert.ToString(objReader("uId_Quocgia")))
                    .v_MaQuocgia = IIf(IsDBNull(objReader("v_MaQuocgia")) = True, "", objReader("v_MaQuocgia"))
                    .nv_TenQuocgia = IIf(IsDBNull(objReader("nv_TenQuocgia")) = True, "", objReader("nv_TenQuocgia"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_QUOCGIAEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ICRM_DM_QUOCGIADA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spCRM_DM_QUOCGIA_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function

    Public Function SelectByID(ByVal uId_Quocgia As String) As CM.CRM_DM_QUOCGIAEntity Implements ICRM_DM_QUOCGIADA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUOCGIA_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_QUOCGIAEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quocgia", System.Data.DbType.String, uId_Quocgia)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_QUOCGIAEntity
            If objReader.Read Then
                With obj
                    .uId_Quocgia = IIf(IsDBNull(objReader("uId_Quocgia")) = True, "", Convert.ToString(objReader("uId_Quocgia")))
                    .v_MaQuocgia = IIf(IsDBNull(objReader("v_MaQuocgia")) = True, "", objReader("v_MaQuocgia"))
                    .nv_TenQuocgia = IIf(IsDBNull(objReader("nv_TenQuocgia")) = True, "", objReader("nv_TenQuocgia"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_QUOCGIAEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_QUOCGIAEntity) As Boolean Implements ICRM_DM_QUOCGIADA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUOCGIA_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaQuocgia", DbType.String, obj.v_MaQuocgia)
            db.AddInParameter(objCmd, "@nv_TenQuocgia", DbType.String, obj.nv_TenQuocgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Quocgia AS String) As Boolean Implements ICRM_DM_QUOCGIADA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spCRM_DM_QUOCGIA_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Quocgia", DbType.String,uId_Quocgia)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.CRM_DM_QUOCGIAEntity) As Boolean Implements ICRM_DM_QUOCGIADA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_QUOCGIA_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quocgia", DbType.String, obj.uId_Quocgia)
            db.AddInParameter(objCmd, "@v_MaQuocgia", DbType.String, obj.v_MaQuocgia)
            db.AddInParameter(objCmd, "@nv_TenQuocgia", DbType.String, obj.nv_TenQuocgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class