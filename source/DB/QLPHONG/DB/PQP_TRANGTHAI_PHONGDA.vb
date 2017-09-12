Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class PQP_TRANGTHAI_PHONGDA

    Implements IPQP_TRANGTHAI_PHONGDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.PQP_TRANGTHAI_PHONGEntity) Implements IPQP_TRANGTHAI_PHONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAI_PHONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.PQP_TRANGTHAI_PHONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.PQP_TRANGTHAI_PHONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.PQP_TRANGTHAI_PHONGEntity)
                With lstobj(i)
                    .uId_TrangthaiPhong = IIf(IsDBNull(objReader("uId_TrangthaiPhong")) = True, "", Convert.ToString(objReader("uId_TrangthaiPhong")))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.PQP_TRANGTHAI_PHONGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IPQP_TRANGTHAI_PHONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAI_PHONG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_TrangthaiPhong As String) As CM.PQP_TRANGTHAI_PHONGEntity Implements IPQP_TRANGTHAI_PHONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAI_PHONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.PQP_TRANGTHAI_PHONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiPhong", System.Data.DbType.String, uId_TrangthaiPhong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.PQP_TRANGTHAI_PHONGEntity
            If objReader.Read Then
                With obj
                    .uId_TrangthaiPhong = IIf(IsDBNull(objReader("uId_TrangthaiPhong")) = True, "", Convert.ToString(objReader("uId_TrangthaiPhong")))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.PQP_TRANGTHAI_PHONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.PQP_TRANGTHAI_PHONGEntity) As Boolean Implements IPQP_TRANGTHAI_PHONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAI_PHONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_TrangthaiPhong As String) As Boolean Implements IPQP_TRANGTHAI_PHONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAI_PHONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiPhong", DbType.String, uId_TrangthaiPhong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.PQP_TRANGTHAI_PHONGEntity) As Boolean Implements IPQP_TRANGTHAI_PHONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAI_PHONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiPhong", DbType.String, obj.uId_TrangthaiPhong)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class