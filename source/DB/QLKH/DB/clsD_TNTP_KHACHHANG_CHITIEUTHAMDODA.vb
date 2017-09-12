Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_KHACHHANG_CHITIEUTHAMDODA

	Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Khachhang As String) As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_CHITIEUTHAMDO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity)
                With lstobj(i)
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Chitieuthamdo = IIf(IsDBNull(objReader("uId_Chitieuthamdo")) = True, "", Convert.ToString(objReader("uId_Chitieuthamdo")))
                    .d_Ngaythamdo = IIf(IsDBNull(objReader("d_Ngaythamdo")) = True, Nothing, objReader("d_Ngaythamdo"))
                    .f_Giatri_So = IIf(IsDBNull(objReader("f_Giatri_So")) = True, 0, objReader("f_Giatri_So"))
                    .nv_Giatri_Xau_vn = IIf(IsDBNull(objReader("nv_Giatri_Xau_vn")) = True, "", objReader("nv_Giatri_Xau_vn"))
                    .nv_Giatri_Xau_en = IIf(IsDBNull(objReader("nv_Giatri_Xau_en")) = True, "", objReader("nv_Giatri_Xau_en"))
                    .b_Giatri_Bit = IIf(IsDBNull(objReader("b_Giatri_Bit")) = True, 0, objReader("b_Giatri_Bit"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .nv_Tenchitieuthamdo_vn = IIf(IsDBNull(objReader("nv_Tenchitieuthamdo_vn")) = True, "", objReader("nv_Tenchitieuthamdo_vn"))
                    .v_Makhachang = IIf(IsDBNull(objReader("v_Makhachang")) = True, "", objReader("v_Makhachang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Khachhang AS String) AS System.Data.DataTable Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_KHACHHANG_CHITIEUTHAMDO_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet 
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String,uId_Khachhang)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function


    Public Function SelectByID(ByVal uId_Khachhang As String, ByVal d_Ngaythamdo As DateTime) As System.Data.DataTable Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_CHITIEUTHAMDO_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@d_Ngaythamdo", DbType.DateTime, d_Ngaythamdo)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)

        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) As Boolean Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_CHITIEUTHAMDO_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Chitieuthamdo", DbType.String, obj.uId_Chitieuthamdo)
            If (obj.d_Ngaythamdo <> Nothing And obj.d_Ngaythamdo <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaythamdo", DbType.DateTime, obj.d_Ngaythamdo)
            End If
            db.AddInParameter(objCmd, "@f_Giatri_So", DbType.Double, obj.f_Giatri_So)
            db.AddInParameter(objCmd, "@nv_Giatri_Xau_vn", DbType.String, obj.nv_Giatri_Xau_vn)
            db.AddInParameter(objCmd, "@nv_Giatri_Xau_en", DbType.String, obj.nv_Giatri_Xau_en)
            db.AddInParameter(objCmd, "@b_Giatri_Bit", DbType.Boolean, obj.b_Giatri_Bit)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Khachhang As String, ByVal uId_Chitieuthamdo As String) As Boolean Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_CHITIEUTHAMDO_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Chitieuthamdo", DbType.String, uId_Chitieuthamdo)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) As Boolean Implements ITNTP_KHACHHANG_CHITIEUTHAMDODA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_CHITIEUTHAMDO_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Chitieuthamdo", DbType.String, obj.uId_Chitieuthamdo)
            If (obj.d_Ngaythamdo <> Nothing And obj.d_Ngaythamdo <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaythamdo", DbType.DateTime, obj.d_Ngaythamdo)
            End If
            db.AddInParameter(objCmd, "@f_Giatri_So", DbType.Double, obj.f_Giatri_So)
            db.AddInParameter(objCmd, "@nv_Giatri_Xau_vn", DbType.String, obj.nv_Giatri_Xau_vn)
            db.AddInParameter(objCmd, "@nv_Giatri_Xau_en", DbType.String, obj.nv_Giatri_Xau_en)
            db.AddInParameter(objCmd, "@b_Giatri_Bit", DbType.Boolean, obj.b_Giatri_Bit)
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