<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Detail_DM_Mathang.aspx.vb" Inherits="NANO_SPA.Detail_DM_Mathang" %>


<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" BorderStyle="Groove" BorderWidth="2" CssClass ="Table " CellPadding="0" CellSpacing="0">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2" >DANH MỤC==> CHI TIẾT MẶT HÀNG</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
            Mã mặt hàng:
</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMaMH" runat="server" 
                Width="256px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ControlToValidate ="txtMaMH" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
            Tên mặt hàng:
</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtTenMH" runat="server" 
                Width="256px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server" ControlToValidate ="txtTenMH" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Loại mặt hàng: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlLoaimathang" AppendDataBoundItems ="true"  runat="server" Width="200px"/>
            
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Nhóm mặt hàng: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlNhommathang" runat="server" AppendDataBoundItems ="true"  Width="200px"/>
</asp:TableCell>
</asp:TableRow>



<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Xuất xứ: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlXuatXu" runat="server" AppendDataBoundItems ="true"  Width="200px"/>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Đơn vị tính:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtDVT" runat="server" Width="256px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtDVT" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>



<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Hạn mức tồn:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHanmucTon" runat="server" Width="256px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ControlToValidate ="txtHanmucTon" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Cảnh báo hàng tồn (ngày):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtTon" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Cảnh báo hạn sử dụng (ngày):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHSD" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Ghi chú:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtGhichu" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            %Hoa hồng (KTV):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongKTV" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            %Hoa hồng (TVV):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongTVV" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            %Hoa hồng (CTV):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongCTV" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
          %Hoa hồng (NV):  
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongNV" runat="server" Width="256px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>



<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
            <asp:Button ID="btn_OK" runat="server"  Text="Lưu"  CssClass ="Button "/>

            <asp:Button ID="btn_Reset" runat="server" Text="<== Danh sách" CssClass="Button " CausesValidation ="false" />
</asp:TableCell>

</asp:TableRow>


</asp:Table>


</asp:Content>