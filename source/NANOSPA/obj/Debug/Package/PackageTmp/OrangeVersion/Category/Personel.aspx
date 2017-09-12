<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Personel.aspx.vb" Inherits="NANO_SPA.Personel" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'f3a3f69c-e022-4e61-b82e-7d7d9b4c870a'}";
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
        function grid_EndCallback(s, e) {

            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }
        }
        function ShowEditWindow() {           
            var txt_Manhanvien = document.getElementById("<%=txt_Manhanvien.ClientID%>");
            document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroChucvu.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgaysinh.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgayvao.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroTennhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_tinhtrang.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = ""
            pcAddNhanvien.Show();
            txt_Manhanvien.focus();
        }

        function Phanquyen() {
            var tabpage = Apcmain.GetTabByName(Phanquyen);
            Apcmain.SetActiveTab(1);
        }

         function ShowAddWindow() {
             pcAddNhanvien.Show();
             ClearText();
             var txt_Manhanvien = document.getElementById("<%=txt_Manhanvien.ClientID%>");
            txt_Manhanvien.focus();
            document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroChucvu.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgaysinh.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgayvao.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroTennhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_tinhtrang.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = ""
        }
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                client_grid.GetRowValues(e.visibleIndex, 'uId_Nhanvien;', OnGridSelectionComplete);
            }
        }
        function ClosePopup(s, e) {
            pcAddNhanvien.Hide();
            client_grid.Refresh();
        }
        function OnGridSelectionComplete(values) {
            //Gan gia tri cho hidden field uId khachhang de sua thong tin khach hoac lam gi do
            var hdfuIdNhanvien = document.getElementById("<%=hdfuIdNhanvien.ClientID%>");
            hdfuIdNhanvien.value = values[0];
            var param_dt = "{'uId_Nhanvien':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/loadNhanvien";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCallNhanvien,
                error: onFail
            });
            //Create  1 session uId_Dichvu_cd
            //jo_CreateSession("uId_Dichvu_cd", values[0]);
            //clientgrid_congdoan.Refresh();
        }
        function OnSuccessCallNhanvien(msg) {
            if (msg.d != "") {
                document.getElementById('<%=lbl_.ClientID%>').innerHTML = ""
                var defaultdata = msg.d.split("$")
                var txt_Manhanvien = document.getElementById('<%=txt_Manhanvien.ClientID%>');
                var txt_Tennhanvien = document.getElementById('<%=txt_Tennhanvien.ClientID%>');
                var txt_Diachi = document.getElementById('<%=txt_Diachi.ClientID%>');
                var txt_Dienthoai = document.getElementById("<%=txt_Dienthoai.ClientID%>");
                var txt_Email = document.getElementById('<%=txt_Email.ClientID%>');
                var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
                var txt_Pass = document.getElementById('<%=txt_Pass.ClientID%>');
                var chk_Taikhoan = document.getElementById('<%=chk_Taikhoan.ClientID%>');
                var txt_image = document.getElementById('<%=txt_image.ClientID%>');
                var img_NhanV = document.getElementById('<%=img_NhanV.ClientID%>');
                var Motaikhoan = document.getElementById("divmotaikhoan")
                txt_Manhanvien.value = defaultdata[1];
                txt_Tennhanvien.value = defaultdata[2];
                //txt_Chucvu.value = defaultdata[3];
                pcbo_Chucvu.SetText(defaultdata[3]);
                txt_Diachi.value = defaultdata[5];
                date_Ngaylam.SetDate(new Date(defaultdata[6]));
                date_Ngaysinh.SetDate(new Date(defaultdata[4]));
                txt_Dienthoai.value = defaultdata[7];
                if (defaultdata[8] == "True") {
                    pcbo_Tinhtrang.SetValue("1");
                }
                else
                    pcbo_Tinhtrang.SetValue("0");
                txt_Email.value = defaultdata[9];

                if (defaultdata[10] != "" || defaultdata[11] != "") {
                    txt_Login.value = defaultdata[10];
                    txt_Pass.value = defaultdata[11];
                    chk_Motaikhoan.SetChecked(true);
                    Motaikhoan.style.display = "block";
                }
                else {
                    chk_Motaikhoan.SetChecked(false);
                    Motaikhoan.style.display = "None";
                    txt_Login.value = "";
                    txt_Pass.value = "";
                    chk_Motaikhoan.SetChecked(false);
                }
                if (defaultdata[12] == "True") {
                    chk_Taikhoan.checked = true;
                }
                else
                    chk_Taikhoan.checked = false;
                if (defaultdata[13] != "" || defaultdata[13] != null) {
                    img_NhanV.src = defaultdata[13];
                    txt_image.value = defaultdata[13];
                }
                else {
                    img_NhanV.src = "";
                    txt_image.value = "";
                }
                document.getElementById('<%=lbl_.ClientID%>').innerHTML = "";
                pcAddNhanvien.Show();
            }
        }
        function onFail(ex) {
            alert(ex._message + " fail");
            return false;
        }
        function Upload() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                document.getElementById('<%=img_NhanV.ClientID%>').src = fileUrl;
                document.getElementById('<%=txt_image.ClientID%>').value = fileUrl
            };
            finder.popup();
        }
        function DeleteImage() {
            document.getElementById('<%=img_NhanV.ClientID%>').src = "";
            document.getElementById('<%=txt_image.ClientID%>').value = "";
        }
        function ClearText() {
            var hdfuIdNhanvien = document.getElementById("<%=hdfuIdNhanvien.ClientID%>");
            hdfuIdNhanvien.value = "";
            document.getElementById('<%=lbl_.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroChucvu.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgaysinh.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgayvao.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroTennhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_tinhtrang.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = ""
            var txt_Manhanvien = document.getElementById('<%=txt_Manhanvien.ClientID%>');
            var txt_Tennhanvien = document.getElementById('<%=txt_Tennhanvien.ClientID%>');
            var txt_Diachi = document.getElementById('<%=txt_Diachi.ClientID%>');
            var txt_Dienthoai = document.getElementById("<%=txt_Dienthoai.ClientID%>");
            var txt_Email = document.getElementById('<%=txt_Email.ClientID%>');
            var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
            var txt_Pass = document.getElementById('<%=txt_pass.ClientID%>');
            var chk_Taikhoan = document.getElementById('<%=chk_Taikhoan.ClientID%>');
            var txt_image = document.getElementById('<%=txt_image.ClientID%>');
            var img_NhanV = document.getElementById('<%=img_NhanV.ClientID%>');
            txt_Tennhanvien.value = "";
            txt_Diachi.value = "";
            txt_Dienthoai.value = "";
            txt_Email.value = "";
            txt_image.value = "";
            txt_Manhanvien.value = "";
            txt_Pass.value = "";
            txt_Login.value = "";
            img_NhanV.url = "";
            txt_image = "";
            pcbo_Tinhtrang.SetValue("1");
            date_Ngaylam.SetDate(new Date(Date.now()));
            pcbo_Chucvu.SetText("Nhân viên")
            chk_Taikhoan.checked = true;
            cbo_Loai.SetText=("Nhân viên khác")

        }
        function ClearText_Dev(s, e) {
            ClearText();
        }
        function CheckEmpty(s, e) {
            document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroChucvu.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgaysinh.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroNgayvao.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_ErroTennhanvien.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_tinhtrang.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = ""
            document.getElementById('<%=lbl_.ClientID%>').innerHTML = ""
            var txt_Manhanvien = document.getElementById('<%=txt_Manhanvien.ClientID%>');
            var txt_Tennhanvien = document.getElementById('<%=txt_Tennhanvien.ClientID%>');
            var txt_Diachi = document.getElementById('<%=txt_Diachi.ClientID%>');
            var txt_Dienthoai = document.getElementById("<%=txt_Dienthoai.ClientID%>");
            var txt_Email = document.getElementById('<%=txt_Email.ClientID%>');
            var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
            var txt_pass = document.getElementById('<%=txt_pass.ClientID%>');
            var chk_Taikhoan = document.getElementById('<%=chk_Taikhoan.ClientID%>');
            var txt_image = document.getElementById('<%=txt_image.ClientID%>');
            var img_NhanV = document.getElementById('<%=img_NhanV.ClientID%>');
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            var currentTime = new Date();
            var year = currentTime.getFullYear();
            if (txt_Manhanvien.value == "") {
                txt_Manhanvien.focus();
                document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = "!";
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Mã nhân viên không được để trống";
                e.processOnServer = false;
            }
            else if (txt_Tennhanvien.value == "") {
                txt_Tennhanvien.focus();
                document.getElementById('<%=lbl_ErroTennhanvien.ClientID%>').innerHTML = "!";
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Tên nhân viên không được để trống";
                e.processOnServer = false;
            }
            else if (pcbo_Chucvu.value == "") {
                txt_Chucvu.focus();
                document.getElementById('<%=lbl_ErroChucvu.ClientID%>').innerHTML = "!";
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Nhân viên phải có chức vụ cụ thể";
                e.processOnServer = false;
            }
            else if (txt_Dienthoai.value != "") {
                if (isNaN(txt_Dienthoai.value)) {
                    txt_Dienthoai.value = "";
                    txt_Dienthoai.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Số điện thoại chỉ được phép nhập số";

                    e.processOnServer = false;
                }
            }
            else if (year - parseInt(date_Ngaysinh.GetText().split("/")[2]) < 18) {
                document.getElementById('<%=lbl_ErroNgaysinh.ClientID%>').innerHTML = "!";
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chưa đủ tuổi đi làm. Phải sinh từ năm " + (year - 18);
                date_Ngaysinh.Focus();
                date_Ngaysinh.ShowDropDown();
                e.processOnServer = false;
            }
            else if (txt_Email.value != "") {
                if (reg.test(txt_Email.value) == false) {
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Định dạng Email không đúng";
                    txt_Email.value = "";
                    txt_Email.focus();
                    e.processOnServer = false;
                }
            }
    var Motaihoan = document.getElementById("divmotaikhoan");
    var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
    if (chk_Motaikhoan.GetChecked() == true) {
        Motaihoan.style.display = "block";
        txt_Login.focus();
    }
    else {
        Motaihoan.style.display = "None";
    }
}

//enter key
function enter_Manhanvien(e) {
    if (e.keyCode == 13) {
        var reg = /^([A-Za-z0-9])/
        var txt_Manhanvien = document.getElementById('<%=txt_Manhanvien.ClientID%>');
        var txt_Tennhanvien = document.getElementById('<%=txt_Tennhanvien.ClientID%>')
        document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "";
        document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = "";
        if (txt_Manhanvien.value == "") {
            txt_Manhanvien.focus();
            document.getElementById('<%=lbl_ErroManhanvien.ClientID%>').innerHTML = "!";
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Mã khách hàng không thể trống";
                }
                else if (reg.test(txt_Manhanvien.value) == false) {
                    txt_Manhanvien.value = "";
                    txt_Manhanvien.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Mã nhân viên chỉ được viết liền không dấu chữ thường, chữ in và số";
        } else
            txt_Tennhanvien.focus();
    return false;
}
}
function enter_Tennhanvien(e) {
    if (e.keyCode == 13) {
        var txt_Tennhanvien = document.getElementById('<%=txt_Tennhanvien.ClientID%>');
        var txt_Diachi = document.getElementById('<%=txt_Diachi.ClientID%>');
        if (txt_Tennhanvien.value == "") {
            txt_Tennhanvien.value = "";
            txt_Tennhanvien.focus();
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Tên nhân viên không được để trống";
        }
        else
            txt_Diachi.focus();
        return false;
    }
}
function enter_Diachi(e) {
    if (e.keyCode == 13) {
        var txt_Dienthoai = document.getElementById('<%=txt_Dienthoai.ClientID%>');
        txt_Dienthoai.focus();
        return false;
    }
}
function enter_Dienthoai(e) {
    if (e.keyCode == 13) {
        var txt_Dienthoai = document.getElementById('<%=txt_Dienthoai.ClientID%>');
        var txt_Email = document.getElementById('<%=txt_Email.ClientID%>');
        if (txt_Dienthoai.value != "") {
            if (isNaN(txt_Dienthoai.value)) {
                txt_Dienthoai.value = "";
                txt_Dienthoai.focus();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số";
            }
            else
                txt_Email.focus();
        }
        else
            txt_Email.focus();
        return false;
    }
}
function enter_Email(e) {
    if (e.keyCode == 13) {
        var txt_Email = document.getElementById('<%=txt_Email.ClientID%>');
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        if (txt_Email.value != "") {
            if (reg.test(txt_Email.value) == false) {
                txt_Email.value = "";
                txt_Email.focus();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Định dạng Email không đúng";
            }
            else {
                pcbo_Tinhtrang.Focus();
                pcbo_Tinhtrang.ShowDropDown();
            }
        }
        else {
            pcbo_Tinhtrang.Focus();
            pcbo_Tinhtrang.ShowDropDown();
        }
        return false;
    }
}
function enter_Tinhtrang(e) {
    if (e.keyCode == 13) {
        cbo_Loai.Focus();
       
        return false;
    }
}
function enter_Loai(e) {
    if (e.keyCode == 13) {
        pcbo_Chucvu.Focus();
        pcbo_Chucvu.ShowDropDown();
        return false;
    }
}
function enter_Chucvu(e) {
    if (e.keyCode == 13) {
        if (pcbo_Chucvu.value == "") {
            pcbo_Chucvu.Focus();
            pcbo_Chucvu.ShowDropDown();
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chức vụ không thể để trống";
            document.getElementById('<%=lbl_ErroChucvu.ClientID%>').innerHTML = "!";
        }
        else {
            date_Ngaysinh.Focus();
            date_Ngaysinh.ShowDropDown();
        }
        return false;
    }
}
function enter_Ngaysinh(e) {
    if (e.keyCode == 13) {
        var currentTime = new Date();
        var year = currentTime.getFullYear();
        var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
        if (year - parseInt(date_Ngaysinh.GetText().split("/")[2]) < 18) {
            date_Ngaysinh.Focus();
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chưa đủ tuổi đi làm";
                    document.getElementById('<%=lbl_ErroNgaysinh.ClientID%>').innerHTML = "!";
                }
                else
                    date_Ngaylam.Focus();
                date_Ngaylam.ShowDropDown();
                return false;
            }
        }
        function enter_Ngayvaolam(e) {
            if (e.keyCode == 13) {
                if (chk_Motaikhoan.GetChecked() == true) {
                    var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
                    txt_Login.focus();
                    return false;
                }
                else {
                    var btOK = document.getElementById('<%=btOK.ClientID%>');
                    btOK.click();
                    return false;
                }
            }
        }
        function enter_Login(e) {
            if (e.keyCode == 13) {
                var txt_Pass = document.getElementById('<%=txt_Pass.ClientID%>');
                txt_Pass.focus();
                return false;
            }
        }
        function enter_Pass(e) {
            if (e.keyCode == 13) {
                var btOK = document.getElementById('<%=btOK.ClientID%>');
                btOK.click();
                return false;
            }
        }
        //thay doi khi click checkbox tai khoan dang nhap
        function check_Motaikhoanchang(s, e) {
            var Motaihoan = document.getElementById("divmotaikhoan");
            var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
            if (chk_Motaikhoan.GetChecked() == true) {
                Motaihoan.style.display = "block";
                txt_Login.focus();
                return false;
            }
            else {
                Motaihoan.style.display = "None";
                return false;
            }
        }
        function popupStyle(s, e) {
            ASPxClientEdit.ClearGroup('entryGroup');
            pcAddNhanvien.Focus();
            var Motaihoan = document.getElementById("divmotaikhoan");
            var txt_Login = document.getElementById('<%=txt_Login.ClientID%>');
            if (chk_Motaikhoan.GetChecked() == true) {
                Motaihoan.style.display = "block";
                txt_Login.focus();
                return false;
            }
            else {
                Motaihoan.style.display = "None";
                return false;
            }
        }
        function selectNhanvien(s, e) {
            Grid_client.Refresh();
        }
        function btnKichhoatClick(event) {
            focusedItemId = event.currentTarget.id;
            var data = focusedItemId.split("$");

            var uId_Nhanvien = cbonhanvien.GetValue();
            if (data[1] == "False") {
                var param_dt = "{'uid_chucnang':'" + data[0] + "','uid_nhanvien':'" + uId_Nhanvien + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/InertPhanquyen";
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
            else {
                var param_dt = "{'uid_chucnang':'" + data[0] + "','uid_nhanvien':'" + uId_Nhanvien + "'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/DeletePhanquyen";
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
        }
        function OnSuccessCall(msg) {
            if (msg != "") {
                Grid_client.Refresh();
                var data = msg.d.split("$");
            }
        }
        function btnThemtatcaClick(s, e) {
            var hdfuIdNv = cbonhanvien.GetValue()
            var param_dt = "{'uid_nhanvien':'" + hdfuIdNv + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertAllPhanquyen";
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

        function btnxoatatcaClick(s, e) {
            var hdfuIdNv = cbonhanvien.GetValue()
            var param_dt = "{'uid_nhanvien':'" + hdfuIdNv + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/DeleteAllPhanquyen";
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
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ NHÂN VIÊN</p>
    </div>
    <div style="clear: both"></div>
    <dx:ASPxPageControl ID="ApcMain" runat="server" Width="100%" ClientInstanceName="Apcmain">
        <TabPages>
            <dx:TabPage Text="Danh sách nhân viên">
                <ContentCollection>
                    <dx:ContentControl>
                        <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
                            <legend><span style="font-weight: bold; color: green;">Tính năng</span></legend>
                            <ul>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btnThemmoi" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                                        runat="server" Text="Thêm mới (F2)">
                                        <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                                    </dx:ASPxButton>
                                </li>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btnExportExcel" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false" Image-Url="~/images/Excel-icon.png"
                                        runat="server" Text="Xuất Excel">
                                    </dx:ASPxButton>
                                </li>
                            </ul>
                        </fieldset>
                        <fieldset class="field" style="width: 98%; height: auto; margin: auto">
                            <legend><span style="font-weight: bold; color: green;">Thông tin nhân viên</span></legend>
                            <dx:ASPxGridView ID="Grid_Nhanvien" KeyFieldName="uId_Nhanvien" ClientInstanceName="client_grid" AutoGenerateColumns="false" runat="server"
                                SettingsPager-PageSize="17" OnRowDeleting="Grid_Nhanvien_RowDeleting">
                                <Columns>
                                    <dx:GridViewDataColumn FieldName="uId_Nhanvien" Visible="false" VisibleIndex="-1" Name="uId_Nhanvien">
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Mã nhân viên" HeaderStyle-HorizontalAlign="Center" FieldName="v_Manhanvien" VisibleIndex="1"
                                        Settings-AutoFilterCondition="Contains" Visible="true" Name="v_Manhanvien" Width="100px">
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Tên Nhân viên" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn" VisibleIndex="2"
                                        Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Hoten_vn" Width="250px">
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Ngày sinh" Visible="true" VisibleIndex="3" FieldName="d_Ngaysinh"
                                        Settings-AutoFilterCondition="Contains" Width="150px" Name="d_Ngaysinh" HeaderStyle-HorizontalAlign="Center">
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Chức vụ" Visible="true" VisibleIndex="4" FieldName="nv_Chucvu_vn"
                                        Settings-AutoFilterCondition="Contains" Width="150px" Name="nv_Chucvu_vn" HeaderStyle-HorizontalAlign="Center">
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Địa chỉ" Visible="true" VisibleIndex="4" FieldName="nv_Diachi_vn"
                                        Settings-AutoFilterCondition="Contains" Width="300px" Name="nv_Diachi_vn" HeaderStyle-HorizontalAlign="Center">
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Số điện thoại" Visible="true" VisibleIndex="4" FieldName="v_Dienthoai"
                                        Settings-AutoFilterCondition="Contains" Width="150px" Name="v_Dienthoai" HeaderStyle-HorizontalAlign="Center">
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Width="50px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Caption="Sửa" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Thông tin Nhân viên" href='javascript:void(0)' onclick="return ShowEditWindow()">
                                                <img src="../../../images/btn_Edit.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Width="50px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Caption="Phân quyền" CellStyle-HorizontalAlign="Center" Visible="false">
                                        <DataItemTemplate>
                                            <a id="popup" title="Phân quyền nhân viên" href='javascript:void(0)' onclick="return Phanquyen()">
                                                <img src="" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="6" Width="50" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                            <Image Url="~/images/btn_Delete.png"></Image>
                                        </DeleteButton>
                                    </dx:GridViewCommandColumn>
                                </Columns>
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
                                                                            <td style="font-weight: bold">Ngày vào làm :</td>
                                                                            <td><%# Eval("d_Ngayvaolam")%>  </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Địa chỉ Email </td>
                                                                            <td><%# Eval("v_Email")%> </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Tình trạng công việc: </td>
                                                                            <td><%#If(Eval("b_Danglamviec") = True, "Đang làm việc", "Đã nghỉ việc")%></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div class="Div_Grid" style="width: 40%; float: right; padding: 5px; margin-right: 130px">
                                                                    <table cellpadding="2" cellspacing="3" style="border-collapse: collapse; width: 100%">
                                                                        <tr style="width: 200px;">
                                                                            <td style="font-weight: bold">Tên đăng nhập: </td>
                                                                            <td><%# Eval("v_Tendangnhap")%>  </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Mật khẩu: </td>
                                                                            <td><%# Eval("v_Matkhau")%> </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Tình trạng tài khoản: </td>
                                                                            <td><%#If(Eval("b_ActiveLogin") = True, "Được kích hoạt", "Chưa kích hoạt")%></td>
                                                                        </tr>
                                                                        <tr>
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
                                <SettingsDetail ShowDetailRow="true" />
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="15">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                            </dx:ASPxGridView>
                            <dx:ASPxGridViewExporter ID="Export_Pesonel" runat="server"></dx:ASPxGridViewExporter>
                        </fieldset>
                        <asp:HiddenField ID="hdfuIdNhanvien" Value="" runat="server" />
                        <dx:ASPxPopupControl ID="pcAddNhanvien" runat="server" CloseAction="CloseButton" Modal="True"
                            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddNhanvien" Font-Size="25px"
                            HeaderText="Nhân viên" AllowDrgging="True" PopupAnimationType="None" OnWindowCallback="pcAddNhanvien_WindowCallback">
                            <ClientSideEvents PopUp="popupStyle" />
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                                    <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="750px" Height="440px" Font-Size="12px">
                                        <PanelCollection>
                                            <dx:PanelContent ID="PanelContent2" runat="server" Width="400px">
                                                <asp:UpdatePanel ID="upNhanvien" runat="server">
                                                    <ContentTemplate>
                                                        <fieldset class="field_tt" style="width: 720px; height: auto; margin: auto">
                                                            <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                                            <div class="thongtin" style="width: 729px; height: 345px">
                                                                <fieldset class="field_tt" style="width: 706px; margin: auto">
                                                                    <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Thông tin nhân viên</span></legend>
                                                                    <table class="info_table" style="font-size: 14px; margin: auto">
                                                                        <tr>
                                                                            <td class="info_table_td" style="font-size: 14px">Mã nhân viên<a style="color: red">*</a> : </td>
                                                                            <td class="info_table_td">
                                                                                <asp:TextBox CssClass="nano_textbox" ID="txt_Manhanvien" runat="server" Width="180px" onkeypress="return enter_Manhanvien(event)"></asp:TextBox>
                                                                                <asp:Label ID="lbl_ErroManhanvien" runat="server" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                            <td class="info_table_td" style="font-size: 14px; width: 100px">Chức vụ<a style="color: red">*</a> :  </td>
                                                                            <td class="info_table_td">
                                                                                <dx:ASPxComboBox ID="pcbo_Chucvu" runat="server" DropDownStyle="DropDownList" Width="180px" ClientInstanceName="pcbo_Chucvu" onkeypress="return enter_Chucvu(event)">
                                                                                </dx:ASPxComboBox>
                                                                                <asp:Label ID="lbl_ErroChucvu" runat="server" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="info_table_td">Tên Nhân viên<a style="color: red">*</a> : </td>
                                                                            <td class="info_table_td">
                                                                                <asp:TextBox CssClass="nano_textbox" ID="txt_Tennhanvien" runat="server" Width="180px" onkeypress="return enter_Tennhanvien(event)"></asp:TextBox>
                                                                                <asp:Label ID="lbl_ErroTennhanvien" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                            </td>

                                                                            <td class="info_table_td">Ngày sinh<a style="color: red">*</a> : </td>
                                                                            <td class="info_table_td" style="height: 26px; width: 200px">
                                                                                <dx:ASPxDateEdit ID="date_Ngaysinh" runat="server" EditFormatString="dd/MM/yyyy" EditFormat="Custom" Width="180px"
                                                                                    ClientInstanceName="date_Ngaysinh" UseMaskBehavior="true" CssClass="floatleft" onkeypress="return enter_Ngaysinh(event)">
                                                                                </dx:ASPxDateEdit>
                                                                                <asp:Label ID="lbl_ErroNgaysinh" runat="server" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="info_table_td">Địa chỉ: </td>
                                                                            <td class="info_table_td" style="width: 200px">
                                                                                <asp:TextBox CssClass="nano_textbox" ID="txt_Diachi" runat="server" Width="180px" onkeypress="return enter_Diachi(event)"></asp:TextBox>
                                                                            </td>
                                                                            <td class="info_table_td">Ngày vào làm<a style="color: red">*</a> : </td>
                                                                            <td class="info_table_td">
                                                                                <dx:ASPxDateEdit ID="date_Ngaylam" runat="server" UseMaskBehavior="true" ClientInstanceName="date_Ngaylam" EditFormatString="dd/MM/yyyy" EditFormat="Custom" Width="180px" onkeypress="return enter_Ngayvaolam(event)">
                                                                                    <CalendarProperties Columns="1">
                                                                                    </CalendarProperties>
                                                                                    <ValidationSettings ErrorDisplayMode="Text" Display="Dynamic">
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </dx:ASPxDateEdit>
                                                                                <asp:Label ID="lbl_ErroNgayvao" runat="server" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="info_table_td">Điện thoại:</td>
                                                                            <td class="info_table_td">
                                                                                <asp:TextBox CssClass="nano_textbox" ID="txt_Dienthoai" runat="server" Width="180px" placeholder="Chính xác số điện thoại" onkeypress="return enter_Dienthoai(event)"></asp:TextBox>
                                                                            </td>
                                                                            <td class="info_table_td">
                                                                                <div>
                                                                                    <asp:HyperLink ID="asplink" runat="server" Text="Đổi ảnh" onclick="javascript: Upload()">
                                                                                    </asp:HyperLink>
                                                                                </div>
                                                                            </td>
                                                                            <td rowspan="3">
                                                                                <div style="height: 100px; width: 100px">
                                                                                    <asp:Image ID="img_NhanV" Width="100px" Height="100px" runat="server"></asp:Image>
                                                                                </div>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="info_table_td">Địa chỉ Email: </td>
                                                                            <td class="info_table_td">
                                                                                <asp:TextBox CssClass="nano_textbox" ID="txt_Email" runat="server" Width="180px" placeholder="" Visible="true" onkeypress="return enter_Email(event)"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <div style="padding-left: 4px">
                                                                                    <asp:HyperLink ID="asplink_xoaanh" runat="server" Text="Xóa ảnh" onclick="javascript: DeleteImage()">
                                                                                    </asp:HyperLink>
                                                                                </div>
                                                                            </td>
                                                                            <td class="info_table_td">
                                                                                <asp:TextBox ID="txt_image" runat="server" CssClass="bigtext" Width="0px" Height="0px" BorderStyle="None"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="info_table_td">Tình trạng <a style="color: red">*</a> : </td>
                                                                            <td class="info_table_td">
                                                                                <dx:ASPxComboBox ID="pcbo_Tinhtrang" runat="server" Width="180px" DropDownStyle="DropDownList" ClientInstanceName="pcbo_Tinhtrang" onkeypress="return enter_Tinhtrang(event)">
                                                                                </dx:ASPxComboBox>
                                                                                <asp:Label ID="lbl_tinhtrang" runat="server" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="info_table_td">Loại :</td>
                                                                            <td class="info_table_td">
                                                                                <dx:ASPxComboBox ID="cbo_Loai" AutoPostBack="false" Width="180px" ClientInstanceName="cbo_Loai" runat="server" ValueType="System.String" onkeypress="return enter_Loai(event)"></dx:ASPxComboBox>
                                                                            </td>
                                                                            <td char="info_table_td">Bộ phận :</td>
                                                                            <td class="info_table_td">
                                                                                <dx:ASPxComboBox ID="cb_Bophan" AutoPostBack="false" DropDownStyle="DropDownList" SelectedIndex="0" Width="180px" ClientInstanceName="cb_Bophan" runat="server"></dx:ASPxComboBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </fieldset>
                                                                <fieldset class="fied_tt" style="width: 706px; float: left">
                                                                    <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">
                                                                        <dx:ASPxCheckBox ID="chk_Motaikhoan" runat="server" ClientInstanceName="chk_Motaikhoan">
                                                                            <ClientSideEvents CheckedChanged="check_Motaikhoanchang" />
                                                                        </dx:ASPxCheckBox>
                                                                        Tài khoản hệ thống</span></legend>
                                                                    <div class="div_Motaikhoan" id="divmotaikhoan">
                                                                        <table class="info_table" style="font-size: 14px">
                                                                            <tr style="width: 600px">
                                                                                <td class="info_table_td" style="width: 130px">Tên đăng nhập: 
                                                                                </td>
                                                                                <td class="info_table_td" style="width: 200px">
                                                                                    <asp:TextBox ID="txt_Login" runat="server" Width="180px" onkeypress="return enter_Login(event)"></asp:TextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="width: 100px">Mật khẩu :
                                                                                </td>
                                                                                <td class="info_table_td" style="width: 200px">
                                                                                    <asp:TextBox ID="txt_Pass" runat="server" Width="200px" onkeypress="return enter_Pass(event)"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td">Kích hoạt tài khoản</td>
                                                                                <td class="info_table_td">
                                                                                    <asp:CheckBox ID="chk_Taikhoan" runat="server" Width="200px" />
                                                                                </td>
                                                                                <td class="info_table_td" colspan="2"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                            <div style="height: 20px">
                                                                <asp:Label ID="lbl_error" runat="server" CssClass="error"></asp:Label>
                                                            </div>
                                                            <div class="pcmButton" style="width: 400px; height: 40px; float: left">
                                                                <dx:ASPxButton ID="btOK" Image-Url="~/images/btn_Save.png" runat="server" Text="Lưu (F4)" AutoPostBack="false"
                                                                    Style="float: left; margin-right: 8px" ClientInstanceName="btOK" OnClick="btOK_Click1">
                                                                    <ClientSideEvents Click="CheckEmpty" />
                                                                </dx:ASPxButton>
                                                                <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                                                    <ClientSideEvents Click="ClearText_Dev" />
                                                                </dx:ASPxButton>
                                                                <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                                                    <ClientSideEvents Click="ClosePopup" />
                                                                </dx:ASPxButton>
                                                            </div>
                                                            <div style="float: right; padding-right: 78px">
                                                                <asp:Label ID="lbl_" runat="server" Width="250px" Height="47px" Font-Size="Medium" Font-Bold="true" ForeColor="Red" CssClass="lbl_Thongbao"></asp:Label>
                                                            </div>
                                                            <div style="float: left">
                                                                <asp:Label ID="lbl_Ghichu" runat="server" CssClass="error" Text="Mục * là bắt buộc nhập dữ liệu"></asp:Label>
                                                            </div>
                                                            </caption>
                                                        </fieldset>
                                                        <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="upNhanvien" DisplayAfter="0" DynamicLayout="false">
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
        <TabPages>
            <dx:TabPage Text="Phân quyền" Name="Phanquyen">
                <ContentCollection>
                    <dx:ContentControl>
                        <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
                            <legend><span style="font-weight: bold; color: green;">Tính năng</span></legend>
                            <ul>
                                <li class="text_title">Nhân viên: </li>
                                <li class="text_title">
                                    <dx:ASPxComboBox ID="cboNhanvien" runat="server" ClientInstanceName="cbonhanvien" AutoPostBack="false">
                                        <ClientSideEvents SelectedIndexChanged="selectNhanvien" />
                                    </dx:ASPxComboBox>
                                </li>
                                <li class="text_title">
                                    <dx:ASPxLabel ID="lblThongbao" runat="server" ClientInstanceName="lblthongbao" Text="" Visible="false"></dx:ASPxLabel>
                                </li>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btnThemtatca" runat="server" ClientInstanceName="btnthemtatca" Text="Thêm tất cả" AutoPostBack="false">
                                        <ClientSideEvents Click="btnThemtatcaClick" />
                                    </dx:ASPxButton>
                                </li>
                                <li class="text_title">
                                    <dx:ASPxButton runat="server" ID="btnXoatatca" ClientInstanceName="btnxoatatca" Text="Xóa tất cả" AutoPostBack="false">
                                        <ClientSideEvents Click="btnxoatatcaClick" />
                                    </dx:ASPxButton>
                                </li>
                            </ul>
                        </fieldset>
                        <asp:HiddenField ID="hdfChucnang" runat="server" />
                        <fieldset class="field_tt" style="width: 99%; height: auto; margin: auto">
                            <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Quyền hạn</span></legend>
                            <div style="float: left; width: 98%">
                                <dx:ASPxGridView ID="Grid_Chucnang" runat="server" KeyFieldName="uId_Chucnang" AutoGenerateColumns="false" Width="100%"
                                    ClientInstanceName="Grid_client" SettingsText-GroupContinuedOnNextPage="(=>Trang sau)">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="uId_Chucnang" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="Check_Active" Caption="Kích hoạt" VisibleIndex="-1" Visible="false" CellStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center" Width="100px" >
                                        </dx:GridViewDataCheckColumn>
                                        <%--                                                <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center">
                                                </dx:GridViewCommandColumn>--%>
                                        <dx:GridViewDataTextColumn FieldName="nv_Tenchucnang_vn" Caption="Chức năng" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Nhóm chức năng" FieldName="nv_Tenphanhe_vn" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Width="100px" Caption="Kích hoạt" VisibleIndex="3">
                                            <DataItemTemplate>
                                                <div id='<%#Eval("uId_Chucnang").ToString + "$" + Eval("Check_Active").ToString%>' onclick=" return btnKichhoatClick(event)"
                                                    style='width: 20px; height: 20px; border: solid; background-position: center center; background-repeat: no-repeat; background-image: url(<%#If(Eval("Check_Active") = "1", "/images/icon_Ok.png", "/images/cancel.png")%>)'>
                                                </div>
                                            </DataItemTemplate>
                                            <%--<%#If(Eval("Check_Active") = 1, "images/Ok-icon.png", "images/cancel.png")%>--%>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsEditing Mode="Inline" />
                                    <SettingsPager PageSize="10" NumericButtonCount="4" Summary-Text="Trang {0}/{1} ({2} Chức năng)"></SettingsPager>
                                    <SettingsBehavior ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                    <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" />
                                    <Styles>
                                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                        </AlternatingRow>
                                        <GroupRow Font-Bold="true">
                                        </GroupRow>
                                    </Styles>
                                    <ClientSideEvents EndCallback="grid_EndCallback" />
                                </dx:ASPxGridView>
                            </div>

                            <%--  <div style="float: right; width: 53%">
                                        <dx:ASPxGridView ID="Grid_Chucnang_Nhanvien" runat="server" KeyFieldName="uId_Chucnang" AutoGenerateColumns="false" Width="100%"
                                            ClientInstanceName="Client_Chucnang_Nhanvien" CssClass="floatright">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="uId_Chucnang" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="nv_Tenphanhe_vn" Caption="Nhóm chức năng" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Chức năng" FieldName="nv_Tenchucnang_vn" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsPager PageSize="10" NumericButtonCount="5" Summary-Text="Trang {0}/{1} ({2} Chức năng)"></SettingsPager>
                                            <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />

                                            <Styles>
                                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                </AlternatingRow>
                                                <GroupRow Font-Bold="true"></GroupRow>
                                            </Styles>
                                        </dx:ASPxGridView>
                                    </div>--%>
                        </fieldset>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>

</asp:Content>
