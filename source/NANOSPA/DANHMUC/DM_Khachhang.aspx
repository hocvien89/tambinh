<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" AutoEventWireup="false" CodeBehind="DM_Khachhang.aspx.vb" Inherits="NANO_SPA.DM_Khachhang" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">DANH MỤC=> Khách hàng</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView CssClass ="Grid " ID="GvKhachhang" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Khachhang">
    <HeaderStyle CssClass ="GridRowHeader " />
    <RowStyle CssClass ="GridRow " />
    <Columns>
<asp:BoundField DataField="v_Makhachang" ItemStyle-CssClass="GridCol "  HeaderText="Mã "></asp:BoundField>
        <asp:BoundField DataField="nv_Hoten_vn" ItemStyle-CssClass ="GridCol " HeaderText="Họ Tên" />
        <asp:BoundField DataField="d_Ngaysinh" HeaderText="Ngày Sinh" ItemStyle-CssClass ="GridCol " />
        <asp:TemplateField HeaderText="Giới Tính" ItemStyle-CssClass ="GridCol ">
            <EditItemTemplate>
                 <asp:DropDownList ID="ddlGioitinh" runat="server">
                <asp:ListItem Value="1">Nam</asp:ListItem>
                <asp:ListItem Value="0">Nữ</asp:ListItem>
            </asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label Text='<%# DisplayByValue(Eval("b_Gioitinh"))%>'  ID="Label1"  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="nv_Diachi_vn" HeaderText="Địa chỉ" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField DataField="nv_Nguyenquan_vn" HeaderText="Nguyên Quán" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField DataField="v_DienthoaiDD" HeaderText="Điện Thoại DĐ" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField DataField="v_Dienthoaikhac" HeaderText="Điên Thoại Khác" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField HeaderText="Email" DataField="v_Email" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField DataField="i_SoCMT" HeaderText="Số CMT" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField DataField="d_NgaycapCMT" HeaderText="Ngày Cấp CMT" ItemStyle-CssClass ="GridCol " />
        <asp:BoundField HeaderText="Nơi Cấp" DataField="nv_Noicap_vn" ItemStyle-CssClass ="GridCol " />
        <asp:TemplateField HeaderText="Ngày Đến">
            <EditItemTemplate>
                <asp:Calendar  ID="cldNgayden" runat="server" SelectedDate ='<%# Eval("d_Ngayden") %>'></asp:Calendar>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("d_Ngayden") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/images/btn_Edit.png" CancelImageUrl="~/images/btn_Cancel.png" UpdateImageUrl="~/images/btn_Save.png" />
         <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
     <asp:ImageButton ID ="imgbtnXoa" runat="server"  CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
     </ItemTemplate>
    </asp:TemplateField> 
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass ="Button " />

</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>