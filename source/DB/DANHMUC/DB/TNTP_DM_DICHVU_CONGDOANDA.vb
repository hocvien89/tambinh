Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_DICHVU_CONGDOANDA

    Implements ITNTP_DM_DICHVU_CONGDOANDA

    Private log As New LogError.ShowError



    Public Function SelectAllTable(ByVal uId_Dichvu As String) As System.Data.DataTable Implements ITNTP_DM_DICHVU_CONGDOANDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_CONGDOAN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function



    Public Function Insert(ByVal obj As CM.TNTP_DM_DICHVU_CONGDOANEntity) As Boolean Implements ITNTP_DM_DICHVU_CONGDOANDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_CONGDOAN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, obj.uId_Congdoan)
            db.AddInParameter(objCmd, "@f_TienHH", DbType.Double, obj.f_TienHH)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.String, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Sophut", DbType.String, obj.f_Sophut)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uIdKho)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Dichvu As String, ByVal uId_Congdoan As String) As Boolean Implements ITNTP_DM_DICHVU_CONGDOANDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_CONGDOAN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, uId_Congdoan)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_DICHVU_CONGDOANEntity) As Boolean Implements ITNTP_DM_DICHVU_CONGDOANDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_CONGDOAN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Congdoan", DbType.String, obj.uId_Congdoan)
            db.AddInParameter(objCmd, "@f_TienHH", DbType.Double, obj.f_TienHH)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uIdKho)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@uId_Dichvu_Congdoan", DbType.String, obj.uId_Dichvu_Congdoan)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.Double, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Sophut", DbType.Double, obj.f_Sophut)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    'xuanhieu 130415 trarmnguyenspa thiet lap cong doan
    Public Function SelectCongdoan(uId_Dichvu As String) As DataTable Implements ITNTP_DM_DICHVU_CONGDOANDA.SelectCongdoan
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_CONGDOAN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class