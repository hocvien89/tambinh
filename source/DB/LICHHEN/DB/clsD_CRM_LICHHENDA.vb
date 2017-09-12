Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_LICHHENDA

    Implements ICRM_LICHHENDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_LICHHENEntity) Implements ICRM_LICHHENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_LICHHENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_LICHHENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_LICHHENEntity)
                With lstobj(i)
                    .uId_Lichhen = IIf(IsDBNull(objReader("uId_Lichhen")) = True, "", Convert.ToString(objReader("uId_Lichhen")))
                    .v_Tugio = IIf(IsDBNull(objReader("v_Tugio")) = True, "", objReader("v_Tugio"))
                    .v_Dengio = IIf(IsDBNull(objReader("v_Dengio")) = True, "", objReader("v_Dengio"))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .nv_HotenKhachhang_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_HotenNhanvien_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_LICHHENEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements ICRM_LICHHENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectAll]"
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

    Public Function CheckCanhBao(ByVal strTime As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements ICRM_LICHHENDA.CheckCanhbao
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectAll_Canhbao]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TimeNow", DbType.String, strTime)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTrangthaiAllTable(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable Implements ICRM_LICHHENDA.SelectTrangthaiAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectTrangThaiAll]"
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

    Public Function SelectByID(ByVal uId_Lichhen As String) As CM.CRM_LICHHENEntity Implements ICRM_LICHHENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_LICHHENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Lichhen", DbType.String, uId_Lichhen)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_LICHHENEntity
            If objReader.Read Then
                With obj
                    .uId_Lichhen = IIf(IsDBNull(objReader("uId_Lichhen")) = True, "", Convert.ToString(objReader("uId_Lichhen")))
                    .v_Tugio = IIf(IsDBNull(objReader("v_Tugio")) = True, "", objReader("v_Tugio"))
                    .v_Dengio = IIf(IsDBNull(objReader("v_Dengio")) = True, "", objReader("v_Dengio"))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .nv_HotenKhachhang_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_HotenNhanvien_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                    '.uId_NVTuvanhen = IIf(IsDBNull(objReader("uId_NVTuvanhen")) = True, "", Convert.ToString(objReader("uId_NVTuvanhen")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_LICHHENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_LICHHENEntity) As Boolean Implements ICRM_LICHHENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Tugio", DbType.String, obj.v_Tugio)
            db.AddInParameter(objCmd, "@v_Dengio", DbType.String, obj.v_Dengio)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
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

    Public Function DeleteByID(ByVal uId_Lichhen As String) As Boolean Implements ICRM_LICHHENDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Lichhen", DbType.String, uId_Lichhen)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_LICHHENEntity) As Boolean Implements ICRM_LICHHENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Lichhen", DbType.String, obj.uId_Lichhen)
            db.AddInParameter(objCmd, "@v_Tugio", DbType.String, obj.v_Tugio)
            db.AddInParameter(objCmd, "@v_Dengio", DbType.String, obj.v_Dengio)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            'db.AddInParameter(objCmd, "@uId_NVTuvanhen", DbType.String, obj.uId_NVTuvanhen)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByKH(ByVal uID_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements ICRM_LICHHENDA.SelectByKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectByKH]"
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

    Public Function SelectByNhanvien(ByVal uId_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements ICRM_LICHHENDA.SelectByNhanvien
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectByNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTrangthaiByNhanvien(ByVal uId_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable Implements ICRM_LICHHENDA.SelectTrangthaiByNhanvien
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectTrangThaiByNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, uID_Trangthai)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function CheckTrungLichhen(ByVal uID_Nhanvien As String, ByVal d_Ngay As DateTime, ByVal v_Tugio As String, ByVal v_Dengio As String, ByVal uId_Cuahang As String, ByVal uId_Lichhen As String) As System.Data.DataTable Implements ICRM_LICHHENDA.CheckTrungLichhen
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_CheckTrungLichhen]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uID_Nhanvien", DbType.String, uID_Nhanvien)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            db.AddInParameter(objCmd, "@v_Tugio", DbType.String, v_Tugio)
            db.AddInParameter(objCmd, "@v_Dengio", DbType.String, v_Dengio)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Lichhen", DbType.String, uId_Lichhen)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class