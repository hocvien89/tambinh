Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class PQP_DICHVU_PHONGDA

    Implements IPQP_DICHVU_PHONGDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.PQP_DICHVU_PHONGEntity) Implements IPQP_DICHVU_PHONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DICHVU_PHONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.PQP_DICHVU_PHONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.PQP_DICHVU_PHONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.PQP_DICHVU_PHONGEntity)
                With lstobj(i)
                    .uId_Dichvu_Phong = IIf(IsDBNull(objReader("uId_Dichvu_Phong")) = True, "", Convert.ToString(objReader("uId_Dichvu_Phong")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.PQP_DICHVU_PHONGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IPQP_DICHVU_PHONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DICHVU_PHONG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Dichvu_Phong As String) As CM.PQP_DICHVU_PHONGEntity Implements IPQP_DICHVU_PHONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DICHVU_PHONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.PQP_DICHVU_PHONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu_Phong", System.Data.DbType.String, uId_Dichvu_Phong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.PQP_DICHVU_PHONGEntity
            If objReader.Read Then
                With obj
                    .uId_Dichvu_Phong = IIf(IsDBNull(objReader("uId_Dichvu_Phong")) = True, "", Convert.ToString(objReader("uId_Dichvu_Phong")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.PQP_DICHVU_PHONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.PQP_DICHVU_PHONGEntity) As Boolean Implements IPQP_DICHVU_PHONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DICHVU_PHONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Dichvu_Phong As String) As Boolean Implements IPQP_DICHVU_PHONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DICHVU_PHONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu_Phong", DbType.String, uId_Dichvu_Phong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.PQP_DICHVU_PHONGEntity) As Boolean Implements IPQP_DICHVU_PHONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DICHVU_PHONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu_Phong", DbType.String, obj.uId_Dichvu_Phong)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class