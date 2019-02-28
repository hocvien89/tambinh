<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master"
    CodeBehind="CustomerList.aspx.vb" Inherits="NANO_SPA.CustomerList" Title="" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
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
    <script>
        var _fieldName = '';
        var _ngaysinh = new Date();
        function grid_RowDblClick(s, e) {
            //var srcElement = e.htmlEvent.srcElement ? e.htmlEvent.srcElement : e.htmlEvent.target;
            //_fieldName = srcElement.getAttsribute('FieldName');
            s.StartEditRow(e.visibleIndex);
        }
        function grid_FocusedRowChanged(s, e) {
            if (s.cpIsEditing) {
                s.UpdateEdit();
            }
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
                alert("Bạn không có quyền xóa bệnh nhân!");
            }
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }

        }
        function ShowAddWindowimport() {
            PcImportExcel.Show();
            document.getElementById("<%=lbl_Import.ClientID%>").innerHTML = ""
        }
        //Set default short key code
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'BC3402F3-9B32-4ED1-9625-A657699A784B'}";
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

        //Show popup add or edit customer
        function ShowEditWindow() {
            pcAddKhachhang.Show();
            var txtHoten = document.getElementById("<%=txtHoten.ClientID %>");
            ClearText();
            txtHoten.focus();
        }
        function ShowAddWindow() {
            pcAddKhachhang.Show();
            var txtMaKH = document.getElementById("<%=txtMaKH.ClientID%>");
            ClearText();
        }
        //Su kien khi chon 1 dong
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                client_grid.GetRowValues(e.visibleIndex, 'v_Makhachang;uId_Khachhang', OnGridSelectionComplete);
            }
        }
        function ClosePopup(s, e) {
            pcAddKhachhang.Hide();
            PcImportExcel.Hide();
            client_grid.Refresh();
        }
        function OnGridSelectionComplete(values) {
            //Gan gia tri cho hidden field uId khachhang de sua thong tin khach hoac lam gi do
            jo_RemoveSession("uId_Khachhang");
            jo_CreateSession("uId_Khachhang", values[1]);
            var hdfuIdKhachhang = document.getElementById("<%=hdfuIdKhachhang.ClientID%>");
            hdfuIdKhachhang.value = values[1];
            var param_dt = "{'uId_Khachhang':'" + values[1] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinKhachHang";
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
                var imgAnhdaidien = document.getElementById('<%=imgAnhdaidien.ClientID%>');
                var txtImgUrl = document.getElementById('<%=txtImgUrl.ClientID%>');
                var date_ngayden = new Date(defaultdata[0]);
             
                //cbo_nhanvientuvan.SetValue(defaultdata[15]);
                deNgayden.SetDate(date_ngayden);
                txtMaKH.value = defaultdata[1];
                txtHoten.value = defaultdata[2];
                txtnamsinh.SetText(defaultdata[3])
                //var date_ngaysinh = new Date(defaultdata[3]);
                //_ngaysinh = date_ngaysinh;
                //var date_Nam = new Date("01/01/1900")
                //deNgaysinh.SetDate(date_ngaysinh);
                //if (date_ngaysinh.getDate() == date_Nam.getDate() & date_ngaysinh.getMonth() == date_Nam.getMonth() & date_ngaysinh.getFullYear() == date_Nam.getFullYear()) {
                //    chk_Ngaysinh.SetChecked(true);
                //    deNgaysinh.SetEnabled(false);
                //}
                //else {
                //    chk_Ngaysinh.SetChecked(false);
                //    deNgaysinh.SetEnabled(true);
                //}
                //txttinhtrangda.SetText(defaultdata[13]);
                //txtsuckhoe.SetText(defaultdata[14]);


                ddlGioitinh.SetValue(ConvertSex(defaultdata[4]));
                txtDiachi.value = defaultdata[5];
                txtDienthoai.value = defaultdata[6];
                txtEmail.value = defaultdata[7];
                ddlNghenghiep.SetValue(defaultdata[8]);
                //ddlNguon.SetValue(defaultdata[9]);
                txtGhichu.value = defaultdata[10];
                imgAnhdaidien.src = defaultdata[11];
                txtImgUrl.value = defaultdata[11];
                txt_Chandoan.SetValue(defaultdata[19]);
             if (defaultdata[14] == 1) {
                    radkh.SetChecked(true);
                }
                else if (defaultdata[14] == 2) {
                    radnv.SetChecked(true);
                }
                else if (defaultdata[14] == 3) {
                    rednguon.SetChecked(true);
                }
                if (defaultdata[12] == "") {
                    chk_ngthieu.SetChecked(false);
                    cbo_nguoigioithieu.SetEnabled(false);
                    cbo_nguoigioithieu.SetText('');
                }
                else {
                    chk_ngthieu.SetChecked(true);
                    cbo_nguoigioithieu.SetEnabled(true);
                    cbo_nguoigioithieu.SetValue(defaultdata[12]);
                }
               
              
            }
        }
        function onFail(ex) {
            alert(ex._message + " fail");
            return false;
        }
        //CKFINDER
        function Upload() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                document.getElementById('<%=imgAnhdaidien.ClientID%>').src = fileUrl;
                document.getElementById('<%=txtImgUrl.ClientID%>').value = fileUrl;
            };
            finder.popup();
        }
        //CLEAR TEXT
        function ClearText() {
            var txtMaKH = document.getElementById("<%=txtMaKH.ClientID %>");
            var txtHoten = document.getElementById("<%=txtHoten.ClientID %>");
            var txtDiachi = document.getElementById("<%=txtDiachi.ClientID%>");
            var txtDienthoai = document.getElementById("<%=txtDienthoai.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            var imgAnhdaidien = document.getElementById('<%=imgAnhdaidien.ClientID%>');
            var txtImgUrl = document.getElementById('<%=txtImgUrl.ClientID%>');
            var hdfuIdKhachhang = document.getElementById("<%=hdfuIdKhachhang.ClientID%>");
            var hdfKHGThieu = document.getElementById("<%=hdfKHGThieu.ClientID%>");
            radkh.SetChecked(false);
            radnv.SetChecked(false);
            radnguon.SetChecked(false);
            //txt_Danhgia.SetText('');
            txtHoten.value = "";
            txtDiachi.value = "";
            txtDienthoai.value = "";
            txtnamsinh.SetText("");
            //deNgayden.SetDate(new Date());
            //deNgaysinh.SetDate(new Date());
            txtEmail.value = "";
            txtGhichu.value = "";
            imgAnhdaidien.src = "";
            txtImgUrl.value = "";
            //chk_Ngaysinh.SetChecked(false);
            cbo_nguoigioithieu.SetText('');
            jo_RemoveSession("uId_Khachhang");
            hdfuIdKhachhang.value = "";
            hdfKHGThieu.value = "";
            chk_ngthieu.SetChecked(false);
            cbo_nguoigioithieu.SetEnabled(false);
            //deNgaysinh.SetEnabled(true);
            ltrError.SetText("");
            ltrSuccess.SetText("");
            txtHoten.focus();
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
        function ClearText_Dev(s, e) {
            ClearText();
        }
        //Enter key function Form
        function enter_txtHoten(e) {
            console.log("enter key ho ten");
            if (e.keyCode == 13) {
                //pcDsKhachhangSearch.Show();
                //grvdanhsachsearch.Refresh();
                var txtHoten = document.getElementById("<%=txtHoten.ClientID%>");
                if (txtHoten.value != "") {
                    txtnamsinh.Focus();
                }
                return false;
            }
        }
        function enter_txtnamsinh(e) {
            if (e.keyCode == 13) {
                //var txtTuoi = document.getElementById("");
                //var currentTime = new Date()
                //var year = currentTime.getFullYear()
                //txtTuoi.value = year - parseInt(deNgaysinh.GetText().split("/")[2]);
                var txtdiachi = document.getElementById("<%=txtDiachi.ClientID%>");
                txtdiachi.focus();
                return false;
            }
        }
        function enter_ddlGioitinh(e) {
            if (e.keyCode == 13) {
                var txtDiachi = document.getElementById("<%=txtDiachi.ClientID%>");
                txtDiachi.Focus();
                return false;
            }
        }
        function enter_txtDiachi(e) {
            if (e.keyCode == 13) {
                var txtdienthoai = document.getElementById("<%=txtDienthoai.ClientID%>");
                txtdienthoai.focus();
                
                return false;
            }
        }
        function enter_txtDienthoai(e) {
            if (e.keyCode == 13) {
                //var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
                //txtEmail.focus();
                btOk.Focus();
                return false;
            }
        }
        function enter_txtEmail(e) {
            if (e.keyCode == 13) {
                ddlNghenghiep.Focus();
                return false;
            }
        }
        function enter_ddlNghenghiep(e) {
            if (e.keyCode == 13) {
                ddlNguon.Focus();
                return false;
            }
        }
        function enter_ddlNguon(e) {
            if (e.keyCode == 13) {
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                txtGhichu.focus();
                return false;
            }
        }

        function enter_txtLichsuchamsocsuckhoe(e) {
            if (e.keyCode == 13) {
                btOk.Focus();
                return false;
            }
        }
        function Chonphieudichvu(uId_Phieudichvu, uId_Khachhang) {
            jo_RemoveSession("uId_Khachhang");
            jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
            jo_CreateSession("uId_Khachhang", uId_Khachhang);
            window.location.href = "../../OrangeVersion/Customer/BillingServices.aspx";
            return false;
        }
        function Chonphieuxuat(uId_Phieuxuat, uId_Khachhang) {
            jo_RemoveSession("uId_Khachhang");
            jo_CreateSession("uId_Phieuxuat", uId_Phieuxuat);
            jo_CreateSession("uId_Khachhang", uId_Khachhang);
            window.location.href = "../../OrangeVersion/Product/ExportProduct.aspx";
            return false;
        }
        function Thietlaplieutrinh(uId_Phieudichvu, uId_Khachhang, uId_Dichvu_Dieutri, uId_Phieudichvu_Chitiet) {
            jo_RemoveSession("uId_Khachhang");
            jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
            jo_CreateSession("uId_Khachhang", uId_Khachhang);
            jo_CreateSession("uId_Dichvu_Dieutri", uId_Dichvu_Dieutri);
            jo_CreateSession("uId_Phieudichvu_Chitiet", uId_Phieudichvu_Chitiet);
            jo_RemoveSession("uId_QT_Dieutri");
            window.location.href = "../../OrangeVersion/Customer/CustomerTherapy.aspx";
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
        function ThanhtoancongnoXuat(uId_Phieuxuat, vSophieu) {
            var tienno = "";
            var param_dt = "{'uId_Phieuxuat':'" + uId_Phieuxuat + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/GetNoPhieuXuat";
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
                jo_CreateSession("uId_Phieuxuat", uId_Phieuxuat);
                window.location.href = "../../OrangeVersion/Finance/Debt.aspx?px=" + vSophieu;
            }
            else {
                alert("Phiếu không nợ!");
            }
            return false;
        }
        function CheckEmpty(s, e) {
            var makh = document.getElementById('<%=txtHoten.ClientID%>');
            var txtSDT = document.getElementById('<%=txtDienthoai.ClientID%>');
            var txtEmail = document.getElementById('<%=txtEmail.ClientID%>');

            var error = document.getElementById('diverror');
            if (deNgayden.GetText() == "01/01/0100") {
                deNgayden.Focus();
                error.innerHTML = "Ngày đến không được để trống";
                deNgayden.ShowDropDown();
                e.processOnServer = false;
            }
            else if (txtnamsinh.GetText() == "") {
                txtnamsinh.Focus();
                error.innerHTML = "Ngày sinh không được để trống";
                //deNgaysinh.ShowDropDown();
                e.processOnServer = false;
            }
            else if (document.getElementById("<%=txtHoten.ClientID%>").value == "") {
                document.getElementById("<%=txtHoten.ClientID%>").focus();
                error.innerHTML = "Tên bệnh nhân không được để trống";
                e.processOnServer = false;
            }
            else if (document.getElementById("<%=txtMaKH.ClientID%>").value == "") {
                document.getElementById("<%=txtMaKH.ClientID%>").focus();
                error.innerHTML = "Mã bệnh nhân không được để trống";
                e.processOnServer = false;
            }
            else if (txtSDT.value == "") {
                error.innerHTML = "Hãy nhập vào số điện thoại!"
                e.processOnServer = false;
                txtSDT.focus();
            }
            else if (txtEmail.value != "") {
                var uId_Khachhang = jo_GetSession("uId_Khachhang")
                if (CheckExist("email", txtEmail.value) == "existemail" && (uId_Khachhang=""||uId_Khachhang==null)) {
                    error.innerHTML = "Email đã tồn tại!";
                    e.processOnServer = false;
                    txtEmail.focus();
                }
            }
            //else if (cbo_nhanvientuvan.GetText() == "") {
            //    error.innerHTML = "Bạn nhập vào nhân viên tư vấn!";
            //    e.processOnServer = false;
            //    cbo_nhanvientuvan.focus();
            //}
            else if (txtSDT.value != "") {
                var uid_khachhang = jo_GetSession("uId_Khachhang")
                if (uid_khachhang == "" || uid_khachhang == "null") {
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
                }
            }

            //else if (chk_Ngaysinh.GetChecked() == true & document.getElementById("<%=txtGhichu.ClientID%>").value == "") {
            //document.getElementById("<%=txtGhichu.ClientID%>").focus()
            //error.innerHTML = "Hãy ghi năm sinh của bệnh nhân vào mục ghi chú";
            //e.processOnServer = false;
            //}
        }
        function chk_NgaysinhChange(s, e) {
            if (chk_Ngaysinh.GetChecked() == true) {
                deNgaysinh.SetDate(new Date("01/01/1900"));
                deNgaysinh.SetEnabled(false);
            }
            else {
                deNgaysinh.SetEnabled(true);
                deNgaysinh.SetDate(_ngaysinh);
            }
        }

        function chk_NGThieuChange(s, e) {
            if (chk_ngthieu.GetChecked() == true) {
                cbo_nguoigioithieu.SetEnabled(true);
            }
            else {
                cbo_nguoigioithieu.SetEnabled(false);
            }
        }
        function myfunction(s, e) {
         if(   radkh.GetChecked()==true)
            {
                cbo_nguoigioithieu.PerformCallback();
         }
         else if (radnv.GetChecked() == true)
         {
                cbo_nguoigioithieu.PerformCallback();
         }
         else if (radnguon.GetChecked() == true)
         {
                cbo_nguoigioithieu.PerformCallback();
         }

        }
        function cbo_NGThieuChange(s, e) {
            var uId_NGThieu = document.getElementById("<%=hdfKHGThieu.ClientID%>");
            if (cbo_nguoigioithieu.GetSelectedItem().value == "") {
                uId_NGThieu.value = "";
            }
            else {
                uId_NGThieu.value = cbo_nguoigioithieu.GetSelectedItem().value;
            }
        }
        function chkallChange(s, e) {
            if (chkall.GetChecked() == true) {
                detungay.SetEnabled(false);
                dedenngay.SetEnabled(false);
                client_grid.Refresh();
            }
            else {
                detungay.SetEnabled(true);
                dedenngay.SetEnabled(true);
                client_grid.Refresh();
            }
        }
        function locclick(s, e) {
            client_grid.Refresh();
        }

        function Checkthemdv(s, e) {
            var hdfuIdKhachhang = jo_GetSession("uId_Khachhang");
            var error = document.getElementById('diverror');
            if (hdfuIdKhachhang == "" || hdfuIdKhachhang == null) {
                error.innerHTML = "Hãy lưu lại trước khi thêm phiếu dịch vụ!";
                e.processOnServer = false;
            }
        }

        function Checkthempx(s, e) {
            var hdfuIdKhachhang = jo_GetSession("uId_Khachhang");
            var error = document.getElementById('diverror');
            if (hdfuIdKhachhang == "" || hdfuIdKhachhang == null) {
                error.innerHTML = "Hãy lưu lại trước khi thêm phiếu xuất!";
                e.processOnServer = false;
            }
        }

        function Checkbooklich(s, e) {
            pcAddKhachhang.Hide();
            pcbooklich.Show();
            cbokhachhang.PerformCallback();
        }

        function OnKhachhangChanged() {
            cbodichvu.PerformCallback();
        }
        function Chonkhachhang(uidkhachhang, vdienthoai) {
            var value = (vdienthoai + "$" + uidkhachhang).split("$");
            OnGridSelectionComplete(value);
            pcDsKhachhangSearch.Hide();
        }
        function Kichhoatthetaikhoan(uId_Khachhang) {
            jo_CreateSession("uId_Khachhang", uId_Khachhang);
            client_dgvDsTheTT.Refresh();
            pcCapthe.Show();
        }
        function ClosePopupDatlich() { }
        function Unlock_Account(uId_Khachhang_Goidichvu, b_Trangthai) {
            if (b_Trangthai == "Đã kích hoạt") {
                alert("Thẻ đã kích hoạt");
            }
            else {
                var param_dt = "{'uId_Khachhang_Goidichvu':'" + uId_Khachhang_Goidichvu + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/Update_Thekhachhang";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d == "YES") {
                            alert("Kích hoạt thành công !");
                            client_dgvDsTheTT.Refresh();
                        }
                    },
                    error: onFail
                });
            }
        }
        //in don thuoc
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
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ BỆNH NHÂN</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">
                <dx:ASPxCheckBox ID="chkViewAll" AutoPostBack="false" Text="Xem tất cả" runat="server" ClientInstanceName="chkall">
                    <ClientSideEvents CheckedChanged="chkallChange" />
                </dx:ASPxCheckBox>
            </li>
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="deTuNgay" CssClass="dateedit_ipad" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" ClientInstanceName="detungay"
                    runat="server">
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="deDenNgay" CssClass="dateedit_ipad" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" ClientInstanceName="dedenngay"
                    runat="server">
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc" AutoPostBack="false">
                    <ClientSideEvents Click="locclick" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnThemmoi" Image-Url="~/images/16x16/add.png" ClientInstanceName="btnThemmoi" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Thêm mới (F2)">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_ImportExcel" Image-Url="~/images/Excel-icon.png" ClientInstanceName="btnThemmoi" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Nhập Excel">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindowimport(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="bnt_ExportExcel" Image-Url="~/images/Excel-icon.png" ClientInstanceName="btnXuatexcel" Height="20px" Style="bottom: 5px; position: relative" OnClick="bnt_ExportExcel_Click"
                    runat="server" Text="Xuất Excel">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <div class="">
        <dx:ASPxGridView ID="dgvDevexpress" Width="100%" runat="server" ClientInstanceName="client_grid"
            AutoGenerateColumns="false" KeyFieldName="uId_Khachhang;nv_Hoten_vn"
            SettingsPager-Position="Bottom" OnRowDeleting="dgvDevexpress_RowDeleting">
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang"
                    Name="uId_Khachhang">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã bệnh nhân" FieldName="v_Makhachang"
                    Name="v_Makhachang">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                    Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Tên bệnh nhân" FieldName="nv_Hoten_vn"
                    Name="nv_Hoten_vn">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="90" VisibleIndex="2" Caption="Năm sinh" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" FieldName="d_Ngaysinh" Name="d_Ngaysinh">
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
                <dx:GridViewDataTextColumn Caption="Bệnh sử" Settings-AutoFilterCondition="Contains"
                    VisibleIndex="3" FieldName="nv_Ghichu_vn" Name="nv_Ghichu_vn" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn  Caption="Chẩn đoán" Settings-AutoFilterCondition="Contains"
                    VisibleIndex="3" FieldName="nv_Diachi_en" Name="nv_Diachi_en">
                </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn Caption="Nguồn" Width="150" Settings-AutoFilterCondition="Contains"
                    VisibleIndex="3" FieldName="nv_Nguon_vn" Name="nv_Nguon_vn">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ngày đến" Width="90" Settings-AutoFilterCondition="Contains"
                    VisibleIndex="3" FieldName="d_Ngayden" Name="d_Ngayden" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return ShowEditWindow()">
                            <img src="../../../images/btn_Edit.png" /></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                 <dx:GridViewDataColumn Visible="false" Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <a id="popup" title="Kích hoạt thẻ" href='javascript:void(0)' onclick="return <%# String.Format("Kichhoatthetaikhoan('{0}')", Eval("uId_Khachhang")).ToString%>">
                            <img src="../../images/16x16/card_front.png" /></a>
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
                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ngày hết hạn" FieldName="d_Ngayketthuc"
                                                        Name="d_Ngayketthuc">
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
                                                            <a id="popup" title="Chọn phiếu" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieudichvu('{0}', '{1}')",Eval("uId_Phieudichvu"), Eval("uId_Khachhang")).ToString %>">
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
                                                                        Caption="Trạng thái" FieldName="b_Trangthai" Name="b_Trangthai">
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
                                                                                        Caption="Bệnh sử" FieldName="nv_Ghichu" Name="nv_Ghichu">
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
                                                            Caption="Số dư tài khoản" FieldName="f_Giatrigoi" Name="f_Giatrigoi" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataComboBoxColumn Caption="Trạng thái" HeaderStyle-HorizontalAlign="Center" FieldName="b_Kichhoat"
                                                            Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="b_Kichhoat" Width="100px">
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
            <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </div>
    <asp:HiddenField ID="hdfuIdKhachhang" Value="" runat="server" />
    <asp:HiddenField ID="hdfKHGThieu" runat="server" />
    <dx:ASPxPopupControl ID="pcAddKhachhang" runat="server" CloseAction="CloseButton" Modal="True" ShowCloseButton="true" ShowMaximizeButton="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddKhachhang"
        HeaderText="Thêm / Sửa bệnh nhân" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcAddKhachhang.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="900px" Height="350px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <asp:UpdatePanel ID="upKhachhang" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Thông tin bệnh nhân</span></legend>
                                         <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Ngày đến:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="deNgayden" UseMaskBehavior="true" ClientInstanceName="deNgayden" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                </td>
                                                <td class="info_table_td">Mã bệnh nhân:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtMaKH" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td rowspan="6" style="padding-left: 58px" align="Left" valign="top" align="center">
                                                    <div style="width: 115px; height: 135px; border: 2px solid #B7B7B7;">
                                                        <asp:Image ID="imgAnhdaidien" Visible="true" Width="115px" Height="135px" runat="server" />
                                                    </div>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtImgUrl" runat="server" Width="0px" CssClass="bigtext "></asp:TextBox>
                                                    <input type="Button" id="Button1" value="X" width="75px" class="Button" />
                                                    <input type="Button" id="btnSelectImg" onclick="javascript: Upload()" value="..."
                                                        width="75px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Họ tên:
                                                </td>
                                                <td class="info_table_td">

                                                    <asp:TextBox ID="txtHoten" AutoPostBack="false" onkeypress="return enter_txtHoten(event)" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Năm sinh:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxCheckBox ID="chk_Ngaysinh" runat="server" Style="float: left; margin-right: 8px; padding-top: 5px" ClientInstanceName="chk_Ngaysinh" Visible="false">
                                                        <ClientSideEvents CheckedChanged="chk_NgaysinhChange" />
                                                    </dx:ASPxCheckBox>
                                                    <dx:ASPxDateEdit ID="deNgaysinh" Visible="false" UseMaskBehavior="true" AutoPostBack="false" onkeypress="return enter_deNgaysinh(event)" ClientInstanceName="deNgaysinh" Style="float: left; margin-right: 8px;" Width="120px" Height="25px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                    <dx:ASPxTextBox ID="txtNamsinh" runat="server" ClientInstanceName="txtnamsinh"  onkeypress="return enter_txtnamsinh(event)"  Style="float: left; margin-right: 8px;" Width="80px" Height="25px"></dx:ASPxTextBox> 
                                                    <%--                                                    <asp:TextBox ID="txtTuoi" runat="server" Width="30px" Style="float: left; margin-right: 7px" placeholder="Tuổi" CssClass="nano_textbox"></asp:TextBox>--%>
                                                    <dx:ASPxComboBox ClientInstanceName="ddlGioitinh" onkeypress="return enter_ddlGioitinh(event)" ID="ddlGioitinh" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="50px" runat="server" ValueType="System.String">
                                                        <Items>
                                                            <dx:ListEditItem Value="0" Selected="true" Text="Nữ" />
                                                            <dx:ListEditItem Value="1" Text="Nam" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                              <tr>
                                                 <td class="info_table_td"><dx:ASPxRadioButton ID="radkh"  ClientInstanceName="radkh" Text="Bệnh nhân" GroupName="gioithieu" runat="server">
                                                      <ClientSideEvents CheckedChanged="myfunction" />
                                                                           </dx:ASPxRadioButton></td>
                                                   <td class="info_table_td"> <dx:ASPxRadioButton ID="radnv"  ClientInstanceName="radnv" Text="Nhân viên" GroupName="gioithieu" runat="server">
                                                        <ClientSideEvents CheckedChanged="myfunction" />
                                                                              </dx:ASPxRadioButton></td>
                                                   <td class="info_table_td" ><dx:ASPxRadioButton ID="radnguon" ClientInstanceName="radnguon"  Text="Nguồn đến" GroupName="gioithieu" runat="server">
                                                            <ClientSideEvents CheckedChanged="myfunction" />
                                                        </dx:ASPxRadioButton>
                                                   </td>
                                             </tr>
                                            <tr>
                                                <td class="info_table_td">Địa chỉ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtDiachi" runat="server" ClientInstanceName="txtdiachi" onkeypress="return enter_txtDiachi(event)" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Người giới thiệu:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxCheckBox ID="chk_NGThieu" runat="server" Style="float: left; margin-right: 8px; padding-top: 5px" ClientInstanceName="chk_ngthieu">
                                                        <ClientSideEvents CheckedChanged="chk_NGThieuChange" />
                                                    </dx:ASPxCheckBox>
                                                    <dx:ASPxComboBox ID="cbo_Nguoigioithhieu" runat="server" OnCallback="cbo_Nguoigioithhieu_Callback" ClientInstanceName="cbo_nguoigioithieu" ValueField="uId_Khachhang" Width="177px"
                                                        TextFormatString="{0} - {1} - {2}" DropDownStyle="DropDown" ValueType="System.String" EnableCallbackMode="true" IncrementalFilteringMode="Contains">
                                
                                                        <ClientSideEvents SelectedIndexChanged="cbo_NGThieuChange" />
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Điện thoại:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtDienthoai" ClientInstanceName="txtdienthoai" runat="server" onkeypress="return enter_txtDienthoai(event)" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Email:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" onkeypress="return enter_txtEmail(event)" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Nghề nghiệp:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlNghenghiep" ClientInstanceName="ddlNghenghiep" onkeypress="return enter_ddlNghenghiep(event)"
                                                        DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith"
                                                        Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                    </dx:ASPxComboBox>
                                                </td>
                                               <td class="info_table_td">Bệnh sử:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtGhichu" onkeypress="return enter_txtGhichu(event)" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
              
                                            </tr>
                                            <tr>
                                                  <%--  <td class="info_table_td">Nguồn đến:
                                                </td>--%>
                                         
                                                    <dx:ASPxComboBox ID="ddlNguon" Visible="false" ClientInstanceName="ddlNguon" DropDownStyle="DropDown" onkeypress="return enter_ddlNguon(event)"
                                                        IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String">
                                                    </dx:ASPxComboBox>
                                               
                                                <td class="info_table_td">Chẩn đoán:
                                                </td>
                                                <td class="info_table_td" colspan="3">
                                               
                                                    <dx:ASPxMemo ID="txt_Danhgia" runat="server" Height="50px" ClientInstanceName="txt_Chandoan" Width="100%"></dx:ASPxMemo>
                                                </td>
                                            </tr>
                                            <tr>
                                            <%--       <td class="info_table_td">Nhân viên tư vấn:
                                                </td>--%>
                                                   <td class="info_table_td">
                                                       <dx:ASPxComboBox ID="cbo_nhanvientuvan" SelectedIndex="0" Visible="false" DropDownStyle="DropDown" ClientInstanceName="cbo_nhanvientuvan" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                             </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div id="diverror" class="error">
                                                        <dx:ASPxLabel ID="ltrError"  EncodeHtml="false" ClientInstanceName="ltrError" runat="server"></dx:ASPxLabel>
                                                        <dx:ASPxLabel ID="ltrSuccess" runat="server" EncodeHtml="false" ClientInstanceName="ltrSuccess"></dx:ASPxLabel>
                                                    </div>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btOK" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" OnClick="btOK_Click" runat="server" Text="Lưu (F4)" Style="float: left; margin-right: 15px">
                                                            <ClientSideEvents Click="CheckEmpty" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btaddbill" Image-Url="~/images/16x16/report_go.png" OnClick="btaddbill_Click" runat="server" Text="Thêm phiếu dịch vụ" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="Checkthemdv" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnaddproductbill" Image-Url="~/images/16x16/report_go.png" Visible="false" OnClick="btnaddproductbill_Click" runat="server" Text="Thêm đơn thuốc" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="Checkthempx" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClearText_Dev" />
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
                                       

                                    </div>
                                    <div>
                                        <asp:LinkButton ID="link_Taiexcl_Mau" runat="server" Text="Excel mẫu" OnClick="link_Taiexcl_Mau_Click1"></asp:LinkButton>
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
    <dx:ASPxPopupControl ID="PcBooklich" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcbooklich" Font-Size="25px"
        HeaderText="Đặt lịch cho bệnh nhân" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="600px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <fieldset class="field_tt" style="width: 97%; margin: auto auto 10px">
                                <legend><span style="font-weight: bold; color: green; font-size: 18px">Thông tin đặt lịch ngày </span>
                                    <dx:ASPxDateEdit ID="deNgaydatlich" runat="server" ClientInstanceName="dengaydatlich" EditFormatString="dd/MM/yyyy" EditFormat="Date"></dx:ASPxDateEdit>
                                </legend>
                                <table class="info_table">
                                    <tr>
                                        <td class="info_table_td">Tên bệnh nhân:</td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboKhachhang" runat="server" ClientInstanceName="cbokhachhang" IncrementalFilteringMode="Contains" AutoPostBack="false"
                                                ValueField="uId_Khachhang" ValueType="System.String" DropDownWidth="500px" TextFormatString="{1} - {2}">
                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã bệnh nhân" Width="20%" />
                                                    <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Tên bệnh nhân" Width="70%" />
                                                    <dx:ListBoxColumn FieldName="v_DienthoaiDD" Caption="Số điện thoại" Width="30%" />
                                                </Columns>
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { OnKhachhangChanged(s); }" />
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td class="info_table_td">Dịch vụ:</td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboDichvu" runat="server" ClientInstanceName="cbodichvu" AutoPostBack="false">
                                                <%--                            <ClientSideEvents EndCallback="OnEndCallback" />--%>
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="info_table_td">Phòng: </td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboPhong" runat="server" ClientInstanceName="cbophong" ValueField="uId_Phong" TextField="nv_Tenphong_vn"></dx:ASPxComboBox>
                                        </td>
                                        <td class="info_table_td">Giường:
                                        </td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboGiuong" runat="server" ClientInstanceName="cbogiuong" ValueField="uId_Giuong" TextField="nv_Tengiuong_vn"></dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="info_table_td">Bắt đầu: </td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboBatdau" runat="server" ClientInstanceName="cbobatdau" ValueField="uId_Khunggio" TextField="nv_Khunggio">
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td class="info_table_td">Kết thúc:
                                        </td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboKetthuc" runat="server" ClientInstanceName="cboketthuc" ValueField="uId_Khunggio" TextField="uId_Khunggio"></dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="info_table_td">Nhân viên chính: </td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboNhanvienchinh" runat="server" ClientInstanceName="cbonhanvienchinh" ValueField="uId_Nhanvien" TextField="nv_Hoten_vn"></dx:ASPxComboBox>
                                        </td>
                                        <td class="info_table_td">Nhân viên phụ:
                                        </td>
                                        <td class="info_table_td">
                                            <dx:ASPxComboBox ID="cboNhanvienphu" runat="server" ClientInstanceName="cbonhanvienphu" ValueField="uId_Nhanvien" TextField="nv_Hoten_vn"></dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="info_table_td">Ghi chú:</td>
                                        <td colspan="3" class="info_table_td">
                                            <dx:ASPxTextBox ID="txtGhichudatgiuong" runat="server" ClientInstanceName="txtghichu" Width="460px"></dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <div style="height: 30px">
                                <asp:Label ID="Label1" runat="server" CssClass="error" Font-Size="16px" Text=""></asp:Label>
                                <dx:ASPxButton ID="btnDatgiuong" Image-Url="~/images/btn_Save.png" runat="server" Text="Đặt lịch" AutoPostBack="false"
                                    Style="float: left; margin-right: 8px" ClientInstanceName="btndatgiuong">
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="ASPxButton2" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                    <ClientSideEvents Click="ClosePopupDatlich" />
                                </dx:ASPxButton>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDsKhachhangSearch" Font-Size="25px"
        HeaderText="Bệnh nhân " AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" Width="600px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <fieldset class="field_tt" style="width: 97%; margin: auto auto 10px">
                                <legend><span style="font-weight: bold; color: green; font-size: 18px">Thông tin đặt lịch ngày </span></legend>
                                <dx:ASPxGridView ID="GrvDanhsachsearch" ClientInstanceName="grvdanhsachsearch" AutoGenerateColumns="false" runat="server" KeyFieldName="uId_Khachhang"
                                    Width="100%">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Họ tên" FieldName="nv_Hoten_vn"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Điện thoại" FieldName="v_DienthoaiDD"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ngày sinh" FieldName="d_Ngaysinh"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <a id="popup" title="Chọn bệnh nhân" href='javascript:void(0)' onclick="return <%# String.Format("Chonkhachhang('{0}', '{1}')",Eval("uId_Khachhang"), Eval("v_DienthoaiDD")).ToString %>">
                                                    <img src="../../../images/bub.png" /></a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsText EmptyDataRow="Đây là bệnh nhân mới!" />
                                </dx:ASPxGridView>
                            </fieldset>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcCapthe"
        HeaderText="Kích hoạt thẻ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcCapthe.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                <dx:ASPxPanel ID="ASPxPanel7" runat="server" Width="900px" Height="380px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent8" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green"> Tìm kiếm thông tin thẻ </span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td"> 
                                                    Nhập mã thẻ :
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox runat="server" ID="txt_Mathe" Width="200px"></dx:ASPxTextBox>
                                                </td>
                                                <td char="info_table_td">
                                                    <dx:ASPxButton runat="server" ID="btn_Search_The" OnClick="btn_Search_The_Click" Image-Url="~/images/16x16/filter.png" Text="Tìm kiếm"></dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                              <dx:ASPxGridView ID="dgvDsTheTT" runat="server" ClientInstanceName="client_dgvDsTheTT"
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
                                        HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" Width="130px" FieldName="b_Kichhoat"
                                        Name="b_Kichhoat">
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate >
                                            <a id="popup" title="Kích hoạt thẻ" href='javascript:void(0)' onclick="return <%# String.Format("Unlock_Account('{0}','{1}')", Eval("uId_Khachhang_Goidichvu"), Eval("b_Kichhoat")).ToString%>">
                                                <img src="../../../images/bub.png" />
                                            </a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="10">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                                <SettingsText EmptyDataRow="Không có thẻ thanh toán!" />
                             </dx:ASPxGridView>
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
    <dx:ASPxGridViewExporter ID="dgvexport" GridViewID="dgvDevexpress" runat="server"></dx:ASPxGridViewExporter>
</asp:Content>

