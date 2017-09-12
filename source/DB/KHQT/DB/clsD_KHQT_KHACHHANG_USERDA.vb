Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class KHQT_KHACHHANG_USERDA

    Implements IKHQT_KHACHHANG_USERDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.KHQT_KHACHHANG_USEREntity) Implements IKHQT_KHACHHANG_USERDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.KHQT_KHACHHANG_USEREntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.KHQT_KHACHHANG_USEREntity)
            While (objReader.Read())
                lstobj.Add(New CM.KHQT_KHACHHANG_USEREntity)
                With lstobj(i)
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Tendangnhap = IIf(IsDBNull(objReader("v_Tendangnhap")) = True, "", objReader("v_Tendangnhap"))
                    .v_Matkhau = IIf(IsDBNull(objReader("v_Matkhau")) = True, "", objReader("v_Matkhau"))
                    .b_Kichhoat = IIf(IsDBNull(objReader("b_Kichhoat")) = True, False, objReader("b_Kichhoat"))
                End With
                i += 1
            End While
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.KHQT_KHACHHANG_USEREntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function SelectByID(ByVal uId_Khachhang As String) As CM.KHQT_KHACHHANG_USEREntity Implements IKHQT_KHACHHANG_USERDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.KHQT_KHACHHANG_USEREntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.KHQT_KHACHHANG_USEREntity
            If objReader.Read Then
                With obj
                    .uId_Khachhang = IIf(IsDBNull(objReader("uId_Khachhang")) = True, "", Convert.ToString(objReader("uId_Khachhang")))
                    .v_Tendangnhap = IIf(IsDBNull(objReader("v_Tendangnhap")) = True, "", objReader("v_Tendangnhap"))
                    .v_Matkhau = IIf(IsDBNull(objReader("v_Matkhau")) = True, "", objReader("v_Matkhau"))
                    .b_Kichhoat = IIf(IsDBNull(objReader("b_Kichhoat")) = True, False, objReader("b_Kichhoat"))
                End With
            End If
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.KHQT_KHACHHANG_USEREntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean Implements IKHQT_KHACHHANG_USERDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, obj.v_Tendangnhap)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.AddInParameter(objCmd, "@b_Kichhoat", DbType.Boolean, obj.b_Kichhoat)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal uId_Khachhang As String) As Boolean Implements IKHQT_KHACHHANG_USERDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean Implements IKHQT_KHACHHANG_USERDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_Tendangnhap", DbType.String, obj.v_Tendangnhap)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.AddInParameter(objCmd, "@b_Kichhoat", DbType.Boolean, obj.b_Kichhoat)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Doimatkhau(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean Implements IKHQT_KHACHHANG_USERDA.Doimatkhau
        Dim db As Database
        Dim sp As String = "[dbo].[spKHQT_KHACHHANG_USER_Doimatkhau]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, obj.uId_Khachhang)
            db.AddInParameter(objCmd, "@v_Matkhau", DbType.String, obj.v_Matkhau)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function BaoCaoDichVu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Uid_Khachhang As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.BaoCaoDichVu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Luocsu_Sudung_DV]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, Uid_Khachhang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BAOCAO_DoanhThuTongHop(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.BAOCAO_DoanhThuTongHop
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThu_TaiChinh_TongHop]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BAOCAO_PHIEUTHUCHI(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Type As String) As System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.BAOCAO_PHIEUTHUCHI
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_PhieuThuChi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Type", DbType.String, Type)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SoNhatKyChung(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal Uid_Khachhang As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.SoNhatKyChung
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_SoNhatKy]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, Uid_Khachhang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BAOCAO_TONGHOPTHUCHI(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Type As String) As System.Data.DataTable Implements IKHQT_KHACHHANG_USERDA.BAOCAO_TONGHOPTHUCHI
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_TongHopThuChi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@Type", DbType.String, Type)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class