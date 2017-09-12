<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Services.aspx.vb" Inherits="NANO_SPA.Services" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

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
<%@ Register Src="~/OrangeVersion/Report/Rp_web/ReportViewerControl.ascx" TagPrefix="uc1" TagName="ReportViewerControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script src="../../bootstrap/js/MaskedEditFix.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'b876314e-5ccb-4e0a-969b-7ac137939a5d'}";
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
            document.onkeyup = KeyCheck;
            function KeyCheck(e) {
                var KeyID = (window.event) ? event.keyCode : e.keyCode;
                if (KeyID == 113) {
                    document.getElementById('<%=btnThemmoi.ClientID%>').click();
                }
                if (KeyID == 115) {
                    document.getElementById('<%=btOK.ClientID%>').click();

                }
                if (KeyID == 120) {
                    document.getElementById('<%=btnClear.ClientID%>').click();

                }
                if (KeyID == 27) {
                    document.getElementById('<%=btCancel.ClientID%>').click();
                }
            }
        });

        var _fieldName = '';
        function grid_FocusedRowChanged(s, e) {
            if (s.cpIsEditing) {
                s.UpdateEdit();
            }
        }
        // tu dong covert khi nhap so vao textbox. vao id textbox ra chuoi dang 000.000
        function jo_ThousanSereprate(id) {
            //var textbox = id;
            id.value = jo_FormatMoney(id.value.replace(/,/g, ""));
            return false;
        }
        // tu dong covert tien khi load du lieu len textbox. vao chuoi so ra chuoi dang 000.000
        function jo_ThousanSereprates(str) {
            var strconvert
            strconvert = jo_FormatMoney(str.replace(/,/g, ""));
            return strconvert;
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
        // mo popup khi select 1 row tren gridview dung de sua
        function ShowEditWindow() {
            pcAddDichvu.Show();
            var txttendv = document.getElementById("<%=txt_Tendichvu.ClientID%>");
            txttendv.focus();
        }
        function ShowEditWindowCongdoan() {
            pcAddcongdoan.Show();
        }
        // clear pupop cong doan dich vu
        function clear_Congdoan() {
            cbocongdoan.SetText("");
            cbokho.SetText("");
            var hdfDVCongdoan = document.getElementById("<%=hdfuIdDVCongdoan.ClientID%>")
            hdfDVCongdoan.value = "";
            cbomathang.SetText("");
            txtsoluong.SetText("");
            txtsophut.SetText("");
        }
        function clear_CongdoanEvt(s, e) {
            clear_Congdoan()
        }
        // mo popup khi click buttom them moi dung de them
        function ShowAddWindow() {
            pcAddDichvu.Show();
            ClearText();
            var txttendv = document.getElementById("<%=txt_Tendichvu.ClientID%>");
            txttendv.focus();
        }
        function ClosePopup(s, e) {
            pcAddDichvu.Hide();
            PcImportExcel.Hide();
            client_grid.Refresh();
        }
        function ClosePopupCD(s, e) {
            pcAddcongdoan.Hide();
            client_grid.Refresh();
        }
        //Su kien khi chon 1 dong
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                client_grid.GetRowValues(e.visibleIndex, 'uId_Dichvu;', OnGridSelectionComplete);
            }
        }
        function OnGridSelectionComplete(values) {
            //Gan gia tri cho hidden field uId khachhang de sua thong tin khach hoac lam gi do
            var hdfuIddv = document.getElementById("<%=hdfuIdDichvu.ClientID%>");
            var hdfuIdcd = document.getElementById("<%=hdfuIdCongdoan.ClientID%>");
            jo_CreateSession("uId_Dichvu_Goidichvu", values[0]);
            hdfuIddv.value = hdfuIdcd.value = values[0];
            var param_dt = "{'uId_Dichvu':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/loadDichvu";
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
            //Create  1 session uId_Dichvu_cd
            jo_CreateSession("uId_Dichvu_cd", values[0]);
            clientgrid_congdoan.Refresh();
        }
        function OnSuccessCall(msg) {
            if (msg.d != "") {
                var defaultdata = msg.d.split("$");
                var txtTendv = document.getElementById("<%=txt_Tendichvu.ClientID%>");
                var txtGiamgia = document.getElementById("<%=txt_Giamgia.ClientID%>");
                var txtGiadv = document.getElementById("<%=txt_GiaDV.ClientID%>");
                var txtSolan = document.getElementById('<%=txt_Solandieutri.ClientID%>');
                var txtChuanbi = document.getElementById('<%=txt_Tgchuanbi.ClientID%>');
                var txtThuchien = document.getElementById('<%=txt_Tgthuchien.ClientID%>');
                var txtSolan = document.getElementById('<%=txt_Solandieutri.ClientID%>');
                var cbohoahoang = document.getElementById('<%=cbo_Hoahong.ClientID%>');
                var cboTinhthue = document.getElementById('<%=cbo_Tinhthue.ClientID%>');
                var cboGoidichvu = document.getElementById('<%=cbo_Goidv.ClientID%>');
                var txtTencddv = document.getElementById("<%=txt_Congdoan_Tendichvu.ClientID%>");
                var txtngay = document.getElementById("<%=txtngay.ClientID%>");
                txtTendv.value = txtTencddv.value = defaultdata[0];
                pcmb_NhomDV.SetValue(defaultdata[1]);
                txtGiadv.value = jo_ThousanSereprates(defaultdata[2]);
                txtGiamgia.value = defaultdata[3];
                pcmb_Ngoaite.SetValue(defaultdata[4]);
                txtChuanbi.value = defaultdata[5];
                txtThuchien.value = defaultdata[6];
                txtSolan.value = defaultdata[7];
                txtngay.value = defaultdata[16];
                if (defaultdata[9] == "True") {
                    cbohoahoang.checked = true;
                } else
                    cbohoahoang.checked = false;

                if (defaultdata[10] == "True") {
                    cboTinhthue.checked = true;
                }
                else
                    cboTinhthue.checked = false;

                if (defaultdata[8] == "True") {
                    cboGoidichvu.checked = true;
                }
                else
                    cboGoidichvu.checked = false;
                var txtHHTvv = document.getElementById('<%=txt_HHTuvan.ClientID%>');
                var txtHHCtv = document.getElementById('<%=txt_HHCongtac.ClientID%>');
                var txtHHNvc = document.getElementById('<%=txt_HHNhanvienchinh.ClientID%>');
                var txtHHNvp = document.getElementById('<%=txt_HHNhanvienphu.ClientID%>');
                //txtHHTvv.value = jo_ThousanSereprates(defaultdata[11]);
                //txtHHCtv.value = jo_ThousanSereprates(defaultdata[12]);
                txtHHNvc.value = jo_ThousanSereprates(defaultdata[13]);
                txtHHNvp.value = jo_ThousanSereprates(defaultdata[14]);
            }

        }
        // clear text dung lam moi de the du lieu
        function ClearText() {
            var hdfuIddv = document.getElementById("<%=hdfuIdDichvu.ClientID%>");
            var txtTendv = document.getElementById("<%=txt_Tendichvu.ClientID%>");
            var txtGiamgia = document.getElementById("<%=txt_Giamgia.ClientID%>");
            var txtGiadv = document.getElementById("<%=txt_GiaDV.ClientID%>");
            var txtSolan = document.getElementById('<%=txt_Solandieutri.ClientID%>');
            var txtChuanbi = document.getElementById('<%=txt_Tgchuanbi.ClientID%>');
            var txtThuchien = document.getElementById('<%=txt_Tgthuchien.ClientID%>');
            var txtHHTvv = document.getElementById('<%=txt_HHTuvan.ClientID%>');
            var txtHHCtv = document.getElementById('<%=txt_HHCongtac.ClientID%>');
            var txtHHNvc = document.getElementById('<%=txt_HHNhanvienchinh.ClientID%>');
            var txtHHNvp = document.getElementById('<%=txt_HHNhanvienphu.ClientID%>');
            var cbohoahoang = document.getElementById('<%=cbo_Hoahong.ClientID%>');
            var cboTinhthue = document.getElementById('<%=cbo_Tinhthue.ClientID%>');
            var cboGoidichvu = document.getElementById('<%=cbo_Goidv.ClientID%>');
            var lbl_Thongbao = document.getElementById('<%=lbl_Thongbao.ClientID%>');
            var txtngay =document.getElementById('<%=txtngay.ClientID%>');
            txtngay.value = 0;
            lbl_Thongbao.innerHTML = "";
            var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>');
            lbl_Error.value = "";
            txtGiamgia.value = 0;
            txtTendv.value = "";
            txtGiadv.value = 0;
            txtSolan.value = 0;
            txtChuanbi.value = 0;
            txtThuchien.value = 0;
          
            txtHHNvc.value = 0;
            txtHHNvp.value = 0;
            hdfuIddv.value = "";
            pcmb_NhomDV.SetText("---");
            pcmb_Ngoaite.SetText("---");
            txtTendv.focus();
        }
        function ClearText_Dev(s, e) {
            ClearText();
        }
        function onFail(ex) {
            alert(ex._message + " fail");
            return false;
        }
        //kiem tra du lieu
        function CheckEmpty(s, e) {
            var hdfuIddv = document.getElementById("<%=hdfuIdDichvu.ClientID%>");
            var txtTendv = document.getElementById("<%=txt_Tendichvu.ClientID%>");
            var txtGiamgia = document.getElementById("<%=txt_Giamgia.ClientID%>");
            var txtGiadv = document.getElementById("<%=txt_GiaDV.ClientID%>");
            var txtSolan = document.getElementById('<%=txt_Solandieutri.ClientID%>');
            var txtChuanbi = document.getElementById('<%=txt_Tgchuanbi.ClientID%>');
            var txtThuchien = document.getElementById('<%=txt_Tgthuchien.ClientID%>');
            var txtHHTvv = document.getElementById('<%=txt_HHTuvan.ClientID%>');
            var txtHHCtv = document.getElementById('<%=txt_HHCongtac.ClientID%>');
            var txtHHNvc = document.getElementById('<%=txt_HHNhanvienchinh.ClientID%>');
            var txtHHNvp = document.getElementById('<%=txt_HHNhanvienphu.ClientID%>');
            var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>');
            var cbo_Goidv = document.getElementById('<%=cbo_Goidv.ClientID%>');
            var cmb_Nhomdichvu = document.getElementById('<%=cmb_Nhomdichvu.ClientID%>');
            lbl_Error.innerHTML = "";
            if (txtTendv.value == "") {
                txtTendv.focus();
                lbl_Error.innerHTML = "Tên dịch vụ không được để trống";
                e.processOnServer = false;
            }
            else if (txtGiadv.value == "" || isNaN(parseInt(txtGiadv.value))) {
                txtGiadv.value = "";
                txtGiadv.focus();
                lbl_Error.innerHTML = "Dữ liệu không đủ hoặc sai kiểu";
                e.processOnServer = false;
            }
            else if (txtGiamgia.value != "") {
                if (isNaN(parseFloat(txtGiamgia.value))) {
                    txtGiamgia.value = "";
                    txtGiamgia.focus();
                    lbl_Error.innerHTML = "Chỉ được phép nhập số";
                    e.processOnServer = false;
                }
            }
            else if (txtSolan.value == "" || isNaN(parseInt(txtSolan.value))) {
                txtSolan.value = "";
                txtSolan.focus();
                lbl_Error.innerHTML = "Chỉ được phép nhập số";
                e.processOnServer = false;
            }
            else if (txtThuchien.value != "") {
                if (isNaN(parseInt(txtThuchien.value))) {
                    txtThuchien.value = "";
                    txtThuchien.focus();
                    lbl_Error.innerHTML = "Chỉ được phép nhập số";
                    e.processOnServer = false;
                }
            }
            else if (txtChuanbi.value != "") {
                if (isNaN(parseInt(txtSolan.value))) {
                    txtChuanbi.value = "";
                    txtChuanbi.focus();
                    lbl_Error.innerHTML = "Chỉ được phép nhập số";
                    e.processOnServer = false;
                }
            }
            else if (txtHHCtv.value != "") {
                if (isNaN(parseFloat(txtHHCtv.value))) {
                    txtHHCtv.value = "";
                    txtHHCtv.focus();
                    lbl_Error.innerHTML = "Chỉ được nhập số";
                    e.processOnServer = false;
                }
            }
            else if (txtHHNvc.value != "") {
                if (isNaN(parseFloat(txtHHNvc.value))) {
                    txtHHNvc.value = "";
                    txtHHNvc.focus();
                    lbl_Error.innerHTML = "Chỉ được nhập số";
                    e.processOnServer = false;
                }
            }
            else if (txtHHNvp.value != "") {
                if (isNaN(parseFloat(txtHHNvp.value))) {
                    txtHHNvp.value = "";
                    txtHHNvp.focus();
                    lbl_Error.innerHTML = "Chỉ được nhập số";
                    e.processOnServer = false;
                }
            }
            else if (txtHHTvv.value != "") {
                if (isNaN(parseFloat(txtHHTvv.value))) {
                    txtHHTvv.value = "";
                    txtHHTvv.focus();
                    lbl_Error.innerHTML = "Chỉ được nhập số";
                    e.processOnServer = false;
                }
            }
            else if (pcmb_NhomDV.GetSelectedItem().value == "0") {
                pcmb_NhomDV.Focus();
                pcmb_NhomDV.ShowDropDown();
                lbl_Error.innerHTML = "Hãy chọn nhóm mặt hàng";
                e.processOnServer = false;
            }
            else if (pcmb_Ngoaite.GetSelectedItem().value == "0") {
                pcmb_Ngoaite.Focus();
                pcmb_Ngoaite.ShowDropDown();
                lbl_Error.innerHTML = "Hãy ngoại tệ mặt hàng";
                e.processOnServer = false;
            }
        }

        // enter event
        function enter_txtTendv(e) {
            if (e.keyCode == 13) {
                var tendv = document.getElementById('<%=txt_Tendichvu.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                lbl_Error.innerHTML = "";
                if (tendv.value != "") {
                    pcmb_NhomDV.Focus();
                    pcmb_NhomDV.ShowDropDown();
                }
                else {
                    tendv.focus();
                    lbl_Error.innerHTML = "Bắt buộc nhập dữ liệu tại ô này";
                }
                return false;
            }
        }
        function enter_txt_GiaDV(e) {
            if (e.keyCode == 13) {
                var txt_GiaDV = document.getElementById('<%=txt_GiaDV.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_GiaDV.value != "") {
                    if (isNaN(parseInt(txt_GiaDV.value))) {
                        txt_GiaDV.value = "";
                        txt_GiaDV.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                    else {
                        pcmb_Ngoaite.Focus();
                        pcmb_Ngoaite.ShowDropDown();
                    }
                }
                else {
                    txt_GiaDV.focus();
                    lbl_Error.innerHTML = "Đây là dòng bắt buộc nhập dữ liệu";
                }
                return false;
            }
        }
        function enter_Ngoaite(e) {
            if (e.keyCode == 13) {
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                var txt_Giamgia = document.getElementById('<%=txt_Giamgia.ClientID%>')
                lbl_Error.value = "";
                txt_Giamgia.focus();
            }
            return false;
        }
        function enter_txtGiamgia(e) {
            if (e.keyCode == 13) {
                var txt_Giamgia = document.getElementById('<%=txt_Giamgia.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                var txt_Tgchuanbi = document.getElementById('<%=txt_Tgchuanbi.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_Giamgia.value != "") {
                    if (isNaN(parseInt(txt_Giamgia.value))) {
                        txt_Giamgia.value = "";
                        txt_Giamgia.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                    else if (txt_Giamgia.value >= 100) {
                        txt_Giamgia.focus()
                        lbl_Error.innerHTML = "Mức giảm giá " + txt_Giamgia.value + " % không phù hợp";
                    }
                    else
                        txt_Tgchuanbi.focus();
                }
                else
                    txt_Tgchuanbi.focus();
                return false;
            }
        }
        function enter_txtTGchuabi(e) {
            if (e.keyCode == 13) {
                var txt_Tgthuchien = document.getElementById('<%=txt_Tgthuchien.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                var txt_Tgchuanbi = document.getElementById('<%=txt_Tgchuanbi.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_Tgchuanbi.value != "") {
                    if (isNaN(parseInt(txt_Tgchuanbi.value))) {
                        txt_Tgchuanbi.value = "";
                        txt_Tgchuanbi.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                    else {
                        txt_Tgthuchien.focus();
                        return false;
                    }
                }
                else
                    txt_Tgthuchien.focus();
                return false;
            }

        }
        function enter_txtTgchuchien(e) {
            if (e.keyCode == 13) {
                var txt_Solandieutri = document.getElementById('<%=txt_Solandieutri.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                var txt_Tgthuchien = document.getElementById('<%=txt_Tgthuchien.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_Tgthuchien.value != "") {
                    if (isNaN(parseInt(txt_Tgthuchien.value))) {
                        txt_Tgthuchien.value = "";
                        txt_Tgthuchien.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                    else {
                        txt_Solandieutri.focus();
                    }
                }
                txt_Solandieutri.focus();
                return false;
            }
        }
        function enter_txtSolandieutri(e) {
            if (e.keyCode == 13) {
                var txt_HHTuvan = document.getElementById('<%=txt_HHTuvan.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                var txt_Solandieutri = document.getElementById('<%=txt_Solandieutri.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_Solandieutri.value != "") {
                    if (isNaN(parseInt(txt_Solandieutri.value))) {
                        txt_Solandieutri.value = "";
                        txt_Solandieutri.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                    else {
                        txt_HHTuvan.focus()
                        return false;
                    }
                }
                else {
                    txt_Solandieutri.value = "";
                    txt_Solandieutri.focus()
                    lbl_Error.innerHTML = "Dòng này bắt buộc nhập dữ liệu";
                }
                return false;
            }
        }
        function enter_pcmb_NhomDV(e) {
            if (e.keyCode == 13) {
                var txt_GiaDV = document.getElementById('<%=txt_GiaDV.ClientID()%>')
                txt_GiaDV.focus();
            }
            return false;
        }
        function enter_txtHHtuvan(e) {
            if (e.keyCode == 13) {
                var txt_HHTuvan = document.getElementById('<%=txt_HHTuvan.ClientID()%>')
                var txt_HHCongtac = document.getElementById('<%=txt_HHCongtac.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_HHTuvan.value != "") {
                    if (isNaN(parseFloat(txt_HHTuvan.value))) {
                        txt_HHTuvan.focus();
                        txt_HHTuvan.value = "";
                        lbl_Error.innerHTML = "Chỉ được nhập chữ số";
                        return false;
                    }
                    else
                        txt_HHCongtac.focus();
                }
                else
                    txt_HHCongtac.focus();
                return false;
            }
        }

        function enter_txtHHCongtac(e) {

            if (e.keyCode == 13) {
                var txt_HHCongtac = document.getElementById('<%=txt_HHCongtac.ClientID%>')
                var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>');
                var txt_HHNhanvienchinh = document.getElementById('<%=txt_HHNhanvienchinh.ClientID%>')
                lbl_Error.innerHTML = "";
                if (txt_HHCongtac.value != "") {
                    if (isNaN(parseInt(txt_HHCongtac.value))) {
                        txt_HHCongtac.value = "";
                        txt_HHCongtac.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                }
                txt_HHNhanvienchinh.focus();
                return false;
            }
        }
        function enter_txtHHnvc(e) {
            var txt_HHNhanvienphu = document.getElementById('<%=txt_HHNhanvienphu.ClientID%>')
            var txt_HHNhanvienchinh = document.getElementById('<%=txt_HHNhanvienchinh.ClientID%>')
            var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>');
            if (e.keyCode == 13) {
                lbl_Error.innerHTML = "";
                if (txt_HHNhanvienchinh.value != "") {
                    if (isNaN(parseInt(txt_HHNhanvienchinh.value))) {
                        txt_HHNhanvienchinh.value = "";
                        txt_HHNhanvienchinh.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                }
                txt_HHNhanvienphu.focus();
                return false;
            }
        }
        function enter_txtHHnvp(e) {
            var txt_HHNhanvienphu = document.getElementById('<%=txt_HHNhanvienphu.ClientID%>')
            var lbl_Error = document.getElementById('<%=lbl_Error.ClientID%>');
            var txt_Tgthuchien = document.getElementById('<%=txt_Tgthuchien.ClientID%>')
            var btOk = document.getElementById("<%=btOK.ClientID%>");
            if (e.keyCode == 13) {
                lbl_Error.innerHTML = "";
                if (txt_HHNhanvienphu.value != "") {
                    if (isNaN(parseInt(txt_HHNhanvienphu.value))) {
                        txt_HHNhanvienphu.value = "";
                        txt_HHNhanvienphu.focus()
                        lbl_Error.innerHTML = "Chỉ được phép nhập số";
                        return false;
                    }
                }

                btOk.click();
                return false;
            }

        }
        // su kien enter tren pupop cong doan
        function enter_txt_Tencongdoan(e) {
            if (e.keyCode == 13) {
                if (txt_Tencongdoan.value != "") {
                    txt_Congdoan_Hoahong.focus()
                }
                else
                    txt_Tencongdoan.focus()
                return false;
            }
        }
        function enter_txt_Congdoan_Hoahong(e) {
            if (e.keyCode == 13) {
                var lbl_ErrorCD = document.getElementById("<%=lbl_ErrorCD.ClientID%>")
                lbl_ErrorCD.innerHTML = "";
                if (txt_Congdoan_Hoahong.value != "") {
                    if (isNaN(parseInt(txt_Congdoan_Hoahong.value))) {
                        txt_Congdoan_Hoahong.value = "";
                        txt_Congdoan_Hoahong.focus();
                        lbl_ErrorCD.innerHTML = "Chỉ được phép nhập số";

                    }
                    else
                        txt_Ghichu.focus();
                }
                else {
                    txt_Congdoan_Hoahong.value = 0;
                    txt_Ghichu.focus();
                }
                return false;
            }
        }
        function enter_txt_Ghichu(e) {
            var KeyID = (window.event) ? event.keyCode : e.keyCode;
            if (KeyID == 13) {
                var btn_luu = document.getElementById("<%=btn_luu.ClientID%>")
                btn_luu.click();
                return true;
            }
        }
        //function CheckCD(s, e) {
        //    if (txt_Tencongdoan.value == "") {
        //        txt_Tencongdoan.focus();
        //        lbl_ErrorCD.innerHTML = "Hãy nhập tên công đoạn !";
        //        e.processOnServer = false;
        //    }
        //    else if (txt_Congdoan_Hoahong.value != "") {
        //        if (isNaN(parseInt(txt_Congdoan_Hoahong.value))) {
        //            txt_Congdoan_Hoahong.value = "";
        //            txt_Congdoan_Hoahong.focus();
        //            lbl_ErrorCD.innerHTML = "Chỉ được nhập số";
        //            e.processOnServer = false;
        //        }
        //    }
        //    else {
        //        txt_Congdoan_Hoahong.value = 0;
        //    }
        //}
        function chkkho_checkchange(s, e) {
            if (chkkho.GetChecked() == true) {
                cbokho.SetEnabled(true);
                cbomathang.SetEnabled(true);
                txtsoluong.SetEnabled(true);
            }
            else {
                cbokho.SetEnabled(false);
                cbomathang.SetEnabled(false);
                txtsoluong.SetEnabled(false);
            }
        }
        function ShowAddWindowimport() {
            PcImportExcel.Show();
            document.getElementById("<%=lbl_Import.ClientID%>").innerHTML = ""
            }
            function ShowAddWindowUathich() {
                PCDVUathich.Show();
                document.getElementById("<%=lbl_Import.ClientID%>").innerHTML = ""
        }
        function Callbackrp(s, e) {
            ReportViewerCallback.PerformCallback(0);
        }

        function importClientclick(s, e) {
            if (raddichvu.GetChecked() == false & radcongdoan.GetChecked() == false & raddmcongdoan.GetChecked() == false) {
                var lblImport = document.getElementById("<%=lbl_Import.ClientID%>")
                lblImport.innerHTML = "Hãy lựa chọn 1 mục để import"
                e.processOnServer = false
            }
        }
        function Locclick(s, e) {
            client_grid.Refresh();
        }

        function Congdoanselect(s, e) {
            if (!e.isSelected) {
            } else {
                clientgrid_congdoan.GetRowValues(e.visibleIndex, 'uId_Dichvu;uId_Congdoan;uId_Dichvu_Congdoan;uId_Kho;uId_Mathang;f_Sophut;f_Soluong', OnGridSelectionCompleteCongdoan);
            }
        }

        function OnGridSelectionCompleteCongdoan(values) {
            var hdfDVCongdoan = document.getElementById("<%=hdfuIdDVCongdoan.ClientID%>")
            hdfDVCongdoan.value = values[2];
            if (values[4] != null) {
                chkkho.SetChecked(true);
                cbokho.SetEnabled(true);
                cbomathang.SetEnabled(true);
                txtsoluong.SetEnabled(true);
                cbokho.SetText("");
                cbomathang.SetText("");
                txtsoluong.SetText("");
                cbocongdoan.SetValue(values[1]);
                cbokho.SetValue(values[3]);
                cbomathang.SetValue(values[4]);
                txtsophut.SetText(values[5]);
                txtsoluong.SetText(values[6]);
            }
            else {
                chkkho.SetChecked(false);
                cbokho.SetEnabled(false);
                cbomathang.SetEnabled(false);
                txtsoluong.SetEnabled(false);
            }
        }

        function ShowEditWindowGoidichvu(s, e) {
            grvdichvugoi.Refresh();
            pcthietlapgoidv.Show();           
        }
        function ClosePopupgdv(s, e) {
            pcthietlapgoidv.Hide();
        }
        var Luachon="Insert"
        function btnluugdvClick(s, e) {
            var hdfuIddv = document.getElementById("<%=hdfuIdDichvu.ClientID%>");
            var sPara = Luachon + "$" + hdfuIddv.value + "$" + cbodichvugoi.GetValue() + "$" + txtsoluongdvg.GetText() + "$" + txtdongiadvg.GetText()
            var param_dt = "{'sPara':'" + sPara + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertGoidichvu";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCallDvgoi,
                error: onFail
            });
        }
        function OnSuccessCallDvgoi(msg) {
            if (msg.d != "") {
                Luachon = "Update";
                grvdichvugoi.Refresh();
            }
        }
        function cbodvgoiChange(s, e) {
            Luachon = "Insert";
          

        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ DANH MỤC DỊCH VỤ</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">Nhóm dịch vụ: </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cmb_Nhomdichvu" DropDownStyle="DropDownList" runat="server" TextField="nv_TennhomDichvu_vn"
                    ValueField="uId_Nhomdichvu" IncrementalFilteringMode="StartsWith">
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc" AutoPostBack="false">
                    <ClientSideEvents Click="Locclick" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnThemmoi" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Thêm mới (F2)">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnImport" Image-Url="~/images/Excel-icon.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Excel">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindowimport(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnUathich" Image-Url="~/images/Excel-icon.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Dịch vụ ưa thích">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindowUathich(); }" />
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <!--grid load thong tin dich vu-->
    <fieldset>
        <dx:ASPxGridView ID="Grid_Dichvu" KeyFieldName="uId_Dichvu" ClientInstanceName="client_grid" AutoGenerateColumns="false" runat="server"
            SettingsPager-PageSize="17" Width="100%" Font-Size="14px">
            <Columns>
                <dx:GridViewDataColumn FieldName="uId_Dichvu" Visible="false" VisibleIndex="-1" Name="uId_Dicgvu">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Tên dịch vụ" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tendichvu_vn" VisibleIndex="1"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Tendichvu_vn">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Nhóm dịch vụ" Visible="true" VisibleIndex="2" FieldName="nv_TennhomDichvu_vn"
                    Settings-AutoFilterCondition="Contains" Width="20%" Name="vn_TennhomDichvu_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="Giá dịch vụ" Visible="true" PropertiesTextEdit-DisplayFormatString="{0:0,0}" VisibleIndex="3" FieldName="f_Gia"
                    Settings-AutoFilterCondition="Contains" Width="8%" Name="f_Gia" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn Caption="Tính thuế" Visible="true" VisibleIndex="3" FieldName="b_Tinhthue"
                    Settings-AutoFilterCondition="Default" Width="8%" Name="b_Tinhthue" HeaderStyle-HorizontalAlign="Center">
                    <PropertiesCheckEdit DisplayTextChecked="Yes" DisplayTextUnchecked="No" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn Caption="Tính hoa hồng" Visible="true" VisibleIndex="3" FieldName="b_TinhHoahong"
                    Settings-AutoFilterCondition="Default" Width="8%" Name="b_TinhHoahong" HeaderStyle-HorizontalAlign="Center">
                    <PropertiesCheckEdit DisplayTextChecked="Yes" DisplayTextUnchecked="No" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn Caption="Gói dịch vụ" Visible="true" VisibleIndex="3" FieldName="b_Goidichvu"
                    Settings-AutoFilterCondition="Default" Width="100px" Name="b_Goidichvu" HeaderStyle-HorizontalAlign="Center">
                    <PropertiesCheckEdit DisplayTextChecked="Có" DisplayTextUnchecked="Không" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" Caption="Sửa">
                    <DataItemTemplate>
                        <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return ShowEditWindow()">
                            <img src="../../../images/btn_Edit.png" /></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Width="90px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" Caption="Thiết lập">
                    <DataItemTemplate>
                        <a id="popup" title="<%#If(Eval("b_Goidichvu") = "True", "Thiết lập gói dịch vụ", "Thiết lập công đoạn")%>" href='javascript:void(0)' onclick="<%#If (Eval("b_Goidichvu")="True","return ShowEditWindowGoidichvu()","return ShowEditWindowCongdoan()" )%>">
                            <img src="../../images/btn_Detail.png" /></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewCommandColumn VisibleIndex="4" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image Url="~/images/btn_Delete.png"></Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>

            <SettingsEditing EditFormColumnCount="5" Mode="PopupEditForm" />
            <SettingsPopup>
                <EditForm Width="700px" />
            </SettingsPopup>
            <Templates>
                <DetailRow>
                    <div style="padding: 3px 3px 2px 3px">
                        <dx:ASPxPageControl ID="PageC_Chitiet" runat="server" Width="100%" EnableCallBacks="true" Font-Size="16px">
                            <TabPages>
                                <dx:TabPage Text="Chi tiết" Visible="true">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl1" runat="server">
                                            <div class="Div_Grid" style="width: 40%; float: left; padding: 5px">
                                                <table cellpadding="2" cellspacing="3" style="border-collapse: collapse; width: 100%">
                                                    <tr style="width: 200px;">
                                                        <td style="font-weight: bold">Hoa hồng tư vấn viên: </td>
                                                        <td><%# Eval("f_PhantramHH_TVV","{0:0,0}")%> (VND) </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold">Hoa hồng kỹ thuật viên chính: </td>
                                                        <td><%# Eval("f_PhantramHH_KTV", "{0:0,0}")%> (VND)</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold">Hoa hồng cộng tác viên: </td>
                                                        <td><%# Eval("f_PhantramHH_CTV", "{0:0,0}")%> (VND)</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold">Hoa hồng nhân viên phụ: </td>
                                                        <td><%# Eval("f_PhantramHH_NV", "{0:0,0}")%> (VND)</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="Div_Grid" style="width: 40%; float: left; margin-left: 50px">
                                                <table cellpadding="2" cellspacing="3" style="border-collapse: collapse; width: 100%">
                                                    <tr style="width: 200px">
                                                        <td style="font-weight: bold">Giảm giá : </td>
                                                        <td><%# Eval("f_Phidichvu")%> (%)</td>
                                                    </tr>
                                                    <tr style="width: 200px">
                                                        <td style="font-weight: bold">Số lần điều trị: </td>
                                                        <td><%# Eval("i_Solan_Dieutri")%> (lần)</td>
                                                    </tr>
                                                    <tr style="width: 200px">
                                                        <td style="font-weight: bold">Thời gian chuẩn bị: </td>
                                                        <td><%# Eval("f_Sophutchuanbi")%> (Phút)</td>
                                                    </tr>
                                                    <tr style="width: 200px">
                                                        <td style="font-weight: bold">Thời gian thực hiện: </td>
                                                        <td><%# Eval("f_Sophutthuchien")%> (Phút)</td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                            </TabPages>
                        </dx:ASPxPageControl>
                    </div>
                </DetailRow>
            </Templates>
            <SettingsEditing Mode="Inline" />
            <SettingsPager PageSize="17">
            </SettingsPager>
            <SettingsDetail ShowDetailRow="true" />
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <asp:HiddenField ID="hdfuIdDichvu" Value="" runat="server" />
        <dx:ASPxPopupControl ID="pcAddDichvu" runat="server" CloseAction="CloseButton" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddDichvu" Font-Size="25px"
            HeaderText="Thêm / Sửa Dịch vụ" AllowDragging="True" PopupAnimationType="None">
            <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcAddDichvu.Focus(); }" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <dx:ASPxPanel ID="Panel1" runat="server" Width="740px" Height="400px" Font-Size="12px">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent1" runat="server" Width="400px">
                                <asp:UpdatePanel ID="upDichvu" runat="server">
                                    <ContentTemplate>
                                        <fieldset class="field_tt">
                                            <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                            <div class="thongtin" style="width: 719px; height: 330px">
                                                <fieldset class="field_tt" style="float: right; width: 324px">
                                                    <legend><span style="font-weight: bold; color: green; font-size: 14px">Lựa chọn</span></legend>
                                                    <table class="info_table">
                                                        <tr>
                                                            <td class="info_table_td">Gói dịch vụ: </td>
                                                            <td class="info_table_td">
                                                                <asp:CheckBox ID="cbo_Goidv" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Tính hoa hồng: </td>
                                                            <td class="info_table_td">
                                                                <asp:CheckBox ID="cbo_Hoahong" runat="server" name="cbo_Hoahong" AutoPostBack="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Tính thuế: </td>
                                                            <td class="info_table_td">
                                                                <asp:CheckBox ID="cbo_Tinhthue" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                                <fieldset class="field_tt" style="float: left; width: 350px; height: 330px">
                                                    <legend><span style="font-weight: bold; color: green; font-size: 14px">Dịch vụ</span></legend>
                                                    <table class="info_table" style="margin-top: 15px">
                                                        <tr>
                                                            <td class="info_table_td">Tên dich vụ:<a style="color: red">*</a>
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_Tendichvu" name="txt_Tendichvu" placeholder="Nhập vào tên dịch vụ" Width="200px" runat="server" CssClass="nano_textbox"
                                                                    onkeypress="return enter_txtTendv(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Nhóm dịch vụ:
                                                            </td>
                                                            <td class="info_table_td">
                                                                <dx:ASPxComboBox ID="pcmb_NhomDV" DropDownStyle="DropDownList" runat="server" Width="200px" onkeypress="return enter_pcmb_NhomDV(event)"
                                                                    ClientInstanceName="pcmb_NhomDV" IncrementalFilteringMode="StartsWith" ValueType="System.String">
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Giá dịch vụ:<a style="color: red">*</a>
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_GiaDV" AutoPostBack="false" onkeypress="return enter_txt_GiaDV(event)" runat="server" Width="140px"
                                                                    Style="float: left; margin-right: 10px" onkeyup="return jo_ThousanSereprate(this)"
                                                                    CssClass="nano_textbox" placeholder="Chỉ được nhập số"></asp:TextBox>
                                                                <dx:ASPxComboBox ID="pcmb_Ngoaite" DropDownStyle="DropDownList" runat="server" Width="50px"
                                                                    ClientInstanceName="pcmb_Ngoaite" IncrementalFilteringMode="StartsWith" ValueType="System.String" Height="23px" onkeypress="return enter_Ngoaite(event)">
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Giảm giá:
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_Giamgia" onkeypress="return enter_txtGiamgia(event)" runat="server" Width="200px"
                                                                    CssClass="nano_textbox" placeholder="Nhập số phần trăm giảm giá"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Thời gian chuẩn bị:
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_Tgchuanbi" onkeypress="return enter_txtTGchuabi(event)" runat="server" Width="200px"
                                                                    CssClass="nano_textbox" placeholder="Phút"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Thời gian thực hiện:
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_Tgthuchien" onkeypress="return enter_txtTgchuchien(event)" runat="server" Width="200px"
                                                                    CssClass="nano_textbox" placeholder="Phút"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Số lần điều trị:<a style="color: red">*</a>
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_Solandieutri" onkeypress="return enter_txtSolandieutri(event)" runat="server" Width="200px"
                                                                    CssClass="nano_textbox" placeholder="Lần"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Số ngày quay lại :<a style="color: red">*</a>
                                                            </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txtngay"  runat="server" Width="200px"
                                                                    CssClass="nano_textbox" placeholder="Ngày"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                                <fieldset class="field_tt" id="field_tt" style="float: right; width: 324px; height: 163px">
                                                    <legend><span style="font-weight: bold; color: green; font-size: 14px">Hoa hồng</span></legend>
                                                    <table class="info_table" >
                                                        <tr>
                                                           <%-- <td class="info_table_td">Tư vấn viên: </td>--%>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_HHTuvan" runat="server" Visible="false" CssClass="nano_textbox" onkeypress="return enter_txtHHtuvan(event)"
                                                                    placeholder="VND hoặc %" Width="200px" name="txt_HHTuvan" onkeyup="return jo_ThousanSereprate(this)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <%--    <td class="info_table_td">Cộng tác viên: </td>--%>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_HHCongtac" runat="server" Visible="false" CssClass="nano_textbox" onkeypress="return enter_txtHHCongtac(event)"
                                                                    onkeyup="return jo_ThousanSereprate(this)" placeholder="VND hoặc %" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Tiền dịch vụ : </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_HHNhanvienchinh" runat="server"  CssClass="nano_textbox" onkeypress="return enter_txtHHnvc(event)"
                                                                    onkeyup="return jo_ThousanSereprate(this)" placeholder="VND hoặc %" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="info_table_td">Tiền TIP: </td>
                                                            <td class="info_table_td">
                                                                <asp:TextBox ID="txt_HHNhanvienphu" runat="server"  CssClass="nano_textbox" onkeypress="return enter_txtHHnvp(event)"
                                                                    onkeyup="return jo_ThousanSereprate(this)" placeholder="VND hoặc %" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                                </caption>
                                            </div>
                                            <div style="height: 20px">
                                                <label id="lbl_Error" runat="server" class="error"></label>
                                            </div>
                                            <div class="pcmButton" style="width: 400px; height: 40px; float: left">
                                                <dx:ASPxButton ID="btOK" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" OnClick="btOK_Click1" runat="server" Text="Lưu (F4)" Style="float: left; margin-right: 8px">
                                                    <ClientSideEvents Click="CheckEmpty" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                                    <ClientSideEvents Click="ClearText_Dev" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                                    <ClientSideEvents Click="ClosePopup" />
                                                </dx:ASPxButton>
                                            </div>
                                            <div style="width: 300px; float: right; color: red;">
                                                <asp:Label ID="lbl_Thongbao" CssClass="divThongBao" Text="" runat="server" Font-Bold="true"></asp:Label>
                                            </div>
                                        </fieldset>

                                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updichvu" DisplayAfter="0" DynamicLayout="false">
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
    </fieldset>
    <asp:HiddenField ID="hdfuIdDVCongdoan" Value="" runat="server" />
    <asp:HiddenField ID="hdfuIdCongdoan" Value="" runat="server" />
    <dx:ASPxPopupControl ID="pcAddcongdoan" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddcongdoan" Font-Size="25px"
        HeaderText="Thiết lập công đoạn" AllowDrgging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcAddcongdoan.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="600px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server" Width="400px">
                            <asp:UpdatePanel ID="upCongdoan" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt" style="width: 575px; text-align: center; height: auto">
                                        <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                        <div class="thongtin" style="width: 570px; height: auto">
                                            <fieldset class="field_tt" id="Fieldset1" style="width: 323px; height: auto; margin: auto">
                                                <legend><span style="font-weight: bold; color: green; font-size: 14px"></span></legend>
                                                <table class="info_table">
                                                    <tr>
                                                        <td class="info_table_td">Tên dịch vụ: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox ID="txt_Congdoan_Tendichvu" runat="server" CssClass="nano_textbox" Style="float: left"
                                                                Width="200px" name="txt_HHTuvan" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Tên công đoạn: </td>
                                                        <td class="info_table_td">
                                                            <dx:ASPxComboBox ID="cboCongdoan" ValueType="System.String" TextFormatString="{0}-{1}" DropDownStyle="DropDown" IncrementalFilteringMode="Contains" runat="server" ClientInstanceName="cbocongdoan" Width="200px"></dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="info_table_td">Hoa hồng: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox ID="txt_Congdoan_Hoahong" runat="server" CssClass="nano_textbox" onkeypress="return enter_txt_Congdoan_Hoahong(event)"
                                                                onkeyup="return jo_ThousanSereprate(this)" placeholder="VND hoặc %" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="info_table_td">Kho
                                                        </td>
                                                        <td class="info_table_td">
                                                            <dx:ASPxCheckBox ID="chkKho" runat="server" ClientInstanceName="chkkho" Style="float: left; margin-right: 10px" AutoPostBack="false">
                                                                <ClientSideEvents CheckedChanged="chkkho_checkchange" />
                                                            </dx:ASPxCheckBox>
                                                            <dx:ASPxComboBox ID="cboKho" runat="server" ClientInstanceName="cbokho" Style="float: left" Width="169px"></dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Mặt hàng:</td>
                                                        <td class="info_table_td">
                                                            <dx:ASPxComboBox ID="cboMathang" IncrementalFilteringMode="Contains" runat="server" ValueType="System.String" TextFormatString="{0}-{1}" DropDownStyle="DropDown" ClientInstanceName="cbomathang" Width="200px"></dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Số lượng:</td>
                                                        <td class="info_table_td">
                                                            <dx:ASPxTextBox ID="txtSoluong" runat="server" Width="50px" Style="margin-right: 47px; float: left" ClientInstanceName="txtsoluong"></dx:ASPxTextBox>
                                                            <dx:ASPxLabel ID="lblSophut" runat="server" Style="float: left" Text="Số phút:"></dx:ASPxLabel>
                                                            <dx:ASPxTextBox ID="txtSophut" runat="server" Style="float: left" Width="50px" ClientInstanceName="txtsophut"></dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="info_table_td">Ghi chú: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox ID="txt_Ghichu" runat="server" CssClass="nano_textbox" onkeydown="return enter_txt_Ghichu(event)"
                                                                onkeyup="return jo_ThousanSereprate(this)" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <div style="width: 60%; height: 50px; margin: auto">
                                            <table style="width: 100%; height: 100%">
                                                <tr>
                                                    <td>
                                                        <dx:ASPxButton ID="btn_luu" Image-Url="~/images/btn_Save.png" AutoPostBack="false" ClientInstanceName="btn_luu" OnClick="btn_luu_Click" runat="server"
                                                            Text="Lưu " Style="float: left; margin-right: 8px">
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxButton ID="btn_Clear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png"
                                                            Text="Làm mới " Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="clear_CongdoanEvt" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxButton ID="btn_cancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát"
                                                            AutoPostBack="false" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopupCD" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="field_tt" id="Fieldset2" style="width: 96%; height: 166px; margin: auto">
                                            <dx:ASPxGridView ID="Grid_Congdoan" runat="server" KeyFieldName="uId_Dichvu;uId_Congdoan;uId_Dichvu_Congdoan" ClientInstanceName="clientgrid_congdoan" AutoGenerateColumns="false" Width="100%">
                                                <Columns>
                                                    <dx:GridViewDataColumn FieldName="uId_Congdoan" VisibleIndex="-1" Name="uId_Congdoan" Visible="false"></dx:GridViewDataColumn>
                                                    <dx:GridViewDataTextColumn FieldName="nv_Tencongdoan_vn" VisibleIndex="1" Caption="Tên công đoạn"
                                                        Visible="true" HeaderStyle-HorizontalAlign="Center">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="nv_Ghichu" VisibleIndex="2" Name="nv_Ghichu" Caption="Mặt hàng"
                                                        Visible="true" HeaderStyle-HorizontalAlign="Center">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="f_Soluong" VisibleIndex="2" Name="f_Soluong" Caption="Số lượng"
                                                        Visible="true" HeaderStyle-HorizontalAlign="Center">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="f_Sophut" VisibleIndex="2" Name="f_Sophut" Caption="Số phút"
                                                        Visible="true" HeaderStyle-HorizontalAlign="Center" Width="80px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="uId_Kho" Visible="false" />
                                                    <dx:GridViewDataTextColumn FieldName="uId_Dichvu" Visible="false" />
                                                    <dx:GridViewDataTextColumn FieldName="uId_Mathang" Visible="false" />
                                                    <dx:GridViewDataTextColumn FieldName="uId_Dichvu_Congdoan" Visible="false" />
                                                    <%--                                                    <dx:GridViewCommandColumn VisibleIndex="3" Width="100px" Caption="Sửa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                                        <EditButton Visible="true" Image-Url="../../images/btn_Delete.png" Image-AlternateText="Sửa">
                                                            <Image Url="../../images/btn_Edit.png"></Image>
                                                        </EditButton>
                                                    </dx:GridViewCommandColumn>--%>
                                                    <%--                                                    <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" Caption="Sửa">
                                                        <DataItemTemplate>
                                                            <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return SelectCongdoan()">
                                                                <img src="../../../images/btn_Edit.png" /></a>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>--%>
                                                    <dx:GridViewCommandColumn VisibleIndex="3" Width="30px" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                                            <Image Url="~/images/btn_Delete.png"></Image>
                                                        </DeleteButton>
                                                    </dx:GridViewCommandColumn>
                                                </Columns>
                                                <SettingsEditing Mode="Inline" />
                                                <SettingsPager PageSize="3"></SettingsPager>
                                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                                <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { Congdoanselect(s,e); }" />
                                                <Styles>
                                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                    </AlternatingRow>
                                                </Styles>
                                            </dx:ASPxGridView>
                                        </div>
                                        <asp:Label ID="lbl_ErrorCD" runat="server" CssClass="error" Text=""></asp:Label>
                                        </caption>

                                    </fieldset>

                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="upCongdoan" DisplayAfter="0" DynamicLayout="false">
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
    <dx:ASPxPopupControl ID="PcImportExcel" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="PcImportExcel" Font-Size="25px"
        HeaderText="Import Excel" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="350px" Height="150px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server" Width="300px">
                            <div style="width: 290px; height: 100px">
                                <fieldset class="field_tt" style="width: 335px; height: 60px; margin: auto">
                                    <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                    <div style="height: 30px; width: 300px">
                                        <asp:FileUpload ID="UploadFileExcel" runat="server" Width="335px" BorderStyle="Groove" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="chỉ được upload file .xls và xlsx"
                                            ValidationExpression="^(?!\..*)(?!.*\.\.)(?=.*[^.]$)([^\&quot;#%&*:<>?\\/{|}~]){1,123}\.(xlsx|xls)$" ControlToValidate="UploadFileExcel">
                                        </asp:RegularExpressionValidator>

                                    </div>
                                    <div style="float: left; margin: 5px; width: 100%; height: 14px">
                                        <dx:ASPxRadioButton ID="radDichvu" runat="server" GroupName="rad" Text="Dịch vụ" Style="float: left" ClientInstanceName="raddichvu"></dx:ASPxRadioButton>
                                        <dx:ASPxRadioButton ID="radCongdoan" runat="server" GroupName="rad" Text="Công đoạn" ClientInstanceName="radcongdoan" Style="float: left"></dx:ASPxRadioButton>
                                        <dx:ASPxRadioButton ID="radDMCongdoan" runat="server" GroupName="rad" Text="DM Công đoạn" ClientInstanceName="raddmcongdoan" Style="float: left"></dx:ASPxRadioButton>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="link_Taiexcl_Mau" runat="server" Text="Excel mẫu" OnClick="link_Taiexcl_Mau_Click"></asp:LinkButton>
                                    </div>
                                </fieldset>
                            </div>
                            <div>
                                <asp:Label ID="lbl_Import" runat="server" CssClass="error" Font-Size="16px" Text=""></asp:Label>
                                <dx:ASPxButton ID="btn_Import" Image-Url="~/images/btn_Save.png" runat="server" Text="Tải lên" OnClick="btn_Import_Click"
                                    Style="float: left; margin-right: 8px" ClientInstanceName="btn_Import">
                                    <ClientSideEvents Click="importClientclick" />
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
    <dx:ASPxPopupControl ID="PCDVUathich" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides" ClientInstanceName="PCDVUathich" Font-Size="25px"
        HeaderText="Dịch vụ ưa thích" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" Width="819px" Font-Size="12px" Height="95%">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server" Width="100%">
                            <div style="width: 100%; height: auto">
                                <fieldset class="field_tt" style="width: 98%; height: auto; margin: auto">
                                    <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                    <ul>
                                        <li class="text_title">Từ ngày: </li>
                                        <li class="text_title">
                                            <dx:ASPxDateEdit ID="dateTungay" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                        </li>
                                        <li class="text_title">Đến ngày: </li>
                                        <li class="text_title">
                                            <dx:ASPxDateEdit ID="dateDenngay" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                        </li>
                                        <li class="text_title">
                                            <dx:ASPxButton ID="btnLocuathich" runat="server" Text="Lọc" AutoPostBack="false">
                                                <ClientSideEvents Click="Callbackrp" />
                                            </dx:ASPxButton>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                            <fieldset class="field_tt">
                                <div style="width: 95%; margin: auto">
                                    <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' ReportViewerID="ReportViewer1">
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
                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="200px" ClientInstanceName="ReportViewerCallback">
                                        <PanelCollection>
                                            <dx:PanelContent>
                                                <dx:ReportViewer ID="ReportViewer1" runat="server" Width="95%"></dx:ReportViewer>
                                            </dx:PanelContent>
                                        </PanelCollection>
                                    </dx:ASPxCallbackPanel>
                                </div>
                            </fieldset>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="PCThietlapgoidv" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcthietlapgoidv" Font-Size="25px"
        HeaderText="Thiết lập gói dịch vụ" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                <dx:ASPxPanel ID="ASPxPanel4" runat="server" Width="699px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent5" runat="server" Width="699">
                            <fieldset class="field_tt" style="width: auto; margin: auto">
                                <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                <div class="container-fluid" style="width:100%; margin:0;padding:0;height:auto">
                                    <ul>
                                        <li class="text_title">Dịch vụ:</li>
                                        <li class="text_title">
                                            <dx:ASPxComboBox ID="cboDichvuGoi" runat ="server" ClientInstanceName="cbodichvugoi" >
                                                <ClientSideEvents SelectedIndexChanged="cbodvgoiChange" />
                                            </dx:ASPxComboBox>
                                        </li>
                                        <li class="text_title">Số lượng:</li>
                                        <li class="text_title">
                                            <dx:ASPxTextBox ID="txtSoluongDVG" runat ="server" ClientInstanceName="txtsoluongdvg" Width="50px"></dx:ASPxTextBox>
                                        </li>
                                        <li class="text_title">Đơn giá:</li>
                                        <li class="text_title" style="width:100px"> 
                                            <dx:ASPxTextBox ID="txtDongiaDVG" runat="server" Width="80px" MaskSettings-Mask="<0..9999999999g><>" ClientInstanceName="txtdongiadvg"></dx:ASPxTextBox>
                                        </li>
                                        <li class="text_title">
                                            <dx:ASPxButton ID="btnLuuGDV" runat="server" ClientInstanceName="btnluugdv" Text="Lưu" Image-Url="~/images/btn_Save.png" AutoPostBack="false">
                                                <ClientSideEvents Click="btnluugdvClick" />
                                            </dx:ASPxButton>
                                        </li>
                                    </ul>
                                    <dx:ASPxGridView ID="GrvDichvugoi" runat="server" OnRowDeleting="GrvDichvugoi_RowDeleting" KeyFieldName="uId_Goidichvu;uId_Dichvu" ClientInstanceName="grvdichvugoi" Width="100%">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Số lượng" FieldName="f_Soluong"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Đơn giá" FieldName="f_Dongia"></dx:GridViewDataTextColumn>
                                             <dx:GridViewCommandColumn VisibleIndex="4" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image Url="~/images/btn_Delete.png"></Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </div>
                                <div style="margin-top:10px">
                                <asp:Label ID="Label1" runat="server" CssClass="error" Font-Size="16px" Text=""></asp:Label>
                                <dx:ASPxButton ID="ASPxButton2" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                    <ClientSideEvents Click="ClosePopupgdv" />
                                </dx:ASPxButton>
                                    </div>
                            </fieldset>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
