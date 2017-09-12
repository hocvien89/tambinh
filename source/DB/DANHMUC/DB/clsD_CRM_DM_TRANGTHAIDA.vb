Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_DM_TRANGTHAIDA

	Implements ICRM_DM_TRANGTHAIDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_DM_TRANGTHAIEntity) Implements ICRM_DM_TRANGTHAIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TRANGTHAI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_DM_TRANGTHAIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_DM_TRANGTHAIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_DM_TRANGTHAIEntity)
                With lstobj(i)
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .v_Matrangthai = IIf(IsDBNull(objReader("v_Matrangthai")) = True, "", objReader("v_Matrangthai"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                    .nv_Tentrangthai_en = IIf(IsDBNull(objReader("nv_Tentrangthai_en")) = True, "", objReader("nv_Tentrangthai_en"))
                    .v_Mau_Chu = IIf(IsDBNull(objReader("v_Mau_Chu")) = True, "", objReader("v_Mau_Chu"))
                    .v_Mau_Nen = IIf(IsDBNull(objReader("v_Mau_Nen")) = True, "", objReader("v_Mau_Nen"))
                    .i_Type = IIf(IsDBNull(objReader("i_Type")) = True, 0, objReader("i_Type"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_DM_TRANGTHAIEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ICRM_DM_TRANGTHAIDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spCRM_DM_TRANGTHAI_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Trangthai As String) As CM.CRM_DM_TRANGTHAIEntity Implements ICRM_DM_TRANGTHAIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TRANGTHAI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_DM_TRANGTHAIEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Trangthai", System.Data.DbType.String, uId_Trangthai)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_DM_TRANGTHAIEntity
            If objReader.Read Then
                With obj
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .v_Matrangthai = IIf(IsDBNull(objReader("v_Matrangthai")) = True, "", objReader("v_Matrangthai"))
                    .nv_Tentrangthai_vn = IIf(IsDBNull(objReader("nv_Tentrangthai_vn")) = True, "", objReader("nv_Tentrangthai_vn"))
                    .nv_Tentrangthai_en = IIf(IsDBNull(objReader("nv_Tentrangthai_en")) = True, "", objReader("nv_Tentrangthai_en"))
                    .v_Mau_Chu = IIf(IsDBNull(objReader("v_Mau_Chu")) = True, "", objReader("v_Mau_Chu"))
                    .v_Mau_Nen = IIf(IsDBNull(objReader("v_Mau_Nen")) = True, "", objReader("v_Mau_Nen"))
                    .i_Type = IIf(IsDBNull(objReader("i_Type")) = True, 0, objReader("i_Type"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_DM_TRANGTHAIEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_TRANGTHAIEntity) As Boolean Implements ICRM_DM_TRANGTHAIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TRANGTHAI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Matrangthai", DbType.String, obj.v_Matrangthai)
            db.AddInParameter(objCmd, "@nv_Tentrangthai_vn", DbType.String, obj.nv_Tentrangthai_vn)
            db.AddInParameter(objCmd, "@nv_Tentrangthai_en", DbType.String, obj.nv_Tentrangthai_en)
            db.AddInParameter(objCmd, "@v_Mau_Chu", DbType.String, obj.v_Mau_Chu)
            db.AddInParameter(objCmd, "@v_Mau_Nen", DbType.String, obj.v_Mau_Nen)
            db.AddInParameter(objCmd, "@i_Type", DbType.Int32, obj.i_Type)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Trangthai AS String) As Boolean Implements ICRM_DM_TRANGTHAIDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spCRM_DM_TRANGTHAI_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String,uId_Trangthai)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.CRM_DM_TRANGTHAIEntity) As Boolean Implements ICRM_DM_TRANGTHAIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TRANGTHAI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Trangthai", DbType.String, obj.uId_Trangthai)
            db.AddInParameter(objCmd, "@v_Matrangthai", DbType.String, obj.v_Matrangthai)
            db.AddInParameter(objCmd, "@nv_Tentrangthai_vn", DbType.String, obj.nv_Tentrangthai_vn)
            db.AddInParameter(objCmd, "@nv_Tentrangthai_en", DbType.String, obj.nv_Tentrangthai_en)
            db.AddInParameter(objCmd, "@v_Mau_Chu", DbType.String, obj.v_Mau_Chu)
            db.AddInParameter(objCmd, "@v_Mau_Nen", DbType.String, obj.v_Mau_Nen)
            db.AddInParameter(objCmd, "@i_Type", DbType.Int32, obj.i_Type)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class