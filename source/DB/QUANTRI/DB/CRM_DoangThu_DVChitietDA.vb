Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class CRM_DoangThu_DVChitietDA
    Implements ICRM_DoangThu_DVChitietDA
    Private log As New LogError.ShowError
    Public Function SelectByMonthBuffer(ByVal Ngay As DateTime) As System.Data.DataTable Implements ICRM_DoangThu_DVChitietDA.SelectByMonthBuffer
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhthuDVChiTietByThangBuffer]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Thang", DbType.DateTime, Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByMonth(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements ICRM_DoangThu_DVChitietDA.SelectByMonth
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhthuDichvuChitiet]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
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
