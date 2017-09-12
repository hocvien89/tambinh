Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_TTV_KH_THETICHDIEM_LICHSUDA
    Implements iclsD_TTV_KH_THETICHDIEM_LICHSUDA
    Dim log As LogError.ShowError
    Public Function Insert(obj As CM.iCls_TTV_KH_Thetichdiem_LichsuEntity) As Boolean Implements iclsD_TTV_KH_THETICHDIEM_LICHSUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_LICHSU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "uId_KH_The", DbType.String, obj.uId_KH_The)
            db.AddInParameter(objCmd, "nv_Noidung", DbType.String, obj.nv_Noidung)
            db.AddInParameter(objCmd, "d_Ngaythuchien", DbType.Date, obj.d_Ngaythuchien)
            db.AddInParameter(objCmd, "b_Luachon", DbType.Boolean, obj.b_Luachon)
            db.AddInParameter(objCmd, "uId_Sukien", DbType.String, obj.uId_Sukien)
            db.AddInParameter(objCmd, "f_Diem", DbType.Double, obj.f_Diem)
            db.AddInParameter(objCmd, "uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function SelectAllTable(uid_KH_The As String) As DataTable Implements iclsD_TTV_KH_THETICHDIEM_LICHSUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_LICHSU_SelectAllTable]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "uId_KH_The", DbType.String, uid_KH_The)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
