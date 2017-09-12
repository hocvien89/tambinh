Public Class CRM_DoangThu_DVChitietFacade

    Dim ICRM_DoangThu_DVChitiet As DB.ICRM_DoangThu_DVChitietDA = New DB.CRM_DoangThu_DVChitietDA

    Public Function SelectByMonthBuffer(ByVal Ngay As DateTime) As System.Data.DataTable
        Return ICRM_DoangThu_DVChitiet.SelectByMonthBuffer(Ngay)
    End Function
    Public Function SelectByMonth(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ICRM_DoangThu_DVChitiet.SelectByMonth(TuNgay, DenNgay, uId_Cuahang)
    End Function
End Class
