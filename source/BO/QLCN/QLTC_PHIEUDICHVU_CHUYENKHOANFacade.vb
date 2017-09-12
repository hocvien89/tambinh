Public Class QLTC_PHIEUDICHVU_CHUYENKHOANFacade

    Dim IQLTC_PHIEUDICHVU_CHUYENKHOAN As DB.IQLTC_PHIEUDICHVU_CHUYENKHOANDA = New DB.QLTC_PHIEUDICHVU_CHUYENKHOANDA

    Public Function SelectAll() As List(Of CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity)
        Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.SelectAllTable()
    End Function

    Public Function SelectAllByPhieuDV(ByVal uId_Phieudichvu As String) As String
        Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.SelectAllByPhieuDV(uId_Phieudichvu)
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) As Boolean
        Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity) As Boolean
        Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_PDV_Chuyentien AS String) AS Boolean
		Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.DeleteByID(uId_PDV_Chuyentien)
	End Function

    Public Function SelectByID(ByVal uId_PDV_Chuyentien As String) As CM.QLTC_PHIEUDICHVU_CHUYENKHOANEntity
        Return IQLTC_PHIEUDICHVU_CHUYENKHOAN.SelectByID(uId_PDV_Chuyentien)
    End Function

End Class