Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLTC_TK_KHACHHANGDA

    Implements IQLTC_TK_KHACHHANGDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLTC_TK_KHACHHANGEntity) Implements IQLTC_TK_KHACHHANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_TK_KHACHHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLTC_TK_KHACHHANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLTC_TK_KHACHHANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLTC_TK_KHACHHANGEntity)
                With lstobj(i)
                    .uId_TK_Khachhang = IIf(IsDBNull(objReader("uId_TK_Khachhang")) = True, "", Convert.ToString(objReader("uId_TK_Khachhang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .d_Thoigian = IIf(IsDBNull(objReader("d_Thoigian")) = True, Nothing, objReader("d_Thoigian"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLTC_TK_KHACHHANGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLTC_TK_KHACHHANGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_TK_KHACHHANG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_TK_Khachhang As String) As CM.QLTC_TK_KHACHHANGEntity Implements IQLTC_TK_KHACHHANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_TK_KHACHHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLTC_TK_KHACHHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TK_Khachhang", System.Data.DbType.String, uId_TK_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLTC_TK_KHACHHANGEntity
            If objReader.Read Then
                With obj
                    .uId_TK_Khachhang = IIf(IsDBNull(objReader("uId_TK_Khachhang")) = True, "", Convert.ToString(objReader("uId_TK_Khachhang")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .d_Thoigian = IIf(IsDBNull(objReader("d_Thoigian")) = True, Nothing, objReader("d_Thoigian"))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLTC_TK_KHACHHANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_TK_KHACHHANGEntity) As Boolean Implements IQLTC_TK_KHACHHANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_TK_KHACHHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", System.Data.DbType.String, obj.uId_Khachhang)
            'If (obj.d_Thoigian <> Nothing And obj.d_Thoigian <> Date.MinValue) Then
            '    db.AddInParameter(objCmd, "@d_Thoigian", DbType.DateTime, obj.d_Thoigian)
            'End If
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_TK_Khachhang As String) As Boolean Implements IQLTC_TK_KHACHHANGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_TK_KHACHHANG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TK_Khachhang", DbType.String, uId_TK_Khachhang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLTC_TK_KHACHHANGEntity) As Boolean Implements IQLTC_TK_KHACHHANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_TK_KHACHHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TK_Khachhang", DbType.String, obj.uId_TK_Khachhang)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            If (obj.d_Thoigian <> Nothing And obj.d_Thoigian <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Thoigian", DbType.DateTime, obj.d_Thoigian)
            End If
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class