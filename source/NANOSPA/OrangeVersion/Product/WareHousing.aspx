<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="WareHousing.aspx.vb" Inherits="NANO_SPA.WareHousing" %>

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
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        var tienthua = 0;
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'46375652-E910-446E-9F0E-7C0FD7786C01'}";
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
            if (s.cpIsUpdated =="update") {
                Getdata_Phieu();
                s.cpIsUpdated = "";
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
        function grid_RowDblClick(s, e) {
            s.StartEditRow(e.visibleIndex);
        }
        function cbTenvattu_SelectChange(s, e) {
            jo_CreateSession("MaVatTu", ddlMathang.GetValue().toString());
            ddlDonvi.PerformCallback();
        }
        //su kien click buttom "Them mat hang" se insert mat hang vao bnag phieu nhap chi tiet 
        //dong thoi update tong tien vao phieu nhap 
        function SaveDetail(s, e) {
            var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
            if (jo_GetSession("MaVatTu") != null) {
                var param_dt = "{'v_MaMathang':'" + jo_GetSession("MaVatTu") + "','f_Soluong':'" + txtSoluong.value + "', 'MaDonVi':'" + ddlDonvi.GetValue().toString() + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieunhapchitiet";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
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
                            var pageUrl_px = "../../../../Webservice/nano_websv.asmx/LoadPhieunhapThanhtoan";
                            $.ajax({
                                type: "POST",
                                url: pageUrl_px,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: OnSuccessCall_Phieunhap,
                                error: onFail
                            });
                        } else {
                            alert(msg.d);
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
        function OnSuccessCall_Phieunhap(msg) {
            var defaultdata = msg.d.split("$");
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthieu.ClientID%>");
            var txtSotientra = document.getElementById("<%=txtSotientra.ClientID%>");
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            txtGiamgiaPhieu.value = jo_FormatMoney(jo_IsString(defaultdata[0]))
            lblTongtien.innerHTML = jo_FormatMoney(jo_IsString(defaultdata[1]));
            txtSotientra.value = jo_FormatMoney(parseFloat(jo_IsString(defaultdata[1]))-parseFloat(jo_FormatMoney(jo_IsString(defaultdata[0]))));
            lblConlai.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(defaultdata[1])) - jo_IsString(defaultdata[0])));
            lblTienthua.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(lblConlai.innerHTML.replace(/,/g, ""))) - parseFloat(jo_IsString(txtSotientra.value.replace(/,/g, "")))));
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
        //Chon danh sach phieu load thong tin phieu nhap len grid va cac control
        function SelChanged_dsphieu(s, e) {
            if (!e.isSelected) {
            } else {
                client_dgvDanhsachphieu.GetRowValues(e.visibleIndex, 'uId_Phieunhap;v_Maphieunhap', OnGridSelectionDSPhieuComplete);
            }
        }
        function OnGridSelectionDSPhieuComplete(values) {
            jo_CreateSession("uId_Phieunhap", values[0]);
            client_grid.Refresh();
            var param_dt = "{'uId_Phieunhap':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuNhap";
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
        function Getdata_Phieu(s,e) {
            var param_dt = "{'uId_Phieunhap':'" + jo_GetSession("uId_Phieunhap") + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuNhap";
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
                var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthieu.ClientID%>");
                var txtSotientra = document.getElementById("<%=txtSotientra.ClientID%>");
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                var lblTinhtien = document.getElementById("<%=lblTinhtien.ClientID%>");
                lblTienthua.innerHTML = "";
                txtMaphieu.value = defaultdata[0];
                txtGhichu.value = defaultdata[4];
                deNgaynhap.SetText(ConvertDateToDDMMYYY(defaultdata[2]));
                ddlDMKho.SetValue(defaultdata[1]);
                txtGiamgiaPhieu.value = jo_FormatMoney(jo_IsString(defaultdata[5]))
                lblTongtien.innerHTML = jo_FormatMoney(jo_IsString(defaultdata[6]));
                lblConlai.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(defaultdata[6])) - jo_IsString(defaultdata[5])));
                if (defaultdata[7] == 0) {
                    txtSotientra.value = jo_FormatMoney((parseFloat(jo_IsString(defaultdata[6])) - jo_IsString(defaultdata[5])));
                }
                else {
                    txtSotientra.value = jo_FormatMoney(jo_IsString(defaultdata[7]));
                }
                lblTienthua.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(lblConlai.innerHTML.replace(/,/g, ""))) - parseFloat(jo_IsString(txtSotientra.value.replace(/,/g, "")))));
                if (parseFloat(lblTienthua.innerHTML.replace(/,/g, "")) < 0) {
                    lblTinhtien.innerHTML = "Tiền thừa";
                }
                else {
                    lblTinhtien.innerHTML = "Tiền thiếu";
                }
            }
        }  
        function ClosePopup() {
            pcDanhsachphieu.Hide();
            return false;
        }
        function ShowDSPopup(s, e) {
            pcDanhsachphieu.Show();
            return false;
        }
        function RefreshGridPhieu(s, e) {
            client_dgvDanhsachphieu.Refresh();
            return false;
        }
        //su kien khi nhan phim so tai textbox giam gia
        function onkeyup_giamgia() {
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotientra.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthieu.ClientID%>");
            var isVNDChecked = rbGiamgiaVND.GetChecked();
            var isphantramChecked = rbGiamgiaphantram.GetChecked();
            if (txtGiamgiaPhieu.value != "") {
                if (isVNDChecked) {
                    lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")))));
                    txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
                    lblTienthua.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(lblConlai.innerHTML.replace(/,/g, ""))) - parseFloat(jo_IsString(txtSotiennhan.value))));
                    document.getElementById("span_giamgia").innerHTML = "VNĐ";
                }
                if (isphantramChecked) {
                    lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - (parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) * parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) / 100))));
                    txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
                    lblTienthua.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(lblConlai.innerHTML.replace(/,/g, ""))) - parseFloat(jo_IsString(txtSotiennhan.value))));
                    document.getElementById("span_giamgia").innerHTML = "%";
                }
            }
           
            return false;
        }
        function ShowHideGiamgia() {
            $("#popupDiscount").toggle();
        };
        function rbGiamgiaVND_Check(s, e) {
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            txtGiamgiaPhieu.value = 0;
            $("#popupDiscount").hide();
            var isVNDChecked = rbGiamgiaVND.GetChecked();
            var isphantramChecked = rbGiamgiaphantram.GetChecked();
            if (isVNDChecked) {
                document.getElementById("span_giamgia").innerHTML = "VNĐ";
            }
            if (isphantramChecked) {
                document.getElementById("span_giamgia").innerHTML = "%";
            }
        }
        $(function () {
            $('#div_giamgia').click(function (e) {
                e.stopPropagation();
            });
        });
        $('html').click(function () {
            $("#popupDiscount").hide();
        });
        $(document).ready(function () {
            $("#popupDiscount").hide();
        });
        //su kien khi nhap so tien vao textbox so tien tra de tinh so tien con thieu
        function onkeyup_txtsotiennhan(id) {
            jo_ThousanSereprate(id);
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var lblTinhtien = document.getElementById("<%=lblTinhtien.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotientra.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthieu.ClientID%>");
            tienthua=parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, ""))
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString(tienthua)).replace(/-/g,"");
            if (tienthua < 0) {
                lblTinhtien.innerHTML = "Tiền thừa";
            }
            else {
                lblTinhtien.innerHTML = "Tiền thiếu";
            }
        }
        //su kien khi click buttom "luu phieu" ben phai khi thanh toan phieu no, se update giam gia, so tien tra vao 
        //bang phieu nhap va, tien thieu vao bang cong no thanh toan. sau khi thanh toan phieu se ko the
        //thay doi so tien tra va ko them duoc mat hang moi vao.
        function UpdatePhieunhap(s, e) {
            var txtSotientra = document.getElementById("<%=txtSotientra.ClientID%>");
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthieu.ClientID%>");
            var isVNDChecked = rbGiamgiaVND.GetChecked();
            var isphantramChecked = rbGiamgiaphantram.GetChecked();
            var giamgia = "0"
            if (isVNDChecked) {
                giamgia = txtGiamgiaPhieu.value.replace(/,/g, "");
            }
            if (isphantramChecked) {
                giamgia = (parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) * parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) / 100);
            }
            var param_dt = "{'f_Tongtienthuc':'" + txtSotientra.value.replace(/,/g, "") + "','tienthieu':'" + tienthua + "','f_Giamgia':'" + giamgia + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/UpdatePhieunhap";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    alert(msg.d);
                },
                error: onFail
            });
            return false;
        }
        function InPhieuCongNo(s,e) {
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rpt_Phieunhapsp.aspx" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 855.733,
                     title: "In phiếu thanh toán",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                     }
                 });
                $dialog.dialog('open');
          
            return false;
        }
    </script>
      <script src="../../../../Js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
     <link href="../../../../Css/jquery-ui.css" rel="stylesheet" type="text/css" />   
    <script src="../../Js/Public/Public.js" type="text/javascript"></script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>NHẬP THUỐC</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt" style="width:48%; float:left">
        <legend><span style="font-weight: bold; color: green">Thông tin phiếu nhập</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Kho nhập:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDMKho" ClientInstanceName="ddlDMKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Số phiếu:
                    </td>
                    <td class="info_table_td">
                        <asp:TextBox ID="txtMaphieu" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Ngày nhập:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deNgaynhap" ClientInstanceName="deNgaynhap" Style="float: left; margin-right: 8px;" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">Nhà cung cấp:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlNhacungcap" ClientInstanceName="ddlNhacungcap" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Ghi chú
                    </td>
                    <td class="info_table_td" colspan="3">
                        <asp:TextBox ID="txtGhichu" runat="server" TextMode="MultiLine" Width="510px" Height="17px" CssClass="nano_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxButton ID="btnLuu" OnClick="btnLuu_Click" ClientInstanceName="btnLuu" Image-Url="~/images/16x16/save.png"  Style="float: left; margin-left: 10px" runat="server" Text="Tạo phiếu">
                            <Image Url="~/images/16x16/save.png"></Image>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnClear" OnClick="btnClear_Click" Image-Url="~/images/16x16/page_white.png" AutoPostBack="true" Style="float: left;
                         margin-left: 10px" ClientInstanceName="btnClear" runat="server" Text="Làm mới">
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
     <fieldset class="field_tt" style="min-height: 149px;width:48%; margin:auto" >
            <legend><span style="font-weight: bold; color: green">Thông tin thanh toán</span></legend>
            <table class="info_table">
                <tbody>
                    <tr>
                        <td class="info_table_td">Tổng tiền:
                        </td>
                        <td class="info_table_td" style="width:140px">
                            <asp:Label ID="lblTongtien" runat="server" Text="0,000,000"></asp:Label>
                        </td>
                        <td class="info_table_td">Số tiền đã trả:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtSotientra" onkeyup="return onkeyup_txtsotiennhan(this)" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Giảm giá:
                        </td>
                        <td class="info_table_td" style="position: relative">
                            <div id="div_giamgia">
                                <asp:TextBox runat="server" onkeyup="return onkeyup_giamgia()" onfocus="ShowHideGiamgia()" Width="76px" CssClass="nano_textbox" ID="txtGiamgiaPhieu"></asp:TextBox>
                                <span id="span_giamgia" style="width:20px">VNĐ</span>
                                <div id="popupDiscount">
                                    <dx:ASPxRadioButton Style="float: left" ClientInstanceName="rbGiamgiaVND" Checked="true" ID="rbGiamgiaVND" runat="server" GroupName="rbthanhtoan" Text="VNĐ">
                                        <ClientSideEvents CheckedChanged="rbGiamgiaVND_Check" />
                                    </dx:ASPxRadioButton>
                                    <dx:ASPxRadioButton ID="rbGiamgiaphantram" Style="float: left" ClientInstanceName="rbGiamgiaphantram" runat="server" Text="%" GroupName="rbthanhtoan">
                                        <ClientSideEvents CheckedChanged="rbGiamgiaVND_Check" />
                                    </dx:ASPxRadioButton>
                                </div>
                            </div>
                        </td>
                        <td class="info_table_td"><asp:Label ID="lblTinhtien" runat="server" Text="Tiền thiếu"></asp:Label>
                        </td>
                        <td class="info_table_td">
                            <asp:Label ID="lblTienthieu" runat="server" Text="0,000,000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Cần trả NCC:
                        </td>
                        <td class="info_table_td">
                            <asp:Label ID="lblConlai" runat="server" Text="0,000,000"></asp:Label>
                        </td>
                        <td colspan="2" rowspan="2">
                            <p style="font-style:italic; color:red; width:330px">Lưu ý: Phiếu nhập sau khi thanh toán không thể chỉnh sửa thông tin</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td" >
                            <dx:ASPxButton ID="btnThanhtoan" ClientInstanceName="btnThanhtoan" Image-Url="~/images/16x16/coins_in_hand.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Thanh toán">
                                <Image Url="~/images/16x16/coins_in_hand.png"></Image>
                                <ClientSideEvents Click="UpdatePhieunhap" />
                            </dx:ASPxButton>
                        </td>
                         <td class="info_table_td" >
                            <dx:ASPxButton ID="btn_In" ClientInstanceName="btn_In" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="In phiếu">
                                <Image Url="~/images/16x16/printer.png"></Image>
                                <ClientSideEvents Click="InPhieuCongNo" />
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
                        <dx:ASPxComboBox ID="ddlMathang" OnCallback="ddlMathang_Callback" onkeypress="return enter_ddlMathang(event)" EnableCallbackMode="true" ClientInstanceName="ddlMathang" runat="server" CallbackPageSize="10"
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
                    <td class="info_table_td">Đơn vị:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDonvi" onkeypress="return enter_ddlDonvi(event)" OnCallback="ddlDonvi_Callback" ClientInstanceName="ddlDonvi" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="86px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td td_0_ipad">Số lượng:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <asp:TextBox ID="txtSoluong" onkeypress="return enter_txtSoluong(event)" Text="1" runat="server" Width="43px" CssClass="nano_textbox"></asp:TextBox>
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <dx:ASPxButton ID="btnLuuchitiet" ClientInstanceName="btnLuuchitiet" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" 
                            runat="server" Text="Thêm thuốc">
                            <Image Url="~/images/16x16/add.png"></Image>
                            <ClientSideEvents Click="SaveDetail" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" OnRowDeleting="dgvDevexpress_RowDeleting" OnRowUpdating="dgvDevexpress_RowUpdating" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Phieunhap_Chitiet;uId_Mathang;MADONVI" OnCustomErrorText="dgvDevexpress_CustomErrorText"
        SettingsPager-Position="Bottom" >
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieunhap_Chitiet"
                Name="uId_Phieunhap_Chitiet">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="false" FieldName="uId_Mathang"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="false" FieldName="MADONVI"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên thuốc" FieldName="nv_TenMathang_vn"
                Name="nv_TenMathang_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex ="2" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="d_NgayhethanSD" Name="d_NgayhethanSD" Caption="Hạn sử dụng"
                PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                Width="80px" HeaderStyle-HorizontalAlign="Center" Caption="ĐVT" FieldName="tendonvi"
                Name="tendonvi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"
                Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"
                Caption="Đơn giá:" FieldName="f_Donggia" Name="f_Donggia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="3" Width="130px" Caption="Thành tiền" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" Visible="true" FieldName="f_Thanhtien" Name="f_Thanhtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}" ReadOnly="true">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="3" Visible="true" Width="100px" Caption="Hạn sử dụng" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="d_NgayhethanSD" Name="d_NgayhethanSD">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image" >
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton >
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
        <Settings ShowFooter="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true"/>
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick"  />
        <TotalSummary>
            <dx:ASPxSummaryItem DisplayFormat="Thành tiền: {0:0,0}" FieldName="f_Thanhtien" SummaryType="Sum" />
        </TotalSummary>
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxPopupControl ID="pcDanhsachphieu" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides" ClientInstanceName="pcDanhsachphieu"
        HeaderText="Danh sách phiếu" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDanhsachphieu.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="900px" Height="370px">
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
                                                        <dx:ASPxButton ID="btnRefresh" ClientInstanceName="btnRefresh" Image-Url="~/images/16x16/filter.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Tải lại">
                                                            <Image Url="~/images/16x16/refresh.png"></Image>
                                                            <ClientSideEvents Click="RefreshGridPhieu" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </fieldset>
                                    <div style="clear: both"></div>
                                    <dx:ASPxGridView ID="dgvDanhsachphieu" OnRowDeleting="dgvDanhsachphieu_RowDeleting" runat="server" ClientInstanceName="client_dgvDanhsachphieu"
                                        AutoGenerateColumns="false" KeyFieldName="uId_Phieunhap;v_Maphieunhap" SettingsPager-PageSize="8"
                                        SettingsPager-Position="Bottom">
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieunhap"
                                                Name="uId_Phieunhap">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="200px" Caption="Số phiếu" FieldName="v_Maphieunhap"
                                                Name="v_Maphieunhap">
                                                <Settings AutoFilterCondition="Contains"></Settings>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="90px" Caption="Ngày lập" FieldName="d_Ngaynhap"
                                                Name="d_Ngaynhap">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Nội dung" Width="370px" FieldName="nv_Noidung_vn"
                                                Name="nv_Noidung_vn">
                                                <Settings AutoFilterCondition="Contains"></Settings>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Nhập vào kho" FieldName="nv_Tenkho_vn"
                                                Name="nv_Tenkho_vn">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return ClosePopup()">
                                                        <img src="../../../images/bub.png" /></a>
                                                </DataItemTemplate>

                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </dx:GridViewDataColumn>
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
                                        <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_dsphieu(s, e); }" />
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
