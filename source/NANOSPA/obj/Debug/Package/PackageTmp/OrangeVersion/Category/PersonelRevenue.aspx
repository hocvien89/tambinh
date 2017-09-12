<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="PersonelRevenue.aspx.vb" Inherits="NANO_SPA.PersonelRevenue" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                client_grid.GetRowValues(e.visibleIndex, 'uId_Mathang;', OnGridSelectionComplete);
            }
        }
    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DOANH THU NHÂN VIÊN</p>
            </li>
        </ul>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Thời gian</span></legend>
        <ul>
            <li class="text_title">Từ ngày </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Nhân viên: </li>
            <li class ="text_title">
                <dx:ASPxComboBox ID="cboNhanvien" Width="200px" runat="server"></dx:ASPxComboBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_Baocao" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset style="width: 98%; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Danh sách nhân viên</span></legend>
        <dx:ASPxGridView ID="Grid_Doanhthunhanvien" runat="server" KeyFieldName="uId_Nhanvien" AutoGenerateColumns="false"
            ClientInstanceName="grid_Doanhthunhanvien" Width="100%">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="v_Manhanvien" Caption="Mã nhân viên" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Caption="Tên nhân viên" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" />
                <dx:GridViewDataTextColumn FieldName="phieuthuchi" Caption="Phiếu thu chi" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="4" PropertiesTextEdit-DisplayFormatString="{0:n0}" CellStyle-ForeColor="Red" />
                <dx:GridViewDataTextColumn FieldName="phieuxuat" Caption="Phiếu xuất" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="5" PropertiesTextEdit-DisplayFormatString="{0:n0}" CellStyle-ForeColor="Blue" />
                <dx:GridViewDataTextColumn FieldName="phieudv" Caption="Phiếu dịch vụ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="3" PropertiesTextEdit-DisplayFormatString="{0:n0}">
                </dx:GridViewDataTextColumn>
            </Columns>
            <Templates>
                <DetailRow>
                    <div style="padding: 3px 3px 2px 3px">
                        <dx:ASPxPageControl ID="PageC_Chitiet" runat="server" Width="100%" EnableCallBacks="true" Font-Size="16px">
                            <TabPages>
                                <dx:TabPage Text="Phiếu dịch vụ" Visible="true">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl1" runat="server">
                                            <div class="divPhieudv">
                                                <dx:ASPxGridView ID="Grid_Phieudichvu" runat="server" KeyFieldName="uId_Phieudichvu"
                                                    OnBeforePerformDataSelect="Grid_Phieudichvu_BeforePerformDataSelect" Width="98%">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="v_Sophieu" Caption="Mã phiếu" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Caption="Khách hàng" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="d_Ngay" Caption="Ngày thực hiện" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="tongtiendv" Caption="Tổng tiền phiếu" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="{0:n0}">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Settings ShowFooter="true" />
                                                    <SettingsPager PageSize="5"></SettingsPager>
                                                    <TotalSummary>
                                                        <dx:ASPxSummaryItem DisplayFormat=" Tổng : {0:n0}" FieldName="tongtiendv" SummaryType="Sum" />
                                                    </TotalSummary>
                                                    <Styles>
                                                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                        </AlternatingRow>
                                                    </Styles>
                                                </dx:ASPxGridView>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Phiếu thu chi" Visible="true">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl2" runat="server">
                                            <div class="divPhieudv">
                                                <dx:ASPxGridView ID="Grid_Phieuthuchi" runat="server" KeyFieldName="uId_Phieuthuchi"
                                                    OnBeforePerformDataSelect="Grid_Phieuthuchi_BeforePerformDataSelect" Width="98%">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="v_Maphieu" Caption="Mã phiếu" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="nv_Ghichu" Caption="Khách hàng" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="d_Ngay" Caption="Ngày thực hiện" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="f_Sotien" Caption="Tổng tiền phiếu" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="{0:n0}">
                                                            <FooterCellStyle ForeColor="Red" />
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Settings ShowFooter="true" />
                                                    <SettingsPager PageSize="5"></SettingsPager>
                                                    <TotalSummary>
                                                        <dx:ASPxSummaryItem DisplayFormat="Tổng : {0:n0}" FieldName="f_Sotien" SummaryType="Sum" />
                                                    </TotalSummary>
                                                    <Styles>
                                                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                        </AlternatingRow>
                                                    </Styles>
                                                </dx:ASPxGridView>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Phiếu xuất" Visible="true">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl3" runat="server">
                                            <div class="divPhieudv">
                                                <dx:ASPxGridView ID="Grid_Phieuxuat" runat="server" KeyFieldName="uId_Phieuxuat"
                                                    OnBeforePerformDataSelect="Grid_Phieuxuat_BeforePerformDataSelect" Width="98%">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="v_Maphieuxuat" Caption="Mã phiếu" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="nv_Tenkho_vn" Caption="Tên kho" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Caption="Khách hàng" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="d_Ngayxuat" Caption="Ngày xuất" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="f_Tongtienthuc" Caption="Tổng tiền phiếu" HeaderStyle-HorizontalAlign="Center"
                                                            Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="{0:n0}">
                                                            <FooterCellStyle ForeColor="Blue"></FooterCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Settings ShowFooter="true" />
                                                    <TotalSummary>
                                                        <dx:ASPxSummaryItem DisplayFormat="Tổng : {0:n0}" FieldName="f_Tongtienthuc" SummaryType="Sum" />
                                                    </TotalSummary>
                                                    <SettingsPager PageSize="5">
                                                    </SettingsPager>
                                                    <Styles>
                                                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                        </AlternatingRow>
                                                    </Styles>
                                                </dx:ASPxGridView>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                            </TabPages>
                        </dx:ASPxPageControl>
                    </div>
                </DetailRow>
            </Templates>
            <SettingsDetail ShowDetailRow="true" />
            <SettingsPager PageSize="15">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <ClientSideEvents SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
</asp:Content>
