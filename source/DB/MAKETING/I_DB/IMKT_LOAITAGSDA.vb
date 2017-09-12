Public Interface IMKT_LOAITAGSDA
    Function Insert(ByVal obj As CM.MKT_LOAITAGSEntity) As Boolean

    Function Update(ByVal obj As CM.MKT_LOAITAGSEntity) As Boolean

    Function SelectAll() As System.Data.DataTable

    Function SelectById(ByVal Id_Loaitag As Integer) As CM.MKT_LOAITAGSEntity

    Function DeleteByID(ByVal i_Thutu As Integer) As Boolean
End Interface
