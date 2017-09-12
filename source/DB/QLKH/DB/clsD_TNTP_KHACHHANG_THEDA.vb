Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_KHACHHANG_THEDA

    Implements ITNTP_KHACHHANG_THEDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_THEEntity) Implements ITNTP_KHACHHANG_THEDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_KHACHHANG_THEEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_KHACHHANG_THEEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_KHACHHANG_THEEntity)
                With lstobj(i)
                    .uId_The = IIf(IsDBNull(objReader("uId_The")) = True, "", Convert.ToString(objReader("uId_The")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Loaithe = IIf(IsDBNull(objReader("uId_Loaithe")) = True, "", Convert.ToString(objReader("uId_Loaithe")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Mathe = IIf(IsDBNull(objReader("v_Mathe")) = True, "", objReader("v_Mathe"))
                    .d_Ngaymua = IIf(IsDBNull(objReader("d_Ngaymua")) = True, Nothing, objReader("d_Ngaymua"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .d_Ngaybatdau = IIf(IsDBNull(objReader("d_Ngaybatdau")) = True, Nothing, objReader("d_Ngaybatdau"))
                    .d_Ngaykethuc = IIf(IsDBNull(objReader("d_Ngaykethuc")) = True, Nothing, objReader("d_Ngaykethuc"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Tenloaithe_vn = IIf(IsDBNull(objReader("nv_Tenloaithe_vn")) = True, "", objReader("nv_Tenloaithe_vn"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_KHACHHANG_THEEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String, ByVal DK As Int32) As System.Data.DataTable Implements ITNTP_KHACHHANG_THEDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DK", DbType.Int32, DK)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllKH_KM(ByVal uId_Khachhang As String, ByVal v_MaKM As String) As System.Data.DataTable Implements ITNTP_KHACHHANG_THEDA.SelectAllKH_KM
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectKMMember]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@v_MaKM", DbType.String, v_MaKM)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectTheKHTichluy(ByVal uId_Khachhang As String, ByVal v_MaKM As String) As System.Data.DataTable Implements ITNTP_KHACHHANG_THEDA.SelectTheKHTichluy
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectTichluy]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@v_MaKM", DbType.String, v_MaKM)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements ITNTP_KHACHHANG_THEDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "Select * from TNTP_KHACHHANG_THE where uId_Cuahang = CASE '" + uId_Cuahang + "' when '' then uId_Cuahang else '" + uId_Cuahang + "' END"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetSqlStringCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_The As String) As CM.TNTP_KHACHHANG_THEEntity Implements ITNTP_KHACHHANG_THEDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_KHACHHANG_THEEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", DbType.String, uId_The)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_KHACHHANG_THEEntity
            If objReader.Read Then
                With obj
                    .uId_The = IIf(IsDBNull(objReader("uId_The")) = True, "", Convert.ToString(objReader("uId_The")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Loaithe = IIf(IsDBNull(objReader("uId_Loaithe")) = True, "", Convert.ToString(objReader("uId_Loaithe")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Mathe = IIf(IsDBNull(objReader("v_Mathe")) = True, "", objReader("v_Mathe"))
                    .d_Ngaymua = IIf(IsDBNull(objReader("d_Ngaymua")) = True, Nothing, objReader("d_Ngaymua"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .d_Ngaybatdau = IIf(IsDBNull(objReader("d_Ngaybatdau")) = True, Nothing, objReader("d_Ngaybatdau"))
                    .d_Ngaykethuc = IIf(IsDBNull(objReader("d_Ngaykethuc")) = True, Nothing, objReader("d_Ngaykethuc"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_KHACHHANG_THEEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As String Implements ITNTP_KHACHHANG_THEDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String, obj.uId_Loaithe)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Mathe", DbType.String, obj.v_Mathe)
            If (obj.d_Ngaymua <> Nothing And obj.d_Ngaymua <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaymua", DbType.DateTime, obj.d_Ngaymua)
            End If
            'db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            If (obj.d_Ngaybatdau <> Nothing And obj.d_Ngaybatdau <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.DateTime, obj.d_Ngaybatdau)
            End If
            If (obj.d_Ngaykethuc <> Nothing And obj.d_Ngaykethuc <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaykethuc", DbType.DateTime, obj.d_Ngaykethuc)
            End If
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)

            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_The As String) As Boolean Implements ITNTP_KHACHHANG_THEDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", DbType.String, uId_The)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As Boolean Implements ITNTP_KHACHHANG_THEDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", DbType.String, obj.uId_The)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Loaithe", DbType.String, obj.uId_Loaithe)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            'db.AddInParameter(objCmd, "@v_Mathe", DbType.String, obj.v_Mathe)
            If (obj.d_Ngaymua <> Nothing And obj.d_Ngaymua <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaymua", DbType.DateTime, obj.d_Ngaymua)
            End If
            'db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            If (obj.d_Ngaybatdau <> Nothing And obj.d_Ngaybatdau <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.DateTime, obj.d_Ngaybatdau)
            End If
            If (obj.d_Ngaykethuc <> Nothing And obj.d_Ngaykethuc <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaykethuc", DbType.DateTime, obj.d_Ngaykethuc)
            End If
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function ThanhToan(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As Boolean Implements ITNTP_KHACHHANG_THEDA.ThanhToan
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_Thanhtoan]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_The", DbType.String, obj.uId_The)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable_DS_TheHetHan(ByVal DK As Integer) As System.Data.DataTable Implements ITNTP_KHACHHANG_THEDA.SelectAllTable_DS_TheHetHan
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_KHACHHANG_THE_SelectAll_TheHetHan]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DK", DbType.Int32, DK)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class