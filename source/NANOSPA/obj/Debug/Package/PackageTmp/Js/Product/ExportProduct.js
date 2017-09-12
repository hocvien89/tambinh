SelChanged_dsphieu// ExportProduct.aspx
function GetThongTinPhieu() {
    var param_dt = "{'uId_Phieuxuat':'" + jo_GetSession("uId_Phieuxuat") + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuXuat";
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
function grid_EndCallback(s, e) {
    var edit = s.GetEditor(1);
    if (s.cpIsEditing) {
        var editor = s.GetEditor(_fieldName);
        if (editor != null) {
            editor.SelectAll();
            editor.Focus();
        }
    }
    if (s.cpIsUpdated == "update") {
        GetThongTinPhieu();
        s.cpIsUpdated = "";
    }
    if (s.cpUpdateStatus == "lackqt") {
        alert("Mặt hàng đã hết trong kho! Vui lòng kiểm tra lại");
        s.cpUpdateStatus = "";
    }
    if (s.cpUpdateStatus == "lock") {
        alert("Phiếu đã khóa!");
        s.cpUpdateStatus = "";
    }
    if (s.cpShowError) {
        lberror.SetText(s.cpText);
    }
}
function grid_RowDblClick(s, e) {
    s.StartEditRow(e.visibleIndex);
}
function grid_FocusedRowChanged(s, e) {
    if (s.cpIsEditing) {
        s.UpdateEdit();
    }
}
function cbKhachhang_SelectChange(s, e) {
    jo_CreateSession("uId_Khachhang", ddlKhachhang.GetValue().toString());
}
function cbTenvattu_SelectChange(s, e) {
    jo_CreateSession("MaVatTu", ddlMathang.GetValue().toString());
    ddlDonvi.PerformCallback();
}
function onFail(ex) {
    alert(ex._message + " fail");
    return false;
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
$(document).ready(function () {
    $("#popupDiscount").hide();
});
//Custom commad button phieu dich vu chi tiet
var _handle = true;
function OnCustomButtonClick(s, e) {
    switch (e.buttonID) {
        case 'Delete':
            if (confirm("Bạn có muốn xóa bản ghi?")) {
                _handle = false;
                client_grid.GetRowValues(e.visibleIndex, 'uId_Phieuxuat_Chitiet;f_Dongia;f_Giamgia;f_Soluong;f_Tongtien', OnGridPhieuchitietSelectionComplete);
                s.DeleteRow(e.visibleIndex);
            }
            break;
        case 'Edit': s.StartEditRow(e.visibleIndex);
            break;
        case 'Save': s.UpdateEdit();
            break;
        case "New": s.AddNewRow();
    }
}
//Chon danh sach the thanh toan
function SelChanged_dsthe(s, e) {
    if (!e.isSelected) {
    } else {
        client_dgvDsTheTT.GetRowValues(e.visibleIndex, 'uId_Khachhang_Goidichvu;f_Giatrigoi;vMaBarcode', OnGridSelectionDSTheComplete);
    }
}
function ClosePopupTheTT() {
    pcDsTheTT.Hide();
    return false;
}
function ShowTheTT(s, e) {
    client_dgvDsTheTT.Refresh();
    pcDsTheTT.Show();
    return false;
}
function ShowDSPopup(s, e) {
    client_dgvDanhsachphieu.Refresh();
    pcDanhsachphieu.Show();
    return false;
}
//Chon danh sach phieu
function SelChanged_dsphieu(s, e) {
    if (!e.isSelected) {
    } else {
        client_dgvDanhsachphieu.GetRowValues(e.visibleIndex, 'uId_Phieuxuat;v_Maphieuxuat;uId_Khachhang', OnGridSelectionDSPhieuComplete);
    }
}
function OnGridSelectionDSPhieuComplete(values) {
    jo_CreateSession("uId_Phieuxuat", values[0]);
    jo_CreateSession("uId_Khachhang", values[2]);
    client_grid.Refresh();
    var param_dt = "{'uId_Phieuxuat':'" + values[0] + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuXuat";
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

function enter_ddlMathang(e) {
    if (e.keyCode == 13) {
        ddlDonvi.Focus();
        return false;
    }
}
function enter_txtSoluong(e) {
    if (e.keyCode == 13) {
        btnLuuchitiet.Focus();
        return false;
    }
}

function ddlMathang_enter(s, e) {
    if (e.keyCode == 13) {
        alert("090");
        var param_dt = "{'v_Barcode':'" + values[0] + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/GetInfoProductByBarcode";
        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                if (msg.d != "") {
                    ddlMathang.SetValue(msg.d);

                }
            },
            error: onFail
        });
    }
}