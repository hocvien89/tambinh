Public Interface IQLP_CA_THIETBIDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.QLP_CA_THIETBIEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Ca As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.QLP_CA_THIETBIEntity) As Boolean

    Function DeleteByID(ByVal uId_Ca As String, ByVal uId_Thietbi As String) As Boolean

    Function Update(ByVal obj As CM.QLP_CA_THIETBIEntity) As Boolean

End Interface