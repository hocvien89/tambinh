Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class BaoCaoQLMH
    Implements iclsD_BaocaoQLMH


    Private log As New LogError.ShowError

    Public Function SelectTonghopNhap(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaocaoQLMH.SelectTonghopNhap
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Tonghop_Nhap]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTonghopXuat(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaocaoQLMH.SelectTonghopXuat
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Tonghop_Xuat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function TheKho(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Mathang As String, ByVal uId_Kho As String) As System.Data.DataTable Implements iclsD_BaocaoQLMH.TheKho
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TheKho]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, uId_Mathang)
            db.AddInParameter(objCmd, "@MaKho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BaoCaoVTTH(ByVal uId_Kho As String, ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Phongban As String) As System.Data.DataTable Implements iclsD_BaocaoQLMH.BaoCaoVTTH
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_VATTUTIEUHAO_BaocaoVTTH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, uId_Phongban)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    'xuanhieu190115
    Public Function BaocaoHansudung(uid_Cuahang As String, uId_Kho As String) As DataTable Implements iclsD_BaocaoQLMH.BaocaoHansudung
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_MATHANG_HANSUDUNG]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uid_Cuahang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
