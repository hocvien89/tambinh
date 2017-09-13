Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_PHIEUXUATDA
    Implements IQLMH_PHIEUXUATDA

    Private oLib_sat As New Lib_SAT.cls_Pub_Functions
    Private log As New LogError.ShowError

#Region "Phieu xuat - Header"

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_PHIEUXUATEntity) Implements IQLMH_PHIEUXUATDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_PHIEUXUATEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_PHIEUXUATEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_PHIEUXUATEntity)
                With lstobj(i)
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Maphieuxuat = IIf(IsDBNull(objReader("v_Maphieuxuat")) = True, "", objReader("v_Maphieuxuat"))
                    .d_Ngayxuat = IIf(IsDBNull(objReader("d_Ngayxuat")) = True, Nothing, objReader("d_Ngayxuat"))
                    .nv_Noidungxuat_vn = IIf(IsDBNull(objReader("nv_Noidungxuat_vn")) = True, "", objReader("nv_Noidungxuat_vn"))
                    .nv_Noidungxuat_en = IIf(IsDBNull(objReader("nv_Noidungxuat_en")) = True, "", objReader("nv_Noidungxuat_en"))
                    .f_Giamgia = IIf(IsDBNull(objReader("f_Giamgia")) = True, "", objReader("f_Giamgia"))
                    .f_Tongtienthuc = IIf(IsDBNull(objReader("f_Tongtienthuc")) = True, "", objReader("f_Tongtienthuc"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_PHIEUXUATEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectAll]"
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

    Public Function SelectAllTablePXNo(ByVal uId_Khachhang As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectAllTablePXNo
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_No_SelectAll]"
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

    Public Function Timkiem(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Type As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.TimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_Timkiem]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@Type", DbType.String, Type)
            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return DT
    End Function


    Public Function SelectByID(ByVal uId_Phieuxuat As String) As CM.QLMH_PHIEUXUATEntity Implements IQLMH_PHIEUXUATDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_PHIEUXUATEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", System.Data.DbType.String, uId_Phieuxuat)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_PHIEUXUATEntity
            If objReader.Read Then
                With obj
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Maphieuxuat = IIf(IsDBNull(objReader("v_Maphieuxuat")) = True, "", objReader("v_Maphieuxuat"))
                    .d_Ngayxuat = IIf(IsDBNull(objReader("d_Ngayxuat1")) = True, Nothing, objReader("d_Ngayxuat1"))
                    .nv_Noidungxuat_vn = IIf(IsDBNull(objReader("nv_Noidungxuat_vn")) = True, "", objReader("nv_Noidungxuat_vn"))
                    .nv_Noidungxuat_en = IIf(IsDBNull(objReader("nv_Noidungxuat_en")) = True, "", objReader("nv_Noidungxuat_en"))
                    .f_Giamgia_Tong = IIf(IsDBNull(objReader("f_Giamgia")) = True, "", objReader("f_Giamgia"))
                    .f_Tongtienthuc = IIf(IsDBNull(objReader("f_Tongtienthuc")) = True, "", objReader("f_Tongtienthuc"))
                    .b_IsKhoa = IIf(IsDBNull(objReader("b_IsKhoa")) = True, False, objReader("b_IsKhoa"))
                    .b_Dathanhtoan = IIf(IsDBNull(objReader("b_IsKhoa")) = True, False, objReader("b_Kedon"))
                    .uId_LoaiTT = IIf(IsDBNull(objReader("uId_LoaiTT")) = True, "", Convert.ToString(objReader("uId_LoaiTT")))
                    .i_Soluog = IIf(IsDBNull(objReader("i_Sothang")) = True, 0, objReader("i_Sothang"))
                    .f_Gia = IIf(IsDBNull(objReader("f_Giathang")) = True, 0, objReader("f_Giathang"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_PHIEUXUATEntity
        End Try
    End Function

    Public Function SelectByIDDataTable(ByVal uId_Phieuxuat As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectByIDDataTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectByID]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)
            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return DT
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_PHIEUXUATEntity) As String Implements IQLMH_PHIEUXUATDA.Insert
        Dim sOut_Uid_Phieunhap As String = ""

        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@v_Maphieuxuat", DbType.String, obj.v_Maphieuxuat)
            db.AddInParameter(objCmd, "@d_Ngayxuat", DbType.DateTime, obj.d_Ngayxuat)
            db.AddInParameter(objCmd, "@nv_Noidungxuat_vn", DbType.String, obj.nv_Noidungxuat_vn)
            db.AddInParameter(objCmd, "@nv_Noidungxuat_en", DbType.String, obj.nv_Noidungxuat_en)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@f_Tongtienthuc", DbType.Double, obj.f_Tongtienthuc)
            db.AddInParameter(objCmd, "@b_Kedon", DbType.Boolean, obj.b_Dathanhtoan)
            sOut_Uid_Phieunhap = db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return sOut_Uid_Phieunhap
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return sOut_Uid_Phieunhap
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieuxuat As String) As Boolean Implements IQLMH_PHIEUXUATDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean Implements IQLMH_PHIEUXUATDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@v_Maphieuxuat", DbType.String, obj.v_Maphieuxuat)
            db.AddInParameter(objCmd, "@d_Ngayxuat", DbType.DateTime, obj.d_Ngayxuat)
            db.AddInParameter(objCmd, "@nv_Noidungxuat_vn", DbType.String, obj.nv_Noidungxuat_vn)
            db.AddInParameter(objCmd, "@nv_Noidungxuat_en", DbType.String, obj.nv_Noidungxuat_en)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia_Tong)
            db.AddInParameter(objCmd, "@f_Tongtienthuc", DbType.Double, obj.f_Tongtienthuc)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, obj.uId_LoaiTT)
            db.AddInParameter(objCmd, "@b_IsKhoa", DbType.Boolean, obj.b_IsKhoa)
            db.AddInParameter(objCmd, "@b_Kedon", DbType.Boolean, obj.b_Dathanhtoan)
            db.AddInParameter(objCmd, "@i_Sothang", DbType.Int16, obj.i_Soluog)
            db.AddInParameter(objCmd, "@f_Giathang", DbType.Double, obj.f_Gia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function ThanhToan(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean Implements IQLMH_PHIEUXUATDA.ThanhToan
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_Thanhtoan]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@f_Tongtienthuc", DbType.Double, obj.f_Tongtienthuc)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function BaoCaoDoanhThuTongHopSP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.BaoCaoDoanhThuTongHopSP
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThu_Tonghop_SP]"
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

    Public Function BaoCaoDoanhThuChiTietSP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.BaoCaoDoanhThuChiTietSP
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThu_Chitiet_SP]"
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

    Public Function SelectByIDChuaThanhtoan(uId_Phieuxuat As String) As CM.QLMH_PHIEUXUATEntity Implements IQLMH_PHIEUXUATDA.SelectByIDChuaThanhtoan
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectByIDChuaThanhtoan]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_PHIEUXUATEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", System.Data.DbType.String, uId_Phieuxuat)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_PHIEUXUATEntity
            If objReader.Read Then
                With obj
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Maphieuxuat = IIf(IsDBNull(objReader("v_Maphieuxuat")) = True, "", objReader("v_Maphieuxuat"))
                    .d_Ngayxuat = IIf(IsDBNull(objReader("d_Ngayxuat1")) = True, Nothing, objReader("d_Ngayxuat1"))
                    .nv_Noidungxuat_vn = IIf(IsDBNull(objReader("nv_Noidungxuat_vn")) = True, "", objReader("nv_Noidungxuat_vn"))
                    .nv_Noidungxuat_en = IIf(IsDBNull(objReader("nv_Noidungxuat_en")) = True, "", objReader("nv_Noidungxuat_en"))
                    .f_Giamgia_Tong = IIf(IsDBNull(objReader("f_Giamgia")) = True, "", objReader("f_Giamgia"))
                    .f_Tongtienthuc = IIf(IsDBNull(objReader("f_Tongtienthuc")) = True, "", objReader("f_Tongtienthuc"))
                    .b_IsKhoa = IIf(IsDBNull(objReader("b_IsKhoa")) = True, False, objReader("b_IsKhoa"))
                    .f_Tongtien = IIf(IsDBNull(objReader("f_Sotien")) = True, False, objReader("f_Sotien"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_PHIEUXUATEntity
        End Try
    End Function
#End Region

#Region "Phieu xuat - Detail"
    Public Function SelectAll_QLMH_PHIEUXUAT_CHITIET() As System.Collections.Generic.List(Of CM.QLMH_PHIEUXUATEntity) Implements IQLMH_PHIEUXUATDA.SelectAll_QLMH_PHIEUXUAT_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_PHIEUXUATEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_PHIEUXUATEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_PHIEUXUATEntity)
                With lstobj(i)
                    .uId_Phieuxuat_Chitiet = IIf(IsDBNull(objReader("uId_Phieuxuat_Chitiet")) = True, "", Convert.ToString(objReader("uId_Phieuxuat_Chitiet")))
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mahang")) = True, "", Convert.ToString(objReader("uId_Mahang")))
                    .f_Soluong = IIf(IsDBNull(objReader("f_Soluong")) = True, 0, objReader("f_Soluong"))
                    .f_Dongia = IIf(IsDBNull(objReader("f_Dongia")) = True, 0, objReader("f_Dongia"))
                    .f_Giamgia = IIf(IsDBNull(objReader("f_Giamgia")) = True, 0, objReader("f_Giamgia"))
                    .f_Tongtien = IIf(IsDBNull(objReader("f_Tongtien")) = True, 0, objReader("f_Thanhtien"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_PHIEUXUATEntity)
        End Try
    End Function

    Public Function SelectAllTable_QLMH_PHIEUXUAT_CHITIET() As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectAllTable_QLMH_PHIEUXUAT_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectAll]"
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

    Public Function SelectPHIEUXUAT_CHITIET_ByID_PX(ByVal uId_Phieuxuat As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectByID_QLMH_PHIEUXUAT_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectByIDPX]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)

            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try

        Return DT
    End Function
    Public Function Select_PHIEUXUAT_CHITIET_ByMaPX(ByVal v_Maphieuxuat As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.Select_PHIEUXUAT_CHITIET_ByMaPX
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectByMaPX]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@v_Maphieuxuat", DbType.String, v_Maphieuxuat)

            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try

        Return DT
    End Function
    Public Function SelectQLMH_PHIEUXUAT_CHITIET_ByID(ByVal uId_Phieuxuat_Chitiet As String) As CM.QLMH_PHIEUXUATEntity Implements IQLMH_PHIEUXUATDA.SelectQLMH_PHIEUXUAT_CHITIET_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_PHIEUXUATEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Phieuxuat_Chitiet", DbType.String, uId_Phieuxuat_Chitiet)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_PHIEUXUATEntity
            If objReader.Read Then
                With obj
                    .uId_Phieuxuat_Chitiet = IIf(IsDBNull(objReader("uId_Phieuxuat_Chitiet")) = True, "", Convert.ToString(objReader("uId_Phieuxuat_Chitiet")))
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .f_Soluong = IIf(IsDBNull(objReader("f_Soluong")) = True, 0, objReader("f_Soluong"))
                    .f_Dongia = IIf(IsDBNull(objReader("f_Dongia")) = True, 0, objReader("f_Dongia"))
                    .f_Giamgia = IIf(IsDBNull(objReader("f_Giamgia")) = True, 0, objReader("f_Giamgia"))
                    .f_Tongtien = IIf(IsDBNull(objReader("f_Tongtien")) = True, 0, objReader("f_Tongtien"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .MaDonVi = IIf(IsDBNull(objReader("MADONVI")) = True, "", objReader("MADONVI"))
                    .f_Soluongnhonhat = IIf(IsDBNull(objReader("f_Soluongnhonhat")) = True, 0, objReader("f_Soluongnhonhat"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_PHIEUXUATEntity
        End Try
    End Function
    Public Function Insert_QLMH_PHIEUXUAT_CHITIET(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean Implements IQLMH_PHIEUXUATDA.Insert_QLMH_PHIEUXUAT_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Dongia", DbType.Double, obj.f_Dongia)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@f_Tongtien", DbType.Double, obj.f_Tongtien)
            db.AddInParameter(objCmd, "@Madonvi", DbType.String, obj.MaDonVi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID_QLMH_PHIEUXUAT_CHITIET(ByVal uId_Phieuxuat_Chitiet As String) As Boolean Implements IQLMH_PHIEUXUATDA.DeleteByID_QLMH_PHIEUXUAT_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat_Chitiet", DbType.String, uId_Phieuxuat_Chitiet)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update_QLMH_PHIEUXUAT_CHITIET(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean Implements IQLMH_PHIEUXUATDA.Update_QLMH_PHIEUXUAT_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat_Chitiet", DbType.String, obj.uId_Phieuxuat_Chitiet)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Dongia", DbType.Double, obj.f_Dongia)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@f_Tongtien", DbType.Double, obj.f_Tongtien)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@Madonvi", DbType.String, obj.MaDonVi)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function


#End Region



    Public Function SelectByKH(ByVal uId_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectByKH
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectByKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID_QLMH_PHIEUXUAT_CHITIET_BC(ByVal uId_Phieuxuat As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectByID_QLMH_PHIEUXUAT_CHITIET_BC
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_CHITIET_SelectByIDPX_BC]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)

            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try

        Return DT
    End Function

    Public Function MaPhieuxuatMax(ByVal ngaynhap As Date) As String Implements IQLMH_PHIEUXUATDA.MaPhieuxuatMax
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUXUAT_SelectSoPhieuxuatMax]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@NgayNhap", DbType.Date, ngaynhap)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "1"
        End Try
    End Function

    Public Function SelectBySoPhieuXuat(ByVal v_Maphieuxuat As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectBySoPhieuXuat
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUXUAT_SelectBySoPhieuXuat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Maphieuxuat", DbType.String, v_Maphieuxuat)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTonghopXuat_Update(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_PHIEUXUATDA.SelectTonghopXuat_Update
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThu_TheoSanpham]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    'xuanhieu 241214 bao cao tong hop xuat
    Public Function BCtonghopxuat(uId_Kho As String, d_Tungay As Date, d_Denngay As Date) As DataTable Implements IQLMH_PHIEUXUATDA.BCtonghopxuat
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_QLMH_Tonghopxuat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectDonthuoc(uId_Phieuxuat As String) As DataTable Implements IQLMH_PHIEUXUATDA.SelectDonthuoc
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectDonthuoc]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)
            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return DT
    End Function
End Class