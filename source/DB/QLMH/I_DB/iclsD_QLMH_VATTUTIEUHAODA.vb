Public Interface IQLMH_VATTUTIEUHAODA

    Function SelectAll(ByVal uId_Dichvu As String) As System.Collections.Generic.List(Of CM.QLMH_VATTUTIEUHAOEntity)

    Function SelectAllTable(ByVal uId_Dichvu As String) As System.Data.DataTable

    Function SelectAllByQTDT(ByVal uId_QT_Dieutri As String, ByVal uId_Kho As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Vattutieuhao As String) As CM.QLMH_VATTUTIEUHAOEntity

    Function Insert(ByVal obj As CM.QLMH_VATTUTIEUHAOEntity) As Boolean

	Function DeleteByID(ByVal uId_Vattutieuhao AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_VATTUTIEUHAOEntity) As Boolean
    'xuanhieu 12.2.05 bao cao vat tu tieu hao
    Function BaocaoVattu(Tungay As DateTime, Denngay As DateTime, uId_Kho As String) As DataTable
End Interface