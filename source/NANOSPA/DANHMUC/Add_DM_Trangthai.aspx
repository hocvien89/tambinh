<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_DM_Trangthai.aspx.vb" Inherits="NANO_SPA.Add_DM_Trangthai" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="Table1" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI TRẠNG THÁI</asp:TableHeaderCell>
</asp:TableHeaderRow>
</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume " Width="40%">

            Mã trạng thái:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMaTrangthai" runat="server" Width="218px" CssClass ="bigtext "></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtMaTrangthai" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Tên trạng thái:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtName" runat="server" Width="218px" CssClass ="bigtext "></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ControlToValidate ="txtName" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">

            Mầu chữ

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMauChu" runat="server" Width="218px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">

            Mầu nền

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMauNen" runat="server" Width="218px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">

            Loại

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtLoai" runat="server" Width="218px" CssClass ="bigtext "></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ControlToValidate ="txtLoai" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtLoai" ErrorMessage="Nhập số" ValidationExpression="\d"></asp:RegularExpressionValidator>  
</asp:TableCell>
</asp:TableRow>


<asp:TableRow > 
    
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
 
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
              <asp:Button ID="btn_ok" runat="server" Text="Lưu"  CssClass ="Button "/>

            <asp:Button ID="btn_back" runat="server" Text="<== Danh sách" CssClass="Button " CausesValidation ="false" />
</asp:TableCell>
</asp:TableRow> 

</asp:Table>
</div>
</div>

</asp:Content>