Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLCN_CONGNO_THANHTOANDA

    Implements IQLCN_CONGNO_THANHTOANDA

    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Khachhang As String) As System.Collections.Generic.List(Of CM.QLCN_CONGNO_THANHTOANEntity) Implements IQLCN_CONGNO_THANHTOANDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLCN_CONGNO_THANHTOANEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLCN_CONGNO_THANHTOANEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLCN_CONGNO_THANHTOANEntity)
                With lstobj(i)
                    .uId_Congno_Thanhtoan = IIf(IsDBNull(objReader("uId_Congno_Thanhtoan")) = True, "", Convert.ToString(objReader("uId_Congno_Thanhtoan")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Phieuthuchi = IIf(IsDBNull(objReader("uId_Phieuthuchi")) = True, "", Convert.ToString(objReader("uId_Phieuthuchi")))
                    .f_Sotien_Nolai = IIf(IsDBNull(objReader("f_Sotien_Nolai")) = True, 0, objReader("f_Sotien_Nolai"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLCN_CONGNO_THANHTOANEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String) As System.Data.DataTable Implements IQLCN_CONGNO_THANHTOANDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_SelectAll]"
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
    Public Function SelectByID(ByVal uId_Congno_Thanhtoan As String) As CM.QLCN_CONGNO_THANHTOANEntity Implements IQLCN_CONGNO_THANHTOANDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLCN_CONGNO_THANHTOANEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congno_Thanhtoan", DbType.String, uId_Congno_Thanhtoan)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLCN_CONGNO_THANHTOANEntity
            If objReader.Read Then
                With obj
                    .uId_Congno_Thanhtoan = IIf(IsDBNull(objReader("uId_Congno_Thanhtoan")) = True, "", Convert.ToString(objReader("uId_Congno_Thanhtoan")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Phieuthuchi = IIf(IsDBNull(objReader("uId_Phieuthuchi")) = True, "", Convert.ToString(objReader("uId_Phieuthuchi")))
                    .uId_Phieuno = IIf(IsDBNull(objReader("uId_Phieuno")) = True, "", Convert.ToString(objReader("uId_Phieuno")))
                    .f_Sotien_Nolai = IIf(IsDBNull(objReader("f_Sotien_Nolai")) = True, 0, objReader("f_Sotien_Nolai"))
                    .vTypeThanhToan = IIf(IsDBNull(objReader("vTypeThanhToan")) = True, "", objReader("vTypeThanhToan"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLCN_CONGNO_THANHTOANEntity
        End Try
    End Function
    Public Function SelectByIDPTC(ByVal uId_Phieuthuchi As String) As CM.QLCN_CONGNO_THANHTOANEntity Implements IQLCN_CONGNO_THANHTOANDA.SelectByIDPTC
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_SelectByIDPTC]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLCN_CONGNO_THANHTOANEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", DbType.String, uId_Phieuthuchi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLCN_CONGNO_THANHTOANEntity
            If objReader.Read Then
                With obj
                    .uId_Congno_Thanhtoan = IIf(IsDBNull(objReader("uId_Congno_Thanhtoan")) = True, "", Convert.ToString(objReader("uId_Congno_Thanhtoan")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Phieuthuchi = IIf(IsDBNull(objReader("uId_Phieuthuchi")) = True, "", Convert.ToString(objReader("uId_Phieuthuchi")))
                    .f_Sotien_Nolai = IIf(IsDBNull(objReader("f_Sotien_Nolai")) = True, 0, objReader("f_Sotien_Nolai"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLCN_CONGNO_THANHTOANEntity
        End Try
    End Function
    Public Function Insert(ByVal obj As CM.QLCN_CONGNO_THANHTOANEntity) As String Implements IQLCN_CONGNO_THANHTOANDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", DbType.String, obj.uId_Phieuthuchi)
            db.AddInParameter(objCmd, "@f_Sotien_Nolai", DbType.Double, obj.f_Sotien_Nolai)
            db.AddInParameter(objCmd, "@uId_Phieuno", DbType.String, obj.uId_Phieuno)
            db.AddInParameter(objCmd, "@vTypeThanhToan", DbType.String, obj.vTypeThanhToan)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Congno_Thanhtoan As String) As Boolean Implements IQLCN_CONGNO_THANHTOANDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congno_Thanhtoan", DbType.String, uId_Congno_Thanhtoan)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLCN_CONGNO_THANHTOANEntity) As Boolean Implements IQLCN_CONGNO_THANHTOANDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Congno_Thanhtoan", DbType.String, obj.uId_Congno_Thanhtoan)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieuthuchi", DbType.String, obj.uId_Phieuthuchi)
            db.AddInParameter(objCmd, "@f_Sotien_Nolai", DbType.Double, obj.f_Sotien_Nolai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectByIDPDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable Implements IQLCN_CONGNO_THANHTOANDA.SelectByIDPDV
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_SelectByIDPDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID_PDV(uId_Phieudichvu As String) As DataTable Implements IQLCN_CONGNO_THANHTOANDA.SelectByID_PDV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_QLTC_CONGNO_TT_SelectByID_PDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectCongnoTTByDate(ngay As Date) As DataTable Implements IQLCN_CONGNO_THANHTOANDA.SelectCongnoTTByDate
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_THANHTOAN_SelectByDate]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Ngay", DbType.String, ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class