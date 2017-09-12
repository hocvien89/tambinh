Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_LICHHEN_HPDA

    Implements ICRM_LICHHEN_HPDA
    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Collections.Generic.List(Of CM.CRM_LICHHEN_HPEntity) Implements ICRM_LICHHEN_HPDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_LICHHEN_HPEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_LICHHEN_HPEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_LICHHEN_HPEntity)
                With lstobj(i)
                    .uId_Lichhen_HP = IIf(IsDBNull(objReader("uId_Lichhen_HP")) = True, "", Convert.ToString(objReader("uId_Lichhen_HP")))
                    .d_Tungay = IIf(IsDBNull(objReader("d_Tungay")) = True, Nothing, objReader("d_Tungay"))
                    .d_Denngay = IIf(IsDBNull(objReader("d_Denngay")) = True, Nothing, objReader("d_Denngay"))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .v_Makhachang = IIf(IsDBNull(objReader("v_Makhachang")) = True, "", objReader("v_Makhachang"))
                    .nv_HotenKhachhang_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_HotenNhanvien_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_LICHHEN_HPEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable Implements ICRM_LICHHEN_HPDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Lichhen_HP As String) As CM.CRM_LICHHEN_HPEntity Implements ICRM_LICHHEN_HPDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_LICHHEN_HPEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Lichhen_HP", DbType.String, uId_Lichhen_HP)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_LICHHEN_HPEntity
            If objReader.Read Then
                With obj
                    .uId_Lichhen_HP = IIf(IsDBNull(objReader("uId_Lichhen_HP")) = True, "", Convert.ToString(objReader("uId_Lichhen_HP")))
                    .d_Tungay = IIf(IsDBNull(objReader("d_Tungay")) = True, Nothing, objReader("d_Tungay"))
                    .d_Denngay = IIf(IsDBNull(objReader("d_Denngay")) = True, Nothing, objReader("d_Denngay"))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_LICHHEN_HPEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_LICHHEN_HPEntity) As Boolean Implements ICRM_LICHHEN_HPDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (obj.d_Tungay <> Nothing And obj.d_Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, obj.d_Tungay)
            End If
            If (obj.d_Denngay <> Nothing And obj.d_Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, obj.d_Denngay)
            End If
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Lichhen_HP As String) As Boolean Implements ICRM_LICHHEN_HPDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Lichhen_HP", DbType.String, uId_Lichhen_HP)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_LICHHEN_HPEntity) As Boolean Implements ICRM_LICHHEN_HPDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Lichhen_HP", DbType.String, obj.uId_Lichhen_HP)
            If (obj.d_Tungay <> Nothing And obj.d_Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, obj.d_Tungay)
            End If
            If (obj.d_Denngay <> Nothing And obj.d_Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, obj.d_Denngay)
            End If
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByKH(ByVal uID_Khachhang As String, ByVal TuNgay As Date, ByVal DenNgay As Date) As System.Data.DataTable Implements ICRM_LICHHEN_HPDA.SelectByKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectByKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uID_Khachhang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As Date, ByVal DenNgay As Date) As System.Data.DataTable Implements ICRM_LICHHEN_HPDA.SelectByNhanvien
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectByNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uID_Nhanvien)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTrangthaiAllTable(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uID_Trangthai As String) As System.Data.DataTable Implements ICRM_LICHHEN_HPDA.SelectTrangthaiAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectTrangThaiAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, uID_Trangthai)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTrangthaiByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uID_Trangthai As String) As System.Data.DataTable Implements ICRM_LICHHEN_HPDA.SelectTrangthaiByNhanvien
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectTrangThaiByNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, uID_Trangthai)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uID_Nhanvien)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllKhachToihen(ByVal d_Tungay As Date) As System.Data.DataTable Implements ICRM_LICHHEN_HPDA.SelectAllKhachToihen
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_HP_SelectAll_Toihen]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Tungay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class