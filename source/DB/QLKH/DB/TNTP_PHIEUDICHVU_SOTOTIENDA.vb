Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_PHIEUDICHVU_SOTOTIENDA

    Implements ITNTP_PHIEUDICHVU_SOTOTIENDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) Implements ITNTP_PHIEUDICHVU_SOTOTIENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SOTOTIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_PHIEUDICHVU_SOTOTIENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_PHIEUDICHVU_SOTOTIENEntity)
                With lstobj(i)
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Menhgiatien = IIf(IsDBNull(objReader("uId_Menhgiatien")) = True, "", Convert.ToString(objReader("uId_Menhgiatien")))
                    .f_Sototien = IIf(IsDBNull(objReader("f_Sototien")) = True, 0, objReader("f_Sototien"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_PHIEUDICHVU_SOTOTIENEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_SOTOTIENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SOTOTIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String, ByVal uId_Menhgiatien As String) As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity Implements ITNTP_PHIEUDICHVU_SOTOTIENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SOTOTIEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", DbType.String, uId_Menhgiatien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_PHIEUDICHVU_SOTOTIENEntity
            If objReader.Read Then
                With obj
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Menhgiatien = IIf(IsDBNull(objReader("uId_Menhgiatien")) = True, "", Convert.ToString(objReader("uId_Menhgiatien")))
                    .f_Sototien = IIf(IsDBNull(objReader("f_Sototien")) = True, 0, objReader("f_Sototien"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_PHIEUDICHVU_SOTOTIENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) As Boolean Implements ITNTP_PHIEUDICHVU_SOTOTIENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SOTOTIEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", DbType.String, obj.uId_Menhgiatien)
            db.AddInParameter(objCmd, "@f_Sototien", DbType.Double, obj.f_Sototien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieudichvu As String, ByVal uId_Menhgiatien As String) As Boolean Implements ITNTP_PHIEUDICHVU_SOTOTIENDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SOTOTIEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", DbType.String, uId_Menhgiatien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) As Boolean Implements ITNTP_PHIEUDICHVU_SOTOTIENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_SOTOTIEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Menhgiatien", DbType.String, obj.uId_Menhgiatien)
            db.AddInParameter(objCmd, "@f_Sototien", DbType.Double, obj.f_Sototien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class