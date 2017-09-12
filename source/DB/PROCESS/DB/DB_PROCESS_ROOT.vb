Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Public Class DB_PROCESS_ROOT
    Implements IDB_PROCESS_ROOT

    Public Function SelectAllTable() As System.Data.DataTable Implements IDB_PROCESS_ROOT.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_ROOT_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectById(ByVal ID As String) As CM.CM_PROCESS_ROOT Implements IDB_PROCESS_ROOT.SelectById
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_ROOT_SelectById]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CM_PROCESS_ROOT = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Id", System.Data.DbType.String, ID)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CM_PROCESS_ROOT
            If objReader.Read Then
                With obj
                    .Code = IIf(IsDBNull(objReader("Code")) = True, "", Convert.ToString(objReader("Code")))
                    .Process_Name = IIf(IsDBNull(objReader("Process_Name")) = True, "", Convert.ToString(objReader("Process_Name")))
                End With
            End If
            Return obj
        Catch ex As Exception
            Return New CM.CM_PROCESS_ROOT
        End Try
    End Function
End Class
