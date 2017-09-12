Public Interface ITNTP_DM_DICHVUDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_DM_DICHVUEntity)

    Function SelectAllTable(ByVal uId_Nhomdichvu As String, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function SelectAllTable_TimTheoTendichvu(ByVal uId_Nhomdichvu As String, ByVal uId_Cuahang As String, ByVal Tendichvu As String) As System.Data.DataTable

    Function SelectAllByGDV(ByVal uId_Nhomdichvu As String, ByVal b_Goidichvu As Byte, ByVal NgayLapPhieu As DateTime) As System.Data.DataTable

    Function SelectByID(ByVal uId_Dichvu As String) As CM.TNTP_DM_DICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean

	Function DeleteByID(ByVal uId_Dichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean

    Function UpdateTest(ByVal obj As CM.TNTP_DM_DICHVUEntity) As Boolean

    Function SelectByIDNhomdichvu(uId_Nhomdv As String) As Boolean

    Function SelectDichvuUathich(tungay As Date, denngay As Date, uId_cuahang As String) As DataTable
    'xuanhieu 1704 import excel cong doan
    Function SelectDichvuByTenDV(nv_Tendichvu_vn As String) As DataTable
    'Phuongdv 13/5/2015 DM_Dichvu_SelectAll(loadcombo)
    Function SelectAllTableDMDichvu() As System.Data.DataTable
    'hieutx
    Function SelectDvBYGDV(Type As String) As DataTable

    Function ThongkeKH() As System.Collections.Generic.List(Of CM.TNTP_DM_DICHVUEntity)

    Function SelectAll_By_Cuahang() As DataTable

End Interface