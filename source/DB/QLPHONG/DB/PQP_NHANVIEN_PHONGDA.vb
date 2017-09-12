Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class PQP_NHANVIEN_PHONGDA

    Implements IPQP_NHANVIEN_PHONGDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.PQP_NHANVIEN_PHONGEntity) Implements IPQP_NHANVIEN_PHONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.PQP_NHANVIEN_PHONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.PQP_NHANVIEN_PHONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.PQP_NHANVIEN_PHONGEntity)
                With lstobj(i)
                    .uId_Nhanvien_Phong = IIf(IsDBNull(objReader("uId_Nhanvien_Phong")) = True, "", Convert.ToString(objReader("uId_Nhanvien_Phong")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.PQP_NHANVIEN_PHONGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IPQP_NHANVIEN_PHONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Nhanvien_Phong As String) As CM.PQP_NHANVIEN_PHONGEntity Implements IPQP_NHANVIEN_PHONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.PQP_NHANVIEN_PHONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien_Phong", System.Data.DbType.String, uId_Nhanvien_Phong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.PQP_NHANVIEN_PHONGEntity
            If objReader.Read Then
                With obj
                    .uId_Nhanvien_Phong = IIf(IsDBNull(objReader("uId_Nhanvien_Phong")) = True, "", Convert.ToString(objReader("uId_Nhanvien_Phong")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.PQP_NHANVIEN_PHONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean Implements IPQP_NHANVIEN_PHONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Nhanvien_Phong As String) As Boolean Implements IPQP_NHANVIEN_PHONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien_Phong", DbType.String, uId_Nhanvien_Phong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean Implements IPQP_NHANVIEN_PHONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien_Phong", DbType.String, obj.uId_Nhanvien_Phong)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectPhongByMaNV(ByVal uId_Nhanvien As String) As CM.PQP_NHANVIEN_PHONGEntity Implements IPQP_NHANVIEN_PHONGDA.SelectPhongByMaNV
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_NHANVIEN_PHONG_SelectPhongTheoMaNV]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.PQP_NHANVIEN_PHONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", System.Data.DbType.String, uId_Nhanvien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.PQP_NHANVIEN_PHONGEntity
            If objReader.Read Then
                With obj
                    .uId_Nhanvien_Phong = IIf(IsDBNull(objReader("uId_Nhanvien_Phong")) = True, "", Convert.ToString(objReader("uId_Nhanvien_Phong")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.PQP_NHANVIEN_PHONGEntity
        End Try
    End Function

    Public Function Update_Table(obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean Implements IPQP_NHANVIEN_PHONGDA.Update_Table
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Update_With_Insert_Nhanvien_Phong]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class