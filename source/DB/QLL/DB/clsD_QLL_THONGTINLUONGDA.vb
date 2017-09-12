Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLL_THONGTINLUONGDA

    Implements IQLL_THONGTINLUONGDA

    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal i_Thang As Int32, ByVal i_Nam As Int32) As System.Collections.Generic.List(Of CM.QLL_THONGTINLUONGEntity) Implements IQLL_THONGTINLUONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLL_THONGTINLUONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Thang", DbType.Int32, i_Thang)
            db.AddInParameter(objCmd, "@i_Nam", DbType.Int32, i_Nam)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLL_THONGTINLUONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLL_THONGTINLUONGEntity)
                With lstobj(i)
                    .uId_Thongtinluong = IIf(IsDBNull(objReader("uId_Thongtinluong")) = True, "", Convert.ToString(objReader("uId_Thongtinluong")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .i_Thang = IIf(IsDBNull(objReader("i_Thang")) = True, 0, objReader("i_Thang"))
                    .i_Nam = IIf(IsDBNull(objReader("i_Nam")) = True, 0, objReader("i_Nam"))
                    .f_Ngaycong = IIf(IsDBNull(objReader("f_Ngaycong")) = True, 0, objReader("f_Ngaycong"))
                    .f_Ngaynghi = IIf(IsDBNull(objReader("f_Ngaynghi")) = True, 0, objReader("f_Ngaynghi"))
                    .f_Tamung = IIf(IsDBNull(objReader("f_Tamung")) = True, 0, objReader("f_Tamung"))
                    .f_Tientru = IIf(IsDBNull(objReader("f_Tientru")) = True, 0, objReader("f_Tientru"))
                    .f_Tienthuong = IIf(IsDBNull(objReader("f_Tienthuong")) = True, 0, objReader("f_Tienthuong"))
                    .b_Khoaso = IIf(IsDBNull(objReader("b_Khoaso")) = True, False, objReader("b_Khoaso"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLL_THONGTINLUONGEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal i_Thang As Int32, ByVal i_Nam As Int32, uId_Cuahang As String) As System.Data.DataTable Implements IQLL_THONGTINLUONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Thang", DbType.Int32, i_Thang)
            db.AddInParameter(objCmd, "@i_Nam", DbType.Int32, i_Nam)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Thongtinluong As String) As CM.QLL_THONGTINLUONGEntity Implements IQLL_THONGTINLUONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLL_THONGTINLUONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thongtinluong", DbType.String, uId_Thongtinluong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLL_THONGTINLUONGEntity
            If objReader.Read Then
                With obj
                    .uId_Thongtinluong = IIf(IsDBNull(objReader("uId_Thongtinluong")) = True, "", Convert.ToString(objReader("uId_Thongtinluong")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .i_Thang = IIf(IsDBNull(objReader("i_Thang")) = True, 0, objReader("i_Thang"))
                    .i_Nam = IIf(IsDBNull(objReader("i_Nam")) = True, 0, objReader("i_Nam"))
                    .f_Ngaycong = IIf(IsDBNull(objReader("f_Ngaycong")) = True, 0, objReader("f_Ngaycong"))
                    .f_Ngaynghi = IIf(IsDBNull(objReader("f_Ngaynghi")) = True, 0, objReader("f_Ngaynghi"))
                    .f_Tamung = IIf(IsDBNull(objReader("f_Tamung")) = True, 0, objReader("f_Tamung"))
                    .f_Tientru = IIf(IsDBNull(objReader("f_Tientru")) = True, 0, objReader("f_Tientru"))
                    .f_Tienthuong = IIf(IsDBNull(objReader("f_Tienthuong")) = True, 0, objReader("f_Tienthuong"))
                    .b_Khoaso = IIf(IsDBNull(objReader("b_Khoaso")) = True, False, objReader("b_Khoaso"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLL_THONGTINLUONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLL_THONGTINLUONGEntity) As Boolean Implements IQLL_THONGTINLUONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@i_Thang", DbType.Int32, obj.i_Thang)
            db.AddInParameter(objCmd, "@i_Nam", DbType.Int32, obj.i_Nam)
            db.AddInParameter(objCmd, "@f_Ngaycong", DbType.Double, obj.f_Ngaycong)
            db.AddInParameter(objCmd, "@f_Ngaynghi", DbType.Double, obj.f_Ngaynghi)
            db.AddInParameter(objCmd, "@f_Tamung", DbType.Double, obj.f_Tamung)
            db.AddInParameter(objCmd, "@f_Tientru", DbType.Double, obj.f_Tientru)
            db.AddInParameter(objCmd, "@f_Tienthuong", DbType.Double, obj.f_Tienthuong)
            db.AddInParameter(objCmd, "@b_Khoaso", DbType.Boolean, obj.b_Khoaso)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Thongtinluong As String) As Boolean Implements IQLL_THONGTINLUONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thongtinluong", DbType.String, uId_Thongtinluong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLL_THONGTINLUONGEntity) As Boolean Implements IQLL_THONGTINLUONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thongtinluong", DbType.String, obj.uId_Thongtinluong)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@i_Thang", DbType.Int32, obj.i_Thang)
            db.AddInParameter(objCmd, "@i_Nam", DbType.Int32, obj.i_Nam)
            db.AddInParameter(objCmd, "@f_Ngaycong", DbType.Double, obj.f_Ngaycong)
            db.AddInParameter(objCmd, "@f_Ngaynghi", DbType.Double, obj.f_Ngaynghi)
            db.AddInParameter(objCmd, "@f_Tamung", DbType.Double, obj.f_Tamung)
            db.AddInParameter(objCmd, "@f_Tientru", DbType.Double, obj.f_Tientru)
            db.AddInParameter(objCmd, "@f_Tienthuong", DbType.Double, obj.f_Tienthuong)
            db.AddInParameter(objCmd, "@b_Khoaso", DbType.Boolean, obj.b_Khoaso)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectInfobyNV(i_thang As Integer, i_nam As Integer, uId_Nhanvien As String) As CM.QLL_THONGTINLUONGEntity Implements IQLL_THONGTINLUONGDA.SelectInfobyNV
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_SelectTTLuong_ByNhanvien]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLL_THONGTINLUONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Thang", DbType.String, i_thang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@i_Nam", DbType.Int32, i_nam)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLL_THONGTINLUONGEntity
            If objReader.Read Then
                With obj
                    .uId_Thongtinluong = IIf(IsDBNull(objReader("uId_Thongtinluong")) = True, "", Convert.ToString(objReader("uId_Thongtinluong")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .i_Thang = IIf(IsDBNull(objReader("i_Thang")) = True, 0, objReader("i_Thang"))
                    .i_Nam = IIf(IsDBNull(objReader("i_Nam")) = True, 0, objReader("i_Nam"))
                    .f_Ngaycong = IIf(IsDBNull(objReader("f_Ngaycong")) = True, 0, objReader("f_Ngaycong"))
                    .f_Ngaynghi = IIf(IsDBNull(objReader("f_Ngaynghi")) = True, 0, objReader("f_Ngaynghi"))
                    .f_Tamung = IIf(IsDBNull(objReader("f_Tamung")) = True, 0, objReader("f_Tamung"))
                    .f_Tientru = IIf(IsDBNull(objReader("f_Tientru")) = True, 0, objReader("f_Tientru"))
                    .f_Tienthuong = IIf(IsDBNull(objReader("f_Tienthuong")) = True, 0, objReader("f_Tienthuong"))
                    .b_Khoaso = IIf(IsDBNull(objReader("b_Khoaso")) = True, False, objReader("b_Khoaso"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                End With
            End If
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return obj
    End Function
End Class