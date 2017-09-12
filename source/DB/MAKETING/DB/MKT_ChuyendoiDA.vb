Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_ChuyendoiDA

	Implements IMKT_ChuyendoiDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.MKT_ChuyendoiEntity) Implements IMKT_ChuyendoiDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chuyendoi_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.MKT_ChuyendoiEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.MKT_ChuyendoiEntity)
            While (objReader.Read())
                lstobj.Add(New CM.MKT_ChuyendoiEntity)
                With lstobj(i)
                    .uId_Chuyendoi = IIf(IsDBNull(objReader("uId_Chuyendoi")) = True, "", Convert.ToString(objReader("uId_Chuyendoi")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.MKT_ChuyendoiEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IMKT_ChuyendoiDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spMKT_Chuyendoi_SelectAll]"
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

    Public Function SelectByID(ByVal uId_Chuyendoi As String) As CM.MKT_ChuyendoiEntity Implements IMKT_ChuyendoiDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chuyendoi_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_ChuyendoiEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chuyendoi", System.Data.DbType.String, uId_Chuyendoi)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_ChuyendoiEntity
            If objReader.Read Then
                With obj
                    .uId_Chuyendoi = IIf(IsDBNull(objReader("uId_Chuyendoi")) = True, "", Convert.ToString(objReader("uId_Chuyendoi")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_ChuyendoiEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.MKT_ChuyendoiEntity) As String Implements IMKT_ChuyendoiDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chuyendoi_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", DbType.String, obj.uId_TrangthaiKH)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_Chuyendoi AS String) As Boolean Implements IMKT_ChuyendoiDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spMKT_Chuyendoi_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Chuyendoi", DbType.String,uId_Chuyendoi)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.MKT_ChuyendoiEntity) As Boolean Implements IMKT_ChuyendoiDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chuyendoi_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Chuyendoi", DbType.String, obj.uId_Chuyendoi)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@uId_KH_Tiemnang", DbType.String, obj.uId_KH_Tiemnang)
            db.AddInParameter(objCmd, "@uId_TrangthaiKH", DbType.String, obj.uId_TrangthaiKH)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function SelectByID_KHtiemnang(ByVal uId_KH_tiemnang As String) As String Implements IMKT_ChuyendoiDA.SelectByID_KHtiemnang
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chuyendoi_SelectbyID_KHtiemnang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_tiemnang", DbType.String, uId_KH_tiemnang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function

    Public Function SelectAllByKHTiemNang(ByVal uId_KH_tiemnang As String) As CM.MKT_ChuyendoiEntity Implements IMKT_ChuyendoiDA.SelectAllByKHTiemNang
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_Chuyendoi_SelectAllByKHTiemNang]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.MKT_ChuyendoiEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_KH_tiemnang", DbType.String, uId_KH_tiemnang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.MKT_ChuyendoiEntity
            If objReader.Read Then
                With obj
                    .uId_Chuyendoi = IIf(IsDBNull(objReader("uId_Chuyendoi")) = True, "", Convert.ToString(objReader("uId_Chuyendoi")))
                    .d_Ngay = IIf(IsDBNull(objReader("d_Ngay")) = True, Nothing, objReader("d_Ngay"))
                    .uId_KH_Tiemnang = IIf(IsDBNull(objReader("uId_KH_Tiemnang")) = True, "", Convert.ToString(objReader("uId_KH_Tiemnang")))
                    .uId_TrangthaiKH = IIf(IsDBNull(objReader("uId_TrangthaiKH")) = True, "", Convert.ToString(objReader("uId_TrangthaiKH")))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.MKT_ChuyendoiEntity
        End Try
    End Function
End Class