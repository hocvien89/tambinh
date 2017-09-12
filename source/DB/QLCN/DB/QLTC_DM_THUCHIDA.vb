Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLTC_DM_THUCHIDA

    Implements IQLTC_DM_THUCHIDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLTC_DM_THUCHIEntity) Implements IQLTC_DM_THUCHIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLTC_DM_THUCHIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLTC_DM_THUCHIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLTC_DM_THUCHIEntity)
                With lstobj(i)
                    .uId_Thuchi = IIf(IsDBNull(objReader("uId_Thuchi")) = True, "", Convert.ToString(objReader("uId_Thuchi")))
                    .v_Mathuchi = IIf(IsDBNull(objReader("v_Mathuchi")) = True, "", objReader("v_Mathuchi"))
                    .nv_Tenthuchi_vn = IIf(IsDBNull(objReader("nv_Tenthuchi_vn")) = True, "", objReader("nv_Tenthuchi_vn"))
                    .nv_Tenthuchi_en = IIf(IsDBNull(objReader("nv_Tenthuchi_en")) = True, "", objReader("nv_Tenthuchi_en"))
                    .b_ThuChi = IIf(IsDBNull(objReader("b_ThuChi")) = True, False, objReader("b_ThuChi"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLTC_DM_THUCHIEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLTC_DM_THUCHIDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Thuchi As String) As CM.QLTC_DM_THUCHIEntity Implements IQLTC_DM_THUCHIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLTC_DM_THUCHIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thuchi", System.Data.DbType.String, uId_Thuchi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLTC_DM_THUCHIEntity
            If objReader.Read Then
                With obj
                    .uId_Thuchi = IIf(IsDBNull(objReader("uId_Thuchi")) = True, "", Convert.ToString(objReader("uId_Thuchi")))
                    .v_Mathuchi = IIf(IsDBNull(objReader("v_Mathuchi")) = True, "", objReader("v_Mathuchi"))
                    .nv_Tenthuchi_vn = IIf(IsDBNull(objReader("nv_Tenthuchi_vn")) = True, "", objReader("nv_Tenthuchi_vn"))
                    .nv_Tenthuchi_en = IIf(IsDBNull(objReader("nv_Tenthuchi_en")) = True, "", objReader("nv_Tenthuchi_en"))
                    .b_ThuChi = IIf(IsDBNull(objReader("b_ThuChi")) = True, False, objReader("b_ThuChi"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLTC_DM_THUCHIEntity
        End Try
    End Function
    Public Function SelectByTen(ByVal Tenthuchi As String) As CM.QLTC_DM_THUCHIEntity Implements IQLTC_DM_THUCHIDA.SelectByTen
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_SelectByTen]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLTC_DM_THUCHIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tenthuchi", System.Data.DbType.String, Tenthuchi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLTC_DM_THUCHIEntity
            If objReader.Read Then
                With obj
                    .uId_Thuchi = IIf(IsDBNull(objReader("uId_Thuchi")) = True, "", Convert.ToString(objReader("uId_Thuchi")))
                    .v_Mathuchi = IIf(IsDBNull(objReader("v_Mathuchi")) = True, "", objReader("v_Mathuchi"))
                    .nv_Tenthuchi_vn = IIf(IsDBNull(objReader("nv_Tenthuchi_vn")) = True, "", objReader("nv_Tenthuchi_vn"))
                    .nv_Tenthuchi_en = IIf(IsDBNull(objReader("nv_Tenthuchi_en")) = True, "", objReader("nv_Tenthuchi_en"))
                    .b_ThuChi = IIf(IsDBNull(objReader("b_ThuChi")) = True, False, objReader("b_ThuChi"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLTC_DM_THUCHIEntity
        End Try
    End Function
    Public Function SelectLoai(ByVal loai As Boolean) As System.Data.DataTable Implements IQLTC_DM_THUCHIDA.SelectLoai
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_SelectLoai]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim dt As DataTable
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@loai", System.Data.DbType.Boolean, loai)
            objDs = db.ExecuteDataSet(objCmd)
            dt = objDs.Tables(0)
            Return dt
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_DM_THUCHIEntity) As Boolean Implements IQLTC_DM_THUCHIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Mathuchi", DbType.String, obj.v_Mathuchi)
            db.AddInParameter(objCmd, "@nv_Tenthuchi_vn", DbType.String, obj.nv_Tenthuchi_vn)
            db.AddInParameter(objCmd, "@nv_Tenthuchi_en", DbType.String, obj.nv_Tenthuchi_en)
            db.AddInParameter(objCmd, "@b_ThuChi", DbType.Boolean, obj.b_ThuChi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Thuchi As String) As Boolean Implements IQLTC_DM_THUCHIDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thuchi", DbType.String, uId_Thuchi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLTC_DM_THUCHIEntity) As Boolean Implements IQLTC_DM_THUCHIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_DM_THUCHI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thuchi", DbType.String, obj.uId_Thuchi)
            db.AddInParameter(objCmd, "@v_Mathuchi", DbType.String, obj.v_Mathuchi)
            db.AddInParameter(objCmd, "@nv_Tenthuchi_vn", DbType.String, obj.nv_Tenthuchi_vn)
            db.AddInParameter(objCmd, "@nv_Tenthuchi_en", DbType.String, obj.nv_Tenthuchi_en)
            db.AddInParameter(objCmd, "@b_ThuChi", DbType.Boolean, obj.b_ThuChi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class