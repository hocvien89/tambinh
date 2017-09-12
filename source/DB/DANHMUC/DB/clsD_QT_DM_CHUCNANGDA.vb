Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QT_DM_CHUCNANGDA

	Implements IQT_DM_CHUCNANGDA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Phanhe As String) As System.Collections.Generic.List(Of CM.QT_DM_CHUCNANGEntity) Implements IQT_DM_CHUCNANGDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CHUCNANG_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QT_DM_CHUCNANGEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String, uId_Phanhe)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QT_DM_CHUCNANGEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QT_DM_CHUCNANGEntity)
                With lstobj(i)
                    .uId_Chucnang = IIf(IsDBNull(objReader("uId_Chucnang")) = True, "", Convert.ToString(objReader("uId_Chucnang")))
                    .uId_Phanhe = IIf(IsDBNull(objReader("uId_Phanhe")) = True, "", Convert.ToString(objReader("uId_Phanhe")))
                    .nv_Tenbien = IIf(IsDBNull(objReader("nv_Tenbien")) = True, "", objReader("nv_Tenbien"))
                    .nv_Tenchucnang_vn = IIf(IsDBNull(objReader("nv_Tenchucnang_vn")) = True, "", objReader("nv_Tenchucnang_vn"))
                    .nv_Tenchucnang_en = IIf(IsDBNull(objReader("nv_Tenchucnang_en")) = True, "", objReader("nv_Tenchucnang_en"))
                    .nv_Tenphanhe_vn = IIf(IsDBNull(objReader("nv_Tenphanhe_vn")) = True, "", objReader("nv_Tenphanhe_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QT_DM_CHUCNANGEntity)
        End Try
    End Function

	Public Function SelectAllTable(ByVal uId_Phanhe AS String) AS System.Data.DataTable Implements IQT_DM_CHUCNANGDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQT_DM_CHUCNANG_SelectAll]"
		Dim objCmd As DbCommand
		Dim objDs As DataSet 
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String,uId_Phanhe)
			objDs = db.ExecuteDataSet(objCmd)
			Return objDs.Tables(0)
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New DataTable
		End Try
	End Function


    Public Function SelectByID(ByVal uId_Chucnang As String) As CM.QT_DM_CHUCNANGEntity Implements IQT_DM_CHUCNANGDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CHUCNANG_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QT_DM_CHUCNANGEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String, uId_Chucnang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QT_DM_CHUCNANGEntity
            If objReader.Read Then
                With obj
                    .uId_Chucnang = IIf(IsDBNull(objReader("uId_Chucnang")) = True, "", Convert.ToString(objReader("uId_Chucnang")))
                    .uId_Phanhe = IIf(IsDBNull(objReader("uId_Phanhe")) = True, "", Convert.ToString(objReader("uId_Phanhe")))
                    .nv_Tenbien = IIf(IsDBNull(objReader("nv_Tenbien")) = True, "", objReader("nv_Tenbien"))
                    .nv_Tenchucnang_vn = IIf(IsDBNull(objReader("nv_Tenchucnang_vn")) = True, "", objReader("nv_Tenchucnang_vn"))
                    .nv_Tenchucnang_en = IIf(IsDBNull(objReader("nv_Tenchucnang_en")) = True, "", objReader("nv_Tenchucnang_en"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QT_DM_CHUCNANGEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QT_DM_CHUCNANGEntity) As Boolean Implements IQT_DM_CHUCNANGDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CHUCNANG_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenbien", DbType.String, obj.nv_Tenbien)
            db.AddInParameter(objCmd, "@nv_Tenchucnang_vn", DbType.String, obj.nv_Tenchucnang_vn)
            db.AddInParameter(objCmd, "@nv_Tenchucnang_en", DbType.String, obj.nv_Tenchucnang_en)
            db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String, obj.uId_Phanhe)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Chucnang AS String) As Boolean Implements IQT_DM_CHUCNANGDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQT_DM_CHUCNANG_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String,uId_Chucnang)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QT_DM_CHUCNANGEntity) As Boolean Implements IQT_DM_CHUCNANGDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_DM_CHUCNANG_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String, obj.uId_Chucnang)
            db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String, obj.uId_Phanhe)
            db.AddInParameter(objCmd, "@nv_Tenbien", DbType.String, obj.nv_Tenbien)
            db.AddInParameter(objCmd, "@nv_Tenchucnang_vn", DbType.String, obj.nv_Tenchucnang_vn)
            db.AddInParameter(objCmd, "@nv_Tenchucnang_en", DbType.String, obj.nv_Tenchucnang_en)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    '14/11
    Public Function Selectquyen() As DataTable Implements IQT_DM_CHUCNANGDA.Selectquyenhan
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_CHUCNANG_NHANVIEN_SelectChucnang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception

        End Try
        Return New DataTable
    End Function
End Class