Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_VATTUTIEUHAO_QT_DIEUTRIDA

    Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity)
                With lstobj(i)
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .f_SLTieuhao = IIf(IsDBNull(objReader("f_SLTieuhao")) = True, 0, objReader("f_SLTieuhao"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_SelectAll]"
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

    Public Function SelectByID(ByVal uId_QT_Dieutri As String, ByVal uId_Mathang As String) As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", System.Data.DbType.String, uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Mathang", System.Data.DbType.String, uId_Mathang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
            If objReader.Read Then
                With obj
                    .uId_QT_Dieutri = IIf(IsDBNull(objReader("uId_QT_Dieutri")) = True, "", Convert.ToString(objReader("uId_QT_Dieutri")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .f_SLTieuhao = IIf(IsDBNull(objReader("f_SLTieuhao")) = True, 0, objReader("f_SLTieuhao"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", System.Data.DbType.String, obj.uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Mathang", System.Data.DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_SLTieuhao", DbType.Double, obj.f_SLTieuhao)
            db.AddInParameter(objCmd, "@uId_Kho", System.Data.DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@Madonvi", System.Data.DbType.String, obj.Madonvi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, obj.uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function DeleteByID_QTDT(ByVal uId_QT_Dieutri As String) As Boolean Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.DeleteByID_QTDT
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_DeleteByID_QTDT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_QT_Dieutri)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Update(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_QT_DIEUTRI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, obj.uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_SLTieuhao", DbType.Double, obj.f_SLTieuhao)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.AddInParameter(objCmd, "@Madonvi", System.Data.DbType.String, obj.Madonvi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class