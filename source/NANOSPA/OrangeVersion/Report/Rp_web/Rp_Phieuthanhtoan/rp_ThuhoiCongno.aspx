﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rp_ThuhoiCongno.aspx.vb" Inherits="NANO_SPA.rp_ThuhoiCongno" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
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
