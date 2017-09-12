Public Class TNTP_DM_DICHVUFacade

    Dim ITNTP_DM_DICHVU As DB.ITNTP_DM_DICHVUDA = New DB.TNTP_DM_DICHVUDA

    Public Function SelectAll() As List(Of CM.TNTP_DM_DICHVUEntity)
        Return ITNTP_DM_DICHVU.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Nhomdichvu As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ITNTP_DM_DICHVU.SelectAllTable(uId_Nhomdichvu, uId_Cuahang)
    End Function

    Public Function SelectAllTable_TimTheoTendichvu(ByVal uId_Nhomdichvu As String, ByVal uId_Cuahang As String, ByVal sTendichvu As String) As System.Data.DataTable
        Return ITNTP_DM_DICHVU.SelectAllTable_TimTheoTendichvu(uId_Nhomdichvu, uId_Cuahang, sTendichvu)
    End Function

    Public Function SelectAllByGDV(ByVal uId_Nhomdichvu As String, ByVal b_Goidichvu As Byte, ByVal NgayLapPhieu As DateTime) As System.Data.DataTable
        Return ITNTP_DM_DICHVU.SelectAllByGDV(uId_Nhomdichvu, b_Goidichvu, NgayLapPhieu)
    End Function
    Public Function Insert(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean
        Return ITNTP_DM_DICHVU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean
        Return ITNTP_DM_DICHVU.Update(obj)
    End Function

    Public Function UpdateTest(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean
        Return ITNTP_DM_DICHVU.UpdateTest(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Dichvu AS String) AS Boolean
		Return ITNTP_DM_DICHVU.DeleteByID(uId_Dichvu)
	End Function

    Public Function SelectByID(ByVal uId_Dichvu As String) As CM.TNTP_DM_DICHVUEntity
        Return ITNTP_DM_DICHVU.SelectByID(uId_Dichvu)
    End Function

    Public Function SelectByIDNhomdichvu(uId_Nhomdv As String) As Boolean
        Return ITNTP_DM_DICHVU.SelectByIDNhomdichvu(uId_Nhomdv)
    End Function
    'xuanhieu 150415
    Public Function SelectDichvuUathich(tungay As Date, denngay As Date, uId_cuahang As String) As DataTable
        Return ITNTP_DM_DICHVU.SelectDichvuUathich(tungay, denngay, uId_cuahang)
    End Function
    Public Function SelectAllDMDichvu() As DataTable
        Return ITNTP_DM_DICHVU.SelectAllTableDMDichvu()
    End Function
    'hieutx 1707
    Public Function SelectDvBYGDV(Type As String) As DataTable
        Return ITNTP_DM_DICHVU.SelectDvBYGDV(Type)
    End Function

    Public Function ThongkeKH() As List(Of CM.TNTP_DM_DICHVUEntity)
        Return ITNTP_DM_DICHVU.ThongkeKH()
    End Function

    Function SelectAll_By_Cuahang() As DataTable
        Return ITNTP_DM_DICHVU.SelectAll_By_Cuahang()
    End Function

End Class