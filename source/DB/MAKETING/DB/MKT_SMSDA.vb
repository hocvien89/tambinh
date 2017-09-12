Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_SMSDA

    Implements IMKT_SMSDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_SMSEntity) Implements IMKT_SMSDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_SMS_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_SMSEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_SMSEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_SMSEntity)
                With lstobj(i)
                    .uId_SMS = IIf(IsDBNull(objReader("uId_SMS")) = True, "", Convert.ToString(objReader("uId_SMS")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_SMSEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IMKT_SMSDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_SMS_SelectAll]"
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

    Public Function SelectByID(ByVal uId_SMS As String) As CM.MKT_SMSEntity Implements IMKT_SMSDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_SMS_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_SMSEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_SMS", System.Data.DbType.String, uId_SMS)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_SMSEntity
            If objReader.Read Then
                With obj
                    .uId_SMS = IIf(IsDBNull(objReader("uId_SMS")) = True, "", Convert.ToString(objReader("uId_SMS")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_SMSEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_SMSEntity) As Boolean Implements IMKT_SMSDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_SMS_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_SMS As String) As Boolean Implements IMKT_SMSDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_SMS_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_SMS", DbType.String, uId_SMS)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_SMSEntity) As Boolean Implements IMKT_SMSDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_SMS_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_SMS", DbType.String, obj.uId_SMS)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class