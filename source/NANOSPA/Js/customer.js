//==========CustomerList============
//Lưu ý: hiện tại bỏ phần check quyền truy cập customer list
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
function ShowAddWindowimport() {
    PcImportExcel.Show();
    document.getElementById("<%=lbl_Import.ClientID%>").innerHTML = ""
}
$(document).ready(function () {
    $("#box_note").css("display", "none");
});
//Set default short key code
$(document).ready(function () {
    //var param_dt = "{'uId_Chucnang':'BC3402F3-9B32-4ED1-9625-A657699A784B'}";
    //var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
    //$.ajax({
    //    type: "POST",
    //    url: pageUrl,
    //    data: param_dt,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    async: false,
    //    success: function (msg) {
    //        if (msg.d == "false") {
    //            window.location.href = "../../OrangeVersion/Util/DeclineRole.aspx";    
    //        }
    //    },
    //    error: onFail
    //});
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
    //var ltrError1 = document.getElementById("<%=ltrError1.ClientID%>");
    var ltrSuccess1 = document.getElementById("<%=ltrSuccess1.ClientID%>");
    //ltrError1.innerHTML = "";
    ltrSuccess1.innerHTML = "";
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
    jo_CreateSession("uId_Khachhang", values[1]);
    //Gan gia tri cho hidden field uId khachhang de sua thong tin khach hoac lam gi do
    var hdfuIdKhachhang = document.getElementById("<%=hdfuIdKhachhang.ClientID%>");
    var hdfuId_KH_chuyen = document.getElementById("<%=hdfuId_KH_chuyen.ClientID%>");
    hdfuIdKhachhang.value = values[1];
    hdfuId_KH_chuyen.value = values[1];
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
        deNgayden.SetDate(date_ngayden);
        txtMaKH.value = defaultdata[1];
        txtHoten.value = defaultdata[2];
        var date_ngaysinh = new Date(defaultdata[3]);
        _ngaysinh = date_ngaysinh;
        var date_Nam = new Date("01/01/1900")
        deNgaysinh.SetDate(date_ngaysinh);
        if (date_ngaysinh.getDate() == date_Nam.getDate() & date_ngaysinh.getMonth() == date_Nam.getMonth() & date_ngaysinh.getFullYear() == date_Nam.getFullYear()) {
            chk_Ngaysinh.SetChecked(true);
            deNgaysinh.SetEnabled(false);
        }
        else {
            chk_Ngaysinh.SetChecked(false);
            deNgaysinh.SetEnabled(true);
        }
        ddlGioitinh.SetValue(ConvertSex(defaultdata[4]));
        txtDiachi.value = defaultdata[5];
        txtDienthoai.value = defaultdata[6];
        txtEmail.value = defaultdata[7];
        ddlNghenghiep.SetValue(defaultdata[8]);
        ddlNguon.SetValue(defaultdata[9]);
        txtGhichu.value = defaultdata[10];
        imgAnhdaidien.src = defaultdata[11];
        txtImgUrl.value = defaultdata[11];
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
    txtHoten.value = "";
    txtDiachi.value = "";
    txtDienthoai.value = "";
    deNgayden.SetDate(new Date());
    deNgaysinh.SetDate(new Date());
    txtEmail.value = "";
    txtGhichu.value = "";
    imgAnhdaidien.src = "";
    txtImgUrl.value = "";
    chk_Ngaysinh.SetChecked(false);
    jo_RemoveSession("uId_Khachhang");
    hdfuIdKhachhang.value = "";
    var error = document.getElementById("error");
    var success = document.getElementById("success");
    if (error != null)
        error.innerHTML = "";
    if (success != null)
        success.innerHTML = "";
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
    if (e.keyCode == 13) {
        var txtHoten = document.getElementById("<%=txtHoten.ClientID%>");
        if (txtHoten.value != "") {
            deNgaysinh.Focus();
        }
        return false;
    }
}
function enter_deNgaysinh(e) {
    if (e.keyCode == 13) {
        var txtTuoi = document.getElementById("<%=txtTuoi.ClientID%>");
        var currentTime = new Date()
        var year = currentTime.getFullYear()
        txtTuoi.value = year - parseInt(deNgaysinh.GetText().split("/")[2]);
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
function enter_txtGhichu(e) {
    if (e.keyCode == 13) {
        btOk.Focus();
        return false;
    }
}
function Chonphieudichvu(uId_Phieudichvu, uId_Khachhang, v_Sophieu, d_Ngaylap) {
    jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
    jo_CreateSession("uId_Khachhang", uId_Khachhang);
    var txtSoPhieu1 = document.getElementById('<%=txtSoPhieu1.ClientID%>');
    var txtNgayLap1 = document.getElementById('<%=txtNgayLap1.ClientID%>');
    txtSoPhieu1.value = v_Sophieu;
    txtNgayLap1.value = d_Ngaylap
    //window.location.href = "../../OrangeVersion/Customer/BillingServices.aspx";
    pcChuyenTaiKham.Show();
    return false;
}
function Chonphieuxuat(uId_Phieuxuat, uId_Khachhang) {
    jo_CreateSession("uId_Phieuxuat", uId_Phieuxuat);
    jo_CreateSession("uId_Khachhang", uId_Khachhang);
    window.location.href = "../../OrangeVersion/Product/ExportProduct.aspx";
    return false;
}
function Thietlaplieutrinh(uId_Phieudichvu, uId_Khachhang, uId_Dichvu_Dieutri, uId_Phieudichvu_Chitiet) {
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

    var error = document.getElementById('diverror');
    if (deNgayden.GetText() == "01/01/0100") {
        deNgayden.Focus();
        error.innerHTML = "Ngày đến không được để trống";
        deNgayden.ShowDropDown();
        e.processOnServer = false;
    }
    else if (deNgaysinh.GetText() == "01/01/0100") {
        deNgaysinh.Focus();
        error.innerHTML = "Ngày sinh không được để trống";
        deNgaysinh.ShowDropDown();
        e.processOnServer = false;
    }
    else if (document.getElementById("<%=txtHoten.ClientID%>").value == "") {
        document.getElementById("<%=txtHoten.ClientID%>").focus();
        error.innerHTML = "Tên khách hàng không được để trống";
        e.processOnServer = false;
    }
    else if (document.getElementById("<%=txtMaKH.ClientID%>").value == "") {
        document.getElementById("<%=txtMaKH.ClientID%>").focus();
        error.innerHTML = "Mã khách hàng không được để trống";
        e.processOnServer = false;
    }
    //else if (chk_Ngaysinh.GetChecked() == true & document.getElementById(").value == "") {
    //document.getElementById("").focus()
    //error.innerHTML = "Hãy ghi năm sinh của khách hàng vào mục ghi chú";
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
function openNote() {
    $("#box_note").toggle();
    return false;
}
function phongchange(s, e) {
    var item = ""
    item = ddlDMPhong.GetValue();
    ddlTrangthai.SetValue(SetTrangThaiByPhong(item))
    //if (item == "Phòng kế toán") {
    //    ddlTrangthai.SetValue("c78d28b5-b837-48ea-b1f9-5c994de6b840");
    //}
    //if (item == "Phòng phẫu thuật" || item == "Phòng spa" || item == "Phòng laser") {
    //    ddlTrangthai.SetValue("715ae9db-98a3-47b1-9ee5-52d6db7d895f");
    //}
    //if (item == "Phòng CSKH") {
    //    ddlTrangthai.SetValue("633e14b6-e05e-4d13-8ef9-942c90b3c8a9");
    //    ddlTrangthai.SetText("Chờ tư vấn");
    //}
}
function phongchange1(s, e) {
    var item = ""
    item = ddlDMPhong1.GetText();
    if (item == "Phòng kế toán") {
        ddlTrangthai1.SetValue("c78d28b5-b837-48ea-b1f9-5c994de6b840");
    }
    if (item == "Phòng phẫu thuật" || item == "Phòng spa" || item == "Phòng laser") {
        ddlTrangthai1.SetValue("715ae9db-98a3-47b1-9ee5-52d6db7d895f");
    }
    if (item == "Phòng CSKH") {
        ddlTrangthai1.SetValue("633e14b6-e05e-4d13-8ef9-942c90b3c8a9");
    }
}
function Checkthemdv(s, e) {
    var hdfuIdKhachhang = document.getElementById('<%=hdfuIdKhachhang.ClientID%>');
    var error = document.getElementById('diverror');
    if (jo_GetSession("uId_Khachhang") == "" || jo_GetSession("uId_Khachhang") == null) {
        error.innerHTML = "Hãy lưu lại trước khi thêm phiếu dịch vụ!";
        e.processOnServer = false;
    }
}

function Checkthempx(s, e) {
    var hdfuIdKhachhang = document.getElementById('<%=hdfuIdKhachhang.ClientID%>');
    var error = document.getElementById('diverror');
    if (hdfuIdKhachhang.value == "") {
        error.innerHTML = "Hãy lưu lại trước khi thêm phiếu xuất!";
        e.processOnServer = false;
    }
}
function Checkthemlh(s, e) {
    var hdfuIdKhachhang = document.getElementById('<%=hdfuIdKhachhang.ClientID%>');
    var error = document.getElementById('diverror');
    if (hdfuIdKhachhang.value == "") {
        error.innerHTML = "Hãy lưu lại trước khi thêm lịch hẹn!";
        e.processOnServer = false;
    }
}
function ReloadGrv(s, e) {
    if (chkviewall.GetChecked() == true) {
        detungay.SetEnabled(false);
        dedenngay.SetEnabled(false);
    }
    else {
        detungay.SetEnabled(true);
        dedenngay.SetEnabled(true);
    }
    client_grid.Refresh();
}