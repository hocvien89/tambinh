<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AddChiendich.aspx.vb" Inherits="NANO_SPA.AddChiendich" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHiddenField" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        var lastvalue = null;
        var last_trangthai = null
        function Onchanged(cb_Trangthai) {
            if (client_grid_1.InCallback())
                last_trangthai = cb_Trangthai.GetValue().toString();
            else
                client_grid_1.PerformCallback(cb_Trangthai.GetValue().toString())
        }
        function OnEndCallback1(s, e) {
            if (last_trangthai) {
                client_grid_1.PerformCallback(last_trangthai);
                last_trangthai = null;
            }
        }
        function loadtag(cb_TagSP) {
            if (client_grid.InCallback())
                lastvalue = cb_TagSP.GetValue().toString();
            else
                client_grid.PerformCallback(cb_TagSP.GetValue().toString());
        }
        function dbclick(s, e) {
            s.GetRowValues(e.visibleIndex, 'uId_ChiendichMarketing;nv_Tenchiendich_vn;d_Ngaybatdau;d_Ngayketthuc;nv_Mota', OnGridSelectionComplete);
        }
        function OnGridSelectionComplete(values) {
            txt_mota.SetText(values[4].toString());
            txt_Tenchuongtrinh.SetText(values[1].toString());
            de_Ngaybatdau.SetText(values[2].toString());
            de_Ngayketthuc.SetText(values[3].toString());
            btn_Add.SetText('Sửa');
            client_grid.PerformCallback(values[0].toString());
        }


    </script>
    
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>CHIẾN DỊCH MARKETING</p>
    </div>
    <div style="clear:both;margin:auto">
        <fieldset style="width:100%;margin:auto" class="field_tt">
            <legend><span style="font-weight: bold; color: green">Thông tin chiến dịch</span></legend>
            <fieldset style="width:43%;float:left">
                <table class="info_table" style="float:left">
            <tbody>
                <tr>
                    <td class="info_table_td">Tên chương trình :</td>
                    <td class="info_table_td" colspan="3"> 
                        <dx:ASPxTextBox ID="txt_Tenchuongtrinh" ClientInstanceName="txt_Tenchuongtrinh" runat="server" Width="465px" Height="18px"></dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Ngày bắt đầu :</td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="de_Ngaybatdau" ClientInstanceName="de_Ngaybatdau" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">Ngày kết thúc :</td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="de_Ngayketthuc" ClientInstanceName="de_Ngayketthuc" Width="180px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server" Height="19px"></dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Từ khóa sản phẩm :</td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxComboBox ID="cb_TagSP" runat="server" ClientInstanceName="cb_TagSP" CallbackPageSize="10" DropDownStyle="DropDown" IncrementalFilteringMode="Contains" EnableCallbackMode="true" Width="465px" ValueType="System.String" Height="17px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { loadtag(s); }"/>
                        </dx:ASPxComboBox>
                    </td>
                </tr>              
                <tr>
                    <td class="info_table_td">Mô tả : </td>
                    <td class="info_table_td" colspan="3">
                       
                        <dx:ASPxTextBox ID="txt_mota2" ClientInstanceName="txt_mota" runat="server" Width="465px" Height="18px"></dx:ASPxTextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="info_table_td" colspan="4">
                        <dx:ASPxButton ID="btn_Refresh" ClientInstanceName="btn_Refresh" runat="server" Text="Làm mới" Style="float: left;margin-left: 40px" Image-Url="~/images/16x16/refresh.png"></dx:ASPxButton>
                            <dx:ASPxButton ID="btn_Add" ClientInstanceName="btn_Add" runat="server" Text="Thêm" Style="float: left;margin-left: 10px; " Image-Url="~/images/16x16/add.png"></dx:ASPxButton>
                        
                        <dx:ASPxButton ID="btn_Phat" ClientInstanceName="btn_Phat" Width="130px" runat="server" Text="Phát SP" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/door_in.png"></dx:ASPxButton>
                        <dx:ASPxButton ID="btn_Thu" ClientInstanceName="btn_Thu" Width="120px" runat="server" Text="Phản hồi" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/door_in.png"></dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td" colspan="4" style="padding-left:200px">
                        <dx:ASPxComboBox ID="cb_Trangthai" ClientInstanceName="cb_Trangthai" runat="server" SelectedIndex="0">
                            <Items>
                                <dx:ListEditItem Selected="True" Text="Tất cả" Value="ALL" />
                                <dx:ListEditItem Text="Còn thời hạn" Value="TRUE" />
                                <dx:ListEditItem Text="Hêt thời hạn" Value="FALSE" />
                            </Items>
                        <ClientSideEvents SelectedIndexChanged="function(s,e){Onchanged(s);}" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </tbody>
            </table>
            </fieldset>
            <fieldset style="float:right;width:724px">
                <table style="float:right;width:724px">
                <tr>
                    <td>
                         <dx:ASPxGridView ID="dgvDevexpress2" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid"
                            AutoGenerateColumns="false" KeyFieldName="uId_Mathang" SettingsPager-Position="Bottom" Width="724px">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Mathang"
                                    Name="uId_Mathang">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="515px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên mặt hàng" FieldName="nv_TenMathang_vn"
                                    Name="nv_TenMathang_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn VisibleIndex="4" Visible="true" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                        <Image Url="~/images/btn_Delete.png"></Image>
                                    </DeleteButton>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsEditing Mode="Inline" />
                            <SettingsPager PageSize="7">
                            </SettingsPager>
                            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                            <SettingsBehavior ProcessSelectionChangedOnServer="true"  AllowFocusedRow="true" AllowMultiSelection="true"  
                                              ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true"  />
                            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                </AlternatingRow>
                            </Styles>
                        </dx:ASPxGridView>
                    </td>
                </tr>
            </table>
            </fieldset>
            
        </fieldset>
    </div>
    <div style="clear:both;width:100%">
        
        <dx:ASPxGridView ID="dgv1" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid_1"
                            AutoGenerateColumns="false" KeyFieldName="uId_ChiendichMarketing" SettingsPager-Position="Bottom" Width="1400px">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_ChiendichMarketing"
                                    Name="uId_ChiendichMarketing">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="300px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên chiến dịch" FieldName="nv_Tenchiendich_vn"
                                    Name="nv_Tenchiendich_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Width="100px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Ngày bắt đầu" FieldName="d_Ngaybatdau"
                                    Name="d_Ngaybatdau">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="4" Width="100px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Ngày kết thúc" FieldName="d_Ngayketthuc"
                                    Name="d_Ngayketthuc">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="5" Width="210px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Mô tả" FieldName="nv_Mota"
                                    Name="nv_Mota">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn VisibleIndex="6" Visible="true" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                        <Image Url="~/images/btn_Delete.png"></Image>
                                    </DeleteButton>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsEditing Mode="Inline" />
                            <SettingsPager PageSize="5">
                            </SettingsPager>
                            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                            <SettingsBehavior ProcessSelectionChangedOnServer="true"  AllowFocusedRow="true" AllowMultiSelection="true"  
                                              ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true"  />
                            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                            <ClientSideEvents EndCallback="OnEndCallback1" RowClick="dbclick" />
                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                </AlternatingRow>
                            </Styles>
                        </dx:ASPxGridView>
           
    </div>
</asp:Content>
