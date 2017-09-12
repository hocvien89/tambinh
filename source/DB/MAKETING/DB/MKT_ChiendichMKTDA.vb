Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_ChiendichMKTDA

    Implements IMKT_ChiendichMKTDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_ChiendichMKTEntity) Implements IMKT_ChiendichMKTDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_ChiendichMKTEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_ChiendichMKTEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_ChiendichMKTEntity)
                With lstobj(i)
                    .uId_ChiendichMKT = IIf(IsDBNull(objReader("uId_ChiendichMKT")) = True, "", Convert.ToString(objReader("uId_ChiendichMKT")))
                    .nv_TenChiendichMKT = IIf(IsDBNull(objReader("nv_TenChiendichMKT")) = True, "", objReader("nv_TenChiendichMKT"))
                    .d_NgayBD = IIf(IsDBNull(objReader("d_NgayBD")) = True, Nothing, objReader("d_NgayBD"))
                    .d_NgayKT = IIf(IsDBNull(objReader("d_NgayKT")) = True, Nothing, objReader("d_NgayKT"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_ChiendichMKTEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IMKT_ChiendichMKTDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_SelectAll]"
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

    Public Function SelectByID(ByVal uId_ChiendichMKT As String) As CM.MKT_ChiendichMKTEntity Implements IMKT_ChiendichMKTDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_ChiendichMKTEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", System.Data.DbType.String, uId_ChiendichMKT)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_ChiendichMKTEntity
            If objReader.Read Then
                With obj
                    .uId_ChiendichMKT = IIf(IsDBNull(objReader("uId_ChiendichMKT")) = True, "", Convert.ToString(objReader("uId_ChiendichMKT")))
                    .nv_TenChiendichMKT = IIf(IsDBNull(objReader("nv_TenChiendichMKT")) = True, "", objReader("nv_TenChiendichMKT"))
                    .d_NgayBD = IIf(IsDBNull(objReader("d_NgayBD")) = True, Nothing, objReader("d_NgayBD"))
                    .d_NgayKT = IIf(IsDBNull(objReader("d_NgayKT")) = True, Nothing, objReader("d_NgayKT"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .nv_Noidung = IIf(IsDBNull(objReader("nv_Noidung")) = True, "", objReader("nv_Noidung"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_ChiendichMKTEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_ChiendichMKTEntity) As String Implements IMKT_ChiendichMKTDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_Insert]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenChiendichMKT", DbType.String, obj.nv_TenChiendichMKT)
            If (obj.d_NgayBD <> Nothing And obj.d_NgayBD <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayBD", DbType.DateTime, obj.d_NgayBD)
            End If
            If (obj.d_NgayKT <> Nothing And obj.d_NgayKT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayKT", DbType.DateTime, obj.d_NgayKT)
            End If
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_ChiendichMKT As String) As Boolean Implements IMKT_ChiendichMKTDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", DbType.String, uId_ChiendichMKT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_ChiendichMKTEntity) As Boolean Implements IMKT_ChiendichMKTDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", DbType.String, obj.uId_ChiendichMKT)
            db.AddInParameter(objCmd, "@nv_TenChiendichMKT", DbType.String, obj.nv_TenChiendichMKT)
            If (obj.d_NgayBD <> Nothing And obj.d_NgayBD <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayBD", DbType.DateTime, obj.d_NgayBD)
            End If
            If (obj.d_NgayKT <> Nothing And obj.d_NgayKT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayKT", DbType.DateTime, obj.d_NgayKT)
            End If
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Timkiem(ByVal obj As CM.MKT_ChiendichMKTEntity) As System.Data.DataTable Implements IMKT_ChiendichMKTDA.Timkiem
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_Timkiem]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenChiendichMKT", DbType.String, obj.nv_TenChiendichMKT)
            db.AddInParameter(objCmd, "@nv_Noidung", DbType.String, obj.nv_Noidung)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectAll_KH(ByVal uId_ChiendichMKT As String) As System.Data.DataTable Implements IMKT_ChiendichMKTDA.SelectAll_KH
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_ChiendichMKT_SELECTALL_KH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", DbType.String, uId_ChiendichMKT)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function BaocaoTrangthai(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable Implements IMKT_ChiendichMKTDA.BaocaoTrangthai
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_MKT_TRANGTHAI_KH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function BaocaoDoanhthu(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable Implements IMKT_ChiendichMKTDA.BaocaoDoanhthu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_MKT_DOANHTHU_CHIENDICH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (Tungay <> Nothing And Tungay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            End If
            If (Denngay <> Nothing And Denngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            End If
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class