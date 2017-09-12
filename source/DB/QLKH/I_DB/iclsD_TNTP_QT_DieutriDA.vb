Public Interface ITNTP_QT_DieutriDA

    Function SelectAll(ByVal uId_Phieudichvu_Chitiet As String) As System.Collections.Generic.List(Of CM.TNTP_QT_DieutriEntity)

    Function SelectAllTable(ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function SelectBySoPhieu(ByVal v_Sophieu As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_QT_Dieutri As String) As CM.TNTP_QT_DieutriEntity

    Function Insert(ByVal obj As CM.TNTP_QT_DieutriEntity) As String

	Function DeleteByID(ByVal uId_QT_Dieutri AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_QT_DieutriEntity) As Boolean

    Function Inphieu(ByVal uId_QT_Dieutri As String) As System.Data.DataTable

    Function SelectVattuTieuhao(ByVal uId_QT_Dieutri As String) As System.Data.DataTable

    Function SelectAllByIdDV(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As System.Data.DataTable

    Function SelectAllByDay(ByVal uId_Phieudichvu As String, ByVal d_Ngay As DateTime) As System.Data.DataTable

    Function SelectBCKHBoDieuTri(ByVal i_Songay As Integer, ByVal uId_Cuahang As String, ByVal NhomDV As String) As System.Data.DataTable

    Function Inphieulieutrinh(ByVal uId_QT_Dieutrinh As String)

End Interface