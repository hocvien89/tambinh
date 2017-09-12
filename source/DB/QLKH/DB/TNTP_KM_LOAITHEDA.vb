Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_KM_LOAITHEDA

	Implements ITNTP_KM_LOAITHEDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_KM_LOAITHEEntity) Implements ITNTP_KM_LOAITHEDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KM_LOAITHE_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_KM_LOAITHEEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_KM_LOAITHEEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_KM_LOAITHEEntity)
                With lstobj(i)
                    .uId_KM_Loaithe = IIf(IsDBNull(objReader("uId_KM_Loaithe")) = True, "", Convert.ToString(objReader("uId_KM_Loaithe")))
                    .uId_Loaithe = IIf(IsDBNull(objReader("uId_Loaithe")) = True, "", Convert.ToString(objReader("uId_Loaithe")))
                    .v_MaKM = IIf(IsDBNull(objReader("v_MaKM")) = True, "", objReader("v_MaKM"))
                    .nv_TenKM = IIf(IsDBNull(objReader("nv_TenKM")) = True, "", objReader("nv_TenKM"))
                    .f_Chietkhau = IIf(IsDBNull(objReader("f_Chietkhau")) = True, 0, objReader("f_Chietkhau"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_KM_LOAITHEEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ITNTP_KM_LOAITHEDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_KM_LOAITHE_SelectAll]"
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

    Public Function SelectByID() As CM.TNTP_KM_LOAITHEEntity Implements ITNTP_KM_LOAITHEDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KM_LOAITHE_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_KM_LOAITHEEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_KM_LOAITHEEntity
            If objReader.Read Then
                With obj
                    .uId_KM_Loaithe = IIf(IsDBNull(objReader("uId_KM_Loaithe")) = True, "", Convert.ToString(objReader("uId_KM_Loaithe")))
                    .uId_Loaithe = IIf(IsDBNull(objReader("uId_Loaithe")) = True, "", Convert.ToString(objReader("uId_Loaithe")))
                    .v_MaKM = IIf(IsDBNull(objReader("v_MaKM")) = True, "", objReader("v_MaKM"))
                    .nv_TenKM = IIf(IsDBNull(objReader("nv_TenKM")) = True, "", objReader("nv_TenKM"))
                    .f_Chietkhau = IIf(IsDBNull(objReader("f_Chietkhau")) = True, 0, objReader("f_Chietkhau"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_KM_LOAITHEEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_KM_LOAITHEEntity) As Boolean Implements ITNTP_KM_LOAITHEDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KM_LOAITHE_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String, obj.uId_Loaithe)
            db.AddInParameter(objCmd, "@v_MaKM", DbType.String, obj.v_MaKM)
            db.AddInParameter(objCmd, "@nv_TenKM", DbType.String, obj.nv_TenKM)
            db.AddInParameter(objCmd, "@f_Chietkhau", DbType.Double, obj.f_Chietkhau)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_KM_Loaithe As String) As Boolean Implements ITNTP_KM_LOAITHEDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KM_LOAITHE_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KM_Loaithe", DbType.String, uId_KM_Loaithe)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KM_LOAITHEEntity) As Boolean Implements ITNTP_KM_LOAITHEDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KM_LOAITHE_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KM_Loaithe", DbType.String, obj.uId_KM_Loaithe)
            db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String, obj.uId_Loaithe)
            db.AddInParameter(objCmd, "@v_MaKM", DbType.String, obj.v_MaKM)
            db.AddInParameter(objCmd, "@nv_TenKM", DbType.String, obj.nv_TenKM)
            db.AddInParameter(objCmd, "@f_Chietkhau", DbType.Double, obj.f_Chietkhau)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class