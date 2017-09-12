Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DM_NHACUNGCAPDA

	Implements IQLMH_DM_NHACUNGCAPDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DM_NHACUNGCAPEntity) Implements IQLMH_DM_NHACUNGCAPDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHACUNGCAP_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DM_NHACUNGCAPEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DM_NHACUNGCAPEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DM_NHACUNGCAPEntity)
                With lstobj(i)
                    .uId_Nhacungcap = IIf(IsDBNull(objReader("uId_Nhacungcap")) = True, "", Convert.ToString(objReader("uId_Nhacungcap")))
                    .v_Manhacungcap = IIf(IsDBNull(objReader("v_Manhacungcap")) = True, "", objReader("v_Manhacungcap"))
                    .nv_Tennhacungcap_vn = IIf(IsDBNull(objReader("nv_Tennhacungcap_vn")) = True, "", objReader("nv_Tennhacungcap_vn"))
                    .nv_Tennhacungcap_en = IIf(IsDBNull(objReader("nv_Tennhacungcap_en")) = True, "", objReader("nv_Tennhacungcap_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DM_NHACUNGCAPEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQLMH_DM_NHACUNGCAPDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_NHACUNGCAP_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Nhacungcap As String) As CM.QLMH_DM_NHACUNGCAPEntity Implements IQLMH_DM_NHACUNGCAPDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHACUNGCAP_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_NHACUNGCAPEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhacungcap", System.Data.DbType.String, uId_Nhacungcap)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_NHACUNGCAPEntity
            If objReader.Read Then
                With obj
                    .uId_Nhacungcap = IIf(IsDBNull(objReader("uId_Nhacungcap")) = True, "", Convert.ToString(objReader("uId_Nhacungcap")))
                    .v_Manhacungcap = IIf(IsDBNull(objReader("v_Manhacungcap")) = True, "", objReader("v_Manhacungcap"))
                    .nv_Tennhacungcap_vn = IIf(IsDBNull(objReader("nv_Tennhacungcap_vn")) = True, "", objReader("nv_Tennhacungcap_vn"))
                    .nv_Tennhacungcap_en = IIf(IsDBNull(objReader("nv_Tennhacungcap_en")) = True, "", objReader("nv_Tennhacungcap_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_NHACUNGCAPEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_NHACUNGCAPEntity) As Boolean Implements IQLMH_DM_NHACUNGCAPDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHACUNGCAP_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Manhacungcap", DbType.String, obj.v_Manhacungcap)
            db.AddInParameter(objCmd, "@nv_Tennhacungcap_vn", DbType.String, obj.nv_Tennhacungcap_vn)
            db.AddInParameter(objCmd, "@nv_Tennhacungcap_en", DbType.String, obj.nv_Tennhacungcap_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Nhacungcap AS String) As Boolean Implements IQLMH_DM_NHACUNGCAPDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_NHACUNGCAP_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Nhacungcap", DbType.String,uId_Nhacungcap)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_NHACUNGCAPEntity) As Boolean Implements IQLMH_DM_NHACUNGCAPDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_NHACUNGCAP_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhacungcap", DbType.String, obj.uId_Nhacungcap)
            db.AddInParameter(objCmd, "@v_Manhacungcap", DbType.String, obj.v_Manhacungcap)
            db.AddInParameter(objCmd, "@nv_Tennhacungcap_vn", DbType.String, obj.nv_Tennhacungcap_vn)
            db.AddInParameter(objCmd, "@nv_Tennhacungcap_en", DbType.String, obj.nv_Tennhacungcap_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class