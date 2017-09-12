<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_DM_Loaimathang.aspx.vb" Inherits="NANO_SPA.Add_DM_Loaimathang" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="table1" runat="server" Width="100%" CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI LOẠI MẶT HÀNG</asp:TableHeaderCell>
</asp:TableHeaderRow>
</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 500px; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

            Tên loại mặt hàng:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtName" runat="server" Width="350px" CssClass ="bigtext "></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtName" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
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