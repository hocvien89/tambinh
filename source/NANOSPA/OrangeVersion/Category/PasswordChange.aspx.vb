Public Class PasswordChange
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_UserName.Text = Session("sTendangnhap")
            txt_OldPass.Focus()
        End If
    End Sub

    Protected Sub btn_Change_Click(sender As Object, e As EventArgs)
        Dim objFcNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objFcLogin As New BO.clsB_Nhanvien
        Dim objEnlogin As New CM.cls_Nhanvien
        lbl_Thongbao.Text = ""
        Dim uid_nhanvien As String
        Dim UserName As String
        Dim NewPass As String
        Dim OldPass As String
        OldPass = txt_OldPass.Text
        UserName = Session("sTendangnhap")
        objEnlogin.v_Tendangnhap = UserName
        objEnlogin.v_Matkhau = OldPass
        If objFcLogin.chk_CheckLogin(objEnlogin) Then
            NewPass = txt_NewPassRewrite.Text
            uid_nhanvien = Session("uId_Nhanvien_Dangnhap")
            Try
                objFcNhanvien.DoiMatKhau(uid_nhanvien, NewPass)
            Catch ex As Exception

            End Try
            lbl_Thongbao.Text = "Bạn thay đổi mật khẩu thành công"
        Else
            txt_OldPass.Text = ""
            txt_OldPass.Focus()
            lbl_Thongbao.Text = "Mật khẩu cũ khỗng chính xác"
        End If
       
    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Response.Redirect("~/LoginSys.aspx")
    End Sub
End Class