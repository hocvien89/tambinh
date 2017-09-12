Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class CRM_LICHHEN_DATLICHHENDA

	Implements ICRM_LICHHEN_DATLICHHENDA
	Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_LICHHEN_DATLICHHENEntity) Implements ICRM_LICHHEN_DATLICHHENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.CRM_LICHHEN_DATLICHHENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.CRM_LICHHEN_DATLICHHENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.CRM_LICHHEN_DATLICHHENEntity)
                With lstobj(i)
                    .uId_DatLichhen = IIf(IsDBNull(objReader("uId_DatLichhen")) = True, "", Convert.ToString(objReader("uId_DatLichhen")))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Email_vn = IIf(IsDBNull(objReader("nv_Email_vn")) = True, "", objReader("nv_Email_vn"))
                    .b_KH_Cu = IIf(IsDBNull(objReader("b_KH_Cu")) = True, False, objReader("b_KH_Cu"))
                    .d_NgayDathen = IIf(IsDBNull(objReader("d_NgayDathen")) = True, Nothing, objReader("d_NgayDathen"))
                    .nv_Tugio = IIf(IsDBNull(objReader("nv_Tugio")) = True, "", objReader("nv_Tugio"))
                    .nv_Dengio = IIf(IsDBNull(objReader("nv_Dengio")) = True, "", objReader("nv_Dengio"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .b_Trangthai = IIf(IsDBNull(objReader("b_Trangthai")) = True, False, objReader("b_Trangthai"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.CRM_LICHHEN_DATLICHHENEntity)
        End Try
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable Implements ICRM_LICHHEN_DATLICHHENDA.SelectAllTable
		Dim db As Database
		Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_SelectAll]"
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
    Public Function SelectTimKiem(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity, ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable Implements ICRM_LICHHEN_DATLICHHENDA.SelectTimKiem
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_SelectTimkiem]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", System.Data.DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@uId_Cuahang", System.Data.DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@b_Trangthai", System.Data.DbType.Byte, obj.b_Trangthai)
            db.AddInParameter(objCmd, "@Tungay", System.Data.DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", System.Data.DbType.DateTime, Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectByID(ByVal uId_DatLichhen As String) As CM.CRM_LICHHEN_DATLICHHENEntity Implements ICRM_LICHHEN_DATLICHHENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CRM_LICHHEN_DATLICHHENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_DatLichhen", System.Data.DbType.String, uId_DatLichhen)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CRM_LICHHEN_DATLICHHENEntity
            If objReader.Read Then
                With obj
                    .uId_DatLichhen = IIf(IsDBNull(objReader("uId_DatLichhen")) = True, "", Convert.ToString(objReader("uId_DatLichhen")))
                    .uId_Cuahang = IIf(IsDBNull(objReader("uId_Cuahang")) = True, "", Convert.ToString(objReader("uId_Cuahang")))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .nv_Diachi_vn = IIf(IsDBNull(objReader("nv_Diachi_vn")) = True, "", objReader("nv_Diachi_vn"))
                    .v_Dienthoai = IIf(IsDBNull(objReader("v_Dienthoai")) = True, "", objReader("v_Dienthoai"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Email_vn = IIf(IsDBNull(objReader("nv_Email_vn")) = True, "", objReader("nv_Email_vn"))
                    .b_KH_Cu = IIf(IsDBNull(objReader("b_KH_Cu")) = True, False, objReader("b_KH_Cu"))
                    .d_NgayDathen = IIf(IsDBNull(objReader("d_NgayDathen")) = True, Nothing, objReader("d_NgayDathen"))
                    .nv_Tugio = IIf(IsDBNull(objReader("nv_Tugio")) = True, "", objReader("nv_Tugio"))
                    .nv_Dengio = IIf(IsDBNull(objReader("nv_Dengio")) = True, "", objReader("nv_Dengio"))
                    .nv_Ghichu = IIf(IsDBNull(objReader("nv_Ghichu")) = True, "", objReader("nv_Ghichu"))
                    .b_Trangthai = IIf(IsDBNull(objReader("b_Trangthai")) = True, False, objReader("b_Trangthai"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.CRM_LICHHEN_DATLICHHENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity) As Boolean Implements ICRM_LICHHEN_DATLICHHENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@nv_Email_vn", DbType.String, obj.nv_Email_vn)
            db.AddInParameter(objCmd, "@b_KH_Cu", DbType.Boolean, obj.b_KH_Cu)
            If (obj.d_NgayDathen <> Nothing And obj.d_NgayDathen <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayDathen", DbType.DateTime, obj.d_NgayDathen)
            End If
            db.AddInParameter(objCmd, "@nv_Tugio", DbType.String, obj.nv_Tugio)
            db.AddInParameter(objCmd, "@nv_Dengio", DbType.String, obj.nv_Dengio)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.Boolean, obj.b_Trangthai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

	Public Function DeleteByID(ByVal uId_DatLichhen AS String) As Boolean Implements ICRM_LICHHEN_DATLICHHENDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_DatLichhen", DbType.String,uId_DatLichhen)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity) As Boolean Implements ICRM_LICHHEN_DATLICHHENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_LICHHEN_DATLICHHEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_DatLichhen", DbType.String, obj.uId_DatLichhen)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, obj.uId_Cuahang)
            db.AddInParameter(objCmd, "@nv_Hoten_vn", DbType.String, obj.nv_Hoten_vn)
            db.AddInParameter(objCmd, "@nv_Diachi_vn", DbType.String, obj.nv_Diachi_vn)
            db.AddInParameter(objCmd, "@v_Dienthoai", DbType.String, obj.v_Dienthoai)
            If (obj.d_Ngaysinh <> Nothing And obj.d_Ngaysinh <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_Ngaysinh", DbType.DateTime, obj.d_Ngaysinh)
            End If
            db.AddInParameter(objCmd, "@nv_Email_vn", DbType.String, obj.nv_Email_vn)
            db.AddInParameter(objCmd, "@b_KH_Cu", DbType.Boolean, obj.b_KH_Cu)
            If (obj.d_NgayDathen <> Nothing And obj.d_NgayDathen <> Date.MinValue) Then
                db.AddInParameter(objCmd, "@d_NgayDathen", DbType.DateTime, obj.d_NgayDathen)
            End If
            db.AddInParameter(objCmd, "@nv_Tugio", DbType.String, obj.nv_Tugio)
            db.AddInParameter(objCmd, "@nv_Dengio", DbType.String, obj.nv_Dengio)
            db.AddInParameter(objCmd, "@nv_Ghichu", DbType.String, obj.nv_Ghichu)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.Boolean, obj.b_Trangthai)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

End Class