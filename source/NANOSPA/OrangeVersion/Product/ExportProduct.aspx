<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ExportProduct.aspx.vb" Inherits="NANO_SPA.ExportProduct" %>

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
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript" src="../../../../Js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
    <link href="../../../../Css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Js/Product/ExportProduct.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tienthua = 0;
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
            var param_dt = "{'uId_Chucnang':'39e6c52f-b3e7-43f9-8222-7c2af4724b80'}";
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

            if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
                btnKekhai_client.SetEnabled(true);
                btnThanhtoanthe_client.SetEnabled(false);
            } else {
                btnThanhtoanthe_client.SetEnabled(true);
                btnKekhai_client.SetEnabled(false);
            }
        });
       
        function SaveDetail(s, e) {
            var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
            
            if (uId_Mathang != "") {
                var param_dt = "{'v_MaMathang':'" + uId_Mathang + "','f_Soluong':'" + txtSoluong.value + "', 'MaDonVi':'" + ddlDonvi.GetValue().toString() + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieuxuatchitiet";
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
                           
                            uId_Mathang = "";
                            txtSoluong.value = "1";
                            //txtbarcode.SetText("");
                            ddlMathang.SetText("");
                           // khong dung barcode 
                            ddlMathang.Focus();
                           // dung barcode
                            //txtbarcode.Focus();
                            //ddlDonvi.PerformCallback();
                            ddlMathang.PerformCallback();
                            var pageUrl_px = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuXuatChuaThanhToan";
                            $.ajax({
                                type: "POST",
                                url: pageUrl_px,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: OnSuccessCall_Phieuxuat,
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
                alert("Chọn mặt thuốc");
                ddlMathang.Focus();
            }
        }
        function OnSuccessCall_Phieuxuat(msg) {
            if (msg.d != "") {
                var defaultdata = msg.d.split("$");
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
                txtdongiathang.SetText(jo_FormatMoney(defaultdata[0]));
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
                lblTongtien.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                txtSotiennhan.value = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                lblConlai.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                lblTienthua.innerHTML = "0";
            }
        }
      
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
       
        function OnGridPhieuchitietSelectionComplete(values) {
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            lblTongtien.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(values[4])));
            //txtGiamgiaPhieu.value = jo_FormatMoney((parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) - parseFloat(values[2])));
            lblConlai.innerHTML = jo_FormatMoney(parseFloat(jo_IsString(lblTongtien.innerHTML.replace(/,/g, ""))) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")));
            txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")))));
        }
        // luu phieu xuat khi click buttom luu phieu
        function UpdatePhieuxuat(s, e) {
            var txtSophieu = document.getElementById("<%=txtMaphieu.ClientID %>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var ddlLoaithanhtoanvalue = ddlLoaithanhtoan.GetValue().toString();
            var ddlKhoValue = ddlDMKho.GetValue().toString();
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            var ddlNhanvienvalue = ddlNhanvien.GetValue().toString();
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var isVNDChecked = rbGiamgiaVND.GetChecked();
            var isphantramChecked = rbGiamgiaphantram.GetChecked();
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var lblconlai = document.getElementById("<%=lblConlai.ClientID%>");
            var giamgia = "0";
            if (isVNDChecked) {
                giamgia = txtGiamgiaPhieu.value.replace(/,/g, "");
            }
            if (isphantramChecked) {
                giamgia = (parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) * parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) / 100);
            }
            var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "','d_Ngay':'" + deNgayxuat.GetText() + "','f_Tongtienthuc':'" +
                txtSotiennhan.value.replace(/,/g, "") + "','tienthua':'" + tienthua + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
                "','f_Giamgia':'" + giamgia + "','uId_Nhanvien':'" + ddlNhanvienvalue + "','nv_Ghichu_vn':'" + txtGhichu.value +
                "','uId_Kho':'" + ddlKhoValue + "','f_Khachtra':'" + lblconlai.innerHTML.replace(/,/g, "") + "','i_Sothang':'" + txtsothang.GetText() + "','f_Giathang':'" + txtdongiathang.GetText().replace(/,/g, "") + "','b_Kedon':'" + cbkchike.GetChecked() + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/UpdatePhieuxuat";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    alert(msg.d);
                    btnThanhtoan.SetEnabled(false);
                },
                error: onFail
            });
            return false;
        }
        
        function OnGridSelectionDSTheComplete(values) {
            jo_CreateSession("uId_Khachhang_Goidichvu_TT", values[0]);
            jo_CreateSession("v_MaTTT", values[2]);
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
            txtSotiennhan.value = jo_FormatMoney(jo_IsString(values[1]));
            ddlLoaithanhtoan.SetValue("01d16c43-7a03-49dc-afd2-39e79a1439f1");
            tienthua = parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, ""));
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString(tienthua)).replace(/-/g, "");
            if (tienthua < 0) {
                lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
            }
            else {
                lblTienthuatext.innerHTML = "Tiền khách nợ:";
            }

            var txtSotiennhanTT = document.getElementById("<%=txtSotiennhanTT.ClientID%>");
            var txtSotienTT_Pop = document.getElementById("<%=txtSotienTT_Pop.ClientID%>");
            var txtMaSoTT_Pop = document.getElementById("<%=txtMaSoTT_Pop.ClientID%>");
            var txtGhichu_Pop = document.getElementById("<%=txtGhichu_Pop.ClientID%>");
            if (jo_IsString(txtSotiennhanTT.value.replace(/,/g, "")) < jo_IsString(values[1])) {
                txtSotienTT_Pop.value = txtSotiennhanTT.value;
            } else {
                txtSotienTT_Pop.value = jo_FormatMoney(jo_IsString(values[1]));
            }
            txtMaSoTT_Pop.value = values[2];
            txtGhichu_Pop.focus();
            ddlHinhthucTT_Pop.SetValue("01d16c43-7a03-49dc-afd2-39e79a1439f1");
        }
        
        function onkeyup_txtsotiennhan(id) {
            jo_ThousanSereprate(id);
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
            tienthua = parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, ""));
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString(tienthua)).replace(/-/g,"");
            if (tienthua < 0) {
                lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
            }
            else {
                lblTienthuatext.innerHTML = "Tiền khách nợ:";
            }
        }
       
        // gan gia tri cua row danh sach phieu vao cac control tren web
        function OnSuccessCall(msg) {
            if (msg.d != "") {
                var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
                var defaultdata = msg.d.split("$");
                var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
                if (jo_GetSession("uId_Phieuxuat") != null && jo_GetSession("uId_Phieuxuat") !="") {
                    txtMaphieu.value = defaultdata[0];
                }
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                ddlDMKho.SetValue(defaultdata[1]);
               
                ddlKhachhang.SetValue(defaultdata[2]);
                deNgayxuat.SetText(ConvertDateToDDMMYYY(defaultdata[3]));
                txtGhichu.value = defaultdata[4];
                txtGiamgiaPhieu.value = jo_FormatMoney(jo_IsString(defaultdata[5]));
                lblTongtien.innerHTML = jo_FormatMoney(jo_IsString(defaultdata[11]*defaultdata[12]));
                lblConlai.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(defaultdata[11] * defaultdata[12])) - jo_IsString(defaultdata[5])));
                txtSotiennhan.value = jo_FormatMoney(jo_IsString(defaultdata[7]));
                ddlLoaithanhtoan.SetValue(defaultdata[8]);
                ddlNhanvien.SetValue(defaultdata[9]);
                tienthua = parseFloat(defaultdata[11] * defaultdata[12]) - parseFloat(defaultdata[5]) - parseFloat(defaultdata[7])
                lblTienthua.innerHTML = jo_FormatMoney(jo_IsString(tienthua)).replace(/-/g, "");
                cbkchike.SetChecked(defaultdata[10]);
                txtsothang.SetText(defaultdata[11]);
                txtdongiathang.SetText(jo_FormatMoney(jo_IsString(defaultdata[12])));
                if (tienthua < 0) {
                    lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
                }
                else {
                    lblTienthuatext.innerHTML = "Tiền khách nợ:";
                }
                btnThanhtoan.SetEnabled(true);
            }
        }
        function ClosePopup() {
            pcDanhsachphieu.Hide();
            return false;
        }
        function onkeyup_giamgia() {
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var isVNDChecked = rbGiamgiaVND.GetChecked();
            var isphantramChecked = rbGiamgiaphantram.GetChecked();
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
            return false;
        }
       
        function enter_ddlDonvi(e) {
            if (e.keyCode == 13) {
                var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
                txtSoluong.focus();
                ddlDonvi.SetSelectedIndex(0);
                return false;
            }
        }
        
        function KeKhaiTT(s, e) {
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblSophieuTT = document.getElementById("<%=lblSophieuTT.ClientID%>");
            var txtSotiennhanTT = document.getElementById("<%=txtSotiennhanTT.ClientID%>");
            lblSophieuTT.innerHTML = txtMaphieu.value;
            txtSotiennhanTT.value = txtSotiennhan.value;
            client_dgvLoaiTT.Refresh();
            pcHinhThucTT.Show();
            return false;
        }
        function ClosePopup_DSTT(s, e) {
            pcHinhThucTT.Hide();
            return false;
        }
        function ddlLoaithanhtoan_SelectedIndex(s, e) {
            if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
                btnKekhai_client.SetEnabled(true);
                btnThanhtoanthe_client.SetEnabled(false);
            } else {
                btnThanhtoanthe_client.SetEnabled(true);
                btnKekhai_client.SetEnabled(false);
            }
        }
        //Enter key function Form
        function enter_txtMaSoTT_Pop(e) {
            if (e.keyCode == 13) {
                var txtMaSoTT_Pop = document.getElementById("<%=txtMaSoTT_Pop.ClientID%>");
                var txtSotienTT_Pop = document.getElementById("<%=txtSotienTT_Pop.ClientID%>");
                var txtSotiennhanTT = document.getElementById("<%=txtSotiennhanTT.ClientID%>");
                if (txtMaSoTT_Pop.value != "") {
                    var param_dt = "{'v_BarCode':'" + txtMaSoTT_Pop.value + "'}";
                    var pageUrl = "../../../../Webservice/nano_websv.asmx/GetBarCodeCard";
                    $.ajax({
                        type: "POST",
                        url: pageUrl,
                        data: param_dt,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (msg) {
                            var defaultdata = msg.d.split("$");
                            jo_CreateSession("uId_Khachhang_Goidichvu_TT", defaultdata[0]);
                            jo_CreateSession("v_MaTTT", txtMaSoTT_Pop.value);
                            if (jo_IsString(txtSotiennhanTT.value.replace(/,/g, "")) < jo_IsString(defaultdata[1])) {
                                txtSotienTT_Pop.value = txtSotiennhanTT.value;
                            } else {
                                txtSotienTT_Pop.value = jo_FormatMoney(jo_IsString(defaultdata[1]));
                            }
                            ddlHinhthucTT_Pop.SetValue("01d16c43-7a03-49dc-afd2-39e79a1439f1");
                        },
                        error: onFail
                    });
                }
                return false;
            }
        }
        function btnLuuClick(s, e) {
            var b_Check = cbkchike.GetChecked();
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
                    var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                    var sPara = ddlDMKho.GetValue() + "$" + ddlNhanvien.GetValue() + "$" + txtMaphieu.value + "$" + deNgayxuat.GetText() + "$" + txtGhichu.value + "$" + b_Check;
                    var param_dt = "{'sPara':'" + sPara + "'}";
                    var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieuxuat";
                    $.ajax({
                        type: "POST",
                        url: pageUrl,
                        data: param_dt,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (msg) {
                            if (msg.d != "") {
                                var data = msg.d.split("$");
                                if (data[0] == "2" || data[0] == "3") {
                                    alert(data[1]);
                                    ddlMathang.PerformCallback()
                                    //txtbarcode.Focus();
                                    ddlMathang.Focus();
                                    return false;
                                }
                            }
                        },
                        error: onFail
                    });
        }
        var uId_Mathang = "";
        function txtBarcode_Textchange(e) {
            if (e.keyCode == 13) {
                var param_dt = "{'v_Barcode':'" + txtbarcode.GetText() + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/GetInfoProductByBarcode";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d == "null") {
                            alert("Mã Barcode không chính xác hãy kiểm tra lại!")
                            txtbarcode.SetText("");
                            txtbarcode.Focus();
                        } else {
                            if (msg.d != "") {
                                ddlMathang.SetValue(msg.d);
                                uId_Mathang = msg.d;
                                ddlDonvi.PerformCallback();
                                //ddlDonvi.SetSelectedIndex(0);
                                ddlDonvi.Focus();
                                //btnLuuchitiet.Focus();
                                return false;
                            }
                        }
                    },
                    error: onFail
                });
            }
            else {
                return true
            }
            return false
        }
        function ddlMathang_Selectchange(s, e) {
            uId_Mathang = ddlMathang.GetValue().toString();
            ddlDonvi.PerformCallback();
            ddlDonvi.Focus();
        }

        function btnLammoiClick(s, e) {
           
            uId_Mathang = "";
            //txtbarcode.SetText("");
            //ddlMathang.SetText("");
            //ddlDonvi.SetText("");
            btnThanhtoan.SetEnabled(true);
            ddlKhachhang.Focus();
            client_grid.Refresh();
            jo_RemoveSession("uId_Phieuxuat");
            e.processOnServer = false;
            Create_Maphieu();
            var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            lblTongtien.innerHTML = "0";
            txtSotiennhan.value = "0";
            lblConlai.innerHTML = "0";
            txtdongiathang.SetText("0");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                lblTienthua.innerHTML = "0";
        }
        function Create_Maphieu() {
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
            var param_dt = "{'sPara':'PX'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CreatePhieunhapxuatCode";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    txtMaphieu.value = msg.d;
                },
                error: onFail
            });
    
        }
        function InPhieu(s, e) {
            if (jo_GetSession("uId_Phieuxuat") == null) {
                alert("Chưa chọn phiếu để in!");
            }
            else {
                var $dialog = $('<div></div>')
                    //jolieD
                 //.html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthuchi/rp_InHoadontonghop.aspx?Luachon=Phieuxuat" width="850px" height="100%"></iframe>')
                    //Harumy
                    .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rp_PhieuthanhtoanSP.aspx" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 855.733,
                     title: "In phiếu sản phẩm",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                     }
                 });
                $dialog.dialog('open');
            }
            return false;
        }
        function btnLuuHinhthuc_Click() {
            var uId_LoaiTT = ddlHinhthucTT_Pop.GetValue();
            var ddlHinhthuc = document.getElementById("<%=ddlHinhthucTT_Pop.ClientID%>");
            var txtSotienTT_Pop = document.getElementById("<%=txtSotienTT_Pop.ClientID%>");
            var txt_Ghichu = document.getElementById("<%=txtGhichu_Pop.ClientID%>");
            var txt_Sophieu = document.getElementById("<%=txtMaSoTT_Pop.ClientID%>");
            var uId_Phieuxuat = jo_GetSession("uId_Phieuxuat");
            var f_Sotien = txtSotienTT_Pop.value.replace(/,/g, "");
            var param_dt = "{'uId_LoaiTT':'" + uId_LoaiTT + "','nv_Ghichu_vn':'" + txt_Ghichu.value + "','v_Sophieu':'" + txt_Sophieu.value + "','f_Sotien':'" + f_Sotien + "','uId_Phieuxuat':'" + uId_Phieuxuat + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/Insert_Hinhthuc_ThanhToan_PX";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d == true) {
                        client_dgvLoaiTT.Refresh();
                    }
                    else {
                        alert("Error !");
                    }
                },
                error: onFail
            });

        }
        function InitPopupMenuHandler(s, e) {
            var imgButton = document.getElementById("<%=btnIn.ClientID%>");
              ASPxClientUtils.AttachEventToElement(imgButton, 'contextmenu', OnPreventContextMenu);
          }
          function OnGridContextMenu(evt) {
              ASPxPopupMenuClientControl.ShowAtPos(evt.clientX + ASPxClientUtils.GetDocumentScrollLeft(), evt.clientY + ASPxClientUtils.GetDocumentScrollTop());
              return OnPreventContextMenu(evt);
          }
          function OnPreventContextMenu(evt) {
              return ASPxClientUtils.PreventEventAndBubble(evt);
          }
          function Test(s, e) {
              var x = ASPxClientUtils.GetEventX(e.htmlEvent);
              var y = ASPxClientUtils.GetEventY(e.htmlEvent);
              pmRowMenu.ShowAtPos(x, y);
              //pmRowMenu.Show();

          }
          function menuItemClick(s, e) {
              if (e.item.name == "DONGY") {
                  InPhieuDongY();
              }
              else if(e.item.name == "TAYY") {
                  InPhieuTayY();
              }
              else if (e.item.name == "HD") {
                  In_HD_DonThuoc();
              } else {
                  In_DinhKem();
              }
          }
          function InPhieuDongY(s, e) {
              if (jo_GetSession("uId_Phieuxuat") == null) {
                  alert("Chưa chọn phiếu để in!");
              }
              else {
                  var $dialog = $('<div></div>')
                   .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/Rp_Phieuthanhtoan_Dongy.aspx" width="850px" height="100%"></iframe>')
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
              }
              return false;
          }
          function InPhieuTayY(s, e) {
              if (jo_GetSession("uId_Phieuxuat") == null) {
                  alert("Chưa chọn phiếu để in!");
              }
              else {
                  var $dialog = $('<div></div>')
                   .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/Rp_Phieuthanhtoan_TayY.aspx" width="850px" height="100%"></iframe>')
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
              }
              return false;
          }
          function In_HD_DonThuoc() {
              if (jo_GetSession("uId_Phieuxuat") == null) {
                  alert("Bạn chưa kê đơn thuốc!");
              }
              else {
                  var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src="../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Indonthuoc.aspx?" width="1000px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 1000,
                     title: "In hướng dẫn",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                     }
                 });
                  $dialog.dialog('open');
              }
          }

          function In_DinhKem() {
              if (jo_GetSession("uId_Khachhang") == null) {
                  alert("Bạn chưa chọn bệnh nhân!");
              }
              else {
                  var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src="../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_ConsultService.aspx?" width="1000px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 1000,
                     title: "In hướng dẫn",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                     }
                 });
                  $dialog.dialog('open');
              }
          }
          function txtGiathangKey(s, e) {
              if (isNaN(txtdongiathang.GetText().replace(/,/g, ""))) {
                  return false;
              }
              else {
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
                lblTongtien.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                txtSotiennhan.value = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                lblConlai.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                lblTienthua.innerHTML = "0";
            }
          }
        function InDonThuoc(s, e) {
            var donthuoc = jo_GetSession("uId_Phieuxuat")
            if (donthuoc = null) {
                alert("Hãy chọn đơn thuốc");
                return;
            }
            else {
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Print.aspx?type=donthuoc" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 855.733,
                     title: "In Đơn Thuốc",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                     }
                 });
                $dialog.dialog('open');
                return false;
            }
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>KÊ THUỐC</p>
    </div>
    <div style="clear: both"></div>
    <div class="div_box">
        <fieldset class="field_tt" style="float: left; margin-right: 10px;">
            <legend><span style="font-weight: bold; color: green">Thông tin đơn thuốc</span></legend>
            <table class="info_table">
                <tbody>
                    <tr>
                        <td class="info_table_td">Kho xuất:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlDMKho" ClientInstanceName="ddlDMKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td">Số đơn thuốc:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtMaphieu" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Bệnh nhân:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlKhachhang" EnableCallbackMode="true" ClientInstanceName="ddlKhachhang" runat="server" CallbackPageSize="10"
                                IncrementalFilteringMode="Contains" ValueField="uId_Khachhang" ValueType="System.String" TextFormatString="{0}-{1}-{2}-{3}"
                                Width="200px" DropDownWidth="500px" DropDownStyle="DropDown">
                                <Columns>
                                    <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã" />
                                    <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Họ tên" />
                                    <dx:ListBoxColumn FieldName="nv_Diachi_vn" Caption="Địa chỉ" />
                                    <dx:ListBoxColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" />
                                </Columns>
                                <ClientSideEvents SelectedIndexChanged="cbKhachhang_SelectChange" />
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td">Ngày xuất:
                        </td>
                         <td class="info_table_td">
                            <dx:ASPxDateEdit ID="deNgayxuat" ClientInstanceName="deNgayxuat" Style="float: left; margin-right: 8px;" Width="100px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                runat="server">
                            </dx:ASPxDateEdit>
                            <dx:ASPxCheckBox ID="chkChike" ClientInstanceName="cbkchike" runat="server" Text="Chỉ kê"></dx:ASPxCheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Bác sĩ lập:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlNhanvien" ClientInstanceName="ddlNhanvien" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                         <td class="info_table_td">Số thang:
                        </td>
                        <td class="info_table_td">
                           <dx:ASPxTextBox runat="server" ID="txtSothang"  onkeyup="txtGiathangKey()" ClientInstanceName="txtsothang" Width="200px" Text="1">
                           </dx:ASPxTextBox>
                        </td>        
                    </tr>
                    <tr>
                        <td class="info_table_td">Ly do khám:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtGhichu" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td class="info_table_td"> Đơn giá thang</td>
                        <td class="info_table_td">
<%--                            <dx:ASPxCheckBox runat="server" ID="chkGia" ClientInstanceName="chkgia" style="float:left; padding-right:10px">
                                <ClientSideEvents CheckedChanged="chkgiachange" />
                            </dx:ASPxCheckBox>--%>
                            <dx:ASPxTextBox runat="server" Enabled="false" onkeyup="txtGiathangKey()" Width="200px" ClientInstanceName="txtdongiathang" style="float:left"  ID="txtDongiathang">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="info_table_td" colspan="3">
                            <dx:ASPxButton ID="btnLuu" ClientInstanceName="btnLuu"  Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Lưu phiếu">
                                <Image Url="~/images/16x16/save.png"></Image>
                                <ClientSideEvents Click="btnLuuClick" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnClear" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnClear" runat="server" Text="Làm mới">
                                <ClientSideEvents Click="btnLammoiClick" />
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
        <fieldset class="field_tt" style="min-height: 150px">
            <legend><span style="font-weight: bold; color: green">Thông tin thanh toán</span></legend>
            <table class="info_table">
                <tbody>
                    <tr>
                        <td class="info_table_td">Tổng tiền:
                        </td>
                        <td class="info_table_td">
                            <asp:Label ID="lblTongtien" runat="server" Text="0,000,000"></asp:Label>
                        </td>
                        <td class="info_table_td">Số tiền nhận:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtSotiennhan" onkeyup="return onkeyup_txtsotiennhan(this)" Width="186px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnThanhtoanthe" Image-Url="~/images/16x16/card_discover_black.png" AutoPostBack="false" Style="float: left;" ClientInstanceName="btnThanhtoanthe_client" runat="server" Text="Thẻ">
                                <ClientSideEvents Click="ShowTheTT" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Giảm giá:
                        </td>
                        <td class="info_table_td" style="position: relative">
                            <div id="div_giamgia">
                                <asp:TextBox runat="server" onkeyup="return onkeyup_giamgia()" onfocus="ShowHideGiamgia()" Width="57px" CssClass="nano_textbox" ID="txtGiamgiaPhieu"></asp:TextBox>
                                <span id="span_giamgia">VNĐ</span>
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
                        <td class="info_table_td" style="width:127px"><asp:Label ID="lblTienthuatext" Text="Tiền thừa trả khách:" runat="server"></asp:Label>
                        </td>
                        <td class="info_table_td">
                            <asp:Label ID="lblTienthua" runat="server" Text="0,000,000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Khách cần trả:
                        </td>
                        <td class="info_table_td">
                            <asp:Label ID="lblConlai" runat="server" Text="0,000,000"></asp:Label>
                        </td>
                        <td class="info_table_td">Hình thức TT
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlLoaithanhtoan" ClientInstanceName="ddlLoaithanhtoan" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="188px" runat="server" ValueType="System.String">
                                <ClientSideEvents SelectedIndexChanged="ddlLoaithanhtoan_SelectedIndex" />
                            </dx:ASPxComboBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnKekhaiHT" Image-Url="~/images/16x16/pencil_add.png" AutoPostBack="false" Style="float: left;" ClientInstanceName="btnKekhai_client" runat="server" Text="Kê khai">
                                <ClientSideEvents Click="KeKhaiTT" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="info_table_td" colspan="5">
                            <dx:ASPxButton ID="btnThanhtoan" ClientInstanceName="btnThanhtoan" Image-Url="~/images/16x16/coins_in_hand.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Thanh toán">
                                <Image Url="~/images/16x16/coins_in_hand.png"></Image>
                                <ClientSideEvents Click="UpdatePhieuxuat" />
                            </dx:ASPxButton>
                            <%-- in phieu jolieD --%>
                            <dx:ASPxButton ID="btnIn" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnClear" runat="server" Text="In phiếu" Visible="True">
                              <%--  <ClientSideEvents Click="InPhieu" />--%>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnInDonThuoc" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnInDonThuoc" runat="server" Text="In đơn thuốc" Visible="True">
                             <ClientSideEvents Click="InDonThuoc" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Phiếu chi tiết</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <%-- harumy --%>
                   <%-- <td class="info_table_td">Mã Barcode:</td>--%>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txtBarcode" Visible="false" runat="server" ClientInstanceName="txtbarcode" AutoPostBack="false" EnableViewState="false" onkeypress="return txtBarcode_Textchange(event)"> 
                        </dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td"> Thuốc:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlMathang"  EnableCallbackMode="true" ClientInstanceName="ddlMathang" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Mathang" ValueType="System.String" TextFormatString="{0}-{1}"
                            Width="300px" CssClass="ddlMathang" DropDownWidth="500px" DropDownStyle="DropDown" OnCallback="ddlMathang_Callback" >
                            <Columns>
                                <dx:ListBoxColumn FieldName="v_MaMathang" Caption="Mã" Width="100%" />
                              
                                <dx:ListBoxColumn FieldName="nv_TenMathang_vn" Caption="Tên vật tư" Width="100%" />
                                <dx:ListBoxColumn FieldName="tendonvi" Caption="Đơn vị (nhỏ nhất)" Width="90px" />
                                <dx:ListBoxColumn FieldName="f_SL_Ton" Caption="Số lượng tồn" Width="70px" />
                            </Columns>
                            <ClientSideEvents SelectedIndexChanged="ddlMathang_Selectchange" />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td td_0_ipad">Đơn vị:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <dx:ASPxComboBox ID="ddlDonvi" OnCallback="ddlDonvi_Callback" onkeypress="return enter_ddlDonvi(event)" ClientInstanceName="ddlDonvi" 
                            DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="86px" runat="server" ValueType="System.String" SelectedIndex="0">
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
    <dx:ASPxGridView ID="dgvDevexpress" runat="server" CssClass="grid_dm_dv" ClientInstanceName="client_grid" OnRowDeleting="dgvDevexpress_RowDeleting"
        OnRowUpdating="dgvDevexpress_RowUpdating" AutoGenerateColumns="false" KeyFieldName="uId_Phieuxuat_Chitiet"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieuxuat_Chitiet"
                Name="uId_Phieuxuat_Chitiet">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn ReadOnly="true" Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên vị thuốc" FieldName="nv_TenMathang_vn"
                Name="nv_TenMathang_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="50px" HeaderStyle-HorizontalAlign="Center" ReadOnly="true" Caption="ĐVT" FieldName="tendonvi"
                Name="tendonvi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="60px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="120px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Đơn giá:" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <%--<dx:GridViewDataTextColumn Visible="true" Width="120px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Giảm giá:" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>--%>
            <dx:GridViewDataColumn Width="120px" FieldName="f_Giamgia" VisibleIndex="1" Caption="Giảm giá" CellStyle-HorizontalAlign="Right">
                <DataItemTemplate>
                    <%#Eval("f_Giamgia", "{0:0,0}")%>
                </DataItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtGiamgia" Width="113px" Text='<%# Eval("f_Giamgia") %>'
                        runat="server"></asp:TextBox>
                </EditItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Width="140px" Caption="Thành tiền" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Visible="true" Width="200px" Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Ghichu" Name="nv_Ghichu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="1" Width="40px" ButtonType="Image">
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton>
                    <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                </UpdateButton>
                <EditButton>
                    <Image AlternateText="Save" Url="~/images/btn_Edit.png" />
                </EditButton>
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="Delete" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Delete">
                        <Image AlternateText="Delete" Url="~/images/btn_Delete.png">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowFooter="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <TotalSummary>
            <dx:ASPxSummaryItem DisplayFormat="Thành tiền: {0:0,0}" FieldName="f_Tongtien" SummaryType="Sum" />
        </TotalSummary>
        <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" CustomButtonClick="OnCustomButtonClick" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxPopupControl ID="pcDsTheTT" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDsTheTT"
        HeaderText="Danh sách thẻ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDsTheTT.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="900px" Height="370px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div style="clear: both"></div>
                            <dx:ASPxGridView ID="dgvDsTheTT" runat="server" OnDataBinding="dgvDsTheTT_DataBinding" ClientInstanceName="client_dgvDsTheTT"
                                AutoGenerateColumns="false" KeyFieldName="uId_Khachhang_Goidichvu" SettingsPager-PageSize="8"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang_Goidichvu"
                                        Name="uId_Khachhang_Goidichvu">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Mã thẻ" FieldName="vMaBarcode"
                                        Name="vMaBarcode">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="90px" Caption="Tên thẻ" FieldName="nv_Tengoi_vn"
                                        Name="nv_Tengoi_vn">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày mua" Width="100px" FieldName="d_Ngaymua"
                                        Name="d_Ngaymua">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Số tiền" Width="100px" FieldName="f_Sotien"
                                        Name="f_Sotien">
<PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>

<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Giá trị thẻ" Width="100px" FieldName="f_Giatrigoi"
                                        Name="f_Giatrigoi">
<PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>

<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày BĐ" Width="100px" FieldName="d_NgayBD"
                                        Name="d_NgayBD">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày KT" Width="100px" FieldName="d_NgayKT"
                                        Name="d_NgayKT">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" Width="130px" FieldName="nv_Tentrangthai_vn"
                                        Name="nv_Tentrangthai_vn">
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Chọn thẻ" href='javascript:void(0)' onclick="return ClosePopupTheTT()">
                                                <img src="../../../images/bub.png" /></a>
                                        </DataItemTemplate>

                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="10">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_dsthe(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
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
                                                HeaderStyle-HorizontalAlign="Center" Width="100px" Caption="Số phiếu" FieldName="v_Maphieuxuat"
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
                                                HeaderStyle-HorizontalAlign="Center" Caption="Bệnh nhân" Width="290px" FieldName="nv_Hoten_vn"
                                                Name="nv_Hoten_vn">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Nội dung" Width="270px" FieldName="nv_Noidungxuat_vn"
                                                Name="nv_Noidungxuat_vn">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Đơn giá" Width="80px" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongdongia"
                                                Name="f_Tongdongia">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Giảm giá" Width="80px" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Giamgia"
                                                Name="f_Giamgia">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán" Width="100px" FieldName="f_Tongtienthuc"
                                                Name="f_Tongtienthuc">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Xuất từ kho" FieldName="nv_Tenkho_vn"
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
    <dx:ASPxPopupControl ID="pcHinhThucTT" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcHinhThucTT"
        HeaderText="Kê khai hình thức" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcHinhThucTT.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                <dx:ASPxPanel ID="ASPxPanel4" runat="server" Width="500px" Height="470px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent5" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel_Kekhai" runat="server">
                                <ContentTemplate>
                                    <div style="clear: both"></div>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Kê khai hình thức</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Số phiếu:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <asp:Label ID="lblSophieuTT" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Số tiền nhận:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <asp:TextBox runat="server" Width="200px"  CssClass="nano_textbox" ID="txtSotiennhanTT"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Hình thức TT:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <dx:ASPxComboBox ID="ddlHinhthucTT_Pop" ClientInstanceName="ddlHinhthucTT_Pop" DropDownStyle="DropDown" Height="25px" Width="200px" runat="server"></dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Số tiền:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" onkeyup="return jo_ThousanSereprate(this)" Width="200px" CssClass="nano_textbox" ID="txtSotienTT_Pop"></asp:TextBox>
                                                </td>
                                                <td>
                                                <dx:ASPxButton ID="ASPxButton1" Image-Url="~/images/16x16/card_discover_black.png" AutoPostBack="false" Style="float: left;" ClientInstanceName="btnThanhtoanthe" runat="server" Text="Thẻ">
                                                    <ClientSideEvents Click="ShowTheTT" />
                                                </dx:ASPxButton>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Mã số:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <asp:TextBox runat="server" Width="200px" onkeypress="return enter_txtMaSoTT_Pop(event)" placeholder="Điền mã thẻ tài khoản và enter" AutoPostBack="false" CssClass="nano_textbox" ID="txtMaSoTT_Pop"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ghi chú:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtGhichu_Pop"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Literal ID="lblError" runat="server"></asp:Literal>
                                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btnLuuHinhthuc" Image-Url="~/images/btn_Save.png" ClientInstanceName="btnLuuHinhthuc" AutoPostBack="false" runat="server" Text="Lưu" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="btnLuuHinhthuc_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnCancelHinhthuc" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopup_DSTT" />
                                                        </dx:ASPxButton>
                                                    </div>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <dx:ASPxGridView ID="dgvLoaiTT" runat="server" ClientInstanceName="client_dgvLoaiTT" OnRowDeleting="dgvLoaiTT_RowDeleting"
                                        AutoGenerateColumns="false" KeyFieldName="uId_LoaiTT" SettingsPager-PageSize="8"
                                        SettingsPager-Position="Bottom">
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_LoaiTT"
                                                Name="uId_LoaiTT">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Loại TT" FieldName="nv_TenLoaiTT"
                                                Name="nv_TenLoaiTT">
                                                <Settings AutoFilterCondition="Contains"></Settings>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="90px" Caption="Mã số" FieldName="v_Maso"
                                                Name="v_Maso">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Số tiền" Width="70px" FieldName="f_Sotien"
                                                Name="f_Sotien">
                                                <PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Loại TT" Width="100px" FieldName="nv_TenLoaiTT"
                                                Name="nv_TenLoaiTT">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu_vn"
                                                Name="nv_Ghichu_vn">
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
                                        <SettingsPager PageSize="10">
                                        </SettingsPager>
                                        <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                        <Styles>
                                            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                            </AlternatingRow>
                                        </Styles>
                                    </dx:ASPxGridView>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel_Kekhai" DisplayAfter="0" DynamicLayout="false">
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
       <dx:ASPxPopupMenu ID="popMenu" runat="server" PopupElementID="btnIn" ClientInstanceName="pmRowMenu"   PopupHorizontalAlign="OutsideRight"  PopupVerticalAlign="TopSides"
            PopupAction="LeftMouseClick">
            <Items>
                <dx:MenuItem Text="In đơn thuốc đông y" Name="DONGY"></dx:MenuItem>
                <dx:MenuItem Text="In đơn thuốc tây y" Name="TAYY"></dx:MenuItem>
      <%--          <dx:MenuItem Text="In hướng dẫn" Name="HD"></dx:MenuItem>--%>
                <dx:MenuItem Text="In đính kèm" Name="DK"></dx:MenuItem>
            </Items>
            <ClientSideEvents Init="InitPopupMenuHandler" ItemClick="menuItemClick" />
        </dx:ASPxPopupMenu>
</asp:Content>
