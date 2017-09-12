Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_DM_CALAMVIEC
    Implements iclsD_DM_CALAMVIEC
    Private log As New LogError.ShowError
    Public Function Insert(obj As CM.cls_CALAMVIEC) As Boolean Implements iclsD_DM_CALAMVIEC.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_DM_Calamviec_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            db.AddInParameter(objCmd, "@v_Calamviec", DbType.String, obj.v_Calamviec)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Select_Nhanvien_ByCa(d_Ngay As DateTime, uId_Ca As String) As DataTable Implements iclsD_DM_CALAMVIEC.Select_Nhanvien_ByCa
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_DM_CALAMVIEC]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, uId_Ca)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Delete_ByID(uId_Nhanvien_Ca As String) As Boolean Implements iclsD_DM_CALAMVIEC.Delete_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_DM_CALAMVIEC_Delete_ByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien_Ca", DbType.String, uId_Nhanvien_Ca)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Check_Trungcalamviec(d_Ngay As Date, uId_Nhanvien As String) As DataTable Implements iclsD_DM_CALAMVIEC.Check_Trungcalamviec
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Check_Trung_Lichlamviec_By_Nhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
