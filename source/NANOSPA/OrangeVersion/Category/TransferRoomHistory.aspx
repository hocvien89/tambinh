<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="TransferRoomHistory.aspx.vb" Inherits="NANO_SPA.TransferRoomHistory" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script>
        function grid_EndCallback(s, e) {
            var edit = s.GetEditor(1);
            if (s.cpIsEditing) {
                var editor = s.GetEditor(_fieldName);
                if (editor != null) {
                    editor.SelectAll();
                    editor.Focus();
                }
            }
            if (s.cpIsAccept == "false") {
                alert("Bạn không có quyền xóa khách hàng!");
            }
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }

        }
    </script>
    <div class="brest_crum">
         <asp:Literal ID="ltrTitleHeader" Text="LỊCH SỬ CHUYỂN PHÒNG" runat="server"></asp:Literal>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px"></dx:ASPxDateEdit>
            </li>
            <li class="text_title">Key: </li>
            <li class="text_title">
                <dx:ASPxTextBox ID="txt_key" runat="server" Width="100px"></dx:ASPxTextBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <fieldset class="field_tt_right>" style="width: 98%; margin: auto; height: auto">
        <legend><span style="font-weight: bold; color: green;">Lịch sử</span></legend>
        <dx:ASPxGridView ID="dgvDevexpress" runat="server" KeyFieldName="uId_Phieudichvu;uId_Khachhang;uId_TrangthaiKH;uId_Trangthai;uId_Phong" Width="100%">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="v_Sophieu" Settings-AutoFilterCondition="Contains" Caption="Số phiếu" VisibleIndex="0"/>
                <dx:GridViewDataTextColumn FieldName="v_Makhachang" Settings-AutoFilterCondition="Contains" Caption="Mã khách hàng" VisibleIndex="0"/>
                <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Settings-AutoFilterCondition="Contains" Caption="Họ tên" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"/>
                <dx:GridViewDataTextColumn FieldName="v_DienthoaiDD" Settings-AutoFilterCondition="Contains" Caption="Điện thoại" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"/>
                <dx:GridViewDataTextColumn FieldName="tenphongchuyen" Settings-AutoFilterCondition="Contains" Caption="Phòng chuyển" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"/>
                <dx:GridViewDataTextColumn FieldName="d_Ngaylam" PropertiesTextEdit-DisplayFormatString="dd/MM/yyy hh:mm" Caption="Ngày" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" />
                <dx:GridViewDataTextColumn FieldName="phongcuoi" Settings-AutoFilterCondition="Contains" Caption="Phòng hiện tại" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"/>
                <dx:GridViewDataTextColumn FieldName="trangthaicuoi" Settings-AutoFilterCondition="Contains" Caption="Trạng thái hiện tại" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"/>
            </Columns>
              <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
            <SettingsPager PageSize="17" Summary-Text="Trang {0}/{1} ({2} Sự kiện)"></SettingsPager>
            <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
            <ClientSideEvents EndCallback="grid_EndCallback" />
        </dx:ASPxGridView>

        </fieldset>
</asp:Content>
