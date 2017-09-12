Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class clsD_TTV_DM_THETICHDIEMDA
    Implements DB.iclsD_TTV_DM_THETICHDIEMDA
    Private log As New LogError.ShowError

    Public Function DeleteById(uId_Thetichdiem As String) As Boolean Implements iclsD_TTV_DM_THETICHDIEMDA.DeleteById
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, uId_Thetichdiem)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function Insert(objEnThetichdiem As CM.icls_TTV_DM_ThetichdiemEntity) As Boolean Implements iclsD_TTV_DM_THETICHDIEMDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenthetichdiem", DbType.String, objEnThetichdiem.nv_Tenthetichdiem)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, objEnThetichdiem.uId_Cuahang)
            db.AddInParameter(objCmd, "@f_Diemkichhoat", DbType.Double, objEnThetichdiem.f_Diemkichhoat)
            db.AddInParameter(objCmd, "@v_Mathetichdiem", DbType.String, objEnThetichdiem.v_Mathetichdiem)
            'db.AddInParameter(objCmd, "@f_Sotiendoi", DbType.Double, objEnThetichdiem.f_Sotiendoi)
            'db.AddInParameter(objCmd, "@i_Sodiemdoi", DbType.Int32, objEnThetichdiem.i_Sodiemdoi)
            db.AddInParameter(objCmd, "@f_Uutien", DbType.Double, objEnThetichdiem.f_Uutien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function SelectAllTable(uId_Cuahang As String) As DataTable Implements iclsD_TTV_DM_THETICHDIEMDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_SelectAllTable]"
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

    Public Function Update(objEnThetichdiem As CM.icls_TTV_DM_ThetichdiemEntity) As Boolean Implements iclsD_TTV_DM_THETICHDIEMDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, objEnThetichdiem.uId_Thetichdiem)
            db.AddInParameter(objCmd, "@nv_Tenthetichdiem", DbType.String, objEnThetichdiem.nv_Tenthetichdiem)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, objEnThetichdiem.uId_Cuahang)
            db.AddInParameter(objCmd, "@f_Diemkichhoat", DbType.Double, objEnThetichdiem.f_Diemkichhoat)
            db.AddInParameter(objCmd, "@v_Mathetichdiem", DbType.String, objEnThetichdiem.v_Mathetichdiem)
            'db.AddInParameter(objCmd, "@f_Sotiendoi", DbType.Double, objEnThetichdiem.f_Sotiendoi)
            'db.AddInParameter(objCmd, "@i_Sodiemdoi", DbType.Int32, objEnThetichdiem.i_Sodiemdoi)
            db.AddInParameter(objCmd, "@f_Uutien", DbType.Double, objEnThetichdiem.f_Uutien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
    End Function

    Public Function SelectUutienByKH(uId_Khachhang As String) As String Implements iclsD_TTV_DM_THETICHDIEMDA.SelectUutienByKH
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_SelectUutien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)("f_Uutien").ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return "0"
        End Try
    End Function

    Public Function SelectByID(uId_Khachhang As String) As CM.cls_DM_ThetichdiemEntity Implements iclsD_TTV_DM_THETICHDIEMDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_SelectUutien]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.cls_DM_ThetichdiemEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.cls_DM_ThetichdiemEntity
            If objReader.Read Then
                With obj

                    .f_Uutien = IIf(IsDBNull(objReader("f_Uutien")) = True, 0, objReader("f_Uutien"))

                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.cls_DM_ThetichdiemEntity
        End Try
    End Function

    Public Function SelectById_Thetichdiem(uid_Thetichdiem As String) As DataTable Implements iclsD_TTV_DM_THETICHDIEMDA.SelectById_Thetichdiem
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Select_Thetichdiem_byId]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, uid_Thetichdiem)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
