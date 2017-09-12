Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLL_QUATRINHLUONGDA

	Implements IQLL_QUATRINHLUONGDA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Nhanvien As String) As System.Collections.Generic.List(Of CM.QLL_QUATRINHLUONGEntity) Implements IQLL_QUATRINHLUONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_QUATRINHLUONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLL_QUATRINHLUONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLL_QUATRINHLUONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLL_QUATRINHLUONGEntity)
                With lstobj(i)
                    .uId_QuatrinhLuong = IIf(IsDBNull(objReader("uId_QuatrinhLuong")) = True, "", Convert.ToString(objReader("uId_QuatrinhLuong")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .d_Ngayquyetdinh = IIf(IsDBNull(objReader("d_Ngayquyetdinh")) = True, Nothing, objReader("d_Ngayquyetdinh"))
                    .f_Mucluong_Ngay = IIf(IsDBNull(objReader("f_Mucluong_Ngay")) = True, 0, objReader("f_Mucluong_Ngay"))
                    .f_Mucluong_Codinh = IIf(IsDBNull(objReader("f_Mucluong_Codinh")) = True, 0, objReader("f_Mucluong_Codinh"))
                    .f_Mucluong_Ngoaigio = IIf(IsDBNull(objReader("f_Mucluong_Ngoaigio")) = True, 0, objReader("f_Mucluong_Ngoaigio"))
                    .f_Mucluong_Trachnhiem = IIf(IsDBNull(objReader("f_Mucluong_Trachnhiem")) = True, 0, objReader("f_Mucluong_Trachnhiem"))
                    .f_ThueTNCN = IIf(IsDBNull(objReader("f_ThueTNCN")) = True, 0, objReader("f_ThueTNCN"))
                    .f_Antrua = IIf(IsDBNull(objReader("f_Antrua")) = True, 0, objReader("f_Antrua"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .f_Songayphep = IIf(IsDBNull(objReader("f_Songayphep")) = True, 0, objReader("f_Songayphep"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLL_QUATRINHLUONGEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Nhanvien AS String) AS System.Data.DataTable Implements IQLL_QUATRINHLUONGDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLL_QUATRINHLUONG_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet 
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String,uId_Nhanvien)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function


    Public Function SelectByID(ByVal uId_QuatrinhLuong As String) As CM.QLL_QUATRINHLUONGEntity Implements IQLL_QUATRINHLUONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_QUATRINHLUONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLL_QUATRINHLUONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QuatrinhLuong", DbType.String, uId_QuatrinhLuong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLL_QUATRINHLUONGEntity
            If objReader.Read Then
                With obj
                    .uId_QuatrinhLuong = IIf(IsDBNull(objReader("uId_QuatrinhLuong")) = True, "", Convert.ToString(objReader("uId_QuatrinhLuong")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .d_Ngayquyetdinh = IIf(IsDBNull(objReader("d_Ngayquyetdinh")) = True, Nothing, objReader("d_Ngayquyetdinh"))
                    .f_Mucluong_Ngay = IIf(IsDBNull(objReader("f_Mucluong_Ngay")) = True, 0, objReader("f_Mucluong_Ngay"))
                    .f_Mucluong_Codinh = IIf(IsDBNull(objReader("f_Mucluong_Codinh")) = True, 0, objReader("f_Mucluong_Codinh"))
                    .f_Mucluong_Ngoaigio = IIf(IsDBNull(objReader("f_Mucluong_Ngoaigio")) = True, 0, objReader("f_Mucluong_Ngoaigio"))
                    .f_Mucluong_Trachnhiem = IIf(IsDBNull(objReader("f_Mucluong_Trachnhiem")) = True, 0, objReader("f_Mucluong_Trachnhiem"))
                    .f_ThueTNCN = IIf(IsDBNull(objReader("f_ThueTNCN")) = True, 0, objReader("f_ThueTNCN"))
                    .f_Antrua = IIf(IsDBNull(objReader("f_Antrua")) = True, 0, objReader("f_Antrua"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    .f_Songayphep = IIf(IsDBNull(objReader("f_Songayphep")) = True, 0, objReader("f_Songayphep"))
                   
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLL_QUATRINHLUONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLL_QUATRINHLUONGEntity) As Boolean Implements IQLL_QUATRINHLUONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_QUATRINHLUONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            If (obj.d_Ngayquyetdinh <> Nothing And obj.d_Ngayquyetdinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayquyetdinh", DbType.DateTime, obj.d_Ngayquyetdinh)
            End If
            db.AddInParameter(objCmd, "@f_Mucluong_Ngay", DbType.Double, obj.f_Mucluong_Ngay)
            db.AddInParameter(objCmd, "@f_Mucluong_Codinh", DbType.Double, obj.f_Mucluong_Codinh)
            db.AddInParameter(objCmd, "@f_Mucluong_Ngoaigio", DbType.Double, obj.f_Mucluong_Ngoaigio)
            db.AddInParameter(objCmd, "@f_Mucluong_Trachnhiem", DbType.Double, obj.f_Mucluong_Trachnhiem)
            db.AddInParameter(objCmd, "@f_ThueTNCN", DbType.Double, obj.f_ThueTNCN)
            db.AddInParameter(objCmd, "@f_Antrua", DbType.Double, obj.f_Antrua)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@f_Songayphep", DbType.Double, obj.f_Songayphep)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_QuatrinhLuong AS String) As Boolean Implements IQLL_QUATRINHLUONGDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLL_QUATRINHLUONG_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_QuatrinhLuong", DbType.String,uId_QuatrinhLuong)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLL_QUATRINHLUONGEntity) As Boolean Implements IQLL_QUATRINHLUONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_QUATRINHLUONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QuatrinhLuong", DbType.String, obj.uId_QuatrinhLuong)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            If (obj.d_Ngayquyetdinh <> Nothing And obj.d_Ngayquyetdinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngayquyetdinh", DbType.DateTime, obj.d_Ngayquyetdinh)
            End If
            db.AddInParameter(objCmd, "@f_Mucluong_Ngay", DbType.Double, obj.f_Mucluong_Ngay)
            db.AddInParameter(objCmd, "@f_Mucluong_Codinh", DbType.Double, obj.f_Mucluong_Codinh)
            db.AddInParameter(objCmd, "@f_Mucluong_Ngoaigio", DbType.Double, obj.f_Mucluong_Ngoaigio)
            db.AddInParameter(objCmd, "@f_Mucluong_Trachnhiem", DbType.Double, obj.f_Mucluong_Trachnhiem)
            db.AddInParameter(objCmd, "@f_ThueTNCN", DbType.Double, obj.f_ThueTNCN)
            db.AddInParameter(objCmd, "@f_Antrua", DbType.Double, obj.f_Antrua)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.AddInParameter(objCmd, "@f_Songayphep", DbType.Double, obj.f_Songayphep)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class