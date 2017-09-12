Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_Phieunhap_Congno_Thanhtoan
    Implements iClsD_Phieunhap_Congno_Thanhtoan

    Public Function Insert(objEnPhieunhapCnTt As CM.cls_Phieunhap_Congno_Thanhtoan) As Boolean Implements iClsD_Phieunhap_Congno_Thanhtoan.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CONGNO_THANHTOAN_Inssert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap_Congno", DbType.String, objEnPhieunhapCnTt.uId_Phieunhap_Congno)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", DbType.String, objEnPhieunhapCnTt.uId_Phhieuthuchi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception

        End Try
    End Function

    Public Function SelectAllTable() As DataTable Implements iClsD_Phieunhap_Congno_Thanhtoan.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CONGNO_SelectAllNCC]"
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

    Public Function SelectChitietPhieu(uId_Phieunhap As String) As DataTable Implements iClsD_Phieunhap_Congno_Thanhtoan.SelectChitietPhieu
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_ChitietCN]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uId_Phieunhap)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectCongnoPhieu(uId_Nhacungcap As String) As DataTable Implements iClsD_Phieunhap_Congno_Thanhtoan.SelectCongnoPhieu
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CONGNO_Chitiet]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhacungcap", DbType.String, uId_Nhacungcap)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
End Class
