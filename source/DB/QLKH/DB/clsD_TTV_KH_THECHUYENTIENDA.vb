Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_TTV_KH_THECHUYENTIENDA
    Implements iclsD_TTV_KH_THECHUYENTIENDA



    Private log As New LogError.ShowError
    'Public Function Insert(obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Phieudichvu_Chitiet As String) As Boolean Implements iclsD_TTV_KH_THECHUYENTIENDA.Insert
    '    Dim db As Database
    '    Dim sp As String = "[dbo].[sp_TTV_KH_THECHUYENTIEN_Insert]"
    '    Dim objCmd As DbCommand
    '    Try
    '        db = DatabaseFactory.CreateDatabase()
    '        objCmd = db.GetStoredProcCommand(sp)
    '        db.AddInParameter(objCmd, "@uId_Phieudichvuchitiet", DbType.String, uId_Phieudichvu_Chitiet)
    '        db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
    '        db.AddInParameter(objCmd, "@Sotien", DbType.String, obj.f_Sotien)
    '        db.AddInParameter(objCmd, "@v_Ghichu", DbType.String, obj.v_Ghichu)
    '        db.AddInParameter(objCmd, "@Ngaychuyen", DbType.DateTime, obj.d_Ngaychuyen)
    '        Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
    '    Catch ex As Exception
    '        log.WriteLog(sp, ex.Message)
    '        Return False
    '    End Try
    'End Function
    Public Function SelectAllTable() As System.Data.DataTable Implements iclsD_TTV_KH_THECHUYENTIENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_KH_Thechuyentien_SelectAll]"
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
    Public Function Update(obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Phieuchitiet As String, ByVal uId_Khachhang As String) As Boolean Implements iclsD_TTV_KH_THECHUYENTIENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_KH_THECHUYENTIEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvuchitiet", DbType.String, uId_Phieuchitiet)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)

            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try

    End Function

    Public Function SelectByID(uId_Khachhang As String) As CM.icls_TTV_KH_THECHUYENTIENEntity Implements iclsD_TTV_KH_THECHUYENTIENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spThechuyentien_SelectByIdKH]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.cls_TTV_KH_THECHUYENTIENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", System.Data.DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.cls_TTV_KH_THECHUYENTIENEntity
            If objReader.Read Then
                With obj
                    .uId_Thechuyentien = IIf(IsDBNull(objReader("uId_Thechuyentien")) = True, False, Convert.ToString(objReader("uId_Thechuyentien")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.cls_TTV_KH_THECHUYENTIENEntity
        End Try
    End Function


    Public Function Update_NT(obj As CM.icls_TTV_KH_THECHUYENTIENEntity, uId_Thechuyentien As String) As Object Implements iclsD_TTV_KH_THECHUYENTIENDA.Update_NT
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_KH_THECHUYENTIEN_Update_NT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thechuyentien", DbType.String, uId_Thechuyentien)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try

    End Function

    Public Function Update_TT(obj As CM.icls_TTV_KH_THECHUYENTIENEntity, uId_Khachhang As String, Gioihan As Integer) As Object Implements iclsD_TTV_KH_THECHUYENTIENDA.Update_TT
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_THECHUYENTIEN_Update_TT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@GT", DbType.Double, Gioihan)
            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update_LoaiTT(uId_Khachhang As String, uId_Phieudichvu As String) As Object Implements iclsD_TTV_KH_THECHUYENTIENDA.Update_LoaiTT
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_KH_THECHUYENTIEN_Update_TT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)

            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByID_TB(uId_Khachhang As String) As DataTable Implements iclsD_TTV_KH_THECHUYENTIENDA.SelectByID_TB
        Dim db As Database
        Dim sp As String = "[dbo].[spThechuyentien_SelectByIdKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Update_Loai_TT_Phieuxuat(uId_Khachhang As String, uId_Phieuxuat As String) As Object Implements iclsD_TTV_KH_THECHUYENTIENDA.Update_Loai_TT_Phieuxuat
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_KH_THECHUYENTIEN_Update_TT_Phieuxuat]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, uId_Phieuxuat)

            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class
