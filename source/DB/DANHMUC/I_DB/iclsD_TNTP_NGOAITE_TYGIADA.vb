Public Interface ITNTP_NGOAITE_TYGIADA

    Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_NGOAITE_TYGIAEntity)

    Function SelectAllTable(ByVal uId_Ngoaite As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Ngoaite As String) As CM.TNTP_NGOAITE_TYGIAEntity

    Function Insert(ByVal obj As CM.TNTP_NGOAITE_TYGIAEntity) As Boolean

	Function DeleteByID(ByVal uId_Ngoaite AS String,ByVal d_Ngay AS DateTime) AS Boolean

    Function Update(ByVal obj As CM.TNTP_NGOAITE_TYGIAEntity) As Boolean

End Interface