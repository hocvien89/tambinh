<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" EnableEventValidation ="false"  AutoEventWireup="false" CodeBehind="DM_Tinhthanh.aspx.vb" Inherits="NANO_SPA.DM_Tinhthanh" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable ">
    DANH MỤC ==><a href="DM_Quocgia.aspx">QUỐC GIA</a>=>Tỉnh thành
</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell>

<asp:GridView ID="GvTinhthanh" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" DataKeyNames="uId_Tinhthanh" CssClass ="Grid ">
<HeaderStyle CssClass ="GridRowHeader " />
<RowStyle CssClass ="GridRow " />
    <Columns>
<asp:BoundField DataField="v_MaTinhthanh" ItemStyle-CssClass ="GridCol "   ItemStyle-Width="80px" HeaderText="Mã tỉnh"></asp:BoundField>
        <asp:BoundField DataField="nv_Tentinhthanh" HeaderText="Tỉnh thành" ItemStyle-CssClass ="GridCol " />
         <asp:TemplateField ItemStyle-CssClass ="GridCol " HeaderText="Quốc gia" SortExpression="nv_Tenquocgia">
            <EditItemTemplate>
                <asp:DropDownList id="ddlQuocgia" runat="server" AppendDataBoundItems="True"/>  
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nv_Tenquocgia") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/images/btn_Edit.png" CancelImageUrl="~/images/btn_Cancel.png" UpdateImageUrl="~/images/btn_Save.png" ItemStyle-Width="25px"/>
        <asp:TemplateField ShowHeader="False" ItemStyle-Width="25px">
            <ItemTemplate>
                <asp:ImageButton ID ="imgbtnXoa" runat="server"  CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:CommandField  ShowSelectButton ="True" HeaderText="Quận huyện" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ButtonType="Image" SelectImageUrl="~/images/btn_Detail.png" HeaderStyle-Width="80px"/>
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass ="Button " />
 &nbsp;<asp:Button ID="btn_XuatExcel" runat="server" Text="Xuất Excel" CausesValidation ="false"  CssClass="Button" />
</asp:TableCell>
</asp:TableRow>


</asp:Table>


</asp:Content>
