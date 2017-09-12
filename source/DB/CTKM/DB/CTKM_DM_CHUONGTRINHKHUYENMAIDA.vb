Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CTKM_DM_CHUONGTRINHKHUYENMAIDA

    Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity)
                With lstobj(i)
                    .uId_ChuongtrinhKhuyenmai = IIf(IsDBNull(objReader("uId_ChuongtrinhKhuyenmai")) = True, "", Convert.ToString(objReader("uId_ChuongtrinhKhuyenmai")))
                    .nv_TenChuongtrinhKM_vn = IIf(IsDBNull(objReader("nv_TenChuongtrinhKM_vn")) = True, "", objReader("nv_TenChuongtrinhKM_vn"))
                    .nv_TenChuongtrinhKM_en = IIf(IsDBNull(objReader("nv_TenChuongtrinhKM_en")) = True, "", objReader("nv_TenChuongtrinhKM_en"))
                    .nv_Mota_vn = IIf(IsDBNull(objReader("nv_Mota_vn")) = True, "", objReader("nv_Mota_vn"))
                    .nv_Mota_en = IIf(IsDBNull(objReader("nv_Mota_en")) = True, "", objReader("nv_Mota_en"))
                    .d_ngaybatdau = IIf(IsDBNull(objReader("d_ngaybatdau")) = True, Nothing, objReader("d_ngaybatdau"))
                    .d_ngayketthuc = IIf(IsDBNull(objReader("d_ngayketthuc")) = True, Nothing, objReader("d_ngayketthuc"))
                    .b_Hoatdong = IIf(IsDBNull(objReader("b_Hoatdong")) = True, False, objReader("b_Hoatdong"))
                    .uId_LoaiGiamgia = IIf(IsDBNull(objReader("uId_LoaiGiamgia")) = True, "", Convert.ToString(objReader("uId_LoaiGiamgia")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_SelectAll]"
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
    Public Function Timkiem(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As System.Data.DataTable Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.Timkiem
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_Timkiem]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenChuongtrinhKM_vn", System.Data.DbType.String, obj.nv_TenChuongtrinhKM_vn)
            db.AddInParameter(objCmd, "@nv_Mota_vn", System.Data.DbType.String, obj.nv_Mota_vn)
            db.AddInParameter(objCmd, "@d_ngaybatdau", System.Data.DbType.DateTime, obj.d_ngaybatdau)
            db.AddInParameter(objCmd, "@d_ngayketthuc", System.Data.DbType.DateTime, obj.d_ngayketthuc)
            db.AddInParameter(objCmd, "@uId_Cuahang", System.Data.DbType.String, obj.uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByID(ByVal uId_ChuongtrinhKhuyenmai As String) As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", System.Data.DbType.String, uId_ChuongtrinhKhuyenmai)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity
            If objReader.Read Then
                With obj
                    .uId_ChuongtrinhKhuyenmai = IIf(IsDBNull(objReader("uId_ChuongtrinhKhuyenmai")) = True, "", Convert.ToString(objReader("uId_ChuongtrinhKhuyenmai")))
                    .nv_TenChuongtrinhKM_vn = IIf(IsDBNull(objReader("nv_TenChuongtrinhKM_vn")) = True, "", objReader("nv_TenChuongtrinhKM_vn"))
                    .nv_TenChuongtrinhKM_en = IIf(IsDBNull(objReader("nv_TenChuongtrinhKM_en")) = True, "", objReader("nv_TenChuongtrinhKM_en"))
                    .nv_Mota_vn = IIf(IsDBNull(objReader("nv_Mota_vn")) = True, "", objReader("nv_Mota_vn"))
                    .nv_Mota_en = IIf(IsDBNull(objReader("nv_Mota_en")) = True, "", objReader("nv_Mota_en"))
                    .d_ngaybatdau = IIf(IsDBNull(objReader("d_ngaybatdau")) = True, Nothing, objReader("d_ngaybatdau"))
                    .d_ngayketthuc = IIf(IsDBNull(objReader("d_ngayketthuc")) = True, Nothing, objReader("d_ngayketthuc"))
                    .b_Hoatdong = IIf(IsDBNull(objReader("b_Hoatdong")) = True, False, objReader("b_Hoatdong"))
                    .uId_LoaiGiamgia = IIf(IsDBNull(objReader("uId_LoaiGiamgia")) = True, "", Convert.ToString(objReader("uId_LoaiGiamgia")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenChuongtrinhKM_vn", DbType.String, obj.nv_TenChuongtrinhKM_vn)
            db.AddInParameter(objCmd, "@nv_TenChuongtrinhKM_en", DbType.String, obj.nv_TenChuongtrinhKM_en)
            db.AddInParameter(objCmd, "@nv_Mota_vn", DbType.String, obj.nv_Mota_vn)
            db.AddInParameter(objCmd, "@nv_Mota_en", DbType.String, obj.nv_Mota_en)
            If (obj.d_ngaybatdau <> Nothing And obj.d_ngaybatdau <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_ngaybatdau", DbType.DateTime, obj.d_ngaybatdau)
            End If
            If (obj.d_ngayketthuc <> Nothing And obj.d_ngayketthuc <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_ngayketthuc", DbType.DateTime, obj.d_ngayketthuc)
            End If
            db.AddInParameter(objCmd, "@b_Hoatdong", DbType.Boolean, obj.b_Hoatdong)
            db.AddInParameter(objCmd, "@uId_Cuahang", System.Data.DbType.String, obj.uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_ChuongtrinhKhuyenmai As String) As Boolean Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", DbType.String, uId_ChuongtrinhKhuyenmai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As Boolean Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_CHUONGTRINHKHUYENMAI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", DbType.String, obj.uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@nv_TenChuongtrinhKM_vn", DbType.String, obj.nv_TenChuongtrinhKM_vn)
            db.AddInParameter(objCmd, "@nv_TenChuongtrinhKM_en", DbType.String, obj.nv_TenChuongtrinhKM_en)
            db.AddInParameter(objCmd, "@nv_Mota_vn", DbType.String, obj.nv_Mota_vn)
            db.AddInParameter(objCmd, "@nv_Mota_en", DbType.String, obj.nv_Mota_en)
            If (obj.d_ngaybatdau <> Nothing And obj.d_ngaybatdau <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_ngaybatdau", DbType.DateTime, obj.d_ngaybatdau)
            End If
            If (obj.d_ngayketthuc <> Nothing And obj.d_ngayketthuc <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_ngayketthuc", DbType.DateTime, obj.d_ngayketthuc)
            End If
            db.AddInParameter(objCmd, "@b_Hoatdong", DbType.Boolean, obj.b_Hoatdong)
            db.AddInParameter(objCmd, "@uId_LoaiGiamgia", DbType.String, obj.uId_LoaiGiamgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Baocao(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal b_Loai As String) As System.Data.DataTable Implements ICTKM_DM_CHUONGTRINHKHUYENMAIDA.Baocao
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_CHUONGTRINHKHUYENMAI]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", System.Data.DbType.String, uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@d_ngaybatdau", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@d_ngayketthuc", System.Data.DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@b_loai", System.Data.DbType.String, b_Loai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class