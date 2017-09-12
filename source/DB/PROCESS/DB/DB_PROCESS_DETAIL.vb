Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Public Class DB_PROCESS_DETAIL
    Implements IDB_PROCESS_DETAIL
    Public Function DeleteByID(ByVal ID As Integer) As Boolean Implements IDB_PROCESS_DETAIL.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@ID", DbType.String, ID)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Insert(ByVal obj As CM.CM_PROCESS_DETAIL) As Boolean Implements IDB_PROCESS_DETAIL.Insert
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Step", DbType.String, obj.uId_Step)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SelectByMaPhong(ByVal uId_Phongban As String, ByVal Root_Id As String) As System.Data.DataTable Implements IDB_PROCESS_DETAIL.SelectByMaPhong
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_SelectByMaPhong]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, uId_Phongban)
            db.AddInParameter(objCmd, "@Root_Id", DbType.String, Root_Id)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectByThutu(ByVal _step As Integer, ByVal Root_Id As String) As System.Data.DataTable Implements IDB_PROCESS_DETAIL.SelectByThutu
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_SelectByThutu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Step", DbType.String, _step)
            db.AddInParameter(objCmd, "@Root_Id", DbType.String, Root_Id)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function Update(ByVal obj As CM.CM_PROCESS_DETAIL) As Boolean Implements IDB_PROCESS_DETAIL.Update
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, obj.uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Step", DbType.String, obj.uId_Step)
            db.AddInParameter(objCmd, "@ID", DbType.String, obj.ID)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SelectAllTable() As System.Data.DataTable Implements IDB_PROCESS_DETAIL.SelectAllTable
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function SelectByID(ByVal ID As Integer) As CM.CM_PROCESS_DETAIL Implements IDB_PROCESS_DETAIL.SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_SelectByID]"
        Dim objCmd As DbCommand
        Dim objReader As IDataReader
        Dim obj As CM.CM_PROCESS_DETAIL = Nothing
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@ID", System.Data.DbType.String, ID)
            objReader = db.ExecuteReader(objCmd)
            obj = New CM.CM_PROCESS_DETAIL
            If objReader.Read Then
                With obj
                    .uId_Step = IIf(IsDBNull(objReader("uId_Step")) = True, "", Convert.ToString(objReader("uId_Step")))
                    .uId_Phongban = IIf(IsDBNull(objReader("uId_Phongban")) = True, "", Convert.ToString(objReader("uId_Phongban")))
                    .RootId = IIf(IsDBNull(objReader("Root_Id")) = True, "", Convert.ToString(objReader("Root_Id")))
                End With
            End If
            Return obj
        Catch ex As Exception
            Return New CM.CM_PROCESS_DETAIL
        End Try
    End Function

    Public Function SelectByPhongIdAndStepId(ByVal uId_Phongban As String, ByVal uId_Step As String) As System.Data.DataTable Implements IDB_PROCESS_DETAIL.SelectByPhongIdAndStepId
        Dim db As Database
        Dim sp As String = "[dbo].[spPROCESS_DETAIL_SelectByPhongIdAndStepId]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phongban", DbType.String, uId_Phongban)
            db.AddInParameter(objCmd, "@uId_Step", DbType.String, uId_Step)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
End Class
