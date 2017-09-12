Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_Chitiet_ChiendichMKTDA

	Implements IMKT_Chitiet_ChiendichMKTDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_Chitiet_ChiendichMKTEntity) Implements IMKT_Chitiet_ChiendichMKTDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chitiet_ChiendichMKT_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_Chitiet_ChiendichMKTEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_Chitiet_ChiendichMKTEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_Chitiet_ChiendichMKTEntity)
                With lstobj(i)
                    .uId_Chitiet_Chiendich = IIf(IsDBNull(objReader("uId_Chitiet_Chiendich")) = True, "", Convert.ToString(objReader("uId_Chitiet_Chiendich")))
                    .uId_ChiendichMKT = IIf(IsDBNull(objReader("uId_ChiendichMKT")) = True, "", Convert.ToString(objReader("uId_ChiendichMKT")))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_Chitiet_ChiendichMKTEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IMKT_Chitiet_ChiendichMKTDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spMKT_Chitiet_ChiendichMKT_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Chitiet_Chiendich As String) As CM.MKT_Chitiet_ChiendichMKTEntity Implements IMKT_Chitiet_ChiendichMKTDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chitiet_ChiendichMKT_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_Chitiet_ChiendichMKTEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chitiet_Chiendich", System.Data.DbType.String, uId_Chitiet_Chiendich)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_Chitiet_ChiendichMKTEntity
            If objReader.Read Then
                With obj
                    .uId_Chitiet_Chiendich = IIf(IsDBNull(objReader("uId_Chitiet_Chiendich")) = True, "", Convert.ToString(objReader("uId_Chitiet_Chiendich")))
                    .uId_ChiendichMKT = IIf(IsDBNull(objReader("uId_ChiendichMKT")) = True, "", Convert.ToString(objReader("uId_ChiendichMKT")))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_Chitiet_ChiendichMKTEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_Chitiet_ChiendichMKTEntity) As Boolean Implements IMKT_Chitiet_ChiendichMKTDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chitiet_ChiendichMKT_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", DbType.String, obj.uId_ChiendichMKT)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_ChiendichMKT As String, ByVal uId_KH_Tiemnang As String) As Boolean Implements IMKT_Chitiet_ChiendichMKTDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chitiet_ChiendichMKT_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", DbType.String, uId_ChiendichMKT)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.MKT_Chitiet_ChiendichMKTEntity) As Boolean Implements IMKT_Chitiet_ChiendichMKTDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chitiet_ChiendichMKT_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chitiet_Chiendich", DbType.String, obj.uId_Chitiet_Chiendich)
            db.AddInParameter(objCmd, "@uId_ChiendichMKT", DbType.String, obj.uId_ChiendichMKT)
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class