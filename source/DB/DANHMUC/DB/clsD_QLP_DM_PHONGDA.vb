Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLP_DM_PHONGDA

    Implements IQLP_DM_PHONGDA


    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.QLP_DM_PHONGEntity) Implements IQLP_DM_PHONGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLP_DM_PHONGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLP_DM_PHONGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLP_DM_PHONGEntity)
                With lstobj(i)
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_Tenphong_vn = IIf(IsDBNull(objReader("nv_Tenphong_vn")) = True, "", objReader("nv_Tenphong_vn"))
                    .nv_Tenphong_en = IIf(IsDBNull(objReader("nv_Tenphong_en")) = True, "", objReader("nv_Tenphong_en"))
                    .i_Thutu = IIf(IsDBNull(objReader("i_Thutu")) = True, 0, objReader("i_Thutu"))
                    .i_Sokhachtoida = IIf(IsDBNull(objReader("i_Sokhachtoida")) = True, 0, objReader("i_Sokhachtoida"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Maunen = IIf(IsDBNull(objReader("v_Maunen")) = True, "", objReader("v_Maunen"))
                    .v_Mauchu = IIf(IsDBNull(objReader("v_Mauchu")) = True, "", objReader("v_Mauchu"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLP_DM_PHONGEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable Implements IQLP_DM_PHONGDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Phong As String) As CM.QLP_DM_PHONGEntity Implements IQLP_DM_PHONGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLP_DM_PHONGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLP_DM_PHONGEntity
            If objReader.Read Then
                With obj
                    .uId_Phong = IIf(IsDBNull(objReader("uId_Phong")) = True, "", Convert.ToString(objReader("uId_Phong")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_Tenphong_vn = IIf(IsDBNull(objReader("nv_Tenphong_vn")) = True, "", objReader("nv_Tenphong_vn"))
                    .nv_Tenphong_en = IIf(IsDBNull(objReader("nv_Tenphong_en")) = True, "", objReader("nv_Tenphong_en"))
                    .i_Thutu = IIf(IsDBNull(objReader("i_Thutu")) = True, 0, objReader("i_Thutu"))
                    .i_Sokhachtoida = IIf(IsDBNull(objReader("i_Sokhachtoida")) = True, 0, objReader("i_Sokhachtoida"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .v_Maunen = IIf(IsDBNull(objReader("v_Maunen")) = True, "", objReader("v_Maunen"))
                    .v_Mauchu = IIf(IsDBNull(objReader("v_Mauchu")) = True, "", objReader("v_Mauchu"))
                    .nv_Tencuahang_vn = IIf(IsDBNull(objReader("nv_Tencuahang_vn")) = True, "", objReader("nv_Tencuahang_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLP_DM_PHONGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLP_DM_PHONGEntity) As Boolean Implements IQLP_DM_PHONGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Tenphong_vn", DbType.String, obj.nv_Tenphong_vn)
            db.AddInParameter(objCmd, "@nv_Tenphong_en", DbType.String, obj.nv_Tenphong_en)
            db.AddInParameter(objCmd, "@i_Thutu", DbType.Int16, obj.i_Thutu)
            db.AddInParameter(objCmd, "@i_Sokhachtoida", DbType.Int16, obj.i_Sokhachtoida)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.AddInParameter(objCmd, "@v_Maunen", DbType.String, obj.v_Maunen)
            db.AddInParameter(objCmd, "@v_Mauchu", DbType.String, obj.v_Mauchu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Phong As String) As Boolean Implements IQLP_DM_PHONGDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, uId_Phong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLP_DM_PHONGEntity) As Boolean Implements IQLP_DM_PHONGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phong", DbType.String, obj.uId_Phong)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Tenphong_vn", DbType.String, obj.nv_Tenphong_vn)
            db.AddInParameter(objCmd, "@nv_Tenphong_en", DbType.String, obj.nv_Tenphong_en)
            db.AddInParameter(objCmd, "@i_Thutu", DbType.Int16, obj.i_Thutu)
            db.AddInParameter(objCmd, "@i_Sokhachtoida", DbType.Int16, obj.i_Sokhachtoida)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            db.AddInParameter(objCmd, "@v_Maunen", DbType.String, obj.v_Maunen)
            db.AddInParameter(objCmd, "@v_Mauchu", DbType.String, obj.v_Mauchu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectPhongCoGiuongTrong() As DataTable Implements IQLP_DM_PHONGDA.SelectPhongCoGiuongTrong
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_DM_PHONG_SelectPhongCoGiuongTrong]"
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