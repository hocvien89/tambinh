Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class clsD_Menu
    Implements iclsD_menu

    Private log As New LogError.ShowError
    Public Function SelectAllByIdPhong(uId_Phongban As String, ParentId As String) As DataTable Implements iclsD_menu.SelectAllByIdPhong
        Dim db As Database
        Dim sp As String = "[dbo].[spMenu_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, uId_Phongban)
            db.AddInParameter(objCmd, "@ParentID", DbType.String, ParentId)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Delete(ID As String) As Boolean Implements iclsD_menu.Delete

    End Function
End Class
