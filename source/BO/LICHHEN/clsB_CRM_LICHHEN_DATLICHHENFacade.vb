Public Class CRM_LICHHEN_DATLICHHENFacade

    Dim ICRM_LICHHEN_DATLICHHEN As DB.ICRM_LICHHEN_DATLICHHENDA = New DB.CRM_LICHHEN_DATLICHHENDA

    Public Function SelectAll() As List(Of CM.CRM_LICHHEN_DATLICHHENEntity)
        Return ICRM_LICHHEN_DATLICHHEN.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ICRM_LICHHEN_DATLICHHEN.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity) As Boolean
        Return ICRM_LICHHEN_DATLICHHEN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity) As Boolean
        Return ICRM_LICHHEN_DATLICHHEN.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_DatLichhen AS String) AS Boolean
		Return ICRM_LICHHEN_DATLICHHEN.DeleteByID(uId_DatLichhen)
	End Function

    Public Function SelectByID(ByVal uId_DatLichhen As String) As CM.CRM_LICHHEN_DATLICHHENEntity
        Return ICRM_LICHHEN_DATLICHHEN.SelectByID(uId_DatLichhen)
    End Function
    Public Function SelectTimKiem(ByVal obj As CM.CRM_LICHHEN_DATLICHHENEntity, ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN_DATLICHHEN.SelectTimKiem(obj, Tungay, Denngay)
    End Function
End Class