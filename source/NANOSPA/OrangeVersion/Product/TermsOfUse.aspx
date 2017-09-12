<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="TermsOfUse.aspx.vb" Inherits="NANO_SPA.TermsOfUse" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function btnFilterClick(s, e) {
            Grv_hansudung.Refresh();
            e.processOnServer = false;
        }

        function cboCuahangSelect(s, e) {
            ddlDsKho.PerformCallback();
            return false;
        }
    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>BÁO CÁO HẠN SỬ DỤNG</p>
            </li>
        </ul>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin lọc</span></legend>


        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Cửa hàng:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDsCuahang" ClientInstanceName="ddlDsKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" runat="server" ValueType="System.String">
                            <ClientSideEvents SelectedIndexChanged="cboCuahangSelect" />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Kho:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDsKho" ClientInstanceName="ddlDsKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" runat="server" ValueType="System.String" OnCallback="ddlDsKho_Callback">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxButton ID="btnFilter" ClientInstanceName="btnFilter" Image-Url="~/images/16x16/filter.png" Style="float: left; margin-left: 10px" runat="server" Text="Lọc">
                            <Image Url="~/images/16x16/filter.png"></Image>
                            <ClientSideEvents Click="btnFilterClick" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportXLS" ClientInstanceName="btnExportXLS" Image-Url="~/images/16x16/export_excel.png" Style="float: left; margin-left: 10px" runat="server" Text="Xuất excel">
                            <Image Url="~/images/16x16/export_excel.png"></Image>
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>

    </fieldset>
    <fieldset style="width: 98%; margin: auto">
        <legend><span style="font-weight: bold; color: green">Thông tin hạn sử dụng</span></legend>
        <dx:ASPxGridView ID="Grv_Hansudung" runat="server" Width="100%" AutoGenerateColumns="false" KeyFieldName="uId_Phieunhap_Chitiet" ClientInstanceName="Grv_hansudung">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="uId_Phieunhap_Chitiet" VisibleIndex="-1" Visible="false"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="v_MaMathang" Caption="Mã hàng" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                <dx:GridViewDataTextColumn FieldName="nv_TenMathang_vn" Width="250px" Caption="Tên mặt hàng" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                <dx:GridViewDataTextColumn FieldName="tendonvi" Caption="Đơn vị" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                <dx:GridViewDataTextColumn FieldName="v_Maphieunhap" Caption="Mã phiếu nhập" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                <dx:GridViewDataTextColumn FieldName="d_Ngaynhap" Caption="Ngày nhập" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"
                    PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" />
                <dx:GridViewDataTextColumn FieldName="d_NgayhethanSD" Caption="Ngày hết hạn" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"
                    PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" />
            </Columns>
            <SettingsPager PageSize="15" Summary-Text="Trang {0}/{1} (Tổng {2} Mặt hàng)">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
            <SettingsText EmptyDataRow="Không có dữ liệu!" />
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
