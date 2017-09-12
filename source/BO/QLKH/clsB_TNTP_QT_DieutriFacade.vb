Public Class TNTP_QT_DieutriFacade

    Dim ITNTP_QT_Dieutri As DB.ITNTP_QT_DieutriDA = New DB.TNTP_QT_DieutriDA

    Public Function SelectAll(ByVal uId_Phieudichvu_Chitiet As String) As List(Of CM.TNTP_QT_DieutriEntity)
        Return ITNTP_QT_Dieutri.SelectAll(uId_Phieudichvu_Chitiet)
    End Function
    Public Function SelectAllByIdDV(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.SelectAllByIdDV(uId_Phieudichvu, uId_Dichvu)
    End Function
    Public Function SelectAllByDay(ByVal uId_Phieudichvu As String, ByVal d_Ngay As DateTime) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.SelectAllByDay(uId_Phieudichvu, d_Ngay)
    End Function
    Public Function SelectAllTable(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.SelectAllTable(uId_Phieudichvu)
    End Function
    Public Function SelectBySoPhieu(ByVal v_Sophieu As String) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.SelectBySoPhieu(v_Sophieu)
    End Function
    Public Function Insert(ByVal obj As CM.TNTP_QT_DieutriEntity) As String
        Return ITNTP_QT_Dieutri.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_QT_DieutriEntity) As Boolean
        Return ITNTP_QT_Dieutri.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_QT_Dieutri AS String) AS Boolean
		Return ITNTP_QT_Dieutri.DeleteByID(uId_QT_Dieutri)
	End Function

    Public Function SelectByID(ByVal uId_QT_Dieutri As String) As CM.TNTP_QT_DieutriEntity
        Return ITNTP_QT_Dieutri.SelectByID(uId_QT_Dieutri)
    End Function
    Public Function Inphieu(ByVal uId_QT_Dieutri As String) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.Inphieu(uId_QT_Dieutri)
    End Function

    Public Function SelectVattuTieuhao(ByVal uId_QT_Dieutri As String) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.SelectVattuTieuhao(uId_QT_Dieutri)
    End Function

    Public Function SelectBCKHBoDieuTri(ByVal i_Songay As Integer, ByVal uId_Cuahang As String, ByVal NhomDV As String) As System.Data.DataTable
        Return ITNTP_QT_Dieutri.SelectBCKHBoDieuTri(i_Songay, uId_Cuahang, NhomDV)
    End Function

    Public Function Inphieulieutrinh(ByVal uId_QT_Dieutri As String) As DataTable
        Return ITNTP_QT_Dieutri.Inphieulieutrinh(uId_QT_Dieutri)
    End Function
End Class