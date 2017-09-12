Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_KHUYENMAIDA

    Implements ITNTP_DM_KHUYENMAIDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_KHUYENMAIEntity) Implements ITNTP_DM_KHUYENMAIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_KHUYENMAI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_KHUYENMAIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_KHUYENMAIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_KHUYENMAIEntity)
                With lstobj(i)
                    .uId_DM_Khuyenmai = IIf(IsDBNull(objReader("uId_DM_Khuyenmai")) = True, "", Convert.ToString(objReader("uId_DM_Khuyenmai")))
                    .v_MaKhuyenMai = IIf(IsDBNull(objReader("v_MaKhuyenMai")) = True, "", objReader("v_MaKhuyenMai"))
                    .nv_TenKhuyenMai = IIf(IsDBNull(objReader("nv_TenKhuyenMai")) = True, "", objReader("nv_TenKhuyenMai"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_KHUYENMAIEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ITNTP_DM_KHUYENMAIDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_KHUYENMAI_SelectAll]"
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




    Public Function SelectByID(ByVal uId_DM_Khuyenmai As String) As CM.TNTP_DM_KHUYENMAIEntity Implements ITNTP_DM_KHUYENMAIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_KHUYENMAI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_KHUYENMAIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", System.Data.DbType.String, uId_DM_Khuyenmai)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_KHUYENMAIEntity
            If objReader.Read Then
                With obj
                    .uId_DM_Khuyenmai = IIf(IsDBNull(objReader("uId_DM_Khuyenmai")) = True, "", Convert.ToString(objReader("uId_DM_Khuyenmai")))
                    .v_MaKhuyenMai = IIf(IsDBNull(objReader("v_MaKhuyenMai")) = True, "", objReader("v_MaKhuyenMai"))
                    .nv_TenKhuyenMai = IIf(IsDBNull(objReader("nv_TenKhuyenMai")) = True, "", objReader("nv_TenKhuyenMai"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_KHUYENMAIEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_KHUYENMAIEntity) As Boolean Implements ITNTP_DM_KHUYENMAIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_KHUYENMAI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaKhuyenMai", DbType.String, obj.v_MaKhuyenMai)
            db.AddInParameter(objCmd, "@nv_TenKhuyenMai", DbType.String, obj.nv_TenKhuyenMai)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_DM_Khuyenmai As String) As Boolean Implements ITNTP_DM_KHUYENMAIDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_KHUYENMAI_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", DbType.String, uId_DM_Khuyenmai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_KHUYENMAIEntity) As Boolean Implements ITNTP_DM_KHUYENMAIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_KHUYENMAI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", DbType.String, obj.uId_DM_Khuyenmai)
            db.AddInParameter(objCmd, "@v_MaKhuyenMai", DbType.String, obj.v_MaKhuyenMai)
            db.AddInParameter(objCmd, "@nv_TenKhuyenMai", DbType.String, obj.nv_TenKhuyenMai)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllKhachHangKM(ByVal uId_DM_Khuyenmai As String, ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements ITNTP_DM_KHUYENMAIDA.SelectAllKhachHangKM
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Khachhang_Khuyenmai]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", DbType.String, uId_DM_Khuyenmai)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class