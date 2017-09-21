<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="rp_Mathangquantam.aspx.vb" Inherits="NANO_SPA.rp_Mathangquantam" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type ="text/javascript">
        var last_value = null;
        function callback(ASPxTinhthanh) {
            if (ASPxQuanhuyen.InCallback())
                last_value = ASPxTinhthanh.GetValue().toString();
            else
                ASPxQuanhuyen.PerformCallback(ASPxTinhthanh.GetValue().toString());
        }
        function ASPxQuanhuyen_Callback(s, e) {
            if (last_value) {
                ASPxQuanhuyen.PerformCallback(last_value);
                last_value = null;
            }
        }
    </script>
    
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quaylại" ToolTip="Quay lại"></dx:ASPxButton>

            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH SÁCH KHÁCH HÀNG SỬ DỤNG DỊCH VỤ</p>
            </li>
        </ul>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Khu vực</span></legend>
        <ul style="padding-left: 86px">
            <li class="text_title">Tỉnh thành : </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="ASPxTinhthanh" runat="server" ValueType="System.String" ClientInstanceName="ASPxTinhthanh" EnableCallbackMode="true"> 
                    <ClientSideEvents SelectedIndexChanged="function(s,e){ callback(s);}"/> 
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">Quận huyện: </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="ASPxQuanhuyen" runat="server" ValueType="System.String" ClientInstanceName="ASPxQuanhuyen" EnableCallbackMode="true" ><ClientSideEvents EndCallback ="ASPxQuanhuyen_Callback"/></dx:ASPxComboBox>
            </li>
        </ul>
    </fieldset>

    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Giới tính</span></legend>
        <ul style="padding-left: 86px">
            <li class="text_title">
                <dx:ASPxRadioButton ID="rb_Nam" GroupName="GT" runat="server" Text ="Nam"></dx:ASPxRadioButton>
            </li>
            <li class="text_title">
                <dx:ASPxRadioButton ID="rb_Nu" GroupName="GT" runat="server" Text="Nữ"></dx:ASPxRadioButton>
            </li>
            <li class="text_title">
                <dx:ASPxRadioButton ID="rb_All" GroupName="GT" runat="server" Text="Tất cả" Checked ="true"></dx:ASPxRadioButton>
            </li>
        </ul>
    </fieldset>

    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Lựa chọn độ tuổi</span></legend>
        <ul style="padding-left: 86px">
            <li class="text_title">Tuổi từ:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
            <li class="text_title">
                <dx:ASPxTextBox ID="ASPx_Tuoitu" runat="server" Width="170px"></dx:ASPxTextBox>    
            </li>
            <li class="text_title">Đến:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
            <li class="text_title">
                <dx:ASPxTextBox ID="ASPx_Tuoiden" runat="server" Width="170px"></dx:ASPxTextBox>    
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_Baocao" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <div style="width: 1075px; margin: auto; text-align: center">
        <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' ReportViewerID="ReportViewer1" Width="1050px" >
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
