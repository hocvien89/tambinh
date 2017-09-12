Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_Nguoidung
    Implements iClisD_Nhanvien

    Private log As New LogError.ShowError

    Public Function SelectAll() As DataTable Implements iClisD_Nhanvien.SelectAll

        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            DT = db.ExecuteDataSet(objCmd).Tables(0)

        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try

        Return DT

    End Function

    Public Function SelectAll_Admin() As DataTable Implements iClisD_Nhanvien.SelectAll_Admin

        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectAll_Admin]"
        Dim objCmd As DbCommand
        Dim DT As DataTable = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            DT = db.ExecuteDataSet(objCmd).Tables(0)

        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try

        Return DT

    End Function

    Public Function SelectByID(ByVal uId_Nhanvien As String) As CM.cls_Nhanvien Implements iClisD_Nhanvien.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.cls_Nhanvien = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", System.Data.DbType.String, uId_Nhanvien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.cls_Nhanvien
            If objReader.Read Then
                With obj
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Barcode = IIf(IsDBNull(objReader("v_Barcode")) = True, "", objReader("v_Barcode"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Hoten_en = IIf(IsDBNull(objReader("nv_Hoten_en")) = True, "", objReader("nv_Hoten_en"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, "", objReader("d_Ngaysinh"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                    .nv_Chucvu_en = IIf(IsDBNull(objReader("nv_Chucvu_en")) = True, "", objReader("nv_Chucvu_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Quequan_vn = IIf(IsDBNull(objReader("nv_Quequan_vn")) = True, "", objReader("nv_Quequan_vn"))
                    .nv_Quequan_en = IIf(IsDBNull(objReader("nv_Quequan_en")) = True, "", objReader("nv_Quequan_en"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .v_Tendangnhap = IIf(IsDBNull(objReader("v_Tendangnhap")) = True, "", objReader("v_Tendangnhap"))
                    .v_Matkhau = IIf(IsDBNull(objReader("v_Matkhau")) = True, "", objReader("v_Matkhau"))
                    .b_ActiveLogin = IIf(IsDBNull(objReader("b_ActiveLogin")) = True, "", objReader("b_ActiveLogin"))
                    .d_Ngayvaolam = IIf(IsDBNull(objReader("d_Ngayvaolam")) = True, "", objReader("d_Ngayvaolam"))
                    .b_Danglamviec = IIf(IsDBNull(objReader("b_Danglamviec")) = True, "", objReader("b_Danglamviec"))
                End With
            End If
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
        End Try
        Return obj
    End Function

    Public Function Insert(ByVal obj As CM.cls_Nhanvien) As Boolean Implements iClisD_Nhanvien.Insert
        Dim db As Database
        Dim sp As String = "spQT_DM_NHANVIEN_Insert"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Barcode", DbType.String, obj.v_Barcode)
            db.AddInParameter(objCmd, "@v_Manhanvien", DbType.String, obj.v_Manhanvien)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            db.AddInParameter(objCmd, "@nv_Chucvu_vn", DbType.String, obj.nv_Chucvu_vn)
            db.AddInParameter(objCmd, "@nv_Chucvu_en", DbType.String, obj.nv_Chucvu_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@nv_Quequan_vn", DbType.String, obj.nv_Quequan_vn)
            db.AddInParameter(objCmd, "@nv_Quequan_en", DbType.String, obj.nv_Quequan_en)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, obj.v_Tendangnhap)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.AddInParameter(objCmd, "@b_ActiveLogin", DbType.String, obj.b_ActiveLogin)
            db.AddInParameter(objCmd, "@d_Ngayvaolam", DbType.DateTime, obj.d_Ngayvaolam)
            db.AddInParameter(objCmd, "@b_Danglamviec", DbType.String, obj.b_Danglamviec)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Nhanvien As String) As Boolean Implements iClisD_Nhanvien.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_NHANVIEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.cls_Nhanvien) As Boolean Implements iClisD_Nhanvien.Update
        Dim db As Database
        Dim sp As String = "spQT_DM_NHANVIEN_Update"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Barcode", DbType.String, obj.v_Barcode)
            db.AddInParameter(objCmd, "@v_Manhanvien", DbType.String, obj.v_Manhanvien)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Hoten_en", DbType.String, obj.nv_Hoten_en)
            db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            db.AddInParameter(objCmd, "@nv_Chucvu_vn", DbType.String, obj.nv_Chucvu_vn)
            db.AddInParameter(objCmd, "@nv_Chucvu_en", DbType.String, obj.nv_Chucvu_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@nv_Quequan_vn", DbType.String, obj.nv_Quequan_vn)
            db.AddInParameter(objCmd, "@nv_Quequan_en", DbType.String, obj.nv_Quequan_en)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, obj.v_Tendangnhap)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.AddInParameter(objCmd, "@b_ActiveLogin", DbType.String, obj.b_ActiveLogin)
            db.AddInParameter(objCmd, "@d_Ngayvaolam", DbType.DateTime, obj.d_Ngayvaolam)
            db.AddInParameter(objCmd, "@b_Danglamviec", DbType.String, obj.b_Danglamviec)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

 
End Class

