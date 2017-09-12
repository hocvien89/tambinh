Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class KHQT_KHACHHANG_USERDA

	Implements IKHQT_KHACHHANG_USERDA
	Private log As New LogError.ShowError

	Public Function SelectAll() AS System.Collections.Generic.List(Of Common.KHQT_KHACHHANG_USEREntity) Implements IKHQT_KHACHHANG_USERDA.SelectAll
		Dim db As Database
		Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_SelectAll]"
		Dim objCmd As DbCommand
		Dim objReader As SqlClient.SqlDataReader 
		Dim lstobj As List(Of Common.KHQT_KHACHHANG_USEREntity) = Nothing
		Dim i As Integer = 0
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			objReader = db.ExecuteReader(objCmd)
			lstobj = New List(Of Common.KHQT_KHACHHANG_USEREntity)
			While (objReader.Read())
				lstobj.Add(New Common.KHQT_KHACHHANG_USEREntity)
				With lstobj(i)
					.uId_Khachhang= IIF(IsDBNull(objReader("uId_Khachhang"))=true,"",Convert.toString(objReader("uId_Khachhang"))
					.v_Tendangnhap= IIF(IsDBNull(objReader("v_Tendangnhap"))=true,"",objReader("v_Tendangnhap"))
					.v_Matkhau= IIF(IsDBNull(objReader("v_Matkhau"))=true,"",objReader("v_Matkhau"))
					.b_Kichhoat= IIF(IsDBNull(objReader("b_Kichhoat"))=true,false,objReader("b_Kichhoat"))
				End With
				i += 1
			End While
			Return lstobj
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New List(Of Common.KHQT_KHACHHANG_USEREntity)
		End Try
	End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_SelectAll]"
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

	Public Function SelectByID(ByVal uId_Khachhang AS String) AS Common.KHQT_KHACHHANG_USEREntity Implements IKHQT_KHACHHANG_USERDA.SelectByID
		Dim db As Database
		Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_SelectByID]"
		Dim objCmd As DbCommand
		Dim objReader As IDataReader
		Dim obj As Common.KHQT_KHACHHANG_USEREntity = Nothing
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Khachhang", System.Data.DbType.String,uId_Khachhang)
			objReader = db.ExecuteReader(objCmd)
			obj = New Common.KHQT_KHACHHANG_USEREntity
			If objReader.Read Then
				With obj
					.uId_Khachhang= IIF(IsDBNull(objReader("uId_Khachhang"))=true,"",Convert.toString(objReader("uId_Khachhang"))
					.v_Tendangnhap= IIF(IsDBNull(objReader("v_Tendangnhap"))=true,"",objReader("v_Tendangnhap"))
					.v_Matkhau= IIF(IsDBNull(objReader("v_Matkhau"))=true,"",objReader("v_Matkhau"))
					.b_Kichhoat= IIF(IsDBNull(objReader("b_Kichhoat"))=true,false,objReader("b_Kichhoat"))
				End With
			End if
			Return obj
		Catch ex as Exception
			log.WriteLog(sp,ex.Message)
			Return New Common.KHQT_KHACHHANG_USEREntity
		End Try
	End Function

	Public Function Insert(ByVal obj As Common.KHQT_KHACHHANG_USEREntity) As Boolean Implements IKHQT_KHACHHANG_USERDA.Insert
		Dim db As Database
		Dim sp As String="[dbo].[spKHQT_KHACHHANG_USER_Insert]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String,obj.v_Tendangnhap)
			db.AddInParameter(objCmd, "@v_Matkhau", DbType.String,obj.v_Matkhau)
			db.AddInParameter(objCmd, "@b_Kichhoat", DbType.Boolean,obj.b_Kichhoat)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

	Public Function DeleteByID(ByVal uId_Khachhang AS String) As Boolean Implements IKHQT_KHACHHANG_USERDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String,uId_Khachhang)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

	Public Function Update(ByVal obj As Common.KHQT_KHACHHANG_USEREntity) As Boolean Implements IKHQT_KHACHHANG_USERDA.Update
		Dim db As Database
		Dim sp As String="[dbo].[spKHQT_KHACHHANG_USER_Update]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String,obj.uId_Khachhang)
			db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String,obj.v_Tendangnhap)
			db.AddInParameter(objCmd, "@v_Matkhau", DbType.String,obj.v_Matkhau)
			db.AddInParameter(objCmd, "@b_Kichhoat", DbType.Boolean,obj.b_Kichhoat)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

End Class