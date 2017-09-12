Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_VATTUTIEUHAODA

    Implements IQLMH_VATTUTIEUHAODA

    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Dichvu As String) As System.Collections.Generic.List(Of CM.QLMH_VATTUTIEUHAOEntity) Implements IQLMH_VATTUTIEUHAODA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_VATTUTIEUHAOEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_VATTUTIEUHAOEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_VATTUTIEUHAOEntity)
                With lstobj(i)
                    .uId_Vattutieuhao = IIf(IsDBNull(objReader("uId_Vattutieuhao")) = True, "", Convert.ToString(objReader("uId_Vattutieuhao")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .f_SLTieuhao = IIf(IsDBNull(objReader("f_SLTieuhao")) = True, 0, objReader("f_SLTieuhao"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_VATTUTIEUHAOEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Dichvu As String) As System.Data.DataTable Implements IQLMH_VATTUTIEUHAODA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectAllByQTDT(ByVal uId_QT_Dieutri As String, ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_VATTUTIEUHAODA.SelectAllByQTDT
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_SelectByQT_Dieutri]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Vattutieuhao As String) As CM.QLMH_VATTUTIEUHAOEntity Implements IQLMH_VATTUTIEUHAODA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_VATTUTIEUHAOEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Vattutieuhao", DbType.String, uId_Vattutieuhao)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_VATTUTIEUHAOEntity
            If objReader.Read Then
                With obj
                    .uId_Vattutieuhao = IIf(IsDBNull(objReader("uId_Vattutieuhao")) = True, "", Convert.ToString(objReader("uId_Vattutieuhao")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .f_SLTieuhao = IIf(IsDBNull(objReader("f_SLTieuhao")) = True, 0, objReader("f_SLTieuhao"))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_VATTUTIEUHAOEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_VATTUTIEUHAOEntity) As Boolean Implements IQLMH_VATTUTIEUHAODA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_SLTieuhao", DbType.Double, obj.f_SLTieuhao)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Vattutieuhao As String) As Boolean Implements IQLMH_VATTUTIEUHAODA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Vattutieuhao", DbType.String, uId_Vattutieuhao)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLMH_VATTUTIEUHAOEntity) As Boolean Implements IQLMH_VATTUTIEUHAODA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Vattutieuhao", DbType.String, obj.uId_Vattutieuhao)
            'db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            'db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_SLTieuhao", DbType.Double, obj.f_SLTieuhao)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function BaocaoVattu(Tungay As Date, Denngay As Date, uId_Kho As String) As DataTable Implements IQLMH_VATTUTIEUHAODA.BaocaoVattu
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_Vattutieuhao]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class