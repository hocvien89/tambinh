<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CustomerStatistic.aspx.vb" Inherits="NANO_SPA.CustomerStatistic" %>

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
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/CONTROL/txtDatepicker.ascx" TagName="txtDatepicker" TagPrefix="uc1" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THỐNG KÊ KHÁCH HÀNG</p>
            </li>
        </ul>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <div style="height: 30px; width: 860px; margin: auto">
            <ul>
                <li class="text_title" style="margin-left: 5px">Từ ngày: </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" Width="85px" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                </li>
                <li class="text_title" style="margin-left: 5px">Đến ngày: </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" Width="85px" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxCheckBox ID="chk_Nguon" runat="server" Text="Nguồn:" />
                </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxComboBox ID="cbo_Nguon" runat="server" />
                </li>
                <li class="text_title">
                    <dx:ASPxButton ID="btn_Baocao" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Lọc">
                    </dx:ASPxButton>
                </li>
                <li class="text_title">
                    <dx:ASPxButton ID="btn_ExportExcel" Image-Url="~/images/16x16/export_excel.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Xuất Excel">
                    </dx:ASPxButton>
                </li>
                <li class="text_title">
                    <dx:ASPxButton ID="btn_Report" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Báo cáo">
                    </dx:ASPxButton>
            </ul>
        </div>
    </fieldset>
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Thông tin khách hàng</span></legend>
        <dx:ASPxGridView ID="Grid_Khahhang" KeyFieldName="uId_Khachhang" ClientInstanceName="client_grid" AutoGenerateColumns="false" runat="server"
            SettingsPager-PageSize="17">
            <Columns>
                <dx:GridViewDataColumn FieldName="uId_Khachhang" Visible="false" VisibleIndex="-1" Name="uId_Khachhang">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Mã Khách hàng" HeaderStyle-HorizontalAlign="Center" FieldName="v_Makhachang" VisibleIndex="0"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="v_Makhachang" Width="100px">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Tên khách hàng" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn" VisibleIndex="1"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Hoten_vn" Width="200px">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Ngày sinh" Visible="true" VisibleIndex="2" FieldName="d_Ngaysinh"
                    Settings-AutoFilterCondition="Contains" Width="85px" Name="d_Ngaysinh" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Gới tính" Visible="true" VisibleIndex="3" FieldName="b_Gioitinh" CellStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" Width="80px" Name="nv_Chucvu_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>
                  <dx:GridViewDataColumn Caption="Nguồn" Visible="true" VisibleIndex="3" FieldName="nv_Nguon_vn" CellStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" Width="80px" Name="nv_Nguon_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Địa chỉ" Visible="true" VisibleIndex="4" FieldName="nv_Diachi_vn"
                    Settings-AutoFilterCondition="Contains" Width="250px" Name="b_Gioitinh" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn Caption="Số điện thoại" Visible="true" VisibleIndex="5" FieldName="v_DienthoaiDD"
                    Settings-AutoFilterCondition="Contains" Width="100px" Name="v_DienthoaiDD" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataColumn Caption="Địa chỉ Email" Visible="true" VisibleIndex="5" FieldName="v_Email"
                    Settings-AutoFilterCondition="Contains" Width="200px" Name="v_Email" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn Caption="Ngày đến" Visible="true" VisibleIndex="6" FieldName="d_Ngayden" SortIndex="0"
                    Settings-AutoFilterCondition="Contains" Width="85px" Name="d_Ngayden" HeaderStyle-HorizontalAlign="Center" Settings-SortMode="Default" SortOrder="Descending" Settings-AllowSort="True">
                    <PropertiesTextEdit DisplayFormatString="{0:d}"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataColumn Caption="Ghi chú" Visible="true" VisibleIndex="6" FieldName="nv_Ghichu_vn"
                    Settings-AutoFilterCondition="Contains" Width="150px" Name="nv_Ghichu_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager PageSize="15" Summary-Text="Trang {0}/{1} (Tổng {2} Khách hàng)">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <div style="width: 1075px; margin: auto; text-align: center">
            <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' ReportViewerID="ReportViewer1" Width="1075">
                <Items>
                    <dx:ReportToolbarButton ItemKind='Search' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='PrintReport' />
                    <dx:ReportToolbarButton ItemKind='PrintPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                    <dx:ReportToolbarLabel ItemKind='PageLabel' />
                    <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind='OfLabel' />
                    <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                    <dx:ReportToolbarButton ItemKind='NextPage' />
                    <dx:ReportToolbarButton ItemKind='LastPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                    <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                    <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                        <Elements>
                            <dx:ListElement Value='pdf' />
                            <dx:ListElement Value='xls' />
                            <dx:ListElement Value='xlsx' />
                            <dx:ListElement Value='rtf' />
                            <dx:ListElement Value='mht' />
                            <dx:ListElement Value='html' />
                            <dx:ListElement Value='txt' />
                            <dx:ListElement Value='csv' />
                            <dx:ListElement Value='png' />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
                <Styles>
                    <LabelStyle>
                        <Margins MarginLeft='3px' MarginRight='3px' />
                    </LabelStyle>
                </Styles>
            </dx:ReportToolbar>
            <dx:ReportViewer ID="ReportViewer1" runat="server"></dx:ReportViewer>
        </div>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
