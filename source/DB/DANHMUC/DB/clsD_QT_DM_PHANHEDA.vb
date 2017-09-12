Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QT_DM_PHANHEDA

	Implements IQT_DM_PHANHEDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QT_DM_PHANHEEntity) Implements IQT_DM_PHANHEDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_PHANHE_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QT_DM_PHANHEEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QT_DM_PHANHEEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QT_DM_PHANHEEntity)
                With lstobj(i)
                    .uId_Phanhe = IIf(IsDBNull(objReader("uId_Phanhe")) = True, "", Convert.ToString(objReader("uId_Phanhe")))
                    .nv_Tenphanhe_vn = IIf(IsDBNull(objReader("nv_Tenphanhe_vn")) = True, "", objReader("nv_Tenphanhe_vn"))
                    .nv_Tenphanhe_en = IIf(IsDBNull(objReader("nv_Tenphanhe_en")) = True, "", objReader("nv_Tenphanhe_en"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QT_DM_PHANHEEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQT_DM_PHANHEDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQT_DM_PHANHE_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Phanhe As String) As CM.QT_DM_PHANHEEntity Implements IQT_DM_PHANHEDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_PHANHE_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QT_DM_PHANHEEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phanhe", System.Data.DbType.String, uId_Phanhe)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QT_DM_PHANHEEntity
            If objReader.Read Then
                With obj
                    .uId_Phanhe = IIf(IsDBNull(objReader("uId_Phanhe")) = True, "", Convert.ToString(objReader("uId_Phanhe")))
                    .nv_Tenphanhe_vn = IIf(IsDBNull(objReader("nv_Tenphanhe_vn")) = True, "", objReader("nv_Tenphanhe_vn"))
                    .nv_Tenphanhe_en = IIf(IsDBNull(objReader("nv_Tenphanhe_en")) = True, "", objReader("nv_Tenphanhe_en"))
                    .nv_Ghichu_vn = IIf(IsDBNull(objReader("nv_Ghichu_vn")) = True, "", objReader("nv_Ghichu_vn"))
                    .nv_Ghichu_en = IIf(IsDBNull(objReader("nv_Ghichu_en")) = True, "", objReader("nv_Ghichu_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QT_DM_PHANHEEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QT_DM_PHANHEEntity) As Boolean Implements IQT_DM_PHANHEDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_PHANHE_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenphanhe_vn", DbType.String, obj.nv_Tenphanhe_vn)
            db.AddInParameter(objCmd, "@nv_Tenphanhe_en", DbType.String, obj.nv_Tenphanhe_en)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Phanhe AS String) As Boolean Implements IQT_DM_PHANHEDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQT_DM_PHANHE_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String,uId_Phanhe)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QT_DM_PHANHEEntity) As Boolean Implements IQT_DM_PHANHEDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_PHANHE_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String, obj.uId_Phanhe)
            db.AddInParameter(objCmd, "@nv_Tenphanhe_vn", DbType.String, obj.nv_Tenphanhe_vn)
            db.AddInParameter(objCmd, "@nv_Tenphanhe_en", DbType.String, obj.nv_Tenphanhe_en)
            db.AddInParameter(objCmd, "@nv_Ghichu_vn", DbType.String, obj.nv_Ghichu_vn)
            db.AddInParameter(objCmd, "@nv_Ghichu_en", DbType.String, obj.nv_Ghichu_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class