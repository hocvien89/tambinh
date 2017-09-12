<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DSKhachHangHuyDV.aspx.vb" Inherits="NANO_SPA.DSKhachHangHuyDV" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function grid_EndCallback(s, e) {
            var edit = s.GetEditor(1);
            if (s.cpIsEditing) {
                var editor = s.GetEditor(_fieldName);
                if (editor != null) {
                    editor.SelectAll();
                    editor.Focus();
                }
            }
        }
    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH SÁCH KHÁCH HÀNG HỦY DỊCH VỤ</p>
            </li>
        </ul>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <ul style="padding-left: 86px">
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_Baocao" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="ExportExcel" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Xuất Excel">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Thông tin nhân viên</span></legend>
        <dx:ASPxGridView ID="Grid_KHhuydv" KeyFieldName="uId_Khachhang" ClientInstanceName="client_grid" AutoGenerateColumns="false" runat="server"
            SettingsPager-PageSize="17">
            <Columns>
                <dx:GridViewDataColumn FieldName="uId_Khachhang" Visible="false" VisibleIndex="-1" Name="uId_Khachhang">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Mã khách hàng" HeaderStyle-HorizontalAlign="Center" FieldName="v_Makhachhang" VisibleIndex="1"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="v_Makhachang" Width="10%">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Tên khách hàng" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tenkhachhang" VisibleIndex="2"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Hoten_vn" Width="15%">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Địa chỉ" Visible="true" VisibleIndex="3" FieldName="nv_Diachi"
                    Settings-AutoFilterCondition="Contains" Width="23%" Name="nv_Diachi" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Số điện thoại" Visible="true" VisibleIndex="4" FieldName="v_Sodienthoai"
                    Settings-AutoFilterCondition="Contains" Width="8%" Name="v_Sodienthoai" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn  Caption="Dịch vụ hủy / Ngày hủy / Người hủy / Lí do" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4"
                    Visible="true" Name="nv_Lido" FieldName="nv_Lido">
                    <PropertiesTextEdit EncodeHtml="false"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsEditing Mode="Inline" />
            <SettingsPager PageSize="15">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true"/>
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" OnRenderBrick="ASPxGridViewExporter1_RenderBrick"></dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
