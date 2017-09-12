Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_DM_GOIDICHVUDA

    Implements ITNTP_DM_GOIDICHVUDA


    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_GOIDICHVUEntity) Implements ITNTP_DM_GOIDICHVUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_GOIDICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_DM_GOIDICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_DM_GOIDICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_DM_GOIDICHVUEntity)
                With lstobj(i)
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .nv_Tengoi_vn = IIf(IsDBNull(objReader("nv_Tengoi_vn")) = True, "", objReader("nv_Tengoi_vn"))
                    .nv_Tengoi_en = IIf(IsDBNull(objReader("nv_Tengoi_en")) = True, "", objReader("nv_Tengoi_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_DM_GOIDICHVUEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements ITNTP_DM_GOIDICHVUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_GOIDICHVU_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Goidichvu As String) As CM.TNTP_DM_GOIDICHVUEntity Implements ITNTP_DM_GOIDICHVUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_GOIDICHVU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_DM_GOIDICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", System.Data.DbType.String, uId_Goidichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_DM_GOIDICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .nv_Tengoi_vn = IIf(IsDBNull(objReader("nv_Tengoi_vn")) = True, "", objReader("nv_Tengoi_vn"))
                    .nv_Tengoi_en = IIf(IsDBNull(objReader("nv_Tengoi_en")) = True, "", objReader("nv_Tengoi_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_DM_GOIDICHVUEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_GOIDICHVUEntity) As Boolean Implements ITNTP_DM_GOIDICHVUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_GOIDICHVU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tengoi_vn", DbType.String, obj.nv_Tengoi_vn)
            db.AddInParameter(objCmd, "@nv_Tengoi_en", DbType.String, obj.nv_Tengoi_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Goidichvu As String) As Boolean Implements ITNTP_DM_GOIDICHVUDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_GOIDICHVU_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, uId_Goidichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_GOIDICHVUEntity) As Boolean Implements ITNTP_DM_GOIDICHVUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_GOIDICHVU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, obj.uId_Goidichvu)
            db.AddInParameter(objCmd, "@nv_Tengoi_vn", DbType.String, obj.nv_Tengoi_vn)
            db.AddInParameter(objCmd, "@nv_Tengoi_en", DbType.String, obj.nv_Tengoi_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable_List_Goi_The_Dichvu(ByVal vType As String, ByVal uId_Nhomdichvu As String) As System.Data.DataTable Implements ITNTP_DM_GOIDICHVUDA.SelectAllTable_List_Goi_The_Dichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spSelectAll_ListGoi_The_Dichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@vType", DbType.String, vType)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_Nhomdichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAllTable_ListLoai_Goi_The_Dichvu(ByVal vType As String) As System.Data.DataTable Implements ITNTP_DM_GOIDICHVUDA.SelectAllTable_ListLoai_Goi_The_Dichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spSelectAll_ListNhom_Goi_The_Dichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@vType", DbType.String, vType)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class