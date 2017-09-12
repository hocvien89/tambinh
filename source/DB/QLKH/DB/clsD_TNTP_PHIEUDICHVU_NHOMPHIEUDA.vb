Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA
    Implements iclsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA

    Private log As New LogError.ShowError
    Public Function SelectAllTable() As System.Data.DataTable Implements iclsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_NHOMPHIEU_SelectAll]"
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

    Public Function BAOCAO_DoanhThu_Nhomphieu(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Id_Nhomphieu As String, ByVal buoitang As Integer) As System.Data.DataTable Implements iclsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA.BAOCAO_DoanhThu_Nhomphieu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThu_LoaiPhieu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Id_Nhomphieu", DbType.Int32, Id_Nhomphieu)
            db.AddInParameter(objCmd, "@buoitang", DbType.Int32, buoitang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
