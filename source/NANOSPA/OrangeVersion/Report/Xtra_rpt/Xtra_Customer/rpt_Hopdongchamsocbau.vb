Public Class rpt_Hopdongchamsocbau
    Public Sub Bindata(dt As DataTable)
        Dim objEnThamsohethong As New CM.cls_QT_THAMSOHETHONG
        Dim objFcThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        BindingSource1.DataSource = dt
        XrPictureBox1.ImageUrl = objFcThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
    End Sub

End Class