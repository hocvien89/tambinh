Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_NHOMDIEUTRI_HPDA

	Implements ITNTP_NHOMDIEUTRI_HPDA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Khachhang As String, ByVal uId_Nhomdichvu As String) As System.Collections.Generic.List(Of CM.TNTP_NHOMDIEUTRI_HPEntity) Implements ITNTP_NHOMDIEUTRI_HPDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NHOMDIEUTRI_HP_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_NHOMDIEUTRI_HPEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_NHOMDIEUTRI_HPEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_NHOMDIEUTRI_HPEntity)
                With lstobj(i)
                    .uId_Nhomdieutri = IIf(IsDBNull(objReader("uId_Nhomdieutri")) = True, "", Convert.ToString(objReader("uId_Nhomdieutri")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhomdichvu = IIf(IsDBNull(objReader("uId_Nhomdichvu")) = True, "", Convert.ToString(objReader("uId_Nhomdichvu")))
                    .f_LephiTong = IIf(IsDBNull(objReader("f_LephiTong")) = True, 0, objReader("f_LephiTong"))
                    .nv_Chandoan_vn = IIf(IsDBNull(objReader("nv_Chandoan_vn")) = True, "", objReader("nv_Chandoan_vn"))
                    .nv_Chandoan_en = IIf(IsDBNull(objReader("nv_Chandoan_en")) = True, "", objReader("nv_Chandoan_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_NHOMDIEUTRI_HPEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Khachhang AS String,ByVal uId_Nhomdichvu AS String) AS System.Data.DataTable Implements ITNTP_NHOMDIEUTRI_HPDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_NHOMDIEUTRI_HP_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet 
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String,uId_Khachhang)
			db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String,uId_Nhomdichvu)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function


    Public Function SelectByID(ByVal uId_Nhomdieutri As String) As CM.TNTP_NHOMDIEUTRI_HPEntity Implements ITNTP_NHOMDIEUTRI_HPDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NHOMDIEUTRI_HP_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_NHOMDIEUTRI_HPEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdieutri", DbType.String, uId_Nhomdieutri)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_NHOMDIEUTRI_HPEntity
            If objReader.Read Then
                With obj
                    .uId_Nhomdieutri = IIf(IsDBNull(objReader("uId_Nhomdieutri")) = True, "", Convert.ToString(objReader("uId_Nhomdieutri")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhomdichvu = IIf(IsDBNull(objReader("uId_Nhomdichvu")) = True, "", Convert.ToString(objReader("uId_Nhomdichvu")))
                    .f_LephiTong = IIf(IsDBNull(objReader("f_LephiTong")) = True, 0, objReader("f_LephiTong"))
                    .nv_Chandoan_vn = IIf(IsDBNull(objReader("nv_Chandoan_vn")) = True, "", objReader("nv_Chandoan_vn"))
                    .nv_Chandoan_en = IIf(IsDBNull(objReader("nv_Chandoan_en")) = True, "", objReader("nv_Chandoan_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_NHOMDIEUTRI_HPEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_NHOMDIEUTRI_HPEntity) As Boolean Implements ITNTP_NHOMDIEUTRI_HPDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NHOMDIEUTRI_HP_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, obj.uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@f_LephiTong", DbType.Double, obj.f_LephiTong)
            db.AddInParameter(objCmd, "@nv_Chandoan_vn", DbType.String, obj.nv_Chandoan_vn)
            db.AddInParameter(objCmd, "@nv_Chandoan_en", DbType.String, obj.nv_Chandoan_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Nhomdieutri AS String) As Boolean Implements ITNTP_NHOMDIEUTRI_HPDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_NHOMDIEUTRI_HP_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Nhomdieutri", DbType.String,uId_Nhomdieutri)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_NHOMDIEUTRI_HPEntity) As Boolean Implements ITNTP_NHOMDIEUTRI_HPDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_NHOMDIEUTRI_HP_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, obj.uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@f_LephiTong", DbType.Double, obj.f_LephiTong)
            db.AddInParameter(objCmd, "@nv_Chandoan_vn", DbType.String, obj.nv_Chandoan_vn)
            db.AddInParameter(objCmd, "@nv_Chandoan_en", DbType.String, obj.nv_Chandoan_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class