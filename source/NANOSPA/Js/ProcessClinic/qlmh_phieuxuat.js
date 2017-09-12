//===============btn event
function BackPhieuChoThanhToan(s, e) {
    window.location.href = "../../OrangeVersion/Customer/CheckOut.aspx";
    return false;
}
function btnSaochepphieuClick(s, e) {
    var sPara = ddlNhanvien.GetValue() + "$" + deNgayxuat.GetText() + "$" + txtGhichu.val() + "$" + cbkchike.GetChecked() + "$" + txtsothang.GetText();
    var param_dt = "{'sPara':'" + jo_GetSession("uId_Phieuxuat") + "'}";
    var pageUrl = "../../../../Webservice/nano_websv_ThuocMethod.asmx/SaoChepDonThuocMau";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.d != "") {
                txtdongiathang.SetText(jo_FormatMoney(msg.d));
                txtdongiathang.SetEnabled(false);
                lblTongtien.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                txtSotiennhan.value = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                lblConlai.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));

                lblTienthua.innerHTML = "0";
            }
        },
        error: onFail
    });

}
function btnLuuClick(s, e) {
    var txtMaphieu = $("[id$='txtMaphieu']");
    var txtGhichu = $("[id$='txtGhichu']");
    var sPara = "";
    sPara = ddlDMKho.GetValue() + "$" + ddlNhanvien.GetValue() + "$" + txtMaphieu.val() + "$" + deNgayxuat.GetText() + "$" + txtGhichu.val() + "$" + cbkchike.GetChecked() + "$" + txtsothang.GetText();
    var param_dt = "{'sPara':'" + sPara + "'}";
    var pageUrl = "../../../../Webservice/nano_websv_ThuocMethod.asmx/InsertPhieuxuat";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.d != "") {
                alert(msg.d);
                cbkchike.SetEnabled(false);
                ddlMathang.PerformCallback();
            }
        },
        error: onFail
    });
}
function Inphieu(s, e) {
    if (jo_GetSession("uId_Phieuxuat") == null) {
        alert("Chưa chọn phiếu để in!");
    }
    else {
        var $dialog = $('<div></div>')
         .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Indonthuoc.aspx" width="850px" height="100%"></iframe>')
         .dialog({
             autoOpen: false,
             modal: true,
             height: 634,
             width: 855.733,
             title: "In đơn thuốc",
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

//=============Grid Event
// chon phieu trong danh sach
function OnGridSelectionDSPhieuComplete(uId_Phieuxuat, uId_Khachhang, Type) {
    pcDanhsachphieu.Hide();
    if (Type == "Edit") {
        btnLuu.SetText("Sửa phiếu");
        btnLuu.SetVisible(true);
        btnSaochepphieu.SetVisible(false);
    }
    else {
        btnSaochepphieu.SetVisible(true);
        btnLuu.SetVisible(false);
    }
        jo_CreateSession("uId_Phieuxuat", uId_Phieuxuat);
        jo_CreateSession("uId_Khachhang", uId_Khachhang);
        client_grid.Refresh();
        var param_dt = "{'uId_Phieuxuat':'" + uId_Phieuxuat + "'}";
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

//=============Combobox Event
function ddlDsKhoChange(s, e) {
    client_dgvDanhsachphieu.Refresh();
}
