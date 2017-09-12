Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CTKM_DICHVU_CHITIETDA

    Implements ICTKM_DICHVU_CHITIETDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CTKM_DICHVU_CHITIETEntity) Implements ICTKM_DICHVU_CHITIETDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DICHVU_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CTKM_DICHVU_CHITIETEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CTKM_DICHVU_CHITIETEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CTKM_DICHVU_CHITIETEntity)
                With lstobj(i)
                    .uId_CTKM_Chitiet = IIf(IsDBNull(objReader("uId_CTKM_Chitiet")) = True, "", Convert.ToString(objReader("uId_CTKM_Chitiet")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .f_phantramGiamgia = IIf(IsDBNull(objReader("f_phantramGiamgia")) = True, 0, objReader("f_phantramGiamgia"))
                    .f_DonghangGia = IIf(IsDBNull(objReader("f_DonghangGia")) = True, 0, objReader("f_DonghangGia"))
                    .uId_Dichvutang = IIf(IsDBNull(objReader("uId_Dichvutang")) = True, "", Convert.ToString(objReader("uId_Dichvutang")))
                    .uId_Mathangtang = IIf(IsDBNull(objReader("uId_Mathangtang")) = True, "", Convert.ToString(objReader("uId_Mathangtang")))
                    .uId_ChuongtrinhKhuyenmai = IIf(IsDBNull(objReader("uId_ChuongtrinhKhuyenmai")) = True, "", Convert.ToString(objReader("uId_ChuongtrinhKhuyenmai")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CTKM_DICHVU_CHITIETEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal strTukhoa As String) As System.Data.DataTable Implements ICTKM_DICHVU_CHITIETDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DICHVU_CHITIET_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", System.Data.DbType.String, uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", System.Data.DbType.String, strTukhoa)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_CTKM_Chitiet As String) As CM.CTKM_DICHVU_CHITIETEntity Implements ICTKM_DICHVU_CHITIETDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DICHVU_CHITIET_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CTKM_DICHVU_CHITIETEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_CTKM_Chitiet", System.Data.DbType.String, uId_CTKM_Chitiet)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CTKM_DICHVU_CHITIETEntity
            If objReader.Read Then
                With obj
                    .uId_CTKM_Chitiet = IIf(IsDBNull(objReader("uId_CTKM_Chitiet")) = True, "", Convert.ToString(objReader("uId_CTKM_Chitiet")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .f_phantramGiamgia = IIf(IsDBNull(objReader("f_phantramGiamgia")) = True, 0, objReader("f_phantramGiamgia"))
                    .f_DonghangGia = IIf(IsDBNull(objReader("f_DonghangGia")) = True, 0, objReader("f_DonghangGia"))
                    .uId_Dichvutang = IIf(IsDBNull(objReader("uId_Dichvutang")) = True, "", Convert.ToString(objReader("uId_Dichvutang")))
                    .uId_Mathangtang = IIf(IsDBNull(objReader("uId_Mathangtang")) = True, "", Convert.ToString(objReader("uId_Mathangtang")))
                    .uId_ChuongtrinhKhuyenmai = IIf(IsDBNull(objReader("uId_ChuongtrinhKhuyenmai")) = True, "", Convert.ToString(objReader("uId_ChuongtrinhKhuyenmai")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CTKM_DICHVU_CHITIETEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_DICHVU_CHITIETEntity) As Boolean Implements ICTKM_DICHVU_CHITIETDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DICHVU_CHITIET_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", DbType.String, obj.uId_ChuongtrinhKhuyenmai)
            db.AddInParameter(objCmd, "@f_phantramGiamgia", DbType.Double, obj.f_phantramGiamgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_CTKM_Chitiet As String) As Boolean Implements ICTKM_DICHVU_CHITIETDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DICHVU_CHITIET_DeleteByID]"
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

    Public Function Update(ByVal obj As CM.CTKM_DICHVU_CHITIETEntity) As Boolean Implements ICTKM_DICHVU_CHITIETDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DICHVU_CHITIET_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_CTKM_Chitiet", DbType.String, obj.uId_CTKM_Chitiet)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@f_phantramGiamgia", DbType.Double, obj.f_phantramGiamgia)
            db.AddInParameter(objCmd, "@f_DonghangGia", DbType.Double, obj.f_DonghangGia)
            db.AddInParameter(objCmd, "@uId_Dichvutang", DbType.String, obj.uId_Dichvutang)
            db.AddInParameter(objCmd, "@uId_Mathangtang", DbType.String, obj.uId_Mathangtang)
            db.AddInParameter(objCmd, "@uId_ChuongtrinhKhuyenmai", DbType.String, obj.uId_ChuongtrinhKhuyenmai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class