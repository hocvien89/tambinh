<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Xaphuong.aspx.vb" Inherits="NANO_SPA.DM_Xaphuong" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">
DANH MỤC=> <a href="DM_Quocgia.aspx" >Quốc gia</a>=><a href="DM_Quocgia.aspx" >Tỉnh thành</a>=><a href="DM_Quanhuyen.aspx" >Quận huyện</a>=>Xã phường</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView ID="GvXaphuong" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Xaphuong" CssClass ="Grid ">
<HeaderStyle CssClass ="GridRowHeader " />
<RowStyle CssClass ="GridRow " />
    <Columns>
<asp:BoundField DataField="v_MaXaphuong" ItemStyle-CssClass ="GridCol " HeaderText="Mã xã, phường"   ItemStyle-Width="120px" ></asp:BoundField>
        <asp:BoundField DataField="nv_TenXaphuong" HeaderText="Xã, Phường" ItemStyle-CssClass ="GridCol " />
         <asp:TemplateField ItemStyle-CssClass ="GridCol " HeaderText="Quốc gia" SortExpression="nv_Tenquocgia">
            <EditItemTemplate>
                <asp:DropDownList id="ddlQuanhuyen" runat="server" AppendDataBoundItems="True"/>  
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nv_TenQuanhuyen") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/images/btn_Edit.png" CancelImageUrl="~/images/btn_Cancel.png" UpdateImageUrl="~/images/btn_Save.png" ItemStyle-Width="25px"/>
        <asp:TemplateField ShowHeader="False" ItemStyle-Width="25px">
            <ItemTemplate>
                <asp:ImageButton ID ="imgbtnXoa" runat="server"  CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
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
