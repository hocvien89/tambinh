Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_MENHGIATIENDA

    Implements ITNTP_DM_MENHGIATIENDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_MENHGIATIENEntity) Implements ITNTP_DM_MENHGIATIENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_MENHGIATIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_MENHGIATIENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_MENHGIATIENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_MENHGIATIENEntity)
                With lstobj(i)
                    .uId_Menhgiatien = IIf(IsDBNull(objReader("uId_Menhgiatien")) = True, "", Convert.ToString(objReader("uId_Menhgiatien")))
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .f_Menhgia = IIf(IsDBNull(objReader("f_Menhgia")) = True, 0, objReader("f_Menhgia"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_MENHGIATIENEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Ngoaite As String) As System.Data.DataTable Implements ITNTP_DM_MENHGIATIENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_MENHGIATIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", System.Data.DbType.String, uId_Ngoaite)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Menhgiatien As String) As CM.TNTP_DM_MENHGIATIENEntity Implements ITNTP_DM_MENHGIATIENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_MENHGIATIEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_MENHGIATIENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", System.Data.DbType.String, uId_Menhgiatien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_MENHGIATIENEntity
            If objReader.Read Then
                With obj
                    .uId_Menhgiatien = IIf(IsDBNull(objReader("uId_Menhgiatien")) = True, "", Convert.ToString(objReader("uId_Menhgiatien")))
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .f_Menhgia = IIf(IsDBNull(objReader("f_Menhgia")) = True, 0, objReader("f_Menhgia"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_MENHGIATIENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_MENHGIATIENEntity) As Boolean Implements ITNTP_DM_MENHGIATIENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_MENHGIATIEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            db.AddInParameter(objCmd, "@f_Menhgia", DbType.Double, obj.f_Menhgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Menhgiatien As String) As Boolean Implements ITNTP_DM_MENHGIATIENDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_MENHGIATIEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", DbType.String, uId_Menhgiatien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_MENHGIATIENEntity) As Boolean Implements ITNTP_DM_MENHGIATIENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_MENHGIATIEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", DbType.String, obj.uId_Menhgiatien)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            db.AddInParameter(objCmd, "@f_Menhgia", DbType.Double, obj.f_Menhgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class