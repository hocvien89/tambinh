<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Rp_Taichinh_charrmnguyen.aspx.vb" Inherits="NANO_SPA.Rp_Taichinh_charrmnguyen" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function baocaoClick(s, e) {
            grvtaichinh.Refresh();
        }
    </script>
    <fieldset>
         <legend><span style="font-weight: bold; color: green">Lựa chọn thời gian</span></legend>
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
                    <ClientSideEvents Click="baocaoClick" />
                </dx:ASPxButton>
            </li>
             <li class="text_title">
                <dx:ASPxButton ID="btnExport" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" OnClick="btnExport_Click"
                    runat="server" Text="Xuất excel">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset>
        <dx:ASPxGridView ID="Grv_Taichinh" runat="server" KeyFieldName="uId_Phieudichvu_Chitiet" ClientInstanceName="grvtaichinh" AutoGenerateColumns="false">
            <Columns>
                <dx:GridViewDataTextColumn Caption="Mã phiếu" CellStyle-HorizontalAlign="Center" FieldName="v_Sophieu"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Mã khách hàng" CellStyle-HorizontalAlign="Center" FieldName="v_Makhachang"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Ngày" CellStyle-HorizontalAlign="Center" FieldName="d_Ngay" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Tên khách hàng" CellStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Địa chỉ" CellStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Sô điện thoại" CellStyle-HorizontalAlign="Center" FieldName="v_DienthoaiDD"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Dịch vụ" CellStyle-HorizontalAlign="Center" FieldName="nv_Tendichvu_vn"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Số lần" CellStyle-HorizontalAlign="Center" FieldName="i_Solan_Dieutri"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Giảm giá" CellStyle-HorizontalAlign="Center" FieldName="f_Giamgia"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Voucher/Thẻ" CellStyle-HorizontalAlign="Center" ></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Tiền mặt" CellStyle-HorizontalAlign="Center" ></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Visa card" CellStyle-HorizontalAlign="Center" FieldName="visacard"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Nợ" CellStyle-HorizontalAlign="Center" ></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Ghi chú" CellStyle-HorizontalAlign="Center" ></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Tư vấn viên" CellStyle-HorizontalAlign="Center"  FieldName="tuvanvien"></dx:GridViewDataTextColumn>
            </Columns>
              <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
            <SettingsPager PageSize="10">
                 </SettingsPager>
        </dx:ASPxGridView>
    </fieldset>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
</asp:Content>
