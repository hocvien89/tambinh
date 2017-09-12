Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports LogError
Imports System.Data.Common

Public Class QLTC_LoaiHinhTTDA

    Implements IQLTC_LoaiHinhTTDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLTC_LoaiHinhTTEntity) Implements IQLTC_LoaiHinhTTDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLTC_LoaiHinhTTEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLTC_LoaiHinhTTEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLTC_LoaiHinhTTEntity)
                With lstobj(i)
                    .uId_LoaiTT = IIf(IsDBNull(objReader("uId_LoaiTT")) = True, "", Convert.ToString(objReader("uId_LoaiTT")))
                    .nv_TenLoaiTT = IIf(IsDBNull(objReader("nv_TenLoaiTT")) = True, "", objReader("nv_TenLoaiTT"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLTC_LoaiHinhTTEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLTC_LoaiHinhTTDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_SelectAll]"
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

    Public Function SelectByID(ByVal uId_LoaiTT As String) As CM.QLTC_LoaiHinhTTEntity Implements IQLTC_LoaiHinhTTDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLTC_LoaiHinhTTEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiTT", System.Data.DbType.String, uId_LoaiTT)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLTC_LoaiHinhTTEntity
            If objReader.Read Then
                With obj
                    .uId_LoaiTT = IIf(IsDBNull(objReader("uId_LoaiTT")) = True, "", Convert.ToString(objReader("uId_LoaiTT")))
                    .nv_TenLoaiTT = IIf(IsDBNull(objReader("nv_TenLoaiTT")) = True, "", objReader("nv_TenLoaiTT"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLTC_LoaiHinhTTEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_LoaiHinhTTEntity) As Boolean Implements IQLTC_LoaiHinhTTDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenLoaiTT", DbType.String, obj.nv_TenLoaiTT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_LoaiTT As String) As Boolean Implements IQLTC_LoaiHinhTTDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, uId_LoaiTT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLTC_LoaiHinhTTEntity) As Boolean Implements IQLTC_LoaiHinhTTDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, obj.uId_LoaiTT)
            db.AddInParameter(objCmd, "@nv_TenLoaiTT", DbType.String, obj.nv_TenLoaiTT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class