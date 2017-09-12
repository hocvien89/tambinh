Public Interface IQLCN_CONGNODA

    Function SelectAll() As System.Collections.Generic.List(Of CM.QLCN_CONGNOEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Phieudichvu As String) As CM.QLCN_CONGNOEntity

    Function Insert(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean

	Function DeleteByID(ByVal uId_Phieudichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean

    Function Update_TT(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean

    Function CongNoKH(ByVal uId_Khachhang As String) As String

    Function SelectByID_TB(ByVal uId_Phieudichvu As String) As System.Data.DataTable
End Interface