Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class TNTP_CHITIEUTHAMDODA

	Implements ITNTP_CHITIEUTHAMDODA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_NhomThamdo As String) As System.Collections.Generic.List(Of CM.TNTP_CHITIEUTHAMDOEntity) Implements ITNTP_CHITIEUTHAMDODA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.TNTP_CHITIEUTHAMDOEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_NhomThamdo", DbType.String, uId_NhomThamdo)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.TNTP_CHITIEUTHAMDOEntity)
            While (objReader.Read())
                lstobj.Add(New CM.TNTP_CHITIEUTHAMDOEntity)
                With lstobj(i)
                    .uId_Chitieuthamdo = IIf(IsDBNull(objReader("uId_Chitieuthamdo")) = True, "", Convert.ToString(objReader("uId_Chitieuthamdo")))
                    .nv_Tenchitieuthamdo_vn = IIf(IsDBNull(objReader("nv_Tenchitieuthamdo_vn")) = True, "", objReader("nv_Tenchitieuthamdo_vn"))
                    .nv_Tenchitieuthamdo_en = IIf(IsDBNull(objReader("nv_Tenchitieuthamdo_en")) = True, "", objReader("nv_Tenchitieuthamdo_en"))
                    .i_Kieugiatri = IIf(IsDBNull(objReader("i_Kieugiatri")) = True, "", objReader("i_Kieugiatri"))
                    .uId_NhomThamdo = IIf(IsDBNull(objReader("uId_NhomThamdo")) = True, "", Convert.ToString(objReader("uId_NhomThamdo")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.TNTP_CHITIEUTHAMDOEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_NhomThamdo AS String) AS System.Data.DataTable Implements ITNTP_CHITIEUTHAMDODA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet 
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_NhomThamdo", DbType.String,uId_NhomThamdo)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function


    Public Function SelectByID(ByVal uId_Chitieuthamdo As String) As CM.TNTP_CHITIEUTHAMDOEntity Implements ITNTP_CHITIEUTHAMDODA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.TNTP_CHITIEUTHAMDOEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chitieuthamdo", DbType.String, uId_Chitieuthamdo)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.TNTP_CHITIEUTHAMDOEntity
            If objReader.Read Then
                With obj
                    .uId_Chitieuthamdo = IIf(IsDBNull(objReader("uId_Chitieuthamdo")) = True, "", Convert.ToString(objReader("uId_Chitieuthamdo")))
                    .nv_Tenchitieuthamdo_vn = IIf(IsDBNull(objReader("nv_Tenchitieuthamdo_vn")) = True, "", objReader("nv_Tenchitieuthamdo_vn"))
                    .nv_Tenchitieuthamdo_en = IIf(IsDBNull(objReader("nv_Tenchitieuthamdo_en")) = True, "", objReader("nv_Tenchitieuthamdo_en"))
                    .i_Kieugiatri = IIf(IsDBNull(objReader("i_Kieugiatri")) = True, "", objReader("i_Kieugiatri"))
                    .uId_NhomThamdo = IIf(IsDBNull(objReader("uId_NhomThamdo")) = True, "", Convert.ToString(objReader("uId_NhomThamdo")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.TNTP_CHITIEUTHAMDOEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_CHITIEUTHAMDOEntity) As Boolean Implements ITNTP_CHITIEUTHAMDODA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenchitieuthamdo_vn", DbType.String, obj.nv_Tenchitieuthamdo_vn)
            db.AddInParameter(objCmd, "@nv_Tenchitieuthamdo_en", DbType.String, obj.nv_Tenchitieuthamdo_en)
            db.AddInParameter(objCmd, "@i_Kieugiatri", DbType.String, obj.i_Kieugiatri)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Chitieuthamdo AS String) As Boolean Implements ITNTP_CHITIEUTHAMDODA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Chitieuthamdo", DbType.String,uId_Chitieuthamdo)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.TNTP_CHITIEUTHAMDOEntity) As Boolean Implements ITNTP_CHITIEUTHAMDODA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_CHITIEUTHAMDO_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chitieuthamdo", DbType.String, obj.uId_Chitieuthamdo)
            db.AddInParameter(objCmd, "@nv_Tenchitieuthamdo_vn", DbType.String, obj.nv_Tenchitieuthamdo_vn)
            db.AddInParameter(objCmd, "@nv_Tenchitieuthamdo_en", DbType.String, obj.nv_Tenchitieuthamdo_en)
            db.AddInParameter(objCmd, "@i_Kieugiatri", DbType.String, obj.i_Kieugiatri)
            db.AddInParameter(objCmd, "@uId_NhomThamdo", DbType.String, obj.uId_NhomThamdo)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class