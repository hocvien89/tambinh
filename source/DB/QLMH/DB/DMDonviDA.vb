Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports LogError
Imports System.Data.Common

Public Class DMDonviDA

    Implements IDMDonviDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.DMDonviEntity) Implements IDMDonviDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spDMDonvi_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.DMDonviEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.DMDonviEntity)
            While (objReader.Read())
                lstobj.Add(New CM.DMDonviEntity)
                With lstobj(i)
                    .madonvi = IIf(IsDBNull(objReader("madonvi")) = True, "", objReader("madonvi"))
                    .tendonvi = IIf(IsDBNull(objReader("tendonvi")) = True, "", objReader("tendonvi"))
                    .ghichu = IIf(IsDBNull(objReader("ghichu")) = True, "", objReader("ghichu"))
                End With
                i += 1
            End While
            objReader.Close()
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.DMDonviEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IDMDonviDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spDMDonvi_SelectAll]"
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

    Public Function SelectByID(ByVal madonvi As String) As CM.DMDonviEntity Implements IDMDonviDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spDMDonvi_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.DMDonviEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@madonvi", System.Data.DbType.String, madonvi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.DMDonviEntity
            If objReader.Read Then
                With obj
                    .madonvi = IIf(IsDBNull(objReader("madonvi")) = True, "", objReader("madonvi"))
                    .tendonvi = IIf(IsDBNull(objReader("tendonvi")) = True, "", objReader("tendonvi"))
                    .ghichu = IIf(IsDBNull(objReader("ghichu")) = True, "", objReader("ghichu"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.DMDonviEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.DMDonviEntity) As Boolean Implements IDMDonviDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spDMDonvi_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@madonvi", DbType.String, obj.madonvi)
            db.AddInParameter(objCmd, "@tendonvi", DbType.String, obj.tendonvi)
            db.AddInParameter(objCmd, "@ghichu", DbType.String, obj.ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal madonvi As String) As Boolean Implements IDMDonviDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spDMDonvi_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@madonvi", DbType.String, madonvi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.DMDonviEntity) As Boolean Implements IDMDonviDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spDMDonvi_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@madonvi", DbType.String, obj.madonvi)
            db.AddInParameter(objCmd, "@tendonvi", DbType.String, obj.tendonvi)
            db.AddInParameter(objCmd, "@ghichu", DbType.String, obj.ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class