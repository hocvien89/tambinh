Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_DICHVUDA

    Implements ITNTP_DM_DICHVUDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_DICHVUEntity) Implements ITNTP_DM_DICHVUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_DICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, "D5D55FFF-00E7-4669-9E05-00CCC435CA1A".ToString)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, "D5D55FFF-00E7-4669-9E05-00CCC435CA1A".ToString)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_DICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_DICHVUEntity)
                With lstobj(i)
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Nhomdichvu = IIf(IsDBNull(objReader("uId_Nhomdichvu")) = True, "", Convert.ToString(objReader("uId_Nhomdichvu")))
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                    .nv_Tendichvu_en = IIf(IsDBNull(objReader("nv_Tendichvu_en")) = True, "", objReader("nv_Tendichvu_en"))
                    .f_Gia = IIf(IsDBNull(objReader("f_Gia")) = True, 0, objReader("f_Gia"))
                    .f_Phidichvu = IIf(IsDBNull(objReader("f_Phidichvu")) = True, 0, objReader("f_Phidichvu"))
                    .f_Sophutchuanbi = IIf(IsDBNull(objReader("f_Sophutchuanbi")) = True, 0, objReader("f_Sophutchuanbi"))
                    .f_Sophutthuchien = IIf(IsDBNull(objReader("f_Sophutthuchien")) = True, 0, objReader("f_Sophutthuchien"))
                    .b_Tinhthue = IIf(IsDBNull(objReader("b_Tinhthue")) = True, False, objReader("b_Tinhthue"))
                    .b_TinhHoahong = IIf(IsDBNull(objReader("b_TinhHoahong")) = True, False, objReader("b_TinhHoahong"))
                    .f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    .f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    .f_PhantramHH_CTV = IIf(IsDBNull(objReader("f_PhantramHH_CTV")) = True, 0, objReader("f_PhantramHH_CTV"))
                    .f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    .i_Solan_Dieutri = IIf(IsDBNull(objReader("i_Solan_Dieutri")) = True, 0, objReader("i_Solan_Dieutri"))
                    .b_Goidichvu = IIf(IsDBNull(objReader("b_Goidichvu")) = True, False, objReader("b_Goidichvu"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_DICHVUEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Nhomdichvu As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements ITNTP_DM_DICHVUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectAllTable_TimTheoTendichvu(ByVal uId_Nhomdichvu As String, ByVal uId_Cuahang As String, ByVal sTendichvu As String) As System.Data.DataTable Implements ITNTP_DM_DICHVUDA.SelectAllTable_TimTheoTendichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", DbType.String, sTendichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllByGDV(ByVal uId_Nhomdichvu As String, ByVal b_Goidichvu As Byte, ByVal NgayLapPhieu As DateTime) As System.Data.DataTable Implements ITNTP_DM_DICHVUDA.SelectAllByGDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectAllByGDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@b_Goidichvu", DbType.Byte, b_Goidichvu)
            db.AddInParameter(objCmd, "@NgayLapPhieu", DbType.DateTime, NgayLapPhieu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Dichvu As String) As CM.TNTP_DM_DICHVUEntity Implements ITNTP_DM_DICHVUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_DICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_DICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .uId_Nhomdichvu = IIf(IsDBNull(objReader("uId_Nhomdichvu")) = True, "", Convert.ToString(objReader("uId_Nhomdichvu")))
                    .uId_Ngoaite = IIf(IsDBNull(objReader("uId_Ngoaite")) = True, "", Convert.ToString(objReader("uId_Ngoaite")))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                    .nv_Tendichvu_en = IIf(IsDBNull(objReader("nv_Tendichvu_en")) = True, "", objReader("nv_Tendichvu_en"))
                    .f_Gia = IIf(IsDBNull(objReader("f_Gia")) = True, 0, objReader("f_Gia"))
                    .f_Phidichvu = IIf(IsDBNull(objReader("f_Phidichvu")) = True, 0, objReader("f_Phidichvu"))
                    .f_Sophutchuanbi = IIf(IsDBNull(objReader("f_Sophutchuanbi")) = True, 0, objReader("f_Sophutchuanbi"))
                    .f_Sophutthuchien = IIf(IsDBNull(objReader("f_Sophutthuchien")) = True, 0, objReader("f_Sophutthuchien"))
                    .b_Tinhthue = IIf(IsDBNull(objReader("b_Tinhthue")) = True, False, objReader("b_Tinhthue"))
                    .b_TinhHoahong = IIf(IsDBNull(objReader("b_TinhHoahong")) = True, False, objReader("b_TinhHoahong"))
                    .f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    .f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    .f_PhantramHH_CTV = IIf(IsDBNull(objReader("f_PhantramHH_CTV")) = True, 0, objReader("f_PhantramHH_CTV"))
                    .f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    .b_Goidichvu = IIf(IsDBNull(objReader("b_Goidichvu")) = True, False, objReader("b_Goidichvu"))
                    .i_Solan_Dieutri = IIf(IsDBNull(objReader("i_Solan_Dieutri")) = True, 0, objReader("i_Solan_Dieutri"))
                    .f_Gia_Giam = IIf(IsDBNull(objReader("f_Gia_Giam")) = True, 0, objReader("f_Gia_Giam"))
                    .i_Songayquaylai = IIf(IsDBNull(objReader("i_Songayquaylai")) = True, 0, objReader("i_Songayquaylai"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_DICHVUEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean Implements ITNTP_DM_DICHVUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, obj.uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", DbType.String, obj.nv_Tendichvu_vn)
            db.AddInParameter(objCmd, "@nv_Tendichvu_en", DbType.String, obj.nv_Tendichvu_en)
            db.AddInParameter(objCmd, "@f_Gia", DbType.Double, obj.f_Gia)
            db.AddInParameter(objCmd, "@f_Phidichvu", DbType.Double, obj.f_Phidichvu)
            db.AddInParameter(objCmd, "@f_Sophutchuanbi", DbType.Double, obj.f_Sophutchuanbi)
            db.AddInParameter(objCmd, "@f_Sophutthuchien", DbType.Double, obj.f_Sophutthuchien)
            db.AddInParameter(objCmd, "@b_Tinhthue", DbType.Boolean, obj.b_Tinhthue)
            db.AddInParameter(objCmd, "@b_TinhHoahong", DbType.Boolean, obj.b_TinhHoahong)
            db.AddInParameter(objCmd, "@f_PhantramHH_KTV", DbType.Double, obj.f_PhantramHH_KTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_TVV", DbType.Double, obj.f_PhantramHH_TVV)
            db.AddInParameter(objCmd, "@f_PhantramHH_CTV", DbType.Double, obj.f_PhantramHH_CTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_NV", DbType.Double, obj.f_PhantramHH_NV)
            db.AddInParameter(objCmd, "@i_Solan_Dieutri", DbType.Int32, obj.i_Solan_Dieutri)
            db.AddInParameter(objCmd, "@b_Goidichvu", DbType.Boolean, obj.b_Goidichvu)
            db.AddInParameter(objCmd, "@f_Gia_Giam", DbType.Double, obj.f_Gia_Giam)

            db.AddInParameter(objCmd, "@i_Songayquaylai", DbType.Int32, obj.i_Songayquaylai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Dichvu As String) As Boolean Implements ITNTP_DM_DICHVUDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean Implements ITNTP_DM_DICHVUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, obj.uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@uId_Ngoaite", DbType.String, obj.uId_Ngoaite)
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", DbType.String, obj.nv_Tendichvu_vn)
            db.AddInParameter(objCmd, "@nv_Tendichvu_en", DbType.String, obj.nv_Tendichvu_en)
            db.AddInParameter(objCmd, "@f_Gia", DbType.Double, obj.f_Gia)
            db.AddInParameter(objCmd, "@f_Phidichvu", DbType.Double, obj.f_Phidichvu)
            db.AddInParameter(objCmd, "@f_Sophutchuanbi", DbType.Double, obj.f_Sophutchuanbi)
            db.AddInParameter(objCmd, "@f_Sophutthuchien", DbType.Double, obj.f_Sophutthuchien)
            db.AddInParameter(objCmd, "@b_Tinhthue", DbType.Boolean, obj.b_Tinhthue)
            db.AddInParameter(objCmd, "@b_TinhHoahong", DbType.Boolean, obj.b_TinhHoahong)
            db.AddInParameter(objCmd, "@f_PhantramHH_KTV", DbType.Double, obj.f_PhantramHH_KTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_TVV", DbType.Double, obj.f_PhantramHH_TVV)
            db.AddInParameter(objCmd, "@f_PhantramHH_CTV", DbType.Double, obj.f_PhantramHH_CTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_NV", DbType.Double, obj.f_PhantramHH_NV)
            db.AddInParameter(objCmd, "@i_Solan_Dieutri", DbType.Int32, obj.i_Solan_Dieutri)
            db.AddInParameter(objCmd, "@b_Goidichvu", DbType.Boolean, obj.b_Goidichvu)
            db.AddInParameter(objCmd, "@f_Gia_Giam", DbType.Double, obj.f_Gia_Giam)
            db.AddInParameter(objCmd, "@i_Songayquaylai", DbType.Int32, obj.i_Songayquaylai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function UpdateTest(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean Implements ITNTP_DM_DICHVUDA.UpdateTest
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_Update_test]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)

            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, obj.uId_Nhomdichvu)
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", DbType.String, obj.nv_Tendichvu_vn)

            db.AddInParameter(objCmd, "@f_Gia", DbType.Double, obj.f_Gia)


            db.AddInParameter(objCmd, "@f_Sophutthuchien", DbType.Double, obj.f_Sophutthuchien)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    'kiem tra dieu kien xoa nhom dich vu
    Public Function SelectByIDNhomdichvu(uId_Nhomdv As String) As Boolean Implements ITNTP_DM_DICHVUDA.SelectByIDNhomdichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectByIDNhomdv]"
        Dim cmd As DbCommand
        Dim dr As IDataReader
        Try
            db = DatabaseFactory.CreateDatabase()
            cmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(cmd, "@uId_Nhomdv", DbType.String, uId_Nhomdv)
            dr = db.ExecuteReader(cmd)
            If dr.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
        End Try
    End Function

    'xuanhieu 150415 dich vu ua thich charmnnguyenspa
    Public Function SelectDichvuUathich(tungay As Date, denngay As Date, uId_cuahang As String) As DataTable Implements ITNTP_DM_DICHVUDA.SelectDichvuUathich
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DICHVU_Uachuong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.Date, tungay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_cuahang)
            db.AddInParameter(objCmd, "@Denngay", DbType.Date, denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectDichvuByTenDV(nv_Tendichvu_vn As String) As DataTable Implements ITNTP_DM_DICHVUDA.SelectDichvuByTenDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectDichvuByTenDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", DbType.String, nv_Tendichvu_vn)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    'Phuongdv 13/05/2015 loadcomboDMdichvu trong bao cao tri lieu
    Public Function SelectAllTableDMDichvu() As DataTable Implements ITNTP_DM_DICHVUDA.SelectAllTableDMDichvu
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Phuongdv_DM_Dichvu_SelectAll]"
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

    Public Function SelectDvBYGDV(Type As String) As DataTable Implements ITNTP_DM_DICHVUDA.SelectDvBYGDV
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectDvByGDV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Type", DbType.String, Type)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function ThongkeKH() As List(Of CM.TNTP_DM_DICHVUEntity) Implements ITNTP_DM_DICHVUDA.ThongkeKH
        Dim db As Database
        Dim sp As String = "[dbo].[sp_ThongkeKH_Chart]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_DICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_DICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_DICHVUEntity)
                With lstobj(i)

                    .i_Ngay = IIf(IsDBNull(objReader("i_Ngay")) = True, 0, objReader("i_Ngay"))
                    .i_Soluong = IIf(IsDBNull(objReader("i_Soluong")) = True, 0, objReader("i_Soluong"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_DICHVUEntity)
        End Try
    End Function

    Public Function SelectAll_By_Cuahang() As DataTable Implements ITNTP_DM_DICHVUDA.SelectAll_By_Cuahang
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_DM_Dichvu_All_Table]"
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
End Class