<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Dinhmuc_GiaMathang.aspx.vb" Inherits="NANO_SPA.Dinhmuc_GiaMathang" %>


<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell ColumnSpan ="2" CssClass ="RowHeaderTable ">THAM SỐ=> Thiết lập định mức giá mặt hàng</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell  HorizontalAlign ="Left" >
    Tên sản phẩm:
    <asp:TextBox ID="txtTim_Tensanpham" Text = "Nhập tên mặt hàng ..." Width="150px" runat="server" CssClass="bigtext" AutoPostBack="true" Font-Italic="true"></asp:TextBox>
</asp:TableCell>           
<asp:TableCell Width="600px"  HorizontalAlign="Right">
      <%--  Nhóm :<asp:DropDownList ID="ddlNhommathang" runat="server" AppendDataBoundItems="True" AutoPostBack ="true">
                    <asp:ListItem Text ="Tất cả" Value ="" Selected ="True" ></asp:ListItem>
              </asp:DropDownList>--%>
                    Loại:<asp:DropDownList ID="ddlLoaiMathang" runat="server" AppendDataBoundItems="True" AutoPostBack ="true">
                    <asp:ListItem Text ="Tất cả" Value ="" Selected ="True" ></asp:ListItem>
              </asp:DropDownList>-
                    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Kho: <asp:DropDownList ID="ddlKho" runat="server" AutoPostBack ="true" Width="200px"/>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell ColumnSpan="2">

        <asp:GridView CssClass ="Grid " ID="GvGiamathang" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="uId_Dinhmuc_Giamathang" PageSize="18">
            <HeaderStyle CssClass ="GridRowHeader " />
            <RowStyle CssClass ="GridRow " />
            <Columns>
                <asp:TemplateField ItemStyle-CssClass ="GridCol " HeaderText="Mặt hàng">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nv_TenMathang_vn") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày nhập giá" ItemStyle-CssClass ="GridCol " ItemStyle-Width="100px">  
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("d_Ngay") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="f_Gianhap" HeaderText="Giá nhập" ItemStyle-CssClass ="GridCol " ItemStyle-HorizontalAlign ="Right"  ItemStyle-Width="100px" DataFormatString="{0:0,0}"/>
                <asp:BoundField DataField="f_Biendo_Gianhap" HeaderText="Biên độ giá nhập"  ItemStyle-CssClass ="GridCol " ItemStyle-HorizontalAlign ="Right" ItemStyle-Width="120px" DataFormatString="{0:0,0}"/>
                <asp:BoundField DataField="f_Giaban" HeaderText="Giá xuất" ItemStyle-CssClass ="GridCol " ItemStyle-HorizontalAlign ="Right" ItemStyle-Width="100px" DataFormatString="{0:0,0}"/>
                <asp:BoundField DataField="f_Biendo_Giaban" HeaderText="Biên độ giá xuất" ItemStyle-CssClass ="GridCol " ItemStyle-HorizontalAlign ="Right" ItemStyle-Width="120px" DataFormatString="{0:0,0}"/>
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
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass="Button "/>


</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>
