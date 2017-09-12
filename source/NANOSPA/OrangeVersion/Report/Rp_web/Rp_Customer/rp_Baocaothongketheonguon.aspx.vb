Imports DevExpress.Web.ASPxEditors

Public Class rp_Baocaothongketheonguon
    Inherits System.Web.UI.Page
    Private objFcNguon As BO.CRM_DM_NGUONFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Aspx_Tungay.Date = Now.Date
            Aspx_Denngay.Date = Now.Date
            loadcombo()
        End If
        loaddata()

    End Sub
    Private Sub loadcombo()
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim dt As DataTable
        Dim item As New ListEditItem
        dt = objFcNguon.SelectAllTable()
        item.Value = ""
        item.Text = "Tất cả"
        cbo_khachhang.Items.Add(item)
        For Each row As DataRow In dt.Rows
            Dim item2 As New ListEditItem
            item2.Value = row("uId_Nguon")
            item2.Text = row("nv_Nguon_vn")
            cbo_khachhang.Items.Add(item2)
        Next
        cbo_khachhang.SelectedIndex = 0

        'cbo_khachhang.DataSource = dt
        'cbo_khachhang.ValueField = "uId_Nguon"
        'cbo_khachhang.TextField = "nv_Nguon_vn"
        'cbo_khachhang.DataBind()
    End Sub
    Private Sub loaddata()
        Dim objFcBaocaoKH = New BO.clsB_BaoCao_Khachhang
        Dim dt As DataTable
        Dim BC As New Xtr_Baocaotheonguon
        dt = objFcBaocaoKH.BaocaothongkeByNguon(cbo_khachhang.SelectedItem.Value.ToString(), Aspx_Tungay.Date, Aspx_Denngay.Date)
        BC.BindingSource1.DataSource = dt
        BC.lbcuahang.Text = Session("nv_Tencuahang_vn").ToString
        BC.lbdiachi.Text = Session("nv_DiachiCH_vn").ToString
        BC.lbtungay.Text = Aspx_Tungay.Text
        BC.lbdenngay.Text = Aspx_Denngay.Text
        ReportViewer1.Report = BC

    End Sub

    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs)
        loaddata()
    End Sub
End Class