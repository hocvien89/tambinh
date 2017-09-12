<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DS_Mathang.aspx.vb" Inherits="NANO_SPA.DS_Mathang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Danh sách mặt hàng</title>
     <link type="text/css" rel="stylesheet" href="../Css/CssMain.css"/>
    <script language="JavaScript" type="text/javascript" src="../Js/jsc_Outlook.js"></script>
    <link type="text/css" rel="stylesheet" href="../aqua/theme.css" />    
    <script type="text/javascript" src="../Js/calendar.js"></script>
    <script type="text/javascript" src="../Js/calendar-vn.js"></script>
    <script type="text/javascript" src="../Js/calendar-setup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblDSMathang" runat="server" Width="100%">
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            Loại :    <asp:DropDownList Width="150px" ID="ddlLoaimathang" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Text ="Tất cả" Value ="0" Selected ="True" ></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>

        <asp:TableCell HorizontalAlign="Right">
           Nhóm :<asp:DropDownList ID="ddlNhommathang" Width="150px"  runat="server" AppendDataBoundItems="True">
            <asp:ListItem Text ="Tất cả" Value ="0" Selected ="True" ></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell Width="300px">
            Tên mặt hàng:<asp:TextBox ID="txtTenMH" runat="server" Width="150px" CssClass="bigtext"></asp:TextBox>
            <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" CssClass="Button"/>
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
           <asp:TableCell ColumnSpan="3">
        <asp:GridView ID="Gv_Mathang" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="uId_Mathang" CssClass ="Grid">
            <RowStyle CssClass ="GridRow " />
            <HeaderStyle CssClass ="GridRowHeader " />
            <Columns>
                <asp:BoundField DataField="v_MaMathang" HeaderText="Mã mặt hàng" ItemStyle-CssClass ="GridCol " ItemStyle-Width="100px"/>
                <asp:BoundField DataField="nv_TenMathang_vn" HeaderText="Tên mặt hàng" ItemStyle-CssClass ="GridCol "/>
                <asp:BoundField DataField="nv_DVT_vn" HeaderText="ĐVT" ItemStyle-CssClass ="GridCol " ItemStyle-Width="60px"/>
                <asp:BoundField DataField="nv_Ghichu_vn" HeaderText="Ghi chú" ItemStyle-CssClass ="GridCol "/>
                <asp:CommandField ShowSelectButton="True" ButtonType ="Image" SelectImageUrl="~/images/btn_Detail.png" ItemStyle-Width="20px"/>
            </Columns>
        </asp:GridView>
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
