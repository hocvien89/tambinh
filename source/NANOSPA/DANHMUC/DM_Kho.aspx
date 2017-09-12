<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Kho.aspx.vb" Inherits="NANO_SPA.DM_Kho" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">DANH MỤC=> Kho</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView ID="GvKho" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Kho" CssClass ="Grid ">
<HeaderStyle CssClass ="GridRowHeader " />
<RowStyle CssClass ="GridRow " />
    <Columns>
        <asp:BoundField DataField="v_Makho" ItemStyle-CssClass ="GridCol " HeaderText="Mã Kho"  ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField DataField="nv_Tenkho_vn" HeaderText="Tên Kho" ItemStyle-CssClass ="GridCol " ItemStyle-Width="300px"/>
         <asp:TemplateField ItemStyle-CssClass ="GridCol " HeaderText="Tên Cửa Hàng" SortExpression="nv_Tencuahang_vn">
            <EditItemTemplate>
                <asp:DropDownList id="ddlCuaHang" runat="server" AppendDataBoundItems="True"/>  
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nv_Tencuahang_vn") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
                           <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="Sửa" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton1" ToolTip ="Ấn để lưu thao tác" runat="server" CausesValidation="True" 
                                    CommandName="Update" ImageUrl="~/images/btn_Save.png" Text="Update" />
                                &nbsp;<asp:ImageButton ID="ImageButton2" ToolTip ="Ấn để thoát thao tác" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" ImageUrl="~/images/btn_Cancel.png" Text="Cancel" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton4" ToolTip ="Ấn để sửa thông tin" runat="server" CausesValidation="False" 
                                    CommandName="Edit" ImageUrl="~/images/btn_Edit.png" Text="Edit" />
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
</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>
