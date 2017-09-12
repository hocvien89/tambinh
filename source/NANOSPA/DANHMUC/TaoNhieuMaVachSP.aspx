<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="TaoNhieuMaVachSP.aspx.vb" Inherits="NANO_SPA.TaoNhieuMaVachSP" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">
<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">TẠO NHIỀU MÃ VẠCH</asp:TableHeaderCell>
</asp:TableHeaderRow>
<asp:TableRow>
   <asp:TableCell >
<CR:CrystalReportViewer ID="CrvMaVachSP"  runat="server" AutoDataBind="True" CssClass ="CrystalReport " /> 
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:Content>
