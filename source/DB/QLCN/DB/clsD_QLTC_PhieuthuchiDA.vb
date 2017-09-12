Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_QLTC_PhieuthuchiDA

    Implements iclsD_QLTC_PhieuthuchiDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLTC_PhieuthuchiEntity) Implements iclsD_QLTC_PhieuthuchiDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLTC_PhieuthuchiEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLTC_PhieuthuchiEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLTC_PhieuthuchiEntity)
                With lstobj(i)
                    .uId_Phieuthuchi = IIf(IsDBNull(objReader("uId_Phieuthuchi")) = True, "", Convert.ToString(objReader("uId_Phieuthuchi")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Thuchi = IIf(IsDBNull(objReader("uId_Thuchi")) = True, "", Convert.ToString(objReader("uId_Thuchi")))
                    .v_Maphieu = IIf(IsDBNull(objReader("v_Maphieu")) = True, "", objReader("v_Maphieu"))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .nv_Lydo_vn = IIf(IsDBNull(objReader("nv_Lydo_vn")) = True, "", objReader("nv_Lydo_vn"))
                    .nv_Lydo_en = IIf(IsDBNull(objReader("nv_Lydo_en")) = True, "", objReader("nv_Lydo_en"))
                    .v_NguonThanhtoan = IIf(IsDBNull(objReader("v_NguonThanhtoan")) = True, "", objReader("v_NguonThanhtoan"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLTC_PhieuthuchiEntity)
        End Try
    End Function
    Public Function SelectByDMThuchi(ByVal uId_Thuchi As String, ByVal strTungay As String, ByVal strDenngay As String) As System.Data.DataTable Implements iclsD_QLTC_PhieuthuchiDA.SelectByDMThuchi
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_SelectByDMThuchi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thuchi", System.Data.DbType.String, uId_Thuchi)
            db.AddInParameter(objCmd, "@Tungay", System.Data.DbType.DateTime, strTungay)
            db.AddInParameter(objCmd, "@Denngay", System.Data.DbType.DateTime, strDenngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectAllTable(ByVal uId_Thuchi As String, ByVal v_NguonThanhtoan As String) As System.Data.DataTable Implements iclsD_QLTC_PhieuthuchiDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thuchi", System.Data.DbType.String, uId_Thuchi)
            db.AddInParameter(objCmd, "@v_NguonThanhtoan", System.Data.DbType.String, v_NguonThanhtoan)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Phieuthuchi As String) As CM.QLTC_PhieuthuchiEntity Implements iclsD_QLTC_PhieuthuchiDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLTC_PhieuthuchiEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", System.Data.DbType.String, uId_Phieuthuchi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLTC_PhieuthuchiEntity
            If objReader.Read Then
                With obj
                    .uId_Phieuthuchi = IIf(IsDBNull(objReader("uId_Phieuthuchi")) = True, "", Convert.ToString(objReader("uId_Phieuthuchi")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Thuchi = IIf(IsDBNull(objReader("uId_Thuchi")) = True, "", Convert.ToString(objReader("uId_Thuchi")))
                    .v_Maphieu = IIf(IsDBNull(objReader("v_Maphieu")) = True, "", objReader("v_Maphieu"))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .nv_Lydo_vn = IIf(IsDBNull(objReader("nv_Lydo_vn")) = True, "", objReader("nv_Lydo_vn"))
                    .nv_Lydo_en = IIf(IsDBNull(objReader("nv_Lydo_en")) = True, "", objReader("nv_Lydo_en"))
                    .v_NguonThanhtoan = IIf(IsDBNull(objReader("v_NguonThanhtoan")) = True, "", objReader("v_NguonThanhtoan"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .uId_LoaiTT = IIf(IsDBNull(objReader("uId_LoaiTT")) = True, "", Convert.ToString(objReader("uId_LoaiTT")))
                    .b_IsKhoa = IIf(IsDBNull(objReader("b_IsKhoa")) = True, False, Convert.ToString(objReader("b_IsKhoa")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLTC_PhieuthuchiEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_PhieuthuchiEntity) As String Implements iclsD_QLTC_PhieuthuchiDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Maphieu", DbType.String, obj.v_Maphieu)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@uId_Thuchi", DbType.String, obj.uId_Thuchi)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.AddInParameter(objCmd, "@nv_Lydo_vn", DbType.String, obj.nv_Lydo_vn)
            db.AddInParameter(objCmd, "@nv_Lydo_en", DbType.String, obj.nv_Lydo_en)
            db.AddInParameter(objCmd, "@v_NguonThanhtoan", DbType.String, obj.v_NguonThanhtoan)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, obj.uId_LoaiTT)
            db.AddInParameter(objCmd, "@b_IsKhoa", DbType.Boolean, obj.b_IsKhoa)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieuthuchi As String) As Boolean Implements iclsD_QLTC_PhieuthuchiDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", DbType.String, uId_Phieuthuchi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLTC_PhieuthuchiEntity) As Boolean Implements iclsD_QLTC_PhieuthuchiDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", DbType.String, obj.uId_Phieuthuchi)
            'db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Thuchi", DbType.String, obj.uId_Thuchi)
            db.AddInParameter(objCmd, "@v_Maphieu", DbType.String, obj.v_Maphieu)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.AddInParameter(objCmd, "@nv_Lydo_vn", DbType.String, obj.nv_Lydo_vn)
            db.AddInParameter(objCmd, "@nv_Lydo_en", DbType.String, obj.nv_Lydo_en)

            'db.AddInParameter(objCmd, "@v_NguonThanhtoan", DbType.String, obj.v_NguonThanhtoan)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function ThuChiKH(ByVal uId_Khachhang As String) As String Implements iclsD_QLTC_PhieuthuchiDA.ThuChiKH
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_Khachhang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function

    Public Function SelectAllCongno(ByVal strTungay As Date, ByVal strDenngay As Date) As System.Data.DataTable Implements iclsD_QLTC_PhieuthuchiDA.SelectAllCongno
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_Phieuthuchi_SelectCongNo]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@Tungay", System.Data.DbType.DateTime, strTungay)
            db.AddInParameter(objCmd, "@Denngay", System.Data.DbType.DateTime, strDenngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function GetMaMaxBydate(uId_Cuahang As String, ddate As Date, sLoai As String) As String Implements iclsD_QLTC_PhieuthuchiDA.GetMaMaxBydate
        Dim db As Database
        Dim sp As String = "[dbo].[tntp_Phieuthuchi_SelectMaxSophieu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@NgayNhap", DbType.Date, ddate)
            db.AddInParameter(objCmd, "@sLoai", DbType.String, sLoai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "1"
        End Try
    End Function

    Public Function InHoadonTonghop(uId_Khachhang As String, uId_Phieuxuat As String, uId_Phieudichvu As String) As DataTable Implements iclsD_QLTC_PhieuthuchiDA.InHoadonTonghop
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_InphieuSPDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)
            db.AddInParameter(objCmd, "@uId_PhieuDichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class