<%@ Page Language="vb" MasterPageFile="~/frmMain.Master" EnableEventValidation="false"
    AutoEventWireup="false" CodeBehind="DM_Dichvu.aspx.vb" Inherits="NANO_SPA.DM_Dichvu" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main"
    runat="Server">
    <asp:Table ID="tblBatdongsan_Moi" runat="server" Width="100%" CssClass="Table " CellPadding="0"
        CellSpacing="0" BorderWidth="0px">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="RowHeaderTable ">DANH MỤC=> Dịch vụ</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Chọn nhóm dịch vụ:
                <asp:DropDownList ID="ddlNhomdichvu" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    Width="300px">
                    <asp:ListItem Value="" Text="Tất cả" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView CssClass="Grid " ID="GvDichvu" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" DataKeyNames="uId_Dichvu" OnRowCommand="GridView1_RowCommand" AllowSorting="true" PageSize="18">
                    <HeaderStyle CssClass="GridRowHeader " />
                    <RowStyle CssClass="GridRow " />
                    <Columns>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nv_Tendichvu_vn" ItemStyle-CssClass="GridCol " HeaderText="Dịch Vụ"
                            SortExpression="nv_Tendichvu_vn" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:TemplateField HeaderText="Nhóm Dịch Vụ" ItemStyle-CssClass="GridCol " SortExpression="nv_TennhomDichvu_vn"
                            ItemStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlNhomdichvu" runat="server" AppendDataBoundItems="True" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("nv_TennhomDichvu_vn") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NT" ItemStyle-CssClass="GridCol " SortExpression="v_Ma"
                            ItemStyle-Width="20px">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlNgoaite" runat="server" AppendDataBoundItems="True" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("v_Ma") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="f_Gia" HeaderText="Giá" ItemStyle-CssClass="GridCol "
                            SortExpression="f_Gia" DataFormatString="{0:0,0}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="f_Phidichvu" HeaderText="%Giảm" SortExpression="f_Phidichvu"
                            ItemStyle-CssClass="GridCol " ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="i_Solan_Dieutri" HeaderText="Slần" ItemStyle-CssClass="GridCol "
                            SortExpression="i_Solan_Dieutri" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="f_Sophutchuanbi" HeaderText="C.bị" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="f_Sophutthuchien" HeaderText="T.hiện" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:CheckBoxField DataField="b_Tinhthue" HeaderText="Thuế" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:CheckBoxField DataField="b_TinhHoahong" HeaderText="HH" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="f_PhantramHH_KTV" HeaderText="Tư vấn" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0,0}" />
                        <asp:BoundField DataField="f_PhantramHH_TVV" HeaderText="KTV chính" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0,0}" />
                        <asp:BoundField DataField="f_PhantramHH_NV" HeaderText="KTV Phụ" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0,0}" />
                        <asp:BoundField DataField="f_PhantramHH_CTV" HeaderText="HH khác" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0,0}" />
                        <asp:CheckBoxField DataField="b_Goidichvu" HeaderText="Gói" ItemStyle-CssClass="GridCol "
                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="14px" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="CT" ShowHeader="False"
                            ItemStyle-CssClass="GridCol ">
                            <ItemTemplate>
                                <asp:ImageButton ToolTip="Ấn để xem chi tiết" ID="ImageButton3" runat="server" CausesValidation="False"
                                    CommandName="Select" ImageUrl="~/images/btn_Detail.png" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="CĐ" ShowHeader="False"
                            ItemStyle-CssClass="GridCol ">
                            <ItemTemplate>
                                <asp:ImageButton CommandName="Congdoan" CommandArgument='<%#Eval("uId_Dichvu") %>' ToolTip="Ấn để thiết lập công đoạn" ID="ImageButton4" runat="server" CausesValidation="False"
                                    ImageUrl="~/images/btn_Permision.png" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ShowHeader="False" HeaderText="Xóa"
                            ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnXoa" runat="server" ToolTip="Ấn để xóa thông tin" CausesValidation="False"
                                    CommandName="Delete" OnClientClick='return confirm("Bạn chắc chắn muốn xóa không?");'
                                    ImageUrl="/images/btn_Delete.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="btn_Them" runat="server" Text="Nhập mới" CssClass="Button " />
                &nbsp;<asp:Button ID="btn_XuatExcel" runat="server" Text="Xuất Excel" CausesValidation="false"
                    CssClass="Button" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
