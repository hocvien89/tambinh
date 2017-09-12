Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QT_DM_NHANVIENDA

    Implements IQT_DM_NHANVIENDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QT_DM_NHANVIENEntity) Implements IQT_DM_NHANVIENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QT_DM_NHANVIENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QT_DM_NHANVIENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QT_DM_NHANVIENEntity)
                With lstobj(i)
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Barcode = IIf(IsDBNull(objReader("v_Barcode")) = True, "", objReader("v_Barcode"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .nv_Chucvu_en = IIf(IsDBNull(objReader("nv_Chucvu_en")) = True, "", objReader("nv_Chucvu_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Quequan_vn = IIf(IsDBNull(objReader("nv_Quequan_vn")) = True, "", objReader("nv_Quequan_vn"))
                    .nv_Quequan_en = IIf(IsDBNull(objReader("nv_Quequan_en")) = True, "", objReader("nv_Quequan_en"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .v_Tendangnhap = IIf(IsDBNull(objReader("v_Tendangnhap")) = True, "", objReader("v_Tendangnhap"))
                    .v_Matkhau = IIf(IsDBNull(objReader("v_Matkhau")) = True, "", objReader("v_Matkhau"))
                    .b_ActiveLogin = IIf(IsDBNull(objReader("b_ActiveLogin")) = True, 0, objReader("b_ActiveLogin"))
                    .d_Ngayvaolam = IIf(IsDBNull(objReader("d_Ngayvaolam")) = True, Nothing, objReader("d_Ngayvaolam"))
                    .b_Danglamviec = IIf(IsDBNull(objReader("b_Danglamviec")) = True, 0, objReader("b_Danglamviec"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QT_DM_NHANVIENEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll]"
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
    Public Function SelectByTenDangNhap(ByVal v_Tendangnhap As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.SelectByTenDangNhap
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectByTenDangNhap]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, v_Tendangnhap)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function DoanhThu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.DoanhThu
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_DoanhThu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function DoanhThuBanDV_SP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.DoanhThuBanDV_SP
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThuTheoNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Nhanvien As String) As CM.QT_DM_NHANVIENEntity Implements IQT_DM_NHANVIENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QT_DM_NHANVIENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", System.Data.DbType.String, uId_Nhanvien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QT_DM_NHANVIENEntity
            If objReader.Read Then
                With obj
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Barcode = IIf(IsDBNull(objReader("v_Barcode")) = True, "", objReader("v_Barcode"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .nv_Chucvu_en = IIf(IsDBNull(objReader("nv_Chucvu_en")) = True, "", objReader("nv_Chucvu_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Quequan_vn = IIf(IsDBNull(objReader("nv_Quequan_vn")) = True, "", objReader("nv_Quequan_vn"))
                    .nv_Quequan_en = IIf(IsDBNull(objReader("nv_Quequan_en")) = True, "", objReader("nv_Quequan_en"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .v_Tendangnhap = IIf(IsDBNull(objReader("v_Tendangnhap")) = True, "", objReader("v_Tendangnhap"))
                    .v_Matkhau = IIf(IsDBNull(objReader("v_Matkhau")) = True, "", objReader("v_Matkhau"))
                    .b_ActiveLogin = IIf(IsDBNull(objReader("b_ActiveLogin")) = True, 0, objReader("b_ActiveLogin"))
                    .d_Ngayvaolam = IIf(IsDBNull(objReader("d_Ngayvaolam")) = True, Nothing, objReader("d_Ngayvaolam"))
                    .b_Danglamviec = IIf(IsDBNull(objReader("b_Danglamviec")) = True, 0, objReader("b_Danglamviec"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QT_DM_NHANVIENEntity
        End Try
    End Function

    Public Function SelectByUser(ByVal v_Tendangnhap As String) As CM.QT_DM_NHANVIENEntity Implements IQT_DM_NHANVIENDA.SelectByUser
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectByUser]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QT_DM_NHANVIENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Tendangnhap", System.Data.DbType.String, v_Tendangnhap)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QT_DM_NHANVIENEntity
            If objReader.Read Then
                With obj
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .v_Barcode = IIf(IsDBNull(objReader("v_Barcode")) = True, "", objReader("v_Barcode"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .nv_Chucvu_en = IIf(IsDBNull(objReader("nv_Chucvu_en")) = True, "", objReader("nv_Chucvu_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Quequan_vn = IIf(IsDBNull(objReader("nv_Quequan_vn")) = True, "", objReader("nv_Quequan_vn"))
                    .nv_Quequan_en = IIf(IsDBNull(objReader("nv_Quequan_en")) = True, "", objReader("nv_Quequan_en"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .v_Tendangnhap = IIf(IsDBNull(objReader("v_Tendangnhap")) = True, "", objReader("v_Tendangnhap"))
                    .v_Matkhau = IIf(IsDBNull(objReader("v_Matkhau")) = True, "", objReader("v_Matkhau"))
                    .b_ActiveLogin = IIf(IsDBNull(objReader("b_ActiveLogin")) = True, 0, objReader("b_ActiveLogin"))
                    .d_Ngayvaolam = IIf(IsDBNull(objReader("d_Ngayvaolam")) = True, Nothing, objReader("d_Ngayvaolam"))
                    .b_Danglamviec = IIf(IsDBNull(objReader("b_Danglamviec")) = True, 0, objReader("b_Danglamviec"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QT_DM_NHANVIENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QT_DM_NHANVIENEntity, ByVal Loai As Boolean) As String Implements IQT_DM_NHANVIENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Barcode", DbType.String, obj.v_Barcode)
            db.AddInParameter(objCmd, "@v_Manhanvien", DbType.String, obj.v_Manhanvien)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@nv_Chucvu_vn", DbType.String, obj.nv_Chucvu_vn)
            db.AddInParameter(objCmd, "@nv_Chucvu_en", DbType.String, obj.nv_Chucvu_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@nv_Quequan_vn", DbType.String, obj.nv_Quequan_vn)
            db.AddInParameter(objCmd, "@nv_Quequan_en", DbType.String, obj.nv_Quequan_en)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, obj.v_Tendangnhap)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.AddInParameter(objCmd, "@b_ActiveLogin", DbType.Boolean, obj.b_ActiveLogin)
            If (obj.d_Ngayvaolam <> Nothing And obj.d_Ngayvaolam <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayvaolam", DbType.DateTime, obj.d_Ngayvaolam)
            End If
            db.AddInParameter(objCmd, "@b_Danglamviec", DbType.Boolean, obj.b_Danglamviec)
            db.AddInParameter(objCmd, "@b_Loai", DbType.Boolean, Loai)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Nhanvien As String) As Boolean Implements IQT_DM_NHANVIENDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QT_DM_NHANVIENEntity, ByVal Loai As Boolean) As Boolean Implements IQT_DM_NHANVIENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@v_Barcode", DbType.String, obj.v_Barcode)
            db.AddInParameter(objCmd, "@v_Manhanvien", DbType.String, obj.v_Manhanvien)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@nv_Chucvu_vn", DbType.String, obj.nv_Chucvu_vn)
            db.AddInParameter(objCmd, "@nv_Chucvu_en", DbType.String, obj.nv_Chucvu_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@nv_Quequan_vn", DbType.String, obj.nv_Quequan_vn)
            db.AddInParameter(objCmd, "@nv_Quequan_en", DbType.String, obj.nv_Quequan_en)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, obj.v_Tendangnhap)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.AddInParameter(objCmd, "@b_ActiveLogin", DbType.Boolean, obj.b_ActiveLogin)
            If (obj.d_Ngayvaolam <> Nothing And obj.d_Ngayvaolam <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayvaolam", DbType.DateTime, obj.d_Ngayvaolam)
            End If
            db.AddInParameter(objCmd, "@b_Danglamviec", DbType.Boolean, obj.b_Danglamviec)
            db.AddInParameter(objCmd, "@b_Loai", DbType.Boolean, Loai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DoiMatKhau(ByVal id As String, ByVal pass As String) As Boolean Implements IQT_DM_NHANVIENDA.DoiMatKhau
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_Doimatkhau]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, id)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, pass)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Get_DS_Nhanvien_To_Nguon() As System.Data.DataTable Implements IQT_DM_NHANVIENDA.Get_DS_Nhanvien_To_Nguon
        'Create by: Mr Thag
        'Ham lay DS nhan vien lam nguon den, de cho biet ai gioi thieu KH den
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll_ToNguon]"
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

    Public Function TimKiem(ByVal key As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.TimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_Search]"
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

    Public Function DoanhThuThucHien(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.DoanhThuThucHien
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Hoahong_Thuchien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function DoanhThuBanHang(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Nhanvien As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.DoanhThuBanHang
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_DoanhThu_Banhang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function HoaHong_PhieuDV(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Nhanvien As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.HoaHong_PhieuDV
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_HoaHong_Phieudichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function HoaHong_BanSP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal uId_Kho As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.HoaHong_BanSP
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_HoaHong_BanSP]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllAdminTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQT_DM_NHANVIENDA.SelectAllAdminTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll_Admin]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            'db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    'xuanhieu 251214 Bao cao doanh thu nhan vien
    Public Function BcDoanhthuTong(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable Implements IQT_DM_NHANVIENDA.BcDoanhthuTong
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_Doanhthu_NV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function HHPhieudv(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable Implements IQT_DM_NHANVIENDA.HHPhieudv
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUDICHVU_SelectByIdNV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function HHPhieuthuchi(Tungay As Date, Denngay As DateTime, uId_Nhanvien As String) As DataTable Implements IQT_DM_NHANVIENDA.HHPhieuthuchi
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUTHUCHI_SelectByIdNV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function HHPhieuxuat(Tungay As Date, Denngay As Date, uId_Nhanvien As String) As DataTable Implements IQT_DM_NHANVIENDA.HHPhieuxuat
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_SelectByIdNV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByActive() As DataTable Implements IQT_DM_NHANVIENDA.SelectByActive
        Dim db As Database
        Dim sp As String = "[dbo].[sp_DM_Nhanvien_SelectAll_Ap]"
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

    Public Function SelectnhanvienByLichhen(uId_Cuahang As String, dateStart As Date, dateEnd As Date, uId_Nhanvien As String) As DataTable Implements IQT_DM_NHANVIENDA.SelectnhanvienByLichhen
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll_Bylichhen]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@DateStrart", DbType.String, dateStart)
            db.AddInParameter(objCmd, "@DateEnd", DbType.String, dateEnd)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Nhanvien_By_Phong(uId_Phong As String) As DataTable Implements IQT_DM_NHANVIENDA.Select_Nhanvien_By_Phong
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Nhanvien_By_Phong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable_Calamviec(d_Ngay As DateTime) As DataTable Implements IQT_DM_NHANVIENDA.SelectAllTable_Calamviec
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_NhanvienAll_Calamviec]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Nhanvien_By_Time() As DataTable Implements IQT_DM_NHANVIENDA.Select_Nhanvien_By_Time
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Nhanvien_By_Time]"
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

    Public Function Select_Nhanvien_Phong_Baocao(uId_Phong As String) As DataTable Implements IQT_DM_NHANVIENDA.Select_Nhanvien_Phong_Baocao
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Nhanvien_By_Phong_Check]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Baocao_Nhanvien_Kythuat(d_Tungay As Date, d_Denngay As Date, uId_Nhanvien As String) As DataTable Implements IQT_DM_NHANVIENDA.Baocao_Nhanvien_Kythuat
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Baocao_Nhanvien_Kythuat_Chitiet]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Load_Nhanvien_Kythuat_AuTo(d_Ngay As DateTime) As DataTable Implements IQT_DM_NHANVIENDA.Load_Nhanvien_Kythuat_AuTo
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Nhanvien_Kythuat_Auto_ByTime]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Load_Nhanvien_Tuvan_AuTo(d_Ngay As DateTime) As DataTable Implements IQT_DM_NHANVIENDA.Load_Nhanvien_Tuvan_AuTo
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Nhanvien_Tuvan_Auto_ByTime]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable_Convert(uId_Cuahang As String) As DataTable Implements IQT_DM_NHANVIENDA.SelectAllTable_Convert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Danhmuc_Nhanvien_Into_Khachhang]"
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
End Class