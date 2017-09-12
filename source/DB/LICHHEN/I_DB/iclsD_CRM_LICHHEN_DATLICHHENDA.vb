Public Interface ICRM_LICHHEN_DATLICHHENDA

    Function SelectAll() As List(Of CM.CRM_LICHHEN_DATLICHHENEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_DatLichhen As String) As CM.CRM_LICHHEN_DATLICHHENEntity

    Function Insert(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity) As Boolean

	Function DeleteByID(ByVal uId_DatLichhen AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity) As Boolean

    Function SelectTimKiem(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity, ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable
End Interface