Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLP_CADA

    Implements IQLP_CADA
    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal d_Ngay As DateTime) As System.Collections.Generic.List(Of CM.QLP_CAEntity) Implements IQLP_CADA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLP_CAEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLP_CAEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLP_CAEntity)
                With lstobj(i)
                    .uId_Ca = IIf(IsDBNull(objReader("uId_Ca")) = True, "", Convert.ToString(objReader("uId_Ca")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .v_Thoigian_BD = IIf(IsDBNull(objReader("v_Thoigian_BD")) = True, "", objReader("v_Thoigian_BD"))
                    .v_Thoigian_KT = IIf(IsDBNull(objReader("v_Thoigian_KT")) = True, "", objReader("v_Thoigian_KT"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .nv_HotenKhachhang_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tenphong_vn = IIf(IsDBNull(objReader("nv_Tenphong_vn")) = True, "", objReader("nv_Tenphong_vn"))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                    .nv_HotenNhanvien_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLP_CAEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal d_Ngay As DateTime) As System.Data.DataTable Implements IQLP_CADA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectAll]"
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
    Public Function SelectAllBuffer(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLP_CADA.SelectAllBuffer
        Dim dbtime As Database
        Dim sptime As String = "[dbo].[spCRM_LICHHEN_KHOANGTG_Selectall]"
        Dim objCmdtime As DbCommand
        Dim objDstime As DataSet
        Dim tugio As Integer
        Dim dengio As Integer
        Dim khoang As Integer
        Try
            dbtime = DatabaseFactory.CreateDatabase()
            objCmdtime = dbtime.GetStoredProcCommand(sptime)
            objDstime = dbtime.ExecuteDataSet(objCmdtime)
            Dim tbtime As DataTable = objDstime.Tables(0)
            tugio = tbtime.Rows(0)(1)
            dengio = tbtime.Rows(0)(2)
            khoang = tbtime.Rows(0)(3)
        Catch ex As Exception
            log.WriteLog(sptime, ex.Message)
        End Try
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectAllBuffer]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tugio", DbType.Int32, tugio)
            db.AddInParameter(objCmd, "@Dengio", DbType.Int32, dengio)
            db.AddInParameter(objCmd, "@Khoang", DbType.Int32, khoang)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByPhong(ByVal d_Ngay As DateTime) As System.Data.DataTable Implements IQLP_CADA.SelectByPhong
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectByPhong]"
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

    Public Function SelectByID(ByVal uId_Ca As String) As CM.QLP_CAEntity Implements IQLP_CADA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLP_CAEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, uId_Ca)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLP_CAEntity
            If objReader.Read Then
                With obj
                    .uId_Ca = IIf(IsDBNull(objReader("uId_Ca")) = True, "", Convert.ToString(objReader("uId_Ca")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .v_Thoigian_BD = IIf(IsDBNull(objReader("v_Thoigian_BD")) = True, "", objReader("v_Thoigian_BD"))
                    .v_Thoigian_KT = IIf(IsDBNull(objReader("v_Thoigian_KT")) = True, "", objReader("v_Thoigian_KT"))
                    '.uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    '.nv_HotenKhachhang_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    '.nv_Tenphong_vn = IIf(IsDBNull(objReader("nv_Tenphong_vn")) = True, "", objReader("nv_Tenphong_vn"))
                    '.nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                    '.nv_HotenNhanvien_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLP_CAEntity
        End Try
    End Function

    Public Function SelectByDate(ByVal uId_Phong As String, ByVal d_Ngay As DateTime) As System.Data.DataTable Implements IQLP_CADA.SelectByDate
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectByDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            If (d_Ngay <> Nothing And d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            End If
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectPhongByDate(ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLP_CADA.SelectPhongByDate
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectPhongByDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet

        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (d_Ngay <> Nothing And d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            End If
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLP_CAEntity) As String Implements IQLP_CADA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, obj.uId_Phong)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@v_Thoigian_BD", DbType.String, obj.v_Thoigian_BD)
            db.AddInParameter(objCmd, "@v_Thoigian_KT", DbType.String, obj.v_Thoigian_KT)

            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString

        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Ca As String) As Boolean Implements IQLP_CADA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, uId_Ca)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLP_CAEntity) As Boolean Implements IQLP_CADA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, obj.uId_Ca)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, obj.uId_Phong)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@v_Thoigian_BD", DbType.String, obj.v_Thoigian_BD)
            db.AddInParameter(objCmd, "@v_Thoigian_KT", DbType.String, obj.v_Thoigian_KT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllByNgay(ByVal d_Ngay As Date) As System.Data.DataTable Implements IQLP_CADA.SelectAllByNgay
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectAllByNgay]"
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

    Public Function SelectAllByThoigian(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLP_CADA.SelectAllByThoigian
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectPhongByNhieuNgay]"
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
End Class