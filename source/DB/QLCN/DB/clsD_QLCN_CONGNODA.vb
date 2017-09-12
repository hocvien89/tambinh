Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLCN_CONGNODA

    Implements IQLCN_CONGNODA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLCN_CONGNOEntity) Implements IQLCN_CONGNODA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLCN_CONGNOEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLCN_CONGNOEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLCN_CONGNOEntity)
                With lstobj(i)
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLCN_CONGNOEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLCN_CONGNODA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SelectAll]"
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


    Public Function SelectByID(ByVal uId_Phieudichvu As String) As CM.QLCN_CONGNOEntity Implements IQLCN_CONGNODA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLCN_CONGNOEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLCN_CONGNOEntity
            If objReader.Read Then
                With obj
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                    .uId_Congno_Thanhtoan = IIf(IsDBNull(objReader("uId_Congno_Thanhtoan")) = True, "", Convert.ToString(objReader("uId_Congno_Thanhtoan")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLCN_CONGNOEntity
        End Try
    End Function

    Public Function CongNoKH(ByVal uId_Khachhang As String) As String Implements IQLCN_CONGNODA.CongNoKH
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_Khachhang]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean Implements IQLCN_CONGNODA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_Insert]"
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

    Public Function DeleteByID(ByVal uId_Phieudichvu As String) As Boolean Implements IQLCN_CONGNODA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean Implements IQLCN_CONGNODA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_Update]"
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
    Public Function Update_TT(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean Implements IQLCN_CONGNODA.Update_TT
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_Update_TT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Congno_Thanhtoan", DbType.String, obj.uId_Congno_Thanhtoan)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByID_TB(uId_Phieudichvu As String) As DataTable Implements IQLCN_CONGNODA.SelectByID_TB
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SelectByID]"
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
End Class