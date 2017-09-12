Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_PHIEUDICHVU_KHUYENMAIDA

	Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KHUYENMAI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity)
                With lstobj(i)
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_DM_Khuyenmai = IIf(IsDBNull(objReader("uId_DM_Khuyenmai")) = True, "", Convert.ToString(objReader("uId_DM_Khuyenmai")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KHUYENMAI_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String, ByVal uId_DM_Khuyenmai As String) As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KHUYENMAI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", System.Data.DbType.String, uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", System.Data.DbType.String, uId_DM_Khuyenmai)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity
            If objReader.Read Then
                With obj
                    .uId_Phieudichvu = IIf(IsDBNull(objReader("uId_Phieudichvu")) = True, "", Convert.ToString(objReader("uId_Phieudichvu")))
                    .uId_DM_Khuyenmai = IIf(IsDBNull(objReader("uId_DM_Khuyenmai")) = True, "", Convert.ToString(objReader("uId_DM_Khuyenmai")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) As Boolean Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KHUYENMAI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", DbType.String, obj.uId_DM_Khuyenmai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Phieudichvu AS String,ByVal uId_DM_Khuyenmai AS String) As Boolean Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KHUYENMAI_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String,uId_Phieudichvu)
			db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", DbType.String,uId_DM_Khuyenmai)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) As Boolean Implements ITNTP_PHIEUDICHVU_KHUYENMAIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_KHUYENMAI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, obj.uId_Phieudichvu)
            db.AddInParameter(objCmd, "@uId_DM_Khuyenmai", DbType.String, obj.uId_DM_Khuyenmai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class