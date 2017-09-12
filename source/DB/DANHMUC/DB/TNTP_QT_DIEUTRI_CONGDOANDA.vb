Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_QT_DIEUTRI_CONGDOANDA

    Implements ITNTP_QT_DIEUTRI_CONGDOANDA
    Private log As New LogError.ShowError

    Public Function SelectAllTable() As System.Data.DataTable Implements ITNTP_QT_DIEUTRI_CONGDOANDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_CONGDOAN_SelectAll]"
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

    Public Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_CONGDOANEntity) As String Implements ITNTP_QT_DIEUTRI_CONGDOANDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_CONGDOAN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tencongdoan_vn", DbType.String, obj.nv_Tencongdoan_vn)
            db.AddInParameter(objCmd, "@v_Macongdoan", DbType.String, obj.v_Macongdoan)

            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Congdoan As String) As Boolean Implements ITNTP_QT_DIEUTRI_CONGDOANDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_DIEUTRI_CONGDOAN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, uId_Congdoan)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(obj As CM.TNTP_QT_DIEUTRI_CONGDOANEntity) As Boolean Implements ITNTP_QT_DIEUTRI_CONGDOANDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_QT_Dieutri_Congdoan_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, obj.uId_Congdoan)
            db.AddInParameter(objCmd, "@v_Macongdoan", DbType.String, obj.v_Macongdoan)
            db.AddInParameter(objCmd, "@nv_Tencongdoan_vn", DbType.String, obj.nv_Tencongdoan_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class