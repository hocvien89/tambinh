Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLP_DM_THIETBIDA

	Implements IQLP_DM_THIETBIDA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.QLP_DM_THIETBIEntity) Implements IQLP_DM_THIETBIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_THIETBI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLP_DM_THIETBIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLP_DM_THIETBIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLP_DM_THIETBIEntity)
                With lstobj(i)
                    .uId_Thietbi = IIf(IsDBNull(objReader("uId_Thietbi")) = True, "", Convert.ToString(objReader("uId_Thietbi")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Mathietbi = IIf(IsDBNull(objReader("v_Mathietbi")) = True, "", objReader("v_Mathietbi"))
                    .nv_Tenthietbi_vn = IIf(IsDBNull(objReader("nv_Tenthietbi_vn")) = True, "", objReader("nv_Tenthietbi_vn"))
                    .nv_Tenthietbi_en = IIf(IsDBNull(objReader("nv_Tenthietbi_en")) = True, "", objReader("nv_Tenthietbi_en"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLP_DM_THIETBIEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable Implements IQLP_DM_THIETBIDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLP_DM_THIETBI_SelectAll]"
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


    Public Function SelectByID(ByVal uId_Thietbi As String) As CM.QLP_DM_THIETBIEntity Implements IQLP_DM_THIETBIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_THIETBI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLP_DM_THIETBIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thietbi", DbType.String, uId_Thietbi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLP_DM_THIETBIEntity
            If objReader.Read Then
                With obj
                    .uId_Thietbi = IIf(IsDBNull(objReader("uId_Thietbi")) = True, "", Convert.ToString(objReader("uId_Thietbi")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Mathietbi = IIf(IsDBNull(objReader("v_Mathietbi")) = True, "", objReader("v_Mathietbi"))
                    .nv_Tenthietbi_vn = IIf(IsDBNull(objReader("nv_Tenthietbi_vn")) = True, "", objReader("nv_Tenthietbi_vn"))
                    .nv_Tenthietbi_en = IIf(IsDBNull(objReader("nv_Tenthietbi_en")) = True, "", objReader("nv_Tenthietbi_en"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLP_DM_THIETBIEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLP_DM_THIETBIEntity) As Boolean Implements IQLP_DM_THIETBIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_THIETBI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Mathietbi", DbType.String, obj.v_Mathietbi)
            db.AddInParameter(objCmd, "@nv_Tenthietbi_vn", DbType.String, obj.nv_Tenthietbi_vn)
            db.AddInParameter(objCmd, "@nv_Tenthietbi_en", DbType.String, obj.nv_Tenthietbi_en)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Thietbi AS String) As Boolean Implements IQLP_DM_THIETBIDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLP_DM_THIETBI_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Thietbi", DbType.String,uId_Thietbi)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLP_DM_THIETBIEntity) As Boolean Implements IQLP_DM_THIETBIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_THIETBI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thietbi", DbType.String, obj.uId_Thietbi)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Mathietbi", DbType.String, obj.v_Mathietbi)
            db.AddInParameter(objCmd, "@nv_Tenthietbi_vn", DbType.String, obj.nv_Tenthietbi_vn)
            db.AddInParameter(objCmd, "@nv_Tenthietbi_en", DbType.String, obj.nv_Tenthietbi_en)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class