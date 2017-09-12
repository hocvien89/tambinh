Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_KH_TIEMNANGDA

    Implements IMKT_KH_TIEMNANGDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_KH_TIEMNANGEntity) Implements IMKT_KH_TIEMNANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_KH_TIEMNANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_KH_TIEMNANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_KH_TIEMNANGEntity)
                With lstobj(i)
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachhang = IIf(IsDBNull(objReader("v_Makhachhang")) = True, "", objReader("v_Makhachhang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_KH_TIEMNANGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IMKT_KH_TIEMNANGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_KH_Tiemnang As String) As CM.MKT_KH_TIEMNANGEntity Implements IMKT_KH_TIEMNANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_KH_TIEMNANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", System.Data.DbType.String, uId_KH_Tiemnang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_KH_TIEMNANGEntity
            If objReader.Read Then
                With obj
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Makhachhang = IIf(IsDBNull(objReader("v_Makhachhang")) = True, "", objReader("v_Makhachhang"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .b_Gioitinh = IIf(IsDBNull(objReader("b_Gioitinh")) = True, False, objReader("b_Gioitinh"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .v_DienthoaiDD = IIf(IsDBNull(objReader("v_DienthoaiDD")) = True, "", objReader("v_DienthoaiDD"))
                    .v_Dienthoaikhac = IIf(IsDBNull(objReader("v_Dienthoaikhac")) = True, "", objReader("v_Dienthoaikhac"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .d_Ngaynhap = IIf(IsDBNull(objReader("d_Ngaynhap")) = True, Nothing, objReader("d_Ngaynhap"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_KH_TIEMNANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean Implements IMKT_KH_TIEMNANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Makhachhang", DbType.String, obj.v_Makhachhang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Boolean, obj.b_Gioitinh)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Dienthoaikhac", DbType.String, obj.v_Dienthoaikhac)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            If (obj.d_Ngaynhap <> Nothing And obj.d_Ngaynhap <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaynhap", DbType.DateTime, obj.d_Ngaynhap)
            End If
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_KH_Tiemnang As String) As Boolean Implements IMKT_KH_TIEMNANGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean Implements IMKT_KH_TIEMNANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_TIEMNANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_Makhachhang", DbType.String, obj.v_Makhachhang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Boolean, obj.b_Gioitinh)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@v_DienthoaiDD", DbType.String, obj.v_DienthoaiDD)
            db.AddInParameter(objCmd, "@v_Dienthoaikhac", DbType.String, obj.v_Dienthoaikhac)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            If (obj.d_Ngaynhap <> Nothing And obj.d_Ngaynhap <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaynhap", DbType.DateTime, obj.d_Ngaynhap)
            End If
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class