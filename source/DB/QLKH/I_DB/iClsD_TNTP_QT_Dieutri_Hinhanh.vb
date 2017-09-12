Public Interface iClsD_TNTP_QT_Dieutri_Hinhanh
    'insert data
    Function Insert(objEnDieutriHinh As CM.iCls_TNTP_QT_Dieutri_Hinhanh) As String

    'update
    Function Update(objEnDieutriHinh As CM.iCls_TNTP_QT_Dieutri_Hinhanh) As Boolean

    'xoa
    Function Delete(uId_Dieutri_Hinhanh As String) As Boolean

    'select all

    Function SelectAllTable() As DataTable

    'select by ID Dieutri

    Function SelectByuId_Dieutri(uId_Dieutri As String) As DataTable
End Interface
