<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CustomerBirthday.aspx.vb" Inherits="NANO_SPA.CustomerBirthday" %>
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>SINH NHẬT BỆNH NHÂN </p>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Theo thời gian</span></legend>
        <div style="height: 30px; width:71%;margin:auto   ">
            <ul>
                <li class="text_title" style="margin-left: 5px">Ngày:  </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxComboBox ID="cbo_Ngay" runat ="server" Width="70px" IncrementalFilteringMode="StartsWith">
                        <Items>
                            <dx:ListEditItem Text="Tất cả" Value="0" />
                        </Items>
                    </dx:ASPxComboBox>
                </li>
                <li class="text_title" style="margin-left: 5px">Tháng:  </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxComboBox ID="cbo_Thang" runat="server" Width="70px" IncrementalFilteringMode="StartsWith">
                        <Items>
                            <dx:ListEditItem Text="Tất cả" Value="0" />
                        </Items>
                    </dx:ASPxComboBox>
                </li>
                <li class="text_title" style="margin-left: 5px">Năm:  </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxComboBox ID="cbo_Nam" runat="server" Width="70px" IncrementalFilteringMode="StartsWith">
                        <Items>
                            <dx:ListEditItem Text="Tất cả" Value="0" />
                        </Items>
                    </dx:ASPxComboBox>
                </li>
                <li class="text_title" style="margin-left: 5px">Cửa hàng:  </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxComboBox ID="cbo_Cuahang" runat="server" />
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
<%--                <li class="text_title">
                    <dx:ASPxButton ID="btn_Report" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Báo cáo">
                    </dx:ASPxButton>
                    </li>--%>
            </ul>
        </div>
    </fieldset>
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Thông tin bệnh nhân</span></legend>
                     <dx:ASPxGridView ID="Grid_KH_Sinhnhat" KeyFieldName="uId_Khachhang" ClientInstanceName="client_grid" AutoGenerateColumns="false" runat="server"
            SettingsPager-PageSize="17" >
            <Columns>
                <dx:GridViewDataColumn Caption="Mã Bệnh nhân" HeaderStyle-HorizontalAlign="Center" FieldName="v_Makhachang" VisibleIndex="0"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="v_Makhachhang" Width="10%">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Tên bệnh nhân" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn" VisibleIndex="1"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Hoten_vn" Width="35%">
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn Caption="Ngày sinh" Visible="true" VisibleIndex="2" FieldName="d_Ngaysinh"
                    Settings-AutoFilterCondition="Contains" Width="10%" Name="d_Ngaysinh" HeaderStyle-HorizontalAlign="Center" SortOrder="Ascending">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataColumn Caption="Gới tính" Visible="true" VisibleIndex="3" FieldName="Gioitinh" CellStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" Width="8%" Name="nv_Chucvu_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Địa chỉ" Visible="true" VisibleIndex="4" FieldName="nv_Diachi_vn"
                    Settings-AutoFilterCondition="Contains" Width="25%" Name="b_Gioitinh" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn Caption="Số điện thoại" Visible="true" VisibleIndex="5" FieldName="v_DienthoaiDD"
                    Settings-AutoFilterCondition="Contains" Width="10%" Name="v_DienthoaiDD" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption="Ghi chú" Visible="true" VisibleIndex="6" FieldName="nv_Ghichu_vn" SortIndex="0" 
                    Settings-AutoFilterCondition="Contains" Width="85px" Name="nv_Ghichu_vn" HeaderStyle-HorizontalAlign="Center" Settings-SortMode="Default" SortOrder="Descending" Settings-AllowSort="True">
                    <PropertiesTextEdit DisplayFormatString="{0:d}"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>

<%--                <dx:GridViewDataColumn Caption="Ghi chú" Visible="true" VisibleIndex="6" FieldName="nv_Ghichu_vn"
                    Settings-AutoFilterCondition="Contains" Width="150px" Name="nv_Ghichu_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>--%>
            </Columns>
            <SettingsPager PageSize="15" Summary-Text="Trang {0}/{1} (Tổng {2} Bệnh nhân)">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
