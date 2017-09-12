Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_CongviecDA

    Implements IMKT_CongviecDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_CongviecEntity) Implements IMKT_CongviecDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_CongviecEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_CongviecEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_CongviecEntity)
                With lstobj(i)
                    .uId_Congviec = IIf(IsDBNull(objReader("uId_Congviec")) = True, "", Convert.ToString(objReader("uId_Congviec")))
                    .uId_MaCongviec = IIf(IsDBNull(objReader("uId_MaCongviec")) = True, "", Convert.ToString(objReader("uId_MaCongviec")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .Tags = IIf(IsDBNull(objReader("Tags")) = True, "", Convert.ToString(objReader("Tags")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_CongviecEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IMKT_CongviecDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SelectAll]"
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

    Public Function SelectByIDKhachhang(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable Implements IMKT_CongviecDA.SelectByIDKhachhang
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SELECTBYIDKhachhang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", System.Data.DbType.String, uId_KH_Tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Congviec As String) As CM.MKT_CongviecEntity Implements IMKT_CongviecDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_CongviecEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congviec", System.Data.DbType.String, uId_Congviec)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_CongviecEntity
            If objReader.Read Then
                With obj
                    .uId_Congviec = IIf(IsDBNull(objReader("uId_Congviec")) = True, "", Convert.ToString(objReader("uId_Congviec")))
                    .uId_MaCongviec = IIf(IsDBNull(objReader("uId_MaCongviec")) = True, "", Convert.ToString(objReader("uId_MaCongviec")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .TrangThaiCongViec = IIf(IsDBNull(objReader("TrangThaiCongViec")) = True, "", Convert.ToString(objReader("TrangThaiCongViec")))
                    .LoaiCuocGoi = IIf(IsDBNull(objReader("LoaiCuocGoi")) = True, "", Convert.ToString(objReader("LoaiCuocGoi")))
                    .DVKHQuantam = IIf(IsDBNull(objReader("DichVuKHQuanTam")) = True, "", Convert.ToString(objReader("DichVuKHQuanTam")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .Tags = IIf(IsDBNull(objReader("Tags")) = True, "", Convert.ToString(objReader("Tags")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_CongviecEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_CongviecEntity) As Boolean Implements IMKT_CongviecDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@uId_MaCongviec", DbType.String, obj.uId_MaCongviec)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "@TrangThaiCongViec", DbType.String, obj.TrangThaiCongViec)
            db.AddInParameter(objCmd, "@LoaiCuocGoi", DbType.String, obj.LoaiCuocGoi)
            db.AddInParameter(objCmd, "@DichVuKHQuanTam", DbType.String, obj.DVKHQuantam)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@Tags", DbType.String, obj.Tags)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Congviec As String) As Boolean Implements IMKT_CongviecDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congviec", DbType.String, uId_Congviec)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_CongviecEntity) As Boolean Implements IMKT_CongviecDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congviec", DbType.String, obj.uId_Congviec)
            db.AddInParameter(objCmd, "@uId_MaCongviec", DbType.String, obj.uId_MaCongviec)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@TrangThaiCongViec", DbType.String, obj.TrangThaiCongViec)
            db.AddInParameter(objCmd, "@LoaiCuocGoi", DbType.String, obj.LoaiCuocGoi)
            db.AddInParameter(objCmd, "@DichVuKHQuanTam", DbType.String, obj.DVKHQuantam)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@Tags", DbType.String, obj.Tags)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByTagsGanDung(ByVal keyword As String, ByVal tungay As Date, ByVal dengay As Date, ByVal uId_Trangthai_KH As String) As System.Data.DataTable Implements IMKT_CongviecDA.SelectByTagsGanDung
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SELECTBYTAGGANDUNG]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@keyword", DbType.String, keyword)
            db.AddInParameter(objCmd, "@tungay", DbType.DateTime, tungay)
            db.AddInParameter(objCmd, "@denngay", DbType.String, dengay)
            db.AddInParameter(objCmd, "@uId_Trangthai_KH", DbType.String, uId_Trangthai_KH)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByTagsChinhXac(ByVal keyword As String, ByVal tungay As Date, ByVal dengay As Date, ByVal uId_Trangthai_KH As String, ByVal uId_Nhanvien As String, uIdCuahang As String) As System.Data.DataTable Implements IMKT_CongviecDA.SelectByTagsChinhxac
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SELECTBYTAGCHINHXAC]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@keyword", DbType.String, keyword)
            db.AddInParameter(objCmd, "@tungay", DbType.DateTime, tungay)
            db.AddInParameter(objCmd, "@denngay", DbType.String, dengay)
            db.AddInParameter(objCmd, "@uId_Trangthai_KH", DbType.String, uId_Trangthai_KH)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uIdCuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTagByTime(ByVal tungay As Date, ByVal dengay As Date) As System.Data.DataTable Implements IMKT_CongviecDA.SelectTagByTime
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Congviec_SELECTTAGBYTIME]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@tungay", DbType.DateTime, tungay)
            db.AddInParameter(objCmd, "@denngay", DbType.String, dengay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class