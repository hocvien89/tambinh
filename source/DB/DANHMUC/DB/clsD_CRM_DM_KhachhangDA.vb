Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_KhachhangDA
    Implements ICRM_DM_KhachhangDA
    Dim log As New LogError.ShowError
    Dim oLib As New Lib_SAT.cls_Pub_Functions

#Region "Ham Chuc nang"


    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_KhachhangEntity) Implements ICRM_DM_KhachhangDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_KhachhangEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_KhachhangEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_KhachhangEntity)
                With lstobj(i)
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachang = IIf(IsDBNull(objReader("v_Makhachang")) = True, "", objReader("v_Makhachang"))
                    .v_BarCode = IIf(IsDBNull(objReader("v_BarCode")) = True, "", objReader("v_BarCode"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, "", objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Nguyenquan_vn = IIf(IsDBNull(objReader("nv_Nguyenquan_vn")) = True, "", objReader("nv_Nguyenquan_vn"))
                    .nv_Nguyenquan_en = IIf(IsDBNull(objReader("nv_Nguyenquan_en")) = True, "", objReader("nv_Nguyenquan_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .i_SoCMT = IIf(IsDBNull(objReader("i_SoCMT")) = True, 0, objReader("i_SoCMT"))
                    .d_NgaycapCMT = IIf(IsDBNull(objReader("d_NgaycapCMT")) = True, "", objReader("d_NgaycapCMT"))
                    .nv_Noicap_vn = IIf(IsDBNull(objReader("nv_Noicap_vn")) = True, "", objReader("nv_Noicap_vn"))
                    .nv_Noicap_en = IIf(IsDBNull(objReader("nv_Noicap_en")) = True, "", objReader("nv_Noicap_en"))
                    .d_Ngayden = IIf(IsDBNull(objReader("d_Ngayden")) = True, Nothing, objReader("d_Ngayden"))
                    .uId_Nguonden = IIf(IsDBNull(objReader("uId_Nguonden")) = True, "", Convert.ToString(objReader("uId_Nguonden")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_KhachhangEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectAll]"
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

    Public Function TimKiemKH(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.TimKiemKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_Timkiem]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachang", DbType.String, obj.v_Makhachang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.String, obj.d_Ngaysinh)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function TimKiemKHChuan(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.TimKiemKHChuan
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_TimkiemChuan]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachang", DbType.String, obj.v_Makhachang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByIDEn(ByVal uId_Khachhang As String) As CM.CRM_DM_KhachhangEntity Implements ICRM_DM_KhachhangDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_KhachhangEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", System.Data.DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_KhachhangEntity
            If objReader.Read Then
                With obj
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachang = IIf(IsDBNull(objReader("v_Makhachang")) = True, "", objReader("v_Makhachang"))
                    .v_BarCode = IIf(IsDBNull(objReader("v_BarCode")) = True, "", objReader("v_BarCode"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    If .d_Ngaysinh <> Nothing Then
                        .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    End If
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Nguyenquan_vn = IIf(IsDBNull(objReader("nv_Nguyenquan_vn")) = True, "", objReader("nv_Nguyenquan_vn"))
                    .nv_Nguyenquan_en = IIf(IsDBNull(objReader("nv_Nguyenquan_en")) = True, "", objReader("nv_Nguyenquan_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .i_SoCMT = IIf(IsDBNull(objReader("i_SoCMT")) = True, 0, objReader("i_SoCMT"))
                    .d_NgaycapCMT = IIf(IsDBNull(objReader("d_NgaycapCMT")) = True, "", objReader("d_NgaycapCMT"))
                    .nv_Noicap_vn = IIf(IsDBNull(objReader("nv_Noicap_vn")) = True, "", objReader("nv_Noicap_vn"))
                    .nv_Noicap_en = IIf(IsDBNull(objReader("nv_Noicap_en")) = True, "", objReader("nv_Noicap_en"))
                    .d_Ngayden = IIf(IsDBNull(objReader("d_Ngayden")) = True, Nothing, objReader("d_Ngayden"))
                    .uId_Nguonden = IIf(IsDBNull(objReader("uId_Nguonden")) = True, "", Convert.ToString(objReader("uId_Nguonden")))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .uId_Xaphuong = IIf(IsDBNull(objReader("uId_Xaphuong")) = True, "", Convert.ToString(objReader("uId_Xaphuong")))
                    .nv_Hinhanh = IIf(IsDBNull(objReader("nv_Hinhanh")) = True, "", objReader("nv_Hinhanh"))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Nghenghiep = IIf(IsDBNull(objReader("uId_Nghenghiep")) = True, "", Convert.ToString(objReader("uId_Nghenghiep")))
                    .uId_Nguoigioithieu = IIf(IsDBNull(objReader("uId_Nguoigioithieu")) = True, "", Convert.ToString(objReader("uId_Nguoigioithieu")))
                    .nv_BietPhongKham = IIf(IsDBNull(objReader("nv_BietPhongKham")) = True, "", objReader("nv_BietPhongKham"))
                    .nv_VungBiDau = IIf(IsDBNull(objReader("nv_VungBiDau")) = True, "", objReader("nv_VungBiDau"))
                    .nv_DauBaoLau = IIf(IsDBNull(objReader("nv_DauBaoLau")) = True, "", objReader("nv_DauBaoLau"))
                    .nv_DaDieuTri = IIf(IsDBNull(objReader("nv_DaDieuTri")) = True, "", objReader("nv_DaDieuTri"))
                    .nv_CamGiacDau = IIf(IsDBNull(objReader("nv_CamGiacDau")) = True, "", objReader("nv_CamGiacDau"))
                    .nv_MucDoDau = IIf(IsDBNull(objReader("nv_MucDoDau")) = True, "", objReader("nv_MucDoDau"))
                    .nv_TuTheDauHon = IIf(IsDBNull(objReader("nv_TuTheDauHon")) = True, "", objReader("nv_TuTheDauHon"))
                    .nv_TuTheTotHon = IIf(IsDBNull(objReader("nv_TuTheTotHon")) = True, "", objReader("nv_TuTheTotHon"))
                    .nv_AnhHuong = IIf(IsDBNull(objReader("nv_AnhHuong")) = True, "", objReader("nv_AnhHuong"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_KhachhangEntity
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Khachhang As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.SelectByIDTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_KhachhangEntity) As String Implements ICRM_DM_KhachhangDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachang", DbType.String, obj.v_Makhachang) '1
            db.AddInParameter(objCmd, "@v_BarCode", DbType.String, obj.v_BarCode) '2
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn) '3
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en) '4
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh) '5
            End If
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Boolean, obj.b_Gioitinh) '6
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn) '7
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en) '8
            db.AddInParameter(objCmd, "@nv_Nguyenquan_vn", DbType.String, obj.nv_Nguyenquan_vn) '9
            db.AddInParameter(objCmd, "@nv_Nguyenquan_en", DbType.String, obj.nv_Nguyenquan_en)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Dienthoaikhac", DbType.String, obj.v_Dienthoaikhac)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@i_SoCMT", DbType.String, obj.i_SoCMT)
            db.AddInParameter(objCmd, "@d_NgaycapCMT", DbType.DateTime, obj.d_NgaycapCMT)
            db.AddInParameter(objCmd, "@nv_Noicap_vn", DbType.String, obj.nv_Noicap_vn)
            db.AddInParameter(objCmd, "@nv_Noicap_en", DbType.String, obj.nv_Noicap_en)
            If (obj.d_Ngayden <> Nothing And obj.d_Ngayden <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayden", DbType.DateTime, obj.d_Ngayden)
            End If
            db.AddInParameter(objCmd, "@uId_Nguonden", DbType.String, obj.uId_Nguonden)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@uId_Xaphuong", DbType.String, obj.uId_Xaphuong)
            db.AddInParameter(objCmd, "@nv_Hinhanh", DbType.String, obj.nv_Hinhanh)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Nghenghiep", DbType.String, obj.uId_Nghenghiep)
            db.AddInParameter(objCmd, "@uId_Nguoigioithieu", DbType.String, obj.uId_Nguoigioithieu)
            db.AddInParameter(objCmd, "@nv_BietPhongKham", DbType.String, obj.nv_BietPhongKham)
            db.AddInParameter(objCmd, "@nv_VungBiDau", DbType.String, obj.nv_VungBiDau)
            db.AddInParameter(objCmd, "@nv_DauBaoLau", DbType.String, obj.nv_DauBaoLau)
            db.AddInParameter(objCmd, "@nv_DaDieuTri", DbType.String, obj.nv_DaDieuTri)
            db.AddInParameter(objCmd, "@nv_CamGiacDau", DbType.String, obj.nv_CamGiacDau)
            db.AddInParameter(objCmd, "@nv_MucDoDau", DbType.String, obj.nv_MucDoDau)
            db.AddInParameter(objCmd, "@nv_TuTheDauHon", DbType.String, obj.nv_TuTheDauHon)
            db.AddInParameter(objCmd, "@nv_TuTheTotHon", DbType.String, obj.nv_TuTheTotHon)
            db.AddInParameter(objCmd, "@nv_AnhHuong", DbType.String, obj.nv_AnhHuong)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Khachhang As String) As Boolean Implements ICRM_DM_KhachhangDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_KHACHHANG_DeleteAllByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_KhachhangEntity) As Boolean Implements ICRM_DM_KhachhangDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_Makhachang", DbType.String, obj.v_Makhachang)
            db.AddInParameter(objCmd, "@v_BarCode", DbType.String, obj.v_BarCode)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Boolean, obj.b_Gioitinh)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@nv_Nguyenquan_vn", DbType.String, obj.nv_Nguyenquan_vn)
            db.AddInParameter(objCmd, "@nv_Nguyenquan_en", DbType.String, obj.nv_Nguyenquan_en)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Dienthoaikhac", DbType.String, obj.v_Dienthoaikhac)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@i_SoCMT", DbType.String, obj.i_SoCMT)
            db.AddInParameter(objCmd, "@d_NgaycapCMT", DbType.DateTime, obj.d_NgaycapCMT)
            db.AddInParameter(objCmd, "@nv_Noicap_vn", DbType.String, obj.nv_Noicap_vn)
            db.AddInParameter(objCmd, "@nv_Noicap_en", DbType.String, obj.nv_Noicap_en)
            If (obj.d_Ngayden <> Nothing And obj.d_Ngayden <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayden", DbType.DateTime, obj.d_Ngayden)
            End If
            db.AddInParameter(objCmd, "@uId_Nguonden", DbType.String, obj.uId_Nguonden)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@uId_Xaphuong", DbType.String, obj.uId_Xaphuong)
            db.AddInParameter(objCmd, "@nv_Hinhanh", DbType.String, obj.nv_Hinhanh)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Nghenghiep", DbType.String, obj.uId_Nghenghiep)
            db.AddInParameter(objCmd, "@uId_Nguoigioithieu", DbType.String, obj.uId_Nguoigioithieu)
            db.AddInParameter(objCmd, "@nv_BietPhongKham", DbType.String, obj.nv_BietPhongKham)
            db.AddInParameter(objCmd, "@nv_VungBiDau", DbType.String, obj.nv_VungBiDau)
            db.AddInParameter(objCmd, "@nv_DauBaoLau", DbType.String, obj.nv_DauBaoLau)
            db.AddInParameter(objCmd, "@nv_DaDieuTri", DbType.String, obj.nv_DaDieuTri)
            db.AddInParameter(objCmd, "@nv_CamGiacDau", DbType.String, obj.nv_CamGiacDau)
            db.AddInParameter(objCmd, "@nv_MucDoDau", DbType.String, obj.nv_MucDoDau)
            db.AddInParameter(objCmd, "@nv_TuTheDauHon", DbType.String, obj.nv_TuTheDauHon)
            db.AddInParameter(objCmd, "@nv_TuTheTotHon", DbType.String, obj.nv_TuTheTotHon)
            db.AddInParameter(objCmd, "@nv_AnhHuong", DbType.String, obj.nv_AnhHuong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectKhachhangNo(ByVal uId_Cuahang As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.SelectKhachhangNo
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_Khachhang]"
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

    Public Function TimKiemKH_No(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.TimKiemKH_No
        Dim db As Database
        Dim sp As String = "[dbo].[spTimkiem_Khachhang_No]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachang", DbType.String, obj.v_Makhachang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.String, obj.d_Ngaysinh)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function TimKiemByMaKH(ByVal v_Makhachang As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.TimKiemByMaKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_TimkiemByMaKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachang", DbType.String, v_Makhachang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function MaKH(ByVal uId_Cuahang As String) As String Implements ICRM_DM_KhachhangDA.MaKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectMaKhachhangMax]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "1"
        End Try
    End Function

    Public Function SelectAll_DS_Sinhnhat_By_NgayTuanThang(ByVal uId_Cuahang As String, ByVal iType As Short) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.SelectAll_DS_Sinhnhat_By_NgayTuanThang
        'Create by  : Mr Thang, 2012.11.02
        'Mo ta      : Lay danh sach sinh nhat
        'Input      : iType = 1: Ngay hien tai
        '           : iType = 2: Thang hien tai

        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectAll_DS_Sinhnhat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@iType", DbType.Int16, iType)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try

    End Function

    Public Function SelectAll_DS_Sinhnhat_By_NgayTuanThang_Nguoithan(ByVal uId_Cuahang As String, ByVal iType As Short) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.SelectAll_DS_Sinhnhat_By_NgayTuanThang_Nguoithan
        'Create by  : Mr Thang, 2012.11.02
        'Mo ta      : Lay danh sach sinh nhat
        'Input      : iType = 1: Ngay hien tai
        '           : iType = 2: Thang hien tai

        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_QUANHEGIADINH_SelectAll_DS_Sinhnhat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@iType", DbType.Int16, iType)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function CheckMaVach(ByVal v_BarCode As String) As CM.CRM_DM_KhachhangEntity Implements ICRM_DM_KhachhangDA.CheckMaVach
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectByMaVach]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_KhachhangEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_BarCode", System.Data.DbType.String, v_BarCode)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_KhachhangEntity
            If objReader.Read Then
                With obj
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachang = IIf(IsDBNull(objReader("v_Makhachang")) = True, "", objReader("v_Makhachang"))
                    .v_BarCode = IIf(IsDBNull(objReader("v_BarCode")) = True, "", objReader("v_BarCode"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    If .d_Ngaysinh <> Nothing Then
                        .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    End If
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Nguyenquan_vn = IIf(IsDBNull(objReader("nv_Nguyenquan_vn")) = True, "", objReader("nv_Nguyenquan_vn"))
                    .nv_Nguyenquan_en = IIf(IsDBNull(objReader("nv_Nguyenquan_en")) = True, "", objReader("nv_Nguyenquan_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .i_SoCMT = IIf(IsDBNull(objReader("i_SoCMT")) = True, 0, objReader("i_SoCMT"))
                    .d_NgaycapCMT = IIf(IsDBNull(objReader("d_NgaycapCMT")) = True, "", objReader("d_NgaycapCMT"))
                    .nv_Noicap_vn = IIf(IsDBNull(objReader("nv_Noicap_vn")) = True, "", objReader("nv_Noicap_vn"))
                    .nv_Noicap_en = IIf(IsDBNull(objReader("nv_Noicap_en")) = True, "", objReader("nv_Noicap_en"))
                    .d_Ngayden = IIf(IsDBNull(objReader("d_Ngayden")) = True, Nothing, objReader("d_Ngayden"))
                    .uId_Nguonden = IIf(IsDBNull(objReader("uId_Nguonden")) = True, "", Convert.ToString(objReader("uId_Nguonden")))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .uId_Xaphuong = IIf(IsDBNull(objReader("uId_Xaphuong")) = True, "", Convert.ToString(objReader("uId_Xaphuong")))
                    .nv_Hinhanh = IIf(IsDBNull(objReader("nv_Hinhanh")) = True, "", objReader("nv_Hinhanh"))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_KhachhangEntity
        End Try
    End Function

    Public Function InTheTVKH(ByVal uId_Khachhang As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.InTheTVKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectAllIntheTV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function InTheTTKH(ByVal uId_Khachhang_Goidichvu As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.InTheTTKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectAllIntheTT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, uId_Khachhang_Goidichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByTenAndSDT(ByVal TenKH As String, ByVal SDT As String) As CM.CRM_DM_KhachhangEntity Implements ICRM_DM_KhachhangDA.SelectByTenAndSDT
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectByTenAndSDT]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_KhachhangEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TenKH", System.Data.DbType.String, TenKH)
            db.AddInParameter(objCmd, "@SDT", System.Data.DbType.String, SDT)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_KhachhangEntity
            If objReader.Read Then
                With obj
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachang = IIf(IsDBNull(objReader("v_Makhachang")) = True, "", objReader("v_Makhachang"))
                    .v_BarCode = IIf(IsDBNull(objReader("v_BarCode")) = True, "", objReader("v_BarCode"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_KhachhangEntity
        End Try
    End Function

    Public Function SearchByKey(ByVal key As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.SearchByKey
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_Search]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@key", DbType.String, key)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function NhacNhoKHLamLieuTrinh(ByVal i_SoNgay As Integer) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.NhacNhoKHLamLieuTrinh
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_NhacNhoKHLamLieuTrinh]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@songay", DbType.String, i_SoNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
#End Region

#Region "Bao cao"
    Public Function BaocaoTheTV(ByVal nv_Hoten_vn As String, ByVal uId_Cuahang As String, ByVal uId_Loaithe As String, ByVal f_Tichluytu As Double, ByVal f_Tichluyden As Double, ByVal d_Tungay As String, ByVal d_Denngay As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.BaocaoTheTV
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_BaocaoTheTV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, nv_Hoten_vn)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String, uId_Loaithe)
            db.AddInParameter(objCmd, "@f_Tichluytu", DbType.Double, f_Tichluytu)
            db.AddInParameter(objCmd, "@f_Tichluyden", DbType.Double, f_Tichluyden)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.String, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.String, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Baocao_Doanhthu_Diadanh(ByVal sTungay As String, ByVal sDenngay As String, ByVal uId_Cuahang As String, ByVal uId_Tinhthanh As String, ByVal uId_Quanhuyen As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.Baocao_Doanhthu_Diadanh
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_Doanhthu_Diadanh]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@dt_Tungay", DbType.String, oLib.DinhdangNgay_HT(sTungay))
            db.AddInParameter(objCmd, "@dt_Denngay", DbType.String, oLib.DinhdangNgay_HT(sDenngay))
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", DbType.String, uId_Tinhthanh)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", DbType.String, uId_Quanhuyen)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BaoCao_KH_LieuTrinh(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.BaoCao_KH_LieuTrinh
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_BaoCaoLieuTrinh]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.Date, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.Date, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
#End Region

    Public Function TimKiemByMaVach(ByVal v_MaVach As String) As System.Data.DataTable Implements ICRM_DM_KhachhangDA.TimKiemByMaVach
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_TimkiemByMaVach]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaVach", DbType.String, v_MaVach)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByBirthday(ngay As Integer, thang As Integer, nam As Integer, uid_cuahang As String, itype As Integer) As DataTable Implements ICRM_DM_KhachhangDA.SelectByBirthday
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectByBirthday]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uid_Cuahang", DbType.String, uid_cuahang)
            db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.String, ngay)
            db.AddInParameter(objCmd, "@d_Namsinh", DbType.String, nam)
            db.AddInParameter(objCmd, "@d_Thangsinh", DbType.String, thang)
            db.AddInParameter(objCmd, "@iType", DbType.String, itype)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    'xuanhieu 08/12/04 insert tu excel
    Function InsertTabl(TableTemp As DataTable) As Boolean Implements ICRM_DM_KhachhangDA.InsertTabl
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_InsertTable]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@tabletemp", System.Data.SqlDbType.Structured, TableTemp)
            db.ExecuteNonQuery(objCmd)

        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    'Phuongdv Bao cao tri lieu 13/05/2015
    Public Function SelectAllTable_Trilieu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As DataTable Implements ICRM_DM_KhachhangDA.SelectAllTable_Trilieu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Lichsu_Khachhangsudung_DV_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.String, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.String, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID_Trilieu(TuNgay As DateTime, DenNgay As DateTime, uId_Khachhang As String, uId_Dichvu As String, Chon As Integer) As DataTable Implements ICRM_DM_KhachhangDA.SelectByID_Trilieu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Lichsu_Khachhangsudung_DV_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.AddInParameter(objCmd, "@Chon", DbType.Int32, Chon)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable_DMKhachhang() As DataTable Implements ICRM_DM_KhachhangDA.SelectAllTable_DMKhachhang

        Dim db As Database
        Dim sp As String = "[dbo].[sp_Phuongdv_CRM_DM_Khachhang_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try

    End Function

    Public Function SelectCognoBytime(tungay As Date, denngay As Date, uId_Cuahang As String) As DataTable Implements ICRM_DM_KhachhangDA.SelectCognoBytime
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_SelectCongnoByTime]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.String, tungay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.String, denngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectKhachhangByIDTable(uId_Khachhang As String) As DataTable Implements ICRM_DM_KhachhangDA.SelectKhachhangByIDTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Thongketheonam() As List(Of CM.CRM_DM_KhachhangEntity) Implements ICRM_DM_KhachhangDA.Thongketheonam
        Dim db As Database
        Dim sp As String = "[dbo].[sp_SelectKHByNam]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_KhachhangEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_KhachhangEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_KhachhangEntity)
                With lstobj(i)
                    .Thang = IIf(IsDBNull(objReader("Thang")) = True, 0, objReader("Thang"))
                    .Soluong = IIf(IsDBNull(objReader("Soluong")) = True, 0, objReader("Soluong"))

                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_KhachhangEntity)
        End Try
    End Function

    Public Function SelectNggioithieu(uId_Cuahang As String, ontions As Integer) As DataTable Implements ICRM_DM_KhachhangDA.SelectNggioithieu
        Dim db As Database
        Dim sp As String = "[dbo].[sp_SelectNguoigioithieu_Option]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@option", DbType.String, ontions)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByIDTable_PDV(uId_Phieudichvu As String) As DataTable Implements ICRM_DM_KhachhangDA.SelectByIDTable_PDV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Information_ByID_PDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
