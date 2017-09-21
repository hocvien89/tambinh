<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="WarehouseCard.aspx.vb" Inherits="NANO_SPA.WarehouseCard" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function jo_IsString(input) {
            var value = "";
            if (input == "" || input == null || isNaN(input) == true) {
                value = "0";
            }
            else {
                value = input;
            }
            return value;
        }
        function jo_FormatMoney(input) {
            return input.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        function jo_ThousanSereprate(id) {
            var textbox = id;
            id.value = jo_FormatMoney(id.value.replace(/,/g, ""));
            return false;
        }
    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THẺ KHO</p>
            </li>
        </ul>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Mặt hàng:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlMathang" EnableCallbackMode="true" ClientInstanceName="ddlMathang" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Mathang" ValueType="System.String" TextFormatString="{0}-{1}"
                            Width="200px" DropDownWidth="500px" DropDownStyle="DropDown">
                            <Columns>
                                <dx:ListBoxColumn FieldName="v_MaMathang" Caption="Mã" />
                                <dx:ListBoxColumn FieldName="nv_TenMathang_vn" Caption="Tên" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Kho:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlKho" ClientInstanceName="ddlKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Từ ngày:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deTuNgay" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">Đến ngày:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deDenNgay" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxButton ID="btnFilter" OnClick="btnFilter_Click" Width="136px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="position: relative"
                            runat="server" Text="Xem thẻ kho">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <dx:ASPxGridView ID="dgvDevexpress" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Mathang"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="80px" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="Ngay" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}"
                Name="Ngay">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Mã phiếu nhập" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="MaPhieuNhap" Name="MaPhieuNhap">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Mã phiếu xuất" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="MaPhieuXuat" Name="MaPhieuXuat">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Diễn giải" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="Nhom" Name="Nhom">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Khách hàng" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="TenBenhNhan" Name="TenBenhNhan">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Tồn đầu" FieldName="TonDau" Name="TonDau" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="SL nhập" FieldName="SoLuongNhap" Name="SoLuongNhap" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="SL xuất" FieldName="SoLuongXuat" Name="SoLuongXuat" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="SL tồn" FieldName="SLTon" Name="SLTon" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="NV thao tác" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="NhanVienThaoTac" Name="NhanVienThaoTac">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
