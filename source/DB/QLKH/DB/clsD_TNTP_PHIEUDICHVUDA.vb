Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_PHIEUDICHVUDA

    Implements ITNTP_PHIEUDICHVUDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_PHIEUDICHVUEntity) Implements ITNTP_PHIEUDICHVUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_PHIEUDICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_PHIEUDICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_PHIEUDICHVUEntity)
                With lstobj(i)
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Sophieu = IIf(IsDBNull(objReader("v_Sophieu")) = True, "", objReader("v_Sophieu"))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_PHIEUDICHVUEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectAll]"
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
    Public Function SelectByDate(ByVal uId_Khachhang As String, ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectByDate
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectIDPDVNo(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectIDPDVNo
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByID_PDVNo]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectDVNo(ByVal uId_Khachhang As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectDVNo
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectDVNo]"
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

    Public Function SelectByID_CNTT(ByVal uId_Congno_Thanhtoan As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectByID_CNTT
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByID_CNTT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congno_Thanhtoan", DbType.String, uId_Congno_Thanhtoan)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectAllByGDV(ByVal uId_Khachhang As String, ByVal b_GoiDV As Byte, ByVal b_Trangthaiphieu As Byte) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectAllByGDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectAllByGDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@b_GoiDV", DbType.Byte, b_GoiDV)
            db.AddInParameter(objCmd, "@b_TrangthaiPhieu", DbType.Byte, b_Trangthaiphieu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByID(ByVal uId_Phieudichvu As String) As CM.TNTP_PHIEUDICHVUEntity Implements ITNTP_PHIEUDICHVUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_PHIEUDICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_PHIEUDICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_LoaiTT = IIf(IsDBNull(objReader("uId_LoaiTT")) = True, "", Convert.ToString(objReader("uId_LoaiTT")))
                    .v_Sophieu = IIf(IsDBNull(objReader("v_Sophieu")) = True, "", objReader("v_Sophieu"))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .f_Giamgia = IIf(IsDBNull(objReader("f_Giamgia_PDV")) = True, "", objReader("f_Giamgia_PDV"))
                    .f_Tongtienthuc = IIf(IsDBNull(objReader("f_Tongtienthuc")) = True, 0, objReader("f_Tongtienthuc"))
                    .d_Ngayketthuc = IIf(IsDBNull(objReader("d_Ngayketthuc")) = True, Nothing, objReader("d_Ngayketthuc"))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .HHPhieu = IIf(IsDBNull(objReader("HHPhieu")) = True, 0, objReader("HHPhieu"))
                    .Id_Nhomphieu = IIf(IsDBNull(objReader("Id_Nhomphieu")) = True, 0, objReader("Id_Nhomphieu"))
                    .b_IsKhoa = IIf(IsDBNull(objReader("b_IsKhoa")) = True, False, objReader("b_IsKhoa"))
                    .b_IsPayed = IIf(IsDBNull(objReader("b_IsPayed")) = True, False, objReader("b_IsPayed"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_PHIEUDICHVUEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As String Implements ITNTP_PHIEUDICHVUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Sophieu", DbType.String, obj.v_Sophieu)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)

            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieudichvu As String) As Boolean Implements ITNTP_PHIEUDICHVUDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As Boolean Implements ITNTP_PHIEUDICHVUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, obj.uId_LoaiTT)
            db.AddInParameter(objCmd, "@v_Sophieu", DbType.String, obj.v_Sophieu)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@f_Tongtienthuc", DbType.Double, obj.f_Tongtienthuc)
            If (obj.d_Ngayketthuc <> Nothing And obj.d_Ngayketthuc <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.DateTime, obj.d_Ngayketthuc)
            End If
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@HHPhieu", DbType.Double, obj.HHPhieu)
            db.AddInParameter(objCmd, "@Id_Nhomphieu", DbType.Int32, obj.Id_Nhomphieu)
            db.AddInParameter(objCmd, "@b_IsKhoa", DbType.Boolean, obj.b_IsKhoa)
            db.AddInParameter(objCmd, "@b_IsPayed", DbType.Boolean, obj.b_IsPayed)
            db.AddInParameter(objCmd, "@uId_Tuvan1", DbType.String, obj.uId_Tuvan1)
            db.AddInParameter(objCmd, "@uId_Tuvan2", DbType.String, obj.uId_Tuvan2)
            db.AddInParameter(objCmd, "@uId_Tuvan3", DbType.String, obj.uId_Tuvan3)
            db.AddInParameter(objCmd, "@uId_Tuvan", DbType.String, obj.uId_Tuvan)
            db.AddInParameter(objCmd, "@f_Tuvan1", DbType.Double, obj.f_Tuvan1)
            db.AddInParameter(objCmd, "@f_Tuvan2", DbType.Double, obj.f_Tuvan2)
            db.AddInParameter(objCmd, "@f_Tuvan3", DbType.Double, obj.f_Tuvan3)
            db.AddInParameter(objCmd, "@f_Hoahong", DbType.Double, obj.f_Hoahong)
            db.AddInParameter(objCmd, "@uId_Dichvu1", DbType.String, obj.uId_Dichvu1)
            db.AddInParameter(objCmd, "@uId_Dichvu2", DbType.String, obj.uId_Dichvu2)
            db.AddInParameter(objCmd, "@uId_Dichvu3", DbType.String, obj.uId_Dichvu3)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Update_TTT(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As Boolean Implements ITNTP_PHIEUDICHVUDA.Update_TTT
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_Update_TTT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@f_Tongtienthuc", DbType.Double, obj.f_Tongtienthuc)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function TongDaDT(ByVal uId_Phieudichvu As String) As String Implements ITNTP_PHIEUDICHVUDA.TongDaDT
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_TongTien_daDT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Function SelectByDateDT(ByVal uId_Khachhang As String, ByVal d_Tungay As Date, ByVal d_Denngay As Date) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectByDateDT
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByDateDT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function MaPDVMax(ByVal uId_Cuahang As String, ByVal ngaynhap As Date) As String Implements ITNTP_PHIEUDICHVUDA.MaPDVMax
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectSoPDVMax]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@NgayNhap", DbType.Date, ngaynhap)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "1"
        End Try
    End Function

    Public Function SelectBySophieu(ByVal v_Sophieu As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVUDA.SelectBySophieu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByMaPhieu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Sophieu", DbType.String, v_Sophieu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function KhoaSoNghiepVu(ByVal DenNgay As Date) As Boolean Implements ITNTP_PHIEUDICHVUDA.KhoaSoNghiepVu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KhoaSo]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function BaocaoHH(uId_Nhanvien As String, Tungay As Date, Denngay As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.BaocaoHH
        Dim db As Database
        Dim sp As String = "[dbo].[sp_BaocaoHH_Bandichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_LoaihinhTT_ByID(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Select_LoaihinhTT_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Thanhtoan_ById_PDV]"
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

    Public Function Select_ById_Table(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Select_ById_Table
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_ById_PDV_Table]"
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

    Public Function SelectByID_Table_PDV(uId_Phieudichvu As Object) As DataTable Implements ITNTP_PHIEUDICHVUDA.SelectByID_Table_PDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SelectByID]"
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

    Public Function Select_Dichvu_ByID_Table(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Select_Dichvu_ByID_Table
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Phieudichvu_Chitiet_ById_PDV]"
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

    Public Function Select_The_Taikhoan_By_PDV(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Select_The_Taikhoan_By_PDV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Danhmuc_The_ByID_PDV]"
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

    Public Function Select_ThongTin_The_Taikhoan_By_DV(uId_Phieudichvu As String, uId_Dichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Select_ThongTin_The_Taikhoan_By_DV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Thetaikhoan_By_DV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Congno_ByID(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Select_Congno_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Congno_ByID_PDV]"
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

    Public Function Kiemtranhomdichvu_Thethaikhoan(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVUDA.Kiemtranhomdichvu_Thethaikhoan
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Check_Nhomdichvuthetaikhoan_ByID]"
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