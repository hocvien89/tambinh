Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class CRM_KhachHang_DoangThuNguonDA
    Implements ICRM_KhachHang_DoangThuNguonDA
    Private log As New LogError.ShowError
    Public Function SelectAllTable(ByVal uId_Cuahang As String, ByVal uId_NguonKH As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements ICRM_KhachHang_DoangThuNguonDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[spCRM_DM_Khachhang_DoanhThuNguon]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Nguon", DbType.String, uId_NguonKH)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
