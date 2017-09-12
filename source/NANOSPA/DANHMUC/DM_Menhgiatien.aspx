<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DM_Menhgiatien.aspx.vb" Inherits="NANO_SPA.DM_Menhgiatien" 
   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass="RowHeaderTable ">DANH MỤC=> Mệnh giá đồng tiền</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow >
    <asp:TableCell HorizontalAlign="Right">
        <asp:DropDownList id="ddlNgoaite" runat="server" AppendDataBoundItems="True" Width="200px" AutoPostBack="true">  
            <asp:ListItem Text="Tất cả" Value=""></asp:ListItem>
        </asp:DropDownList> 
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell>
<asp:GridView ID="GvMenhGia" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Menhgiatien" CssClass ="Grid" PageSize="18">
    <HeaderStyle CssClass ="GridRowHeader " />
    <RowStyle CssClass ="GridRow " />
    <Columns>
        <%--<asp:BoundField DataField="v_Ma" HeaderText="Loại tiền" ItemStyle-CssClass ="GridCol "></asp:BoundField>--%>
        <asp:TemplateField HeaderText="Loại tiền" ItemStyle-CssClass ="GridCol " HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Center">
            <EditItemTemplate>
                <asp:DropDownList id="ddlNgoaite" runat="server" AppendDataBoundItems="True"/>  
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("v_Ma") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="f_Menhgia" HeaderText="Mệnh giá" ItemStyle-CssClass ="GridCol" DataFormatString="{0:0,0}" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
         <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="Chi tiết" ShowHeader="False" ItemStyle-CssClass ="GridCol ">
                            <ItemTemplate>
                                <asp:ImageButton ToolTip="Ấn để xem chi tiết" ID="ImageButton3" runat="server" CausesValidation="False" 
                                    CommandName="Select" ImageUrl="~/images/btn_Detail.png" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
        <%--<asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/images/btn_Edit.png" CancelImageUrl="~/images/btn_Cancel.png" UpdateImageUrl="~/images/btn_Save.png" ItemStyle-Width="25px"/>--%>
   <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  ShowHeader="False" HeaderText="Xóa"  ItemStyle-Width ="20px">
     <ItemTemplate>
     <asp:ImageButton ID ="imgbtnXoa" runat="server" ToolTip="Ấn để xóa thông tin" CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
     </ItemTemplate>
    </asp:TemplateField>  
    </Columns>
</asp:GridView>


<br />
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới"  CssClass ="Button " />
 &nbsp;<asp:Button ID="btn_XuatExcel" runat="server" Text="Xuất Excel" CausesValidation ="false"  CssClass="Button" />
</asp:TableCell>
</asp:TableRow>


</asp:Table>

</asp:Content>
