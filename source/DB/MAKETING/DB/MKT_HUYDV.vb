Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class MKT_HUYDV
    Implements IMKT_HUYDV
    Private log As New LogError.ShowError
    Public Function DeleteByID(ByVal uId_HuyDV As String) As Boolean Implements IMKT_HUYDV.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_HuyDV", DbType.String, uId_HuyDV)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_HUYDV) As Boolean Implements IMKT_HUYDV.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@Date", DbType.String, obj.Date)
            db.AddInParameter(objCmd, "@Ghichu", DbType.String, obj.nv_Ghichu_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable(ByVal tungay As Date, ByVal dengay As Date) As System.Data.DataTable Implements IMKT_HUYDV.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@tungay", DbType.String, tungay)
            db.AddInParameter(objCmd, "@denngay", DbType.String, dengay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_HUYDV) As Boolean Implements IMKT_HUYDV.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@Date", DbType.String, obj.Date)
            db.AddInParameter(objCmd, "@Ghichu", DbType.String, obj.nv_Ghichu_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectKHHuyDV(ByVal tungay As Date, ByVal dengay As Date) As System.Data.DataTable Implements IMKT_HUYDV.SelectKHHuyDV
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_SelectKHHuyDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@tungay", DbType.String, tungay)
            db.AddInParameter(objCmd, "@denngay", DbType.String, dengay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByIdKH(ByVal uId_Khachhang As String) As System.Data.DataTable Implements IMKT_HUYDV.SelectByIdKH
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_SelectByIdKH]"
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

    Public Function SelectKHHuyDV_Search(ByVal keyword As String) As System.Data.DataTable Implements IMKT_HUYDV.SelectKHHuyDV_Search
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_HuyDv_SelectKHHuyDV_Search]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@keyword", DbType.String, keyword)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
