Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLMH_DM_MATHANGDA
    Implements IQLMH_DM_MATHANGDA

    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DM_MATHANGEntity) Implements IQLMH_DM_MATHANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLMH_DM_MATHANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLMH_DM_MATHANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLMH_DM_MATHANGEntity)
                With lstobj(i)
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    .uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    .uId_Xuatxu = IIf(IsDBNull(objReader("uId_Xuatxu")) = True, "", Convert.ToString(objReader("uId_Xuatxu")))
                    .v_MaMathang = IIf(IsDBNull(objReader("v_MaMathang")) = True, "", objReader("v_MaMathang"))
                    .nv_TenMathang_vn = IIf(IsDBNull(objReader("nv_TenMathang_vn")) = True, "", objReader("nv_TenMathang_vn"))
                    .nv_TenMathang_en = IIf(IsDBNull(objReader("nv_TenMathang_en")) = True, "", objReader("nv_TenMathang_en"))
                    .nv_DVT_vn = IIf(IsDBNull(objReader("nv_DVT_vn")) = True, "", objReader("nv_DVT_vn"))
                    .nv_DVT_en = IIf(IsDBNull(objReader("nv_DVT_en")) = True, "", objReader("nv_DVT_en"))
                    .f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    .f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    .f_PhamtramHH_CTV = IIf(IsDBNull(objReader("f_PhamtramHH_CTV")) = True, 0, objReader("f_PhamtramHH_CTV"))
                    .f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    .f_Hanmuc_Ton = IIf(IsDBNull(objReader("f_Hanmuc_Ton")) = True, 0, objReader("f_Hanmuc_Ton"))
                    .i_Songaycanhbao_Ton = IIf(IsDBNull(objReader("i_Songaycanhbao_Ton")) = True, 0, objReader("i_Songaycanhbao_Ton"))
                    .i_Songaycanhbao_HethanSD = IIf(IsDBNull(objReader("i_Songaycanhbao_HethanSD")) = True, 0, objReader("i_Songaycanhbao_HethanSD"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))

                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLMH_DM_MATHANGEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectAll]"
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
    Public Function SelectTimKiem(ByVal uId_Loaimathang As String, ByVal uId_NhomMathang As String, ByVal nv_TenMathang_vn As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.SelectTimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectTimKiem]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, uId_Loaimathang)
            db.AddInParameter(objCmd, "@uId_NhomMathang", DbType.String, uId_NhomMathang)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, nv_TenMathang_vn)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectAllBarcode(ByVal uId_NhomMathang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.SelectAllBarcode
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectAllBarcode]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_NhomMathang", DbType.String, uId_NhomMathang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByBarcode(ByVal uId_Mathang As String, ByVal v_MaBarcode As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.SelectByBarcode
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectByBarcode]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, uId_Mathang)
            db.AddInParameter(objCmd, "@v_MaBarcode", DbType.String, v_MaBarcode)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByID(ByVal uId_Mathang As String) As CM.QLMH_DM_MATHANGEntity Implements IQLMH_DM_MATHANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_MATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, uId_Mathang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_MATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    .uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    .uId_Xuatxu = IIf(IsDBNull(objReader("uId_Xuatxu")) = True, "", Convert.ToString(objReader("uId_Xuatxu")))
                    .v_MaMathang = IIf(IsDBNull(objReader("v_MaMathang")) = True, "", objReader("v_MaMathang"))
                    .v_MaBarcode = IIf(IsDBNull(objReader("v_MaBarcode")) = True, "", objReader("v_MaBarcode"))
                    .nv_TenMathang_vn = IIf(IsDBNull(objReader("nv_TenMathang_vn")) = True, "", objReader("nv_TenMathang_vn"))
                    .nv_TenMathang_en = IIf(IsDBNull(objReader("nv_TenMathang_en")) = True, "", objReader("nv_TenMathang_en"))
                    .nv_DVT_vn = IIf(IsDBNull(objReader("nv_DVT_vn")) = True, "", objReader("nv_DVT_vn"))
                    .nv_DVT_en = IIf(IsDBNull(objReader("nv_DVT_en")) = True, "", objReader("nv_DVT_en"))
                    .f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    .f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    .f_PhamtramHH_CTV = IIf(IsDBNull(objReader("f_PhamtramHH_CTV")) = True, 0, objReader("f_PhamtramHH_CTV"))
                    .f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    .f_Hanmuc_Ton = IIf(IsDBNull(objReader("f_Hanmuc_Ton")) = True, 0, objReader("f_Hanmuc_Ton"))
                    .i_Songaycanhbao_Ton = IIf(IsDBNull(objReader("i_Songaycanhbao_Ton")) = True, 0, objReader("i_Songaycanhbao_Ton"))
                    .i_Songaycanhbao_HethanSD = IIf(IsDBNull(objReader("i_Songaycanhbao_HethanSD")) = True, 0, objReader("i_Songaycanhbao_HethanSD"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    '.d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Gianhap = IIf(IsDBNull(objReader("f_Gianhap")) = True, 0, objReader("f_Gianhap"))
                    '.f_Biendo_Gianhap = IIf(IsDBNull(objReader("f_Biendo_Gianhap")) = True, 0, objReader("f_Biendo_Gianhap"))
                    .f_Giaban = IIf(IsDBNull(objReader("f_Giaban")) = True, 0, objReader("f_Giaban"))
                    '.f_Biendo_Giaban = IIf(IsDBNull(objReader("f_Biendo_Giaban")) = True, 0, objReader("f_Biendo_Giaban"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_MATHANGEntity
        End Try
    End Function
    Public Function SelectByMaVach(ByVal v_MaBarcode As String) As CM.QLMH_DM_MATHANGEntity Implements IQLMH_DM_MATHANGDA.SelectByMaVach
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectByMaVach]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_MATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaBarcode", DbType.String, v_MaBarcode)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_MATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    '.uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    '.uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    '.uId_Xuatxu = IIf(IsDBNull(objReader("uId_Xuatxu")) = True, "", Convert.ToString(objReader("uId_Xuatxu")))
                    '.v_MaMathang = IIf(IsDBNull(objReader("v_MaMathang")) = True, "", objReader("v_MaMathang"))
                    '.v_MaBarcode = IIf(IsDBNull(objReader("v_MaBarcode")) = True, "", objReader("v_MaBarcode"))
                    .nv_TenMathang_vn = IIf(IsDBNull(objReader("nv_TenMathang_vn")) = True, "", objReader("nv_TenMathang_vn"))
                    .nv_TenMathang_en = IIf(IsDBNull(objReader("nv_TenMathang_en")) = True, "", objReader("nv_TenMathang_en"))
                    .nv_DVT_vn = IIf(IsDBNull(objReader("nv_DVT_vn")) = True, "", objReader("nv_DVT_vn"))
                    .nv_DVT_en = IIf(IsDBNull(objReader("nv_DVT_en")) = True, "", objReader("nv_DVT_en"))
                    '.f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    '.f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    '.f_PhamtramHH_CTV = IIf(IsDBNull(objReader("f_PhamtramHH_CTV")) = True, 0, objReader("f_PhamtramHH_CTV"))
                    '.f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    '.f_Hanmuc_Ton = IIf(IsDBNull(objReader("f_Hanmuc_Ton")) = True, 0, objReader("f_Hanmuc_Ton"))
                    '.i_Songaycanhbao_Ton = IIf(IsDBNull(objReader("i_Songaycanhbao_Ton")) = True, 0, objReader("i_Songaycanhbao_Ton"))
                    '.i_Songaycanhbao_HethanSD = IIf(IsDBNull(objReader("i_Songaycanhbao_HethanSD")) = True, 0, objReader("i_Songaycanhbao_HethanSD"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    '.d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Gianhap = IIf(IsDBNull(objReader("f_Gianhap")) = True, 0, objReader("f_Gianhap"))
                    '.f_Biendo_Gianhap = IIf(IsDBNull(objReader("f_Biendo_Gianhap")) = True, 0, objReader("f_Biendo_Gianhap"))
                    .f_Giaban = IIf(IsDBNull(objReader("f_Giaban")) = True, 0, objReader("f_Giaban"))
                    '.f_Biendo_Giaban = IIf(IsDBNull(objReader("f_Biendo_Giaban")) = True, 0, objReader("f_Biendo_Giaban"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_MATHANGEntity
        End Try
    End Function
    Public Function SelectBarcodeMax(ByVal barcode As String) As CM.QLMH_DM_MATHANGEntity Implements IQLMH_DM_MATHANGDA.SelectBarcodeMax
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectBarcodeMax]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_MATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@barcode", DbType.String, barcode)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_MATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .v_MaBarcode = IIf(IsDBNull(objReader("v_MaBarcode")) = True, "", objReader("v_MaBarcode"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_MATHANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_MATHANGEntity) As String Implements IQLMH_DM_MATHANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, obj.uId_Nhommathang)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, obj.uId_Loaimathang)
            db.AddInParameter(objCmd, "@uId_Xuatxu", DbType.String, obj.uId_Xuatxu)
            db.AddInParameter(objCmd, "@v_MaMathang", DbType.String, obj.v_MaMathang)
            db.AddInParameter(objCmd, "@v_MaBarcode", DbType.String, obj.v_MaBarcode)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, obj.nv_TenMathang_vn)
            db.AddInParameter(objCmd, "@nv_TenMathang_en", DbType.String, obj.nv_TenMathang_en)
            db.AddInParameter(objCmd, "@nv_DVT_vn", DbType.String, obj.nv_DVT_vn)
            db.AddInParameter(objCmd, "@nv_DVT_en", DbType.String, obj.nv_DVT_en)
            db.AddInParameter(objCmd, "@f_PhantramHH_KTV", DbType.Double, obj.f_PhantramHH_KTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_TVV", DbType.Double, obj.f_PhantramHH_TVV)
            db.AddInParameter(objCmd, "@f_PhamtramHH_CTV", DbType.Double, obj.f_PhamtramHH_CTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_NV", DbType.Double, obj.f_PhantramHH_NV)
            db.AddInParameter(objCmd, "@f_Hanmuc_Ton", DbType.Double, obj.f_Hanmuc_Ton)
            db.AddInParameter(objCmd, "@i_Songaycanhbao_Ton", DbType.Int32, obj.i_Songaycanhbao_Ton)
            db.AddInParameter(objCmd, "@i_Songaycanhbao_HethanSD", DbType.Int32, obj.i_Songaycanhbao_HethanSD)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Mathang As String) As Boolean Implements IQLMH_DM_MATHANGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, uId_Mathang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_MATHANGEntity) As Boolean Implements IQLMH_DM_MATHANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, obj.uId_Nhommathang)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, obj.uId_Loaimathang)
            db.AddInParameter(objCmd, "@uId_Xuatxu", DbType.String, obj.uId_Xuatxu)
            db.AddInParameter(objCmd, "@v_MaMathang", DbType.String, obj.v_MaMathang)
            db.AddInParameter(objCmd, "@v_MaBarcode", DbType.String, obj.v_MaBarcode)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, obj.nv_TenMathang_vn)
            db.AddInParameter(objCmd, "@nv_TenMathang_en", DbType.String, obj.nv_TenMathang_en)
            db.AddInParameter(objCmd, "@nv_DVT_vn", DbType.String, obj.nv_DVT_vn)
            db.AddInParameter(objCmd, "@nv_DVT_en", DbType.String, obj.nv_DVT_en)
            db.AddInParameter(objCmd, "@f_PhantramHH_KTV", DbType.Double, obj.f_PhantramHH_KTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_TVV", DbType.Double, obj.f_PhantramHH_TVV)
            db.AddInParameter(objCmd, "@f_PhamtramHH_CTV", DbType.Double, obj.f_PhamtramHH_CTV)
            db.AddInParameter(objCmd, "@f_PhantramHH_NV", DbType.Double, obj.f_PhantramHH_NV)
            db.AddInParameter(objCmd, "@f_Hanmuc_Ton", DbType.Double, obj.f_Hanmuc_Ton)
            db.AddInParameter(objCmd, "@i_Songaycanhbao_Ton", DbType.Int32, obj.i_Songaycanhbao_Ton)
            db.AddInParameter(objCmd, "@i_Songaycanhbao_HethanSD", DbType.Int32, obj.i_Songaycanhbao_HethanSD)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Select_Banggia_Nhap(ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Nhap
        Dim db As Database
        Dim sp As String = "Select uId_Mathang, nv_TenMathang_vn,nv_DVT_vn,f_Gianhap as f_Gia from dbo.ThangNM_Banggia_MatHang where uId_Kho='" + uId_Kho + "' order by nv_TenMathang_vn ASC"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetSqlStringCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function Select_Banggia_Nhap_ByLoaimathang(ByVal uId_Loaimathang As String, ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Nhap_ByLoaimathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectNhapByLoaimathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, uId_Loaimathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Banggia_Xuat_ByLoaimathang(ByVal uId_Loaimathang As String, ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Xuat_ByLoaimathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectXuatByLoaimathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, uId_Loaimathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function Select_Banggia_Nhap_ByNhommathang(ByVal uId_Nhommathang As String, ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Nhap_ByNhommathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectNhapByNhommathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, uId_Nhommathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Banggia_Xuat_ByNhommathang(ByVal uId_Nhommathang As String, ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Xuat_ByNhommathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectXuatByNhommathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, uId_Nhommathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Select_Banggia_Xuat(ByVal uId_Nhommathang As String, ByVal uId_Loaimathang As String, ByVal uId_Kho As String, ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Xuat
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectXuat]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhommathang", DbType.String, uId_Nhommathang)
            db.AddInParameter(objCmd, "@uId_Loaimathang", DbType.String, uId_Loaimathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, d_Ngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Banggia_Xuatban(ByVal uId_Kho As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Xuatban
        Dim db As Database
        Dim sp As String = "Select ThangNM_Banggia_MatHang.uId_Mathang, nv_TenMathang_vn,nv_DVT_vn,f_Giaban as f_Gia,coalesce(f_phantramGiamgia ,0) as f_phantramGiamgia from dbo.ThangNM_Banggia_MatHang Left join CTKM_MATHANG_CHITIET on CTKM_MATHANG_CHITIET.uId_Mathang = ThangNM_Banggia_MatHang.uId_Mathang left join CTKM_DM_CHUONGTRINHKHUYENMAI on CTKM_DM_CHUONGTRINHKHUYENMAI.uId_ChuongtrinhKhuyenmai = CTKM_MATHANG_CHITIET.uId_ChuongtrinhKhuyenmai  where uId_Kho='" + uId_Kho + "' and coalesce(d_ngaybatdau,GETDATE()) <= GETDATE() and GETDATE()<=coalesce(d_ngayketthuc,GETDATE()) order by nv_TenMathang_vn ASC"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetSqlStringCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Bang_Tonghop_Ton(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Bang_Tonghop_Ton
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_TongHopTon]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Bang_Tonghop_Ton_TimTheoTen(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Kho As String, ByVal uId_Cuahang As String, ByVal sTenMatHang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Bang_Tonghop_Ton_TimTheoTen
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_TongHopTon_TimTheoTen]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, sTenMatHang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Bang_Tonghop_Ton_Canhbao_SapQuahan(ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Bang_Tonghop_Ton_Canhbao_SapQuahan
        Dim db As Database
        Dim sp As String = "[dbo].[spGet_DSMH_SapHetHanSuDung]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function Bang_Tonghop_Ton_Canhbao(ByVal TuNgay As Date, ByVal DenNgay As Date) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Bang_Tonghop_Ton_Canhbao
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_TonKho_CanhbaoTon]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByMamathang(ByVal Mamathang As String) As CM.QLMH_DM_MATHANGEntity Implements IQLMH_DM_MATHANGDA.SelectByMamathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectByMamathang]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_MATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Mamathang", DbType.String, Mamathang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_MATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    '.uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    '.uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    '.uId_Xuatxu = IIf(IsDBNull(objReader("uId_Xuatxu")) = True, "", Convert.ToString(objReader("uId_Xuatxu")))
                    '.v_MaMathang = IIf(IsDBNull(objReader("v_MaMathang")) = True, "", objReader("v_MaMathang"))
                    '.v_MaBarcode = IIf(IsDBNull(objReader("v_MaBarcode")) = True, "", objReader("v_MaBarcode"))
                    .nv_TenMathang_vn = IIf(IsDBNull(objReader("nv_TenMathang_vn")) = True, "", objReader("nv_TenMathang_vn"))
                    .nv_TenMathang_en = IIf(IsDBNull(objReader("nv_TenMathang_en")) = True, "", objReader("nv_TenMathang_en"))
                    .nv_DVT_vn = IIf(IsDBNull(objReader("nv_DVT_vn")) = True, "", objReader("nv_DVT_vn"))
                    .nv_DVT_en = IIf(IsDBNull(objReader("nv_DVT_en")) = True, "", objReader("nv_DVT_en"))
                    '.f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    '.f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    '.f_PhamtramHH_CTV = IIf(IsDBNull(objReader("f_PhamtramHH_CTV")) = True, 0, objReader("f_PhamtramHH_CTV"))
                    '.f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    '.f_Hanmuc_Ton = IIf(IsDBNull(objReader("f_Hanmuc_Ton")) = True, 0, objReader("f_Hanmuc_Ton"))
                    '.i_Songaycanhbao_Ton = IIf(IsDBNull(objReader("i_Songaycanhbao_Ton")) = True, 0, objReader("i_Songaycanhbao_Ton"))
                    '.i_Songaycanhbao_HethanSD = IIf(IsDBNull(objReader("i_Songaycanhbao_HethanSD")) = True, 0, objReader("i_Songaycanhbao_HethanSD"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    '.d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Gianhap = IIf(IsDBNull(objReader("f_Gianhap")) = True, 0, objReader("f_Gianhap"))
                    '.f_Biendo_Gianhap = IIf(IsDBNull(objReader("f_Biendo_Gianhap")) = True, 0, objReader("f_Biendo_Gianhap"))
                    .f_Giaban = IIf(IsDBNull(objReader("f_Giaban")) = True, 0, objReader("f_Giaban"))
                    '.f_Biendo_Giaban = IIf(IsDBNull(objReader("f_Biendo_Giaban")) = True, 0, objReader("f_Biendo_Giaban"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_MATHANGEntity
        End Try
    End Function

    Public Function Bang_Tonghop_Ton_Canhbao_Quahan(ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Bang_Tonghop_Ton_Canhbao_Quahan
        Dim db As Database
        Dim sp As String = "[dbo].[spGet_DSMH_HetHanSuDung]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Select_Banggia_Xuat_ByTenMathang(ByVal sTenMatHang As String, ByVal uId_Kho As String, ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Xuat_ByTenMathang
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectXuatByTenMathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", DbType.String, sTenMatHang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, d_Ngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByMamathangVaKho(ByVal Mamathang As String, ByVal uId_Kho As String) As CM.QLMH_DM_MATHANGEntity Implements IQLMH_DM_MATHANGDA.SelectByMamathangVaKho
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectByMamathangVaKho]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLMH_DM_MATHANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Mamathang", DbType.String, Mamathang)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLMH_DM_MATHANGEntity
            If objReader.Read Then
                With obj
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    '.uId_Nhommathang = IIf(IsDBNull(objReader("uId_Nhommathang")) = True, "", Convert.ToString(objReader("uId_Nhommathang")))
                    '.uId_Loaimathang = IIf(IsDBNull(objReader("uId_Loaimathang")) = True, "", Convert.ToString(objReader("uId_Loaimathang")))
                    '.uId_Xuatxu = IIf(IsDBNull(objReader("uId_Xuatxu")) = True, "", Convert.ToString(objReader("uId_Xuatxu")))
                    '.v_MaMathang = IIf(IsDBNull(objReader("v_MaMathang")) = True, "", objReader("v_MaMathang"))
                    '.v_MaBarcode = IIf(IsDBNull(objReader("v_MaBarcode")) = True, "", objReader("v_MaBarcode"))
                    .nv_TenMathang_vn = IIf(IsDBNull(objReader("nv_TenMathang_vn")) = True, "", objReader("nv_TenMathang_vn"))
                    .nv_TenMathang_en = IIf(IsDBNull(objReader("nv_TenMathang_en")) = True, "", objReader("nv_TenMathang_en"))
                    .nv_DVT_vn = IIf(IsDBNull(objReader("nv_DVT_vn")) = True, "", objReader("nv_DVT_vn"))
                    .nv_DVT_en = IIf(IsDBNull(objReader("nv_DVT_en")) = True, "", objReader("nv_DVT_en"))
                    '.f_PhantramHH_KTV = IIf(IsDBNull(objReader("f_PhantramHH_KTV")) = True, 0, objReader("f_PhantramHH_KTV"))
                    '.f_PhantramHH_TVV = IIf(IsDBNull(objReader("f_PhantramHH_TVV")) = True, 0, objReader("f_PhantramHH_TVV"))
                    '.f_PhamtramHH_CTV = IIf(IsDBNull(objReader("f_PhamtramHH_CTV")) = True, 0, objReader("f_PhamtramHH_CTV"))
                    '.f_PhantramHH_NV = IIf(IsDBNull(objReader("f_PhantramHH_NV")) = True, 0, objReader("f_PhantramHH_NV"))
                    '.f_Hanmuc_Ton = IIf(IsDBNull(objReader("f_Hanmuc_Ton")) = True, 0, objReader("f_Hanmuc_Ton"))
                    '.i_Songaycanhbao_Ton = IIf(IsDBNull(objReader("i_Songaycanhbao_Ton")) = True, 0, objReader("i_Songaycanhbao_Ton"))
                    '.i_Songaycanhbao_HethanSD = IIf(IsDBNull(objReader("i_Songaycanhbao_HethanSD")) = True, 0, objReader("i_Songaycanhbao_HethanSD"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                    '.d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .f_Gianhap = IIf(IsDBNull(objReader("f_Gianhap")) = True, 0, objReader("f_Gianhap"))
                    '.f_Biendo_Gianhap = IIf(IsDBNull(objReader("f_Biendo_Gianhap")) = True, 0, objReader("f_Biendo_Gianhap"))
                    .f_Giaban = IIf(IsDBNull(objReader("f_Giaban")) = True, 0, objReader("f_Giaban"))
                    '.f_Biendo_Giaban = IIf(IsDBNull(objReader("f_Biendo_Giaban")) = True, 0, objReader("f_Biendo_Giaban"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLMH_DM_MATHANGEntity
        End Try
    End Function


    Public Function LaySLTonByTime(ByVal DenNgay As Date, ByVal uId_Kho As String, ByVal uId_Cuahang As String, ByVal uId_Mathang As String) As Integer Implements IQLMH_DM_MATHANGDA.LaySLTonByTime
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_LaySLTon]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, uId_Mathang)
            Return Integer.Parse(db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Select_Banggia_Nhap_Update(ByVal uId_Kho As String, ByVal key As String) As System.Data.DataTable Implements IQLMH_DM_MATHANGDA.Select_Banggia_Nhap_Update
        Dim db As Database
        Dim sp As String = "Select uId_Mathang, nv_TenMathang_vn,nv_DVT_vn,f_Gianhap as f_Gia from dbo.ThangNM_Banggia_MatHang where uId_Kho='" + uId_Kho + "' AND nv_TenMathang_vn LIKE N'%" + key + "%' order by nv_TenMathang_vn ASC"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetSqlStringCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectGiaKhuyenMai(ByVal uId_Mathang As String, ByVal d_Ngay As Date) As Double Implements IQLMH_DM_MATHANGDA.SelectGiaKhuyenMai
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_DM_MATHANG_SelectGiaKhuyenMai]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, uId_Mathang)
            db.AddInParameter(objCmd, "@d_Ngay", DbType.Date, d_Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return 0
        End Try
    End Function

    Public Function QuyDoiVeDonViNhoNhat(MaVatTu As String, MaDonVi As String, SoLuong As Double) As Integer Implements IQLMH_DM_MATHANGDA.QuyDoiVeDonViNhoNhat
        Dim db As Database
        Dim sp As String = "[dbo].[sp_QuyDoiVeDonViNhoNhat]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, MaVatTu)
            db.AddInParameter(objCmd, "@MaDonVi", DbType.String, MaDonVi)
            db.AddInParameter(objCmd, "@SoLuong", DbType.Double, SoLuong)
            Return Integer.Parse(db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectSearchByName(uId_Kho As String, uId_Cuahang As String, nv_Tenmathang As String) As DataTable Implements IQLMH_DM_MATHANGDA.SelectSearchByName
        Dim db As Database
        Dim sp As String = "[dbo].[spQLMH_SM_MATHANG_SelectSearch]"
        Dim objCmd As DbCommand
        Dim ds As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Kho", DbType.String, uId_Kho)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Tenmathang", DbType.String, nv_Tenmathang)
            ds = db.ExecuteDataSet(objCmd)
            Return ds.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function CreateMa() As String Implements IQLMH_DM_MATHANGDA.CreateMa
        Dim db As Database
        Dim sp As String = "[dbo].[spCreate_CodeMathang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "1"
        End Try
    End Function

    Public Function Select_By_Mathang_Table(v_Mamathang As String) As DataTable Implements IQLMH_DM_MATHANGDA.Select_By_Mathang_Table
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_By_Mamathang_Table]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Mamathang", DbType.String, v_Mamathang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class