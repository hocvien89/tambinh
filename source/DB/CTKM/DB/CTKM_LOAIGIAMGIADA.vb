Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CTKM_LOAIGIAMGIADA

    Implements ICTKM_LOAIGIAMGIADA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CTKM_LOAIGIAMGIAEntity) Implements ICTKM_LOAIGIAMGIADA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_LOAIGIAMGIA_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CTKM_LOAIGIAMGIAEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CTKM_LOAIGIAMGIAEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CTKM_LOAIGIAMGIAEntity)
                With lstobj(i)
                    .uId_LoaiGiamgia = IIf(IsDBNull(objReader("uId_LoaiGiamgia")) = True, "", Convert.ToString(objReader("uId_LoaiGiamgia")))
                    .nv_TenLoaiGiamgia_vn = IIf(IsDBNull(objReader("nv_TenLoaiGiamgia_vn")) = True, "", objReader("nv_TenLoaiGiamgia_vn"))
                    .nv_TenLoaiGiamgia_en = IIf(IsDBNull(objReader("nv_TenLoaiGiamgia_en")) = True, "", objReader("nv_TenLoaiGiamgia_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CTKM_LOAIGIAMGIAEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ICTKM_LOAIGIAMGIADA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_LOAIGIAMGIA_SelectAll]"
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

    Public Function SelectByID(ByVal uId_LoaiGiamgia As String) As CM.CTKM_LOAIGIAMGIAEntity Implements ICTKM_LOAIGIAMGIADA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_LOAIGIAMGIA_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CTKM_LOAIGIAMGIAEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiGiamgia", System.Data.DbType.String, uId_LoaiGiamgia)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CTKM_LOAIGIAMGIAEntity
            If objReader.Read Then
                With obj
                    .uId_LoaiGiamgia = IIf(IsDBNull(objReader("uId_LoaiGiamgia")) = True, "", Convert.ToString(objReader("uId_LoaiGiamgia")))
                    .nv_TenLoaiGiamgia_vn = IIf(IsDBNull(objReader("nv_TenLoaiGiamgia_vn")) = True, "", objReader("nv_TenLoaiGiamgia_vn"))
                    .nv_TenLoaiGiamgia_en = IIf(IsDBNull(objReader("nv_TenLoaiGiamgia_en")) = True, "", objReader("nv_TenLoaiGiamgia_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CTKM_LOAIGIAMGIAEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_LOAIGIAMGIAEntity) As Boolean Implements ICTKM_LOAIGIAMGIADA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_LOAIGIAMGIA_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenLoaiGiamgia_vn", DbType.String, obj.nv_TenLoaiGiamgia_vn)
            db.AddInParameter(objCmd, "@nv_TenLoaiGiamgia_en", DbType.String, obj.nv_TenLoaiGiamgia_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_LoaiGiamgia As String) As Boolean Implements ICTKM_LOAIGIAMGIADA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_LOAIGIAMGIA_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiGiamgia", DbType.String, uId_LoaiGiamgia)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CTKM_LOAIGIAMGIAEntity) As Boolean Implements ICTKM_LOAIGIAMGIADA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_LOAIGIAMGIA_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiGiamgia", DbType.String, obj.uId_LoaiGiamgia)
            db.AddInParameter(objCmd, "@nv_TenLoaiGiamgia_vn", DbType.String, obj.nv_TenLoaiGiamgia_vn)
            db.AddInParameter(objCmd, "@nv_TenLoaiGiamgia_en", DbType.String, obj.nv_TenLoaiGiamgia_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class