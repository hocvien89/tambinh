<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Cuahang.aspx.vb" Inherits="NANO_SPA.DM_Cuahang" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblCuahang" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass="RowHeaderTable">QUẢN TRỊ=> Danh mục cửa hàng</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell HorizontalAlign="Center">

<asp:GridView ID="GvCuahang" runat="server" 
    AutoGenerateColumns="False" TabIndex="1" DataKeyNames = "uId_Cuahang" AllowSorting ="true"  AllowPaging="True" PageSize="14" CssClass="Grid">
    <HeaderStyle CssClass="GridRowHeader"/>   
    <RowStyle CssClass="GridRow"/>
    
    <Columns>
        <asp:BoundField DataField="v_Macuahang" HeaderText="Mã" ItemStyle-CssClass="GridCol"  SortExpression ="v_Macuahang"  ItemStyle-Width="80px" ReadOnly="true"/>
        <asp:BoundField DataField="nv_Tencuahang_vn" HeaderText="Tên cửa hàng" ItemStyle-CssClass="GridCol" SortExpression ="nv_Tencuahang_vn" />
        <asp:BoundField DataField="nv_Diachi_vn" HeaderText="Địa chỉ cửa hàng" ItemStyle-CssClass="GridCol" />
        <asp:CheckBoxField DataField="b_Active" HeaderText="Hoạt động" ItemStyle-CssClass="GridCol" ItemStyle-Width="100px"/>
        
                      <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="CT" ShowHeader="False" ItemStyle-CssClass ="GridCol ">
                            <ItemTemplate>
                                <asp:ImageButton ToolTip="Ấn để xem chi tiết" ID="ImageButton4" runat="server" CausesValidation="False" 
                                    CommandName="Select" ImageUrl="~/images/btn_Detail.png" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                            
                            <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="Sửa" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton1" ToolTip ="Ấn để lưu thao tác" runat="server" CausesValidation="True" 
                                    CommandName="Update" ImageUrl="~/images/btn_Save.png" Text="Update" />
                                &nbsp;<asp:ImageButton ID="ImageButton2" ToolTip ="Ấn để thoát thao tác" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" ImageUrl="~/images/btn_Cancel.png" Text="Cancel" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" ToolTip ="Ấn để sửa thông tin" runat="server" CausesValidation="False" 
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

</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
     &nbsp;
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
     <asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass="Button"  />
     &nbsp;<asp:Button ID="btn_XuatExcel" runat="server" Text="Xuất Excel" CausesValidation ="false"  CssClass="Button" />
</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>
<%--ItemStyle-HorizontalAlign="Center" ItemStyle-BorderStyle="Inset" ItemStyle-BorderWidth="1px"--%>