Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_KHACHHANG_THE_GIAHANDA

	Implements ITNTP_KHACHHANG_THE_GIAHANDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_THE_GIAHANEntity) Implements ITNTP_KHACHHANG_THE_GIAHANDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_GIAHAN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_KHACHHANG_THE_GIAHANEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_KHACHHANG_THE_GIAHANEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_KHACHHANG_THE_GIAHANEntity)
                With lstobj(i)
                    .uId_The = IIf(IsDBNull(objReader("uId_The")) = True, "", Convert.ToString(objReader("uId_The")))
                    .d_Giahandenngay = IIf(IsDBNull(objReader("d_Giahandenngay")) = True, Nothing, objReader("d_Giahandenngay"))
                    .f_Sotiendongthem = IIf(IsDBNull(objReader("f_Sotiendongthem")) = True, 0, objReader("f_Sotiendongthem"))
                    .nv_Noidung_vn = IIf(IsDBNull(objReader("nv_Noidung_vn")) = True, "", objReader("nv_Noidung_vn"))
                    .nv_Noidung_en = IIf(IsDBNull(objReader("nv_Noidung_en")) = True, "", objReader("nv_Noidung_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_KHACHHANG_THE_GIAHANEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ITNTP_KHACHHANG_THE_GIAHANDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_GIAHAN_SelectAll]"
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

    Public Function SelectByID(ByVal uId_The As String, ByVal d_Giahandenngay As DateTime) As CM.TNTP_KHACHHANG_THE_GIAHANEntity Implements ITNTP_KHACHHANG_THE_GIAHANDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_GIAHAN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", System.Data.DbType.String, uId_The)
            db.AddInParameter(objCmd, "@d_Giahandenngay", System.Data.DbType.DateTime, d_Giahandenngay)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_KHACHHANG_THE_GIAHANEntity
            If objReader.Read Then
                With obj
                    .uId_The = IIf(IsDBNull(objReader("uId_The")) = True, "", Convert.ToString(objReader("uId_The")))
                    .d_Giahandenngay = IIf(IsDBNull(objReader("d_Giahandenngay")) = True, Nothing, objReader("d_Giahandenngay"))
                    .f_Sotiendongthem = IIf(IsDBNull(objReader("f_Sotiendongthem")) = True, 0, objReader("f_Sotiendongthem"))
                    .nv_Noidung_vn = IIf(IsDBNull(objReader("nv_Noidung_vn")) = True, "", objReader("nv_Noidung_vn"))
                    .nv_Noidung_en = IIf(IsDBNull(objReader("nv_Noidung_en")) = True, "", objReader("nv_Noidung_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_KHACHHANG_THE_GIAHANEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity) As Boolean Implements ITNTP_KHACHHANG_THE_GIAHANDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_GIAHAN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", DbType.String, obj.uId_The)
            If (obj.d_Giahandenngay <> Nothing And obj.d_Giahandenngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Giahandenngay", DbType.DateTime, obj.d_Giahandenngay)
            End If
            db.AddInParameter(objCmd, "@f_Sotiendongthem", DbType.Double, obj.f_Sotiendongthem)
            db.AddInParameter(objCmd, "@nv_Noidung_vn", DbType.String, obj.nv_Noidung_vn)
            db.AddInParameter(objCmd, "@nv_Noidung_en", DbType.String, obj.nv_Noidung_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_The AS String,ByVal d_Giahandenngay AS DateTime) As Boolean Implements ITNTP_KHACHHANG_THE_GIAHANDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_GIAHAN_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_The", DbType.String,uId_The)
			db.AddInParameter(objCmd, "@d_Giahandenngay", DbType.DateTime,d_Giahandenngay)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity) As Boolean Implements ITNTP_KHACHHANG_THE_GIAHANDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_GIAHAN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", DbType.String, obj.uId_The)
            If (obj.d_Giahandenngay <> Nothing And obj.d_Giahandenngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Giahandenngay", DbType.DateTime, obj.d_Giahandenngay)
            End If
            db.AddInParameter(objCmd, "@f_Sotiendongthem", DbType.Double, obj.f_Sotiendongthem)
            db.AddInParameter(objCmd, "@nv_Noidung_vn", DbType.String, obj.nv_Noidung_vn)
            db.AddInParameter(objCmd, "@nv_Noidung_en", DbType.String, obj.nv_Noidung_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class