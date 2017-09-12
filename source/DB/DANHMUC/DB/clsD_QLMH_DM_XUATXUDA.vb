Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DM_XUATXUDA

	Implements IQLMH_DM_XUATXUDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DM_XUATXUEntity) Implements IQLMH_DM_XUATXUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_XUATXU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DM_XUATXUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DM_XUATXUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DM_XUATXUEntity)
                With lstobj(i)
                    .uid_Xuatxu = IIf(IsDBNull(objReader("uid_Xuatxu")) = True, "", Convert.ToString(objReader("uid_Xuatxu")))
                    .nv_Tenxuatxu_vn = IIf(IsDBNull(objReader("nv_Tenxuatxu_vn")) = True, "", objReader("nv_Tenxuatxu_vn"))
                    .nv_Tenxuatxu_en = IIf(IsDBNull(objReader("nv_Tenxuatxu_en")) = True, "", objReader("nv_Tenxuatxu_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DM_XUATXUEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQLMH_DM_XUATXUDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_XUATXU_SelectAll]"
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

    Public Function SelectByID(ByVal uid_Xuatxu As String) As CM.QLMH_DM_XUATXUEntity Implements IQLMH_DM_XUATXUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_XUATXU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_XUATXUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uid_Xuatxu", System.Data.DbType.String, uid_Xuatxu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_XUATXUEntity
            If objReader.Read Then
                With obj
                    .uid_Xuatxu = IIf(IsDBNull(objReader("uid_Xuatxu")) = True, "", Convert.ToString(objReader("uid_Xuatxu")))
                    .nv_Tenxuatxu_vn = IIf(IsDBNull(objReader("nv_Tenxuatxu_vn")) = True, "", objReader("nv_Tenxuatxu_vn"))
                    .nv_Tenxuatxu_en = IIf(IsDBNull(objReader("nv_Tenxuatxu_en")) = True, "", objReader("nv_Tenxuatxu_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_XUATXUEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_XUATXUEntity) As Boolean Implements IQLMH_DM_XUATXUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_QLMH_DM_XUATXU_INSERT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Maxuatxu", DbType.String, obj.v_Maxuatxu)
            db.AddInParameter(objCmd, "@nv_Tenxuatxu_vn", DbType.String, obj.nv_Tenxuatxu_vn)
            db.AddInParameter(objCmd, "@nv_Tenxuatxu_en", DbType.String, obj.nv_Tenxuatxu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uid_Xuatxu AS String) As Boolean Implements IQLMH_DM_XUATXUDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLMH_DM_XUATXU_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uid_Xuatxu", DbType.String, uid_Xuatxu)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_XUATXUEntity) As Boolean Implements IQLMH_DM_XUATXUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_XUATXU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uid_Xuatxu", DbType.String, obj.uId_Xuatxu)
            db.AddInParameter(objCmd, "@v_Maxuatxu", DbType.String, obj.v_Maxuatxu)
            db.AddInParameter(objCmd, "@nv_Tenxuatxu_vn", DbType.String, obj.nv_Tenxuatxu_vn)
            db.AddInParameter(objCmd, "@nv_Tenxuatxu_en", DbType.String, obj.nv_Tenxuatxu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class