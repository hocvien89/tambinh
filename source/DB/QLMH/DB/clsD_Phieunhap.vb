Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_Phieunhap
    Implements iClsD_Phieunhap

    Private oLib_sat As New Lib_SAT.cls_Pub_Functions
    Private log As New LogError.ShowError

#Region "Danh sach Phieu nhap - Header"

    Public Function SelectAll(ByVal uId_Cuahang As String) As System.Data.DataTable Implements iClsD_Phieunhap.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_SelectAll]"
        Dim objCmd As DbCommand
        Dim DT As DataTable
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            DT = db.ExecuteDataSet(objCmd).Tables(0)
            Return DT
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function Timkiem(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements iClsD_Phieunhap.TimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_Timkiem]"
        Dim objCmd As DbCommand
        Dim DT As New DataTable
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return DT
    End Function

    Public Function SelectByID(ByVal uId_Phieunhap As String) As CM.cls_Phieunhap Implements iClsD_Phieunhap.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.cls_Phieunhap = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", System.Data.DbType.String, uId_Phieunhap)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.cls_Phieunhap
            If objReader.Read Then
                With obj
                    .uId_Phieunhap = IIf(IsDBNull(objReader("uId_Phieunhap")) = True, "", Convert.ToString(objReader("uId_Phieunhap")))
                    .uId_Nhacungcap = IIf(IsDBNull(objReader("uId_Nhacungcap")) = True, "", Convert.ToString(objReader("uId_Nhacungcap")))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Maphieunhap = IIf(IsDBNull(objReader("v_Maphieunhap")) = True, "", objReader("v_Maphieunhap"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                    .nv_Noidung_vn = IIf(IsDBNull(objReader("nv_Noidung_vn")) = True, "", objReader("nv_Noidung_vn"))
                    .nv_Noidung_en = IIf(IsDBNull(objReader("nv_Noidung_en")) = True, "", objReader("nv_Noidung_en"))
                    .f_Giamgia = IIf(IsDBNull(objReader("f_Giamgia")) = True, 0, objReader("f_Giamgia"))
                    .f_Tongtien = IIf(IsDBNull(objReader("f_tongtien")) = True, 0, objReader("f_tongtien"))
                    .f_Tongthanhtoan = IIf(IsDBNull(objReader("f_Tongtienthuc")) = True, 0, objReader("f_Tongtienthuc"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.cls_Phieunhap
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.cls_Phieunhap) As String Implements iClsD_Phieunhap.Insert
        Dim sOut_Uid_Phieunhap As String = ""

        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_Insert]"
        Dim objCmd As DbCommand

        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Nhacungcap", DbType.String, obj.uId_Nhacungcap)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@v_Maphieunhap", DbType.String, obj.v_Maphieunhap)
            db.AddInParameter(objCmd, "@d_Ngaynhap", DbType.DateTime, obj.d_Ngaynhap)
            db.AddInParameter(objCmd, "@nv_Noidung_vn", DbType.String, obj.nv_Noidung_vn)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@f_Tongtien", DbType.Double, obj.f_Tongtien)
            db.AddInParameter(objCmd, "@f_Tongthanhtoan", DbType.Double, obj.f_Tongthanhtoan)
            sOut_Uid_Phieunhap = db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString

            Return sOut_Uid_Phieunhap
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return sOut_Uid_Phieunhap
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieunhap As String) As Boolean Implements iClsD_Phieunhap.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uId_Phieunhap)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.cls_Phieunhap) As Boolean Implements iClsD_Phieunhap.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, obj.uId_Phieunhap)
            db.AddInParameter(objCmd, "@uId_Nhacungcap", DbType.String, obj.uId_Nhacungcap)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@v_Maphieunhap", DbType.String, obj.v_Maphieunhap)
            If (obj.d_Ngaynhap <> Nothing And obj.d_Ngaynhap <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaynhap", DbType.DateTime, obj.d_Ngaynhap)
            End If
            db.AddInParameter(objCmd, "@nv_Noidung_vn", DbType.String, obj.nv_Noidung_vn)
            db.AddInParameter(objCmd, "@nv_Noidung_en", DbType.String, obj.nv_Noidung_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByMaPhieu(MaPhieu As String) As CM.cls_Phieunhap Implements iClsD_Phieunhap.SelectByMaPhieu
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_SelectByMaPhieu]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.cls_Phieunhap = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaPhieu", System.Data.DbType.String, MaPhieu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.cls_Phieunhap
            If objReader.Read Then
                With obj
                    .uId_Phieunhap = IIf(IsDBNull(objReader("uId_Phieunhap")) = True, "", Convert.ToString(objReader("uId_Phieunhap")))
                    .uId_Nhacungcap = IIf(IsDBNull(objReader("uId_Nhacungcap")) = True, "", Convert.ToString(objReader("uId_Nhacungcap")))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Maphieunhap = IIf(IsDBNull(objReader("v_Maphieunhap")) = True, "", objReader("v_Maphieunhap"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                    .nv_Noidung_vn = IIf(IsDBNull(objReader("nv_Noidung_vn")) = True, "", objReader("nv_Noidung_vn"))
                    .nv_Noidung_en = IIf(IsDBNull(objReader("nv_Noidung_en")) = True, "", objReader("nv_Noidung_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.cls_Phieunhap
        End Try
    End Function
#End Region


#Region "Danh sach Phieu nhap - Detail"

    Public Function Insert_PHIEUNHAP_CHITIET(ByVal obj As CM.cls_Phieunhap) As Boolean Implements iClsD_Phieunhap.Insert_PHIEUNHAP_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, obj.uId_Phieunhap)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Donggia", DbType.Double, obj.f_Donggia)
            db.AddInParameter(objCmd, "@f_Thanhtien", DbType.Double, obj.f_Thanhtien)
            db.AddInParameter(objCmd, "@d_NgayhethanSD", DbType.DateTime, oLib_sat.DinhdangNgay_HT(obj.d_NgayhethanSD))
            db.AddInParameter(objCmd, "@Madonvi", DbType.String, obj.MaDonVi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try


    End Function

    Public Function SelectByID_PHIEUNHAP_CHITIET(ByVal uId_Phieunhap As String) As System.Data.DataTable Implements iClsD_Phieunhap.SelectByID_PHIEUNHAP_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uId_Phieunhap)

            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return DT
    End Function

    Public Function Update_PHIEUNHAP_CHITIET(ByVal obj As CM.cls_Phieunhap) As Boolean Implements iClsD_Phieunhap.Update_PHIEUNHAP_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap_Chitiet", DbType.String, obj.uId_Phieunhap_Chitiet)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Donggia", DbType.Double, obj.f_Donggia)
            db.AddInParameter(objCmd, "@f_Thanhtien", DbType.Double, obj.f_Thanhtien)
            db.AddInParameter(objCmd, "@d_NgayhethanSD", DbType.DateTime, oLib_sat.DinhdangNgay_HT(obj.d_NgayhethanSD))
            db.AddInParameter(objCmd, "@Madonvi", DbType.String, obj.MaDonVi)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try

    End Function

    Public Function DeleteByID_PHIEUNHAP_CHITIET(ByVal uId_Phieunhap_Chitiet As String) As Boolean Implements iClsD_Phieunhap.DeleteByID_PHIEUNHAP_CHITIET
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap_Chitiet", DbType.String, uId_Phieunhap_Chitiet)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try

    End Function
    Public Function SelectPNChitiet_ByIDSP(ByVal v_Sophieu As String, ByVal uId_Mathang As String) As String Implements iClsD_Phieunhap.SelectPNChitiet_ByIDSP
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_SelectByIDSP]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Sophieu", DbType.String, v_Sophieu)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, uId_Mathang)

            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return String.Empty
        End Try
    End Function
#End Region

#Region "Phieu nhap - Tim kiem"
    Public Function Select_By_MaTenMypham(ByVal uId_Phieunhap As String, ByVal nv_TenMathang_vn As String) As DataTable Implements iClsD_Phieunhap.Select_By_MaTenMypham

        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_SelectAll_TimSanpham]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uId_Phieunhap)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, nv_TenMathang_vn)
            DT = db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return DT

    End Function
#End Region
    Public Function SelectTonghopNhap_Update(ByVal uId_Kho As String, ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iClsD_Phieunhap.SelectTonghopNhap_Update
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Tonghop_PhieuNhap]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
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
    'xuanhieu 121214
    Public Function UpdateTongthucte(uid_Phieunhap As String, f_Giamgia As Double, f_Tongthucte As Double) As Boolean Implements iClsD_Phieunhap.UpdateTongthucte
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_Update_Thanhtoan]"
        Dim objCm As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCm = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCm, "@uId_Phieunhap", DbType.String, uid_Phieunhap)
            db.AddInParameter(objCm, "@f_Giamgia", DbType.Double, f_Giamgia)
            db.AddInParameter(objCm, "@f_Tongthucte", DbType.Double, f_Tongthucte)
            db.ExecuteNonQuery(objCm)
            Return True
        Catch ex As Exception

        End Try
    End Function
    'xuanhieu 131214
    Public Function SelectByTongthucte(uid_Phieunhap As String) As Double Implements iClsD_Phieunhap.SelectByTongthucte
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CHITIET_SelectByTongTien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim Tongtien As Double = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uid_Phieunhap)
            objDs = db.ExecuteDataSet(objCmd)
            If objDs.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In objDs.Tables(0).Rows
                    Tongtien = Double.Parse(row("f_Tongtien").ToString)
                Next
            End If
        Catch ex As Exception

        End Try
        Return Tongtien
    End Function
    'xuanhieu 151214 update tong tien phieu nhap
    Public Function UpdateTongtien(uid_Phieunhap As String) As Boolean Implements iClsD_Phieunhap.UpdateTongtien
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_UpdateTongtien]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uid_Phieunhap)
            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception

        End Try
        Return True
    End Function

    'xuanhieu 231214 baocao tong nhap
    Public Function BCTonghopnhap(uId_kho As String, d_Tungay As DateTime, d_Denngay As DateTime) As DataTable Implements iClsD_Phieunhap.BCTonghopnhap
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_QLMH_Tonghopnhap]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_kho)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
        Return New DataTable
    End Function
    Public Function InPhieunhapByID(uId_phieunhap As String) As DataTable Implements iClsD_Phieunhap.InPhieunhapByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_InHoadoan_Phieunhap]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uId_phieunhap)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
        Return New DataTable
    End Function
End Class
