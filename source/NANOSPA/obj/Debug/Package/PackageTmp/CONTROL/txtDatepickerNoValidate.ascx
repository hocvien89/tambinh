﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="txtDatepickerNoValidate.ascx.vb" Inherits="NANO_SPA.txtDatepickerNoValidate" %>

<link rel="stylesheet" href="../Css/datepicker.css" type="text/css"/>
<script type="text/javascript" src="../Js/datepicker.js"></script>
<asp:TextBox ID="txtDatePicker" runat="server" Height="25px" ToolTip="Nhập theo định dạng: 30/01/2000"  Width="200px" CssClass ="bigtext" MaxLength="200" AutoComplete="off">
   </asp:TextBox>
  
<img alt="Chọn ngày tháng" title="Chọn ngày tháng" src="../images/calendar.gif" onclick='displayDatePicker("<% =txtDatePicker.ClientID %>", this, "dmy", "/");'
align="middle" />
<asp:RegularExpressionValidator ControlToValidate="txtDatePicker" ID="RegularExpressionValidator1" 
    ValidationExpression ="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" runat="server"  ErrorMessage="Err!!"></asp:RegularExpressionValidator>