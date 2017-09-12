Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Public Class MKT_KHACHHANGPHANANH
    Implements IMKT_KHACHHANGPHANANH
    Public Function DeleteByID(ByVal uId_Phananh As String) As Boolean Implements IMKT_KHACHHANGPHANANH.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phananh", DbType.String, uId_Phananh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CM_CRM_PHANANHKHACHHANG) As Boolean Implements IMKT_KHACHHANGPHANANH.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, obj.uId_Phong)
            db.AddInParameter(objCmd, "@NoiDung", DbType.String, obj.NoiDung)
            db.AddInParameter(objCmd, "@HuongXuLy", DbType.String, obj.HuongXuLy)
            db.AddInParameter(objCmd, "@Status_phananh", DbType.String, obj.Status_phananh)
            db.AddInParameter(objCmd, "@Status_sauxuly", DbType.String, obj.Status_sauxuly)
            db.AddInParameter(objCmd, "@CreatedOn", DbType.String, obj.CreatedOn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SelectAllTable(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable Implements IMKT_KHACHHANGPHANANH.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectByMaKH(ByVal uId_Khachhang As String) As System.Data.DataTable Implements IMKT_KHACHHANGPHANANH.SelectByMaKH
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_SelectByMaKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhag", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectByMaPhongChuaXuLy(ByVal uId_Phong As String) As System.Data.DataTable Implements IMKT_KHACHHANGPHANANH.SelectByMaPhongChuaXuLy
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_SelectByMaPhongChuaXuLi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CM_CRM_PHANANHKHACHHANG) As Boolean Implements IMKT_KHACHHANGPHANANH.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phananh", DbType.String, obj.uId_Phananh)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, obj.uId_Phong)
            db.AddInParameter(objCmd, "@NoiDung", DbType.String, obj.NoiDung)
            db.AddInParameter(objCmd, "@HuongXuLy", DbType.String, obj.HuongXuLy)
            db.AddInParameter(objCmd, "@Status_phananh", DbType.String, obj.Status_phananh)
            db.AddInParameter(objCmd, "@Status_sauxuly", DbType.String, obj.Status_sauxuly)
            db.AddInParameter(objCmd, "@CreatedOn", DbType.String, obj.CreatedOn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Phananh As String) As CM.CM_CRM_PHANANHKHACHHANG Implements IMKT_KHACHHANGPHANANH.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CM_CRM_PHANANHKHACHHANG = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phananh", System.Data.DbType.String, uId_Phananh)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CM_CRM_PHANANHKHACHHANG
            If objReader.Read Then
                With obj
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, Nothing, Convert.ToString(objReader("uId_Khachhang")))
                    .NoiDung = IIf(IsDBNull(objReader("NoiDung")) = True, "", Convert.ToString(objReader("NoiDung")))
                    .Status_sauxuly = IIf(IsDBNull(objReader("Status_sauxuly")) = True, "", Convert.ToString(objReader("Status_sauxuly")))
                    .Status_phananh = IIf(IsDBNull(objReader("Status_phananh")) = True, "", Convert.ToString(objReader("Status_phananh")))
                    .HuongXuLy = IIf(IsDBNull(objReader("HuongXuLy")) = True, "", Convert.ToString(objReader("HuongXuLy")))
                    .CreatedOn = IIf(IsDBNull(objReader("CreatedOn")) = True, "", Convert.ToDateTime(objReader("CreatedOn")))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tenphong_vn = IIf(IsDBNull(objReader("nv_Tenphong_vn")) = True, "", objReader("nv_Tenphong_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            Return New CM.CM_CRM_PHANANHKHACHHANG
        End Try
    End Function

    Public Function SelectChoXyLy() As System.Data.DataTable Implements IMKT_KHACHHANGPHANANH.SelectChoXyLy
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_PHANANHKHACHHANG_SelectChoXuLy]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
End Class
