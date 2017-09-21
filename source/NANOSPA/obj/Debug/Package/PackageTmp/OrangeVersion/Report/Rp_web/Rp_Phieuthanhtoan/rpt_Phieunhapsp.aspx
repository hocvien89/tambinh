<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rpt_Phieunhapsp.aspx.vb" Inherits="NANO_SPA.rpt_Phieunhapsp" %>
<%@ Register Src="~/OrangeVersion/Report/Rp_web/ReportViewerControl.ascx" TagPrefix="uc1" TagName="ReportViewerControl" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <uc1:ReportViewerControl runat="server" ID="ReportViewerControl" />
    </div>
    </form>
</body>
</html>
