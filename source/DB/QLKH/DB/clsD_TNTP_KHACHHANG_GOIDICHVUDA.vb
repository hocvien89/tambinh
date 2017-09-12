Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_KHACHHANG_GOIDICHVUDA

    Implements ITNTP_KHACHHANG_GOIDICHVUDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_GOIDICHVUEntity) Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_KHACHHANG_GOIDICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_KHACHHANG_GOIDICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_KHACHHANG_GOIDICHVUEntity)
                With lstobj(i)
                    .uId_Khachhang_Goidichvu = IIf(IsDBNull(objReader("uId_Khachhang_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Khachhang_Goidichvu")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .d_Ngaymua = IIf(IsDBNull(objReader("d_Ngaymua")) = True, Nothing, objReader("d_Ngaymua"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .d_NgayBD = IIf(IsDBNull(objReader("d_NgayBD")) = True, Nothing, objReader("d_NgayBD"))
                    .d_NgayKT = IIf(IsDBNull(objReader("d_NgayKT")) = True, Nothing, objReader("d_NgayKT"))
                    .b_Tatca_Dichvu = IIf(IsDBNull(objReader("b_Tatca_Dichvu")) = True, False, objReader("b_Tatca_Dichvu"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_KHACHHANG_GOIDICHVUEntity)
        End Try
    End Function

    Public Function SelectAllTable_ByKH(ByVal uId_Khachhang As String, ByVal DK As Integer) As System.Data.DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectAllTable_ByKH
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DK", DbType.Int16, DK)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "spTNTP_KHACHHANG_GOIDICHVU_SelectAll_By_Cuahang"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Khachhang_Goidichvu As String) As CM.TNTP_KHACHHANG_GOIDICHVUEntity Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, uId_Khachhang_Goidichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Khachhang_Goidichvu = IIf(IsDBNull(objReader("uId_Khachhang_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Khachhang_Goidichvu")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .d_Ngaymua = IIf(IsDBNull(objReader("d_Ngaymua")) = True, Nothing, objReader("d_Ngaymua"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .i_TongSolanthuchien = IIf(IsDBNull(objReader("i_TongSolanthuchien")) = True, 0, objReader("i_TongSolanthuchien"))
                    .d_NgayBD = IIf(IsDBNull(objReader("d_NgayBD")) = True, Nothing, objReader("d_NgayBD"))
                    .d_NgayKT = IIf(IsDBNull(objReader("d_NgayKT")) = True, Nothing, objReader("d_NgayKT"))
                    .b_Tatca_Dichvu = IIf(IsDBNull(objReader("b_Tatca_Dichvu")) = True, False, objReader("b_Tatca_Dichvu"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .f_Giatrigoi = IIf(IsDBNull(objReader("f_Giatrigoi")) = True, 0, objReader("f_Giatrigoi"))
                    .vMaBarcode = IIf(IsDBNull(objReader("vMaBarcode")) = True, "", objReader("vMaBarcode"))
                    .b_Kichhoat = IIf(IsDBNull(objReader("b_Kichhoat")) = True, False, objReader("b_Kichhoat"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        End Try
    End Function

    Public Function SelectByvBarcode(ByVal vMaBarcode As String) As CM.TNTP_KHACHHANG_GOIDICHVUEntity Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectByvBarcode
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_SelectByvMaBarcode]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@vMaBarcode", DbType.String, vMaBarcode)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Khachhang_Goidichvu = IIf(IsDBNull(objReader("uId_Khachhang_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Khachhang_Goidichvu")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .d_Ngaymua = IIf(IsDBNull(objReader("d_Ngaymua")) = True, Nothing, objReader("d_Ngaymua"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .i_TongSolanthuchien = IIf(IsDBNull(objReader("i_TongSolanthuchien")) = True, 0, objReader("i_TongSolanthuchien"))
                    .d_NgayBD = IIf(IsDBNull(objReader("d_NgayBD")) = True, Nothing, objReader("d_NgayBD"))
                    .d_NgayKT = IIf(IsDBNull(objReader("d_NgayKT")) = True, Nothing, objReader("d_NgayKT"))
                    .b_Tatca_Dichvu = IIf(IsDBNull(objReader("b_Tatca_Dichvu")) = True, False, objReader("b_Tatca_Dichvu"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .f_Giatrigoi = IIf(IsDBNull(objReader("f_Giatrigoi")) = True, 0, objReader("f_Giatrigoi"))
                    .vMaBarcode = IIf(IsDBNull(objReader("vMaBarcode")) = True, 0, objReader("f_Giatrigoi"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        End Try
    End Function


    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As String Implements ITNTP_KHACHHANG_GOIDICHVUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, obj.uId_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            If (obj.d_Ngaymua <> Nothing And obj.d_Ngaymua <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaymua", DbType.DateTime, obj.d_Ngaymua)
            End If
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.AddInParameter(objCmd, "@f_Giatrigoi", DbType.Double, obj.f_Giatrigoi)
            db.AddInParameter(objCmd, "@i_TongSolanthuchien", DbType.Double, obj.i_TongSolanthuchien)
            If (obj.d_NgayKT <> Nothing And obj.d_NgayKT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayKT", DbType.DateTime, obj.d_NgayKT)
            End If
            db.AddInParameter(objCmd, "@b_Tatca_Dichvu", DbType.Boolean, obj.b_Tatca_Dichvu)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)

            db.AddInParameter(objCmd, "@vMaBarcode", DbType.String, obj.vMaBarcode)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Khachhang_Kichhoat", DbType.String, obj.uId_Khachhang_Kichhoat)
            db.AddInParameter(objCmd, "@b_Kichhoat", DbType.Boolean, obj.b_Kichhoat)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Khachhang_Goidichvu As String) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, uId_Khachhang_Goidichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, obj.uId_Khachhang_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, obj.uId_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            If (obj.d_Ngaymua <> Nothing And obj.d_Ngaymua <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaymua", DbType.DateTime, obj.d_Ngaymua)
            End If
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.AddInParameter(objCmd, "@f_Giatrigoi", DbType.Double, obj.f_Giatrigoi)
            db.AddInParameter(objCmd, "@i_TongSolanthuchien", DbType.Double, obj.i_TongSolanthuchien)
            If (obj.d_NgayBD <> Nothing And obj.d_NgayBD <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayBD", DbType.DateTime, obj.d_NgayBD)
            End If
            If (obj.d_NgayKT <> Nothing And obj.d_NgayKT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayKT", DbType.DateTime, obj.d_NgayKT)
            End If
            db.AddInParameter(objCmd, "@b_Tatca_Dichvu", DbType.Boolean, obj.b_Tatca_Dichvu)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.AddInParameter(objCmd, "@vMaBarcode", DbType.String, obj.vMaBarcode)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function ThanhToan(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.ThanhToan
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_Thanhtoan]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, obj.uId_Khachhang_Goidichvu)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Hoantien(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.Hoantien
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_Hoantien]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function UpdateTrangthai(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.UpdateTrangthai
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_Update_Trangthai]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, obj.uId_Khachhang_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Khachhang_Kichhoat", DbType.String, obj.uId_Khachhang_Kichhoat)
            db.AddInParameter(objCmd, "@f_Giatrigoi", DbType.Double, obj.f_Giatrigoi)
            db.AddInParameter(objCmd, "@b_Kichhoat", DbType.Boolean, obj.b_Kichhoat)
            db.AddInParameter(objCmd, "@d_NgayBD", DbType.DateTime, obj.d_NgayBD)
            db.AddInParameter(objCmd, "@d_NgayKT", DbType.DateTime, obj.d_NgayKT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function


    Public Function SelectAllTable_DSTHE_Daban(ByVal uId_Cuahang As String, ByVal vType As String) As System.Data.DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectAllTable_DSTHE_Daban
        Dim db As Database
        Dim sp As String = "spSelectAll_DSTHE_Daban_By_Cuahang"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@vType", DbType.String, vType)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function chkExist_MaTheThanhtoan(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.chkExist_MaTheThanhtoan
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_CheckExist_Mathe]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim bReturnValue As Boolean = False
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@vMaBarcode", DbType.String, obj.vMaBarcode)
            objDs = db.ExecuteDataSet(objCmd)
            Dim DT As DataTable = objDs.Tables(0)
            If Not DT Is Nothing Then
                If DT.Rows.Count > 0 Then
                    bReturnValue = True
                End If
            End If
            DT = Nothing
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try

        db = Nothing
        objCmd = Nothing
        objDs = Nothing
        Return bReturnValue
    End Function

    Public Function BaoCao_DSTheKhachHang(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Keyword As String) As System.Data.DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.BaoCao_DSTheKhachHang
        Dim db As Database
        Dim sp As String = "spBAOCAO_DSTheKhachHang"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@keyword", DbType.String, Keyword)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function LichSuThanhtoan(v_MaThe As String) As DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.LichSuThanhtoan
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_LichSuThanhtoan]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaThe", DbType.String, v_MaThe)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByDate(TuNgay As Date, DenNgay As Date, uId_Cuahang As String, uId_Trangthai As String) As DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectByDate
        Dim db As Database
        Dim sp As String = "spTNTP_KHACHHANG_GOIDICHVU_SelectByDate"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.String, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, uId_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function CreateMaCode() As String Implements ITNTP_KHACHHANG_GOIDICHVUDA.CreateMaCode
        Dim db As Database
        Dim sp As String = "[dbo].[spCreate_CodeTheKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "1"
        End Try
    End Function

    Public Function Check_Capthe_By_PDV(uId_Phieudichvu As String, uId_Dichvu As String) As DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.Check_Capthe_By_PDV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Check_Capthe_Thanhtoan_ByPDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_TheTaiKhoan_By_Khachhang(uId_Khachhang As String, Luachon As Integer) As DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.Select_TheTaiKhoan_By_Khachhang
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_GOIDICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DK", DbType.Int16, Luachon)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectBy_Mathe(v_Mathe As String) As DataTable Implements ITNTP_KHACHHANG_GOIDICHVUDA.SelectBy_Mathe
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Thongtin_The_By_Mathe]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Mathe", DbType.String, v_Mathe)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Update_Khachhang_GoiDichvu(uId_Khachhang_Goidichvu As String) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUDA.Update_Khachhang_GoiDichvu
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Update_Thekhachhang_By_uId_Khachhang_Goidichvu]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, uId_Khachhang_Goidichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class