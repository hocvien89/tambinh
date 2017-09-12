Public Class BO_PROCESS_ROOT
    Dim IDB_PROCESS_ROOT As DB.IDB_PROCESS_ROOT = New DB.DB_PROCESS_ROOT
    Public Function SelectAllTable() As System.Data.DataTable
        Return IDB_PROCESS_ROOT.SelectAllTable()
    End Function
    Public Function SelectByID(ByVal ID As String) As CM.CM_PROCESS_ROOT
        Return IDB_PROCESS_ROOT.SelectById(ID)
    End Function
End Class
