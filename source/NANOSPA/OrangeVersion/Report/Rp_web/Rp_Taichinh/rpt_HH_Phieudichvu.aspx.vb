Imports DevExpress.Web.ASPxEditors

Public Class rpt_HH_Phieudichvu
    Inherits System.Web.UI.Page
    Private objFcPhieudichvu As BO.TNTP_PHIEUDICHVUFacade
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Aspx_Tungay.Date = Now.Date
            Aspx_Denngay.Date = Now.Date
            loadcombo()
        End If

        loaddata()
    End Sub
    Private Sub loadcombo()
        cbo_nhanvien.Items.Clear()
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcNhanvien.SelectAllAdminTable(Session("uId_Cuahang"))
       

        If dt.Rows.Count > 1 Then
            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cbo_nhanvien.Items.Add(item)
            For Each row As DataRow In dt.Rows
                Dim item2 As New ListEditItem
                item2.Value = row("uId_Nhanvien")
                item2.Text = row("nv_Hoten_vn")
                cbo_nhanvien.Items.Add(item2)
            Next
        Else
            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cbo_nhanvien.Items.Add(item)
        End If
       
        cbo_nhanvien.SelectedIndex = 0
    End Sub
    Private Sub loaddata()

        objFcPhieudichvu = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable
        Dim Bc As New Xtr_HH_Phieudichvu
        Dim st As String = cbo_nhanvien.SelectedItem.Value.ToString
        dt = objFcPhieudichvu.BaocaoHH(st, Aspx_Tungay.Date, Aspx_Denngay.Date)
        Bc.BindingSource1.DataSource = dt
        Bc.lbCuahang.Text = Session("nv_Tencuahang_vn").ToString
        Bc.lbtungay.Text = Aspx_Tungay.Text
        Bc.lbdenngay.Text = Aspx_Denngay.Text
        ReportViewer1.Report = Bc

    End Sub

    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs)
        loaddata()
    End Sub
End Class