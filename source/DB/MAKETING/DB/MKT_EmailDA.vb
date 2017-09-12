Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_EmailDA

	Implements IMKT_EmailDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_EmailEntity) Implements IMKT_EmailDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Email_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_EmailEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_EmailEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_EmailEntity)
                With lstobj(i)
                    .uId_Email = IIf(IsDBNull(objReader("uId_Email")) = True, "", Convert.ToString(objReader("uId_Email")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_EmailEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IMKT_EmailDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spMKT_Email_SelectAll]"
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

    Public Function SelectByIDKhachhang(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable Implements IMKT_EmailDA.SelectByIDKhachhang
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Email_SELECTBYIDKhachhang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", System.Data.DbType.String, uId_KH_Tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Email As String) As CM.MKT_EmailEntity Implements IMKT_EmailDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Email_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_EmailEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Email", System.Data.DbType.String, uId_Email)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_EmailEntity
            If objReader.Read Then
                With obj
                    .uId_Email = IIf(IsDBNull(objReader("uId_Email")) = True, "", Convert.ToString(objReader("uId_Email")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .nv_Tieude = IIf(IsDBNull(objReader("nv_Tieude")) = True, "", objReader("nv_Tieude"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_EmailEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_EmailEntity) As Boolean Implements IMKT_EmailDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Email_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@nv_Tieude", DbType.String, obj.nv_Tieude)
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Email AS String) As Boolean Implements IMKT_EmailDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spMKT_Email_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Email", DbType.String,uId_Email)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.MKT_EmailEntity) As Boolean Implements IMKT_EmailDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Email_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Email", DbType.String, obj.uId_Email)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Tieude", DbType.String, obj.nv_Tieude)
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class