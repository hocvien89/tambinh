Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_MKT_SALES
    Implements iclsD_MKT_SALES
    Private log As New LogError.ShowError

    Public Function Insert(obj As CM.icls_MKT_SALES) As Boolean Implements iclsD_MKT_SALES.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_SALES_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenchuongtrinh_vn", DbType.String, obj.nv_Tenchuongtrinh_vn)
            db.AddInParameter(objCmd, "@f_Giamgia_percent", DbType.Int16, obj.f_Giamgia_percent)
            db.AddInParameter(objCmd, "@f_Giamgia_money", DbType.Int32, obj.f_Giamgia_money)
            db.AddInParameter(objCmd, "@d_Start", DbType.DateTime, obj.d_Start)
            db.AddInParameter(objCmd, "@d_End", DbType.DateTime, obj.d_End)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Select_All_Table() As DataTable Implements iclsD_MKT_SALES.Select_All_Table
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_SALE_Select_All_Table]"
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

    Public Function DeleteByID(uId_Sale As String) As Boolean Implements iclsD_MKT_SALES.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_SALES_Delete_ById]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Sale", DbType.String, uId_Sale)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Select_ByID(uId_Sale As String) As DataTable Implements iclsD_MKT_SALES.Select_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_SALE_Select_ById]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Sale", DbType.String, uId_Sale)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Update(obj As CM.icls_MKT_SALES) As Boolean Implements iclsD_MKT_SALES.Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_SALES_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Sale", DbType.String, obj.uId_Sale)
            db.AddInParameter(objCmd, "@nv_Tenchuongtrinh_vn", DbType.String, obj.nv_Tenchuongtrinh_vn)
            db.AddInParameter(objCmd, "@f_Giamgia_percent", DbType.Int16, obj.f_Giamgia_percent)
            db.AddInParameter(objCmd, "@f_Giamgia_money", DbType.Int32, obj.f_Giamgia_money)
            db.AddInParameter(objCmd, "@d_Start", DbType.DateTime, obj.d_Start)
            db.AddInParameter(objCmd, "@d_End", DbType.DateTime, obj.d_End)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Search_By_Date(d_Tungay As Date, d_Denngay As Date) As DataTable Implements iclsD_MKT_SALES.Search_By_Date
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_Sale_Search_By_Date]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.DateTime, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.DateTime, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Khuyenmai_Defualt() As DataTable Implements iclsD_MKT_SALES.Select_Khuyenmai_Defualt
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Khuyenmai_Default]"
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
End Class
