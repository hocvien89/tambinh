<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_DM_Cuahang.aspx.vb" Inherits="NANO_SPA.Add_DM_Cuahang" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<script language="javascript" type="text/javascript">
    function UpperString() {
        var x = document.getElementById('<%=txtMaCuahang.ClientID%>');
        x.value = x.value.toUpperCase();
    }
</script>
<asp:Table ID="table1" runat="server" Width="100%" HorizontalAlign ="Center"  CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2"  > DANH MỤC==> THÊM MỚI CỬA HÀNG</asp:TableHeaderCell>
</asp:TableHeaderRow>
</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

            Mã cửa hàng:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMaCuahang" runat="server" Width="256px" CssClass ="bigtext " MaxLength="2" onkeyup="UpperString()" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtMaCuahang" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >

            Tên cửa hàng:
         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtTenCuahang" runat="server" Width="256px" CssClass ="bigtext "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ControlToValidate ="txtTenCuahang" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">

            Địa chỉ:
 
            
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtDiaChi" runat="server" Width="256px" CssClass ="bigtext "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ControlToValidate ="txtDiaChi" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
 </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >

            Trạng Thái:

  
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlTrangthai" runat="server" Width="137px">
                <asp:ListItem Value="1">Hoạt động</asp:ListItem>
                <asp:ListItem Value="0">Ngừng hoạt động</asp:ListItem>
            </asp:DropDownList>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
            <asp:Button ID="btn_OK" runat="server"  Text="Xác nhận"  CssClass ="Button "/>

            <asp:Button ID="btn_Reset" runat="server" Text="Quay lại" CssClass="Button " CausesValidation ="false" />
            <asp:Button ID="btnThemAdmin" runat="server"  Text="Thêm TK Admin"  CssClass ="Button" />
</asp:TableCell>

</asp:TableRow>

</asp:Table>
</div>
<br />
<div id="divTkAdmin" runat="server" style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;" visible="false">
<asp:Table ID="Table2" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

           Tên đăng nhập :

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtTenadmin" runat="server" style="margin-left: 0px" 
                Width="256px" CssClass ="bigtext " ReadOnly="true"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >

            Mật khẩu :
         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtMatkhau" runat="server" Width="256px" CssClass ="bigtext " TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server" ControlToValidate ="txtMatkhau" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">

            Nhập lại :
 
            
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtNhaplaiMK" runat="server" Width="256px" CssClass ="bigtext " TextMode="Password" ></asp:TextBox>
            <asp:CompareValidator runat="server" ErrorMessage="Err!!" ControlToCompare="txtMatkhau" ControlToValidate="txtNhaplaiMK"></asp:CompareValidator>
 </asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
            <asp:Button ID="btnLuu" runat="server"  Text="Lưu"  CssClass ="Button "/>

</asp:TableCell>

</asp:TableRow>

</asp:Table>
</div>
</div>
</asp:Content>
