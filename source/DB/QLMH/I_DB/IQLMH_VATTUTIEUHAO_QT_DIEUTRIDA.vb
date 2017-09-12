Public Interface IQLMH_VATTUTIEUHAO_QT_DIEUTRIDA

    Function SelectAll() As List(Of CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_QT_Dieutri As String, ByVal uId_Mathang As String) As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity

    Function Insert(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean

    Function DeleteByID(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean

    Function DeleteByID_QTDT(ByVal uId_QT_Dieutri As String) As Boolean

    Function Update(ByVal obj As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity) As Boolean

End Interface