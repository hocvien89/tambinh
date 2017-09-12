Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_NGOAITE_TYGIADA

	Implements ITNTP_NGOAITE_TYGIADA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_NGOAITE_TYGIAEntity) Implements ITNTP_NGOAITE_TYGIADA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NGOAITE_TYGIA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_NGOAITE_TYGIAEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_NGOAITE_TYGIAEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_NGOAITE_TYGIAEntity)
                With lstobj(i)
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Tygia_VND = IIf(IsDBNull(objReader("f_Tygia_VND")) = True, 0, objReader("f_Tygia_VND"))
                    .v_Ma = IIf(IsDBNull(objReader("v_Ma")) = True, "", objReader("v_Ma"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_NGOAITE_TYGIAEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Ngoaite As String) As System.Data.DataTable Implements ITNTP_NGOAITE_TYGIADA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NGOAITE_TYGIA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, uId_Ngoaite)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Ngoaite As String) As CM.TNTP_NGOAITE_TYGIAEntity Implements ITNTP_NGOAITE_TYGIADA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NGOAITE_TYGIA_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_NGOAITE_TYGIAEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, uId_Ngoaite)
            'db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_NGOAITE_TYGIAEntity
            If objReader.Read Then
                With obj
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Tygia_VND = IIf(IsDBNull(objReader("f_Tygia_VND")) = True, 1, objReader("f_Tygia_VND"))
                    .v_Ma = IIf(IsDBNull(objReader("v_Ma")) = True, "", objReader("v_Ma"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_NGOAITE_TYGIAEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_NGOAITE_TYGIAEntity) As Boolean Implements ITNTP_NGOAITE_TYGIADA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NGOAITE_TYGIA_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@f_Tygia_VND", DbType.Double, obj.f_Tygia_VND)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Ngoaite AS String,ByVal d_Ngay AS DateTime) As Boolean Implements ITNTP_NGOAITE_TYGIADA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_NGOAITE_TYGIA_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String,uId_Ngoaite)
			db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime,d_Ngay)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_NGOAITE_TYGIAEntity) As Boolean Implements ITNTP_NGOAITE_TYGIADA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NGOAITE_TYGIA_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@f_Tygia_VND", DbType.Double, obj.f_Tygia_VND)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class