<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Mathang.aspx.vb" Inherits="NANO_SPA.DM_Mathang" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell ColumnSpan="3" CssClass ="RowHeaderTable ">DANH MỤC=> Mặt hàng</asp:TableHeaderCell>
</asp:TableHeaderRow>
<asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            Loại :    <asp:DropDownList Width="150px" ID="ddlLoaimathang" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Text ="Tất cả" Value ="0" Selected ="True" ></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>

        <asp:TableCell HorizontalAlign="Right" Width="300px">
           Nhóm :<asp:DropDownList ID="ddlNhommathang" Width="150px"  runat="server" AppendDataBoundItems="True">
            <asp:ListItem Text ="Tất cả" Value ="0" Selected ="True" ></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell Width="320px">
            Tên mặt hàng:<asp:TextBox ID="txtTenMH" runat="server" Width="150px" CssClass="bigtext"></asp:TextBox>
            <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" CssClass="Button"/>
        </asp:TableCell>
        </asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="3">

<asp:GridView CssClass ="Grid " ID="GvMathang" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Mathang" AllowSorting ="true" PageSize ="18">
    <HeaderStyle CssClass ="GridRowHeader " />
    <RowStyle CssClass ="GridRow " />
    <Columns>
        <asp:BoundField DataField="v_MaMathang" HeaderText="Mã MH" ItemStyle-CssClass ="GridCol " SortExpression ="v_MaMathang"  ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField DataField="v_MaBarcode" HeaderText="Mã Vạch" ItemStyle-CssClass ="GridCol " SortExpression ="v_MaBarcode"  ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField DataField="nv_TenMathang_vn" HeaderText="Tên Mặt Hàng" ItemStyle-CssClass ="GridCol " SortExpression ="nv_TenMathang_vn"/>
        <asp:BoundField DataField="nv_DVT_vn" HeaderText="ĐVT" ItemStyle-CssClass ="GridCol "  ItemStyle-HorizontalAlign="Center"/>
        <asp:BoundField HeaderText="Giới hạn tồn" DataField="f_Hanmuc_Ton" ItemStyle-CssClass ="GridCol" ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Center"/>
        <asp:BoundField DataField="i_Songaycanhbao_Ton" HeaderText="Cảnh báo(tồn)" ItemStyle-CssClass ="GridCol "  ItemStyle-Width="30px"  ItemStyle-HorizontalAlign="Center"/>
        <asp:BoundField DataField="i_Songaycanhbao_HethanSD" 
            HeaderText="Cảnh báo(HSD)" ItemStyle-CssClass ="GridCol "  ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"/>
        <asp:BoundField HeaderText="Ghi Chú" DataField="nv_Ghichu_vn" ItemStyle-CssClass ="GridCol "/>
        <asp:BoundField DataField="nv_Tennhommathang_vn" HeaderText="Nhóm MH" ItemStyle-CssClass ="GridCol " SortExpression ="nv_Tennhommathang_vn"/>
        <asp:BoundField DataField="nv_Tenloaimathang_vn" HeaderText="Loại MH" ItemStyle-CssClass ="GridCol " SortExpression ="nv_Tenloaimathang_vn"/>
        <asp:BoundField DataField="nv_Tenxuatxu_vn" HeaderText="Xuất Xứ" ItemStyle-CssClass ="GridCol " SortExpression="nv_Tenxuatxu_vn"  ItemStyle-HorizontalAlign="Center"/> 
         <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="CT" ShowHeader="False" ItemStyle-CssClass ="GridCol ">
                            <ItemTemplate>
                                <asp:ImageButton ToolTip="Ấn để xem chi tiết" ID="ImageButton3" runat="server" CausesValidation="False" 
                                    CommandName="Select" ImageUrl="~/images/btn_Detail.png" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                     <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  ShowHeader="False" HeaderText="Xóa"  ItemStyle-Width ="20px">
     <ItemTemplate>
     <asp:ImageButton ID ="imgbtnXoa" runat="server" ToolTip="Ấn để xóa thông tin" CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
     </ItemTemplate>
    </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass ="Button " />
  &nbsp;<asp:Button ID="btn_XuatExcel" runat="server" Text="Xuất Excel" CausesValidation ="false"  CssClass="Button" />
<asp:Button ID="btnTaoMaVach" runat="server" Text="Tạo mã vạch" CausesValidation ="false"  CssClass="Button" />
</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>
