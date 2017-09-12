Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class MKT_LOAITAGDA
    Implements IMKT_LOAITAGSDA


    Private log As New LogError.ShowError
    Public Function Insert(ByVal obj As CM.MKT_LOAITAGSEntity) As Boolean Implements IMKT_LOAITAGSDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_LoaiTags_INSERT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenLoaiTag_vn", DbType.String, obj.nv_TenLoaiTag_vn)
            db.AddInParameter(objCmd, "@i_Thutu", DbType.Int32, obj.i_Thutu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_LOAITAGSEntity) As Boolean Implements IMKT_LOAITAGSDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_LoaiTags_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenLoaiTag_vn", DbType.String, obj.nv_TenLoaiTag_vn)
            db.AddInParameter(objCmd, "@i_Thutu", DbType.Int32, obj.i_Thutu)
            db.AddInParameter(objCmd, "@Id_LoaiTag", DbType.Int32, obj.Id_LoaiTag)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAll() As System.Data.DataTable Implements IMKT_LOAITAGSDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_LoaiTags_SelectAll]"
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

    Public Function SelectById(ByVal Id_Loaitag As Integer) As CM.MKT_LOAITAGSEntity Implements IMKT_LOAITAGSDA.SelectById
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_LoaiTags_SelectById]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_LOAITAGSEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Id_Loaitag", System.Data.DbType.String, Id_Loaitag)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_LOAITAGSEntity
            If objReader.Read Then
                With obj
                    .Id_LoaiTag = IIf(IsDBNull(objReader("Id_Loaitag")) = True, "", Convert.ToString(objReader("Id_Loaitag")))
                    .nv_TenLoaiTag_vn = IIf(IsDBNull(objReader("nv_TenLoaiTag_vn")) = True, "", Convert.ToString(objReader("nv_TenLoaiTag_vn")))
                    .i_Thutu = IIf(IsDBNull(objReader("i_Thutu")) = True, "", Convert.ToInt32(objReader("i_Thutu")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_LOAITAGSEntity
        End Try
    End Function

    Public Function DeleteByID(ByVal i_Thutu As Integer) As Boolean Implements IMKT_LOAITAGSDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_DMLoaiTag_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Thutu", DbType.Int32, i_Thutu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class
