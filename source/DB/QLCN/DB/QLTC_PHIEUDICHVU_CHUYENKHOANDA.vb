Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLTC_PHIEUDICHVU_CHUYENKHOANDA

    Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity)
                With lstobj(i)
                    .uId_PDV_Chuyentien = IIf(IsDBNull(objReader("uId_PDV_Chuyentien")) = True, "", Convert.ToString(objReader("uId_PDV_Chuyentien")))
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .d_Thoigian = IIf(IsDBNull(objReader("d_Thoigian")) = True, Nothing, objReader("d_Thoigian"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_SelectAll]"
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

    Public Function SelectByID(ByVal uId_PDV_Chuyentien As String) As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_PDV_Chuyentien", System.Data.DbType.String, uId_PDV_Chuyentien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity
            If objReader.Read Then
                With obj
                    .uId_PDV_Chuyentien = IIf(IsDBNull(objReader("uId_PDV_Chuyentien")) = True, "", Convert.ToString(objReader("uId_PDV_Chuyentien")))
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .d_Thoigian = IIf(IsDBNull(objReader("d_Thoigian")) = True, Nothing, objReader("d_Thoigian"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) As Boolean Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_PDV_Chuyentien As String) As Boolean Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@uId_PDV_Chuyentien", DbType.String, uId_PDV_Chuyentien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) As Boolean Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_PDV_Chuyentien", DbType.String, obj.uId_PDV_Chuyentien)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            If (obj.d_Thoigian <> Nothing And obj.d_Thoigian <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Thoigian", DbType.DateTime, obj.d_Thoigian)
            End If
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllByPhieuDV(ByVal uId_Phieudichvu As String) As String Implements IQLTC_PHIEUDICHVU_CHUYENKHOANDA.SelectAllByPhieuDV
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_PHIEUDICHVU_CHUYENKHOAN_SelectAllByPDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)("f_Sotien").ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function
End Class