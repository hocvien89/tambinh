Public Interface ITNTP_CHECKINCHECKOUTDA

    Function SelectAll() As List(Of CM.TNTP_CHECKINCHECKOUTEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Check As String) As CM.TNTP_CHECKINCHECKOUTEntity

    Function Insert(ByVal obj As CM.TNTP_CHECKINCHECKOUTEntity) As Boolean

    Function DeleteByID(ByVal uId_Check As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_CHECKINCHECKOUTEntity) As Boolean

    Function Checkout(uId_QT_Dieutri As String, dt_checkout As DateTime, b_Status As Boolean) As Boolean

    Function SelectByIDDieuTri(ByVal uId_QT_Dieutri As String) As CM.TNTP_CHECKINCHECKOUTEntity

    Function SelectLieuTrinhTheoPhong(uId_Giuong As String) As System.Data.DataTable

End Interface