<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master"  AutoEventWireup="false" CodeBehind="Add_DM_Mathang.aspx.vb" Inherits="NANO_SPA.Add_DM_Mathang" %>
<%@ Register src="../CONTROL/txtDatepicker.ascx" tagname="txtDatepicker" tagprefix="uc1" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'width=150,height=150,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
</script>
    <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px" CssClass ="Table ">
   <asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÔNG TIN MẶT HÀNG</asp:TableHeaderCell>
</asp:TableHeaderRow>

   <asp:TableRow >
   <asp:TableCell >
   <asp:Table ID="tblMathang_Moi" runat="server" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="15%">
            Mã mặt hàng:
</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtMaMH" runat="server" 
                Width="130px" CssClass ="bigtext"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtMaMH" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
             
</asp:TableCell>
<asp:TableCell RowSpan = "3" Width="50%">
    <table >
    <tr>
    <td>
    <div id="divPrint">
    <asp:Table CssClass="Table" runat="server" ID="tblMaVach" CellPadding="2" CellSpacing="2">
        <asp:TableRow >
            <asp:TableCell HorizontalAlign="Left"  >
                <asp:Image ID="imgMaVach" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblMaVach" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>  
    </asp:Table> 
    </div>
    </td>
    <td>
    <asp:Button ID="btn_In" runat="server" Text="In Mã Vạch" CssClass="Button" OnClientClick="javascript:CallPrint('divPrint')" Visible="false" CausesValidation="false"/>
    </td>
    </tr>
    </table>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
            Mã Vạch:
</asp:TableCell>
<asp:TableCell>
    <table >
        <tr>
            <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate >
            <asp:TextBox ID="txtBarcode" runat="server" CssClass ="bigtext" Width="130px"></asp:TextBox>
            <asp:DropDownList ID="ddlBarcodeType" runat="server" AutoPostBack="true" CausesValidation="false" >
                <asp:ListItem Value="128" Text="Code 128"></asp:ListItem>
                <asp:ListItem Value="13" Text="EAN 13"></asp:ListItem>
            </asp:DropDownList>
            
            </ContentTemplate> 
            </asp:UpdatePanel> 
            </td>
            <td>
            <asp:Button ID="btnTaoMaVach" runat="server" CssClass="Button" Text="Tạo Mã Vạch" CausesValidation="false"/>
            </td>
        </tr>
    </table>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
            Tên mặt hàng:
</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtTenMH" runat="server" CssClass ="bigtext"
                Width="256px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ControlToValidate ="txtTenMH" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Đơn vị tính:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtDVT" runat="server" Width="256px" CssClass ="bigtext"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ControlToValidate ="txtDVT" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>



<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Giới hạn tồn:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHanmucTon" runat="server" Width="256px" CssClass ="bigtext"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server" ControlToValidate ="txtHanmucTon" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Loại mặt hàng: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlLoaimathang" AppendDataBoundItems ="true"  runat="server" Width="250px"/>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Nhóm mặt hàng: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlNhommathang" runat="server" AppendDataBoundItems ="true"  Width="250px"/>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>



<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Xuất xứ: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlXuatXu" runat="server" AppendDataBoundItems ="true"  Width="250px"/>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Cảnh báo hàng tồn (ngày):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtTon" runat="server" Width="256px" CssClass ="bigtext"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Cảnh báo hạn sử dụng (ngày):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHSD" runat="server" Width="256px" CssClass ="bigtext"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Ghi chú:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtGhichu" runat="server" Width="256px" CssClass ="bigtext"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Hoa hồng (KTV):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongKTV" runat="server" Width="256px" CssClass ="bigtext" onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Hoa hồng (TVV):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongTVV" runat="server" Width="256px" CssClass ="bigtext" onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Hoa hồng (CTV):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongCTV" runat="server" Width="256px" CssClass ="bigtext" onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
          Hoa hồng (NV):  
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongNV" runat="server" Width="256px" CssClass ="bigtext" onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>



<asp:TableRow > 
<asp:TableCell ColumnSpan="3"> &nbsp; </asp:TableCell>
 </asp:TableRow>
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
            <asp:Button ID="btn_OK" runat="server"  Text="Lưu"  CssClass ="Button "/>

            <asp:Button ID="btn_Reset" runat="server" Text="<== Danh sách" CssClass="Button " CausesValidation ="false" />
</asp:TableCell>
<asp:TableCell ></asp:TableCell>
</asp:TableRow>


</asp:Table>
   </asp:TableCell>
   
   
   
   
   <asp:TableCell >
   <%-- 
<asp:Table ID="tblDinhmucgia_Moi" runat="server"  CssClass ="Table " >


<asp:TableRow >
<asp:TableCell >
&nbsp;
</asp:TableCell>
</asp:TableRow>

<asp:TableRow >
<asp:TableCell >
&nbsp;
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

           Ngày nhập :

</asp:TableCell>
<asp:TableCell>
           <uc1:txtDatepicker ID="txtngay" runat="server" />
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
             Giá nhập:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtGianhap" runat="server" Width="200px" CssClass ="bigtext"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                    runat="server" ControlToValidate ="txtGianhap" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
             Biên độ giá nhập:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtBiendoGianhap" runat="server" Width="200px" CssClass ="bigtext"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
           Giá xuất:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtGiaxuat" runat="server" Width="200px" CssClass ="bigtext"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                    runat="server" ControlToValidate ="txtGiaxuat" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">
             Biên độ giá xuất:
</asp:TableCell>
<asp:TableCell>
              <asp:TextBox ID="txtBiendoGiaxuat" runat="server" Width="200px" CssClass ="bigtext"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
 
</asp:Table>
  --%> 
   </asp:TableCell>
   </asp:TableRow>
    </asp:Table>
    


</asp:Content>