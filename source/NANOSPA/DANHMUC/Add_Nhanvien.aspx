<%@ Page Language="vb"  MasterPageFile ="~/frmMain.Master"  AutoEventWireup="false" CodeBehind="Add_Nhanvien.aspx.vb" Inherits="NANO_SPA.Add_Nhanvien" %>
<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

 <asp:Table ID="tblThemoinhanvien" runat="server"  CssClass="Table" CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell  ColumnSpan="2" CssClass="RowHeaderTable">DANH MỤC==> THÊM MỚI NHÂN VIÊN</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume" Width="40%">Mã nhân viên</asp:TableCell>
<asp:TableCell>

<asp:TextBox ID="txtManhanvien" runat="server" Width="100px" MaxLength="50"> </asp:TextBox>
<asp:RequiredFieldValidator ID="RFV_txtManhanvien" Display="Dynamic"  SetFocusOnError="true" ControlToValidate="txtManhanvien" Font-Bold="true" ErrorMessage="!Err" runat="server" ></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Họ tên</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtHoten" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume"> Ngày sinh</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="dNgaysinh" runat="server" Width="100px" MaxLength="50" ReadOnly="true"> </asp:TextBox> 
<button type="button" id="btnNgaysinh">...</button>
</asp:TableCell>
</asp:TableRow>             
                           
<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Chức vụ</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtChucvu" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Địa chỉ</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtDiachi" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Quên quán</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtQuequan" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Điện thoại</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtDienthoai" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Email</asp:TableCell>
<asp:TableCell ><asp:TextBox ID="txtEmail" runat="server" Width="300px" MaxLength="50"> </asp:TextBox>
<asp:RegularExpressionValidator ID="REV_txtEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)" ErrorMessage="!Err" ></asp:RegularExpressionValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Tên đăng nhập</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtTendangnhap" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Mật khẩu</asp:TableCell>
<asp:TableCell><asp:TextBox ID="txtMatkhau" runat="server" Width="300px" MaxLength="50"> </asp:TextBox></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Gõ lại mật khẩu</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txtMatkhau_Golai" runat="server" Width="300px" MaxLength="50"> </asp:TextBox>
<asp:CompareValidator ID="ComparePassword" runat="server" ControlToValidate ="txtMatkhau" Operator="Equal" ControlToCompare ="txtMatkhau_Golai" Text="!Err: Hai mật khẩu không trùng nhau!"></asp:CompareValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>&nbsp;</asp:TableCell>
<asp:TableCell><asp:CheckBox ID ="chkActiveLogin" runat="server" text="Kích hoạt đăng nhập"/> </asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume">Ngày vào làm</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="dNgayvaolam" runat="server" Width="100px" MaxLength="50" ReadOnly="true"> </asp:TextBox>
<button type="button" id="btnNgayvaolam">...</button>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>&nbsp;</asp:TableCell>
<asp:TableCell><asp:CheckBox ID ="chkDanglamviec" runat="server" text="Đã nghỉ"/> </asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>&nbsp;</asp:TableCell>
<asp:TableCell>&nbsp;</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>&nbsp;</asp:TableCell>
<asp:TableCell>
    <asp:Button ID="cmdLuu" Text="Lưu" runat="server" OnClick="cmdLuu_Click" CssClass="Button"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cmdThoat" Text="<== Danh sách" runat="server" OnClick="cmdThoat_Click" CssClass="Button" CausesValidation="false"/>
</asp:TableCell>
</asp:TableRow>
</asp:Table>

<script type="text/javascript">
 Calendar.setup({inputField:"ctl00_ContentPlaceHolder_Main_dNgaysinh",ifFormat:"%d/%m/%Y",showsTime:false,button:"btnNgaysinh",singleClick:true,step:1});
 Calendar.setup({inputField:"ctl00_ContentPlaceHolder_Main_dNgayvaolam",ifFormat:"%d/%m/%Y",showsTime:false,button:"btnNgayvaolam",singleClick:true,step:1});
</script> 

 </asp:Content>


