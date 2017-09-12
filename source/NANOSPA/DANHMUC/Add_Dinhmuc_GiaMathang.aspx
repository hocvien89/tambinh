<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_Dinhmuc_GiaMathang.aspx.vb" Inherits="NANO_SPA.Add_Dinhmuc_GiaMathang" %>
<%@ Register src="../CONTROL/txtDatepicker.ascx" tagname="txtDatepicker" tagprefix="uc1" %>
<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
    
<asp:Table ID="table1" runat="server" Width="100%" HorizontalAlign ="Center"  CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow >
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI ĐỊNH MỨC GIÁ MẶT HÀNG</asp:TableHeaderCell>
</asp:TableHeaderRow>

</asp:Table>    
 
 
 <div align="center" style="padding: 30px 0px">
<div  style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
    
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

          Tên mặt hàng:

</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtMathang" Enabled ="false"  runat="server" CssClass ="bigtext " Width="200px"></asp:TextBox>
            <asp:Button ID="btn_DSMathang" runat="server" Text="..." CausesValidation="false" CssClass="Button "/>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

          Kho:

</asp:TableCell>
<asp:TableCell>
    <asp:DropDownList ID="ddlKho" runat="server"  Width="200px"/>
</asp:TableCell>
</asp:TableRow>




<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

           Ngày nhập :

</asp:TableCell>
<asp:TableCell>
          <uc1:txtDatepicker ID="txtNgaynhap" runat="server" />
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
             Giá nhập:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtGianhap" onkeyup="javascript:ThousandSeparate(this)" CssClass ="bigtext " runat="server" Width="200px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
             Biên độ giá nhập:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtBiendoGianhap" CssClass ="bigtext " runat="server" Width="200px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
           Giá xuất:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtGiaxuat" onkeyup="javascript:ThousandSeparate(this)" CssClass ="bigtext " runat="server" Width="200px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
             Biên độ giá xuất:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtBiendoGiaxuat" CssClass ="bigtext " runat="server" Width="200px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
 
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
             <asp:Button ID="btn_ok" runat="server" Text="Lưu" CssClass ="Button " />
            <asp:Button ID="btn_back" runat="server" Text="<== Danh sách"  CssClass ="Button " CausesValidation ="false" />
</asp:TableCell>
</asp:TableRow> 
</asp:Table>
</div>
</div>

</asp:Content>

