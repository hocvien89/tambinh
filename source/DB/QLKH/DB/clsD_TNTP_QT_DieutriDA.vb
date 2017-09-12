Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_QT_DieutriDA

    Implements ITNTP_QT_DieutriDA


    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Phieudichvu_Chitiet As String) As System.Collections.Generic.List(Of CM.TNTP_QT_DieutriEntity) Implements ITNTP_QT_DieutriDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_QT_DieutriEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, uId_Phieudichvu_Chitiet)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_QT_DieutriEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_QT_DieutriEntity)
                With lstobj(i)
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .uId_Phieudichvu_Chitiet = IIf(IsDBNull(objReader("uId_Phieudichvu_Chitiet")) = True, "", Convert.ToString(objReader("uId_Phieudichvu_Chitiet")))
                    .d_Ngaydieutri = IIf(IsDBNull(objReader("d_Ngaydieutri")) = True, Nothing, objReader("d_Ngaydieutri"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))

                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_QT_DieutriEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectAll]"
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
    Public Function SelectAllByIdDV(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.SelectAllByIdDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectIdDV]"
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
    Public Function SelectAllByIdDV(ByVal uId_Phieudichvu As String, ByVal d_Ngay As DateTime) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.SelectAllByDay
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectByDay]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Inphieu(ByVal uId_QT_Dieutri As String) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.Inphieu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Inphieu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectBySoPhieu(ByVal v_Sophieu As String) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.SelectBySoPhieu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectBySoPhieu]"
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

    Public Function SelectByID(ByVal uId_QT_Dieutri As String) As CM.TNTP_QT_DieutriEntity Implements ITNTP_QT_DieutriDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_QT_DieutriEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_QT_DieutriEntity
            If objReader.Read Then
                With obj
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .uId_Phieudichvu_Chitiet = IIf(IsDBNull(objReader("uId_Phieudichvu_Chitiet")) = True, "", Convert.ToString(objReader("uId_Phieudichvu_Chitiet")))
                    .d_Ngaydieutri = IIf(IsDBNull(objReader("d_Ngaydieutri")) = True, Nothing, objReader("d_Ngaydieutri"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .i_Lanthu = IIf(IsDBNull(objReader("i_Lanthu")) = True, 0, objReader("i_Lanthu"))
                    .nv_Hinhanh = IIf(IsDBNull(objReader("nv_Hinhanh")) = True, "", objReader("nv_Hinhanh"))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .f_Lephi_DT = IIf(IsDBNull(objReader("f_Lephi_DT")) = True, 0, objReader("f_Lephi_DT"))
                    .f_SuatDT = IIf(IsDBNull(objReader("f_SuatDT")) = True, 0, objReader("f_SuatDT"))
                    .b_yeucau = IIf(IsDBNull(objReader("b_yeucau")) = True, False, objReader("b_yeucau"))
                    .nv_Ghichu_cc_vn = IIf(IsDBNull(objReader("nv_Ghichu_cc_vn")) = True, 0, objReader("nv_Ghichu_cc_vn"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, 0, objReader("nv_Ghichu_vn"))
                    .f_HHNV3 = IIf(IsDBNull(objReader("f_HHNV3")) = True, 0, objReader("f_HHNV3"))
                    .f_HHNV4 = IIf(IsDBNull(objReader("f_HHNV4")) = True, 0, objReader("f_HHNV4"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_QT_DieutriEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_QT_DieutriEntity) As String Implements ITNTP_QT_DieutriDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Insert]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, obj.uId_Phieudichvu_Chitiet)
            If (obj.d_Ngaydieutri <> Nothing And obj.d_Ngaydieutri <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaydieutri", DbType.DateTime, obj.d_Ngaydieutri)
            End If
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.AddInParameter(objCmd, "@i_Lanthu", DbType.Int32, obj.i_Lanthu)
            db.AddInParameter(objCmd, "@nv_Hinhanh", DbType.String, obj.nv_Hinhanh)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@f_Lephi_DT", DbType.Double, obj.f_Lephi_DT)
            db.AddInParameter(objCmd, "@f_SuatDT", DbType.Double, obj.f_SuatDT)
            db.AddInParameter(objCmd, "@b_yeucau", DbType.Boolean, obj.b_yeucau)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.Double, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_cc_vn", DbType.Double, obj.nv_Ghichu_cc_vn)
            db.AddInParameter(objCmd, "@b_Tieuhao", DbType.Boolean, obj.b_Tieuhao)
            db.AddInParameter(objCmd, "@f_HHNV3", DbType.Double, obj.f_HHNV3)
            db.AddInParameter(objCmd, "@f_HHNV4", DbType.Double, obj.f_HHNV4)
            db.AddInParameter(objCmd, "@uId_Nhanvien3", DbType.String, obj.uId_Nhanvien3)
            db.AddInParameter(objCmd, "@uId_Nhanvien4", DbType.String, obj.uId_Nhanvien4)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_QT_Dieutri As String) As Boolean Implements ITNTP_QT_DieutriDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_QT_DieutriEntity) As Boolean Implements ITNTP_QT_DieutriDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Update]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, obj.uId_QT_Dieutri)
            If (obj.d_Ngaydieutri <> Nothing And obj.d_Ngaydieutri <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaydieutri", DbType.DateTime, obj.d_Ngaydieutri)
            End If
            db.AddInParameter(objCmd, "@uId_Phieudichvuchitiet", DbType.String, obj.uId_Phieudichvu_Chitiet)
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.AddInParameter(objCmd, "@i_Lanthu", DbType.Int32, obj.i_Lanthu)
            db.AddInParameter(objCmd, "@nv_Hinhanh", DbType.String, obj.nv_Hinhanh)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@f_Lephi_DT", DbType.Double, obj.f_Lephi_DT)
            db.AddInParameter(objCmd, "@f_SuatDT", DbType.Double, obj.f_SuatDT)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.Double, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_cc_vn", DbType.Double, obj.nv_Ghichu_cc_vn)
            db.AddInParameter(objCmd, "@b_yeucau", DbType.Boolean, obj.b_yeucau)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectVattuTieuhao(ByVal uId_QT_Dieutri As String) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.SelectVattuTieuhao
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_SelectVattuTieuhao]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectBCKHBoDieuTri(ByVal i_Songay As Integer, ByVal uId_Cuahang As String, ByVal NhomDV As String) As System.Data.DataTable Implements ITNTP_QT_DieutriDA.SelectBCKHBoDieuTri
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectBoDieutri]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Songay", DbType.Int32, i_Songay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@NhomDV", DbType.String, NhomDV)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Inphieulieutrinh(uId_QT_Dieutrinh As String) As Object Implements ITNTP_QT_DieutriDA.Inphieulieutrinh
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Inlieutrinh_ByIDDT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutrinh)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class