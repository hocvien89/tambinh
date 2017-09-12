Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DM_KHODA

	Implements IQLMH_DM_KHODA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.QLMH_DM_KHOEntity) Implements IQLMH_DM_KHODA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_KHO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DM_KHOEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DM_KHOEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DM_KHOEntity)
                With lstobj(i)
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Makho = IIf(IsDBNull(objReader("v_Makho")) = True, "", objReader("v_Makho"))
                    .nv_Tenkho_vn = IIf(IsDBNull(objReader("nv_Tenkho_vn")) = True, "", objReader("nv_Tenkho_vn"))
                    .nv_Tenkho_en = IIf(IsDBNull(objReader("nv_Tenkho_en")) = True, "", objReader("nv_Tenkho_en"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DM_KHOEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable Implements IQLMH_DM_KHODA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_KHO_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet 
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String,uId_Cuahang)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function


    Public Function SelectByID(ByVal uId_Kho As String) As CM.QLMH_DM_KHOEntity Implements IQLMH_DM_KHODA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_KHO_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_KHOEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_KHOEntity
            If objReader.Read Then
                With obj
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Makho = IIf(IsDBNull(objReader("v_Makho")) = True, "", objReader("v_Makho"))
                    .nv_Tenkho_vn = IIf(IsDBNull(objReader("nv_Tenkho_vn")) = True, "", objReader("nv_Tenkho_vn"))
                    .nv_Tenkho_en = IIf(IsDBNull(objReader("nv_Tenkho_en")) = True, "", objReader("nv_Tenkho_en"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_KHOEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_KHOEntity) As Boolean Implements IQLMH_DM_KHODA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_KHO_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makho", DbType.String, obj.v_Makho)
            db.AddInParameter(objCmd, "@nv_Tenkho_vn", DbType.String, obj.nv_Tenkho_vn)
            db.AddInParameter(objCmd, "@nv_Tenkho_en", DbType.String, obj.nv_Tenkho_en)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Kho AS String) As Boolean Implements IQLMH_DM_KHODA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_KHO_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Kho", DbType.String,uId_Kho)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_KHOEntity) As Boolean Implements IQLMH_DM_KHODA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_KHO_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Makho", DbType.String, obj.v_Makho)
            db.AddInParameter(objCmd, "@nv_Tenkho_vn", DbType.String, obj.nv_Tenkho_vn)
            db.AddInParameter(objCmd, "@nv_Tenkho_en", DbType.String, obj.nv_Tenkho_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class