Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLCN_CONGNO_SPDA

	Implements IQLCN_CONGNO_SPDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLCN_CONGNO_SPEntity) Implements IQLCN_CONGNO_SPDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLCN_CONGNO_SPEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLCN_CONGNO_SPEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLCN_CONGNO_SPEntity)
                With lstobj(i)
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLCN_CONGNO_SPEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQLCN_CONGNO_SPDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Phieuxuat As String) As CM.QLCN_CONGNO_SPEntity Implements IQLCN_CONGNO_SPDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QLCN_CONGNO_SPEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", System.Data.DbType.String, uId_Phieuxuat)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QLCN_CONGNO_SPEntity
            If objReader.Read Then
                With obj
                    .uId_Phieuxuat = IIf(IsDBNull(objReader("uId_Phieuxuat")) = True, "", Convert.ToString(objReader("uId_Phieuxuat")))
                    .f_Sotien = IIf(IsDBNull(objReader("f_Sotien")) = True, 0, objReader("f_Sotien"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QLCN_CONGNO_SPEntity
        End Try
    End Function

    Public Function CongNoKH(ByVal uId_Khachhang As String) As String Implements IQLCN_CONGNO_SPDA.CongNoKH
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_Khachhang]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function


    Public Function Insert(ByVal obj As CM.QLCN_CONGNO_SPEntity) As Boolean Implements IQLCN_CONGNO_SPDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Phieuxuat AS String) As Boolean Implements IQLCN_CONGNO_SPDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String,uId_Phieuxuat)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QLCN_CONGNO_SPEntity) As Boolean Implements IQLCN_CONGNO_SPDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_CONGNO_SP_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieuxuat", DbType.String, obj.uId_Phieuxuat)
            db.AddInParameter(objCmd, "@f_Sotien", DbType.Double, obj.f_Sotien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class