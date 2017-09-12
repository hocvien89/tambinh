Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_TTV_KH_THETICHDIEMDA
    Implements iclsD_TTV_KH_THETICHDIEMDA


    Private log As New LogError.ShowError

    Public Function DeleteById(uId_KH_The As String) As Boolean Implements iclsD_TTV_KH_THETICHDIEMDA.DeleteById
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "uId_KH_The", DbType.String, uId_KH_The)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function Insert(objEnKHThe As CM.icls_TTV_KH_ThetichdiemEntity) As String Implements iclsD_TTV_KH_THETICHDIEMDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, objEnKHThe.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, objEnKHThe.uId_Thetichdiem)
            db.AddInParameter(objCmd, "@f_Tongtichluy", DbType.Double, objEnKHThe.f_Tongtichluy)
            db.AddInParameter(objCmd, "@f_Diemhientai", DbType.Double, objEnKHThe.f_Diemhientai)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.Boolean, objEnKHThe.b_Trangthai)
            db.AddInParameter(objCmd, "@v_Mathekhachhang", DbType.String, objEnKHThe.v_Mathekhachhang)
            db.AddInParameter(objCmd, "@b_Isdelete", DbType.Boolean, objEnKHThe.b_Isdelete)
            db.AddInParameter(objCmd, "@d_Ngaycap", DbType.DateTime, objEnKHThe.d_Ngaycap)
            db.AddInParameter(objCmd, "@d_Ngayhethan", DbType.DateTime, objEnKHThe.d_Ngayhethan)
            Return db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function

    Public Function SelectAllTable() As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_SelectAllTable]"
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
    Public Function Update(objEnKHThe As CM.icls_TTV_KH_ThetichdiemEntity) As Boolean Implements iclsD_TTV_KH_THETICHDIEMDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_The", DbType.String, objEnKHThe.uId_KH_The)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, objEnKHThe.uId_Thetichdiem)
            db.AddInParameter(objCmd, "@v_Mathekhachhang", DbType.String, objEnKHThe.v_Mathekhachhang)
            db.AddInParameter(objCmd, "@d_Ngayhethan", DbType.DateTime, objEnKHThe.d_Ngayhethan)
            db.AddInParameter(objCmd, "@d_Ngaykichhoat", DbType.DateTime, objEnKHThe.d_Ngaycap)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function SelectKHThe(uId_Cuahang As String) As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.SelectKHThe
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_SelectKHThe]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function CheckKH(uId_Khachhang As String) As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.CheckKH
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_CheckKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function UpdatePoint(f_Tongtichluy As Double, f_Diemhientai As Double, uid_KHThe As String) As Boolean Implements iclsD_TTV_KH_THETICHDIEMDA.UpdatePoint
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_UpdatePoint]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_The", DbType.String, uid_KHThe)
            db.AddInParameter(objCmd, "@f_Tongtichluy", DbType.Double, f_Tongtichluy)
            db.AddInParameter(objCmd, "@f_Diemhientai", DbType.Double, f_Diemhientai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception

        End Try

    End Function

    Public Function CheckMathe() As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.CheckMathe
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_CheckMathe]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Function SelectPointById(uid_KH_The As String) As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.SelectPointById
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_SelectPointById]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_The", DbType.String, uid_KH_The)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Function Khoathe(uid_kh_the As String, b_trangthai As Boolean) As Boolean Implements iclsD_TTV_KH_THETICHDIEMDA.Khoathe
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_Khoathe]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_The", DbType.String, uid_kh_the)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.String, b_trangthai)
            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
        End Try
    End Function

    Function Huythe(uid_kh_the As String, b_isdelete As Boolean) As Boolean Implements iclsD_TTV_KH_THETICHDIEMDA.Huythe
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_Huythe]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_The", DbType.String, uid_kh_the)
            db.AddInParameter(objCmd, "@b_Isdelete", DbType.String, b_isdelete)
            db.ExecuteNonQuery(objCmd)
        Catch ex As Exception
        End Try
    End Function

    Public Function SelectByIdKH(uId_Khachhang As String) As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.SelectByIdKH
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_KH_THETICHDIEM_SelectByIdKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectName(uId_Khachhang As String) As DataTable Implements iclsD_TTV_KH_THETICHDIEMDA.SelectName
        Dim db As Database
        Dim sp As String = "[dbo].[sp_SelectNameByIDKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
End Class
