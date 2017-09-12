<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Add_DM_Dichvu_Congdoan.aspx.vb"
    Inherits="NANO_SPA.Add_DM_Dichvu_Congdoan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thiết lập công đoạn</title>
    <link type="text/css" rel="stylesheet" href="../Css/CssMain.css" />

    <script language="JavaScript" type="text/javascript" src="../Js/jsc_Outlook.js"></script>

    <link type="text/css" rel="stylesheet" href="../aqua/theme.css" />

    <script type="text/javascript" src="../Js/calendar.js"></script>

    <script type="text/javascript" src="../Js/calendar-vn.js"></script>

    <script type="text/javascript" src="../Js/calendar-setup.js"></script>

    <script>
        function ThousandSeparate()
        {
            if (arguments.length == 1)
            {
                var V = arguments[0].value;
                V = V.replace(/,/g,'');
                var R = new RegExp('(-?[0-9]+)([0-9]{3})'); 
                while(R.test(V))
                {
                    V = V.replace(R, '$1,$2');
                }
                arguments[0].value = V;
            }
            else  if ( arguments.length == 2)
            {
                var V = document.getElementById(arguments[0]).value;
                var R = new RegExp('(-?[0-9]+)([0-9]{3})'); 
                while(R.test(V))
                {
                    V = V.replace(R, '$1,$2');
                }
                document.getElementById(arguments[1]).innerHTML = V;
            }
            else return false;
        }   
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Table ID="tblThemoithe" runat="server" CssClass="Table ">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" CssClass="RowHeaderTable ">DANH SÁCH NHÂN VIÊN PHỤ</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell CssClass="AlignLableColume">
            Tên dịch vụ:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTendichvu" Enabled="false" Width="200px" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="AlignLableColume">
            Công đoạn:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTenCongdoan" runat="server" CssClass="bigtext " Width="200px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="AlignLableColume">
            Tiền hoa hồng:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTienHH" onkeyup="ThousandSeparate(this)" runat="server" CssClass="bigtext "
                    Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTienHH"
                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="AlignLableColume">
            Ghi chú:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtGhichu" runat="server" CssClass="bigtext " Width="200px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="AlignLableColume"></asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnLuu" runat="server" CssClass="Button" Text="Lưu" />
                <asp:Button ID="btnLuuDong" runat="server" CssClass="Button" Text="Đóng" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Literal ID="lblError" runat="server"></asp:Literal>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:GridView ID="GVCongdoan" runat="server" AutoGenerateColumns="False" CssClass="Grid "
                    AllowPaging="True" DataKeyNames="uId_Congdoan,uId_Dichvu">
                    <HeaderStyle CssClass="GridRowHeader " />
                    <RowStyle CssClass="GridRow " HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundField DataField="nv_Tencongdoan_vn" ItemStyle-HorizontalAlign="Center"
                            ItemStyle-Width="100px" HeaderText="Công đoạn" ItemStyle-CssClass="GridCol " />
                        <asp:TemplateField HeaderText="Tiền hoa hồng" ItemStyle-CssClass="GridCol " ItemStyle-Width="70px"
                            ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("f_TienHH", "{0:0,0}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTienHH" Width="80px" Text='<%# Eval("f_TienHH", "{0:0,0}") %>'
                                    runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiền hoa hồng" ItemStyle-CssClass="GridCol " ItemStyle-Width="70px"
                            ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("nv_Ghichu") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGhichu" Width="80px" Text='<%# Eval("nv_Ghichu") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sửa" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton1" ToolTip="Ấn để lưu thao tác" runat="server" CausesValidation="False"
                                    CommandName="Update" ImageUrl="~/images/btn_Save.png" Text="Update" />
                                &nbsp;<asp:ImageButton ID="ImageButton2" ToolTip="Ấn để thoát thao tác" runat="server"
                                    CausesValidation="False" CommandName="Cancel" ImageUrl="~/images/btn_Cancel.png"
                                    Text="Cancel" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" ToolTip="Ấn để sửa thông tin" runat="server" CausesValidation="False"
                                    CommandName="Edit" ImageUrl="~/images/btn_Edit.png" Text="Edit" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ShowHeader="False" HeaderText="Xóa"
                            ItemStyle-Width="10px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnXoa" runat="server" ToolTip="Ấn để xóa" CausesValidation="False"
                                    CommandName="Delete" OnClientClick='return confirm("Bạn chắc chắn muốn xóa không?");'
                                    ImageUrl="/images/btn_Delete.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
