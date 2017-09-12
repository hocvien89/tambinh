<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="TherapyList.aspx.vb" Inherits="NANO_SPA.TherapyList" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function btnlocClick(s, e) {
            grid_Lieutrinh.Refresh();
        }
    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>LIỆU TRÌNH ĐIỀU TRỊ</p>
            </li>
        </ul>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Điều kiện tìm kiếm</span></legend>
        <ul>
            <li class="text_title">Số ngày nhắc nhở: </li>
            <li class="text_title">
                <dx:ASPxTextBox ID="txt_Songay" runat="server" onkeypress="return enter_txtsongay(event)" ClientInstanceName="txt_Songay"></dx:ASPxTextBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_Baocao" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Lọc" ClientInstanceName="btn_Baocao" EnableClientSideAPI="true">
                    <ClientSideEvents Click="btnlocClick" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="ExportExcel" runat ="server" Image-Url="~/images/16x16/export_excel.png" Text="Xuất Excel" OnClick="ExportExcel_Click"></dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset style="width: 98%; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Danh sách liệu trình </span></legend>
        <dx:ASPxGridView ID="Grid_Lieutrinh" runat="server" KeyFieldName="uId_QT_Dieutri" AutoGenerateColumns="false"
            ClientInstanceName="grid_Lieutrinh" Width="100%" >
            <Columns>
                <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Caption="Khách hàng" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="2" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Diachi_vn" Caption="Địa chỉ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="3" Width="150px"/>
                <dx:GridViewDataTextColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="4" CellStyle-ForeColor="Red" Width="80px" />
                <dx:GridViewDataTextColumn FieldName="v_Email" Caption="Email" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="5"  CellStyle-ForeColor="Blue" />
                <dx:GridViewDataTextColumn FieldName="v_Sophieu" Caption="Mã phiếu" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="1" Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Tendichvu_vn" Caption="Dịch vụ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="6" Width="200px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Ghichu" Caption="Ghi chú" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="8" >
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="i_Lanthu" Caption="Lần thứ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="7" Width="30px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="d_Ngaydieutri" Caption="Ngày thực hiện" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="7" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" Width="80px">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPager PageSize="15">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <ClientSideEvents SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
