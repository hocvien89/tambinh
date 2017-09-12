Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_QT_DIEUTRI_HPDA

    Implements ITNTP_QT_DIEUTRI_HPDA
    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Khachhang As String) As System.Collections.Generic.List(Of CM.TNTP_QT_DIEUTRI_HPEntity) Implements ITNTP_QT_DIEUTRI_HPDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_SelectAll1]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_QT_DIEUTRI_HPEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_QT_DIEUTRI_HPEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_QT_DIEUTRI_HPEntity)
                With lstobj(i)
                    .uId_QT_Dieutri_HP = IIf(IsDBNull(objReader("uId_QT_Dieutri_HP")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri_HP")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .i_Lanthu = IIf(IsDBNull(objReader("i_Lanthu")) = True, 0, objReader("i_Lanthu"))
                    .d_NgayDT = IIf(IsDBNull(objReader("d_NgayDT")) = True, Nothing, objReader("d_NgayDT"))
                    .nv_GiatriDT_vn = IIf(IsDBNull(objReader("nv_GiatriDT_vn")) = True, "", objReader("nv_GiatriDT_vn"))
                    .nv_GiatriDT_en = IIf(IsDBNull(objReader("nv_GiatriDT_en")) = True, "", objReader("nv_GiatriDT_en"))
                    .nv_Hinhanh = IIf(IsDBNull(objReader("nv_Hinhanh")) = True, "", objReader("nv_Hinhanh"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                    .f_Gia = IIf(IsDBNull(objReader("f_Gia")) = True, 0, objReader("f_Gia"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .f_Lephi_DT = IIf(IsDBNull(objReader("f_Lephi_DT")) = True, 0, objReader("f_Lephi_DT"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_QT_DIEUTRI_HPEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String, ByVal uId_Nhomdichvu As String) As System.Data.DataTable Implements ITNTP_QT_DIEUTRI_HPDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_QT_Dieutri_HP As String) As CM.TNTP_QT_DIEUTRI_HPEntity Implements ITNTP_QT_DIEUTRI_HPDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_QT_DIEUTRI_HPEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri_HP", DbType.String, uId_QT_Dieutri_HP)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_QT_DIEUTRI_HPEntity
            If objReader.Read Then
                With obj
                    .uId_QT_Dieutri_HP = IIf(IsDBNull(objReader("uId_QT_Dieutri_HP")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri_HP")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .i_Lanthu = IIf(IsDBNull(objReader("i_Lanthu")) = True, 0, objReader("i_Lanthu"))
                    .d_NgayDT = IIf(IsDBNull(objReader("d_NgayDT")) = True, Nothing, objReader("d_NgayDT"))
                    .nv_GiatriDT_vn = IIf(IsDBNull(objReader("nv_GiatriDT_vn")) = True, "", objReader("nv_GiatriDT_vn"))
                    .nv_GiatriDT_en = IIf(IsDBNull(objReader("nv_GiatriDT_en")) = True, "", objReader("nv_GiatriDT_en"))
                    .nv_Hinhanh = IIf(IsDBNull(objReader("nv_Hinhanh")) = True, "", objReader("nv_Hinhanh"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .f_Lephi_DT = IIf(IsDBNull(objReader("f_Lephi_DT")) = True, 0, objReader("f_Lephi_DT"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_QT_DIEUTRI_HPEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_HPEntity) As Boolean Implements ITNTP_QT_DIEUTRI_HPDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Lanthu", DbType.Int32, obj.i_Lanthu)
            If (obj.d_NgayDT <> Nothing And obj.d_NgayDT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayDT", DbType.DateTime, obj.d_NgayDT)
            End If
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@nv_GiatriDT_vn", DbType.String, obj.nv_GiatriDT_vn)
            db.AddInParameter(objCmd, "@nv_GiatriDT_en", DbType.String, obj.nv_GiatriDT_en)
            db.AddInParameter(objCmd, "@nv_Hinhanh", DbType.String, obj.nv_Hinhanh)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@f_Lephi_DT", DbType.Double, obj.f_Lephi_DT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_QT_Dieutri_HP As String) As Boolean Implements ITNTP_QT_DIEUTRI_HPDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri_HP", DbType.String, uId_QT_Dieutri_HP)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_QT_DIEUTRI_HPEntity) As Boolean Implements ITNTP_QT_DIEUTRI_HPDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri_HP", DbType.String, obj.uId_QT_Dieutri_HP)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@i_Lanthu", DbType.Int32, obj.i_Lanthu)
            If (obj.d_NgayDT <> Nothing And obj.d_NgayDT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayDT", DbType.DateTime, obj.d_NgayDT)
            End If
            db.AddInParameter(objCmd, "@nv_GiatriDT_vn", DbType.String, obj.nv_GiatriDT_vn)
            db.AddInParameter(objCmd, "@nv_GiatriDT_en", DbType.String, obj.nv_GiatriDT_en)
            db.AddInParameter(objCmd, "@nv_Hinhanh", DbType.String, obj.nv_Hinhanh)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@f_Lephi_DT", DbType.Double, obj.f_Lephi_DT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByKH_Ngay(ByVal uId_Khachhang As String, ByVal d_Ngay As Date) As System.Data.DataTable Implements ITNTP_QT_DIEUTRI_HPDA.SelectByKH_Ngay
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_HP_SelectByKH_Ngay]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class