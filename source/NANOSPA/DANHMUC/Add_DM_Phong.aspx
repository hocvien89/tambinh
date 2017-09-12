<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_DM_Phong.aspx.vb" Inherits="NANO_SPA.Add_DM_Phong1" %>


<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="Table1" runat="server" Width="100%" CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI PHÒNG</asp:TableHeaderCell>
</asp:TableHeaderRow>
</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

            Tên cửa hàng:

</asp:TableCell>
<asp:TableCell>
            <asp:DropDownList ID="ddlCuaHang" Width="183px" runat="server"
                AppendDataBoundItems="True">
            </asp:DropDownList>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Tên phòng:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtTenPhong" runat="server" Width="183px" CssClass ="bigtext "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtTenPhong" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Số thứ tự:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtStt" runat="server" Width="183px" CssClass ="bigtext "></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtStt" ErrorMessage="Nhập số" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>  
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Số khách tối đa:

</asp:TableCell>
<asp:TableCell>
             <asp:TextBox ID="txtSlKhach" runat="server" Width="183px" CssClass ="bigtext "></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtSlKhach" ErrorMessage="Nhập số" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Điện thoại:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtDienThoai" runat="server" Width="183px" CssClass ="bigtext "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ControlToValidate ="txtDienThoai" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Màu nền:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMaunen" runat="server" Width="183px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Màu chữ:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMauchu" runat="server" Width="183px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
 
<asp:TableRow>

<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
             <asp:Button ID="btn_ok" runat="server" Text="Lưu"  CssClass ="Button "/>
           <asp:Button ID="btn_Reset" runat="server" Text="<== Danh sách" CssClass ="Button " CausesValidation="false" />
</asp:TableCell>
</asp:TableRow> 

</asp:Table>
</div> 
</div>

</asp:Content>

