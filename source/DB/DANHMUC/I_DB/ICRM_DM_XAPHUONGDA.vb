Public Interface ICRM_DM_XAPHUONGDA

    Function SelectAll() As List(Of CM.CRM_DM_XAPHUONGEntity)

    Function SelectAllTable(ByVal uId_Quanhuyen As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Xaphuong As String) As CM.CRM_DM_XAPHUONGEntity

    Function SelectDiaDanhByID(ByVal uId_Xaphuong As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.CRM_DM_XAPHUONGEntity) As Boolean

    Function DeleteByID(ByVal uId_Xaphuong As String) As Boolean

    Function Update(ByVal obj As CM.CRM_DM_XAPHUONGEntity) As Boolean

End Interface