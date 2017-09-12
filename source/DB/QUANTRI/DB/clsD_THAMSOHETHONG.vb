Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_THAMSOHETHONG
    Implements iClisD_THAMSOHETHONG


    Private log As New LogError.ShowError

    Public Function SelectByV_Tenbien(ByVal v_Tenbien As String) As CM.cls_QT_THAMSOHETHONG Implements iClisD_THAMSOHETHONG.SelectByV_Tenbien
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_THAMSOHETHONG_SelectByV_Tenbien]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.cls_QT_THAMSOHETHONG = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Tenbien", System.Data.DbType.String, v_Tenbien)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.cls_QT_THAMSOHETHONG
            If objReader.Read Then
                With obj
                    .v_Tenbien = IIf(IsDBNull(objReader("v_Tenbien")) = True, "", Convert.ToString(objReader("v_Tenbien")))
                    .v_Giatri = IIf(IsDBNull(objReader("v_Giatri")) = True, "", Convert.ToString(objReader("v_Giatri")))
                    .f_Giatri = IIf(IsDBNull(objReader("f_Giatri")) = True, 0, objReader("f_Giatri"))
                End With
            End If
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
        End Try
        Return obj
    End Function

    Public Function UpdateByV_Tenbien(ByVal obj As CM.cls_QT_THAMSOHETHONG) As Boolean Implements iClisD_THAMSOHETHONG.UpdateByV_Tenbien
        Dim db As Database
        Dim sp As String = "spQT_THAMSOHETHONG_UpdateByV_Tenbien"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@v_Tenbien", DbType.String, obj.v_Tenbien)
            db.AddInParameter(objCmd, "@v_Giatri", DbType.String, obj.v_Giatri)
            db.AddInParameter(objCmd, "@f_Giatri", DbType.Double, obj.f_Giatri)

            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Insert(objEnThamso As CM.cls_QT_THAMSOHETHONG) As Boolean Implements iClisD_THAMSOHETHONG.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_THAMSOHETHONG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@v_Tenbien", DbType.String, objEnThamso.v_Tenbien)
            db.AddInParameter(objCmd, "@v_Giatri", DbType.String, objEnThamso.v_Giatri)
            db.AddInParameter(objCmd, "@f_Giatri", DbType.Double, objEnThamso.f_Giatri)
            db.AddInParameter(objCmd, "@nv_Mota_vn", DbType.String, objEnThamso.nv_Mota_vn)
            db.AddInParameter(objCmd, "@i_STT", DbType.Int16, objEnThamso.i_STT)
            db.AddInParameter(objCmd, "@b_Hoatdong", DbType.Boolean, objEnThamso.b_Hoatdong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Delete(uId_thamso As String) As Boolean Implements iClisD_THAMSOHETHONG.Delete
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_THAMSOHETHONG_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thamsohethong", DbType.String, uId_thamso)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function SelectAllTable() As DataTable Implements iClisD_THAMSOHETHONG.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_THAMSOHETHONG_SelectAllTable]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Function Update(objEnThamso As CM.cls_QT_THAMSOHETHONG) As Boolean Implements iClisD_THAMSOHETHONG.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_THAMSOHETHONG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)

            db.AddInParameter(objCmd, "@v_Tenbien", DbType.String, objEnThamso.v_Tenbien)
            db.AddInParameter(objCmd, "@v_Giatri", DbType.String, objEnThamso.v_Giatri)
            db.AddInParameter(objCmd, "@f_Giatri", DbType.Double, objEnThamso.f_Giatri)
            db.AddInParameter(objCmd, "@nv_Mota_vn", DbType.String, objEnThamso.nv_Mota_vn)
            db.AddInParameter(objCmd, "@i_STT", DbType.Int16, objEnThamso.i_STT)
            db.AddInParameter(objCmd, "@b_Hoatdong", DbType.Boolean, objEnThamso.b_Hoatdong)
            db.AddInParameter(objCmd, "@uId_Thamso", DbType.String, objEnThamso.uId_Thamsohethong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            'log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class

