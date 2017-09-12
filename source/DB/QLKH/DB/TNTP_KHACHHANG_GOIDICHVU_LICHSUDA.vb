Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_KHACHHANG_GOIDICHVU_LICHSUDA

    Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUDA


    Private log As New LogError.ShowError

    Public Function Insert_Phieudv(obj As CM.ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUDA.Insert_Phieudv
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TNTP_KHACHHANG_GOIDICHVU_LICHSU_Insert_Phieudichvu]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, obj.uId_Khachhang_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.String, obj.f_Sotien)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.String, obj.d_Ngay)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Insert_Phieuxuat(obj As CM.ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity) As Boolean Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUDA.Insert_Phieuxuat
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TNTP_KHACHHANG_GOIDICHVU_Insert_Phieuxuat]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang_Goidichvu", DbType.String, obj.uId_Khachhang_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.String, obj.f_Sotien)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.String, obj.d_Ngay)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByID(uId_Khachhang_Goidichvu As String) As DataTable Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_KH_Goidichvu_In]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_KH_GoiDV", DbType.String, uId_Khachhang_Goidichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
