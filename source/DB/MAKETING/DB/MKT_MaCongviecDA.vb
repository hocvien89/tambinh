Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_MaCongviecDA

    Implements IMKT_MaCongviecDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_MaCongviecEntity) Implements IMKT_MaCongviecDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_MaCongviec_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_MaCongviecEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_MaCongviecEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_MaCongviecEntity)
                With lstobj(i)
                    .uId_MaCongviec = IIf(IsDBNull(objReader("uId_MaCongviec")) = True, "", Convert.ToString(objReader("uId_MaCongviec")))
                    .nv_TenMaCongviec = IIf(IsDBNull(objReader("nv_TenMaCongviec")) = True, "", objReader("nv_TenMaCongviec"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_MaCongviecEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IMKT_MaCongviecDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_MaCongviec_SelectAll]"
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

    Public Function SelectByID(ByVal uId_MaCongviec As String) As CM.MKT_MaCongviecEntity Implements IMKT_MaCongviecDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_MaCongviec_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_MaCongviecEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_MaCongviec", System.Data.DbType.String, uId_MaCongviec)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_MaCongviecEntity
            If objReader.Read Then
                With obj
                    .uId_MaCongviec = IIf(IsDBNull(objReader("uId_MaCongviec")) = True, "", Convert.ToString(objReader("uId_MaCongviec")))
                    .nv_TenMaCongviec = IIf(IsDBNull(objReader("nv_TenMaCongviec")) = True, "", objReader("nv_TenMaCongviec"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_MaCongviecEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_MaCongviecEntity) As Boolean Implements IMKT_MaCongviecDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_MaCongviec_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenMaCongviec", DbType.String, obj.nv_TenMaCongviec)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_MaCongviec As String) As Boolean Implements IMKT_MaCongviecDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_MaCongviec_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_MaCongviec", DbType.String, uId_MaCongviec)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_MaCongviecEntity) As Boolean Implements IMKT_MaCongviecDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_MaCongviec_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_MaCongviec", DbType.String, obj.uId_MaCongviec)
            db.AddInParameter(objCmd, "@nv_TenMaCongviec", DbType.String, obj.nv_TenMaCongviec)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class