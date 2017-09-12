Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_NHOMTHAMDODA

	Implements ITNTP_DM_NHOMTHAMDODA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_NHOMTHAMDOEntity) Implements ITNTP_DM_NHOMTHAMDODA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMTHAMDO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_NHOMTHAMDOEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_NHOMTHAMDOEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_NHOMTHAMDOEntity)
                With lstobj(i)
                    .uId_NhomThamdo = IIf(IsDBNull(objReader("uId_NhomThamdo")) = True, "", Convert.ToString(objReader("uId_NhomThamdo")))
                    .nv_TennhomThamdo_vn = IIf(IsDBNull(objReader("nv_TennhomThamdo_vn")) = True, "", objReader("nv_TennhomThamdo_vn"))
                    .nv_TennhomThando_en = IIf(IsDBNull(objReader("nv_TennhomThando_en")) = True, "", objReader("nv_TennhomThando_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_NHOMTHAMDOEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ITNTP_DM_NHOMTHAMDODA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_NHOMTHAMDO_SelectAll]"
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

    Public Function SelectByID(ByVal uId_NhomThamdo As String) As CM.TNTP_DM_NHOMTHAMDOEntity Implements ITNTP_DM_NHOMTHAMDODA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMTHAMDO_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_NHOMTHAMDOEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_NhomThamdo", System.Data.DbType.String, uId_NhomThamdo)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_NHOMTHAMDOEntity
            If objReader.Read Then
                With obj
                    .uId_NhomThamdo = IIf(IsDBNull(objReader("uId_NhomThamdo")) = True, "", Convert.ToString(objReader("uId_NhomThamdo")))
                    .nv_TennhomThamdo_vn = IIf(IsDBNull(objReader("nv_TennhomThamdo_vn")) = True, "", objReader("nv_TennhomThamdo_vn"))
                    .nv_TennhomThando_en = IIf(IsDBNull(objReader("nv_TennhomThando_en")) = True, "", objReader("nv_TennhomThando_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_NHOMTHAMDOEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_NHOMTHAMDOEntity) As Boolean Implements ITNTP_DM_NHOMTHAMDODA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMTHAMDO_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TennhomThamdo_vn", DbType.String, obj.nv_TennhomThamdo_vn)
            db.AddInParameter(objCmd, "@nv_TennhomThando_en", DbType.String, obj.nv_TennhomThando_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_NhomThamdo AS String) As Boolean Implements ITNTP_DM_NHOMTHAMDODA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_NHOMTHAMDO_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_NhomThamdo", DbType.String,uId_NhomThamdo)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_NHOMTHAMDOEntity) As Boolean Implements ITNTP_DM_NHOMTHAMDODA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMTHAMDO_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_NhomThamdo", DbType.String, obj.uId_NhomThamdo)
            db.AddInParameter(objCmd, "@nv_TennhomThamdo_vn", DbType.String, obj.nv_TennhomThamdo_vn)
            db.AddInParameter(objCmd, "@nv_TennhomThando_en", DbType.String, obj.nv_TennhomThando_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class