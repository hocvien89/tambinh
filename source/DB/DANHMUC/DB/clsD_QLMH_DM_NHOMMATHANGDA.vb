Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DM_NHOMMATHANGDA

	Implements IQLMH_DM_NHOMMATHANGDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DM_NHOMMATHANGEntity) Implements IQLMH_DM_NHOMMATHANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DM_NHOMMATHANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DM_NHOMMATHANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DM_NHOMMATHANGEntity)
                With lstobj(i)
                    .uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    .nv_Tennhommathang_vn = IIf(IsDBNull(objReader("nv_Tennhommathang_vn")) = True, "", objReader("nv_Tennhommathang_vn"))
                    .nv_Tennhommathang_en = IIf(IsDBNull(objReader("nv_Tennhommathang_en")) = True, "", objReader("nv_Tennhommathang_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DM_NHOMMATHANGEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQLMH_DM_NHOMMATHANGDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Nhommathang As String) As CM.QLMH_DM_NHOMMATHANGEntity Implements IQLMH_DM_NHOMMATHANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_NHOMMATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhommathang", System.Data.DbType.String, uId_Nhommathang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_NHOMMATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    .nv_Tennhommathang_vn = IIf(IsDBNull(objReader("nv_Tennhommathang_vn")) = True, "", objReader("nv_Tennhommathang_vn"))
                    .nv_Tennhommathang_en = IIf(IsDBNull(objReader("nv_Tennhommathang_en")) = True, "", objReader("nv_Tennhommathang_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_NHOMMATHANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_NHOMMATHANGEntity) As Boolean Implements IQLMH_DM_NHOMMATHANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tennhommathang_vn", DbType.String, obj.nv_Tennhommathang_vn)
            db.AddInParameter(objCmd, "@nv_Tennhommathang_en", DbType.String, obj.nv_Tennhommathang_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Nhommathang AS String) As Boolean Implements IQLMH_DM_NHOMMATHANGDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String,uId_Nhommathang)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_NHOMMATHANGEntity) As Boolean Implements IQLMH_DM_NHOMMATHANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, obj.uId_Nhommathang)
            db.AddInParameter(objCmd, "@nv_Tennhommathang_vn", DbType.String, obj.nv_Tennhommathang_vn)
            db.AddInParameter(objCmd, "@nv_Tennhommathang_en", DbType.String, obj.nv_Tennhommathang_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    'xuanhieu 31/10/2014
    Public Function SelectcheckMa(manhom As String) As String Implements IQLMH_DM_NHOMMATHANGDA.SelectcheckMa
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHOMMATHANG_SelectByTenNhom]"
        Dim objCmd As DbCommand
        Dim ds As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_tennhommathang_en", DbType.String, manhom)
            ds = db.ExecuteDataSet(objCmd)
            Return ds.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            Return ""
        End Try

    End Function
End Class