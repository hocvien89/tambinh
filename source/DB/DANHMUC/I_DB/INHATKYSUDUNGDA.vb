Public Interface INHATKYSUDUNGDA

    Function SelectAllTable(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal key As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.NHATKYSUDUNGEntity) As Boolean

End Interface