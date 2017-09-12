<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Add_DM_Menhgiatien.aspx.vb" Inherits="NANO_SPA.Add_DM_Menhgiatien"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
<asp:Table ID="table1" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI MỆNH GIÁ TIỀN</asp:TableHeaderCell>
</asp:TableHeaderRow>

</asp:Table>
<div align="center" style="padding: 30px 0px">
<div  style="width: 550px; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="150px">

            Loại tiền:

</asp:TableCell>
<asp:TableCell>
            <asp:DropDownList ID="ddlNgoaite" runat="server" Width="200px">
        
            </asp:DropDownList>
            
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >

            Mệnh giá:

            
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtMenhgia" runat="server"  CssClass ="bigtext " onkeyup="javascript:ThousandSeparate(this)" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtMenhgia" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
 
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
              <asp:Button ID="btn_ok" runat="server" Text="Lưu" CssClass ="Button " />

            <asp:Button ID="btn_back" runat="server" Text="<== Danh sách" CssClass="Button " CausesValidation="false"  />
</asp:TableCell>
</asp:TableRow> 

</asp:Table>
</div>
</div>
</asp:Content>
