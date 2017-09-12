Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CTKM_MATHANG_CHITIETDA

    Implements ICTKM_MATHANG_CHITIETDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CTKM_MATHANG_CHITIETEntity) Implements ICTKM_MATHANG_CHITIETDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_MATHANG_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CTKM_MATHANG_CHITIETEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CTKM_MATHANG_CHITIETEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CTKM_MATHANG_CHITIETEntity)
                With lstobj(i)
                    .uId_CTKM_Chitiet = IIf(IsDBNull(objReader("uId_CTKM_Chitiet")) = True, "", Convert.ToString(objReader("uId_CTKM_Chitiet")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .uId_ChuongtrinhKhuyenmai = IIf(IsDBNull(objReader("uId_ChuongtrinhKhuyenmai")) = True, "", Convert.ToString(objReader("uId_ChuongtrinhKhuyenmai")))
                    .f_phantramGiamgia = IIf(IsDBNull(objReader("f_phantramGiamgia")) = True, 0, objReader("f_phantramGiamgia"))
                    .f_DonghangGia = IIf(IsDBNull(objReader("f_DonghangGia")) = True, 0, objReader("f_DonghangGia"))
                    .uId_Dichvutang = IIf(IsDBNull(objReader("uId_Dichvutang")) = True, "", Convert.ToString(objReader("uId_Dichvutang")))
                    .uId_Mathangtang = IIf(IsDBNull(objReader("uId_Mathangtang")) = True, "", Convert.ToString(objReader("uId_Mathangtang")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CTKM_MATHANG_CHITIETEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal strTukhoa As String) As System.Data.DataTable Implements ICTKM_MATHANG_CHITIETDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_MATHANG_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", System.Data.DbType.String, uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@nv_TenMathang_vn", System.Data.DbType.String, strTukhoa)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_CTKM_Chitiet As String) As CM.CTKM_MATHANG_CHITIETEntity Implements ICTKM_MATHANG_CHITIETDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_MATHANG_CHITIET_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CTKM_MATHANG_CHITIETEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_CTKM_Chitiet", System.Data.DbType.String, uId_CTKM_Chitiet)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CTKM_MATHANG_CHITIETEntity
            If objReader.Read Then
                With obj
                    .uId_CTKM_Chitiet = IIf(IsDBNull(objReader("uId_CTKM_Chitiet")) = True, "", Convert.ToString(objReader("uId_CTKM_Chitiet")))
                    .uId_Mathang = IIf(IsDBNull(objReader("uId_Mathang")) = True, "", Convert.ToString(objReader("uId_Mathang")))
                    .uId_ChuongtrinhKhuyenmai = IIf(IsDBNull(objReader("uId_ChuongtrinhKhuyenmai")) = True, "", Convert.ToString(objReader("uId_ChuongtrinhKhuyenmai")))
                    .f_phantramGiamgia = IIf(IsDBNull(objReader("f_phantramGiamgia")) = True, 0, objReader("f_phantramGiamgia"))
                    .f_DonghangGia = IIf(IsDBNull(objReader("f_DonghangGia")) = True, 0, objReader("f_DonghangGia"))
                    .uId_Dichvutang = IIf(IsDBNull(objReader("uId_Dichvutang")) = True, "", Convert.ToString(objReader("uId_Dichvutang")))
                    .uId_Mathangtang = IIf(IsDBNull(objReader("uId_Mathangtang")) = True, "", Convert.ToString(objReader("uId_Mathangtang")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CTKM_MATHANG_CHITIETEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_MATHANG_CHITIETEntity) As Boolean Implements ICTKM_MATHANG_CHITIETDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_MATHANG_CHITIET_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", DbType.String, obj.uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@f_phantramGiamgia", DbType.Double, obj.f_phantramGiamgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_CTKM_Chitiet As String) As Boolean Implements ICTKM_MATHANG_CHITIETDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_MATHANG_CHITIET_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_CTKM_Chitiet", DbType.String, uId_CTKM_Chitiet)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CTKM_MATHANG_CHITIETEntity) As Boolean Implements ICTKM_MATHANG_CHITIETDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_MATHANG_CHITIET_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_CTKM_Chitiet", DbType.String, obj.uId_CTKM_Chitiet)
            db.AddInParameter(objCmd, "@uId_Mathang", DbType.String, obj.uId_Mathang)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", DbType.String, obj.uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@f_phantramGiamgia", DbType.Double, obj.f_phantramGiamgia)
            db.AddInParameter(objCmd, "@f_DonghangGia", DbType.Double, obj.f_DonghangGia)
            db.AddInParameter(objCmd, "@uId_Dichvutang", DbType.String, obj.uId_Dichvutang)
            db.AddInParameter(objCmd, "@uId_Mathangtang", DbType.String, obj.uId_Mathangtang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class