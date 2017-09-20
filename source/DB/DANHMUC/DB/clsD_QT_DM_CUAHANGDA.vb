Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Imports System.Data.SqlClient

Public Class QT_DM_CUAHANGDA

    Implements IQT_DM_CUAHANGDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QT_DM_CUAHANGEntity) Implements IQT_DM_CUAHANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim lstobj As New List(Of CM.QT_DM_CUAHANGEntity)
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QT_DM_CUAHANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QT_DM_CUAHANGEntity)
                With lstobj(i)
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .v_Macuahang = IIf(IsDBNull(objReader("v_Macuahang")) = True, "", objReader("v_Macuahang"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                    .nv_Tencuahang_en = IIf(IsDBNull(objReader("nv_Tencuahang_en")) = True, "", objReader("nv_Tencuahang_en"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .b_Active = IIf(IsDBNull(objReader("b_Active")) = True, False, objReader("b_Active"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QT_DM_CUAHANGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQT_DM_CUAHANGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQT_DM_CUAHANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", System.Data.DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByMaCH(ByVal v_Macuahang As String) As System.Data.DataTable Implements IQT_DM_CUAHANGDA.SelectByMaCH
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_SelectByMaCH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Macuahang", System.Data.DbType.String, v_Macuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Insert(ByVal obj As CM.QT_DM_CUAHANGEntity) As String Implements IQT_DM_CUAHANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Macuahang", DbType.String, obj.v_Macuahang)
            db.AddInParameter(objCmd, "@nv_Tencuahang_vn", DbType.String, obj.nv_Tencuahang_vn)
            db.AddInParameter(objCmd, "@nv_Tencuahang_en", DbType.String, obj.nv_Tencuahang_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@b_Active", DbType.Boolean, obj.b_Active)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Cuahang As String) As Boolean Implements IQT_DM_CUAHANGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QT_DM_CUAHANGEntity) As Boolean Implements IQT_DM_CUAHANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Macuahang", DbType.String, obj.v_Macuahang)
            db.AddInParameter(objCmd, "@nv_Tencuahang_vn", DbType.String, obj.nv_Tencuahang_vn)
            db.AddInParameter(objCmd, "@nv_Tencuahang_en", DbType.String, obj.nv_Tencuahang_en)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_en", DbType.String, obj.nv_Diachi_en)
            db.AddInParameter(objCmd, "@b_Active", DbType.Boolean, obj.b_Active)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function AddThongtinMail(ByVal obj As CM.QT_DM_CUAHANGEntity) As Boolean Implements IQT_DM_CUAHANGDA.AddThongtinMail
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_AddThongtinMail]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@v_Email", DbType.String, obj.v_Email)
            db.AddInParameter(objCmd, "@v_passEmail", DbType.String, obj.v_passEmail)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByIDCuahang(uId_Cuahang As String) As CM.QT_DM_CUAHANGEntity Implements IQT_DM_CUAHANGDA.SelectByIDCuahang
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CUAHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QT_DM_CUAHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", System.Data.DbType.String, uId_Cuahang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QT_DM_CUAHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", Convert.ToString(objReader("nv_Tencuahang_vn")))
                    .nv_Tencuahang_en = IIf(IsDBNull(objReader("nv_Tencuahang_en")) = True, "", Convert.ToString(objReader("nv_Tencuahang_en")))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, Nothing, objReader("nv_Diachi_vn"))
                    .nv_Diachi_en = IIf(IsDBNull(objReader("nv_Diachi_en")) = True, "", objReader("nv_Diachi_en"))
                    .nv_Dienthoai = IIf(IsDBNull(objReader("nv_Dienthoai")) = True, "", objReader("nv_Dienthoai"))
                    .v_Macuahang = IIf(IsDBNull(objReader("v_Macuahang")) = True, "", objReader("v_Macuahang"))
                    .b_Active = IIf(IsDBNull(objReader("b_Active")) = True, 1, objReader("b_Active"))
                    .v_Email = IIf(IsDBNull(objReader("v_Email")) = True, "", objReader("v_Email"))
                    .v_passEmail = IIf(IsDBNull(objReader("v_passEmail")) = True, "", objReader("v_passEmail"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QT_DM_CUAHANGEntity
        End Try
    End Function
End Class