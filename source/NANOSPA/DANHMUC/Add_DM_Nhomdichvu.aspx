<%@ Page Language="vb" MasterPageFile ="~/frmMain.Master"  AutoEventWireup="false" CodeBehind="Add_DM_Nhomdichvu.aspx.vb" Inherits="NANO_SPA.Add_DM_Nhomdichvu" %>
<%@Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor"%>


<asp:Content ID="Content_Default" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
<asp:Table ID="Table1" runat="server" Width="100%" CssClass ="Table " CellPadding="0" CellSpacing="0" BorderWidth="0px">

<asp:TableHeaderRow>
<asp:TableHeaderCell CssClass ="RowHeaderTable " ColumnSpan ="2">DANH MỤC==> THÊM MỚI NHÓM DỊCH VỤ</asp:TableHeaderCell>
</asp:TableHeaderRow>
</asp:Table>

<div align="center" style="padding: 30px 0px">
<div  style="width: 500px; -moz-border-radius: 5px; -webkit-border-radius: 5px; border: 1px solid #CCCCCC; padding: 1px;">
<asp:Table ID="tblBatdongsan_Moi" Width="100%" runat ="server" >
<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume " Width="40%">

            Tên nhóm dịch vụ:

</asp:TableCell>
<asp:TableCell>
            <asp:TextBox ID="txtTenNhomdichvu" runat="server" Width="350px" CssClass ="bigtext "></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ControlToValidate ="txtTenNhomdichvu" ErrorMessage="Err!!"></asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell CssClass ="AlignLableColume ">

            Tên cửa hàng:

</asp:TableCell>
<asp:TableCell>
            <asp:DropDownList ID="ddlCuaHang" runat="server" Width="181px" 
                AppendDataBoundItems="True">
            </asp:DropDownList>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow Visible="false" >
<asp:TableCell CssClass ="AlignLableColume ">

            Chi tiết 1 (mặc định):

</asp:TableCell>
<asp:TableCell>
         
</asp:TableCell>
</asp:TableRow>

<asp:TableRow Visible="false">
<asp:TableCell ColumnSpan ="2" CssClass ="AlignLableColume ">
       <CKEditor:CKEditorControl ID="CKENoidung" Height="250px" Width ="99%" BasePath="~/ckeditor" Toolbar ="Full" FilebrowserImageBrowseUrl="../ckfinder/ckfinder.html?type=Images" FilebrowserImageUploadUrl ="../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images" runat="server" ></CKEditor:CKEditorControl>   
         
</asp:TableCell>
</asp:TableRow>

<asp:TableRow Visible="false">
<asp:TableCell CssClass ="AlignLableColume ">

            Chi tiết 2:

</asp:TableCell>
<asp:TableCell>
         
</asp:TableCell>
</asp:TableRow>

<asp:TableRow Visible="false">
<asp:TableCell ColumnSpan ="2" CssClass ="AlignLableColume ">
       <CKEditor:CKEditorControl ID="CKENoidungPhu" Height="250px" Width ="99%" BasePath="~/ckeditor" Toolbar ="Full" FilebrowserImageBrowseUrl="../ckfinder/ckfinder.html?type=Images" FilebrowserImageUploadUrl ="../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images" runat="server" ></CKEditor:CKEditorControl>   
         
</asp:TableCell>
</asp:TableRow>

<asp:TableRow > 
<asp:TableCell > &nbsp; </asp:TableCell>
 </asp:TableRow>
 
<asp:TableRow>

<asp:TableCell > &nbsp; </asp:TableCell>
<asp:TableCell >
             <asp:Button ID="btn_ok" runat="server" Text="Lưu" CssClass="Button "/>
           <asp:Button ID="btn_Reset" runat="server" Text="<== Danh sách" CssClass="Button " CausesValidation ="false" />
</asp:TableCell>
</asp:TableRow> 

</asp:Table>
</div>
</div>

</asp:Content>
