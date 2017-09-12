Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_PHIEUDICHVU_CHITIETDA
    Implements ITNTP_PHIEUDICHVU_CHITIETDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_PHIEUDICHVU_CHITIETEntity) Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_PHIEUDICHVU_CHITIETEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_PHIEUDICHVU_CHITIETEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_PHIEUDICHVU_CHITIETEntity)
                With lstobj(i)
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .f_Solan = IIf(IsDBNull(objReader("f_Solan")) = True, 0, objReader("f_Solan"))
                    .f_Soluong = IIf(IsDBNull(objReader("f_Soluong")) = True, 0, objReader("f_Soluong"))
                    .f_Dongia = IIf(IsDBNull(objReader("f_Dongia")) = True, 0, objReader("f_Dongia"))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_PHIEUDICHVU_CHITIETEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectAll]"
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


    Public Function SelectByID(ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID]"
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
    Public Function SelectBySoPhieu(ByVal v_Sophieu As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectBySoPhieu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectBySoPhieu]"
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
    Public Function SelectByIDChitiet(ByVal uId_Phieudichvu_Chitiet As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectByIDChitiet
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID_PDVCT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, uId_Phieudichvu_Chitiet)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByIDDichvu(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As CM.TNTP_PHIEUDICHVU_CHITIETEntity Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectByIDDichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByIDDichvu]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", System.Data.DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", System.Data.DbType.String, uId_Dichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
            If objReader.Read Then
                With obj
                    .uId_Phieudichvu_Chitiet = IIf(IsDBNull(objReader("uId_Phieudichvu_Chitiet")) = True, "", Convert.ToString(objReader("uId_Phieudichvu_Chitiet")))
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .f_Solan = IIf(IsDBNull(objReader("f_Solan")) = True, 0, objReader("f_Solan"))
                    .f_Soluong = IIf(IsDBNull(objReader("f_Soluong")) = True, 0, objReader("f_Soluong"))
                    .f_Dongia = IIf(IsDBNull(objReader("f_Dongia")) = True, 0, objReader("f_Dongia"))
                    .f_Giamgia = IIf(IsDBNull(objReader("f_Giamgia")) = True, 0, objReader("f_Giamgia"))
                    .f_Tongtien = IIf(IsDBNull(objReader("f_Tongtien")) = True, 0, objReader("f_Tongtien"))
                    .b_BaoHanh = IIf(IsDBNull(objReader("b_BaoHanh")) = True, False, objReader("b_BaoHanh"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            db.AddInParameter(objCmd, "@f_Solan", DbType.Double, obj.f_Solan)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Dongia", DbType.Double, obj.f_Dongia)
            db.AddInParameter(objCmd, "@f_Tongtien", DbType.Double, obj.f_Tongtien)
            db.AddInParameter(objCmd, "@f_Giamgia", DbType.Double, obj.f_Giamgia)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@b_BaoHanh", DbType.Boolean, obj.b_BaoHanh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieudichvu_Chitiet As String) As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, uId_Phieudichvu_Chitiet)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, obj.uId_Phieudichvu_Chitiet)
            db.AddInParameter(objCmd, "@f_Solan", DbType.Double, obj.f_Solan)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Dongia", DbType.Double, obj.f_Dongia)
            db.AddInParameter(objCmd, "@uId_CTKM", DbType.String, obj.uId_CTKM)
            db.AddInParameter(objCmd, "@f_Tongtien", DbType.Double, obj.f_Tongtien)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@b_BaoHanh", DbType.Boolean, obj.b_BaoHanh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Sub Update_Nhanvien_ById_Phieudichvu(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) Implements ITNTP_PHIEUDICHVU_CHITIETDA.Update_Nhanvien_ById_Phieudichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_UpdateId_Nhanvien]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Sub

    Public Function DeleteByIDPhieu(uId_Phieudichvu As String, uId_Dichvu As String) As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETDA.DeleteByIDPhieu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_DeleteByIDPhieu]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByID_PDV(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectByID_PDV

    End Function

    Public Function SelectByIDChitiet_NoTable(uId_Phieudichvu_Chitiet As String) As CM.TNTP_PHIEUDICHVU_CHITIETEntity Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectByIDChitiet_NoTable

    End Function

    Public Function SelectDVByIDKhachhang(uId_Khachhang As String) As DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectDVByIDKhachhang

    End Function

    Public Function SelectCkinCkoutByIDChitiet(uId_Phieudichvu_Chitiet As String) As DataSet Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectCkinCkoutByIDChitiet
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID_PDVCT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, uId_Phieudichvu_Chitiet)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SelectByID_PDV_DTS(uId_Phieudichvu As String) As DataSet Implements ITNTP_PHIEUDICHVU_CHITIETDA.SelectByID_PDV_DTS
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Select_Dichvu_Lieutrinh(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.Select_Dichvu_Lieutrinh
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_SelectByID_Lieutrinh]"
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

    Public Function Check_HuyDV(uId_Phieudichvu_Chitiet As String) As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETDA.Check_HuyDV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Check_Huydichvu_ById]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, uId_Phieudichvu_Chitiet)
            objDs = db.ExecuteDataSet(objCmd)
            Return Convert.ToBoolean(objDs.Tables(0)(0)(0))
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function CheckDV(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVU_CHITIETDA.CheckDV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CheckDVByIDPCT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu_Chitiet", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class