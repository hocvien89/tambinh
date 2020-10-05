<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReportViewerControl.ascx.vb" Inherits="NANO_SPA.ReportViewerControl" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<dx:ReportToolbar ID="ReportToolbar1" EnableViewState="false" style="min-width:97%" runat='server' ReportViewer="<%#ReportViewer1%>" ShowDefaultButtons='False'>
    <Items>
        <dx:ReportToolbarButton ItemKind='Search' />
        <dx:ReportToolbarSeparator />
        <dx:ReportToolbarButton ItemKind='SaveToWindow' />
        <dx:ReportToolbarButton ItemKind='SaveToWindow' />
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
<dx:ReportViewer ID="ReportViewer1" OnCacheReportDocument="ReportViewer1_CacheReportDocument" OnRestoreReportDocumentFromCache="ReportViewer1_RestoreReportDocumentFromCache" runat="server"></dx:ReportViewer>
