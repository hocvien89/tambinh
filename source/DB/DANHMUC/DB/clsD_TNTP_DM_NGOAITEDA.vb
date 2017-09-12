Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_NGOAITEDA

	Implements ITNTP_DM_NGOAITEDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_NGOAITEEntity) Implements ITNTP_DM_NGOAITEDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NGOAITE_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_NGOAITEEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_NGOAITEEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_NGOAITEEntity)
                With lstobj(i)
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .v_Ma = IIf(IsDBNull(objReader("v_Ma")) = True, "", objReader("v_Ma"))
                    .b_Macdinh = IIf(IsDBNull(objReader("b_Macdinh")) = True, False, objReader("b_Macdinh"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_NGOAITEEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ITNTP_DM_NGOAITEDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_NGOAITE_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Ngoaite As String) As CM.TNTP_DM_NGOAITEEntity Implements ITNTP_DM_NGOAITEDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NGOAITE_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_NGOAITEEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", System.Data.DbType.String, uId_Ngoaite)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_NGOAITEEntity
            If objReader.Read Then
                With obj
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .v_Ma = IIf(IsDBNull(objReader("v_Ma")) = True, "", objReader("v_Ma"))
                    .b_Macdinh = IIf(IsDBNull(objReader("b_Macdinh")) = True, False, objReader("b_Macdinh"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_NGOAITEEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_NGOAITEEntity) As Boolean Implements ITNTP_DM_NGOAITEDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NGOAITE_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Ma", DbType.String, obj.v_Ma)
            db.AddInParameter(objCmd, "@b_Macdinh", DbType.Boolean, obj.b_Macdinh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Ngoaite AS String) As Boolean Implements ITNTP_DM_NGOAITEDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_NGOAITE_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String,uId_Ngoaite)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_NGOAITEEntity) As Boolean Implements ITNTP_DM_NGOAITEDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NGOAITE_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            db.AddInParameter(objCmd, "@v_Ma", DbType.String, obj.v_Ma)
            db.AddInParameter(objCmd, "@b_Macdinh", DbType.Boolean, obj.b_Macdinh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class