Public Class TNTP_CHECKINCHECKOUTFacade

    Dim ITNTP_CHECKINCHECKOUT As DB.ITNTP_CHECKINCHECKOUTDA = New DB.TNTP_CHECKINCHECKOUTDA

    Public Function SelectAll() As List(Of CM.TNTP_CHECKINCHECKOUTEntity)
        Return ITNTP_CHECKINCHECKOUT.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ITNTP_CHECKINCHECKOUT.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_CHECKINCHECKOUTEntity) As Boolean
        Return ITNTP_CHECKINCHECKOUT.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_CHECKINCHECKOUTEntity) As Boolean
        Return ITNTP_CHECKINCHECKOUT.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Check As String) As Boolean
        Return ITNTP_CHECKINCHECKOUT.DeleteByID(uId_Check)
    End Function

    Public Function SelectByID(ByVal uId_Check As String) As CM.TNTP_CHECKINCHECKOUTEntity
        Return ITNTP_CHECKINCHECKOUT.SelectByID(uId_Check)
    End Function
    Public Function Checkout(uId_QT_Dieutri As String, dt_checkout As Date, b_Status As Boolean) As Boolean
        Return ITNTP_CHECKINCHECKOUT.Checkout(uId_QT_Dieutri, dt_checkout, b_Status)
    End Function
    Public Function SelectByIDDieuTri(uId_QT_Dieutri As String) As CM.TNTP_CHECKINCHECKOUTEntity
        Return ITNTP_CHECKINCHECKOUT.SelectByIDDieuTri(uId_QT_Dieutri)
    End Function
    Public Function SelectLieuTrinhTheoPhong(uId_Giuong As String) As DataTable
        Return ITNTP_CHECKINCHECKOUT.SelectLieuTrinhTheoPhong(uId_Giuong)
    End Function
End Class