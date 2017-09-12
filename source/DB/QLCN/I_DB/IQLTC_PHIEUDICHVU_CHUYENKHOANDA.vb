Public Interface IQLTC_PHIEUDICHVU_CHUYENKHOANDA

    Function SelectAll() As List(Of CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectAllByPhieuDV(ByVal uId_Phieudichvu As String) As String

    Function SelectByID(ByVal uId_PDV_Chuyentien As String) As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity

    Function Insert(ByVal obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) As Boolean

	Function DeleteByID(ByVal uId_PDV_Chuyentien AS String) AS Boolean

    Function Update(ByVal obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) As Boolean

End Interface