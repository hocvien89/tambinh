Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class QT_PHANQUYENDA

	Implements IQT_PHANQUYENDA
	Private log As New LogError.ShowError

    Public Function SelectAll(ByVal uId_Nhanvien As String) As System.Collections.Generic.List(Of CM.QT_PHANQUYENEntity) Implements IQT_PHANQUYENDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.QT_PHANQUYENEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.QT_PHANQUYENEntity)
            While (objReader.Read())
                lstobj.Add(New CM.QT_PHANQUYENEntity)
                With lstobj(i)
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Chucnang = IIf(IsDBNull(objReader("uId_Chucnang")) = True, "", Convert.ToString(objReader("uId_Chucnang")))
                    .b_Enable = IIf(IsDBNull(objReader("b_Enable")) = True, False, objReader("b_Enable"))
                    .b_Visible = IIf(IsDBNull(objReader("b_Visible")) = True, False, objReader("b_Visible"))
                    .nv_Tenchucnang_vn = IIf(IsDBNull(objReader("nv_Tenchucnang_vn")) = True, "", objReader("nv_Tenchucnang_vn"))
                    .v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    .nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    .d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    .nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.QT_PHANQUYENEntity)
        End Try
    End Function

    Public Function SelectAllTable(ByVal uId_Nhanvien As String, ByVal uId_Phanhe As String) As System.Data.DataTable Implements IQT_PHANQUYENDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Phanhe", DbType.String, uId_Phanhe)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Nhanvien As String, ByVal uId_Chucnang As String) As CM.QT_PHANQUYENEntity Implements IQT_PHANQUYENDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.QT_PHANQUYENEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String, uId_Chucnang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.QT_PHANQUYENEntity
            If objReader.Read Then
                With obj
                    .uId_Nhanvien = IIf(IsDBNull(objReader("uId_Nhanvien")) = True, "", Convert.ToString(objReader("uId_Nhanvien")))
                    .uId_Chucnang = IIf(IsDBNull(objReader("uId_Chucnang")) = True, "", Convert.ToString(objReader("uId_Chucnang")))
                    .b_Enable = IIf(IsDBNull(objReader("b_Enable")) = True, False, objReader("b_Enable"))
                    .b_Visible = IIf(IsDBNull(objReader("b_Visible")) = True, False, objReader("b_Visible"))
                    '.nv_Tenchucnang_vn = IIf(IsDBNull(objReader("nv_Tenchucnang_vn")) = True, "", objReader("nv_Tenchucnang_vn"))
                    '.v_Manhanvien = IIf(IsDBNull(objReader("v_Manhanvien")) = True, "", objReader("v_Manhanvien"))
                    '.nv_Hoten_vn = IIf(IsDBNull(objReader("nv_Hoten_vn")) = True, "", objReader("nv_Hoten_vn"))
                    '.d_Ngaysinh = IIf(IsDBNull(objReader("d_Ngaysinh")) = True, Nothing, objReader("d_Ngaysinh"))
                    '.nv_Chucvu_vn = IIf(IsDBNull(objReader("nv_Chucvu_vn")) = True, "", objReader("nv_Chucvu_vn"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.QT_PHANQUYENEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.QT_PHANQUYENEntity) As Boolean Implements IQT_PHANQUYENDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String, obj.uId_Chucnang)
            db.AddInParameter(objCmd, "@b_Enable", DbType.Boolean, obj.b_Enable)
            db.AddInParameter(objCmd, "@b_Visible", DbType.Boolean, obj.b_Visible)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function InsertAdmin(ByVal uId_Nhanvien As String) As Boolean Implements IQT_PHANQUYENDA.InsertAdmin
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_InsertAdmin]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
	Public Function DeleteByID(ByVal uId_Nhanvien AS String,ByVal uId_Chucnang AS String) As Boolean Implements IQT_PHANQUYENDA.DeleteByID
		Dim db As Database
		Dim sp As String = "[dbo].[spQT_PHANQUYEN_DeleteByID]"
		Dim objCmd As DbCommand
		Try
			db = DatabaseFactory.CreateDatabase()
			objCmd = db.GetStoredProcCommand(sp)
			db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String,uId_Nhanvien)
			db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String,uId_Chucnang)
			db.ExecuteNonQuery(objCmd)
			Return True
		Catch ex As Exception
			log.WriteLog(sp,ex.Message)
			Return False
		End Try
	End Function

    Public Function Update(ByVal obj As CM.QT_PHANQUYENEntity) As Boolean Implements IQT_PHANQUYENDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, obj.uId_Nhanvien)
            db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String, obj.uId_Chucnang)
            db.AddInParameter(objCmd, "@b_Enable", DbType.Boolean, obj.b_Enable)
            db.AddInParameter(objCmd, "@b_Visible", DbType.Boolean, obj.b_Visible)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    '15/11/2014 xuanhieu tra ve bang nhung chuc nang ma nhan vien co quyen b_enable=true
    Public Function SelectByuIdNhanvien(uId_Nhanvien As String) As DataTable Implements IQT_PHANQUYENDA.SelectByuIdNhanvien
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_SelectByIdNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    '17/11/2014 kiem tra thong tin la insert hay update vao bang phan quyen
    Public Function CheckPhanquyen(uid_chucnang As String, uid_nhanvien As String) As Boolean Implements IQT_PHANQUYENDA.CheckPhanquyen
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_CheckPhanquyen]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uid_nhanvien)
            db.AddInParameter(objCmd, "@uId_Chucnang", DbType.String, uid_chucnang)
            objDs = db.ExecuteDataSet(objCmd)
            If objDs.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function
    '21/11/2014 xoa tat ca chuc nang theo nhan vien 
    Public Function DeleteAllById(uid_nhanvien As String) As Boolean Implements IQT_PHANQUYENDA.DeleteAllById
        Dim db As Database
        Dim sp As String = "[dbo].[spQT_PHANQUYEN_DeleteAllById]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uid_nhanvien)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception

        End Try
    End Function
End Class