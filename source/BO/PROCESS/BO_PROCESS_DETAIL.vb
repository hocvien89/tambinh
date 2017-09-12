Public Class BO_PROCESS_DETAIL
    Dim IDB_PROCESS_DETAIL As DB.IDB_PROCESS_DETAIL = New DB.DB_PROCESS_DETAIL

    Public Function SelectByMaPhong(ByVal uId_Phongban As String, ByVal Root_Id As String) As System.Data.DataTable
        Return IDB_PROCESS_DETAIL.SelectByMaPhong(uId_Phongban, Root_Id)
    End Function

    Public Function SelectByThutu(ByVal _step As Integer, ByVal Root_Id As String) As System.Data.DataTable
        Return IDB_PROCESS_DETAIL.SelectByMaPhong(_step, Root_Id)
    End Function

    Public Function SelectByAllTable() As System.Data.DataTable
        Return IDB_PROCESS_DETAIL.SelectAllTable()
    End Function

    Public Function SelectByPhongIdAndStepId(ByVal uId_Phong As String, ByVal uId_Step As String) As System.Data.DataTable
        Return IDB_PROCESS_DETAIL.SelectByPhongIdAndStepId(uId_Phong, uId_Step)
    End Function

    Public Function SelectByID(ByVal ID As Integer) As CM.CM_PROCESS_DETAIL
        Return IDB_PROCESS_DETAIL.SelectByID(ID)
    End Function

    Public Function Insert(ByVal obj As CM.CM_PROCESS_DETAIL) As Boolean
        Return IDB_PROCESS_DETAIL.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CM_PROCESS_DETAIL) As Boolean
        Return IDB_PROCESS_DETAIL.Update(obj)
    End Function

    Public Function DeleteByID(ByVal ID As Integer) As Boolean
        Return IDB_PROCESS_DETAIL.DeleteByID(ID)
    End Function
End Class
