Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DINHMUC_GIAMATHANGDA

    Implements IQLMH_DINHMUC_GIAMATHANGDA


    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DINHMUC_GIAMATHANGEntity) Implements IQLMH_DINHMUC_GIAMATHANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DINHMUC_GIAMATHANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DINHMUC_GIAMATHANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DINHMUC_GIAMATHANGEntity)
                With lstobj(i)
                    .uId_Dinhmuc_Giamathang = IIf(IsDBNull(objReader("uId_Dinhmuc_Giamathang")) = True, "", Convert.ToString(objReader("uId_Dinhmuc_Giamathang")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Gianhap = IIf(IsDBNull(objReader("f_Gianhap")) = True, 0, objReader("f_Gianhap"))
                    .f_Biendo_Gianhap = IIf(IsDBNull(objReader("f_Biendo_Gianhap")) = True, 0, objReader("f_Biendo_Gianhap"))
                    .f_Giaban = IIf(IsDBNull(objReader("f_Giaban")) = True, 0, objReader("f_Giaban"))
                    .f_Biendo_Giaban = IIf(IsDBNull(objReader("f_Biendo_Giaban")) = True, 0, objReader("f_Biendo_Giaban"))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DINHMUC_GIAMATHANGEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Kho As String, ByVal uId_Nhommathang As String) As System.Data.DataTable Implements IQLMH_DINHMUC_GIAMATHANGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, uId_Nhommathang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Dinhmuc_Giamathang As String) As CM.QLMH_DINHMUC_GIAMATHANGEntity Implements IQLMH_DINHMUC_GIAMATHANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DINHMUC_GIAMATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dinhmuc_Giamathang", System.Data.DbType.String, uId_Dinhmuc_Giamathang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DINHMUC_GIAMATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Dinhmuc_Giamathang = IIf(IsDBNull(objReader("uId_Dinhmuc_Giamathang")) = True, "", Convert.ToString(objReader("uId_Dinhmuc_Giamathang")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Gianhap = IIf(IsDBNull(objReader("f_Gianhap")) = True, 0, objReader("f_Gianhap"))
                    .f_Biendo_Gianhap = IIf(IsDBNull(objReader("f_Biendo_Gianhap")) = True, 0, objReader("f_Biendo_Gianhap"))
                    .f_Giaban = IIf(IsDBNull(objReader("f_Giaban")) = True, 0, objReader("f_Giaban"))
                    .f_Biendo_Giaban = IIf(IsDBNull(objReader("f_Biendo_Giaban")) = True, 0, objReader("f_Biendo_Giaban"))
                    .uId_Kho = IIf(IsDBNull(objReader("uId_Kho")) = True, "", Convert.ToString(objReader("uId_Kho")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DINHMUC_GIAMATHANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DINHMUC_GIAMATHANGEntity) As Boolean Implements IQLMH_DINHMUC_GIAMATHANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@f_Gianhap", DbType.Double, obj.f_Gianhap)
            db.AddInParameter(objCmd, "@f_Biendo_Gianhap", DbType.Double, obj.f_Biendo_Gianhap)
            db.AddInParameter(objCmd, "@f_Giaban", DbType.Double, obj.f_Giaban)
            db.AddInParameter(objCmd, "@f_Biendo_Giaban", DbType.Double, obj.f_Biendo_Giaban)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, obj.uId_Kho)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Dinhmuc_Giamathang As String) As Boolean Implements IQLMH_DINHMUC_GIAMATHANGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dinhmuc_Giamathang", DbType.String, uId_Dinhmuc_Giamathang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DINHMUC_GIAMATHANGEntity) As Boolean Implements IQLMH_DINHMUC_GIAMATHANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dinhmuc_Giamathang", DbType.String, obj.uId_Dinhmuc_Giamathang)

            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@f_Gianhap", DbType.Double, obj.f_Gianhap)
            db.AddInParameter(objCmd, "@f_Biendo_Gianhap", DbType.Double, obj.f_Biendo_Gianhap)
            db.AddInParameter(objCmd, "@f_Giaban", DbType.Double, obj.f_Giaban)
            db.AddInParameter(objCmd, "@f_Biendo_Giaban", DbType.Double, obj.f_Biendo_Giaban)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectTim_ByTensanpham(ByVal uId_Kho As String, ByVal sTensanpham As String) As System.Data.DataTable Implements IQLMH_DINHMUC_GIAMATHANGDA.SelectTim_ByTensanpham
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_SelectAll_TimTheoTenSP]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, sTensanpham)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable_ByuId_Loaimathang(ByVal uId_Kho As String, ByVal uId_Loaimathang As String) As System.Data.DataTable Implements IQLMH_DINHMUC_GIAMATHANGDA.SelectAllTable_ByuId_Loaimathang
        Dim db As Database
        Dim sp As String = "[dbo].spQLMH_DINHMUC_GIAMATHANG_SelectAll_byuId_Loaimathang"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, uId_Loaimathang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    '24/10/2014 dinh muc gia 
    Public Function SelectById_Mathang(uId_Mathang As String, uId_Cuahang As String) As DataTable Implements IQLMH_DINHMUC_GIAMATHANGDA.SelectById_Mathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_SelectByIdMathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "uId_Mathang", DbType.String, uId_Mathang)
            db.AddInParameter(objCmd, "uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    '27/10/2014
    Public Function SelectCheck(uId_Mathang As String, uId_Kho As String) As DataTable Implements IQLMH_DINHMUC_GIAMATHANGDA.Selectcheck
        Dim db As Database
        Dim sp = "[dbo].[spQLMH_DINHMUC_GIAMATHANG_SelectCheck]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "uId_Mathang", DbType.String, uId_Mathang)
            db.AddInParameter(objCmd, "uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class