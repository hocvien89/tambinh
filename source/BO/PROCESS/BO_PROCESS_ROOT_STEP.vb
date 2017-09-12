Public Class BO_PROCESS_ROOT_STEP
    Dim IDB_PROCESS_ROOT_STEP As DB.IDB_PROCESS_ROOT_STEP = New DB.DB_PROCESS_ROOT_STEP
    Public Function SelectByRootId(ByVal RootId As String) As System.Data.DataTable
        Return IDB_PROCESS_ROOT_STEP.SelectByRootId(RootId)
    End Function
End Class
