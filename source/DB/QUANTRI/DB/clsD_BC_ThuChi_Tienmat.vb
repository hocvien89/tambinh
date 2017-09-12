Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_BC_ThuChi_Tienmat
    Implements iclsD_BC_ThuChi_Tienmat
    Private log As New LogError.ShowError
    Public Function ThuChi_Tienmat(ByVal uID_cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements iclsD_BC_ThuChi_Tienmat.ThuChi_Tienmat
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_TC_Tienmat]"
        Dim objCmd As DbCommand
        Dim dt, dt1, dt2 As New DataTable
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uID_cuahang)
            dt = db.ExecuteDataSet(objCmd).Tables(0)
            dt1 = db.ExecuteDataSet(objCmd).Tables(1)
            dt2 = db.ExecuteDataSet(objCmd).Tables(2)
            Dim i As Integer = 0
            While i < dt1.Rows.Count
                dt.ImportRow(dt1.Rows(i))
                i += 1
            End While
            i = 0
            While i < dt2.Rows.Count
                dt.ImportRow(dt2.Rows(i))
                i += 1
            End While
            Return dt
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
