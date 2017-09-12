Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports LogError
Imports System.Data.Common

Public Class NHATKYSUDUNGDA

    Implements INHATKYSUDUNGDA
    Private log As New LogError.ShowError

    Public Function SelectAllTable(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal key As String) As System.Data.DataTable Implements INHATKYSUDUNGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spNHATKYSUDUNG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@key", DbType.String, key)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.NHATKYSUDUNGEntity) As Boolean Implements INHATKYSUDUNGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spNHATKYSUDUNG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tendangnhap", DbType.String, obj.Tendangnhap)
            db.AddInParameter(objCmd, "@hanhdong", DbType.String, obj.hanhdong)
            db.AddInParameter(objCmd, "@IP", DbType.String, obj.IP)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class