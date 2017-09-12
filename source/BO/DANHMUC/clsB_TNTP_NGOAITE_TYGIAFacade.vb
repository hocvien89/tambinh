Public Class TNTP_NGOAITE_TYGIAFacade

    Dim ITNTP_NGOAITE_TYGIA As DB.ITNTP_NGOAITE_TYGIADA = New DB.TNTP_NGOAITE_TYGIADA

    Public Function SelectAll() As List(Of CM.TNTP_NGOAITE_TYGIAEntity)
        Return ITNTP_NGOAITE_TYGIA.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Ngoaite As String) As System.Data.DataTable
        Return ITNTP_NGOAITE_TYGIA.SelectAllTable(uId_Ngoaite)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_NGOAITE_TYGIAEntity) As Boolean
        Return ITNTP_NGOAITE_TYGIA.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_NGOAITE_TYGIAEntity) As Boolean
        Return ITNTP_NGOAITE_TYGIA.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Ngoaite AS String,ByVal d_Ngay AS DateTime) AS Boolean
		Return ITNTP_NGOAITE_TYGIA.DeleteByID(uId_Ngoaite,d_Ngay)
	End Function

    Public Function SelectByID(ByVal uId_Ngoaite As String) As CM.TNTP_NGOAITE_TYGIAEntity
        Return ITNTP_NGOAITE_TYGIA.SelectByID(uId_Ngoaite)
    End Function

End Class