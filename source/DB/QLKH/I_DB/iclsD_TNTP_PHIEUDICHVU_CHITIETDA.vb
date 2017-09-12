Public Interface ITNTP_PHIEUDICHVU_CHITIETDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_PHIEUDICHVU_CHITIETEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function SelectBySoPhieu(ByVal v_Sophieu As String) As System.Data.DataTable

    Function SelectByIDChitiet(ByVal uId_Phieudichvu_Chitiet As String) As System.Data.DataTable
    Function SelectByIDChitiet_NoTable(ByVal uId_Phieudichvu_Chitiet As String) As CM.TNTP_PHIEUDICHVU_CHITIETEntity

    Function SelectByIDDichvu(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As CM.TNTP_PHIEUDICHVU_CHITIETEntity
    Function SelectByID_PDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable
    Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) As Boolean

    Function DeleteByID(ByVal uId_Phieudichvu_Chitiet As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) As Boolean

    Sub Update_Nhanvien_ById_Phieudichvu(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity)

    Function DeleteByIDPhieu(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As Boolean

    Function SelectDVByIDKhachhang(ByVal uId_Khachhang As String) As System.Data.DataTable
    Function SelectCkinCkoutByIDChitiet(ByVal uId_Phieudichvu_Chitiet As String) As System.Data.DataSet

    Function SelectByID_PDV_DTS(ByVal uId_Phieudichvu As String) As System.Data.DataSet

    Function Select_Dichvu_Lieutrinh(uId_Phieudichvu As String) As DataTable

    Function Check_HuyDV(uId_Phieudichvu_Chitiet As String) As Boolean

    Function CheckDV(ByVal uId_Phieudichvu As String) As DataTable

End Interface