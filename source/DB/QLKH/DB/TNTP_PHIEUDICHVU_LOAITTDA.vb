Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_PHIEUDICHVU_LOAITTDA

    Implements ITNTP_PHIEUDICHVU_LOAITTDA


    Private log As New LogError.ShowError

    Public Function SelectByPhieuDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_LOAITTDA.SelectByPhieuDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_LOAITT_SelectByPhieuDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", System.Data.DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_LOAITTEntity) As Boolean Implements ITNTP_PHIEUDICHVU_LOAITTDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_LOAITT_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, obj.uId_LoaiTT)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.AddInParameter(objCmd, "@v_Maso", DbType.String, obj.v_Maso)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phieudichvu As String, ByVal uId_LoaiTT As String) As Boolean Implements ITNTP_PHIEUDICHVU_LOAITTDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_LOAITT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_LoaiTT", DbType.String, uId_LoaiTT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectTongtien(ByVal uId_Phieudichvu As String) As String Implements ITNTP_PHIEUDICHVU_LOAITTDA.SelectTongtien
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_LOAITT_SelectTongTien]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function QLTC_LoaiHinhTT_SelectByMa(ByVal v_MaLoaiTT As String) As String Implements ITNTP_PHIEUDICHVU_LOAITTDA.QLTC_LoaiHinhTT_SelectByMa
        Dim db As Database
        Dim sp As String = "[dbo].[spQLTC_LoaiHinhTT_SelectByMa]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaLoaiTT", DbType.String, v_MaLoaiTT)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllByMaThe(ByVal vMaBarcode As String) As System.Data.DataTable Implements ITNTP_PHIEUDICHVU_LOAITTDA.SelectAllByMaThe
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_LOAITT_SelectAll_ByMaThe]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Maso", System.Data.DbType.String, vMaBarcode)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function updatesotien(uId_LoaiTT As String, uId_Phieudichvu As String, f_Sotien As Double) As Boolean Implements ITNTP_PHIEUDICHVU_LOAITTDA.updatesotien
        Dim db As Database
        Dim sp As String = "[dbo].[spDVLoaiTT_Update_Sotien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiTT", System.Data.DbType.String, uId_LoaiTT)
            db.AddInParameter(objCmd, "@uId_Dichvu", System.Data.DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@f_Sotien", System.Data.DbType.String, f_Sotien)
            objDs = db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function LoaiTT_SelectByID(uId_Phieudichvu As String) As DataTable Implements ITNTP_PHIEUDICHVU_LOAITTDA.LoaiTT_SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_bindloaihinhTT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", System.Data.DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function
End Class