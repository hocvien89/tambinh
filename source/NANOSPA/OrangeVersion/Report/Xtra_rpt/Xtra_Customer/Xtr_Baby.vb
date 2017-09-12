Public Class Xtr_Baby
    Public Sub Bindata(ByVal uId_Khachhang As String, ByVal uId_Phieudichvuchitiet As String)
        Dim objEnThamsohethong As New CM.cls_QT_THAMSOHETHONG
        Dim objFcThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim objFcBaocaokhachhang As New BO.clsB_BaoCao_Khachhang
        Dim objFcPhieudichvuchitiet As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt As DataTable
        dt = objFcBaocaokhachhang.BaocaoHopDong_MevaBe(uId_Khachhang, uId_Phieudichvuchitiet)
        Dim objEnDM_Dichvu As New CM.TNTP_DM_DICHVUEntity
        If dt.Rows.Count > 0 Then
            BindingSource1.DataSource = dt
            dt.Dispose()
        End If

        XrPictureBox1.ImageUrl = objFcThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
    End Sub
End Class