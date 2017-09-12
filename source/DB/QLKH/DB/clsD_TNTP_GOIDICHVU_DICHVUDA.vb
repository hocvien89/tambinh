Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_GOIDICHVU_DICHVUDA

    Implements ITNTP_GOIDICHVU_DICHVUDA

    Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Goidichvu As String) As System.Collections.Generic.List(Of CM.TNTP_GOIDICHVU_DICHVUEntity) Implements ITNTP_GOIDICHVU_DICHVUDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_GOIDICHVU_DICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_GOIDICHVU_DICHVUEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, uId_Goidichvu)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_GOIDICHVU_DICHVUEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_GOIDICHVU_DICHVUEntity)
                With lstobj(i)
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_GOIDICHVU_DICHVUEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Goidichvu As String) As System.Data.DataTable Implements ITNTP_GOIDICHVU_DICHVUDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_GOIDICHVU_DICHVU_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, uId_Goidichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Goidichvu As String, ByVal uId_Dichvu As String) As CM.TNTP_GOIDICHVU_DICHVUEntity Implements ITNTP_GOIDICHVU_DICHVUDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_GOIDICHVU_DICHVU_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_GOIDICHVU_DICHVUEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, uId_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_GOIDICHVU_DICHVUEntity
            If objReader.Read Then
                With obj
                    .uId_Goidichvu = IIf(IsDBNull(objReader("uId_Goidichvu")) = True, "", Convert.ToString(objReader("uId_Goidichvu")))
                    .uId_Dichvu = IIf(IsDBNull(objReader("uId_Dichvu")) = True, "", Convert.ToString(objReader("uId_Dichvu")))
                    .nv_Tendichvu_vn = IIf(IsDBNull(objReader("nv_Tendichvu_vn")) = True, "", objReader("nv_Tendichvu_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_GOIDICHVU_DICHVUEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_GOIDICHVU_DICHVUEntity) As Boolean Implements ITNTP_GOIDICHVU_DICHVUDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_GOIDICHVU_DICHVU_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, obj.uId_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.AddInParameter(objCmd, "@f_Soluong", DbType.String, obj.f_Soluong)
            db.AddInParameter(objCmd, "@f_Dongia", DbType.String, obj.f_Dongia)
            db.AddInParameter(objCmd, "@f_Thanhtien", DbType.String, obj.f_Thanhtien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Goidichvu As String, ByVal uId_Dichvu As String) As Boolean Implements ITNTP_GOIDICHVU_DICHVUDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_GOIDICHVU_DICHVU_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, uId_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.TNTP_GOIDICHVU_DICHVUEntity) As Boolean Implements ITNTP_GOIDICHVU_DICHVUDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_GOIDICHVU_DICHVU_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Goidichvu", DbType.String, obj.uId_Goidichvu)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, obj.uId_Dichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

   
End Class