Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_QT_DIEUTRI_NHANVIENPHUDA

    Implements ITNTP_QT_DIEUTRI_NHANVIENPHUDA


    Private log As New LogError.ShowError

    Public Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_NHANVIENPHUEntity) As Boolean Implements ITNTP_QT_DIEUTRI_NHANVIENPHUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_NHANVIENPHU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, obj.uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Nhanvien_Phu", DbType.String, obj.uId_Nhanvien_Phu)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, obj.uId_Congdoan)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_QT_Dieutri As String) As Boolean Implements ITNTP_QT_DIEUTRI_NHANVIENPHUDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_NHANVIENPHU_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByQTDT(ByVal uId_QT_Dieutri As String) As System.Data.DataTable Implements ITNTP_QT_DIEUTRI_NHANVIENPHUDA.SelectByQTDT
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_NHANVIENPHU_SelectByQTDT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function DeleteByALl(ByVal uId_QT_Dieutri As String, ByVal uId_Nhanvien_Phu As String, ByVal uId_Congdoan As String) As Boolean Implements ITNTP_QT_DIEUTRI_NHANVIENPHUDA.DeleteByALl
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_NHANVIENPHU_DeleteByALl]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Nhanvien_Phu", DbType.String, uId_Nhanvien_Phu)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, uId_Congdoan)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class