//#Region "BillingService"
var tienthua_Data = 0;
$(document).ready(function () {
    $("#popupDiscount").hide();
    if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
        btnKekhai_client.SetEnabled(true);
        btnThanhtoanthe_client.SetEnabled(false);
    } else {
        btnThanhtoanthe_client.SetEnabled(true);
        btnKekhai_client.SetEnabled(false);
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

    }
}
function SelChanged(s, e) {
    if (!e.isSelected) {
        if (_handle == true) {
            client_grid.GetRowValues(e.visibleIndex, 'uId_Dichvu;f_phantramGiamgia;f_Gia;vType', OnGridDeSelectionComplete);
        }
    } else {
        _handle = true;
        client_grid.GetRowValues(e.visibleIndex, 'uId_Dichvu;f_phantramGiamgia;f_Gia;vType', OnGridSelectionComplete);
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
    txtSotiennhan.value = jo_FormatMoney(jo_IsString(parseFloat(values[2])));
    lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")))));
}

function OnGridSelectionComplete(values) {
    var hdfuIdDichvu = document.getElementById("<%=hdfuIdDichvu.ClientID %>");
    var hdfGiamgiaDV = document.getElementById("<%=hdfGiamgiaDV.ClientID%>");
    var hdfTienDV = document.getElementById("<%=hdfTienDV.ClientID%>");
    var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
    var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
    var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
    var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
    hdfuIdDichvu.value = values[0];
    hdfGiamgiaDV.value = values[1];
    hdfTienDV.value = values[2];
    SavePhieuDV();
    //Them thong tin cho box thanh toan
    lblTongtien.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) + parseFloat(hdfTienDV.value)));
    txtGiamgiaPhieu.value = jo_FormatMoney((parseFloat(jo_IsString(txtGiamgiaPhieu.value.replace(/,/g, ""))) + (parseFloat(hdfGiamgiaDV.value) * parseFloat(hdfTienDV.value) / 100)).toString());
    lblConlai.innerHTML = jo_FormatMoney(parseFloat(jo_IsString(lblTongtien.innerHTML.replace(/,/g, ""))) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")));
    txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
    if (values[3] == "TAIKHOAN") {
        $("#<%=btnCapthe.ClientID %>").css("display", "");
        ddlNhomphieu.SetValue("4");
    }
}
var checknew;
function OnGridDeSelectionComplete(values) {
    if (checknew != "clear") {
        var hdfuIdDichvu = document.getElementById("<%=hdfuIdDichvu.ClientID %>");
        var hdfGiamgiaDV = document.getElementById("<%=hdfGiamgiaDV.ClientID%>");
        var hdfTienDV = document.getElementById("<%=hdfTienDV.ClientID%>");
        var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
        var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
        var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
        var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
        hdfuIdDichvu.value = values[0];
        hdfGiamgiaDV.value = values[1];
        hdfTienDV.value = values[2];
        //Them thong tin cho box thanh toan
        lblTongtien.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(hdfTienDV.value)));
        txtGiamgiaPhieu.value = jo_FormatMoney((parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) - (parseFloat(hdfGiamgiaDV.value) * parseFloat(hdfTienDV.value) / 100)));
        lblConlai.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, ""))));
        txtSotiennhan.value = jo_FormatMoney(lblConlai.innerHTML);
        DeletePhieuDV();
        if (values[3] == "TAIKHOAN") {
            $("#<%=btnCapthe.ClientID %>").css("display", "none");
            ddlNhomphieu.SetValue("1");
        }
    }
}
function SavePhieuDV() {
    var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
    var hdfuIdDichvu = document.getElementById("<%=hdfuIdDichvu.ClientID %>");
    var hdfGiamgiaDV = document.getElementById("<%=hdfGiamgiaDV.ClientID%>");
    var ddlLoaithanhtoanvalue = ddlLoaithanhtoan.GetValue().toString();
    var ddlNhanvienvalue = ddlNhanvien.GetValue().toString();
    var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "','d_Ngay':'" + deNgaylap.GetText() +
        "','uId_Dichvu':'" + hdfuIdDichvu.value + "','f_GiamgiaDV':'" + hdfGiamgiaDV.value +
        "','uId_Nhanvien':'" + ddlNhanvienvalue + "', 'uId_LoaiTT':'" + ddlLoaithanhtoanvalue + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieudichvu";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            client_Phieuchitiet.Refresh();
        },
        error: onFail
    });
    return false;
}
function DeletePhieuDV() {
    var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
    var hdfuIdDichvu = document.getElementById("<%=hdfuIdDichvu.ClientID %>");
    var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "','uId_Dichvu':'" + hdfuIdDichvu.value + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/DeletePhieuchitiet";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.d != "") {
                OnGridSelectionDSPhieuComplete(msg.d.split("$"));
            }
        },
        error: onFail
    });
    return false;
}
function UpdatePhieuDV(s, e) {
    if (checkThanhtoan == 1) {
        alert("Phiếu dịch vụ đã được thanh toán không thể sửa thông tin!");
        e.processOnServer = false;
    }
    else {
        var uid_Thethanhtoan = jo_GetSession("uId_Khachhang_Goidichvu_TT");
        if (uid_Thethanhtoan == null & ddlLoaithanhtoan.GetValue().toString() == "01d16c43-7a03-49dc-afd2-39e79a1439f1") {
            alert("Hãy chọn loại hình thanh toán khác! hoặc chọn thẻ thanh toán nếu muốn thanh toán bằng thẻ");
            ddlLoaithanhtoan.ShowDropDown();
            return false;
        }
        var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
        var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID %>");
        var ddlLoaithanhtoanvalue = ddlLoaithanhtoan.GetValue().toString();
        var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
        var ddlNhanvienvalue = ddlNhanvien.GetValue().toString();
        var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
        var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
        var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
        var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
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
        var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "','d_Ngay':'" + deNgaylap.GetText() +
            "','f_Tongtienthuc':'" + txtSotiennhan.value.replace(/,/g, "") + "','tienthua':'" +
            //lblTienthua.innerHTML.replace(/,/g, "") + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
            tienthua_Data + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
            "','f_Giamgia':'" + giamgia + "','uId_Nhanvien':'" + ddlNhanvienvalue + "','nv_Ghichu_vn':'" +
            txtGhichu.value + "','HH':'" + txtHH.value + "','Id_Nhomphieu':'" + ddlNhomphieuvalue + "','f_Khachtra':'" + lblConlai.innerHTML.replace(/,/g, "") + "'}";
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
                btnThanhtoan.SetEnabled(false);
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
    var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
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
        var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
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
        var txtSoPhieu = document.getElementById("<%=txtSoPhieu.ClientID%>");
        var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
        var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
        var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
        var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
        var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
        var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
        var txtHH = document.getElementById("<%=txtHH.ClientID%>");
        var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
        txtSoPhieu.value = defaultdata[0];
        var date_ngaylap = new Date(defaultdata[1]);
        deNgaylap.SetDate(date_ngaylap);
        date_ngaylap.SetEnabled(faless);
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
         .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rp_Phieudichvu.aspx?Luachon=Thanhtoan" width="850px" height="100%"></iframe>')
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
function Incongdoan(uId_Dichvu_chitiet) {

    jo_CreateSession("uId_Dichvu_chitiet", uId_Dichvu_chitiet);
    if (jo_GetSession("uId_Phieudichvu") == null) {
        alert("Chưa chọn phiếu để in!");
    }
    else {

        var $dialog = $('<div></div>')
         .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rp_Phieudichvu.aspx?Luachon=Congdoan" width="850px" height="100%"></iframe>')
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
function Thietlaplieutrinh(uId_Dichvu, uId_Dichvu_chitiet) {
    jo_CreateSession("uId_Dichvu_Dieutri", uId_Dichvu);
    jo_CreateSession("uId_Dichvu_chitiet", uId_Dichvu_chitiet);
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
    var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
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
                            txtTenthe.value = defaultdata[1];
                            txtGiatri.value = jo_FormatMoney(jo_IsString(defaultdata[2]));
                            hdfDongiathe.value = defaultdata[2];
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
function loaddata() {
    window.external.LoadDSTheTT();
}
//EndRegion BillingService