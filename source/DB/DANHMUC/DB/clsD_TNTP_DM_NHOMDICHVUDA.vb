Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_NHOMDICHVUDA

	Implements ITNTP_DM_NHOMDICHVUDA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.TNTP_DM_NHOMDICHVUEntity) Implements ITNTP_DM_NHOMDICHVUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_NHOMDICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_NHOMDICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_NHOMDICHVUEntity)
                With lstobj(i)
                    .uId_Nhomdichvu = IIf(IsDBNull(objReader("uId_Nhomdichvu")) = True, "", Convert.ToString(objReader("uId_Nhomdichvu")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_TennhomDichvu_vn = IIf(IsDBNull(objReader("nv_TennhomDichvu_vn")) = True, "", objReader("nv_TennhomDichvu_vn"))
                    .nv_TennhomDichvu_en = IIf(IsDBNull(objReader("nv_TennhomDichvu_en")) = True, "", objReader("nv_TennhomDichvu_en"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                    .vType = IIf(IsDBNull(objReader("vType")) = True, "", objReader("vType"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_NHOMDICHVUEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable Implements ITNTP_DM_NHOMDICHVUDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_SelectAll]"
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


    Public Function SelectByID(ByVal uId_Nhomdichvu As String) As CM.TNTP_DM_NHOMDICHVUEntity Implements ITNTP_DM_NHOMDICHVUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_NHOMDICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_NHOMDICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Nhomdichvu = IIf(IsDBNull(objReader("uId_Nhomdichvu")) = True, "", Convert.ToString(objReader("uId_Nhomdichvu")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_TennhomDichvu_vn = IIf(IsDBNull(objReader("nv_TennhomDichvu_vn")) = True, "", objReader("nv_TennhomDichvu_vn"))
                    .nv_TennhomDichvu_en = IIf(IsDBNull(objReader("nv_TennhomDichvu_en")) = True, "", objReader("nv_TennhomDichvu_en"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .vType = IIf(IsDBNull(objReader("vType")) = True, "", objReader("vType"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_NHOMDICHVUEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_NHOMDICHVUEntity) As Boolean Implements ITNTP_DM_NHOMDICHVUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_TennhomDichvu_vn", DbType.String, obj.nv_TennhomDichvu_vn)
            db.AddInParameter(objCmd, "@nv_TennhomDichvu_en", DbType.String, obj.nv_TennhomDichvu_en)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@vType", DbType.String, obj.vType)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Nhomdichvu AS String) As Boolean Implements ITNTP_DM_NHOMDICHVUDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String,uId_Nhomdichvu)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_NHOMDICHVUEntity) As Boolean Implements ITNTP_DM_NHOMDICHVUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, obj.uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_TennhomDichvu_vn", DbType.String, obj.nv_TennhomDichvu_vn)
            db.AddInParameter(objCmd, "@nv_TennhomDichvu_en", DbType.String, obj.nv_TennhomDichvu_en)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@vType", DbType.String, obj.vType)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByName(tencuahang As String) As String Implements ITNTP_DM_NHOMDICHVUDA.SelectByname
        Dim db As Database
        Dim uidcuahang As String
        Dim sp As String = "[dbo].[spTNTP_DM_NHOMDICHVU_SelectByName]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tencuahang_vn", DbType.String, tencuahang)
            objReader = db.ExecuteReader(objCmd)
            If objReader.Read Then
                uidcuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                Return uidcuahang
            End If
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try

    End Function
End Class