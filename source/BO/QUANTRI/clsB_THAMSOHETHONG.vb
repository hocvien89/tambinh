Public Class clsB_QT_THAMSOHETHONG
    Dim ITHAMSOHETHONG As DB.iClisD_THAMSOHETHONG = New DB.clsD_THAMSOHETHONG

    Public Function UpdateTHAMSOHETHONG(ByVal THAMSOHETHONG As CM.cls_QT_THAMSOHETHONG) As Boolean
        Return ITHAMSOHETHONG.UpdateByV_Tenbien(THAMSOHETHONG)
    End Function

    Public Function SelectTHAMSOHETHONGByID(ByVal v_Tenbien As String) As CM.cls_QT_THAMSOHETHONG
        Return ITHAMSOHETHONG.SelectByV_Tenbien(v_Tenbien)
    End Function

    Public Function Insert(objEnthamso As CM.cls_QT_THAMSOHETHONG) As Boolean
        Return ITHAMSOHETHONG.Insert(objEnthamso)
    End Function

    Public Function Delete(uId_Thamso As String) As Boolean
        Return ITHAMSOHETHONG.Delete(uId_Thamso)
    End Function

    Public Function SelectAllTable() As DataTable
        Return ITHAMSOHETHONG.SelectAllTable()
    End Function

    Public Function Update(objEnThamso As CM.cls_QT_THAMSOHETHONG) As Boolean
        Return ITHAMSOHETHONG.Update(objEnThamso)
    End Function
End Class
