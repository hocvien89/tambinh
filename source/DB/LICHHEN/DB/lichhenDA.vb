Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class lichhenDA
    Implements IlichhenDA
    Private log As New LogError.ShowError
    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IlichhenDA.SelectAllTable
        Dim dbtime As Database
        Dim sptime As String = "[dbo].[spCRM_LICHHEN_KHOANGTG_Selectall]"
        Dim objCmdtime As DbCommand
        Dim objDstime As DataSet
        Dim tugio As Integer
        Dim dengio As Integer
        Dim khoang As Integer
        Try
            dbtime = DatabaseFactory.CreateDatabase()
            objCmdtime = dbtime.GetStoredProcCommand(sptime)
            objDstime = dbtime.ExecuteDataSet(objCmdtime)
            Dim tbtime As DataTable = objDstime.Tables(0)
            tugio = tbtime.Rows(0)(1)
            dengio = tbtime.Rows(0)(2)
            khoang = tbtime.Rows(0)(3)
        Catch ex As Exception
            log.WriteLog(sptime, ex.Message)
        End Try
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectAllBuffer]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tugio", DbType.Int32, tugio)
            db.AddInParameter(objCmd, "@Dengio", DbType.Int32, dengio)
            db.AddInParameter(objCmd, "@Khoang", DbType.Int32, khoang)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectbyDateS(ByVal ngay As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IlichhenDA.SelectbyDateS
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectbyDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        Dim d_Ngay As DateTime = Convert.ToDateTime(ngay, sFormat)
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@ngay", DbType.DateTime, d_Ngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectDate(ByVal strStartdate As String, ByVal strEnddate As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IlichhenDA.SelectDate
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        Dim d_Ngaybd As DateTime = Convert.ToDateTime(strStartdate, sFormat)
        Dim d_Ngaykt As DateTime = Convert.ToDateTime(strEnddate, sFormat)
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Ngaybd)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, d_Ngaykt)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectDatePhong(ByVal strStartdate As String, ByVal strEnddate As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IlichhenDA.SelectDatePhong
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_SelectDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        Dim d_Ngaybd As DateTime = Convert.ToDateTime(strStartdate, sFormat)
        Dim d_Ngaykt As DateTime = Convert.ToDateTime(strEnddate, sFormat)
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Ngaybd)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, d_Ngaykt)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectThongke(ByVal strStartdate As String, ByVal strEnddate As String) As System.Data.DataTable Implements IlichhenDA.SelectThongke
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_SelectAll_NV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        Dim d_Ngaybd As DateTime = Convert.ToDateTime(strStartdate, sFormat)
        Dim d_Ngaykt As DateTime = Convert.ToDateTime(strEnddate, sFormat)
        Dim dtAll As DataTable
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Ngaybd)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, d_Ngaykt)
            objDs = db.ExecuteDataSet(objCmd)
            dtAll = objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            dtAll = New DataTable
            Return New DataTable
        End Try
        Dim spIdNV As String = "[dbo].[spCRM_LICHHEN_Thongke]"
        Dim dt As New DataTable
        Dim struIdNV As String
        If dtAll.Rows.Count > 0 Then
            Try
                struIdNV = dtAll.Rows(0)("uId_Nhanvien").ToString
                db = DatabaseFactory.CreateDatabase()
                objCmd = db.GetStoredProcCommand(spIdNV)
                db.AddInParameter(objCmd, "@uId_nv", DbType.String, struIdNV)
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Ngaybd)
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, d_Ngaykt)
                objDs = db.ExecuteDataSet(objCmd)
                dt = objDs.Tables(0)
            Catch ex As Exception
                log.WriteLog(sp, ex.Message)
                Return New DataTable
            End Try
            Dim i As Integer = 1
            While (i < dtAll.Rows.Count)
                struIdNV = dtAll.Rows(i)("uId_Nhanvien").ToString
                Try
                    db = DatabaseFactory.CreateDatabase()
                    objCmd = db.GetStoredProcCommand(spIdNV)
                    db.AddInParameter(objCmd, "@uId_nv", DbType.String, struIdNV)
                    db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, d_Ngaybd)
                    db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, d_Ngaykt)
                    objDs = db.ExecuteDataSet(objCmd)
                    dt.ImportRow(objDs.Tables(0).Rows(0))
                Catch ex As Exception
                    log.WriteLog(sp, ex.Message)
                    Return New DataTable
                End Try
                i += 1
            End While

        End If
        Return dt
    End Function
End Class
