<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CustomerCare.aspx.vb" Inherits="NANO_SPA.CustomerCare" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
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
    <%--    <script type="text/javascript">
        function trim(str) {
            return str.replace(/^\s+|\s+$/g, "");
        }
        function GetYearFromAge() {
            var age = $("#<%=txtTuoi.ClientID %>").val();
            var currentTime = new Date()
            var year = currentTime.getFullYear();
            var ageyear = new Date("01/01/" + (year - age));
            deNgaysinh.SetDate(ageyear);
        }
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            var uId_KH_Tiemnang = jo_GetSession("uId_KH_Tiemnang");
            if (uId_KH_Tiemnang != "" && uId_KH_Tiemnang != null) {
            }
        });

        var _fieldName = '';
        function grid_RowDblClick(s, e) {
            s.StartEditRow(e.visibleIndex);
        }
        function grid_FocusedRowChanged(s, e) {
            if (s.cpIsEditing) {
                s.UpdateEdit();
            }
        }

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
        //Show popup add or edit customer
        function ShowEditWindow() {
            pcAddKhachhang.Show();
            var txtDienthoai = document.getElementById("<%=txtDienthoai.ClientID%>");
            txtDienthoai.focus();
        }
        function ShowAddWindow() {
            pcAddKhachhang.Show();
            ClearText();
        }
        function ShowWorkWindow(uId_KH_Tiemnang, uId_Khachhang, uId_Chuyendoi) {
            //jo_CreateSession("uId_KH_Tiemnang", uId_KH_Tiemnang);
            //jo_CreateSession("uId_Khachhang", uId_Khachhang);
            //jo_CreateSession("uId_Chuyendoi", uId_Chuyendoi);
            jo_CreateSession("tags", "");
            window.location.href = "../../OrangeVersion/Marketing/AddWork.aspx?uId_KH_Tiemnang="+uId_KH_Tiemnang+"&uId_Khachhang="+uId_Khachhang;
            return false;
        }
        function ClosePopup(s, e) {
            jo_RemoveSession("uId_KH_Tiemnang");
            jo_RemoveSession("uId_Chuyendoi");
            jo_RemoveSession("uId_Khachhang");
            pcAddKhachhang.Hide();
            PcImportExcel.Hide();
            client_grid.Refresh();
        }
        function CheckExist(type, value) {
            var rs = "";
            if (type == "email") {
                var param_dt = "{'SDT':'N/A', 'Email':'" + value + "'}";
            }
            if (type == "sdt") {
                var param_dt = "{'SDT':'" + value + "', 'Email':'N/A'}";
            }
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckExistEmailSDT";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    rs = msg.d;
                },
                error: onFail
            });
            return rs;
        }
        function OkClick(s, e) {
            var txtEmail = document.getElementById("<%=txtEmail.ClientID %>");
            var txtSDT = document.getElementById("<%=txtDienthoai.ClientID %>");
            var txtHoten = document.getElementById("<%=txtHoten.ClientID%>");
            var txtMaKH = document.getElementById("<%=txtMaKH.ClientID%>");
            var ltrError = document.getElementById("<%=ltrError.ClientID%>");
            var error = document.getElementById("error");
            if (txtMaKH.value == "") {
                e.processOnServer = false;
                txtMaKH.focus();
                error.innerHTML = "Chưa nhập mã khách hàng";
            } else if (txtHoten.value == "") {
                e.processOnServer = false;
                txtHoten.focus();
                error.innerHTML = "Chưa nhập tên khách hàng";
            } else if (txtSDT.value != "") {
                if (CheckExist("sdt", txtSDT.value) == "existsdt") {
                    error.innerHTML = "Số điện thoại đã tồn tại!";
                    e.processOnServer = false;
                    txtSDT.focus();
                }
                else if (isNaN(txtSDT.value)) {
                    error.innerHTML = "Số điện thoại chỉ được nhập số"
                    e.processOnServer = false;
                    txtSDT.value = "";
                    txtSDT.focus();
                }
            } else if (txtEmail.value != "") {
                if (CheckExist("email", txtEmail.value) == "existemail") {
                    error.innerHTML = "Email đã tồn tại!";
                    e.processOnServer = false;
                    txtEmail.focus();
                }
            }
        }
        function onFail(ex) {
            alert(ex._message + " fail");
            return false;
        }
        //CLEAR TEXT
        function ClearText() {
            var txtMaKH = document.getElementById("<%=txtMaKH.ClientID %>");
            var txtHoten = document.getElementById("<%=txtHoten.ClientID %>");
            var txtDiachi = document.getElementById("<%=txtDiachi.ClientID%>");
            var txtDienthoai = document.getElementById("<%=txtDienthoai.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            txtHoten.value = "";
            txtDiachi.value = "";
            txtDienthoai.value = "";
            deNgayden.SetDate(new Date());
            deNgaysinh.SetDate(new Date());
            txtEmail.value = "";
            txtGhichu.value = "";
            jo_RemoveSession("uId_KH_Tiemnang");
            jo_RemoveSession("uId_Chuyendoi");
            var error = document.getElementById("error");
            var success = document.getElementById("success");
            if (error != null)
                error.innerHTML = "";
            if (success != null)
                success.innerHTML = "";
            txtDienthoai.focus();
            //Tao moi ma khach hang
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateNewCustomerCode";
            $.ajax({
                type: "POST",
                url: pageUrl,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        txtMaKH.value = msg.d;
                    }
                },
                error: onFail
            });
        }
        function ClearTextCus(s, e) {
            ClearText();
        }
        //Su kien khi chon 1 dong
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                client_grid.GetRowValues(e.visibleIndex, 'v_Makhachang;uId_KH_Tiemnang;uId_Chuyendoi;uId_Khachhang', OnGridSelectionComplete);
            }
        }
        function OnGridSelectionComplete(values) {
            jo_CreateSession("uId_KH_Tiemnang", values[1]);
            jo_CreateSession("uId_Chuyendoi", values[2]);
            jo_CreateSession("uId_Khachhang", values[3]);
            var param_dt = "{'uId_KHTiemnang':'" + values[1] + "','uId_Chuyendoi':'" + values[2] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinKhachHangTiemNang";
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
                var defaultdata = msg.d.split("$");
                var txtMaKH = document.getElementById("<%=txtMaKH.ClientID %>");
                var txtHoten = document.getElementById("<%=txtHoten.ClientID %>");
                var txtDiachi = document.getElementById("<%=txtDiachi.ClientID%>");
                var txtDienthoai = document.getElementById("<%=txtDienthoai.ClientID%>");
                var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var date_ngayden = new Date(defaultdata[0]);
                deNgayden.SetDate(date_ngayden);
                ddlDanhgia.SetValue(defaultdata[10]);
                txtMaKH.value = defaultdata[1];
                txtHoten.value = defaultdata[2];
                var date_ngaysinh = new Date(defaultdata[3]);
                deNgaysinh.SetDate(date_ngaysinh);
                ddlGioitinh.SetValue(ConvertSex(defaultdata[4]));
                txtDiachi.value = defaultdata[5];
                txtDienthoai.value = defaultdata[6];
                txtEmail.value = defaultdata[7];
                ddlCuahang.SetValue(defaultdata[8]);
                txtGhichu.value = defaultdata[9];
            }
        }

        //Enter key function Form
        function enter_txtHoten(e) {
            var txtHoten = document.getElementById("<%=txtHoten.ClientID%>");
            if (e.keyCode == 13) {
                if (txtHoten.value != "") {
                    deNgaysinh.Focus();
                    txtHoten.value = trim(txtHoten.value).toUpperCase();
                }
                return false;
            }
            txtHoten.value = txtHoten.value.toUpperCase();
        }
        function enter_deNgaysinh(e) {
            if (e.keyCode == 13) {
                //var txtTuoi = document.getElementById();
                //var currentTime = new Date()
                //var year = currentTime.getFullYear()
                //txtTuoi.value = year - parseInt(deNgaysinh.GetText().split("/")[2]);
                ddlGioitinh.Focus();
                return false;
            }
        }
        function enter_ddlGioitinh(e) {
            if (e.keyCode == 13) {
                var txtDiachi = document.getElementById("<%=txtDiachi.ClientID%>");
                txtDiachi.focus();
                return false;
            }
        }
        function enter_txtDiachi(e) {
            if (e.keyCode == 13) {
                var txtDienthoai = document.getElementById("<%=txtDienthoai.ClientID%>");
                txtDienthoai.focus();
                return false;
            }
        }
        function enter_txtDienthoai(e) {
            if (e.keyCode == 13) {
                var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
                txtEmail.focus();
                return false;
            }
        }
        function enter_txtEmail(e) {
            if (e.keyCode == 13) {
                ddlCuahang.Focus();
                return false;
            }
        }
        function enter_ddlCuahang(e) {
            if (e.keyCode == 13) {
                ddlDanhgia.Focus();
                return false;
            }
        }
        function enter_ddlDanhgia(e) {
            if (e.keyCode == 13) {
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                txtGhichu.focus();
                return false;
            }
        }
        function enter_txtGhichu(e) {
            if (e.keyCode == 13) {
                btOk.Focus();
                return false;
            }
        }
        function ShowAddWindowimport() {
            PcImportExcel.Show();
        }

        function Reloadgrvkhachhang(s, e) {
            grv_KHHethong.Refresh();
            grv_chamsoc.Refresh();
            client_grid.Refresh();
            e.processOnServer = false;
        }

        function checkAll(s, e) {
            if (chkall.GetChecked() == true) {
                detungay.SetEnabled(false);
                dedenngay.SetEnabled(false);

            }
            else {
                detungay.SetEnabled(true);
                dedenngay.SetEnabled(true);
            }
            //grv_KHHethong.Refresh();
            //client_grid.Refresh();
            //grv_chamsoc.Refresh();
            var tabindex = pgcchamsockhachhang.GetActiveTabIndex();
            switch (tabindex) {
                case 0:
                    grv_chamsoc.Refresh();
                    break;
                case 1:
                    client_grid.Refresh();
                    break;
                case 2:
                    grv_KHHethong.Refresh();
                    break;
            }
            e.processOnServer = false;
        }
        function rdbChamsoc(s, e) {
            grv_chamsoc.Refresh();
        }

        function tabchange(s, e) {
            var tabindex = s.GetActiveTabIndex();
            switch (tabindex) {
                case 0:
                    grv_chamsoc.Refresh();
                    break;
                case 1:
                    client_grid.Refresh();
                    break;
                case 2:
                    grv_KHHethong.Refresh();
                    break;
            }
        }

    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>CHĂM SÓC KHÁCH HÀNG</p>
    </div>
    <div style="clear: both"></div>

    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">
                <dx:ASPxCheckBox ID="chkViewAll" OnCheckedChanged="chkViewAll_CheckedChange" AutoPostBack="true" Text="Xem tất cả" runat="server" ClientInstanceName="chkall">
                    <ClientSideEvents CheckedChanged="checkAll" />
                </dx:ASPxCheckBox>
            </li>
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="deTuNgay" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" ClientInstanceName="detungay"
                    runat="server">
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="deDenNgay" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" ClientInstanceName="dedenngay"
                    runat="server">
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" OnClick="btnFilter_Click" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc">
                    <ClientSideEvents Click="Reloadgrvkhachhang" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnThemmoi" Image-Url="~/images/16x16/add.png" ClientInstanceName="btnThemmoi" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Thêm mới (F2)">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_ExportExcel" Image-Url="~/images/16x16/export_excel.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Xuất Excel">
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_ImportExcel" Visible="false" Image-Url="~/images/Excel-icon.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Nhập Excel">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindowimport(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_Report" Visible="false" Image-Url="~/images/16x16/report_go.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Báo cáo">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <div class="form-group">
        <dx:ASPxPageControl ID="pgcChamsockhachhang" runat="server" Width="98%" ClientInstanceName="pgcchamsockhachhang">
            <%-- danh sach khach hang moi su dung dich vu cua cua hang thoi gian gan nhat
                uu tien cham soc ngay --%>
            <TabPages>
                <dx:TabPage Text="Danh sách ưu tiên" ActiveTabStyle-Font-Bold="true" TabStyle-Font-Bold="true" TabStyle-ForeColor="Red" ActiveTabStyle-ForeColor="White">
                    <ContentCollection>
                        <dx:ContentControl>
                            <fieldset>
                                <ul>
                                    <li class="text_title">
                                        <dx:ASPxRadioButton ID="rdb_Dichvu" ClientInstanceName="rdb_Dichvu" runat="server" Text="Mua dịch vụ"
                                            GroupName="chamsoc">
                                            <ClientSideEvents CheckedChanged="rdbChamsoc" />
                                        </dx:ASPxRadioButton>
                                    </li>
                                    <li class="text_title">
                                        <dx:ASPxRadioButton ID="rdb_Dieutri" ClientInstanceName="rdb_dieutri" runat="server" Text="Mới điều trị"
                                            GroupName="chamsoc">
                                            <ClientSideEvents CheckedChanged="rdbChamsoc" />
                                        </dx:ASPxRadioButton>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset>
                                <dx:ASPxGridView ID="grv_Chamsoc" runat="server" ClientInstanceName="grv_chamsoc"
                                    AutoGenerateColumns="false" KeyFieldName="uId_KH_Tiemnang" SettingsPager-PageSize="8"
                                    SettingsPager-Position="Bottom">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="uId_Khachhang" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                            Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_KH_Tiemnang"
                                            Name="uId_KH_Tiemnang">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                            Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Chuyendoi"
                                            Name="uId_Chuyendoi">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                            Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã KH" FieldName="v_Makhachang"
                                            Name="v_Makhachang">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                            Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Tên khách hàng" FieldName="nv_Hoten_vn"
                                            Name="nv_Hoten_vn">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Width="90" VisibleIndex="2" Caption="Ngày sinh" Settings-AutoFilterCondition="Contains"
                                            HeaderStyle-HorizontalAlign="Center" FieldName="d_Ngaysinh" Name="d_Ngaysinh" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Địa chỉ" Settings-AutoFilterCondition="Contains"
                                            HeaderStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn" Name="nv_Diachi_vn">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Điện thoại" Width="100px" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Email" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="v_Email" Name="v_Email">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Visible="false" Caption="Lịch sử chăm sóc da" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="nv_Hoten_en" Name="nv_Hoten_en">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Visible="false" Caption="Lịch sử chăm sóc sức khỏe" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="nv_Diachi_en" Name="nv_Diachi_en">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ngày" Width="90" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="d_Ngay" Name="d_Ngay" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="Ghichu" Name="Ghichu">
                                        </dx:GridViewDataTextColumn>
                                        <%--                                        <dx:GridViewDataTextColumn Caption="Thuộc cửa hàng" Settings-AutoFilterCondition="Contains"
                                            VisibleIndex="3" FieldName="nv_Tencuahang_vn" Name="nv_Tencuahang_vn">
                                        </dx:GridViewDataTextColumn>--%>
                                        <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <a id="popup" title="Thêm công việc" href='javascript:void(0)' onclick="return <%# String.Format("ShowWorkWindow('{0}','{1}','{2}')", Eval("uId_KH_Tiemnang"), Eval("uId_Khachhang"), Eval("uId_Chuyendoi")).ToString%>">
                                                    <img src="../../../images/16x16/application_link.png" /></a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <%--                                        <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return ShowEditWindow()">
                                                    <img src="../../../images/btn_Edit.png" /></a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>--%>
                                    </Columns>
                                    <Templates>
                                        <DetailRow>
                                            <div style="padding: 3px 3px 2px 3px">
                                                <dx:ASPxPageControl ID="pageControl" runat="server" Width="100%" EnableCallBacks="true">
                                                    <TabPages>
                                                        <dx:TabPage Text="Phiếu dịch vụ" Visible="true">
                                                            <ContentCollection>
                                                                <dx:ContentControl ID="ContentControl1" runat="server">
                                                                    <dx:ASPxGridView ID="dgvPhieudichvu" OnBeforePerformDataSelect="dgvPhieudichvu_BeforePerformDataSelect" runat="server"
                                                                        KeyFieldName="uId_Phieudichvu" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Số phiếu" FieldName="v_Sophieu"
                                                                                Name="v_Sophieu">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="d_Ngay"
                                                                                Name="d_Ngay">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dathanhtoan"
                                                                                Name="f_Dathanhtoan">
                                                                                <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Còn nợ" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="tienno"
                                                                                Name="tienno">
                                                                                <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu_vn"
                                                                                Name="nv_Ghichu_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <%--                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                            <DataItemTemplate>
                                                                                <a id="popup" title="Thanh toán công nợ" href='javascript:void(0)' onclick="return <%# String.Format("ThanhtoancongnoDV('{0}', '{1}')", Eval("uId_Phieudichvu"), Eval("v_Sophieu")).ToString%>">
                                                                                    <img src="../../../images/16x16/coins_in_hand.png" /></a>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                            <DataItemTemplate>
                                                                                <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieudichvu('{0}', '{1}','{2}','{3}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("v_Sophieu"), Eval("d_Ngay")).ToString%>">
                                                                                    <img src="../../../images/bub.png" /></a>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>--%>
                                                                        </Columns>
                                                                        <Templates>
                                                                            <DetailRow>
                                                                                <div style="padding: 3px 3px 2px 3px">
                                                                                    <dx:ASPxGridView ID="dgvPhieuchitiet" OnBeforePerformDataSelect="dgvPhieuchitiet_BeforePerformDataSelect" runat="server"
                                                                                        KeyFieldName="uId_Phieudichvu_Chitiet" Width="100%">
                                                                                        <Columns>
                                                                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="" FieldName="uId_Phieudichvu" Name="uId_Phieudichvu">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="" FieldName="uId_Dichvu" Name="uId_Dichvu">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn" Name="nv_Tendichvu_vn">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Tổng S.Lần" FieldName="f_Solan" Name="f_Solan">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Đã ĐT" FieldName="i_SL_daDieutri" Name="i_SL_daDieutri">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Đơn giá" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Giảm giá" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Thành tiền" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                        </Columns>
                                                                                        <Templates>
                                                                                            <DetailRow>
                                                                                                <div style="padding: 3px 3px 2px 3px">
                                                                                                    <dx:ASPxGridView ID="dgvQTdieutri" OnBeforePerformDataSelect="dgvQTdieutri_BeforePerformDataSelect" runat="server"
                                                                                                        KeyFieldName="uId_QT_Dieutri" Width="100%">
                                                                                                        <Columns>
                                                                                                            <dx:GridViewDataTextColumn Visible="false" HeaderStyle-HorizontalAlign="Center"
                                                                                                                FieldName="uId_QT_Dieutri" Name="uId_QT_Dieutri">
                                                                                                            </dx:GridViewDataTextColumn>
                                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                                Caption="Lần thứ" FieldName="i_Lanthu" Name="i_Lanthu">
                                                                                                            </dx:GridViewDataTextColumn>
                                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                                Caption="Ngày điều trị" FieldName="d_Ngaydieutri" Name="d_Ngaydieutri">
                                                                                                            </dx:GridViewDataTextColumn>
                                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                                Caption="Nhân viên" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
                                                                                                            </dx:GridViewDataTextColumn>
                                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                                Caption="Tên trạng thái" FieldName="nv_Tentrangthai_vn" Name="nv_Tentrangthai_vn">
                                                                                                            </dx:GridViewDataTextColumn>
                                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                                Caption="Ghi chú" FieldName="nv_Ghichu" Name="nv_Ghichu">
                                                                                                            </dx:GridViewDataTextColumn>
                                                                                                        </Columns>
                                                                                                    </dx:ASPxGridView>
                                                                                                </div>
                                                                                            </DetailRow>
                                                                                        </Templates>
                                                                                        <SettingsDetail ShowDetailRow="true" />
                                                                                    </dx:ASPxGridView>
                                                                                </div>
                                                                            </DetailRow>
                                                                        </Templates>
                                                                        <SettingsDetail ShowDetailRow="true" />
                                                                        <Settings ShowFooter="true" />
                                                                        <TotalSummary>
                                                                            <dx:ASPxSummaryItem FieldName="f_Dathanhtoan" SummaryType="Sum" />
                                                                            <dx:ASPxSummaryItem FieldName="tienno" SummaryType="Sum" />
                                                                        </TotalSummary>
                                                                    </dx:ASPxGridView>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:TabPage>
                                                    </TabPages>
                                                </dx:ASPxPageControl>
                                            </div>
                                        </DetailRow>
                                    </Templates>
                                    <SettingsDetail ShowDetailRow="true" />
                                    <SettingsEditing Mode="Inline" />
                                    <SettingsPager PageSize="15">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                    <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                    <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                    <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                    <Styles>
                                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                        </AlternatingRow>
                                    </Styles>
                                </dx:ASPxGridView>
                            </fieldset>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
            <%-- danh sach khach hang tiem nang --%>
            <TabPages>
                <dx:TabPage Text="Danh sách tiềm năng" ActiveTabStyle-Font-Bold="true" TabStyle-Font-Bold="true" TabStyle-ForeColor="Blue" ActiveTabStyle-ForeColor="White">
                    <ContentCollection>
                        <dx:ContentControl>
                            <dx:ASPxGridView ID="dgvDevexpress" runat="server" ClientInstanceName="client_grid" OnRowDeleting="dgvDevexpress_RowDeleting"
                                AutoGenerateColumns="false" KeyFieldName="uId_KH_Tiemnang" SettingsPager-PageSize="8"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="uId_Khachhang" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_KH_Tiemnang"
                                        Name="uId_KH_Tiemnang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Chuyendoi"
                                        Name="uId_Chuyendoi">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã KH" FieldName="v_Makhachang"
                                        Name="v_Makhachang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Tên khách hàng" FieldName="nv_Hoten_vn"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="90" VisibleIndex="2" Caption="Ngày sinh" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" FieldName="d_Ngaysinh" Name="d_Ngaysinh" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Địa chỉ" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn" Name="nv_Diachi_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Điện thoại" Width="100px" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Email" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="v_Email" Name="v_Email">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" Caption="Lịch sử chăm sóc da" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="nv_Hoten_en" Name="nv_Hoten_en">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" Caption="Lịch sử chăm sóc sức khỏe" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="nv_Diachi_en" Name="nv_Diachi_en">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ngày nhập" Width="90" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="d_Ngaynhap" Name="d_Ngaynhap" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="Ghichu" Name="Ghichu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Thuộc cửa hàng" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="nv_Tencuahang_vn" Name="nv_Tencuahang_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Dánh giá" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="danhgia" Name="danhgia">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Thêm công việc" href='javascript:void(0)' onclick="return <%# String.Format("ShowWorkWindow('{0}','{1}','{2}')", Eval("uId_KH_Tiemnang"), Eval("uId_Khachhang"), Eval("uId_Chuyendoi")).ToString%>">
                                                <img src="../../../images/16x16/application_link.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return ShowEditWindow()">
                                                <img src="../../../images/btn_Edit.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
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
                                <%-- <Templates>
                                    <DetailRow>
                                        <div style="padding: 3px 3px 2px 3px">
                                            <dx:ASPxPageControl ID="pageControl" runat="server" Width="100%" EnableCallBacks="true">
                                                <TabPages>
                                                    <dx:TabPage Text="Phiếu dịch vụ" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                                <dx:ASPxGridView ID="dgvPhieudichvu" OnBeforePerformDataSelect="dgvPhieudichvu_BeforePerformDataSelect" runat="server"
                                                                    KeyFieldName="uId_Phieudichvu" Width="100%">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Số phiếu" FieldName="v_Sophieu"
                                                                            Name="v_Sophieu">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="d_Ngay"
                                                                            Name="d_Ngay">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dathanhtoan"
                                                                            Name="f_Dathanhtoan">
                                                                            <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Còn nợ" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="tienno"
                                                                            Name="tienno">
                                                                            <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu_vn"
                                                                            Name="nv_Ghichu_vn">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                            <DataItemTemplate>
                                                                                <a id="popup" title="Thanh toán công nợ" href='javascript:void(0)' onclick="return <%# String.Format("ThanhtoancongnoDV('{0}', '{1}')", Eval("uId_Phieudichvu"), Eval("v_Sophieu")).ToString%>">
                                                                                    <img src="../../../images/16x16/coins_in_hand.png" /></a>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                            <DataItemTemplate>
                                                                                <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieudichvu('{0}', '{1}','{2}','{3}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("v_Sophieu"), Eval("d_Ngay")).ToString%>">
                                                                                    <img src="../../../images/bub.png" /></a>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <Templates>
                                                                        <DetailRow>
                                                                            <div style="padding: 3px 3px 2px 3px">
                                                                                <dx:ASPxGridView ID="dgvPhieuchitiet" OnBeforePerformDataSelect="dgvPhieuchitiet_BeforePerformDataSelect" runat="server"
                                                                                    KeyFieldName="uId_Phieudichvu_Chitiet" Width="100%">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="" FieldName="uId_Phieudichvu" Name="uId_Phieudichvu">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="" FieldName="uId_Dichvu" Name="uId_Dichvu">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn" Name="nv_Tendichvu_vn">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Tổng S.Lần" FieldName="f_Solan" Name="f_Solan">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Đã ĐT" FieldName="i_SL_daDieutri" Name="i_SL_daDieutri">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Đơn giá" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Giảm giá" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Thành tiền" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <%--                                                                <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                    <DataItemTemplate>
                                                                        <a id="popup" title="Thiết lập liệu trình dịch vụ <%#Eval("nv_Tendichvu_vn")%>" href='javascript:void(0)' onclick="return <%# String.Format("Thietlaplieutrinh('{0}', '{1}', '{2}','{3}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("uId_Dichvu"), Eval("uId_Phieudichvu_Chitiet")).ToString%>">
                                                                            <img src="../../../images/bub.png" /></a>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                                                    </Columns>
                                                                                    <Templates>
                                                                                        <DetailRow>
                                                                                            <div style="padding: 3px 3px 2px 3px">
                                                                                                <dx:ASPxGridView ID="dgvQTdieutri" OnBeforePerformDataSelect="dgvQTdieutri_BeforePerformDataSelect" runat="server"
                                                                                                    KeyFieldName="uId_QT_Dieutri" Width="100%">
                                                                                                    <Columns>
                                                                                                        <dx:GridViewDataTextColumn Visible="false" HeaderStyle-HorizontalAlign="Center"
                                                                                                            FieldName="uId_QT_Dieutri" Name="uId_QT_Dieutri">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Lần thứ" FieldName="i_Lanthu" Name="i_Lanthu">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Ngày điều trị" FieldName="d_Ngaydieutri" Name="d_Ngaydieutri">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Nhân viên" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Tên trạng thái" FieldName="nv_Tentrangthai_vn" Name="nv_Tentrangthai_vn">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Ghi chú" FieldName="nv_Ghichu" Name="nv_Ghichu">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                    </Columns>
                                                                                                </dx:ASPxGridView>
                                                                                            </div>
                                                                                        </DetailRow>
                                                                                    </Templates>
                                                                                    <SettingsDetail ShowDetailRow="true" />
                                                                                </dx:ASPxGridView>
                                                                            </div>
                                                                        </DetailRow>
                                                                    </Templates>
                                                                    <SettingsDetail ShowDetailRow="true" />
                                                                    <Settings ShowFooter="true" />
                                                                    <TotalSummary>
                                                                        <dx:ASPxSummaryItem FieldName="f_Dathanhtoan" SummaryType="Sum" />
                                                                        <dx:ASPxSummaryItem FieldName="tienno" SummaryType="Sum" />
                                                                    </TotalSummary>
                                                                </dx:ASPxGridView>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Phiếu xuất" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                                <div style="padding: 3px 3px  3px">
                                                                    <dx:ASPxGridView ID="dgvPhieuxuat" OnBeforePerformDataSelect="dgvPhieuxuat_BeforePerformDataSelect" runat="server"
                                                                        KeyFieldName="uId_Phieuxuat" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Số phiếu" FieldName="v_Maphieuxuat" Name="v_Maphieuxuat">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Ngày xuất" FieldName="d_PXNgayxuat" Name="d_PXNgayxuat">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Nội dung xuất" FieldName="nv_Noidungxuat_vn" Name="nv_Noidungxuat_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Nhân viên xuất" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Đã thanh toán" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongtienthuc" Name="f_Tongtienthuc">
                                                                                <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Còn nợ" FieldName="tienno" Name="tienno">
                                                                                <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <%--                                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <a id="popup" title="Thanh toán công nợ" href='javascript:void(0)' onclick="return <%# String.Format("ThanhtoancongnoXuat('{0}', '{1}')", Eval("uId_Phieuxuat"), Eval("v_Maphieuxuat")).ToString%>">
                                                                <img src="../../../images/16x16/coins_in_hand.png" /></a>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieuxuat('{0}', '{1}')",Eval("uId_Phieuxuat"), Eval("uId_Khachhang")).ToString %>">
                                                                <img src="../../../images/bub.png" /></a>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                                        </Columns>
                                                                        <Templates>
                                                                            <DetailRow>
                                                                                <div style="padding: 3px 3px 2px 3px">
                                                                                    <dx:ASPxGridView ID="dgvPhieuxuatchitiet" OnBeforePerformDataSelect="dgvPhieuxuatchitiet_BeforePerformDataSelect" runat="server"
                                                                                        KeyFieldName="uId_Phieuxuat_Chitiet" Width="100%">
                                                                                        <Columns>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Tên hàng" FieldName="nv_TenMathang_vn" Name="nv_TenMathang_vn">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="ĐVT" FieldName="nv_DVT_vn" Name="nv_DVT_vn">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Số lượng" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Soluong" Name="f_Soluong">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Đơn giá" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dongia" Name="f_Dongia">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Giảm giá" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Giamgia" Name="f_Giamgia">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Tổng tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongtien" Name="f_Tongtien">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                        </Columns>
                                                                                    </dx:ASPxGridView>
                                                                                </div>
                                                                            </DetailRow>
                                                                        </Templates>
                                                                        <SettingsDetail ShowDetailRow="true" />
                                                                        <Settings ShowFooter="true" />
                                                                        <TotalSummary>
                                                                            <dx:ASPxSummaryItem FieldName="f_Tongtienthuc" SummaryType="Sum" />
                                                                            <dx:ASPxSummaryItem FieldName="tienno" SummaryType="Sum" />
                                                                        </TotalSummary>
                                                                    </dx:ASPxGridView>
                                                                </div>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Lịch sử trả nợ" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                                <div style="padding: 3px 3px  3px">
                                                                    <dx:ASPxGridView ID="dgvCongno" runat="server" OnBeforePerformDataSelect="dgvCongno_BeforePerformDataSelect"
                                                                        KeyFieldName="uId_Phieuthuchi" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Số phiếu" FieldName="v_Maphieu" Name="v_Maphieu">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Ngày trả" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}" FieldName="d_Ngay" Name="d_Ngay">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Số tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Sotien" Name="f_Sotien">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Lý do" FieldName="nv_Lydo_vn" Name="nv_Lydo_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </div>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Thẻ tài khoản" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl4" runat="server">
                                                                <div style="padding: 3px 3px  3px">
                                                                    <dx:ASPxGridView ID="dgvTheTT" runat="server" OnBeforePerformDataSelect="dgvTheTT_BeforePerformDataSelect"
                                                                        KeyFieldName="vMaBarcode" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang_Goidichvu"
                                                                                Name="uId_Khachhang_Goidichvu">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                Width="140px" HeaderStyle-HorizontalAlign="Center" Caption="Mã thẻ" FieldName="vMaBarcode"
                                                                                Name="vMaBarcode">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                Width="200px" HeaderStyle-HorizontalAlign="Center" Caption="Tên thẻ" FieldName="nv_Tengoi_vn"
                                                                                Name="nv_Tengoi_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                HeaderStyle-HorizontalAlign="Center" Caption="Ngày cấp" FieldName="d_Ngaymua"
                                                                                Name="d_Ngaymua">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                HeaderStyle-HorizontalAlign="Center" Caption="Ngày hết hạn" FieldName="d_NgayKT"
                                                                                Name="d_NgayKT">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" Width="90px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Giá trị" FieldName="f_Giatrigoi" Name="f_Giatrigoi" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Trạng thái" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tentrangthai_vn"
                                                                                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="nv_Tentrangthai_vn" Width="100px">
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                        </Columns>
                                                                        <Templates>
                                                                            <DetailRow>
                                                                                <div style="padding: 3px 3px 2px 3px">
                                                                                    <dx:ASPxGridView ID="dgvLichSuTheTT" OnBeforePerformDataSelect="dgvLichSuTheTT_BeforePerformDataSelect" runat="server"
                                                                                        KeyFieldName="uId_Phieuxuat_Chitiet" Width="100%">
                                                                                        <Columns>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Mã phiếu dịch vụ" FieldName="v_MaPhieuDV" Name="v_MaPhieuDV">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Mã phiếu xuất" FieldName="v_MaPhieuxuat" Name="v_MaPhieuxuat">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Ngày lập" FieldName="d_Ngay" Name="d_Ngay">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Số tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Sotien" Name="f_Sotien">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                        </Columns>
                                                                                    </dx:ASPxGridView>
                                                                                </div>
                                                                            </DetailRow>
                                                                        </Templates>
                                                                        <SettingsDetail ShowDetailRow="true" />
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
                                --%>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="15">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:TabPage>

            </TabPages>
            <%-- danh sach khach hang he thong --%>
            <TabPages>
                <dx:TabPage Text="Danh sách khách hàng" ActiveTabStyle-Font-Bold="true" TabStyle-Font-Bold="true" TabStyle-ForeColor="Green" ActiveTabStyle-ForeColor="White">
                    <ContentCollection>
                        <dx:ContentControl>
                            <dx:ASPxGridView ID="grv_KHHethong" runat="server" ClientInstanceName="grv_KHHethong"
                                AutoGenerateColumns="false" KeyFieldName="uId_KH_Tiemnang" SettingsPager-PageSize="8"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="uId_Khachhang" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_KH_Tiemnang"
                                        Name="uId_KH_Tiemnang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Chuyendoi"
                                        Name="uId_Chuyendoi">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã KH" FieldName="v_Makhachang"
                                        Name="v_Makhachang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Tên khách hàng" FieldName="nv_Hoten_vn"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="90" VisibleIndex="2" Caption="Ngày sinh" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" FieldName="d_Ngaysinh" Name="d_Ngaysinh" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Địa chỉ" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn" Name="nv_Diachi_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Điện thoại" Width="100px" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Email" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="v_Email" Name="v_Email">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ngày nhập" Width="90" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="d_Ngaynhap" Name="d_Ngaynhap" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="Ghichu" Name="Ghichu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" Caption="Lịch sử chăm sóc da" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="nv_Hoten_en" Name="nv_Hoten_en">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" Caption="Lịch sử chăm sóc sức khỏe" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="nv_Diachi_en" Name="nv_Diachi_en">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Thuộc cửa hàng" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="nv_Tencuahang_vn" Name="nv_Tencuahang_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Thêm công việc" href='javascript:void(0)' onclick="return <%# String.Format("ShowWorkWindow('{0}','{1}','{2}')", Eval("uId_KH_Tiemnang"), Eval("uId_Khachhang"), Eval("uId_Chuyendoi")).ToString%>">
                                                <img src="../../../images/16x16/application_link.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <%--                                    <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return ShowEditWindow()">
                                                <img src="../../../images/btn_Edit.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>--%>
                                    <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image">
                                        <CancelButton>
                                            <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                                        </CancelButton>
                                        <UpdateButton>
                                            <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                                        </UpdateButton>
                                        <%--                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                            <Image AlternateText="Xóa" Url="~/images/btn_Delete.png">
                                            </Image>
                                        </DeleteButton>--%>
                                    </dx:GridViewCommandColumn>
                                </Columns>
                                <Templates>
                                    <DetailRow>
                                        <div style="padding: 3px 3px 2px 3px">
                                            <dx:ASPxPageControl ID="pageControl" runat="server" Width="100%" EnableCallBacks="true">
                                                <TabPages>
                                                    <dx:TabPage Text="Phiếu dịch vụ" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                                <dx:ASPxGridView ID="dgvPhieudichvu" OnBeforePerformDataSelect="dgvPhieudichvu_BeforePerformDataSelect" runat="server"
                                                                    KeyFieldName="uId_Phieudichvu" Width="100%">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Số phiếu" FieldName="v_Sophieu"
                                                                            Name="v_Sophieu">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="d_Ngay"
                                                                            Name="d_Ngay">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dathanhtoan"
                                                                            Name="f_Dathanhtoan">
                                                                            <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Còn nợ" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="tienno"
                                                                            Name="tienno">
                                                                            <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu_vn"
                                                                            Name="nv_Ghichu_vn">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                            <DataItemTemplate>
                                                                                <a id="popup" title="Thanh toán công nợ" href='javascript:void(0)' onclick="return <%# String.Format("ThanhtoancongnoDV('{0}', '{1}')", Eval("uId_Phieudichvu"), Eval("v_Sophieu")).ToString%>">
                                                                                    <img src="../../../images/16x16/coins_in_hand.png" /></a>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                            <DataItemTemplate>
                                                                                <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieudichvu('{0}', '{1}','{2}','{3}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("v_Sophieu"), Eval("d_Ngay")).ToString%>">
                                                                                    <img src="../../../images/bub.png" /></a>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <Templates>
                                                                        <DetailRow>
                                                                            <div style="padding: 3px 3px 2px 3px">
                                                                                <dx:ASPxGridView ID="dgvPhieuchitiet" OnBeforePerformDataSelect="dgvPhieuchitiet_BeforePerformDataSelect" runat="server"
                                                                                    KeyFieldName="uId_Phieudichvu_Chitiet" Width="100%">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="" FieldName="uId_Phieudichvu" Name="uId_Phieudichvu">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="" FieldName="uId_Dichvu" Name="uId_Dichvu">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn" Name="nv_Tendichvu_vn">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Tổng S.Lần" FieldName="f_Solan" Name="f_Solan">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Đã ĐT" FieldName="i_SL_daDieutri" Name="i_SL_daDieutri">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Đơn giá" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Giảm giá" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                            Caption="Thành tiền" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                                            <DataItemTemplate>
                                                                                                <a id="popup" title="Thiết lập liệu trình dịch vụ <%#Eval("nv_Tendichvu_vn")%>" href='javascript:void(0)' onclick="return <%# String.Format("Thietlaplieutrinh('{0}', '{1}', '{2}','{3}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("uId_Dichvu"), Eval("uId_Phieudichvu_Chitiet")).ToString%>">
                                                                                                    <img src="../../../images/bub.png" /></a>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                    </Columns>
                                                                                    <Templates>
                                                                                        <DetailRow>
                                                                                            <div style="padding: 3px 3px 2px 3px">
                                                                                                <dx:ASPxGridView ID="dgvQTdieutri" OnBeforePerformDataSelect="dgvQTdieutri_BeforePerformDataSelect" runat="server"
                                                                                                    KeyFieldName="uId_QT_Dieutri" Width="100%">
                                                                                                    <Columns>
                                                                                                        <dx:GridViewDataTextColumn Visible="false" HeaderStyle-HorizontalAlign="Center"
                                                                                                            FieldName="uId_QT_Dieutri" Name="uId_QT_Dieutri">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Lần thứ" FieldName="i_Lanthu" Name="i_Lanthu">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Ngày điều trị" FieldName="d_Ngaydieutri" Name="d_Ngaydieutri">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Nhân viên" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Tên trạng thái" FieldName="nv_Tentrangthai_vn" Name="nv_Tentrangthai_vn">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                            Caption="Ghi chú" FieldName="nv_Ghichu" Name="nv_Ghichu">
                                                                                                        </dx:GridViewDataTextColumn>
                                                                                                    </Columns>
                                                                                                </dx:ASPxGridView>
                                                                                            </div>
                                                                                        </DetailRow>
                                                                                    </Templates>
                                                                                    <SettingsDetail ShowDetailRow="true" />
                                                                                </dx:ASPxGridView>
                                                                            </div>
                                                                        </DetailRow>
                                                                    </Templates>
                                                                    <SettingsDetail ShowDetailRow="true" />
                                                                    <Settings ShowFooter="true" />
                                                                    <TotalSummary>
                                                                        <dx:ASPxSummaryItem FieldName="f_Dathanhtoan" SummaryType="Sum" />
                                                                        <dx:ASPxSummaryItem FieldName="tienno" SummaryType="Sum" />
                                                                    </TotalSummary>
                                                                </dx:ASPxGridView>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Phiếu xuất" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                                <div style="padding: 3px 3px  3px">
                                                                    <dx:ASPxGridView ID="dgvPhieuxuat" OnBeforePerformDataSelect="dgvPhieuxuat_BeforePerformDataSelect" runat="server"
                                                                        KeyFieldName="uId_Phieuxuat" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Số phiếu" FieldName="v_Maphieuxuat" Name="v_Maphieuxuat">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Ngày xuất" FieldName="d_PXNgayxuat" Name="d_PXNgayxuat">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Nội dung xuất" FieldName="nv_Noidungxuat_vn" Name="nv_Noidungxuat_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Nhân viên xuất" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Đã thanh toán" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongtienthuc" Name="f_Tongtienthuc">
                                                                                <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Còn nợ" FieldName="tienno" Name="tienno">
                                                                                <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                                <DataItemTemplate>
                                                                                    <a id="popup" title="Thanh toán công nợ" href='javascript:void(0)' onclick="return <%# String.Format("ThanhtoancongnoXuat('{0}', '{1}')", Eval("uId_Phieuxuat"), Eval("v_Maphieuxuat")).ToString%>">
                                                                                        <img src="../../../images/16x16/coins_in_hand.png" /></a>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                                                <DataItemTemplate>
                                                                                    <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieuxuat('{0}', '{1}')",Eval("uId_Phieuxuat"), Eval("uId_Khachhang")).ToString %>">
                                                                                        <img src="../../../images/bub.png" /></a>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                        </Columns>
                                                                        <Templates>
                                                                            <DetailRow>
                                                                                <div style="padding: 3px 3px 2px 3px">
                                                                                    <dx:ASPxGridView ID="dgvPhieuxuatchitiet" OnBeforePerformDataSelect="dgvPhieuxuatchitiet_BeforePerformDataSelect" runat="server"
                                                                                        KeyFieldName="uId_Phieuxuat_Chitiet" Width="100%">
                                                                                        <Columns>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Tên hàng" FieldName="nv_TenMathang_vn" Name="nv_TenMathang_vn">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="ĐVT" FieldName="nv_DVT_vn" Name="nv_DVT_vn">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Số lượng" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Soluong" Name="f_Soluong">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Đơn giá" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dongia" Name="f_Dongia">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Giảm giá" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Giamgia" Name="f_Giamgia">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Tổng tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongtien" Name="f_Tongtien">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                        </Columns>
                                                                                    </dx:ASPxGridView>
                                                                                </div>
                                                                            </DetailRow>
                                                                        </Templates>
                                                                        <SettingsDetail ShowDetailRow="true" />
                                                                        <Settings ShowFooter="true" />
                                                                        <TotalSummary>
                                                                            <dx:ASPxSummaryItem FieldName="f_Tongtienthuc" SummaryType="Sum" />
                                                                            <dx:ASPxSummaryItem FieldName="tienno" SummaryType="Sum" />
                                                                        </TotalSummary>
                                                                    </dx:ASPxGridView>
                                                                </div>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Lịch sử trả nợ" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                                <div style="padding: 3px 3px  3px">
                                                                    <dx:ASPxGridView ID="dgvCongno" runat="server" OnBeforePerformDataSelect="dgvCongno_BeforePerformDataSelect"
                                                                        KeyFieldName="uId_Phieuthuchi" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Số phiếu" FieldName="v_Maphieu" Name="v_Maphieu">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Ngày trả" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}" FieldName="d_Ngay" Name="d_Ngay">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Số tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Sotien" Name="f_Sotien">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Lý do" FieldName="nv_Lydo_vn" Name="nv_Lydo_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </div>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Thẻ tài khoản" Visible="true">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl4" runat="server">
                                                                <div style="padding: 3px 3px  3px">
                                                                    <dx:ASPxGridView ID="dgvTheTT" runat="server" OnBeforePerformDataSelect="dgvTheTT_BeforePerformDataSelect"
                                                                        KeyFieldName="vMaBarcode" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang_Goidichvu"
                                                                                Name="uId_Khachhang_Goidichvu">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                Width="140px" HeaderStyle-HorizontalAlign="Center" Caption="Mã thẻ" FieldName="vMaBarcode"
                                                                                Name="vMaBarcode">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                Width="200px" HeaderStyle-HorizontalAlign="Center" Caption="Tên thẻ" FieldName="nv_Tengoi_vn"
                                                                                Name="nv_Tengoi_vn">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                HeaderStyle-HorizontalAlign="Center" Caption="Ngày cấp" FieldName="d_Ngaymua"
                                                                                Name="d_Ngaymua">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                                                HeaderStyle-HorizontalAlign="Center" Caption="Ngày hết hạn" FieldName="d_NgayKT"
                                                                                Name="d_NgayKT">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="true" Width="90px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                Caption="Giá trị" FieldName="f_Giatrigoi" Name="f_Giatrigoi" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Trạng thái" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tentrangthai_vn"
                                                                                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="nv_Tentrangthai_vn" Width="100px">
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                        </Columns>
                                                                        <Templates>
                                                                            <DetailRow>
                                                                                <div style="padding: 3px 3px 2px 3px">
                                                                                    <dx:ASPxGridView ID="dgvLichSuTheTT" OnBeforePerformDataSelect="dgvLichSuTheTT_BeforePerformDataSelect" runat="server"
                                                                                        KeyFieldName="uId_Phieuxuat_Chitiet" Width="100%">
                                                                                        <Columns>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Mã phiếu dịch vụ" FieldName="v_MaPhieuDV" Name="v_MaPhieuDV">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Mã phiếu xuất" FieldName="v_MaPhieuxuat" Name="v_MaPhieuxuat">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Ngày lập" FieldName="d_Ngay" Name="d_Ngay">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                Caption="Số tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Sotien" Name="f_Sotien">
                                                                                            </dx:GridViewDataTextColumn>
                                                                                        </Columns>
                                                                                    </dx:ASPxGridView>
                                                                                </div>
                                                                            </DetailRow>
                                                                        </Templates>
                                                                        <SettingsDetail ShowDetailRow="true" />
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
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="15">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
            <ClientSideEvents ActiveTabChanged="tabchange" />
        </dx:ASPxPageControl>
    </div>
    <asp:HiddenField ID="hdfuId_KH_Tiemnang" runat="server" />
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
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
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
    <asp:HiddenField ID="hdfuId_Chuyendoi" runat="server" />


    <dx:ASPxPopupControl ID="pcAddKhachhang" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddKhachhang"
        HeaderText="Thêm / Sửa khách hàng" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcAddKhachhang.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="680px" Height="400px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <asp:UpdatePanel ID="upKhachhang" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Thông tin khách hàng tiềm năng</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Điện thoại:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtDienthoai" runat="server" onkeypress="return enter_txtDienthoai(event)" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Mã khách hàng:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtMaKH" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Họ tên:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtHoten" AutoPostBack="false" onkeypress="return enter_txtHoten(event)" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Ngày sinh:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="deNgaysinh" UseMaskBehavior="true" onkeypress="return enter_deNgaysinh(event)" ClientInstanceName="deNgaysinh" Style="float: left; margin-right: 8px;" Width="120px" Height="25px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                    <%--                                                    <asp:TextBox ID="txtTuoi" runat="server" onkeyup="return GetYearFromAge()" Width="30px" Style="float: left; margin-right: 7px" placeholder="Tuổi" CssClass="nano_textbox"></asp:TextBox>--%>
                                                    <dx:ASPxComboBox ClientInstanceName="ddlGioitinh" onkeypress="return enter_ddlGioitinh(event)" ID="ddlGioitinh" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="70px" runat="server" ValueType="System.String">
                                                        <Items>
                                                            <dx:ListEditItem Value="0" Selected="true" Text="Nữ" />
                                                            <dx:ListEditItem Value="1" Text="Nam" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Địa chỉ:
                                                </td>
                                                <td class="info_table_td" colspan="3">
                                                    <asp:TextBox ID="txtDiachi" runat="server" onkeypress="return enter_txtDiachi(event)" Width="514px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ngày đến:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="deNgayden" UseMaskBehavior="true" ClientInstanceName="deNgayden" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                </td>

                                                <td class="info_table_td">Email:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" onkeypress="return enter_txtEmail(event)" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Chi nhánh / TT:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlCuahang" ClientInstanceName="ddlCuahang" onkeypress="return enter_ddlCuahang(event)" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server"></dx:ASPxComboBox>
                                                </td>
                                                <td class="info_table_td">Đánh giá:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlDanhgia" ClientInstanceName="ddlDanhgia" DropDownStyle="DropDown" onkeypress="return enter_ddlDanhgia(event)" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ghi chú:
                                                </td>
                                                <td class="info_table_td" colspan="3">
                                                    <asp:TextBox ID="txtGhichu" onkeypress="return enter_txtGhichu(event)" runat="server" Width="514px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <tr>
                                                    <td colspan="5">
                                                        <span class='error' id='error'></span>
                                                        <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                        <asp:Literal ID="ltrSuccess" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td class="info_table_td">Lịch sử chăm sóc da:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <asp:TextBox ID="txt_Lichsuchamsocda" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                    </td>
                                                    <td class="info_table_td">Lịch sử chăm sóc sức khỏe:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <asp:TextBox ID="txt_Lichsuchamsocsuckhoe" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                    </td>

                                                </tr>--%>
                                                <tr>
                                                    <td colspan="5">
                                                        <div class="pcmButton" style="width: 600px">
                                                            <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Thêm mới (F9)" Style="float: left; margin-right: 8px">
                                                                <ClientSideEvents Click="ClearTextCus" />
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton ID="btOK" OnClick="btOK_Click" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" runat="server" Text="Lưu (F4)" Style="float: left; margin-right: 8px">
                                                                <ClientSideEvents Click="OkClick" />
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton ID="btaddbill" OnClick="btaddbill_Click" Visible="false" Image-Url="~/images/16x16/report_go.png" runat="server" Text="Thêm công việc" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                                <ClientSideEvents Click="ClosePopup" />
                                                            </dx:ASPxButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                        </table>
                                    </fieldset>
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
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter_KH" runat="server" GridViewID="dgvDevexpress"></dx:ASPxGridViewExporter>
    <dx:ASPxPopupControl ID="PcImportExcel" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="PcImportExcel" Font-Size="25px"
        HeaderText="Import Excel" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="350px" Height="150px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server" Width="300px">
                            <div style="width: 290px; height: 100px">
                                <fieldset class="field_tt" style="width: 335px; height: 60px; margin: auto">
                                    <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                    <div style="height: 52px; width: 300px">
                                        <asp:FileUpload ID="UploadFileExcel" runat="server" Width="335px" BorderStyle="Groove" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="chỉ được upload file .xls và xlsx"
                                            ValidationExpression="^(?!\..*)(?!.*\.\.)(?=.*[^.]$)([^\&quot;#%&*:<>?\\/{|}~]){1,123}\.(xlsx)$" ControlToValidate="UploadFileExcel">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="link_Taiexcel_Mau" runat="server" Text="Excel mẫu" OnClick="link_Taiexcel_Mau_Click"></asp:LinkButton>
                                    </div>
                                </fieldset>
                            </div>
                            <div>
                                <asp:Label ID="lbl_Import" runat="server" CssClass="error" Font-Size="16px" Text=""></asp:Label>
                                <dx:ASPxButton ID="btn_Import" Image-Url="~/images/btn_Save.png" runat="server" Text="Tải lên" AutoPostBack="false"
                                    Style="float: left; margin-right: 8px" ClientInstanceName="btn_Import">
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="btn_close" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                    <ClientSideEvents Click="ClosePopup" />
                                </dx:ASPxButton>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
