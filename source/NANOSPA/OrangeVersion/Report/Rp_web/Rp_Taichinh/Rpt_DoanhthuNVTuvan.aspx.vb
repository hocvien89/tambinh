﻿Imports DevExpress.Web.ASPxEditors

Public Class Rpt_DoanhthuNVTuvan
    Inherits System.Web.UI.Page
    Private objFcBaocao As BO.clsB_Baocao_Taichinh
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Aspx_Tungay.Date = Now.Date
            Aspx_Denngay.Date = Now.Date
            loadnhanvien()
        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFcBaocao = New BO.clsB_Baocao_Taichinh
        Dim dt As DataTable
        dt = objFcBaocao.DoanhthuTV(cbonhanvien.SelectedItem.Value.ToString, Aspx_Tungay.Date, Aspx_Denngay.Date)
        Dim BC As New Xtr_DoanhthuNVTuvan
        BC.BindingSource1.DataSource = dt
        BC.lbcuahang.Text = Session("nv_Tencuahang_vn").ToString
        BC.lbdiachi.Text = Session("nv_DiachiCH_vn").ToString
        BC.lbtungay.Text = Aspx_Tungay.Text
        BC.lndenngay.Text = Aspx_Denngay.Text
        BC.lbnhanvien.Text = Session("sTendangnhap").ToString
        ReportViewer1.Report = BC

    End Sub
    Private Sub loadnhanvien()
        Dim objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang").ToString)
        Dim item As New ListEditItem
        item.Value = ""
        item.Text = "Tất cả"
        cbonhanvien.Items.Add(item)
        For Each row As DataRow In dt.Rows
            Dim item2 As New ListEditItem
            item2.Value = row("uId_Nhanvien")
            item2.Text = row("nv_Hoten_vn")
            cbonhanvien.Items.Add(item2)
        Next
        cbonhanvien.SelectedIndex = 0
    End Sub

    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs)
        loaddata()
    End Sub
End Class