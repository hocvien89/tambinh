Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_Baocao_Lichhen

    Implements iclsD_Baocao_Lichhen
    Private log As New LogError.ShowError

    Public Function SelectLichhenThongkeKH(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal DK As Integer, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_Baocao_Lichhen.SelectLichhenThongkeKH
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Lichhen_KH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DK", DbType.Int32, DK)
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
