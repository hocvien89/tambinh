<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Inventory.aspx.vb" Inherits="NANO_SPA.Inventory" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

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
        function btnFilterClick(s, e) {
            client_dgvdevexpress.Refresh();
        }
    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>TỔNG HỢP TỒN SỐ LƯỢNG</p>
            </li>
        </ul>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin lọc</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Kho:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDsKho" ClientInstanceName="ddlDsKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Đến ngày:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deDenNgay" ClientInstanceName="deDenNgay" Style="float: left; margin-right: 8px;" Width="130px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxButton ID="btnFilter" ClientInstanceName="btnFilter" Image-Url="~/images/16x16/filter.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Lọc">
                            <Image Url="~/images/16x16/filter.png"></Image>
                            <ClientSideEvents Click="btnFilterClick" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnExportXLS" OnClick="btnExportXLS_Click" ClientInstanceName="btnExportXLS" Image-Url="~/images/16x16/export_excel.png" Style="float: left; margin-left: 10px" runat="server" Text="Xuất excel">
                            <Image Url="~/images/16x16/export_excel.png"></Image>
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <div style="clear: both"></div>
    <dx:ASPxGridView ID="dgvDevexpress" runat="server" ClientInstanceName="client_dgvdevexpress"
        AutoGenerateColumns="false" KeyFieldName="uId_Mathang" SettingsPager-PageSize="8"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewBandColumn Caption="Thông tin">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Mathang"
                        Name="uId_Mathang">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Width="150px" Caption="Mã thuốc" FieldName="v_MaMathang"
                        Name="v_MaMathang">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Width="400px" Caption="Tên thuốc" FieldName="nv_TenMathang_vn"
                        Name="nv_TenMathang_vn">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="ĐVT" Width="90px" FieldName="tendonvi"
                        Name="tendonvi">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Caption="SL nhập" Width="70px" FieldName="f_Sl_Nhap"
                        Name="f_Sl_Nhap">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="GTrị nhập" Width="80px" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                        FieldName="f_GT_Nhap" Name="f_GT_Nhap">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="SL xuất" Width="80px" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Sl_Xuat"
                        Name="f_Sl_Xuat">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="GTrị xuất" Width="100px" FieldName="f_GT_Xuat"
                        Name="f_GT_Xuat">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="GTrị Lãi trong ngày" Width="150px" FieldName="f_LaiXuatNgay"
                        Name="f_LaiXuatNgay">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="SL tiêu hao" Width="100px" FieldName="f_SLTieuhao"
                        Name="f_SLTieuhao">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="SL tồn" Width="100px" FieldName="f_SL_Ton"
                        Name="f_SL_Ton">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="Tồn trên kho" Width="100px" FieldName="nv_Tenkho_vn"
                        Name="nv_Tenkho_vn">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="14">
        </SettingsPager>
          <SettingsDetail ShowDetailRow="true" />
        <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" ShowFooter="true"/>
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
         <TotalSummary>
                                                    <dx:ASPxSummaryItem FieldName="f_LaiXuatNgay" SummaryType="Sum"  />
                                                </TotalSummary>
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="dgvexport" GridViewID="dgvDevexpress" runat="server"></dx:ASPxGridViewExporter>
</asp:Content>
