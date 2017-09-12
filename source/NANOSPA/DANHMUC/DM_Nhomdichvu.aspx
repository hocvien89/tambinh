<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Nhomdichvu.aspx.vb" Inherits="NANO_SPA.DM_Nhomdichvu" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">DANH MỤC=> Nhóm dịch vụ</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView CssClass ="Grid " ID="GvNhomdichvu" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Nhomdichvu" AllowSorting ="true" PageSize="15" >
    <HeaderStyle CssClass ="GridRowHeader " />
    <RowStyle CssClass ="GridRow " />
    <Columns>
<asp:BoundField DataField="nv_TennhomDichvu_vn" ItemStyle-CssClass ="GridCol " HeaderText="Tên Nhóm Dịch Vụ" SortExpression ="nv_TennhomDichvu_vn"></asp:BoundField>
         <asp:TemplateField ItemStyle-CssClass ="GridCol " HeaderText="Tên Cửa Hàng" SortExpression="nv_Tencuahang_vn">
            <EditItemTemplate>
                <asp:DropDownList id="ddlCuaHang" runat="server" AppendDataBoundItems="True"/>  
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nv_Tencuahang_vn") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         
                      <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="Chi tiết" ShowHeader="False" ItemStyle-CssClass ="GridCol ">
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
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass="Button " />
  &nbsp;<asp:Button ID="btn_XuatExcel" runat="server" Text="Xuất Excel" CausesValidation ="false"  CssClass="Button" />
</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>