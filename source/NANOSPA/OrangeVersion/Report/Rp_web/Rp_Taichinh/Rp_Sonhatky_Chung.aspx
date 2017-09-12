<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Rp_Sonhatky_Chung.aspx.vb" Inherits="NANO_SPA.Rp_Sonhatky_Chung" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/CONTROL/txtDatepicker.ascx" TagName="txtDatepicker" TagPrefix="uc1" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>SỔ NHẬT KÝ CHUNG</p>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Lựa chọn thời gian</span></legend>
        <ul style="padding-left:86px">
            <li class="text_title">Từ ngày: </li>
       
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title" style="width:100px">
                <dx:ASPxButton ID="btn_Baocao" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <div style="width: 1075px; margin: auto; text-align: center">
    <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' ReportViewerID="ReportViewer1" Width="1075px">
        <Items>
            <dx:ReportToolbarButton ItemKind='Search' />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton ItemKind='PrintReport' />
            <dx:ReportToolbarButton ItemKind='PrintPage' />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
            <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
            <dx:ReportToolbarLabel ItemKind='PageLabel' />
            <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dx:ReportToolbarComboBox>
            <dx:ReportToolbarLabel ItemKind='OfLabel' />
            <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
            <dx:ReportToolbarButton ItemKind='NextPage' />
            <dx:ReportToolbarButton ItemKind='LastPage' />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton ItemKind='SaveToDisk' />
            <dx:ReportToolbarButton ItemKind='SaveToWindow' />
            <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                <Elements>
                    <dx:ListElement Value='pdf' />
                    <dx:ListElement Value='xls' />
                    <dx:ListElement Value='xlsx' />
                    <dx:ListElement Value='rtf' />
                    <dx:ListElement Value='mht' />
                    <dx:ListElement Value='html' />
                    <dx:ListElement Value='txt' />
                    <dx:ListElement Value='csv' />
                    <dx:ListElement Value='png' />
                </Elements>
            </dx:ReportToolbarComboBox>
        </Items>
        <Styles>
            <LabelStyle>
                <Margins MarginLeft='3px' MarginRight='3px' />
            </LabelStyle>
        </Styles>
    </dx:ReportToolbar>
    <dx:ReportViewer ID="ReportViewer1" runat="server"></dx:ReportViewer>
        </div>
</asp:Content>
