Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_KH_TIEMNANGDA

    Implements IMKT_KH_TIEMNANGDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_KH_TIEMNANGEntity) Implements IMKT_KH_TIEMNANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_KH_TIEMNANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_KH_TIEMNANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_KH_TIEMNANGEntity)
                With lstobj(i)
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachhang = IIf(IsDBNull(objReader("v_Makhachhang")) = True, "", objReader("v_Makhachhang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_KH_TIEMNANGEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal Tungay As DateTime, ByVal Denngay As DateTime, uid_Cuahang As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uid_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_KH_Tiemnang As String) As CM.MKT_KH_TIEMNANGEntity Implements IMKT_KH_TIEMNANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_KH_TIEMNANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", System.Data.DbType.String, uId_KH_Tiemnang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_KH_TIEMNANGEntity
            If objReader.Read Then
                With obj
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachhang = IIf(IsDBNull(objReader("v_Makhachhang")) = True, "", objReader("v_Makhachhang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                    .Ghichu = IIf(IsDBNull(objReader("Ghichu")) = True, "", objReader("Ghichu"))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Xaphuong = IIf(IsDBNull(objReader("uId_Xaphuong")) = True, "", Convert.ToString(objReader("uId_Xaphuong")))
                    .uId_Nghenghiep = IIf(IsDBNull(objReader("uId_Nghenghiep")) = True, "", Convert.ToString(objReader("uId_Nghenghiep")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_KH_TIEMNANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As String Implements IMKT_KH_TIEMNANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachhang", DbType.String, obj.v_Makhachhang)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Boolean, obj.b_Gioitinh)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Dienthoaikhac", DbType.String, obj.v_Dienthoaikhac)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@Ghichu", DbType.String, obj.Ghichu)
            If (obj.d_Ngaynhap <> Nothing And obj.d_Ngaynhap <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaynhap", DbType.DateTime, obj.d_Ngaynhap)
            End If
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Xaphuong", DbType.String, obj.uId_Xaphuong)
            db.AddInParameter(objCmd, "@uId_Nghenghiep", DbType.String, obj.uId_Nghenghiep)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_KH_Tiemnang As String) As Boolean Implements IMKT_KH_TIEMNANGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean Implements IMKT_KH_TIEMNANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_Makhachhang", DbType.String, obj.v_Makhachhang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Boolean, obj.b_Gioitinh)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Dienthoaikhac", DbType.String, obj.v_Dienthoaikhac)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@Ghichu", DbType.String, obj.Ghichu)
            'If (obj.d_Ngaynhap <> Nothing And obj.d_Ngaynhap <> Date.MinValue) Then
            '    db.AddInParameter(objCmd, "@d_Ngaynhap", DbType.DateTime, obj.d_Ngaynhap)
            'End If
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Xaphuong", DbType.String, obj.uId_Xaphuong)
            db.AddInParameter(objCmd, "@uId_Nghenghiep", DbType.String, obj.uId_Nghenghiep)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function MaKH() As String Implements IMKT_KH_TIEMNANGDA.MaKH
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectMaKhachhangMax]"
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

    Public Function TimKiem(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.TimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_Timkiem_Test]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachhang", DbType.String, obj.v_Makhachhang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@Ghichu", DbType.String, obj.Ghichu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function TimKiemNangCao(ByVal keyword As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.TimKiemNangCao
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_Timkiem_nangcao]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@keyword", DbType.String, keyword)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectCongviec(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_KH_Tiemnang As String, ByVal strLoai As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectCongviec
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectCongviec]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, uId_KH_Tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Dim dt As DataTable
            Select Case strLoai
                Case "1"
                    dt = objDs.Tables(0)
                Case "2"
                    dt = objDs.Tables(1)
                Case "3"
                    dt = objDs.Tables(2)
                Case Else
                    dt = objDs.Tables(0)
                    dt.Merge(objDs.Tables(1))
                    dt.Merge(objDs.Tables(2))
            End Select
            Return dt
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectLSchuyendoi(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectLSchuyendoi
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectLSchuyendoi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, uId_KH_Tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByDaCoHoSo(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal b_Gioitinh As Boolean, ByVal Type As Integer) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectByDaCoHoSo
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SELECTBYDACOHOSO]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            db.AddInParameter(objCmd, "@Type", DbType.Int32, Type)
            db.AddInParameter(objCmd, "@Tuoitu", DbType.Int32, TuoiTu)
            db.AddInParameter(objCmd, "@Tuoiden", DbType.Int32, TuoiDen)
            db.AddInParameter(objCmd, "@Gioitinh", DbType.Boolean, b_Gioitinh)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SELECTBYMaKHHethong(ByVal uId_Khachhang As String) As CM.MKT_KH_TIEMNANGEntity Implements IMKT_KH_TIEMNANGDA.SELECTBYMaKHHethong
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SELECTBYMaKHHethong]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_KH_TIEMNANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", System.Data.DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_KH_TIEMNANGEntity
            If objReader.Read Then
                With obj
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachhang = IIf(IsDBNull(objReader("v_Makhachhang")) = True, "", objReader("v_Makhachhang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_KH_TIEMNANGEntity
        End Try
    End Function

    Public Function SelectByCapChuyen(ByVal Tungay As Date, ByVal Denngay As Date, ByVal uId_Chuyendoi As String, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal b_Gioitinh As Boolean, ByVal Type As Integer) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectByCapChuyen
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SELECTBYCAPCHUYEN]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            db.AddInParameter(objCmd, "@uId_Chuyendoi", DbType.String, uId_Chuyendoi)
            db.AddInParameter(objCmd, "@Type", DbType.Int32, Type)
            db.AddInParameter(objCmd, "@Tuoitu", DbType.Int32, TuoiTu)
            db.AddInParameter(objCmd, "@Tuoiden", DbType.Int32, TuoiDen)
            db.AddInParameter(objCmd, "@Gioitinh", DbType.Boolean, b_Gioitinh)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function KiemtraTontaiSDT(ByVal SDT As String, ByVal Email As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.KiemtraTontaiSDT
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_KiemtraTontaiSDT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@SDT", DbType.String, SDT)
            db.AddInParameter(objCmd, "@Email", DbType.String, Email)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAll_V1(ByVal Tungay As DateTime, ByVal Denngay As DateTime, uId_Phong As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectAll_V1
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SELECTALL_V1]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            db.AddInParameter(objCmd, "uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByIDCapChuyen(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectByIDCapChuyen
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectByIDCapChuyen]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, uId_KH_Tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function LichSuKhachHang(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_KH_Tiemnang As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.LichSuKhachHang
        Dim db As Database
        Dim sp As String = "[dbo].[sp_LichSuKhachHang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_KH_Tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByMaKH(ByVal v_Makhachhang As String) As CM.MKT_KH_TIEMNANGEntity Implements IMKT_KH_TIEMNANGDA.SelectByMaKH
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_KH_TIEMNAG_SelectByMaKhachHang]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_KH_TIEMNANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachhang", System.Data.DbType.String, v_Makhachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_KH_TIEMNANGEntity
            If objReader.Read Then
                With obj
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachhang = IIf(IsDBNull(objReader("v_Makhachhang")) = True, "", objReader("v_Makhachhang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                    .Ghichu = IIf(IsDBNull(objReader("Ghichu")) = True, "", objReader("Ghichu"))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Xaphuong = IIf(IsDBNull(objReader("uId_Xaphuong")) = True, "", Convert.ToString(objReader("uId_Xaphuong")))
                    .uId_Nghenghiep = IIf(IsDBNull(objReader("uId_Nghenghiep")) = True, "", Convert.ToString(objReader("uId_Nghenghiep")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_KH_TIEMNANGEntity
        End Try
    End Function

    Public Function TongHopKHTiemNang(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.TongHopKHTiemNang
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_KH_Tiemnang_SelectTongHop]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectKHUutienChamsoc(Tungay As Date, Denngay As Date, uId_Cuahang As String, Type As String) As DataTable Implements IMKT_KH_TIEMNANGDA.SelectKHUutienChamsoc
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KHACHHANG_SelectUutien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Type", DbType.String, Type)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function ChamsocKH(Tungay As String, Denngay As Date, uId_Cuahang As String, loaiKH As String, Thamso As String) As DataTable Implements IMKT_KH_TIEMNANGDA.ChamsocKH
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_ChamsocKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Loaikh", DbType.String, loaiKH)
            db.AddInParameter(objCmd, "@Thamso", DbType.String, Thamso)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class