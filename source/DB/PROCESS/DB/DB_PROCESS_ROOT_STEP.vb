Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Public Class DB_PROCESS_ROOT_STEP
    Implements IDB_PROCESS_ROOT_STEP
    Public Function SelectByRootId(ByVal RootId As String) As System.Data.DataTable Implements IDB_PROCESS_ROOT_STEP.SelectByRootId
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_ROOT_Step_SelectByRootID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@RootId", DbType.String, RootId)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
End Class
