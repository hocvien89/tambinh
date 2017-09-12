<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DS_SPBarcode.aspx.vb" Inherits="NANO_SPA.DS_SPBarcode" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
<script type="text/javascript">  
  
function selectAll(obj1,obj2)  
{  
    var checkboxIds = new String();  
    checkboxIds = obj1;  
          
    var arrIds = new Array();  
    arrIds = checkboxIds.split('|');  
          
    for(var i=0;i<arrIds.length;i++)  
    {  
        document.getElementById(arrIds[i]).checked = obj2.checked;  
    }  
}  
  
</script>  
    <table width="100%">
    <tr>
        <td colspan="2"><asp:Label runat="server" CssClass = "RowHeaderTable" Width="100%" Font-Bold="true" >MẶT HÀNG==> TẠO NHIỀU MÃ VẠCH</asp:Label> </td>
    </tr>
    <tr>
    <td valign="top" >
        <table>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
            <ContentTemplate >
                <table >
                    <tr>
                        <td align="right" >Nhóm :</td>
                        <td style="width:200px"><asp:DropDownList ID="ddlNhomMH" runat="server" AppendDataBoundItems="True" AutoPostBack="true" Width="200px">
                        <asp:ListItem Text="Tất cả" Value="0"></asp:ListItem></asp:DropDownList></td>
                    </tr>
                    <%--<tr>
                        <td colspan="2">
                        <asp:Button ID="btnTatCa" runat="server" CssClass="Button" Text="Chọn tất cả" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2">
                        <asp:GridView ID="GvSPBarcode" runat="server"  AutoGenerateColumns="False" DataKeyNames ="uId_Mathang" CssClass ="Grid "
                            AllowPaging="True" PageSize="14">
                            <RowStyle CssClass ="GridRow " />
                            <HeaderStyle CssClass ="GridRowHeader " />
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass ="GridCol ">
                                    <HeaderTemplate>  
                                        <asp:CheckBox ID="chkSelectAll"   
                                            runat="server"   
                                            Text="" />  
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkChon" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="v_MaMathang" HeaderText="Mã SP"  ItemStyle-CssClass ="GridCol "/>
                                <asp:BoundField  DataField="nv_TenMathang_vn" HeaderText="Tên sản phẩm" ItemStyle-CssClass ="GridCol "/>                    
                                <asp:BoundField DataField="v_MaBarcode" HeaderText="Mã vạch" ItemStyle-CssClass ="GridCol "/>
                            </Columns>
                        </asp:GridView>
                        </td>
                    </tr>
                 </table>
             </ContentTemplate>
             </asp:UpdatePanel>
         </td>
         </tr>
            <tr>
                <td>
                <asp:Button ID="btnLuu" runat="server" CssClass="Button" Text="In mã vạch"/>
                </td>
            </tr>
        </table>
    </td>
    <td style="width:875px"><CR:CrystalReportViewer ID="CrvMaVachSP"  runat="server" AutoDataBind="True" CssClass ="CrystalReport " /></td>
    </tr>
    </table>
</asp:Content>
