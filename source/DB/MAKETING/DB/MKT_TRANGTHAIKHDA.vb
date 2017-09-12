Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_TRANGTHAIKHDA

    Implements IMKT_TRANGTHAIKHDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_TRANGTHAIKHEntity) Implements IMKT_TRANGTHAIKHDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_TRANGTHAIKH_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_TRANGTHAIKHEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_TRANGTHAIKHEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_TRANGTHAIKHEntity)
                With lstobj(i)
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                    .nv_TenTrangthaiKH_vn = IIf(IsDBNull(objReader("nv_TenTrangthaiKH_vn")) = True, "", objReader("nv_TenTrangthaiKH_vn"))
                    .nv_TenTrangthaiKH_en = IIf(IsDBNull(objReader("nv_TenTrangthaiKH_en")) = True, "", objReader("nv_TenTrangthaiKH_en"))
                    .i_SoThuTu = IIf(IsDBNull(objReader("i_SoThuTu")) = True, 0, objReader("i_SoThuTu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_TRANGTHAIKHEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IMKT_TRANGTHAIKHDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_TRANGTHAIKH_SelectAll]"
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

    Public Function SelectByID(ByVal uId_TrangthaiKH As String) As CM.MKT_TRANGTHAIKHEntity Implements IMKT_TRANGTHAIKHDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_TRANGTHAIKH_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_TRANGTHAIKHEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", System.Data.DbType.String, uId_TrangthaiKH)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_TRANGTHAIKHEntity
            If objReader.Read Then
                With obj
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                    .nv_TenTrangthaiKH_vn = IIf(IsDBNull(objReader("nv_TenTrangthaiKH_vn")) = True, "", objReader("nv_TenTrangthaiKH_vn"))
                    .nv_TenTrangthaiKH_en = IIf(IsDBNull(objReader("nv_TenTrangthaiKH_en")) = True, "", objReader("nv_TenTrangthaiKH_en"))
                    .i_SoThuTu = IIf(IsDBNull(objReader("i_SoThuTu")) = True, 0, objReader("i_SoThuTu"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_TRANGTHAIKHEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_TRANGTHAIKHEntity) As Boolean Implements IMKT_TRANGTHAIKHDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_TRANGTHAIKH_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenTrangthaiKH_vn", DbType.String, obj.nv_TenTrangthaiKH_vn)
            db.AddInParameter(objCmd, "@nv_TenTrangthaiKH_en", DbType.String, obj.nv_TenTrangthaiKH_en)
            db.AddInParameter(objCmd, "@i_SoThuTu", DbType.Int32, obj.i_SoThuTu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_TrangthaiKH As String) As Boolean Implements IMKT_TRANGTHAIKHDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_TRANGTHAIKH_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", DbType.String, uId_TrangthaiKH)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_TRANGTHAIKHEntity) As Boolean Implements IMKT_TRANGTHAIKHDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_TRANGTHAIKH_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", DbType.String, obj.uId_TrangthaiKH)
            db.AddInParameter(objCmd, "@nv_TenTrangthaiKH_vn", DbType.String, obj.nv_TenTrangthaiKH_vn)
            db.AddInParameter(objCmd, "@nv_TenTrangthaiKH_en", DbType.String, obj.nv_TenTrangthaiKH_en)
            db.AddInParameter(objCmd, "@i_SoThuTu", DbType.Int32, obj.i_SoThuTu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class