Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_QUANHEGIADINHDA

    Implements ICRM_QUANHEGIADINHDA

    Private log As New LogError.ShowError


    Public Function Insert(ByVal obj As CM.CRM_QUANHEGIADINHEntity) As Boolean Implements ICRM_QUANHEGIADINHDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_QUANHEGIADINH_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_MaQuanhe", DbType.String, obj.v_MaQuanhe)
            db.AddInParameter(objCmd, "@nv_Hoten", DbType.String, obj.nv_Hoten)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Quanhe As String) As Boolean Implements ICRM_QUANHEGIADINHDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_QUANHEGIADINH_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Quanhe", DbType.String, uId_Quanhe)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByIdKH(ByVal uId_Khachhang As String) As System.Data.DataTable Implements ICRM_QUANHEGIADINHDA.SelectByIdKH
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_QUANHEGIADINH_SelectByIdKH]"
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
End Class