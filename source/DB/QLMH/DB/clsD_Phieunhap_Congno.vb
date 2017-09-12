Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_Phieunhap_Congno
    Implements iClsD_Phieunhap_Congno

    Public Function Insert(objEnPhieunhapCn As CM.cls_Phieunhap_Congno) As String Implements iClsD_Phieunhap_Congno.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CONGNO_Insert]"
        Dim objCmd As DbCommand
        Dim uId_Phieunhap_Congno As String = ""
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, objEnPhieunhapCn.uId_Phieunhap)
            db.AddInParameter(objCmd, "@uId_Thuchi", DbType.String, objEnPhieunhapCn.uId_Thuchi)
            db.AddInParameter(objCmd, "@f_Tienno", DbType.Double, objEnPhieunhapCn.f_Tienno)
            uId_Phieunhap_Congno = db.ExecuteNonQuery(objCmd)
        Catch ex As Exception

        End Try
        Return uId_Phieunhap_Congno
    End Function

    Public Function UpdateTienno(uId_Phieunhap As String, f_Tienno As Double) As Double Implements iClsD_Phieunhap_Congno.UpdateTienno
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CONGNO_UpdateTienno]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieunhap", DbType.String, uId_Phieunhap)
            db.AddInParameter(objCmd, "@f_Tienno", DbType.Double, f_Tienno)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception

        End Try
    End Function

    Public Function SelectByuIdPhieunhap(uId_Phieunhap As String) As DataTable Implements iClsD_Phieunhap_Congno.SelectByuIdPhieunhap
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_PHIEUNHAP_CONGNO_SelectByuIdPhieunhap]"
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
End Class
