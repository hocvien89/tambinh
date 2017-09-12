<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DM_Danhgia.aspx.vb" Inherits="NANO_SPA.DM_Danhgia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
<script language="javascript" type="text/javascript"> 
    function selectAll(obj1, obj2) {
            var checkboxIds = new String();
            checkboxIds = obj1;

            var arrIds = new Array();
            arrIds = checkboxIds.split('|');

            for (var i = 0; i < arrIds.length; i++) {
                document.getElementById(arrIds[i]).checked = obj2.checked;
            }
        }
    </script>
<table width="100%" cellspacing="3">
    <tr>
        <td colspan="2"><asp:Label ID="lblheader" runat="server" CssClass="RowHeaderTable" Width="99.2%" Font-Bold="true" > DANH MỤC==> DANH MỤC ĐÁNH GIÁ</asp:Label></td>
    </tr>
    <tr>
        <td align="right" style="width:70px">Câu hỏi :</td>
        <td><asp:TextBox ID="txtCauhoi" runat="server"  Width="300px" CssClass ="bigtext "></asp:TextBox>        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCauhoi"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
        <asp:Button ID="btnLammoi" runat="server" Text="Nhập mới"  CssClass="Button" CausesValidation="false"/>
            <asp:Button ID="btnLuu" runat="server" Text="Lưu"  CssClass="Button" Width="70px"/>            
        </td>
    </tr>
    <tr>
        <td colspan="2"><hr /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GvDanhgia" runat="server" AutoGenerateColumns="False"  
                    DataKeyNames="uId_Danhgia" CssClass ="Grid " AllowPaging ="true" PageSize ="14" Width="100%" >
                    <HeaderStyle CssClass="GridRowHeader "/>
                    <RowStyle CssClass="GridRow "/>
                    <Columns>         
                        <asp:TemplateField ItemStyle-CssClass ="GridCol " ItemStyle-Width="15px">
                            <HeaderTemplate>  
                                <asp:CheckBox ID="chkSelectAll"   
                                    runat="server"   
                                    Text="" />  
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkChon" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>     
                        <asp:TemplateField ItemStyle-CssClass ="GridCol " ItemStyle-Width="30px" HeaderText="STT" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>          
                        <asp:BoundField DataField="nv_Cauhoi_vn" HeaderText="Câu hỏi đánh giá"  ItemStyle-CssClass ="GridCol "/>
                       
                      <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  HeaderText="Chi tiết" ShowHeader="False" ItemStyle-CssClass ="GridCol ">
                            <ItemTemplate>
                                <asp:ImageButton ToolTip="Ấn để xem chi tiết" ID="ImageButton3" runat="server" CausesValidation="False" 
                                    CommandName="Select" ImageUrl="~/images/btn_Detail.png" Text="Chọn" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
	
                     <asp:TemplateField ItemStyle-HorizontalAlign ="Center"  ShowHeader="False" HeaderText="Xóa"  ItemStyle-Width ="20px">
     <ItemTemplate>
     <asp:ImageButton ID ="imgbtnXoa" runat="server" ToolTip="Ấn để xóa thông tin" CausesValidation="False" CommandName="Delete" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");' ImageUrl ="/images/btn_Delete.png" />
     </ItemTemplate>
    </asp:TemplateField>                    
                    </Columns> 
             </asp:GridView> 
        </td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnXoa" runat="server" Text="Xóa"  CssClass="Button" CausesValidation="false" OnClientClick ='return confirm("Bạn chắc chắn muốn xóa không?");'/></td>
    </tr>
</table>
</asp:Content>
