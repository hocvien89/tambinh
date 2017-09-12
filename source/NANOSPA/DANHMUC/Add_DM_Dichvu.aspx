<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master" AutoEventWireup="false" CodeBehind="Add_DM_Dichvu.aspx.vb" Inherits="NANO_SPA.Add_DM_Dichvu" %>

<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="table1" runat="server" Width="100%" HorizontalAlign ="Center"  CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2" >DANH MỤC==> THÊM MỚI DỊCH VỤ</asp:TableHeaderCell>
</asp:TableHeaderRow>

</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 40%; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >

<%--<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">
            Gói dịch vụ:
</asp:TableCell>
<asp:TableCell >
              <asp:CheckBox ID="chkGoiDV" runat="server" />
 </asp:TableCell>
</asp:TableRow>--%>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">
            Tên dịch vụ:
</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtTendichvu" runat="server" CssClass ="bigtext "
                Width="256px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate ="txtTendichvu" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Tên nhóm dịch vụ: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlNhomdichvu" AppendDataBoundItems ="true"  runat="server" Width="200px"/>
            
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Mã ngoại tệ: 
</asp:TableCell>
<asp:TableCell >
            <asp:DropDownList ID="ddlMangoaite" runat="server" AppendDataBoundItems ="true"  Width="200px"/>
            
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Giá:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtGia" runat="server" Width="256px" onkeyup="javascript:ThousandSeparate(this)" CssClass ="bigtext "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                   ControlToValidate="txtGia" runat="server" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>



<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            % Giảm giá:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtPhidichvu" runat="server" Width="256px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Số lần điều trị:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtSolandieutri" runat="server" Width="256px" CssClass ="bigtext "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server" ControlToValidate ="txtSolandieutri" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Thời gian chuẩn bị (phút):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtChuanbi" runat="server" Width="256px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            Thời gian thực hiện (phút):         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtThuchien" runat="server" Width="256px" CssClass ="bigtext "></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">
            Tính thuế:
</asp:TableCell>
<asp:TableCell >
              <asp:CheckBox ID="CkThue" runat="server" />
 </asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass="AlignLableColume ">
            Tính hoa hồng:
</asp:TableCell>
<asp:TableCell >
              <asp:CheckBox ID="CkHoahong" runat="server" />
 </asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            HH tư vấn bán:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongKTV" runat="server" Width="256px" CssClass ="bigtext " onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            HH KTV Chính:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongTVV" runat="server" Width="256px" CssClass ="bigtext " onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
          HH KTV phụ:  
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongNV" runat="server" Width="256px" CssClass ="bigtext " onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " >
            HH khác:         
</asp:TableCell>
<asp:TableCell >
            <asp:TextBox ID="txtHoahongCTV" runat="server" Width="256px" CssClass ="bigtext " onkeyup="javascript:ThousandSeparate(this)"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
<asp:TableRow>
<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
            <asp:Button ID="btn_OK" runat="server"  Text="Lưu"  CssClass ="Button "/>

            <asp:Button ID="btn_Reset" runat="server" Text="<== Danh sách" CssClass="Button " CausesValidation ="false" />
</asp:TableCell>

</asp:TableRow>


</asp:Table>
</div>
</div>

</asp:Content>
