<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="WarehouseTranfer.aspx.vb" Inherits="NANO_SPA.WarehouseTranfer" %>

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
        function jo_IsString(input) {
            var value = "";
            if (input == "" || input == null || isNaN(input) == true) {
                value = "0";
            }
            else {
                value = input;
            }
            return value;
        }
        function jo_FormatMoney(input) {
            return input.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        function jo_ThousanSereprate(id) {
            var textbox = id;
            id.value = jo_FormatMoney(id.value.replace(/,/g, ""));
            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'d891eb5d-7555-403a-aa2e-7ccd44150acd'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d == "false") {
                        window.location.href = "../../OrangeVersion/Util/DeclineRole.aspx";
                    }
                },
                error: onFail
            });
        });
        function grid_EndCallback(s, e) {
            var edit = s.GetEditor(1);
            if (s.cpIsEditing) {
                var editor = s.GetEditor(_fieldName);
                if (editor != null) {
                    editor.SelectAll();
                    editor.Focus();
                }
            }
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }
        }
        function grid_FocusedRowChanged(s, e) {
            if (s.cpIsEditing) {
                s.UpdateEdit();
            }
        }
        function cbTenvattu_SelectChange(s, e) {
            jo_CreateSession("MaVatTu", ddlMathang.GetValue().toString());
            ddlDonvi.PerformCallback();
        }
        function SaveDetail(s, e) {
            var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
            if (jo_GetSession("MaVatTu") != null) {
                var param_dt = "{'v_MaMathang':'" + jo_GetSession("MaVatTu") + "','f_Soluong':'" + txtSoluong.value + "', 'MaDonVi':'" + ddlDonvi.GetValue().toString() + "'}";
                var pageUrl_xuat = "../../../../Webservice/nano_websv.asmx/InsertPhieuxuatchitiet";
                var pageUrl_nhap = "../../../../Webservice/nano_websv.asmx/InsertPhieunhapchitiet";
                $.ajax({
                    type: "POST",
                    url: pageUrl_xuat,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d == "Success") {
                            client_grid.Refresh();
                        } else {
                            alert(msg.d);
                            return false;
                        }
                    },
                    error: onFail
                });
                $.ajax({
                    type: "POST",
                    url: pageUrl_nhap,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d == "Success") {
                            client_grid.Refresh();
                            jo_RemoveSession("MaVatTu");
                            txtSoluong.value = "1";
                            ddlMathang.SetText("");
                            ddlMathang.Focus();
                            ddlDonvi.PerformCallback();
                            ddlMathang.PerformCallback();
                        }
                    },
                    error: onFail
                });
            }
            else {
                alert("Chọn mặt hàng");
                ddlMathang.Focus();
            }
        }
        function onFail(ex) {
            alert(ex._message + " fail");
            return false;
        }
        function enter_ddlMathang(e) {
            if (e.keyCode == 13) {
                ddlDonvi.Focus();
                return false;
            }
        }
        function enter_ddlDonvi(e) {
            if (e.keyCode == 13) {
                var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
                txtSoluong.focus();
                return false;
            }
        }
        function enter_txtSoluong(e) {
            if (e.keyCode == 13) {
                btnLuuchitiet.Focus();
                return false;
            }
        }
        function ShowDSPopup(s, e) {
            client_dgvDanhsachphieu.Refresh();
            pcDanhsachphieu.Show();
            return false;
        }
        //Chon danh sach phieu
        function SelChanged_dsphieu(s, e) {
            if (!e.isSelected) {
            } else {
                client_dgvDanhsachphieu.GetRowValues(e.visibleIndex, 'uId_Phieuxuat;v_Maphieuxuat;uId_Khachhang', OnGridSelectionDSPhieuComplete);
            }
        }
        function OnGridSelectionDSPhieuComplete(values) {
            jo_CreateSession("uId_Phieuxuat", values[0]);
            jo_CreateSession("uId_Khachhang", values[2]);
            client_grid.Refresh();
            var param_dt = "{'uId_Phieuxuat':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuXuat";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCall,
                error: onFail
            });
        }
        function OnSuccessCall(msg) {
            if (msg.d != "") {
                
            }
        }
        function ClosePopup() {
            pcDanhsachphieu.Hide();
            return false;
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>CHUYỂN KHO</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin phiếu chuyển</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Số phiếu:
                    </td>
                    <td class="info_table_td">
                        <asp:TextBox ID="txtMaphieu" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                    </td>
                    <td class="info_table_td">Ngày chuyển:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deNgaychuyen" ClientInstanceName="deNgaychuyen" Style="float: left; margin-right: 8px;" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Từ kho
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDMTuKho" ClientInstanceName="ddlDMTuKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Đến kho:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDMDenKho" ClientInstanceName="ddlDMDenKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Nhân viên:
                    </td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxComboBox ID="ddlNhanvien" ClientInstanceName="ddlNhanvien" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxButton ID="btnLuu" OnClick="btnLuu_Click" ClientInstanceName="btnLuu" Image-Url="~/images/16x16/save.png" AutoPostBack="true" Style="float: left; margin-left: 10px" runat="server" Text="Lưu phiếu">
                            <Image Url="~/images/16x16/save.png"></Image>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnClear" OnClick="btnClear_Click" Image-Url="~/images/16x16/page_white.png" AutoPostBack="true" Style="float: left; margin-left: 10px" ClientInstanceName="btnClear" runat="server" Text="Làm mới">
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnDanhsach" ClientInstanceName="btnDanhsach" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Danh sách phiếu">
                            <Image Url="~/images/16x16/table.png"></Image>
                            <ClientSideEvents Click="ShowDSPopup" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Phiếu chi tiết</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Thuốc:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlMathang" onkeypress="return enter_ddlMathang(event)" EnableCallbackMode="true" ClientInstanceName="ddlMathang" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Mathang" ValueType="System.String" TextFormatString="{0}-{1}"
                            Width="300px" CssClass="ddlMathang" DropDownWidth="500px" DropDownStyle="DropDown">
                            <Columns>
                                <dx:ListBoxColumn FieldName="v_MaMathang" Caption="Mã" Width="100%" />
                                <dx:ListBoxColumn FieldName="nv_TenMathang_vn" Caption="Tên vật tư" Width="100%" />
                                <dx:ListBoxColumn FieldName="tendonvi" Caption="Đơn vị (nhỏ nhất)" Width="90px" />
                                <dx:ListBoxColumn FieldName="f_SL_Ton" Caption="Số lượng tồn" Width="70px" />
                            </Columns>
                            <ClientSideEvents SelectedIndexChanged="cbTenvattu_SelectChange" />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td td_0_ipad">Đơn vị:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <dx:ASPxComboBox ID="ddlDonvi" OnCallback="ddlDonvi_Callback" onkeypress="return enter_ddlDonvi(event)" ClientInstanceName="ddlDonvi" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="86px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td td_0_ipad">Số lượng:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <asp:TextBox ID="txtSoluong" onkeypress="return enter_txtSoluong(event)" Text="1" runat="server" Width="43px" CssClass="nano_textbox"></asp:TextBox>
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <dx:ASPxButton ID="btnLuuchitiet" ClientInstanceName="btnLuuchitiet" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Thêm thuốc">
                            <Image Url="~/images/16x16/add.png"></Image>
                            <ClientSideEvents Click="SaveDetail" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" OnRowDeleting="dgvDevexpress_RowDeleting" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Phieuxuat_Chitiet"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieuxuat_Chitiet"
                Name="uId_Phieuxuat_Chitiet">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên hàng" FieldName="nv_TenMathang_vn"
                Name="nv_TenMathang_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="50px" HeaderStyle-HorizontalAlign="Center" Caption="ĐVT" FieldName="tendonvi"
                Name="tendonvi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="60px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="120px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Đơn giá:" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="120px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Giảm giá:" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Width="140px" Caption="Thành tiền" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Width="200px" Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Ghichu" Name="nv_Ghichu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image">
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton>
                    <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                </UpdateButton>
                <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                    <Image AlternateText="Xóa" Url="~/images/btn_Delete.png">
                    </Image>
                </DeleteButton>
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="grid_EndCallback" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxPopupControl ID="pcDanhsachphieu" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDanhsachphieu"
        HeaderText="Danh sách phiếu" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDanhsachphieu.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="1200px" Height="500px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <asp:UpdatePanel ID="upKhachhang" runat="server">
                                <ContentTemplate>
                                    <asp:Literal ID="ltrErrorPuPhieu" runat="server"></asp:Literal>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Lọc danh sách phiếu</span></legend>
                                        <table class="info_table">
                                            <tbody>
                                                <tr>
                                                    <td class="info_table_td">Kho:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxComboBox ID="ddlDsKho" ClientInstanceName="ddlDsKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" runat="server" ValueType="System.String">
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    <td class="info_table_td">Từ ngày:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxDateEdit ID="deTungay" ClientInstanceName="deTungay" Style="float: left; margin-right: 8px;" Width="130px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                            runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                    <td class="info_table_td">Đến ngày:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxDateEdit ID="deDenNgay" ClientInstanceName="deDenNgay" Style="float: left; margin-right: 8px;" Width="130px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                            runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxButton ID="btnFilter" OnClick="btnFilter_Click" ClientInstanceName="btnFilter" Image-Url="~/images/16x16/filter.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Lọc">
                                                            <Image Url="~/images/16x16/filter.png"></Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </fieldset>
                                    <div style="clear: both"></div>
                                    <dx:ASPxGridView ID="dgvDanhsachphieu" OnRowDeleting="dgvDanhsachphieu_RowDeleting" runat="server" ClientInstanceName="client_dgvDanhsachphieu"
                                        AutoGenerateColumns="false" KeyFieldName="uId_Phieuxuat;v_Maphieuxuat" SettingsPager-PageSize="8"
                                        SettingsPager-Position="Bottom">
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieuxuat"
                                                Name="uId_Phieuxuat">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang"
                                                Name="uId_Khachhang">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="200px" Caption="Số phiếu" FieldName="v_Maphieuxuat"
                                                Name="v_Maphieuxuat">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="90px" Caption="Ngày lập" FieldName="d_Ngayxuat"
                                                Name="d_Ngayxuat">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Nội dung" Width="700px" FieldName="nv_Noidungxuat_vn"
                                                Name="nv_Noidungxuat_vn">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Xuất từ kho" FieldName="nv_Tenkho_vn"
                                                Name="nv_Tenkho_vn">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn VisibleIndex="5" Width="30px" ButtonType="Image">
                                                <DeleteButton Visible="true">
                                                    <Image AlternateText="Delete" Url="~/images/btn_Delete.png" />
                                                </DeleteButton>
                                            </dx:GridViewCommandColumn>
                                        </Columns>
                                        <SettingsEditing Mode="Inline" />
                                        <SettingsPager PageSize="7">
                                        </SettingsPager>
                                        <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                        <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged_dsphieu(s, e); }" />
                                        <Styles>
                                            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                            </AlternatingRow>
                                        </Styles>
                                    </dx:ASPxGridView>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="upKhachhang" DisplayAfter="0" DynamicLayout="false">
                                        <ProgressTemplate>
                                            <img alt="In progress..." src="../../images/progress.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
