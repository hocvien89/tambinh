Public Class clsB_TNTP_Dieutri_Hinhanh
    Private iobjFcDieutriha As DB.iClsD_TNTP_QT_Dieutri_Hinhanh = New DB.clsD_TNTP_QT_Dieutri_Hinhanh
    'insert data
    Public Function Insert(objEnDieutriHinh As CM.iCls_TNTP_QT_Dieutri_Hinhanh) As String
        Return iobjFcDieutriha.Insert(objEnDieutriHinh)
    End Function

    'update
    Public Function Update(objEnDieutriHinh As CM.iCls_TNTP_QT_Dieutri_Hinhanh) As Boolean
        Return iobjFcDieutriha.Update(objEnDieutriHinh)
    End Function

    'xoa
    Public Function Delete(uId_Dieutri_Hinhanh As String) As Boolean
        Return iobjFcDieutriha.Delete(uId_Dieutri_Hinhanh)
    End Function

    'select all

    Public Function SelectAllTable() As DataTable
        Return iobjFcDieutriha.SelectAllTable()
    End Function

    'select by ID Dieutri

    Public Function SelectByuId_Dieutri(uId_Dieutri As String) As DataTable
        Return iobjFcDieutriha.SelectByuId_Dieutri(uId_Dieutri)
    End Function
End Class
