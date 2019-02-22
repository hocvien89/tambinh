Public Class Xtr_Chitiet_Doanhthu_Tonghop

    Sub Bindata(dt As DataTable)
        XrPictureBox_logo.ImageUrl = "~/images/icon_logo/pk-logo.png"
        BindingSource_DATA.DataSource = dt
    End Sub

End Class