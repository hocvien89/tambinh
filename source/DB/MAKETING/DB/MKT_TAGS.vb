Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class MKT_TAGS
    Implements IMKT_TAGS

    Private log As New LogError.ShowError
    Public Function DeleteByID(ByVal uId_Tags As String) As Boolean Implements IMKT_TAGS.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_DeleteById]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tags", DbType.String, uId_Tags)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_TAGS) As Boolean Implements IMKT_TAGS.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_INSERT]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TagName_vn", DbType.String, obj.nv_TagName_vn)
            db.AddInParameter(objCmd, "@MaLoai", DbType.String, obj.MaLoai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable(ByVal key As String) As System.Data.DataTable Implements IMKT_TAGS.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@key", System.Data.DbType.String, key)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal uId_Tags As String) As CM.MKT_TAGS Implements IMKT_TAGS.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_SelectById]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_TAGS = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tags", System.Data.DbType.String, uId_Tags)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_TAGS
            If objReader.Read Then
                With obj
                    .uId_Tags = IIf(IsDBNull(objReader("uId_Tags")) = True, "", Convert.ToString(objReader("uId_Tags")))
                    .nv_TagName_vn = IIf(IsDBNull(objReader("nv_TagName_vn")) = True, "", Convert.ToString(objReader("nv_TagName_vn")))
                    .MaLoai = IIf(IsDBNull(objReader("MaLoai")) = True, "", Convert.ToInt32(objReader("MaLoai")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_TAGS
        End Try
    End Function

    Public Function TimKiem(ByVal keyword As String) As System.Data.DataTable Implements IMKT_TAGS.TimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_TimKiem]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@keyword", System.Data.DbType.String, keyword)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_TAGS) As Boolean Implements IMKT_TAGS.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tags", DbType.String, obj.uId_Tags)
            db.AddInParameter(objCmd, "@nv_TagName_vn", DbType.String, obj.nv_TagName_vn)
            db.AddInParameter(objCmd, "@MaLoai", DbType.String, obj.MaLoai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTableByMaLoai(ByVal MaLoai As Integer) As System.Data.DataTable Implements IMKT_TAGS.SelectAllTableByMaLoai
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_SelectAllByMaLoai]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaLoai", DbType.String, MaLoai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectByTen(ByVal nv_TenTag As String) As CM.MKT_TAGS Implements IMKT_TAGS.SelectByTen
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_SelectByTen]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_TAGS = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_TenTag_vn", System.Data.DbType.String, nv_TenTag)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_TAGS
            If objReader.Read Then
                With obj
                    .uId_Tags = IIf(IsDBNull(objReader("uId_Tags")) = True, "", Convert.ToString(objReader("uId_Tags")))
                    .nv_TagName_vn = IIf(IsDBNull(objReader("nv_TagName_vn")) = True, "", Convert.ToString(objReader("nv_TagName_vn")))
                    .MaLoai = IIf(IsDBNull(objReader("MaLoai")) = True, "", Convert.ToInt32(objReader("MaLoai")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_TAGS
        End Try
    End Function

    Public Function SelectByIDAndMaloai(ByVal uId_Tags As String, ByVal Maloai As Integer) As CM.MKT_TAGS Implements IMKT_TAGS.SelectByIDAndMaloai
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Tags_SelectByIdAndMaloai]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_TAGS = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tags", System.Data.DbType.String, uId_Tags)
            db.AddInParameter(objCmd, "@MaLoai", System.Data.DbType.String, Maloai)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_TAGS
            If objReader.Read Then
                With obj
                    .nv_TagName_vn = IIf(IsDBNull(objReader("nv_TagName_vn")) = True, "", Convert.ToString(objReader("nv_TagName_vn")))
                    .MaLoai = IIf(IsDBNull(objReader("MaLoai")) = True, "", Convert.ToInt32(objReader("MaLoai")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_TAGS
        End Try
    End Function

    Public Function SelectAllTable_Nokey() As DataTable Implements IMKT_TAGS.SelectAllTable_Nokey
        Dim db As Database
        Dim sp As String = "[dbo].[sp_MKT_Tag_SelectAll]"
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

    Public Function SelectAllTable_LoaiTag() As DataTable Implements IMKT_TAGS.SelectAllTable_LoaiTag
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
End Class
