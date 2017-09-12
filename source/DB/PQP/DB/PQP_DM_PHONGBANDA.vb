Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class PQP_DM_PHONGBANDA

    Implements IPQP_DM_PHONGBANDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.PQP_DM_PHONGBANEntity) Implements IPQP_DM_PHONGBANDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DM_PHONGBAN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.PQP_DM_PHONGBANEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.PQP_DM_PHONGBANEntity)
            While (objReader.Read())
                lstobj.Add(New CM.PQP_DM_PHONGBANEntity)
                With lstobj(i)
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_Tenphongban_vn = IIf(IsDBNull(objReader("nv_Tenphongban_vn")) = True, "", objReader("nv_Tenphongban_vn"))
                    .nv_Tenphongban_en = IIf(IsDBNull(objReader("nv_Tenphongban_en")) = True, "", objReader("nv_Tenphongban_en"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.PQP_DM_PHONGBANEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IPQP_DM_PHONGBANDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DM_PHONGBAN_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Phongban As String) As CM.PQP_DM_PHONGBANEntity Implements IPQP_DM_PHONGBANDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DM_PHONGBAN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.PQP_DM_PHONGBANEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", System.Data.DbType.String, uId_Phongban)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.PQP_DM_PHONGBANEntity
            If objReader.Read Then
                With obj
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_Tenphongban_vn = IIf(IsDBNull(objReader("nv_Tenphongban_vn")) = True, "", objReader("nv_Tenphongban_vn"))
                    .nv_Tenphongban_en = IIf(IsDBNull(objReader("nv_Tenphongban_en")) = True, "", objReader("nv_Tenphongban_en"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.PQP_DM_PHONGBANEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.PQP_DM_PHONGBANEntity) As Boolean Implements IPQP_DM_PHONGBANDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DM_PHONGBAN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Tenphongban_vn", DbType.String, obj.nv_Tenphongban_vn)
            db.AddInParameter(objCmd, "@nv_Tenphongban_en", DbType.String, obj.nv_Tenphongban_en)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phongban As String) As Boolean Implements IPQP_DM_PHONGBANDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DM_PHONGBAN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, uId_Phongban)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.PQP_DM_PHONGBANEntity) As Boolean Implements IPQP_DM_PHONGBANDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_DM_PHONGBAN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Tenphongban_vn", DbType.String, obj.nv_Tenphongban_vn)
            db.AddInParameter(objCmd, "@nv_Tenphongban_en", DbType.String, obj.nv_Tenphongban_en)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class