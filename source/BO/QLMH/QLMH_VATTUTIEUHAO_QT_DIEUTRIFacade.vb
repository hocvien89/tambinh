Public Class QLMH_VATTUTIEUHAO_QT_DIEUTRIFacade

    Dim IQLMH_VATTUTIEUHAO_QT_DIEUTRI As DB.IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA = New DB.QLMH_VATTUTIEUHAO_QT_DIEUTRIDA

    Public Function SelectAll() As List(Of CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity)
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.Update(obj)
    End Function

    Public Function DeleteByID(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.DeleteByID(obj)
    End Function
    Public Function DeleteByID_QTDT(ByVal uId_QT_Dieutri As String) As Boolean
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.DeleteByID_QTDT(uId_QT_Dieutri)
    End Function
    Public Function SelectByID(ByVal uId_QT_Dieutri As String, ByVal uId_Mathang As String) As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
        Return IQLMH_VATTUTIEUHAO_QT_DIEUTRI.SelectByID(uId_QT_Dieutri, uId_Mathang)
    End Function

End Class