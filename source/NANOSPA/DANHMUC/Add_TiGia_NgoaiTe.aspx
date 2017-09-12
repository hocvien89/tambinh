<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_TiGia_NgoaiTe.aspx.vb" Inherits="NANO_SPA.Add_TiGia_NgoaiTe" %>


<%@ Register src="../CONTROL/txtDatepicker.ascx" tagname="txtDatepicker" tagprefix="uc1" %>


<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="Table1" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow >
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI TỈ GIÁ NGOẠI TỆ</asp:TableHeaderCell>
</asp:TableHeaderRow>
</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

           Ngoại tệ:

</asp:TableCell>
<asp:TableCell>
            <asp:DropDownList AppendDataBoundItems ="true"  ID="ddlNgoaite" runat="server" Width="200px">
            </asp:DropDownList>
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

             Tỉ giá VND:

</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtTigia" runat="server" Width="200px" CssClass ="bigtext " onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtTigia" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
 
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
             <asp:Button ID="btn_ok" runat="server" Text="Lưu" CssClass ="Button " />
            <asp:Button ID="btn_back" runat="server" Text="<== Danh sách"  CssClass ="Button " CausesValidation ="false"/>
</asp:TableCell>
</asp:TableRow> 
</asp:Table>
    
</div> 
</div>

</asp:Content>
