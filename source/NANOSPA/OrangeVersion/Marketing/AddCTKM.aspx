<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AddCTKM.aspx.vb" Inherits="NANO_SPA.AddCTKM" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHiddenField" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    
    <script type="text/javascript">
        var last_trangthai = null;
        
        function Onchanged(cb_Trangthai) {
            if (client_grid.InCallback())
                last_trangthai = cb_Trangthai.GetValue().toString();
            else
                client_grid.PerformCallback(cb_Trangthai.GetValue().toString())
        }
        function OnEndCallback(s, e) {
            if (last_trangthai) {
                client_grid.PerformCallback(last_trangthai);
                last_trangthai = null;
            }
        }

        function dbclick(s, e) {
            s.GetRowValues(e.visibleIndex, 'uId_Loaivoucher;nv_Tenloaivoucher;d_Ngaybatdau;d_Ngayketthuc;f_Menhgia;i_sl;nv_GioihanVOUCHER', OnGridSelectionComplete);
        }

        function OnGridSelectionComplete(values) {
            txt_Tenchuongtrinh.SetText(values[1].toString());
            de_Ngaybatdau.SetText(values[2].toString());
            de_Ngayketthuc.SetText(values[3].toString());
            txt_Gia.SetText(values[4].toString());
            txt_SL.SetText(values[5].toString());
            txt_Gioihan.SetText(values[6].toString());
            btn_Add.SetText('Sửa');
            client_grid.PerformCallback(values[0].toString());
        }


    </script>
    
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>CHƯƠNG TRÌNH KHUYẾN MÃI</p>
    </div>
    <div style="clear:both">
        <fieldset class="field_tt" style="margin:auto;width:100%">
        <legend><span style="font-weight: bold; color: green">Thông tin voucher</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Tên chương trình :</td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txt_Tenchuongtrinh" ClientInstanceName="txt_Tenchuongtrinh" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td">
                        Mệnh giá :
                    </td>
                    <td class="info_table_td" style="float:left">
                        <dx:ASPxTextBox ID="txt_Gia" ClientInstanceName="txt_Gia" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td">Ngày bắt đầu :</td>
                    <td class="info_table_td">
                    <dx:ASPxDateEdit ID="de_Ngaybatdau" ClientInstanceName="de_Ngaybatdau" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>    
                    </td>
                      <td class="info_table_td">
                        Ngày kết thúc :
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="de_Ngayketthuc" ClientInstanceName="de_Ngayketthuc" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>    
                    </td>
                </tr>    
                <tr>
                    
                    <td class="info_table_td">
                        Giới hạn :
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="txt_Gioihan" ClientInstanceName="txt_Gioihan" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                    </td>
                     <td class="info_table_td">
                        Số lượng : 
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txt_SL" ClientInstanceName="txt_SL" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td">
                        Mô tả :
                    </td>
                    <td class="info_table_td" colspan="3">
                        
                        <dx:ASPxTextBox ID="txt_Mota2" runat="server" Width="450px"></dx:ASPxTextBox>
                    </td>
                </tr>
                            
                <tr>
                    <td colspan="4" class="info_table_td" style="text-align:center">
                        <dx:ASPxButton ID="btn_Refresh" ClientInstanceName="btn_Refresh" runat="server" Text="Làm mới" Style="float: left;margin-left: 10px" Image-Url="~/images/16x16/refresh.png"></dx:ASPxButton>
                        <dx:ASPxButton ID="btn_Add" ClientInstanceName="btn_Add" runat="server" Text="Nhập mới" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/add.png"></dx:ASPxButton>
                        <dx:ASPxButton ID="btn_Phat" ClientInstanceName="btn_Phat" Width="150px" runat="server" Text="Phát Voucher" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/door_in.png"></dx:ASPxButton>
                        <dx:ASPxButton ID="btn_Thu" ClientInstanceName="btn_Thu" Width="150px" runat="server" Text="Thu Voucher" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/door_in.png"></dx:ASPxButton>
                    </td>
                </tr>
                
            </tbody>
        </table>
        </fieldset>
    </div>
    <div style="text-align:center ; padding-bottom:20px;margin:auto">
        <fieldset class="field_tt" style="margin:auto;width:100%">
            <div>
                <ul>
                  
                    <li class="text_title" >
                        Dang sách loại Voucher :</li>
                    <li class="text_title"> <dx:ASPxComboBox ID="cb_Trangthai" ClientInstanceName="cb_Trangthai" runat="server" SelectedIndex="0" OnSelectedIndexChanged="cb_Trangthai_SelectedIndexChanged">
                            <Items>
                                <dx:ListEditItem Selected="True" Text="Tất cả" Value="ALL" />
                                <dx:ListEditItem Text="Còn thời hạn" Value="TRUE" />
                                <dx:ListEditItem Text="Hết hạn" Value="FAULT" />
                            </Items>
                            <ClientSideEvents SelectedIndexChanged="function(s,e){Onchanged(s);}" />
                        </dx:ASPxComboBox>
                    </li>
             
                </ul>
            </div>
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Loaivoucher" OnSelectionChanged="dgvDevexpress_SelectionChanged"
        SettingsPager-Position="Bottom" Width="100%">
        <Columns>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Loaivoucher"
                Name="uId_Loaivoucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Width="300px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên voucher" FieldName="nv_Tenloaivoucher"
                Name="nv_Tenloaivoucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Ngày bắt đầu" FieldName="d_Ngaybatdau"
                Name="d_Ngaybatdau"  PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"
                Caption="Ngày kết thúc" FieldName="d_Ngayketthuc" Name="d_Ngayketthuc" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center"
                Caption="Mệnh giá" FieldName="f_Menhgia" Name="f_Menhgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center"
                Caption="Số lượng " FieldName="i_sl" Name="i_sl" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="7" HeaderStyle-HorizontalAlign="Center"
                Caption="Giới hạn" FieldName="nv_GioihanVOUCHER" Name="nv_GioihanVOUCHER">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="8" Width="40px" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                    <Image AlternateText="Xóa" Url="~/images/btn_Delete.png">
                    </Image>
                </DeleteButton>
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <SettingsBehavior ProcessSelectionChangedOnServer="true" ConfirmDelete="true"  AllowFocusedRow="true" AllowMultiSelection="true"  />
        <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="OnEndCallback" RowClick="dbclick"  />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
            </fieldset>
    </div>
</asp:Content>
