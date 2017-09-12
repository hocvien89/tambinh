Public Interface IDB_PROCESS_DETAIL

    Function SelectByMaPhong(ByVal uId_Phongban As String, ByVal Root_Id As String) As System.Data.DataTable

    Function SelectByThutu(ByVal _step As Integer, ByVal Root_Id As String) As System.Data.DataTable

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByPhongIdAndStepId(ByVal uId_Phongban As String, ByVal uId_Step As String) As System.Data.DataTable

    Function SelectByID(ByVal ID As Integer) As CM.CM_PROCESS_DETAIL

    Function Insert(ByVal obj As CM.CM_PROCESS_DETAIL) As Boolean

    Function DeleteByID(ByVal ID As Integer) As Boolean

    Function Update(ByVal obj As CM.CM_PROCESS_DETAIL) As Boolean
End Interface
