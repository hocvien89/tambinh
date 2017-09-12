Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.CM
Imports LogError
Imports System.Data.Common

Public Class TNTP_CHECKINCHECKOUTDA

    Implements ITNTP_CHECKINCHECKOUTDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_CHECKINCHECKOUTEntity) Implements ITNTP_CHECKINCHECKOUTDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_CHECKINCHECKOUTEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_CHECKINCHECKOUTEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_CHECKINCHECKOUTEntity)
                With lstobj(i)
                    .uId_Check = IIf(IsDBNull(objReader("uId_Check")) = True, "", Convert.ToString(objReader("uId_Check")))
                    .uId_Giuong = IIf(IsDBNull(objReader("uId_Giuong")) = True, "", Convert.ToString(objReader("uId_Giuong")))
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .dt_checkin = IIf(IsDBNull(objReader("dt_checkin")) = True, Nothing, objReader("dt_checkin"))
                    .dt_checkout = IIf(IsDBNull(objReader("dt_checkout")) = True, Nothing, objReader("dt_checkout"))
                End With
                i += 1
            End While
            objReader.Close()
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_CHECKINCHECKOUTEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ITNTP_CHECKINCHECKOUTDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Check As String) As CM.TNTP_CHECKINCHECKOUTEntity Implements ITNTP_CHECKINCHECKOUTDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_CHECKINCHECKOUTEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Check", System.Data.DbType.String, uId_Check)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_CHECKINCHECKOUTEntity
            If objReader.Read Then
                With obj
                    .uId_Check = IIf(IsDBNull(objReader("uId_Check")) = True, "", Convert.ToString(objReader("uId_Check")))
                    .uId_Giuong = IIf(IsDBNull(objReader("uId_Giuong")) = True, "", Convert.ToString(objReader("uId_Giuong")))
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .dt_checkin = IIf(IsDBNull(objReader("dt_checkin")) = True, Nothing, objReader("dt_checkin"))
                    .dt_checkout = IIf(IsDBNull(objReader("dt_checkout")) = True, Nothing, objReader("dt_checkout"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_CHECKINCHECKOUTEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_CHECKINCHECKOUTEntity) As Boolean Implements ITNTP_CHECKINCHECKOUTDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (obj.dt_checkin <> Nothing And obj.dt_checkin <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@dt_checkin", DbType.DateTime, obj.dt_checkin)
            End If
            If (obj.dt_checkout <> Nothing And obj.dt_checkout <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@dt_checkout", DbType.DateTime, obj.dt_checkout)
            End If
            db.AddInParameter(objCmd, "@uId_Giuong", DbType.String, obj.uId_Giuong)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, obj.uId_QT_Dieutri)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Check As String) As Boolean Implements ITNTP_CHECKINCHECKOUTDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Check", DbType.String, uId_Check)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_CHECKINCHECKOUTEntity) As Boolean Implements ITNTP_CHECKINCHECKOUTDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Check", DbType.String, obj.uId_Check)
            db.AddInParameter(objCmd, "@uId_Giuong", DbType.String, obj.uId_Giuong)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, obj.uId_QT_Dieutri)
            If (obj.dt_checkin <> Nothing And obj.dt_checkin <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@dt_checkin", DbType.DateTime, obj.dt_checkin)
            End If
            If (obj.dt_checkout <> Nothing And obj.dt_checkout <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@dt_checkout", DbType.DateTime, obj.dt_checkout)
            End If
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Checkout(uId_QT_Dieutri As String, dt_checkout As Date, b_Status As Boolean) As Boolean Implements ITNTP_CHECKINCHECKOUTDA.Checkout
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_Checkout]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@dt_checkout", DbType.DateTime, dt_checkout)
            db.AddInParameter(objCmd, "@b_Status", DbType.Boolean, b_Status)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByIDDieuTri(uId_QT_Dieutri As String) As CM.TNTP_CHECKINCHECKOUTEntity Implements ITNTP_CHECKINCHECKOUTDA.SelectByIDDieuTri
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_SelectByIDDieuTri]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_CHECKINCHECKOUTEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", System.Data.DbType.String, uId_QT_Dieutri)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_CHECKINCHECKOUTEntity
            If objReader.Read Then
                With obj
                    .uId_Check = IIf(IsDBNull(objReader("uId_Check")) = True, "", Convert.ToString(objReader("uId_Check")))
                    .uId_Giuong = IIf(IsDBNull(objReader("uId_Giuong")) = True, "", Convert.ToString(objReader("uId_Giuong")))
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .dt_checkin = IIf(IsDBNull(objReader("dt_checkin")) = True, Nothing, objReader("dt_checkin"))
                    .dt_checkout = IIf(IsDBNull(objReader("dt_checkout")) = True, Nothing, objReader("dt_checkout"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_CHECKINCHECKOUTEntity
        End Try
    End Function

    Public Function SelectLieuTrinhTheoPhong(uId_Giuong As String) As DataTable Implements ITNTP_CHECKINCHECKOUTDA.SelectLieuTrinhTheoPhong
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHECKINCHECKOUT_SelectLieuTrinhTheoPhong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Giuong", System.Data.DbType.String, uId_Giuong)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class