Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_TTV_THECHUYENTIEN_LICHSUDA
    Implements iclsD_TTV_THECHUYENTIEN_LICHSUDA

    Private log As New LogError.ShowError

    Public Function Insert(obj As CM.icls_TTV_THECHUYENTIEN_LICHSUEntity) As Boolean Implements iclsD_TTV_THECHUYENTIEN_LICHSUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Ngaychuyen", DbType.String, obj.d_Ngaychuyen)
            db.AddInParameter(objCmd, "	@v_Ghichu", DbType.String, obj.v_Ghichu)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String) As DataTable Implements iclsD_TTV_THECHUYENTIEN_LICHSUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TTV_THECHUYENTIENLICHSU_SelectByIDKH]"
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
