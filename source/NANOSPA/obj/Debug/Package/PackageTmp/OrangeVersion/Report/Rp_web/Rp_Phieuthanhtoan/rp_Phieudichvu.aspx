﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rp_Phieudichvu.aspx.vb" Inherits="NANO_SPA.rp_Phieudichvu" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

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
