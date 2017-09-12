Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class QLMH_PHIEUXUAT_LOAITTDA
    Implements IQLMH_PHIEUXUAT_LOAITTDA

    Private log As New LogError.ShowError

    Public Function SelectByPhieuxuat(ByVal uId_Phieuxuat As String) As System.Data.DataTable Implements IQLMH_PHIEUXUAT_LOAITTDA.SelectByPhieuxuat
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_LOAITT_SelectByPhieuxuat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", System.Data.DbType.String, uId_Phieuxuat)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_PHIEUXUAT_LOAITTEntity) As Boolean Implements IQLMH_PHIEUXUAT_LOAITTDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_LOAITT_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, obj.uId_LoaiTT)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.AddInParameter(objCmd, "@v_Maso", DbType.String, obj.v_Maso)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieuxuat As String, ByVal uId_LoaiTT As String) As Boolean Implements IQLMH_PHIEUXUAT_LOAITTDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_LOAITT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, uId_LoaiTT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectTongtien(ByVal uId_Phieuxuat As String) As String Implements IQLMH_PHIEUXUAT_LOAITTDA.SelectTongtien
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUXUAT_LOAITT_SelectTongTien]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class
