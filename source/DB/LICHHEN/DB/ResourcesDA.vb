Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports LogError
Imports System.Data.Common

Public Class ResourcesDA

    Implements IResourcesDA


    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.ResourcesEntity) Implements IResourcesDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.ResourcesEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.ResourcesEntity)
            While (objReader.Read())
                lstobj.Add(New CM.ResourcesEntity)
                With lstobj(i)
                    .UniqueID = IIf(IsDBNull(objReader("UniqueID")) = True, 0, objReader("UniqueID"))
                    .ResourceID = IIf(IsDBNull(objReader("ResourceID")) = True, 0, objReader("ResourceID"))
                    .ResourceName = IIf(IsDBNull(objReader("ResourceName")) = True, "", objReader("ResourceName"))
                    .Color = IIf(IsDBNull(objReader("Color")) = True, 0, objReader("Color"))
                End With
                i += 1
            End While
            objReader.Close()
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.ResourcesEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IResourcesDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_SelectAll]"
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

    Public Function SelectByID(ByVal UniqueID As Int32) As CM.ResourcesEntity Implements IResourcesDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.ResourcesEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", System.Data.DbType.Int32, UniqueID)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.ResourcesEntity
            If objReader.Read Then
                With obj
                    .UniqueID = IIf(IsDBNull(objReader("UniqueID")) = True, 0, objReader("UniqueID"))
                    .ResourceID = IIf(IsDBNull(objReader("ResourceID")) = True, 0, objReader("ResourceID"))
                    .ResourceName = IIf(IsDBNull(objReader("ResourceName")) = True, "", objReader("ResourceName"))
                    .Color = IIf(IsDBNull(objReader("Color")) = True, 0, objReader("Color"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.ResourcesEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.ResourcesEntity) As Boolean Implements IResourcesDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@ResourceID", DbType.Int32, obj.ResourceID)
            db.AddInParameter(objCmd, "@ResourceName", DbType.String, obj.ResourceName)
            db.AddInParameter(objCmd, "@Color", DbType.Int32, obj.Color)
            db.AddInParameter(objCmd, "@CustomField1", DbType.String, obj.CustomField1)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal UniqueID As Int32) As Boolean Implements IResourcesDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", DbType.Int32, UniqueID)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.ResourcesEntity) As Boolean Implements IResourcesDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@UniqueID", DbType.Int32, obj.UniqueID)
            db.AddInParameter(objCmd, "@ResourceID", DbType.Int32, obj.ResourceID)
            db.AddInParameter(objCmd, "@ResourceName", DbType.String, obj.ResourceName)
            db.AddInParameter(objCmd, "@Color", DbType.Int32, obj.Color)
            db.AddInParameter(objCmd, "@CustomField1", DbType.String, obj.CustomField1)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByResourceId(RsID As Integer) As String Implements IResourcesDA.SelectByResourceId
        Dim db As Database
        Dim sp As String = "[dbo].[spResources_SelectByResourcID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@ResourceID", DbType.Int32, RsID)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function

    Public Function Insert_Resource_Up(obj As CM.ResourcesEntity) As Boolean Implements IResourcesDA.Insert_Resource_Up
        Dim db As Database
        Dim sp As String = "[dbo].[Resourcer_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@ResourceName", DbType.String, obj.ResourceName)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Select_Thongtin_ByID(id As String) As DataTable Implements IResourcesDA.Select_Thongtin_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Appointment_ByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Id", DbType.String, id)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class