Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CUAHANG_NHANVIENDA

    Implements ICUAHANG_NHANVIENDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CUAHANG_NHANVIENEntity) Implements ICUAHANG_NHANVIENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCUAHANG_NHANVIEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CUAHANG_NHANVIENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CUAHANG_NHANVIENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CUAHANG_NHANVIENEntity)
                With lstobj(i)
                    .uId_Cuahang_Nhanvien = IIf(IsDBNull(objReader("uId_Cuahang_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Cuahang_Nhanvien")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Lydo_vn = IIf(IsDBNull(objReader("nv_Lydo_vn")) = True, "", objReader("nv_Lydo_vn"))
                    .nv_Lydo_en = IIf(IsDBNull(objReader("nv_Lydo_en")) = True, "", objReader("nv_Lydo_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CUAHANG_NHANVIENEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ICUAHANG_NHANVIENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCUAHANG_NHANVIEN_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Cuahang_Nhanvien As String) As CM.CUAHANG_NHANVIENEntity Implements ICUAHANG_NHANVIENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCUAHANG_NHANVIEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CUAHANG_NHANVIENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang_Nhanvien", System.Data.DbType.String, uId_Cuahang_Nhanvien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CUAHANG_NHANVIENEntity
            If objReader.Read Then
                With obj
                    .uId_Cuahang_Nhanvien = IIf(IsDBNull(objReader("uId_Cuahang_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Cuahang_Nhanvien")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .nv_Lydo_vn = IIf(IsDBNull(objReader("nv_Lydo_vn")) = True, "", objReader("nv_Lydo_vn"))
                    .nv_Lydo_en = IIf(IsDBNull(objReader("nv_Lydo_en")) = True, "", objReader("nv_Lydo_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CUAHANG_NHANVIENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CUAHANG_NHANVIENEntity) As Boolean Implements ICUAHANG_NHANVIENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCUAHANG_NHANVIEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Lydo_vn", DbType.String, obj.nv_Lydo_vn)
            db.AddInParameter(objCmd, "@nv_Lydo_en", DbType.String, obj.nv_Lydo_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Cuahang_Nhanvien As String) As Boolean Implements ICUAHANG_NHANVIENDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCUAHANG_NHANVIEN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang_Nhanvien", DbType.String, uId_Cuahang_Nhanvien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CUAHANG_NHANVIENEntity) As Boolean Implements ICUAHANG_NHANVIENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCUAHANG_NHANVIEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang_Nhanvien", DbType.String, obj.uId_Cuahang_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@nv_Lydo_vn", DbType.String, obj.nv_Lydo_vn)
            db.AddInParameter(objCmd, "@nv_Lydo_en", DbType.String, obj.nv_Lydo_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class