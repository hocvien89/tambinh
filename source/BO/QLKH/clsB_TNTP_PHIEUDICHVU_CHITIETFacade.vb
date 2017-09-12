Public Class TNTP_PHIEUDICHVU_CHITIETFacade

    Dim ITNTP_PHIEUDICHVU_CHITIET As DB.ITNTP_PHIEUDICHVU_CHITIETDA = New DB.TNTP_PHIEUDICHVU_CHITIETDA

    Public Function SelectAll() As List(Of CM.TNTP_PHIEUDICHVU_CHITIETEntity)
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_CHITIET.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_CHITIET.Update(obj)
    End Function

    Public Sub Update_Nhanvien_ById_Phieudichvu(ByVal obj As CM.TNTP_PHIEUDICHVU_CHITIETEntity)
        ITNTP_PHIEUDICHVU_CHITIET.Update_Nhanvien_ById_Phieudichvu(obj)
    End Sub

    Public Function DeleteByID(ByVal uId_Phieudichvu_Chitiet As String) As Boolean
        Return ITNTP_PHIEUDICHVU_CHITIET.DeleteByID(uId_Phieudichvu_Chitiet)
    End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectByID(uId_Phieudichvu)
    End Function
    Public Function SelectBySoPhieu(ByVal v_Sophieu As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectBySoPhieu(v_Sophieu)
    End Function
    Public Function SelectByIDChitiet(ByVal uId_Phieudichvu_Chitiet As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectByIDChitiet(uId_Phieudichvu_Chitiet)
    End Function
    Public Function SelectByIDDichvu(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As CM.TNTP_PHIEUDICHVU_CHITIETEntity
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectByIDDichvu(uId_Phieudichvu, uId_Dichvu)
    End Function
    Public Function DeleteByIDPhieu(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As Boolean
        Return ITNTP_PHIEUDICHVU_CHITIET.DeleteByIDPhieu(uId_Phieudichvu, uId_Dichvu)
    End Function
    'Phuongdv bao cao me va be
  
    Public Function SelectDVByID_Khachhang(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectDVByIDKhachhang(uId_Khachhang)
    End Function
    Public Function SelectCkinCkoutByIDChitiet(ByVal uId_Phieudichvu_Chitiet As String) As DataSet
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectCkinCkoutByIDChitiet(uId_Phieudichvu_Chitiet)
    End Function
    Public Function SelectByID_PDV_DTS(ByVal uId_Phieudichvu As String) As System.Data.DataSet
        Return ITNTP_PHIEUDICHVU_CHITIET.SelectByID_PDV_DTS(uId_Phieudichvu)
    End Function

    Function Select_Dichvu_Lieutrinh(ByVal uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.Select_Dichvu_Lieutrinh(uId_Phieudichvu)
    End Function

    Function Check_HuyDV(ByVal uId_Phieudichvu_Chitiet As String) As Boolean
        Return ITNTP_PHIEUDICHVU_CHITIET.Check_HuyDV(uId_Phieudichvu_Chitiet)
    End Function

    Function CheckDV(ByVal uId_Phieudichvu_Chitiet As String) As DataTable
        Return ITNTP_PHIEUDICHVU_CHITIET.CheckDV(uId_Phieudichvu_Chitiet)
    End Function
End Class