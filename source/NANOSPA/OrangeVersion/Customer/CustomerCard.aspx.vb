Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Drawing
Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.XtraPrinting
Public Class CustomerCard
    Inherits System.Web.UI.Page
    Private objFcThechuyentien As New BO.clsB_TTV_KH_THECHUYENTIENFacade
    Private objEnThechyentien As New CM.cls_TTV_KH_THECHUYENTIENEntity
    Private objFcThechuyentien_Lichsu As New BO.clsb_TTV_KH_THECHUYENTIEN_LichsuFacede
    Private objEnThechuyentien_Lichsu As New CM.cls_TTV_THECHUYENTIEN_LICHSUEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
            loadcombokhachhang()

        End If

        loaddatagridthongtin()
        ltrSuccess.Text = ""
        lbl_Thongbao.Text = ""
        'loaddatagridlichsu()
    End Sub
    Private Sub loaddatagridthongtin()
        Dim dt As DataTable
        Dim objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        Try
            dt = objFcThechuyentien.SelectAllTable()
            Grid_Thongtinthe.DataSource = dt
            Grid_Thongtinthe.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    
    Private Sub loadcombokhachhang()
        Dim dt As DataTable
        Dim objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        dt = objFcThechuyentien.SelectAllTable()
        cbo_Khachhang.DataSource = dt
        Dim item_t As New ListEditItem
        item_t.Value = "0"
        item_t.Text = "Không xác định"
        cbo_Khachhang.Items.Add(item_t)
        For Each row As DataRow In dt.Rows
            Dim item As New ListEditItem
            item.Value = row("uId_Thechuyentien")
            item.Text = row("nv_Hoten_vn")
            cbo_Khachhang.Items.Add(item)
        Next
        cbo_Khachhang.SelectedIndex = 0
    End Sub

    Protected Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        Dim objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        Dim objEnThechyentien = New CM.cls_TTV_KH_THECHUYENTIENEntity
        Dim uId_Thechuyentien As String
        With objEnThechyentien
            .f_Sotien = txtsotien.Text
            uId_Thechuyentien = cbo_Khachhang.SelectedItem.Value.ToString
        End With
        objFcThechuyentien.Update_NT(objEnThechyentien, uId_Thechuyentien)

        loaddatagridthongtin()
        lbl_Thongbao.Text = "Nạp tiền thành công!"


    End Sub

    
    Protected Sub Grid_Lichsu_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFcThechuyentien_Lichsu = New BO.clsb_TTV_KH_THECHUYENTIEN_LichsuFacede
        Dim dt As DataTable = objFcThechuyentien_Lichsu.SelectAllTable(uId_Khachhang)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFcThechuyentien = Nothing
        dt = Nothing
    End Sub
End Class