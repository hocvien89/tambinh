<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="MarketingStatistic.aspx.vb" Inherits="NANO_SPA.MarketingStatistic" %>

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
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        var _fieldName = '';
        function grid_RowDblClick(s, e) {
            s.StartEditRow(e.visibleIndex);
        }
        function grid_FocusedRowChanged(s, e) {
            if (s.cpIsEditing) {
                s.UpdateEdit();
            }
        }
        function grid_EndCallback_congviec(s, e) {
            var edit = s.GetEditor(1);
            var lblSoLuong = document.getElementById("<%=lblSoLuong.ClientID%>");
            if (s.cpIsSoLuong != "0") {
                lblSoLuong.innerHTML = "<span style='font-weight:bold; color:red'>Số lượng: " + s.cpIsSoLuong + "</span></br> Từ khóa: " + s.cpIsTuKhoa;
                s.cpIsSoLuong = "0";
            } else {
                lblSoLuong.innerHTML = "";
            }
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THỐNG KÊ CÔNG VIỆC MARKETING</p>
    </div>
    <div style="clear: both"></div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset class="field_tt">
                <legend><span style="font-weight: bold; color: green">Thông tin phiếu</span></legend>
                <table class="info_table">
                    <tbody>
                        <tr>
                            <td class="info_table_td">Từ ngày:
                            </td>
                            <td class="info_table_td">
                                <dx:ASPxDateEdit ID="deTungay" UseMaskBehavior="true" ClientInstanceName="deTungay" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                    runat="server">
                                </dx:ASPxDateEdit>
                            </td>
                            <td class="info_table_td">Đến ngày:
                            </td>
                            <td class="info_table_td">
                                <dx:ASPxDateEdit ID="deDenngay" UseMaskBehavior="true" ClientInstanceName="deDenngay" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                    runat="server">
                                </dx:ASPxDateEdit>
                            </td>
                            <td class="info_table_td">
                                <dx:ASPxButton ID="btnXem" Image-Url="~/images/16x16/page.png" OnClick="btnXem_Click" AutoPostBack="true" ClientInstanceName="btnXem" runat="server" Text="Thống kê từ khóa">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </fieldset>
            <div style="clear: both"></div>
            <div class="bill_infor">
                <fieldset class="field_dsphieu" style="width: 30% !important; float: left">
                    <legend><span style="font-weight: bold; color: green">Danh sách từ khóa</span></legend>
                    <dx:ASPxGridView ID="GVTukhoa" runat="server" ClientInstanceName="client_GVTukhoa" KeyFieldName="Tags" CssClass="grid_dm_dv"
                        AutoGenerateColumns="false" SettingsPager-PageSize="8"
                        SettingsPager-Position="Bottom">
                        <Columns>
                            <dx:GridViewCommandColumn Width="30px" ShowSelectCheckbox="True" Visible="true" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="Tags"
                                Name="Tags">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                HeaderStyle-HorizontalAlign="Center" Width="100px" Caption="Tên từ khóa" FieldName="nv_TagName_vn"
                                Name="nv_TagName_vn">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsEditing Mode="Inline" />
                        <SettingsPager PageSize="12">
                        </SettingsPager>
                        <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                        <Styles>
                            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                            </AlternatingRow>
                            <GroupRow Font-Bold="true"></GroupRow>
                        </Styles>
                    </dx:ASPxGridView>
                </fieldset>
                <div style="float: left; position: relative; left: 5px; top: 200px">
                    <dx:ASPxButton ID="btnDSNo" Image-Url="~/images/16x16/page_go.png" OnClick="btnDSNo_Click" ClientInstanceName="btnDSNo" AutoPostBack="false" runat="server" Text="Xem">
                    </dx:ASPxButton>
                </div>
                <fieldset class="field_thanhtoan" style="width: 60.4% !important; float: right">
                    <legend><span style="font-weight: bold; color: green">Danh sách công việc</span></legend>
                    <div class="box_thanhtoan" style="min-height: 174px;">
                        <dx:ASPxGridView ID="GVLocTheoTags" runat="server" ClientInstanceName="client_GVLocTheoTags"
                            AutoGenerateColumns="false" KeyFieldName="uId_Congviec;uId_KH_Tiemnang;uId_Chuyendoi" CssClass="grid_dm_dv" SettingsPager-PageSize="8"
                            SettingsPager-Position="Bottom">
                            <Columns>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Khách hàng" FieldName="nv_Hoten_vn"
                                    Name="nv_Hoten_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Nhân viên làm" FieldName="tennhanvien"
                                    Name="tennhanvien">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Ngày làm" FieldName="d_Ngay" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}"
                                    Name="d_Ngay">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Nội dung" FieldName="nv_Noidung"
                                    Name="nv_Noidung">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Từ khóa dịch vụ" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <%# SplitTags_DV(Eval("Tags").ToString) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Từ khóa khác" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <%# SplitTags(Eval("Tags").ToString) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)'>
                                            <img src="../../../images/bub.png" /></a>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsEditing Mode="Inline" />
                            <SettingsPager PageSize="3">
                            </SettingsPager>
                            <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                            <ClientSideEvents EndCallback="grid_EndCallback_congviec" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" />
                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                </AlternatingRow>
                            </Styles>
                        </dx:ASPxGridView>
                        <asp:Label ID="lblSoLuong" Style="position: relative; top: 9px" runat="server"></asp:Label>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
