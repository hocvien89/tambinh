Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class PQP_TRANGTHAIKHCHOXULYDA

    Implements IPQP_TRANGTHAIKHCHOXULYDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.PQP_TRANGTHAIKHCHOXULYEntity) Implements IPQP_TRANGTHAIKHCHOXULYDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAIKHCHOXULY_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.PQP_TRANGTHAIKHCHOXULYEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.PQP_TRANGTHAIKHCHOXULYEntity)
            While (objReader.Read())
                lstobj.Add(New CM.PQP_TRANGTHAIKHCHOXULYEntity)
                With lstobj(i)
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .d_ThoigianchuyenTT = IIf(IsDBNull(objReader("d_ThoigianchuyenTT")) = True, Nothing, objReader("d_ThoigianchuyenTT"))
                    '.uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.PQP_TRANGTHAIKHCHOXULYEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IPQP_TRANGTHAIKHCHOXULYDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAIKHCHOXULY_SelectAll]"
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

    Public Function SelectByID(ByVal uId_TrangthaiKH As String) As CM.PQP_TRANGTHAIKHCHOXULYEntity Implements IPQP_TRANGTHAIKHCHOXULYDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAIKHCHOXULY_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.PQP_TRANGTHAIKHCHOXULYEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", System.Data.DbType.String, uId_TrangthaiKH)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.PQP_TRANGTHAIKHCHOXULYEntity
            If objReader.Read Then
                With obj
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .d_ThoigianchuyenTT = IIf(IsDBNull(objReader("d_ThoigianchuyenTT")) = True, Nothing, objReader("d_ThoigianchuyenTT"))
                    '.uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.PQP_TRANGTHAIKHCHOXULYEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.PQP_TRANGTHAIKHCHOXULYEntity) As Boolean Implements IPQP_TRANGTHAIKHCHOXULYDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAIKHCHOXULY_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (obj.d_ThoigianchuyenTT <> Nothing And obj.d_ThoigianchuyenTT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_ThoigianchuyenTT", DbType.DateTime, obj.d_ThoigianchuyenTT)
            End If
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_TrangthaiKH As String) As Boolean Implements IPQP_TRANGTHAIKHCHOXULYDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAIKHCHOXULY_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", DbType.String, uId_TrangthaiKH)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.PQP_TRANGTHAIKHCHOXULYEntity) As Boolean Implements IPQP_TRANGTHAIKHCHOXULYDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spPQP_TRANGTHAIKHCHOXULY_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", DbType.String, obj.uId_TrangthaiKH)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            If (obj.d_ThoigianchuyenTT <> Nothing And obj.d_ThoigianchuyenTT <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_ThoigianchuyenTT", DbType.DateTime, obj.d_ThoigianchuyenTT)
            End If
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class