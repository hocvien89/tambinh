Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports LogError
Imports System.Data.Common

Public Class DMQuyDoiDonViDA

    Implements IDMQuyDoiDonViDA
    Private log As New LogError.ShowError

    Public Function SelectAll() As System.Collections.Generic.List(Of CM.DMQuyDoiDonViEntity) Implements IDMQuyDoiDonViDA.SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_SelectAll]"
        Dim objCmd As DbCommand
        Dim objReader As SqlClient.SqlDataReader
        Dim lstobj As List(Of CM.DMQuyDoiDonViEntity) = Nothing
        Dim i As Integer = 0
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objReader = db.ExecuteReader(objCmd)
            lstobj = New List(Of CM.DMQuyDoiDonViEntity)
            While (objReader.Read())
                lstobj.Add(New CM.DMQuyDoiDonViEntity)
                With lstobj(i)
                    .MaVatTu = IIf(IsDBNull(objReader("MaVatTu")) = True, "", objReader("MaVatTu"))
                    .MaDonVi1 = IIf(IsDBNull(objReader("MaDonVi1")) = True, "", objReader("MaDonVi1"))
                    .MaDonVi21 = IIf(IsDBNull(objReader("MaDonVi21")) = True, "", objReader("MaDonVi21"))
                    .MaDonVi32 = IIf(IsDBNull(objReader("MaDonVi32")) = True, "", objReader("MaDonVi32"))
                    .SoLuong21 = IIf(IsDBNull(objReader("SoLuong21")) = True, 0, objReader("SoLuong21"))
                    .SoLuong32 = IIf(IsDBNull(objReader("SoLuong32")) = True, 0, objReader("SoLuong32"))
                    .DonGiaDV11 = IIf(IsDBNull(objReader("DonGiaDV11")) = True, 0, objReader("DonGiaDV11"))
                    .DonGiaDV21 = IIf(IsDBNull(objReader("DonGiaDV21")) = True, 0, objReader("DonGiaDV21"))
                    .DonGiaDV32 = IIf(IsDBNull(objReader("DonGiaDV32")) = True, 0, objReader("DonGiaDV32"))
                End With
                i += 1
            End While
            objReader.Close()
            Return lstobj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New List(Of CM.DMQuyDoiDonViEntity)
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IDMQuyDoiDonViDA.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_SelectAll]"
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

    Public Function SelectByID(ByVal MaVatTu As String) As CM.DMQuyDoiDonViEntity Implements IDMQuyDoiDonViDA.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.DMQuyDoiDonViEntity = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", System.Data.DbType.String, MaVatTu)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.DMQuyDoiDonViEntity
            If objReader.Read Then
                With obj
                    .MaVatTu = IIf(IsDBNull(objReader("MaVatTu")) = True, "", objReader("MaVatTu"))
                    .MaDonVi1 = IIf(IsDBNull(objReader("MaDonVi1")) = True, "", objReader("MaDonVi1"))
                    .MaDonVi21 = IIf(IsDBNull(objReader("MaDonVi21")) = True, "", objReader("MaDonVi21"))
                    .MaDonVi32 = IIf(IsDBNull(objReader("MaDonVi32")) = True, "", objReader("MaDonVi32"))
                    .SoLuong21 = IIf(IsDBNull(objReader("SoLuong21")) = True, 0, objReader("SoLuong21"))
                    .SoLuong32 = IIf(IsDBNull(objReader("SoLuong32")) = True, 0, objReader("SoLuong32"))
                End With
            End If
            objReader.Close()
            Return obj
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New CM.DMQuyDoiDonViEntity
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.DMQuyDoiDonViEntity) As Boolean Implements IDMQuyDoiDonViDA.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, obj.MaVatTu)
            db.AddInParameter(objCmd, "@MaDonVi1", DbType.String, obj.MaDonVi1)
            db.AddInParameter(objCmd, "@MaDonVi21", DbType.String, obj.MaDonVi21)
            db.AddInParameter(objCmd, "@MaDonVi32", DbType.String, obj.MaDonVi32)
            db.AddInParameter(objCmd, "@SoLuong21", DbType.Double, obj.SoLuong21)
            db.AddInParameter(objCmd, "@SoLuong32", DbType.Double, obj.SoLuong32)
            db.AddInParameter(objCmd, "@DonGiaDV11", DbType.Double, obj.DonGiaDV11)
            db.AddInParameter(objCmd, "@DonGiaDV21", DbType.Double, obj.DonGiaDV21)
            db.AddInParameter(objCmd, "@DonGiaDV32", DbType.Double, obj.DonGiaDV32)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteByID(ByVal MaVatTu As String) As Boolean Implements IDMQuyDoiDonViDA.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_DeleteByID]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, MaVatTu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(ByVal obj As CM.DMQuyDoiDonViEntity) As Boolean Implements IDMQuyDoiDonViDA.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, obj.MaVatTu)
            db.AddInParameter(objCmd, "@MaDonVi1", DbType.String, obj.MaDonVi1)
            db.AddInParameter(objCmd, "@MaDonVi21", DbType.String, obj.MaDonVi21)
            db.AddInParameter(objCmd, "@MaDonVi32", DbType.String, obj.MaDonVi32)
            db.AddInParameter(objCmd, "@SoLuong21", DbType.Double, obj.SoLuong21)
            db.AddInParameter(objCmd, "@SoLuong32", DbType.Double, obj.SoLuong32)
            db.AddInParameter(objCmd, "@DonGiaDV11", DbType.Double, obj.DonGiaDV11)
            db.AddInParameter(objCmd, "@DonGiaDV21", DbType.Double, obj.DonGiaDV21)
            db.AddInParameter(objCmd, "@DonGiaDV32", DbType.Double, obj.DonGiaDV32)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function LoadDSDonViTheoVatTu(MaVatTu As String) As DataTable Implements IDMQuyDoiDonViDA.LoadDSDonViTheoVatTu
        Dim db As Database
        Dim sp As String = "[dbo].[sp_DanhSachDonViTheoVattu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, MaVatTu)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    'Xuan hieu 28/10/2014
    Public Function SelectCheck(MaVaytu As String) As Boolean Implements IDMQuyDoiDonViDA.Selectcheck
        Dim db As Database
        Dim sp As String = "[dbo].[spDMQuyDoiDonVi_SelectById]"
        Dim objcmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objcmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objcmd, "@Mavattu", DbType.String, MaVaytu)
            objDs = db.ExecuteDataSet(objcmd)
            If objDs.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function LayGiaTriQuyDoi(MaVatTu As String, MaDonVi As String) As Integer Implements IDMQuyDoiDonViDA.LayGiaTriQuyDoi
        Dim db As Database
        Dim sp As String = "[dbo].[sp_LayGiaTriQuyDoi]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@MaVatTu", DbType.String, MaVatTu)
            db.AddInParameter(objCmd, "@MaDonVi", DbType.String, MaDonVi)
            Return Integer.Parse(db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class