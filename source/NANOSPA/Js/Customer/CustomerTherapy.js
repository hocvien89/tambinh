// CustomerTherapy
//#region "CustomerTherapy" 
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
function grid_FocusedRowChanged(s, e) {
    if (s.cpIsEditing) {
        s.UpdateEdit();
    }
}
function grid_RowDblClick(s, e) {
    s.StartEditRow(e.visibleIndex);
}
function gridVTTH_RowDblClick(s, e) {
    s.StartEditRow(e.visibleIndex);
}
var _handle = true;
function OnCustomButtonClick(s, e) {
    switch (e.buttonID) {
        case 'Delete':
            if (confirm("Bạn có muốn xóa bản ghi?")) {
                _handle = false;
                s.DeleteRow(e.visibleIndex);
            }
            break;
    }
}
//CKFINDER
function Upload(s, e) {
    var finder = new CKFinder();
    var uId_QT_Dieutri = jo_GetSession("uId_QT_Dieutri");
    finder.selectActionFunction = function (fileUrl) {
        //document.getElementById('<%%>').value = fileUrl;
        var param_dt = "{'nv_Hinhanh':'" + fileUrl + "','uId_QT_Dieutri':'" + uId_QT_Dieutri + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/CongdoanImageInsert";

        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                dtv_DieutriHinhanh.PerformCallback();
            },
            error: onFail
        });
    };
    finder.popup();
}
//Clear text
function ClearText(s, e) {
    jo_RemoveSession("uId_QT_Dieutri");
    jo_RemoveSession("uId_Dichvu_Chitiet");
    var ddlDichvuvalue = ddlDichvu.GetValue().toString();
    var param_dt = "{'uId_Dichvu':'" + ddlDichvuvalue + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/Loadlandieutri";
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
        var txtSolanDT = document.getElementById("<%=txtSolanDT.ClientID%>");
        var txtLanthu = document.getElementById("<%=txtLanthu.ClientID%>");
        var lblSoDVconlai = document.getElementById("<%=lblSoDVconlai.ClientID%>");
        //var txtNhanvienphu = document.getElementById("<%%>");
        //var txtImgUrl = document.getElementById("<%%>");
        var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
        txtSolanDT.value = defaultdata[0];
        txtLanthu.value = defaultdata[1];
        lblSoDVconlai.innerHTML = "Còn lại: " + defaultdata[3] + " lần điều trị";
        //txtNhanvienphu.value = "";
        //txtImgUrl.value = "";
        txtGhichu.value = "";
        dtv_DieutriHinhanh.PerformCallback();
    }
}
function onFail(ex) {
    alert(ex._message + " fail");
    return false;
}
function ddlDichvu_SelectChange(s, e) {
    jo_RemoveSession("uId_QT_Dieutri");
    jo_CreateSession("uId_Dichvu_Dieutri", ddlDichvu.GetValue().toString());
    var ddlDichvuvalue = ddlDichvu.GetValue().toString();
    var ltrTitleHeader = document.getElementById("<%=ltrTitleHeader.ClientID %>");
    ltrTitleHeader.innerHTML = ddlDichvu.GetText().toString();;
    var param_dt = "{'uId_Dichvu':'" + ddlDichvuvalue + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/Loadlandieutri";
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
    client_Lieutrinh.Refresh();
}
function SelectLieutrinh(uId_QT_Dieutri, uId_Dichvu) {
    jo_CreateSession("uId_QT_Dieutri", uId_QT_Dieutri);
    jo_CreateSession("uId_Dichvu_Chitiet", uId_Dichvu);
    window.location.href = "../../OrangeVersion/Customer/CustomerTherapy.aspx";
    return false;
}
function BackTo(s, e) {
    window.location.href = "../../OrangeVersion/Customer/BillingServices.aspx";
    return false;
}
function PopupNhanvienphu(s, e) {
    if (jo_GetSession("uId_QT_Dieutri") == null || jo_GetSession("uId_QT_Dieutri") == "") {
        alert("Vui lòng lưu quá trình điều trị trước khi kê khai nhân viên phụ");
    } else {
        var ddlDichvuvalue = ddlDichvu.GetText().toString();
        var txtTendichvu = document.getElementById("<%=txtTendichvu.ClientID %>");
        txtTendichvu.value = ddlDichvuvalue;
        pcNhanvienphu.Show();
    }
    return false;
}
function ClosePopup(s, e) {
    pcNhanvienphu.Hide();
    return false;
}
function LoadPopVTTH(s, e) {
    if (jo_GetSession("uId_QT_Dieutri") == null || jo_GetSession("uId_QT_Dieutri") == "") {
        alert("Vui lòng lưu quá trình điều trị trước khi kê khai vật tư tiêu hao");
    } else {
        var ddlDichvuvalue = ddlDichvu.GetText().toString();
        var txtTendichvuTH = document.getElementById("<%=txtTendichvuTH.ClientID%>");
        //txtTendichvuTH.value = ddlDichvuvalue;
        cbTenvattu.Focus();
        pcVTTH.Show();
    }
    return false;
}
function ClosePopupVTTH(s, e) {
    pcVTTH.Hide();
    return false;
}
function cbTenvattu_SelectChange(s, e) {
    jo_CreateSession("MaVatTu", cbTenvattu.GetValue().toString());
    cbDonvi.PerformCallback();
}
function cbKho_SelectChange(s, e) {
    cbTenvattu.PerformCallback();
}
function ShowUpload(s, e) {
    pcHinhanh.Show();
}
var focusedItemId = "";
var uid_ = "";
function onClick(event) {
    //if (focusedItemId != "") {
    //    if (event.currentTarget.id != focusedItemId)
    //        document.getElementById(focusedItemId).style.backgroundColor = "transparent";
    //}
    focusedItemId = event.currentTarget.id;
    var data = focusedItemId.split("$");
    imag_pup.SetImageUrl(data[1]);
    uid_ = data[0];
    pup_Phonganh.Show();
};
function lik_Deletecik(s, e) {
    var param_dt = "{'uId_HinhanhCongdoan':'" + uid_ + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/DeleteHinhanhCongdoan";

    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            dtv_DieutriHinhanh.PerformCallback();

        },
        error: onFail
    });
    pup_Phonganh.Hide();
}
function ShowCheckIn(s, e) {
    if (jo_GetSession("uId_QT_Dieutri") == null || jo_GetSession("uId_QT_Dieutri") == "") {
        alert("Vui lòng lưu quá trình điều trị trước khi kê khai vật tư tiêu hao");
        return false;
    } else {
        pcCheckIn.Show();
        return false;
    }
}
//in cong doan dich vu
function Incongdoan(s, e) {
    if (jo_GetSession("uId_Dichvu_Chitiet") == null) {
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
//kiem tra dieu kien de check in 
function CheckinTest(s, e) {
    var uId_Dieutri = jo_GetSession("uId_QT_Dieutri")
    var param_dt = "{'uId_Dieutri':'" + uId_Dieutri + "'}";
    var pageUrl = "../../../../Webservice/nano_websv_CheckInCheckOut.asmx/TestCheckIn";

    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.d == "True") {
                pcCheckIn.Hide();
                alert("Lần điều trị này đã được sử dụng!");
                e.processOnServer = false;
            }
        },
        error: onFail
    });
}
// End region

