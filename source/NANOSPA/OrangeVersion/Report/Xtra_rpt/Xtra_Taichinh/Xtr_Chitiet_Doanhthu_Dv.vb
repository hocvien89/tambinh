Public Class Xtr_Chitiet_Doanhthu_Dv
    Public Sub Binding(dt As DataTable)
        XrPictureBox_logo.ImageUrl = "~/images/icon_logo/pk-logo.png"
        BindingSource1.DataSource = dt
    End Sub
End Class