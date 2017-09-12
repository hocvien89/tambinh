Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DM_LOAIMATHANGDA

	Implements IQLMH_DM_LOAIMATHANGDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DM_LOAIMATHANGEntity) Implements IQLMH_DM_LOAIMATHANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DM_LOAIMATHANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DM_LOAIMATHANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DM_LOAIMATHANGEntity)
                With lstobj(i)
                    .uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    .nv_Tenloaimathang_en = IIf(IsDBNull(objReader("nv_Tenloaimathang_en")) = True, "", objReader("nv_Tenloaimathang_en"))
                    .nv_Tenloaimathang_vn = IIf(IsDBNull(objReader("nv_Tenloaimathang_vn")) = True, "", objReader("nv_Tenloaimathang_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DM_LOAIMATHANGEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQLMH_DM_LOAIMATHANGDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Loaimathang As String) As CM.QLMH_DM_LOAIMATHANGEntity Implements IQLMH_DM_LOAIMATHANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_LOAIMATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaimathang", System.Data.DbType.String, uId_Loaimathang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_LOAIMATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    .nv_Tenloaimathang_en = IIf(IsDBNull(objReader("nv_Tenloaimathang_en")) = True, "", objReader("nv_Tenloaimathang_en"))
                    .nv_Tenloaimathang_vn = IIf(IsDBNull(objReader("nv_Tenloaimathang_vn")) = True, "", objReader("nv_Tenloaimathang_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_LOAIMATHANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_LOAIMATHANGEntity) As Boolean Implements IQLMH_DM_LOAIMATHANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenloaimathang_en", DbType.String, obj.nv_Tenloaimathang_en)
            db.AddInParameter(objCmd, "@nv_Tenloaimathang_vn", DbType.String, obj.nv_Tenloaimathang_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Loaimathang AS String) As Boolean Implements IQLMH_DM_LOAIMATHANGDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String,uId_Loaimathang)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_LOAIMATHANGEntity) As Boolean Implements IQLMH_DM_LOAIMATHANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, obj.uId_Loaimathang)
            db.AddInParameter(objCmd, "@nv_Tenloaimathang_en", DbType.String, obj.nv_Tenloaimathang_en)
            db.AddInParameter(objCmd, "@nv_Tenloaimathang_vn", DbType.String, obj.nv_Tenloaimathang_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    'xuanhieu 31/10/2013 
    Public Function SelectcheckMa(maloai As String) As String Implements IQLMH_DM_LOAIMATHANGDA.Selectcheckma
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_LOAIMATHANG_SelectByTenLoai]"
        Dim objCmd As DbCommand
        Dim ds As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_tenloaimathang_en", DbType.String, maloai)
            ds = db.ExecuteDataSet(objCmd)
            Return ds.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class