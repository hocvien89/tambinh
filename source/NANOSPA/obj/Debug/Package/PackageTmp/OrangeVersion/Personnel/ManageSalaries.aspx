<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ManageSalaries.aspx.vb" Inherits="NANO_SPA.ManageSalaries" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'a3594590-a6e4-416e-bc1e-05987a93b3c2'}";
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
            if (s.cpIsAccept == "false") {
                alert("Bạn không có quyền xóa khách hàng!");
            }
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }

        }
        var uId_quytrinhluong = "";
        function LoadInfoLuoncoban() {
            var sPara = cbonhanvien.GetValue() + "$" + cbothang.GetText() + "$" + cbonam.GetText();
            var param_dt = "{'sPara':'" + sPara + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadInfoLuong";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "NoInfo") {
                        var uId_Luongcoban = document.getElementById("<%=hdfuIdluongcoban.ClientID%>")
                        var sdata = msg.d.split("$");
                        uId_Luongcoban.value = sdata[0];
                        txtluongcoban.SetText(sdata[2]);
                        txtluongngoaigio.SetText(sdata[3]);
                        txtluongtrachnhiem.SetText(sdata[4]);
                        datengayapdung.SetText(sdata[1]);
                        uId_quytrinhluong = sdata[0];
                        txtphucap.SetText(sdata[5]);
                    }
                    else {
                        clear();
                        var uId_Luongcoban = document.getElementById("<%=hdfuIdluongcoban.ClientID%>")
                        uId_Luongcoban.value = "";
                    }
                },
                error: onFail
            });
        }
        function ShowEditWindow() {
            if (cbonhanvien.GetText() == "") {
                alert("Hãy chọn nhân viên trước!");

                cbonhanvien.ShowDropdown();
            }
            else {
                lblnhanvien.SetText(cbonhanvien.GetText());
                LoadInfoLuoncoban();
                Apcluongcoban.Show();
            }

        }

        function btnexitClick(s, e) {

            Apcluongcoban.Hide();
        }

        function jo_ThousanSereprate(id) {
            var textbox = id;
            id.SetText(jo_FormatMoney(id.GetText().replace(/,/g, "")));
            return false;
        }
        function cbonhanvienchange(s, e) {
            grvdsluong.Refresh();
            LoadInfoLuoncoban();
        }
        function Jo_CheckRole(input) {
            var value = "";
            var param_dt = "{'uId_Chucnang':'" + input + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    value = msg.d
                },
                error: function () {
                    value = "false"
                }
            });
            return value;
        }
        function btnluuluongClick(s, e) {
           
            var chucnang = "FE8B2BFA-9C5F-4A07-8EEA-49EFA4B0B58C"
            if (Jo_CheckRole(chucnang) == "false") {
                alert("Bạn không có quyền thực hiện chức năng này");
                e.processOnServer = false;
            }
            else {
                var sPara
                sPara = cbonhanvien.GetValue() + "$" + cbothang.GetText() + "$" + cbonam.GetText() + "$" +
                    txtngaycong.GetText() + "$" + txtngaynghi.GetText() + "$" + txttienthuong.GetText() + "$" +
                    txttientru.GetText() + "$" + txttamung.GetText();
                var param_dt = "{'sPara':'" + sPara + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/InserTTLuong";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        alert(msg.d);
                        grvdsluong.Refresh();
                    },
                    error: onFail
                });
            }
        }
        function clear() {
            txtluongcoban.SetText("");
            txtluongngoaigio.SetText("");
            txtluongtrachnhiem.SetText("");
            var datenow = new Date();
            datengayapdung.SetDate(datenow);
            txtphucap.SetText("");
            txtluongcoban.Focus();
        }
        function btnqtluongClick(s, e) {
            var uId_Luongcoban = document.getElementById("<%=hdfuIdluongcoban.ClientID%>")
            uId_Luongcoban.value = "";
            clear();
        }

        function cboNamChange(s, e) {
            grvdsluong.Refresh();
        }

        function pupclose(s, e) {
            grvdsluong.Refresh();
        }


    </script>
    <asp:HiddenField ID="hdfuIdluongcoban" runat="server" />
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÝ LƯƠNG</p>
    </div>
    <fieldset class="container-fluid" style="width: 44%; margin: auto">
        <legend><span style="font-weight: bold; color: green">Thiết lập lương</span></legend>
        <table class="info_table container-fluid">
            <tr>
                <td class="info_table_td">Tháng:</td>
                <td class="info_table_td" style="width: 180px">
                    <dx:ASPxComboBox ID="cboThang" runat="server" ValueType="System.String" ClientInstanceName="cbothang" Width="100%">
                        <ClientSideEvents SelectedIndexChanged="cboNamChange" />
                    </dx:ASPxComboBox>
                </td>
                <td class="info_table_td">Năm:</td>
                <td class="info_table_td" style="width: 180px">
                    <dx:ASPxComboBox ID="cboNam" runat="server" ClientInstanceName="cbonam" Width="100%"></dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td class="info_table_td">Nhân viên:</td>
                <td class="info_table_td">
                    <ul>
                        <li style="float: left; width: 78%">
                            <dx:ASPxComboBox ID="cboNhanvien" runat="server" ClientInstanceName="cbonhanvien" Width="100%" ValueType="System.String">
                                <ClientSideEvents SelectedIndexChanged="cbonhanvienchange" />
                            </dx:ASPxComboBox>
                        </li>
                        <li style="float: left">
                            <a id="popup" title="Lương cơ bản" href='javascript:void(0)' onclick="return ShowEditWindow()">
                                <img src="../../../images/btn_Edit.png" /></a>
                        </li>
                    </ul>

                </td>
                <td class="info_table_td">Chức vụ:</td>
                <td class="info_table_td" style="width: 180px">
                    <dx:ASPxComboBox ID="cboChucvu" runat="server" ClientInstanceName="cbochucvu" Width="100%" ValueType="System.String"></dx:ASPxComboBox>
                </td>
            </tr>

            <tr>
                <td class="info_table_td">Ngày công:</td>
                <td class="info_table_td">
                    <dx:ASPxTextBox ID="txtNgaycong" runat="server" ReadOnly="true" ClientInstanceName="txtngaycong" Width="100%"></dx:ASPxTextBox>
                </td>
                <td class="info_table_td">Ngày nghỉ:</td>
                <td class="info_table_td">
                    <dx:ASPxTextBox ID="txtNgaynghi" runat="server" ClientInstanceName="txtngaynghi" Width="100%"></dx:ASPxTextBox>
                </td>
            </tr>

            <tr>
                <td class="info_table_td">Tiền thưởng:</td>
                <td class="info_table_td">
                    <dx:ASPxTextBox ID="txtTienthuong" runat="server" ClientInstanceName="txttienthuong" Width="100%" MaskSettings-Mask="<0..9999999999g><>">
                    </dx:ASPxTextBox>
                </td>
                <td class="info_table_td">Tiền trừ:</td>
                <td class="info_table_td">
                    <dx:ASPxTextBox ID="txtTientru" runat="server" ClientInstanceName="txttientru" Width="100%" MaskSettings-Mask="<0..9999999999g><>"></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="info_table_td">Tạm ứng:</td>
                <td class="info_table_td">
                    <dx:ASPxTextBox ID="txtTamung" runat="server" ClientInstanceName="txttamung" Width="100%" MaskSettings-Mask="<0..9999999999g><>"></dx:ASPxTextBox>
                </td>

            </tr>

            <tr>
                <td class="info_table_td" colspan="3">
                    <ul>
                        <li class="text_title">
                            <dx:ASPxButton ID="btnluuluong" runat="server" ClientInstanceName="btnluuluong" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Text="lưu">
                                <ClientSideEvents Click="btnluuluongClick" />
                            </dx:ASPxButton>
                        </li>
                        <li class="text_title">
                            <dx:ASPxButton ID="btnXuatExcel" runat="server" Image-Url="~/images/Excel-icon.png" ClientInstanceName="btnxuatexcel" OnClick="btnXuatExcel_Click" Text="Excel">
                            </dx:ASPxButton>
                        </li>
                    </ul>

                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="container-fluid" style="width: 96%; margin: auto">
        <legend><span style="font-weight: bold; color: green">Danh sách lương</span></legend>
        <dx:ASPxGridView ID="GrvDsluong" runat="server" KeyFieldName="uId_Nhanvien;uId_Thongtinluong" OnRowDeleting="GrvDsluong_RowDeleting" Width="100%" ClientInstanceName="grvdsluong">
            <Columns>
                
                <dx:GridViewDataTextColumn Caption="Mã nhân viên" FieldName="v_Manhanvien"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Họ tên" FieldName="nv_Hoten_vn"></dx:GridViewDataTextColumn>
              
                <dx:GridViewDataTextColumn Caption="Lương cơ bản" FieldName="f_luongcoban" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ngày công" FieldName="f_Ngaycong"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ngày nghỉ" FieldName="f_Ngaynghi"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Lương ngoài giờ" FieldName="f_Mucluong_Ngoaigio" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Lương trách nhiệm" FieldName="f_Mucluong_Trachnhiem" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Tiền thưởng" FieldName="f_Tienthuong" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Phụ cấp" FieldName="f_phucap" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Tạm ứng" FieldName="f_Tamung" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="tiền trừ" FieldName="f_Tientru" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Hoa hồng" FieldName="f_Hoahong" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Tổng" FieldName="f_tong" PropertiesTextEdit-DisplayFormatString="N0"></dx:GridViewDataTextColumn>
                 <dx:GridViewCommandColumn VisibleIndex="14" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image Url="~/images/btn_Delete.png"></Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
            <ClientSideEvents EndCallback="grid_EndCallback" />
             <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa?" />
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="ExportLuong" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="Apcluongcoban" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Thiết lập lương cơ bản">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="350px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server" Width="300px">
                            <asp:UpdatePanel ID="upKhachhang" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">
                                            <dx:ASPxLabel ID="lblNhanvien" runat="server" ClientInstanceName="lblnhanvien"></dx:ASPxLabel>
                                        </span></legend>

                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Ngày áp dụng:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="dateNgayapdung" runat="server" EditFormatString="dd/MM/yyyy" ClientInstanceName="datengayapdung"></dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Lương cơ bản:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtLuongcoban" runat="server" ClientInstanceName="txtluongcoban" Width="100px" MaskSettings-Mask="<0..9999999999g><>">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Lương ngoài giờ:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtLuongngoaigio" runat="server" ClientInstanceName="txtluongngoaigio" Width="100px" MaskSettings-Mask="<0..9999999999g><>">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Lương trách nhiệm:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtLuongtrachnhiem" runat="server" ClientInstanceName="txtluongtrachnhiem" Width="100px" MaskSettings-Mask="<0..9999999999g><>">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Tiền phụ cấp:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtPhucap" runat="server" ClientInstanceName="txtphucap" Width="100px" MaskSettings-Mask="<0..9999999999g><>"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ghi chú:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtGhichu" runat="server" ClientInstanceName="txtghichu" Width="100%"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="5">
                                                    <div id="diverror" class="error">
                                                        <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                        <asp:Literal ID="ltrSuccess" runat="server"></asp:Literal>
                                                    </div>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td" colspan="2">
                                                    <ul>
                                                        <li class="text_title">
                                                            <dx:ASPxButton ID="btnLuuLuongcoban" runat="server" ClientInstanceName="btnluongcoban" Text="Lưu" OnClick="btnLuuLuongcoban_Click"
                                                                Image-Url="~/images/16x16/save.png">
                                                             
                                                            </dx:ASPxButton>
                                                        </li>
                                                        <li class="text_title">
                                                            <dx:ASPxButton ID="btnLuuQTluong" runat="server" ClientInstanceName="btnqtluong" AutoPostBack="false" Text="Làm mới" Image-Url="~/images/16x16/refresh.png">
                                                                <ClientSideEvents Click="btnqtluongClick" />
                                                            </dx:ASPxButton>
                                                        </li>
                                                        <li class="text_title">
                                                            <dx:ASPxButton ID="btnExit" runat="server" ClientInstanceName="btnexit" Text="Thoát" AutoPostBack="false" Image-Url="~/images/16x16/cancel.png">
                                                                <ClientSideEvents Click="btnexitClick" />
                                                            </dx:ASPxButton>
                                                        </li>
                                                    </ul>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ClientSideEvents CloseUp="pupclose" />
    </dx:ASPxPopupControl>
</asp:Content>
