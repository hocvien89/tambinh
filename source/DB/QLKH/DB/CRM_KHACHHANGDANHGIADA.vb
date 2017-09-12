Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_KHACHHANGDANHGIADA

    Implements ICRM_KHACHHANGDANHGIADA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_KHACHHANGDANHGIAEntity) Implements ICRM_KHACHHANGDANHGIADA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_KHACHHANGDANHGIAEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_KHACHHANGDANHGIAEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_KHACHHANGDANHGIAEntity)
                With lstobj(i)
                    .uId_KhachhangDanhgia = IIf(IsDBNull(objReader("uId_KhachhangDanhgia")) = True, "", Convert.ToString(objReader("uId_KhachhangDanhgia")))
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Danhgia = IIf(IsDBNull(objReader("uId_Danhgia")) = True, "", Convert.ToString(objReader("uId_Danhgia")))
                    .f_Mucdanhgia = IIf(IsDBNull(objReader("f_Mucdanhgia")) = True, 0, objReader("f_Mucdanhgia"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_KHACHHANGDANHGIAEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ICRM_KHACHHANGDANHGIADA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_SelectAll]"
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
    Public Function SelectByIDPDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements ICRM_KHACHHANGDANHGIADA.SelectByIDPDV
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_SelectByIDPDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", System.Data.DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function BaocaoKHdanhgia(ByVal uId_Cuahang As String, ByVal Tungay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements ICRM_KHACHHANGDANHGIADA.BaocaoKHdanhgia
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Danhgia_Thongke]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", System.Data.DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Tungay", System.Data.DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", System.Data.DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByID(ByVal uId_KhachhangDanhgia As String) As CM.CRM_KHACHHANGDANHGIAEntity Implements ICRM_KHACHHANGDANHGIADA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_KHACHHANGDANHGIAEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KhachhangDanhgia", System.Data.DbType.String, uId_KhachhangDanhgia)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_KHACHHANGDANHGIAEntity
            If objReader.Read Then
                With obj
                    .uId_KhachhangDanhgia = IIf(IsDBNull(objReader("uId_KhachhangDanhgia")) = True, "", Convert.ToString(objReader("uId_KhachhangDanhgia")))
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_Danhgia = IIf(IsDBNull(objReader("uId_Danhgia")) = True, "", Convert.ToString(objReader("uId_Danhgia")))
                    .f_Mucdanhgia = IIf(IsDBNull(objReader("f_Mucdanhgia")) = True, 0, objReader("f_Mucdanhgia"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_KHACHHANGDANHGIAEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_KHACHHANGDANHGIAEntity) As Boolean Implements ICRM_KHACHHANGDANHGIADA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Danhgia", DbType.String, obj.uId_Danhgia)
            db.AddInParameter(objCmd, "@f_Mucdanhgia", DbType.Int16, obj.f_Mucdanhgia)
            db.AddInParameter(objCmd, "@nv_ghichu", DbType.String, obj.nv_ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_KhachhangDanhgia As String) As Boolean Implements ICRM_KHACHHANGDANHGIADA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KhachhangDanhgia", DbType.String, uId_KhachhangDanhgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CRM_KHACHHANGDANHGIAEntity) As Boolean Implements ICRM_KHACHHANGDANHGIADA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_KHACHHANGDANHGIA_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KhachhangDanhgia", DbType.String, obj.uId_KhachhangDanhgia)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Danhgia", DbType.String, obj.uId_Danhgia)
            db.AddInParameter(objCmd, "@f_Mucdanhgia", DbType.Int16, obj.f_Mucdanhgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class