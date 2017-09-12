Partial Public Class Add_Nhanvien
    Inherits System.Web.UI.Page

    Private ocls_Nhansu As CM.cls_Nhanvien
    Private oclsB_Nhansu As BO.clsB_Nhanvien

#Region "Init, Dispose"
    Public Sub New()
        ocls_Nhansu = New CM.cls_Nhanvien
        oclsB_Nhansu = New BO.clsB_Nhanvien
    End Sub
    Protected Overrides Sub Finalize()
        ocls_Nhansu = Nothing
        oclsB_Nhansu = Nothing
        MyBase.Finalize()
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '<uc1:UC_Calendar ID="UC_Calendar1" runat="server" />

        ' <%@ Register src="../UC_Calendar.ascx" tagname="UC_Calendar" tagprefix="uc1" %>
    End Sub

    Protected Sub cmdLuu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLuu.Click
        'Lay gia tri, gan cho doi tuong moi
        ocls_Nhansu.v_Manhanvien = txtManhanvien.Text
        ocls_Nhansu.nv_Hoten_vn = txtHoten.Text
        ocls_Nhansu.d_Ngaysinh = dNgaysinh.Text
        ocls_Nhansu.nv_Chucvu_vn = txtChucvu.Text

        ocls_Nhansu.nv_Diachi_vn = txtDiachi.Text
        ocls_Nhansu.nv_Quequan_vn = txtQuequan.Text
        ocls_Nhansu.v_Dienthoai = txtDiachi.Text
        ocls_Nhansu.v_Email = txtEmail.Text

        ocls_Nhansu.v_Tendangnhap = txtTendangnhap.Text
        ocls_Nhansu.v_Matkhau = txtMatkhau.Text
        ocls_Nhansu.b_ActiveLogin = chkActiveLogin.Checked

        ocls_Nhansu.d_Ngayvaolam = dNgayvaolam.Text
        ocls_Nhansu.b_Danglamviec = chkDanglamviec.Checked

        Response.Write(ocls_Nhansu.d_Ngaysinh)


        'Luu thong tin doi tuong
        If oclsB_Nhansu.InsertQT_DM_NHANVIEN(ocls_Nhansu) Then

        End If

    End Sub

    Protected Sub cmdThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Response.Write("<script language=javascript> window.close()</script>")
    End Sub

    Protected Sub txtManhanvien_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManhanvien.TextChanged

    End Sub



   
End Class