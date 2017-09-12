<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master"  AutoEventWireup="false" CodeBehind="DM_Nhomthamdo.aspx.vb" Inherits="NANO_SPA.DM_Nhomthamdo" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass="RowHeaderTable ">DANH MỤC=> Nhóm thăm dò</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView ID="GvNhomthamdo" runat="server" CssClass ="Grid " AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_NhomThamdo">
    <HeaderStyle CssClass ="GridRowHeader " />
    <RowStyle CssClass ="GridRow " />
    <Columns>
        <asp:BoundField ItemStyle-CssClass ="GridCol " DataField="nv_TennhomThamdo_vn" 
            HeaderText="Tên Nhóm Thăm Dò" />
        <asp:CommandField ShowEditButton="True"  ItemStyle-CssClass ="GridCol " ButtonType="Image" EditImageUrl="~/images/btn_Edit.png" CancelImageUrl="~/images/btn_Cancel.png" UpdateImageUrl="~/images/btn_Save.png"/>
         <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
     <asp:ImageButton ID ="imgbtnXoa" runat="server"  CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
     </ItemTemplate>
    </asp:TemplateField> 
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới"  CssClass ="Button "/>

</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>
