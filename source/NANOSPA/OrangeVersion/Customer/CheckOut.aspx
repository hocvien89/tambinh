<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CheckOut.aspx.vb" Inherits="NANO_SPA.CheckOut" %>

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
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script src="../../../../Js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
    <link href="../../../../Css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        var tienthua_Data;
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
            $("#popupDiscount").hide();
            $("#gv_chothanhtoan").hide();
            if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
                //btnKekhai_client.SetEnabled(true);
                //btnThanhtoanthe_client.SetEnabled(false);
            } else {
                //btnThanhtoanthe_client.SetEnabled(true);
                //btnKekhai_client.SetEnabled(false);
            }
        });
        $(document).ready(function () {
            document.onkeyup = KeyCheck;
            function KeyCheck(e) {
                var KeyID = (window.event) ? event.keyCode : e.keyCode;
                if (KeyID == 113) {
                    document.getElementById('<%=btnThanhtoan.ClientID%>').click();
                }
                if (KeyID == 115) {
                    document.getElementById('<%=btnIn.ClientID%>').click();
                }
                if (KeyID == 120) {
                    document.getElementById('<%=btnPhieumoi.ClientID%>').click();
                }
                if (KeyID == 27) {
                    document.getElementById('<%=btCancel.ClientID%>').click();
                }
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
        function GetThongTinPhieu() {
            var param_dt = "{'uId_Phieudichvu':'" + jo_GetSession("uId_Phieudichvu") + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuDichVu";
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
        function gridPhieuchitiet_EndCallback(s, e) {

            if (s.cpIsUpdated == "update") {
                GetThongTinPhieu();
                s.cpIsUpdated = "";
            }
            if (s.cpIsHuyDV == "after") {
                alert("Phiếu đã thanh toán! vui lòng cho biết lí do xóa!");
                $("#box_huy").css("display", "");
                var txtLidoxoa = document.getElementById("<%=txtLidoxoa.ClientID %>");
                txtLidoxoa.focus();
                s.cpIsHuyDV = "";
            }
            if (s.cpIsHuyDV == "before") {
                GetThongTinPhieu();
                s.cpIsHuyDV = "";
            }
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }
        }
        //Custom commad button phieu dich vu chi tiet
        var _handle = true;
        function OnCustomButtonClick(s, e) {
            switch (e.buttonID) {
                case 'Delete':
                    if (confirm("Bạn có muốn xóa bản ghi?")) {
                        _handle = false;
                        s.DeleteRow(e.visibleIndex);
                        //client_Phieuchitiet.GetRowValues(e.visibleIndex, 'uId_Dichvu;f_Dongia;f_Giamgia;f_Soluong;f_Tongtien', OnGridPhieuchitietSelectionComplete);
                    }
                    break;
                case 'Edit': s.StartEditRow(e.visibleIndex);
                    break;
                case 'Save': s.UpdateEdit();
                    break;
                case "New": s.AddNewRow();
            }
        }
        //Su kien khi chon 1 dong
        function SelChanged_chitiet(s, e) {
            if (!e.isSelected) {

            } else {
                client_Phieuchitiet.GetRowValues(e.visibleIndex, "uId_Phieudichvu_Chitiet;uId_Dichvu", dichvuchitiet);
            }
        }

        function dichvuchitiet(values) {
            var hdfIDdichvuhuy = document.getElementById("<%=hdfIDdichvuhuy.ClientID%>");
            hdfIDdichvuhuy.value = values[0];
            pcHuydichvu.Show();
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
        function UpdatePhieuDV(s, e) {
            var hdfCheckthanhtoan = document.getElementById("<%=hdfCheckthanhtoan.ClientID%>");
            if (hdfCheckthanhtoan.value == 1) {
                alert("Phiếu dịch vụ đã được thanh toán không thể sửa thông tin!");
                e.processOnServer = false;
            }
            else if (hdfCheckthanhtoan.value == 2) {
                alert("Phiếu dịch vụ không có mặt hàng để thanh toán!");
                e.processOnServer = false;
            }
            else {
                var uid_Thethanhtoan = jo_GetSession("uId_Khachhang_Goidichvu_TT");
                if (uid_Thethanhtoan == null & ddlLoaithanhtoan.GetValue().toString() == "01d16c43-7a03-49dc-afd2-39e79a1439f1") {
                    alert("Hãy chọn loại hình thanh toán khác! hoặc chọn thẻ thanh toán nếu muốn thanh toán bằng thẻ");
                    ddlLoaithanhtoan.ShowDropDown();
                    return false;
                }
                var lblSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID %>");
                var ddlLoaithanhtoanvalue = ddlLoaithanhtoan.GetValue().toString();
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                //var ddlNhanvienvalue = ddlNhanvien.GetValue().toString();
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var txtHH = document.getElementById("<%=txtHH.ClientID%>");
                var ddlNhomphieuvalue = ddlNhomphieu.GetValue().toString();
                var giamgia = "0";
                var isVNDChecked = rbGiamgiaVND.GetChecked();
                var isphantramChecked = rbGiamgiaphantram.GetChecked();
                if (isVNDChecked) {
                    giamgia = txtGiamgiaPhieu.value.replace(/,/g, "");
                }
                if (isphantramChecked) {
                    giamgia = (parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) * parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) / 100);
                }
                var param_dt = "{'v_Sophieu':'" + lblSophieu.innerHTML + "','d_Ngay':'','f_Tongtienthuc':'" + txtSotiennhan.value.replace(/,/g, "") + "','tienthua':'" +
                    //lblTienthua.innerHTML.replace(/,/g, "") + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
                    tienthua_Data + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
                    "','f_Giamgia':'" + giamgia + "','uId_Nhanvien':'','nv_Ghichu_vn':'" +
                    txtGhichu.value + "','HH':'" + txtHH.value + "','Id_Nhomphieu':'" + ddlNhomphieuvalue + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/UpdatePhieudichvu";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        alert(msg.d);
                        if (msg.d == "Thanh toán thành công!") {
                            lblkhachtra.SetText("Đã thanh toán");
                        }
                        btnThanhtoan.SetEnabled(false);
                        client_dgvDanhsachcho.Refresh();
                    },
                    error: onFail
                });
                client_dgvDsTheTT.Refresh();
                return false;
            }
    }
    function ClearPhieuDichVu(s, e) {
        checknew = "clear";
        checkThanhtoan = 0;
        btnThanhtoan.SetEnabled(true);
        jo_RemoveSession("uId_Phieudichvu");
        jo_RemoveSession("v_MaTTT");
        jo_RemoveSession("uId_Khachhang_Goidichvu_TT");
        client_grid.UnselectRows();
        var txtSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
        var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID %>");
        var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
        var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
        var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
        var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
        var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
        var txtHH = document.getElementById("<%=txtHH.ClientID%>");
        //Tao moi ma khach hang
        var param_dt = "{'ngaynhap':'" + deNgaylap.GetText() + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateSoPhieuDichVu";
        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                if (msg.d != "") {
                    txtSophieu.value = msg.d;
                }
            },
            error: onFail
        });
        txtSotiennhan.value = "0";
        txtGiamgiaPhieu.value = "0";
        txtGhichu.value = "";
        lblTienthua.innerHTML = "0";
        lblTongtien.innerHTML = "0";
        lblConlai.innerHTML = "0";
        txtHH.value = "0";
        $("#box_huy").css("display", "none");
        $("#readmore").css("display", "none");
        ddlHinhthucTT_Pop.SetValue("43915768-694A-49B8-8DB2-6332718DB194");
        ddlLoaithanhtoan.SetValue("43915768-694a-49b8-8db2-6332718db194");
        client_Phieuchitiet.Refresh();
        return false;
    }
    function onFail(ex) {
        alert(ex._message + " fail");
        return false;
    }
    function deNgaplapChange(s, e) {
        if (jo_GetSession("uId_Phieudichvu") == "" || jo_GetSession("uId_Phieudichvu") == null) {
            var txtSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
                //Tao moi ma khach hang
                var param_dt = "{'ngaynhap':'" + deNgaylap.GetText() + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateSoPhieuDichVu";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d != "") {
                            txtSophieu.value = msg.d;
                        }
                    },
                    error: onFail
                });
            }
        }
        //Show popup danh sach phieu
        function ShowDSPhieuWindow() {
            pcDanhsachphieu.Show();
        }
        function ClosePopup() {
            pcDanhsachphieu.Hide();
            return false;
        }
        //Chon danh sach phieu
        function SelChanged_dsphieu(s, e) {
            if (!e.isSelected) {
            } else {
                client_dgvDanhsachphieu.GetRowValues(e.visibleIndex, 'uId_Phieudichvu;v_Sophieu', OnGridSelectionDSPhieuComplete);
            }
        }
        function OnGridSelectionDSPhieuComplete(values) {
            jo_CreateSession("uId_Phieudichvu", values[0]);
            client_Phieuchitiet.Refresh();
            var param_dt = "{'uId_Phieudichvu':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuDichVu";
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
        var checkThanhtoan = 0
        function OnSuccessCall(msg) {

            if (msg.d != "") {
                var defaultdata = msg.d.split("$");
                alert(defaultdata[2]);
                var txtSoPhieu = document.getElementById("<%=lblSophieu.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var txtHH = document.getElementById("<%=txtHH.ClientID%>");
                var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
                txtSoPhieu.value = defaultdata[0];
                //var date_ngaylap = new Date(defaultdata[1]);
                //deNgaylap.SetDate(date_ngaylap);
                lblTongtien.innerHTML = jo_FormatMoney(jo_IsString(defaultdata[6]));
                txtGiamgiaPhieu.value = jo_IsString(defaultdata[3]);
                lblConlai.innerHTML = jo_FormatMoney((jo_IsString(parseFloat(defaultdata[6])) - parseFloat(defaultdata[3])));
                txtSotiennhan.value = jo_FormatMoney(jo_IsString(defaultdata[2]));
                if (defaultdata[2] > 0) {
                    checkThanhtoan = 1;
                }
                else {
                    checkThanhtoan = 0;
                }
                lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(defaultdata[6]) - parseFloat(defaultdata[3]) - parseFloat(defaultdata[2]))));
                if (defaultdata[4] != null && defaultdata[4] != "") {
                    ddlLoaithanhtoan.SetValue(defaultdata[4]);
                }
                txtGhichu.value = defaultdata[7];
                txtHH.value = defaultdata[8];
                ddlNhomphieu.SetValue(defaultdata[9]);
                btnThanhtoan.SetEnabled(true);
                var tienthua = jo_IsString(parseFloat(lblTienthua.innerHTML.replace(/,/g, "")));
                if (tienthua < 0) {
                    lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
                }
                else {
                    lblTienthuatext.innerHTML = "Tiền khách nợ:";
                }
            }
        }
        //Chon danh sach the thanh toan
        function SelChanged_dsthe(s, e) {
            if (!e.isSelected) {
            } else {
                client_dgvDsTheTT.GetRowValues(e.visibleIndex, 'uId_Khachhang_Goidichvu;f_Giatrigoi;vMaBarcode', OnGridSelectionDSTheComplete);
            }
        }
        function OnGridSelectionDSTheComplete(values) {
            jo_CreateSession("uId_Khachhang_Goidichvu_TT", values[0]);
            jo_CreateSession("v_MaTTT", values[2]);
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");

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

            txtSotiennhan.value = lblConlai.innerHTML;
            tienthua_Data = parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(jo_IsString(values[1]))
            lblTienthua.innerHTML = (jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(jo_IsString(values[1])))))).replace(/-/g, "");
            ddlLoaithanhtoan.SetValue("01d16c43-7a03-49dc-afd2-39e79a1439f1");
            var tienthua = jo_IsString(parseFloat(lblTienthua.innerHTML.replace(/,/g, "")));
            if (tienthua_Data > 0) {
                lblTienthuatext.innerHTML = "Tiền khách nợ:";
            }
            else {
                lblTienthuatext.innerHTML = "Số dư tài khoản:";
            }
        }
        function ShowHideGiamgia() {
            $("#popupDiscount").toggle();
        };
        $(function () {
            $('#div_giamgia').click(function (e) {
                e.stopPropagation();
            });
        });
        $('html').click(function () {
            $("#popupDiscount").hide();
        });
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
                lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")))));
                document.getElementById("span_giamgia").innerHTML = "VNĐ";
            }
            if (isphantramChecked) {
                lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - (parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) * parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) / 100))));
                txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
                lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")))));
                document.getElementById("span_giamgia").innerHTML = "%";
            }
            return false;
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
        function onkeyup_txtsotiennhan(id) {
            jo_RemoveSession("uId_Khachhang_Goidichvu_TT");
            jo_ThousanSereprate(id);
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
            tienthua_Data = (parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")));
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, ""))))).replace(/-/g, "");
            var tienthua = jo_IsString(parseFloat(lblTienthua.innerHTML.replace(/,/g, "")));
            if (tienthua_Data > 0) {
                lblTienthuatext.innerHTML = "Tiền khách nợ:";
            }
            else {
                lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
            }
        }
        function onkeyup_txtsotiennhanTT(id) {
            jo_ThousanSereprate(id);
        }
        function Inphieu(s, e) {
            if (jo_GetSession("uId_Phieudichvu") == null) {
                alert("Chưa chọn phiếu để in!");
            }
            else {
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rp_Phieudichvu.aspx" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 855.733,
                     title: "In phiếu dịch vụ",
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
        function OpenPopupDSNo(s, e) {
            pcDanhsachno.Show();
            return false;
        }
        function Thietlaplieutrinh(uId_Dichvu) {
            jo_CreateSession("uId_Dichvu_Dieutri", uId_Dichvu);
            window.location.href = "../../OrangeVersion/Customer/CustomerTherapy.aspx";
            return false;
        }
        function BackQuanLyKhachHang(s, e) {
            window.location.href = "../../OrangeVersion/Customer/CustomerList.aspx";
            return false;
        }
        function Refresh_pcDanhsachphieu(s, e) {
            client_dgvDanhsachphieu.Refresh();
            return false;
        }
        function Refresh_DSTheTT(s, e) {
            client_dgvDsTheTT.Refresh();
            return false;
        }
        function ShowTheTT(s, e) {
            pcDsTheTT.Show();
            return false;
        }
        function KeKhaiTT(s, e) {
            var txtSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblSophieuTT = document.getElementById("<%=lblSophieuTT.ClientID%>");
            var txtSotiennhanTT = document.getElementById("<%=txtSotiennhanTT.ClientID%>");
            lblSophieuTT.innerHTML = txtSophieu.value;
            txtSotiennhanTT.value = txtSotiennhan.value;
            client_dgvLoaiTT.Refresh();
            pcHinhThucTT.Show();
            return false;
        }
        function ClosePopupTheTT() {
            pcDsTheTT.Hide();
            return false;
        }
        function ReadMore() {
            $("#readmore").toggle();
            return false;
        }
        function Capthe(s, e) {
            var param_dt_p = "{'uId_Phieudichvu':'" + jo_GetSession("uId_Phieudichvu") + "'}";
            var pageUrl_p = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuDichVu";
            $.ajax({
                type: "POST",
                url: pageUrl_p,
                data: param_dt_p,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    var phieudata = msg.d.split("$");
                    if (phieudata[10].toUpperCase() == "TRUE") {
                        var param_dt = "{'uId_Phieudichvu':'" + jo_GetSession("uId_Phieudichvu") + "'}";
                        var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinCapThe";
                        $.ajax({
                            type: "POST",
                            url: pageUrl,
                            data: param_dt,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (msg) {
                                var defaultdata = msg.d.split("$");
                                if (defaultdata[0] == "TAIKHOAN") {
                                    var txtTenthe = document.getElementById("<%=txtTenthe.ClientID %>");
                                    var txtGiatri = document.getElementById("<%=txtGiatri.ClientID%>");
                                    var hdfDongiathe = document.getElementById("<%=hdfDongiathe.ClientID%>");
                                    var lblKhachhangThe = document.getElementById("<%=lblKhachhangThe.ClientID%>");
                                    txtTenthe.value = defaultdata[1];
                                    txtGiatri.value = jo_FormatMoney(jo_IsString(defaultdata[2]));
                                    hdfDongiathe.value = defaultdata[2];
                                    lblKhachhangThe.innerHTML = defaultdata[4];
                                    jo_CreateSession("uId_Dichvu_The", defaultdata[3]);
                                }
                            },
                            error: onFail
                        });
                        pcCapthe.Show();
                    }
                    else {
                        alert("Yêu cầu thanh toán trước khi cấp thẻ!");
                    }
                },
                error: onFail
            });
            return false;
        }
        function ClosePopup_The(s, e) {
            pcCapthe.Hide();
            return false;
        }
        function ClosePopup_DSTT(s, e) {
            pcHinhThucTT.Hide();
            return false;
        }
        function ddlLoaithanhtoan_SelectedIndex(s, e) {
            if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
                btnKekhai_client.SetEnabled(true);
                //btnThanhtoanthe_client.SetEnabled(false);
            } else {
                //btnThanhtoanthe_client.SetEnabled(true);
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
        function loaddata() {
            window.external.LoadDSTheTT();
        }
        function XuLyPhieuDichVu(uId_Phieudichvu, uId_Khachhang, uId_TrangthaiKH) {
            alert("!23");
            var uId_Nhanvien_phong = jo_GetSession("uId_Phongban_NV_Current")
            if (uId_Nhanvien_phong == "98cab2b9-ff4c-4d25-ba8c-202aa0b854c2") {
                jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
                jo_CreateSession("uId_Khachhang", uId_Khachhang);
                jo_CreateSession("uId_TrangthaiKH", uId_TrangthaiKH);
                window.location.href = "../../OrangeVersion/Customer/CheckOut.aspx";
            }
            return false;
        }
        function ThanhtoancongnoDV(uId_Phieudichvu, vSophieu) {
            var tienno = "";
            var param_dt = "{'uId_Phieudichvu':'" + uId_Phieudichvu + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/GetNoPhieuDV";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        tienno = msg.d
                    }
                },
                error: onFail
            });
            if (parseFloat(tienno) > 0) {
                jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
                window.location.href = "../../OrangeVersion/Finance/Debt.aspx?pdv=" + vSophieu;
            }
            else {
                alert("Phiếu không nợ!");
            }
            return false;
        }
        function ShowPhieuXuat() {
            $("#gv_chothanhtoan").toggle("slow");
            return false;
        }
        function Chonphieuxuat(uId_Phieuxuat, uId_Khachhang) {
            jo_CreateSession("uId_Phieuxuat", uId_Phieuxuat);
            jo_CreateSession("uId_Khachhang", uId_Khachhang);
            window.location.href = "../../OrangeVersion/Product/ExportProduct.aspx";
            return false;
        }
        function phongchange(s, e) {
            var item = ""
            item = ddlDMPhong.GetValue() + "$PHONG";
            ddlTrangthai.SetValue(SetTrangThaiByPhong(item))
        }

        function ddlTrangthaiChange(s, e) {
            var item = ""
            item = ddlTrangthai.GetValue() + "$TT";
            ddlDMPhong.SetValue(SetTrangThaiByPhong(item))
        }
        function CheckHuydichvu(s, e) {
            var hdfIDdichvuhuy = document.getElementById("<%=hdfIDdichvuhuy.ClientID%>");
            if (hdfIDdichvuhuy.value == "") {
                alert("Hãy chọn một dịch vụ để xóa");
                e.processOnServer = false;
            }
            if (txtlydohuydv.GetText() == "") {
                txtlydohuydv.Focus();
                alert("Hãy nhập lý do để xóa phiếu")
                e.processOnServer = false;
            }
        }
        function Xoadichvu(s, e) {
            pcHuydichvu.Show();
            return false;
        }
        function closePup() {
            pcHuydichvu.Hide();
            client_Phieuchitiet.Refresh();
        }
    </script>
    <style type="text/css">
        #pendroom td {
            padding: 2px;
        }

        #gv_chothanhtoan {
            position: relative;
            top: 5px;
        }
    </style>
    <div class="brest_crum">
        <dx:ASPxButton ID="btnQuaylai" Visible="false" Style="float: left; margin-right: 7px; margin-left: 5px" Image-Url="~/images/16x16/back.png" ClientInstanceName="btnQuaylai" AutoPostBack="false" runat="server" Text="Quay lại">
            <ClientSideEvents Click="BackQuanLyKhachHang" />
        </dx:ASPxButton>
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THANH TOÁN PHÍ - PHÒNG KẾ TOÁN</p>
        <%--<asp:Literal ID="ltrTitleHeader" Text="THÊM PHIẾU DỊCH VỤ" runat="server"></asp:Literal>--%>
    </div>
    <asp:HiddenField ID="hdfCheckthanhtoan" runat="server" />
    <div style="clear: both"></div>
    <dx:ASPxPageControl ID="PgcThanhtoan" runat="server" Width="100%">
        <TabPages>
            <dx:TabPage Text="Dịch vụ" Visible="true">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <fieldset class="field_tt" style="width: 45%; float: left">
                            <legend><span style="font-weight: bold; color: green">Danh sách chờ</span></legend>
                            <%--                            <fieldset class="field_tt">
                            </fieldset>--%>
                            <dx:ASPxGridView ID="dgvDanhsachcho" runat="server" ClientInstanceName="client_dgvDanhsachcho" AutoGenerateColumns="false" SettingsPager-PageSize="4"
                                KeyFieldName="uId_Phieudichvu;uId_Khachhang;uId_TrangthaiKH;uId_Trangthai;uId_Phong"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieudichvu"
                                        Name="uId_Phieudichvu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phong"
                                        Name="uId_Phong">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="110px" Caption="Số phiếu" FieldName="v_Sophieu"
                                        Name="v_Sophieu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Tên khách hàng" FieldName="nv_Hoten_vn" Width="140px"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Điện thoại" FieldName="v_DienthoaiDD"
                                        Name="v_DienthoaiDD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Đang ở phòng" FieldName="nv_Tenphong_vn"
                                        Name="nv_Tenphong_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" FieldName="b_Trangthai"
                                        Name="b_Trangthai">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu" Width="50px"
                                        Name="nv_Ghichu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày chuyển" FieldName="d_Ngaylam"
                                        Name="d_Ngaylam">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Chọn khách hàng" href='javascript:void(0)' onclick="return <%# String.Format("XuLyPhieuDichVu('{0}', '{1}','{2}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("uId_TrangthaiKH")).ToString%>">
                                                <img src="../../../images/bub.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="4" Width="30px" Caption="" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                            <Image Url="~/images/btn_Delete.png"></Image>
                                        </DeleteButton>
                                    </dx:GridViewCommandColumn>
                                </Columns>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="10">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false"
                                    ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior AllowFocusedRow="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" FocusedRowChanged="grid_FocusedRowChanged" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                    <GroupRow Font-Bold="true"></GroupRow>
                                </Styles>
                            </dx:ASPxGridView>

                        </fieldset>
                        <%--<div style="clear: both"></div>--%>
                        <div class="bill_infor" style="float: left; width: 52%; min-height: 330px">
                            <fieldset class="field_dsphieu" style="float: left; width: 100%; height: auto; min-height: 150px">
                                <legend><span style="font-weight: bold; color: green">Thông tin phiếu</span></legend>
                                <div class="box_thanhtoan" style="min-height: 150px;">
                                    <dx:ASPxGridView ID="dgvPhieuchitiet" runat="server" ClientInstanceName="client_Phieuchitiet"
                                        AutoGenerateColumns="false" KeyFieldName="uId_Phieudichvu_Chitiet;uId_Dichvu;nv_Tendichvu_vn" CssClass="grid_dm_dv" SettingsPager-PageSize="8"
                                        SettingsPager-Position="Bottom" OnDataBinding="dgvPhieuchitiet_DataBinding" OnRowUpdating="dgvPhieuchitiet_RowUpdating">
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Dichvu"
                                                Name="uId_Dichvu">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"
                                                Name="nv_Tendichvu_vn">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Width="70px" Caption="Tổng lần" FieldName="f_Solan"
                                                Name="f_Solan">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Đã ĐT" Width="70px" FieldName="i_SL_daDieutri"
                                                Name="i_SL_daDieutri">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Đơn giá" Width="70px" FieldName="f_Dongia"
                                                Name="f_Dongia">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="SL" Width="50px" FieldName="f_Soluong"
                                                Name="f_Soluong">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataColumn Width="60px" FieldName="f_Giamgia" VisibleIndex="1" Caption="Giảm giá" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <%#Eval("f_Giamgia", "{0:0,0}")%>
                                                </DataItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGiamgia" Width="60px" Text='<%# Eval("f_Giamgia")%>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                                HeaderStyle-HorizontalAlign="Center" Caption="Thành tiền" Width="70px" FieldName="f_Tongtien"
                                                Name="f_Tongtien">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <a id="popup" title="Hủy dịch vụ" href='javascript:void(0)' onclick="Xoadichvu">
                                                        <img src="../../../images/btn_Delete.png" /></a>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                        </Columns>
                                        <SettingsEditing Mode="Inline" />
                                        <SettingsPager PageSize="3">
                                        </SettingsPager>
                                        <Settings ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                        <%--                                        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />--%>
                                        <ClientSideEvents CustomButtonClick="OnCustomButtonClick" EndCallback="gridPhieuchitiet_EndCallback"  FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_chitiet(s, e); }" /><%--RowDblClick="grid_RowDblClick"--%>
                                        <Styles>
                                            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                            </AlternatingRow>
                                        </Styles>
                                    </dx:ASPxGridView>
                                    <div class="box_huy" id="box_huy" style="display: none">
                                        <span style="color: Red; margin-left: 45px">Phiếu đã thanh toán! Xin vui lòng cho biết lí do xóa</span>
                                        <asp:TextBox ID="txtLidoxoa" Width="225px" placeholder="Nhập lí do xóa" CssClass="nano_textbox" runat="server"></asp:TextBox>
                                        <dx:ASPxButton OnClick="btnLidoxoa_Click" ID="btnLidoxoa" Image-Url="~/images/btn_Delete.png" Style="float: right; margin-left: 10px; position: relative; bottom: 6px" ClientInstanceName="btnLidoxoa" runat="server" Text="Hủy">
                                        </dx:ASPxButton>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="field_tt" style="float: left; width: 100%">
                                <legend><span style="font-weight: bold; color: green">Thông tin thanh toán -
                                    <asp:Label ID="lblSophieu" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    - 
                                    <asp:Label ID="lblHoten" runat="server" Text="" ForeColor="Orange"></asp:Label>

                                </span></legend>
                                <div class="box_thanhtoan" style="min-height: 330px;">
                                    <table class="info_table" style="float: right">
                                        <tbody>
                                            <tr>
                                                <td class="info_table_td" style="width: 135px">Tổng tiền:
                                                </td>
                                                <td class="info_table_td" style="width: 120px">
                                                    <asp:Label ID="lblTongtien" runat="server" Text="0,000,000"></asp:Label>
                                                </td>
                                                <td class="info_table_td" style="width: 120px">
                                                    <dx:ASPxLabel ID="lblKhachtra" runat="server" Text="" ClientInstanceName="lblkhachtra"></dx:ASPxLabel>
                                                </td>
                                                <td class="info_table_td" style="width: 120px">
                                                    <asp:TextBox runat="server" Width="120px" onkeyup="return onkeyup_txtsotiennhan(this)" CssClass="nano_textbox" ID="txtSotiennhan"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <dx:ASPxButton ID="btnThanhtoanthe" Image-Url="~/images/16x16/card_discover_black.png" Visible="false" AutoPostBack="false" Style="float: left;" ClientInstanceName="btnThanhtoanthe_client" runat="server" Text="Thẻ">
                                                        <ClientSideEvents Click="ShowTheTT" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td" style="width: 140px">Giảm giá phiếu:
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
                                                <td class="info_table_td">
                                                    <asp:Label ID="lblTienthuatext" Text="Tiền thừa trả khách:" runat="server"></asp:Label>
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
                                                <td class="info_table_td">Hình thức TT:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlLoaithanhtoan" ClientInstanceName="ddlLoaithanhtoan" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="120px" runat="server" ValueType="System.String">
                                                        <ClientSideEvents SelectedIndexChanged="ddlLoaithanhtoan_SelectedIndex" ButtonClick="loaddata" />
                                                    </dx:ASPxComboBox>
                                                </td>
                                                <td>
                                                    <dx:ASPxButton ID="btnKekhaiHT" Image-Url="~/images/16x16/pencil_add.png" AutoPostBack="false" Style="float: left;" ClientInstanceName="btnKekhai_client" Visible="false" runat="server" Text="Kê khai">
                                                        <ClientSideEvents Click="KeKhaiTT" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ghi chú:
                                                </td>
                                                <td colspan="4" class="info_table_td">
                                                    <asp:TextBox TextMode="MultiLine" runat="server" Width="446px" Height="17px" CssClass="nano_textbox" ID="txtGhichu"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td" colspan="3" style="text-align: right">
                                                    <asp:LinkButton ID="lbtReadmore" OnClientClick="return ReadMore()" runat="server" Text="Hiển thị thêm"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr id="readmore" style="display: none">
                                                <td class="info_table_td">HH (%):
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" onkeyup="return onkeyup_giamgia()" Width="57px" CssClass="nano_textbox" ID="txtHH"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Nhóm phiếu:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlNhomphieu" ClientInstanceName="ddlNhomphieu" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="188px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" align="right" class="info_table_td">
                                                    <dx:ASPxButton ID="btnThanhtoan" Image-Url="~/images/16x16/coins_in_hand.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnThanhtoan" runat="server" Text="Thanh toán (F2)">
                                                        <ClientSideEvents Click="UpdatePhieuDV" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btnIn" AutoPostBack="false" Image-Url="~/images/16x16/printer.png" Style="float: left; margin-left: 10px" ClientInstanceName="btnIn" runat="server" Text="In (F4)">
                                                        <ClientSideEvents Click="Inphieu" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btnDSPhieu" Image-Url="~/images/16x16/page.png" AutoPostBack="false" ClientInstanceName="btnDSPhieu" Style="float: left; margin-left: 10px" runat="server" Text="Danh sách phiếu">
                                                        <ClientSideEvents Click="function(s, e) { ShowDSPhieuWindow(); }" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btnDSNo" Image-Url="~/images/16x16/money_dollar.png" ClientInstanceName="btnDSNo" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Xem nợ">
                                                        <ClientSideEvents Click="OpenPopupDSNo" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton Visible="false" ID="btnPhieumoi" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnPhieumoi" runat="server" Text="Phiếu mới (F9)">
                                                        <ClientSideEvents Click="ClearPhieuDichVu" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btnCapthe" Image-Url="~/images/16x16/card_front.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnCapthe" Visible="false" runat="server" Text="Cấp thẻ">
                                                        <ClientSideEvents Click="Capthe" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table id="pendroom" style="position: relative; top: 8px">
                                        <tbody>
                                            <tr>
                                                <td class="info_table_td">Chuyển đến:
                                                </td>
                                                <td class="info_table_td" style="width: 100px">
                                                    <dx:ASPxComboBox ID="ddlDMPhong" ClientInstanceName="ddlDMPhong" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                        <ClientSideEvents SelectedIndexChanged="phongchange" />
                                                    </dx:ASPxComboBox>
                                                </td>
                                                <td class="info_table_td">Trạng thái:
                                                </td>
                                                <td>
                                                    <dx:ASPxComboBox ID="ddlTrangthai" ClientInstanceName="ddlTrangthai" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                        <ClientSideEvents SelectedIndexChanged="ddlTrangthaiChange" />
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ngày chuyển: </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="dat_Ngaychuyen" ClientInstanceName="dat_ngaychuyen" runat="server" Width="200px"></dx:ASPxDateEdit>
                                                </td>
                                                <td class="info_table_td">Ghi chú chuyển:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtNote" runat="server" Width="200px" TextMode="MultiLine" Height="17px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="Tr1">
                                                <td></td>
                                                <td class="info_table_td" colspan="2">
                                                    <dx:ASPxButton ID="btnChuyen" OnClick="btnChuyen_Click" Image-Url="~/images/door_in.png" Style="float: left; margin-right: 8px" runat="server" Text="Chuyển">
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div style="clear: both"></div>
                                </div>
                            </fieldset>


                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Đơn thuốc">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <%--                        <asp:LinkButton ID="lbtnPhieuxuat" Visible="true" OnClientClick="return ShowPhieuXuat()"
                            runat="server" Style="font-weight: bold; color: Red; position: relative; top: 5px" Text="Có 0 phiếu xuất chờ thanh toán"></asp:LinkButton>--%>

                        <%--<div id="gv_chothanhtoan">--%>
                        <dx:ASPxGridView ID="dgvPhieuxuatcho" runat="server" ClientInstanceName="client_dgvPhieuxuatcho" AutoGenerateColumns="false" SettingsPager-PageSize="4"
                            KeyFieldName="uId_Phieuxuat"
                            SettingsPager-Position="Bottom">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieuxuat"
                                    Name="uId_Phieuxuat">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Width="140px" Caption="Số phiếu xuất" FieldName="v_Maphieuxuat"
                                    Name="v_Maphieuxuat">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Ngày xuất" FieldName="d_Ngayxuat"
                                    Name="d_Ngayxuat">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Bệnh nhân" FieldName="nv_Hoten_vn"
                                    Name="nv_Hoten_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Nội dung xuất" FieldName="nv_Noidungxuat_vn"
                                    Name="nv_Noidungxuat_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Số thang" FieldName="i_Soluong"
                                    Name="f_Giamgia">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" FieldName="Trangthai"
                                    Name="f_Giamgia">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Giảm giá" FieldName="f_Giamgia"
                                    Name="f_Giamgia">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                    HeaderStyle-HorizontalAlign="Center" Caption="Thanh toán" FieldName="f_Tongtienthuc"
                                    Name="f_Tongtienthuc">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieuxuat('{0}', '{1}')",Eval("uId_Phieuxuat"), Eval("uId_Khachhang")).ToString %>">
                                            <img src="../../../images/bub.png" /></a>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewCommandColumn VisibleIndex="4" Width="30px" Caption="" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                        <Image Url="~/images/btn_Delete.png"></Image>
                                    </DeleteButton>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsEditing Mode="Inline" />
                            <SettingsPager PageSize="14">
                            </SettingsPager>
                            <Settings ShowFilterRow="true" ShowGroupPanel="false"
                                ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                            <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                            <ClientSideEvents EndCallback="grid_EndCallback" />
                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                </AlternatingRow>
                                <GroupRow Font-Bold="true"></GroupRow>
                            </Styles>
                        </dx:ASPxGridView>
                        <%--        </div>--%>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <%--            <dx:TabPage Text="Nhập hàng">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>--%>
        </TabPages>
    </dx:ASPxPageControl>

    <div style="clear: both"></div>
    <dx:ASPxPopupControl ID="pcDanhsachphieu" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDanhsachphieu"
        HeaderText="Danh sách phiếu" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDanhsachphieu.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="900px" Height="370px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <asp:Literal ID="ltrErrorPuPhieu" runat="server"></asp:Literal>
                            <dx:ASPxButton ID="btnRefreshDSPhieu" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Tải lại" Style="float: left; margin-right: 8px">
                                <ClientSideEvents Click="Refresh_pcDanhsachphieu" />

                                <Image Url="~/images/16x16/refresh.png"></Image>
                            </dx:ASPxButton>
                            <div style="clear: both"></div>
                            <dx:ASPxGridView ID="dgvDanhsachphieu" OnRowDeleting="dgvDanhsachphieu_RowDeleting" OnDataBinding="dgvDanhsachphieu_DataBinding" runat="server" ClientInstanceName="client_dgvDanhsachphieu"
                                AutoGenerateColumns="false" KeyFieldName="uId_Phieudichvu" SettingsPager-PageSize="8"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieudichvu"
                                        Name="uId_Phieudichvu">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Số phiếu" FieldName="v_Sophieu"
                                        Name="v_Sophieu">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="90px" Caption="Ngày lập" FieldName="d_Ngay"
                                        Name="d_Ngay">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Giảm giá" Width="70px" FieldName="f_Giamgia"
                                        Name="f_Giamgia">
                                        <PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>

                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Tổng thanh toán" Width="70px" FieldName="f_Tongtienthuc"
                                        Name="f_Tongtienthuc">
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
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" Width="370px" FieldName="nv_Ghichu_vn"
                                        Name="nv_Ghichu_vn">
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
                                <SettingsPager PageSize="10">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_dsphieu(s, e); }" />
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
    <dx:ASPxPopupControl ID="pcDanhsachno" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDanhsachno"
        HeaderText="Danh sách nợ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDanhsachno.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="600px" Height="470px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <dx:ASPxGridView ID="dgvDSPhieuno" OnDataBinding="dgvDSPhieuno_DataBinding" runat="server" ClientInstanceName="client_dgvDanhsachphieuno"
                                AutoGenerateColumns="false" KeyFieldName="uId_Phieudichvu" SettingsPager-PageSize="8"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieudichvu"
                                        Name="uId_Phieudichvu">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="230px" Caption="Số phiếu" FieldName="v_Sophieu"
                                        Name="v_Sophieu">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="100px" Caption="Ngày lập" FieldName="d_Ngay"
                                        Name="d_Ngay">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Tổng thanh toán" Width="120px" FieldName="f_Tongtienthuc"
                                        Name="f_Tongtienthuc">
                                        <PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>

                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Số tiền nợ" Width="120px" FieldName="f_Sotienno"
                                        Name="f_Sotienno">
                                        <PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>

                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Thanh toán công nợ" href='javascript:void(0)' onclick="return <%# String.Format("ThanhtoancongnoDV('{0}', '{1}')", Eval("uId_Phieudichvu"), Eval("v_Sophieu")).ToString%>">
                                                <img src="../../../images/16x16/coins_in_hand.png" /></a>
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
                                <ClientSideEvents />
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
    <dx:ASPxPopupControl ID="pcDsTheTT" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDsTheTT"
        HeaderText="Danh sách thẻ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDsTheTT.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="900px" Height="370px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div style="clear: both"></div>
                            <div>
                                <dx:ASPxButton ID="btn_Restart" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Tải lại">
                                    <ClientSideEvents Click="Refresh_DSTheTT" />
                                </dx:ASPxButton>
                            </div>
                            <dx:ASPxGridView ID="dgvDsTheTT" runat="server" OnDataBinding="dgvDsTheTT_DataBinding" ClientInstanceName="client_dgvDsTheTT"
                                AutoGenerateColumns="false" KeyFieldName="uId_Khachhang_Goidichvu" SettingsPager-PageSize="8"
                                SettingsPager-Position="Bottom">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang_Goidichvu"
                                        Name="uId_Khachhang_Goidichvu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Mã thẻ" FieldName="vMaBarcode"
                                        Name="vMaBarcode">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="90px" Caption="Tên thẻ" FieldName="nv_Tengoi_vn"
                                        Name="nv_Tengoi_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày mua" Width="100px" FieldName="d_Ngaymua"
                                        Name="d_Ngaymua">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Số tiền" Width="100px" FieldName="f_Sotien"
                                        Name="f_Sotien">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Giá trị thẻ" Width="100px" FieldName="f_Giatrigoi"
                                        Name="f_Giatrigoi">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày BĐ" Width="100px" FieldName="d_NgayBD"
                                        Name="d_NgayBD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày KT" Width="100px" FieldName="d_NgayKT"
                                        Name="d_NgayKT">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" Width="130px" FieldName="nv_Tentrangthai_vn"
                                        Name="nv_Tentrangthai_vn">
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
                                <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_dsthe(s, e); }" />
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
    <dx:ASPxPopupControl ID="pcCapthe" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcCapthe"
        HeaderText="Cấp thẻ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcCapthe.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" Width="700px" Height="300px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <asp:HiddenField ID="hdfDongiathe" runat="server" />
                            <asp:UpdatePanel ID="upThe" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Cấp thẻ thanh toán</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Khách hàng:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:Label ID="lblKhachhangThe" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="info_table_td">Tên thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtTenthe"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Mã số / Mã vạch:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" placeholder="Mã tự động" CssClass="nano_textbox" ID="txtMavach"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Giá trị thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtGiatri"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Ngày cấp:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="deNgaycap" UseMaskBehavior="true" ClientInstanceName="deNgaycap" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                </td>
                                                <td class="info_table_td">Ngày hết hạn:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="deNgayhethan" UseMaskBehavior="true" ClientInstanceName="deNgayhethan" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltrSuccess" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btLuuthe" Image-Url="~/images/btn_Save.png" ClientInstanceName="btLuuthe" OnClick="btLuuthe_Click" runat="server" Text="Kích hoạt (F4)" Style="float: left; margin-right: 8px">
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopup_The" />
                                                        </dx:ASPxButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="upThe" DisplayAfter="0" DynamicLayout="false">
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
    <dx:ASPxPopupControl ID="pcHinhThucTT" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcHinhThucTT"
        HeaderText="Danh sách phiếu" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcHinhThucTT.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                <dx:ASPxPanel ID="ASPxPanel4" runat="server" Width="500px" Height="470px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent5" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtSotiennhanTT"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Hình thức TT:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <dx:ASPxComboBox ID="ddlHinhthucTT_Pop" ClientInstanceName="ddlHinhthucTT_Pop" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
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
                                                        <dx:ASPxButton ID="btnLuuHinhthuc" Image-Url="~/images/btn_Save.png" ClientInstanceName="btnLuuHinhthuc" OnClick="btnLuuHinhthuc_Click" runat="server" Text="Lưu" Style="float: left; margin-right: 8px">
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
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" DynamicLayout="false">
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
    <asp:HiddenField ID="hdfIDdichvuhuy" runat="server" Value="" />
    <dx:ASPxPopupControl ID="pcHuydichvu" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcHuydichvu"
        HeaderText="Hủy dịch vụ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcHuydichvu.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server">
                <dx:ASPxPanel ID="ASPxPanel5" runat="server" Width="300px" Height="100px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent6" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div style="clear: both"></div>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green"></span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Lý do:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtLydohuydv" ClientInstanceName="txtlydohuydv" runat="server"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btnHuydichvu" Image-Url="~/images/btn_Save.png" ClientInstanceName="btnHuydichvu" OnClick="btnHuydichvu_Click"
                                                            runat="server" Text="Lưu" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="CheckHuydichvu" />
                                                        </dx:ASPxButton>
                                                    </div>
                                                </td>
                                                <td></td>
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
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
