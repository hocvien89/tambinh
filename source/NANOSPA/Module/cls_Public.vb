Public Class cls_Public
    Inherits System.Web.UI.Page

    Public Sub CheckUser()
        Dim objFCPhanQuyen As New BO.QT_PHANQUYENFacade
        Dim DT As New DataTable
        Try
            DT = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "7d0cbc29-b030-4fbb-ada2-273ea5ad3a1f")
            If DT.Rows.Count > 0 Then
                Public_Class.CheckUser(Me.Page, DT)
            Else
                Response.Redirect("../ThongBaoQuyen.aspx")
            End If
        Catch ex As Exception
            DT = Nothing
            objFCPhanQuyen = Nothing
            Response.Redirect("../Login.aspx")
        Finally
            DT = Nothing
            objFCPhanQuyen = Nothing
        End Try
    End Sub
End Class
