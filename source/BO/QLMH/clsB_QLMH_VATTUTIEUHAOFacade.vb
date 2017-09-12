Public Class QLMH_VATTUTIEUHAOFacade

    Dim IQLMH_VATTUTIEUHAO As DB.IQLMH_VATTUTIEUHAODA = New DB.QLMH_VATTUTIEUHAODA

    Public Function SelectAll(ByVal uId_Dichvu As String) As List(Of CM.QLMH_VATTUTIEUHAOEntity)
        Return IQLMH_VATTUTIEUHAO.SelectAll(uId_Dichvu)
    End Function

	Public Function SelectAllTable(ByVal uId_Dichvu AS String) AS System.Data.DataTable
		Return IQLMH_VATTUTIEUHAO.SelectAllTable(uId_Dichvu)
	End Function
    Public Function SelectAllByQTDT(ByVal uId_QT_Dieutri As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_VATTUTIEUHAO.SelectAllByQTDT(uId_QT_Dieutri, uId_Kho)
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_VATTUTIEUHAOEntity) As Boolean
        Return IQLMH_VATTUTIEUHAO.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_VATTUTIEUHAOEntity) As Boolean
        Return IQLMH_VATTUTIEUHAO.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Vattutieuhao AS String) AS Boolean
		Return IQLMH_VATTUTIEUHAO.DeleteByID(uId_Vattutieuhao)
	End Function

    Public Function SelectByID(ByVal uId_Vattutieuhao As String) As CM.IQLMH_VATTUTIEUHAOEntity
        Return IQLMH_VATTUTIEUHAO.SelectByID(uId_Vattutieuhao)
    End Function
    'xuanhieu 12.2.05 bao cao vat tu tieu hao
    Public Function BaocaoVattu(Tungay As DateTime, Denngay As DateTime, uId_Kho As String) As DataTable
        Return IQLMH_VATTUTIEUHAO.BaocaoVattu(Tungay, Denngay, uId_Kho)
    End Function

End Class