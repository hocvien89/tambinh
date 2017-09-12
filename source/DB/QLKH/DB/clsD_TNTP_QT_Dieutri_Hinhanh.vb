Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class clsD_TNTP_QT_Dieutri_Hinhanh
    Implements iClsD_TNTP_QT_Dieutri_Hinhanh

    Public Function Delete(uId_Dieutri_Hinhanh As String) As Boolean Implements iClsD_TNTP_QT_Dieutri_Hinhanh.Delete
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Hinhanh_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dieutri_Hinhanh", DbType.String, uId_Dieutri_Hinhanh)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Insert(objEnDieutriHinh As CM.iCls_TNTP_QT_Dieutri_Hinhanh) As String Implements iClsD_TNTP_QT_Dieutri_Hinhanh.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Hinhanh_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, objEnDieutriHinh.uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@nv_Hinhanh_vn", DbType.String, objEnDieutriHinh.nv_Hinhanh_nv)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SelectAllTable() As DataTable Implements iClsD_TNTP_QT_Dieutri_Hinhanh.SelectAllTable
        Dim db As Database
        Dim sp As String = ""
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectByuId_Dieutri(uId_Dieutri As String) As DataTable Implements iClsD_TNTP_QT_Dieutri_Hinhanh.SelectByuId_Dieutri
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Hinhanh_SelectAllTable]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, uId_Dieutri)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function Update(objEnDieutriHinh As CM.iCls_TNTP_QT_Dieutri_Hinhanh) As Boolean Implements iClsD_TNTP_QT_Dieutri_Hinhanh.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_QT_Dieutri_Hinhanh_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Hinhanh_Congdoan", DbType.String, objEnDieutriHinh.uId_Hinhanh_Congdoan)
            db.AddInParameter(objCmd, "@uId_QT_Dieutri", DbType.String, objEnDieutriHinh.uId_QT_Dieutri)
            db.AddInParameter(objCmd, "@nv_Hinhanh_vn", DbType.String, objEnDieutriHinh.nv_Hinhanh_nv)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
