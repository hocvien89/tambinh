Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class clsD_TTV_DM_THETICHDIEM_CHUYENDOIDA
    Implements DB.iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA


    Public Function Delete(uId_TTDChuyendoi As String) As Boolean Implements iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.Delete
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_CHUYENDOI_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TTDChuyendoi", DbType.String, uId_TTDChuyendoi)
            objCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception

        End Try
    End Function

    Public Function Insert(objEnTTDChuyendoi As CM.icls_TTV_DM_Thetichdiem_ChuyendoiEntity) As String Implements iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_CHUYENDOI_Insert]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Dim st As String = ""
        Try
            db = DatabaseFactory.CreateDatabase
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Machuyendoi", DbType.String, objEnTTDChuyendoi.v_Machuyendoi)
            db.AddInParameter(objCmd, "@f_Giatri", DbType.String, objEnTTDChuyendoi.f_Giatri)
            db.AddInParameter(objCmd, "@i_Diem", DbType.String, objEnTTDChuyendoi.i_Diem)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, objEnTTDChuyendoi.uId_Thetichdiem)
            db.AddInParameter(objCmd, "@nv_Tenchuyendoi", DbType.String, objEnTTDChuyendoi.nv_Tenchuyendoi)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.String, objEnTTDChuyendoi.b_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            st = objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception

        End Try
        Return st
    End Function

    Public Function Update(objEnTTDChuyendoi As CM.icls_TTV_DM_Thetichdiem_ChuyendoiEntity) As Boolean Implements iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_CHUYENDOI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_TTDChuyendoi", DbType.String, objEnTTDChuyendoi.uId_TTDChuyendoi)
            db.AddInParameter(objCmd, "@v_Machuyendoi", DbType.String, objEnTTDChuyendoi.v_Machuyendoi)
            db.AddInParameter(objCmd, "@f_Giatri", DbType.String, objEnTTDChuyendoi.f_Giatri)
            db.AddInParameter(objCmd, "@i_Diem", DbType.String, objEnTTDChuyendoi.i_Diem)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, objEnTTDChuyendoi.uId_Thetichdiem)
            db.AddInParameter(objCmd, "@nv_Tenchuyendoi", DbType.String, objEnTTDChuyendoi.nv_Tenchuyendoi)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.String, objEnTTDChuyendoi.b_Trangthai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception

        End Try
    End Function

    Public Function SelectByIdThe(uId_Thetichdiem As String) As DataTable Implements iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.SelectByIdThe
        Dim db As Database
        Dim sp As String = "[dbo].[spTTV_DM_THETICHDIEM_CHUYENDOI_SelectByIdThe]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Thetichdiem", DbType.String, uId_Thetichdiem)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
End Class
