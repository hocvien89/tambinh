<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rp_InHoadontonghop.aspx.vb" Inherits="NANO_SPA.rp_InHoadontonghop" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Src="~/OrangeVersion/Report/Rp_web/ReportViewerControl.ascx" TagPrefix="uc1" TagName="ReportViewerControl" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

    <link href="../../../../bootstrap/css/mybootstrap.css" rel="stylesheet" type="text/css" />
 <link href="../../../../Css/simple.css" rel="stylesheet" type="text/css" />
<link href="../../../../Css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function btnlocClick(s, e) {
        btnloc.PerformCallback();
    }
</script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
            <legend ><p  style="font-size:14px">Lựa chọn</p></legend>
            <ul>
                <li class="text_title" style="font-size:14px">Phiếu xuất: </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cboPhieuxuat" runat="server" ValueType="System.String"></dx:ASPxComboBox>
            </li>
                <li class="text_title"  style="font-size:14px">Phiếu dịch vụ</li>
            <li class="text_title">               
                <dx:ASPxComboBox ID="cboPhieudichvu" runat="server" ClientInstanceName="cbophieunhap"></dx:ASPxComboBox>
            </li>
                <li class="text_title">
                    <dx:ASPxButton ID="btnLoc" runat="server" ClientInstanceName="btnloc" Text="Lọc">
                        <ClientSideEvents Click="btnlocClick" />
                    </dx:ASPxButton>
                </li>
            </ul>
        </fieldset>
        </div>
    <div>       
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" OnCallback="ASPxCallbackPanel1_Callback" ClientInstanceName="btnloc">
            <PanelCollection>
                <dx:PanelContent>
                     <uc1:ReportViewerControl runat="server" ID="ReportViewerControl" />
                </dx:PanelContent>
                
            </PanelCollection>
        </dx:ASPxCallbackPanel> 
    </div>
    </form>
</body>
</html>
