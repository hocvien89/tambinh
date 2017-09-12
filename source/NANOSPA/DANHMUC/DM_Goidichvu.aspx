<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Goidichvu.aspx.vb" Inherits="NANO_SPA.DM_Goidichvu" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%"  CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">DANH MỤC=> Gói dịch vụ</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView ID="GvGoidichvu" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Goidichvu" CssClass ="Grid " AllowSorting ="true" >
    <HeaderStyle CssClass ="GridRowHeader " />
    <RowStyle CssClass ="GridRow " />
    <Columns>
        <asp:BoundField DataField="nv_Tengoi_vn" 
            HeaderText="Tên Gói Dịch Vụ"  ItemStyle-CssClass ="GridCol " SortExpression ="nv_Tengoi_vn"/>
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