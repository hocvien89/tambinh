<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="TiGia_NgoaiTe.aspx.vb" Inherits="NANO_SPA.TiGia_NgoaiTe" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%"  CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">THAM SỐ=> Thiết lập tỷ giá ngoại tệ</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView ID="GvNgoaite" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="uId_Ngoaite" AllowPaging="True" CssClass="Grid ">
            <HeaderStyle CssClass ="GridRowHeader " />
            <RowStyle CssClass ="GridRow " />
            <Columns>
                <asp:TemplateField ItemStyle-CssClass ="GridCol " HeaderText="Mã Ngoại Tệ">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("v_Ma") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày Nhập" ItemStyle-CssClass ="GridCol ">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("d_Ngay") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="f_Tygia_VND" HeaderText="Tỉ Giá VND"  ItemStyle-CssClass ="GridCol" DataFormatString="{0:0,0}"/>
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
