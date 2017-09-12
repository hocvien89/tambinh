Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QLP_CA_THIETBIDA

	Implements IQLP_CA_THIETBIDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.QLP_CA_THIETBIEntity) Implements IQLP_CA_THIETBIDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_THIETBI_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QLP_CA_THIETBIEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QLP_CA_THIETBIEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QLP_CA_THIETBIEntity)
                With lstobj(i)
                    .uId_Ca = IIf(IsDBNull(objReader("uId_Ca")) = True, "", Convert.ToString(objReader("uId_Ca")))
                    .uId_Thietbi = IIf(IsDBNull(objReader("uId_Thietbi")) = True, "", Convert.ToString(objReader("uId_Thietbi")))
                    .v_Thoigian_BD = IIf(IsDBNull(objReader("v_Thoigian_BD")) = True, "", objReader("v_Thoigian_BD"))
                    .v_Thoigian_KT = IIf(IsDBNull(objReader("v_Thoigian_KT")) = True, "", objReader("v_Thoigian_KT"))
                    .i_Soluong = IIf(IsDBNull(objReader("i_Soluong")) = True, 0, objReader("i_Soluong"))
                    .uId_Trangthai = IIf(IsDBNull(objReader("uId_Trangthai")) = True, "", Convert.ToString(objReader("uId_Trangthai")))
                    .nv_Tenthietbi_vn = IIf(IsDBNull(objReader("nv_Tenthietbi_vn")) = True, "", objReader("nv_Tenthietbi_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QLP_CA_THIETBIEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements IQLP_CA_THIETBIDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spQLP_CA_THIETBI_SelectAll]"
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


    Public Function SelectByID(ByVal uId_Ca As String) As System.Data.DataTable Implements IQLP_CA_THIETBIDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_THIETBI_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, uId_Ca)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QLP_CA_THIETBIEntity) As Boolean Implements IQLP_CA_THIETBIDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_THIETBI_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, obj.uId_Ca)
            db.AddInParameter(objCmd, "@uId_Thietbi", DbType.String, obj.uId_Thietbi)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@v_Thoigian_BD", DbType.String, obj.v_Thoigian_BD)
            db.AddInParameter(objCmd, "@v_Thoigian_KT", DbType.String, obj.v_Thoigian_KT)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Ca As String, ByVal uId_Thietbi As String) As Boolean Implements IQLP_CA_THIETBIDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_THIETBI_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, uId_Ca)
            db.AddInParameter(objCmd, "@uId_Thietbi", DbType.String, uId_Thietbi)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.QLP_CA_THIETBIEntity) As Boolean Implements IQLP_CA_THIETBIDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQLP_CA_THIETBI_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Ca", DbType.String, obj.uId_Ca)
            db.AddInParameter(objCmd, "@uId_Thietbi", DbType.String, obj.uId_Thietbi)
            If (obj.d_Ngay <> Nothing And obj.d_Ngay <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngay", DbType.DateTime, obj.d_Ngay)
            End If
            db.AddInParameter(objCmd, "@v_Thoigian_BD", DbType.String, obj.v_Thoigian_BD)
            db.AddInParameter(objCmd, "@v_Thoigian_KT", DbType.String, obj.v_Thoigian_KT)
            db.AddInParameter(objCmd, "@i_Soluong", DbType.Int32, obj.i_Soluong)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class