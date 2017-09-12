Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_LOAITHEDA

	Implements ITNTP_DM_LOAITHEDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_LOAITHEEntity) Implements ITNTP_DM_LOAITHEDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_LOAITHE_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_LOAITHEEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_LOAITHEEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_LOAITHEEntity)
                With lstobj(i)
                    .uId_Loaithe = IIf(IsDBNull(objReader("uId_Loaithe")) = True, "", Convert.ToString(objReader("uId_Loaithe")))
                    .nv_Tenloaithe_vn = IIf(IsDBNull(objReader("nv_Tenloaithe_vn")) = True, "", objReader("nv_Tenloaithe_vn"))
                    .nv_Tenloaithe_en = IIf(IsDBNull(objReader("nv_Tenloaithe_en")) = True, "", objReader("nv_Tenloaithe_en"))
                    .f_Sotiendinhmuc = IIf(IsDBNull(objReader("f_Sotiendinhmuc")) = True, 0, objReader("f_Sotiendinhmuc"))
                    .f_Phantramchietkhau = IIf(IsDBNull(objReader("f_Phantramchietkhau")) = True, 0, objReader("f_Phantramchietkhau"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_LOAITHEEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ITNTP_DM_LOAITHEDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_LOAITHE_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Loaithe As String) As CM.TNTP_DM_LOAITHEEntity Implements ITNTP_DM_LOAITHEDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_LOAITHE_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_LOAITHEEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaithe", System.Data.DbType.String, uId_Loaithe)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_LOAITHEEntity
            If objReader.Read Then
                With obj
                    .uId_Loaithe = IIf(IsDBNull(objReader("uId_Loaithe")) = True, "", Convert.ToString(objReader("uId_Loaithe")))
                    .nv_Tenloaithe_vn = IIf(IsDBNull(objReader("nv_Tenloaithe_vn")) = True, "", objReader("nv_Tenloaithe_vn"))
                    .nv_Tenloaithe_en = IIf(IsDBNull(objReader("nv_Tenloaithe_en")) = True, "", objReader("nv_Tenloaithe_en"))
                    .f_Sotiendinhmuc = IIf(IsDBNull(objReader("f_Sotiendinhmuc")) = True, 0, objReader("f_Sotiendinhmuc"))
                    .f_Phantramchietkhau = IIf(IsDBNull(objReader("f_Phantramchietkhau")) = True, 0, objReader("f_Phantramchietkhau"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_LOAITHEEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_LOAITHEEntity) As Boolean Implements ITNTP_DM_LOAITHEDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_LOAITHE_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenloaithe_vn", DbType.String, obj.nv_Tenloaithe_vn)
            db.AddInParameter(objCmd, "@nv_Tenloaithe_en", DbType.String, obj.nv_Tenloaithe_en)
            db.AddInParameter(objCmd, "@f_Sotiendinhmuc", DbType.Double, obj.f_Sotiendinhmuc)
            db.AddInParameter(objCmd, "@f_Phantramchietkhau", DbType.Double, obj.f_Phantramchietkhau)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Loaithe AS String) As Boolean Implements ITNTP_DM_LOAITHEDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_LOAITHE_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String,uId_Loaithe)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_LOAITHEEntity) As Boolean Implements ITNTP_DM_LOAITHEDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_LOAITHE_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String, obj.uId_Loaithe)
            db.AddInParameter(objCmd, "@nv_Tenloaithe_vn", DbType.String, obj.nv_Tenloaithe_vn)
            db.AddInParameter(objCmd, "@nv_Tenloaithe_en", DbType.String, obj.nv_Tenloaithe_en)
            db.AddInParameter(objCmd, "@f_Sotiendinhmuc", DbType.Double, obj.f_Sotiendinhmuc)
            db.AddInParameter(objCmd, "@f_Phantramchietkhau", DbType.Double, obj.f_Phantramchietkhau)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class