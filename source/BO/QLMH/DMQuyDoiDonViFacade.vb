Public Class DMQuyDoiDonViFacade

    Dim IDMQuyDoiDonVi As DB.IDMQuyDoiDonViDA = New DB.DMQuyDoiDonViDA

    Public Function SelectAll() As List(Of CM.DMQuyDoiDonViEntity)
        Return IDMQuyDoiDonVi.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IDMQuyDoiDonVi.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.DMQuyDoiDonViEntity) As Boolean
        Return IDMQuyDoiDonVi.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.DMQuyDoiDonViEntity) As Boolean
        Return IDMQuyDoiDonVi.Update(obj)
    End Function

    Public Function DeleteByID(ByVal MaVatTu As String) As Boolean
        Return IDMQuyDoiDonVi.DeleteByID(MaVatTu)
    End Function

    Public Function SelectByID(ByVal MaVatTu As String) As CM.DMQuyDoiDonViEntity
        Return IDMQuyDoiDonVi.SelectByID(MaVatTu)
    End Function

    Public Function LoadDSDonViTheoVatTu(MaVatTu) As System.Data.DataTable
        Return IDMQuyDoiDonVi.LoadDSDonViTheoVatTu(MaVatTu)
    End Function

    Public Function SelectCheck(MaVatTu As String) As Boolean
        Return IDMQuyDoiDonVi.Selectcheck(MaVatTu)
    End Function

    Function LayGiaTriQuyDoi(ByVal MaVatTu As String, ByVal MaDonVi As String) As Integer
        Return IDMQuyDoiDonVi.LayGiaTriQuyDoi(MaVatTu, MaDonVi)
    End Function
End Class