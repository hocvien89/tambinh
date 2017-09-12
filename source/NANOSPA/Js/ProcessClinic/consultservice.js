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
function CallConfirmBox() {
    if (confirm("Chuyển thành công!")) {
        //OK – Do your stuff or call any callback method here..
        client_dgvDanhsachcho.Refresh();
        client_Phieuchitiet.Refresh();
        client_grid.UnselectRows();
        grvdadieutri.Refresh();
    } else {
        //CANCEL – Do your stuff or call any callback method here..
        //alert("You pressed Cancel!");
    }
} function CallConfirm() {
    if (confirm("Lưu thành công!")) {
        //OK – Do your stuff or call any callback method here..
    } else {

    }
}
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
function gridPhieuchitiet_EndCallback(s, e) {
    if (s.cpIsUpdated == "update") {
        s.cpIsUpdated = "";
    }
    if (s.cpIsHuyDV == "after") {
        alert("Phiếu đã thanh toán! vui lòng cho biết lí do xóa!");
        $("#box_huy").css("display", "");
        var txtLidoxoa =$("[id$='txtLidoxoa']");
        txtLidoxoa.focus();
        s.cpIsHuyDV = "";
    }
    if (s.cpIsHuyDV == "before") {
        s.cpIsHuyDV = "";
    }
    if (s.cpIsLocked == "true") {
        alert("Phiếu đã khóa");
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
function OnGridSelectionComplete(values) {
    var uid=jo_GetSession("uId_Phieudichvu1");
    if (uid == "" & uid=='null') {
        client_grid.UnselectRows();
        alert("Chưa chọn khách hàng để điều trị");
        return false;
    }
    else {
        var hdfuIdDichvu = $("[id$='hdfuIdDichvu']");
        var hdfGiamgiaDV =$("[id$='hdfGiamgiaDV']");
        var hdfTienDV =$("[id$='hdfTienDV']");
        hdfuIdDichvu.val(values[0]);
        hdfGiamgiaDV.val(values[1]);
        hdfTienDV.val(values[2]);
        SavePhieuDV();
    }
}
var checknew;
function OnGridDeSelectionComplete(values) {
    if (checknew != "clear") {
        var hdfuIdDichvu =$("[id$='hdfuIdDichvu']");
        var hdfGiamgiaDV =$("[id$='hdfGiamgiaDV']");
        var hdfTienDV =$("[id$='hdfTienDV']");
        hdfuIdDichvu.val(values[0]);
        hdfGiamgiaDV.val(values[1]);
        hdfTienDV.val(values[2]);
        DeletePhieuDV();
    }
}
function SavePhieuDV() {
    var txtSophieu =$("[id$='txtSoPhieu']");
    var hdfuIdDichvu =$("[id$='hdfuIdDichvu']");
    var hdfGiamgiaDV =$("[id$='hdfGiamgiaDV']");
    var param_dt = "{'v_Sophieu':'" + txtSophieu.val() + "','d_Ngay':'" + deNgaylap.GetText() +
        "','uId_Dichvu':'" + hdfuIdDichvu.val() + "','f_GiamgiaDV':'" + hdfGiamgiaDV.val() + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieudichvuchitiet";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            client_Phieuchitiet.Refresh();
            //client_dgvDanhsachcho.Refresh();
        },
        error: onFail
    });
    return false;
}
function DeletePhieuDV() {
    var txtSophieu =$("[id$='txtSoPhieu']");
    var hdfuIdDichvu =$("[id$='hdfuIdDichvu']");
    var param_dt = "{'v_Sophieu':'" + txtSophieu.val() + "','uId_Dichvu':'" + hdfuIdDichvu.val() + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/DeletePhieuchitiet";
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
function XuLyPhieuDichVu(uId_Phieudichvu, uId_Khachhang, uId_TrangthaiKH, nv_Hoten_vn, v_Sophieu, d_Ngaylap) {
    var uId_Nhanvien_phong = jo_GetSession("uId_Phongban_NV_Current")
    var txtSophieu =$("[id$='txtSoPhieu']");
    var txtHoten =$("[id$='txtHoten']");
    //phong kham
    if (uId_Nhanvien_phong == "67be576f-54fe-43a3-bd33-27f42e88b3fe") {
        jo_CreateSession("uId_Phieudichvu1", uId_Phieudichvu);
        jo_RemoveSession("uId_Phieuxuat");
        //jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
        jo_CreateSession("uId_Khachhang", uId_Khachhang);
        //jo_CreateSession("uId_TrangthaiKH", uId_TrangthaiKH);
        deNgaylap.SetText(d_Ngaylap);
        txtSophieu.val(v_Sophieu);
        txtHoten.val(nv_Hoten_vn);
        //client_Phieuchitiet.Refresh();
        //window.location.href = "../../OrangeVersion/Customer/ConsultService.aspx";
        pcthongtinkham.Show();
        pagedieutri.SetActiveTab(pagedieutri.GetTab(1));
        pagedieutri.GetTab(1).SetVisible(false);
        pagedieutri.GetTab(0).SetVisible(false);
        pagedieutri.GetTab(2).SetVisible(true);
        pcthongtinkham.SetHeaderText("Hồ Sơ bệnh nhân - " + nv_Hoten_vn);
        txtmach.Focus();
        grvhistory.Refresh();
    }
        //le tan
    else {
        jo_CreateSession("uId_Phieudichvu", uId_Phieudichvu);
        jo_CreateSession("uId_Khachhang", uId_Khachhang);
        jo_CreateSession("uId_TrangthaiKH", uId_TrangthaiKH);
        window.location.href = "../../OrangeVersion/Customer/ConsultService.aspx";
    }
    return false;
}
function Lichsudieutri(uId_Khachhang, nv_Hoten_vn) {
    jo_CreateSession("uId_Khachhang", uId_Khachhang);
    pcthongtinkham.Show();
    pcthongtinkham.SetHeaderText("Hồ Sơ bệnh nhân - " + nv_Hoten_vn);
    pagedieutri.SetActiveTab(pagedieutri.GetTab(2));
    pagedieutri.GetTab(1).SetVisible(false);
    pagedieutri.GetTab(0).SetVisible(false);
    txtmach.Focus();
    grvhistory.Refresh();
}
function Thietlaplieutrinh(uId_Dichvu) {
    jo_CreateSession("uId_Phieudichvu_Chitiet", uId_Dichvu);
    var param_dt = "{'Info':'" + uId_Dichvu + "'}";
    var pageUrl = "../../../../Webservice/nano_websv_ProcessClinic.asmx/GetHistory";
    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: SetDataDieutri,
        error: onFail
    });
    pcthongtinkham.Show();
    txtmach.Focus();
    grvhistory.Refresh();
    //window.location.href = "../../OrangeVersion/Customer/CustomerTherapy.aspx";
    return false;
}
function SetDataDieutri(msg) {
    pagedieutri.GetTab(0).SetVisible(true);
    pagedieutri.GetTab(1).SetVisible(true);
    pagedieutri.SetActiveTab(pagedieutri.GetTab(1));
    if (msg.d != '') {
        var data = msg.d.split("#")
        var datacothe = data[0].split("$");
        var databieuhienbenh = data[2].split("$");
        var datasinhoamau = data[1].split("$");
        var phuongphapDT = data[3].split("$");
        var ketluan = data[4].split("$");
        //tinh trang co the
        txtmach.SetText(datacothe[0]);
        txthuyetap.SetText(datacothe[1]);
        txthuyetapgio.SetText(datacothe[2]);
        txtluoichat.SetText(datacothe[3]);
        txtluoireu.SetText(datacothe[4]);
        cboda.SetText(datacothe[5]);
        cbomohoi.SetText(datacothe[6]);
        cboan.SetText(datacothe[7]);
        cbongu.SetText(datacothe[8]);
        txtdaitienlan.SetText(datacothe[9].split("/")[0]);
        txtdaitienngay.SetText(datacothe[9].split("/")[1]);
        cbodaitien.SetText(datacothe[10]);
        txttieutienlan.SetText(datacothe[11].split("/")[0]);
        txttieutienngay.SetText(datacothe[11].split("/")[1]);
        cbotieutien.SetText(datacothe[12])
        txtkg.SetText(datacothe[13].split("/")[0]);
        txtcm.SetText(datacothe[13].split("/")[1]);
        cbothetrang.SetText(datacothe[14]);
        cbotheluc.SetText(datacothe[14]);
        cbotinhthan.SetText(datacothe[15]);
        // sinh hoa mau
        txtshmgot.SetText(datasinhoamau[0]);
        txtshmgpt.SetText(datasinhoamau[1]);
        txtshmggt.SetText(datasinhoamau[2]);
        txtbiltp.SetText(datasinhoamau[3]);
        txtbiltt.SetText(datasinhoamau[4]);
        txtchol.SetText(datasinhoamau[5]);
        txttrig.SetText(datasinhoamau[6]);
        txthdl.SetText(datasinhoamau[7]);
        txtldl.SetText(datasinhoamau[8]);
        txtgluo.SetText(datasinhoamau[9]);
        txtauric.SetText(datasinhoamau[10]);
        txtcreatinin.SetText(datasinhoamau[11]);
        txture.SetText(datasinhoamau[12]);
        memoboxung.SetText(datasinhoamau[13]);
        memochandoantuanh.SetText(datasinhoamau[14]);
        // bieu hien benh
        memotrieuchung.SetText(databieuhienbenh[0]);
        memoyeutotangbenh.SetText(databieuhienbenh[1]);
        memocodia.SetText(databieuhienbenh[2]);
        memodungtanduoc.SetText(databieuhienbenh[3]);
        memodungdongduoc.SetText(databieuhienbenh[4]);
        memobenhsu.SetText(databieuhienbenh[5]);
        memoghichu.SetText(databieuhienbenh[6]);
        // phuong phap dieu tri
        memoppdieutri.SetText(data[3]);
        // ket luan
        cboketluan.SetText(data[4]);
    }
    else {
        clearInfo();
    }

}
function clearInfo() {
    txtmach.SetText("");
    txthuyetap.SetText("");
    txthuyetapgio.SetText("");
    txtluoichat.SetText("");
    txtluoireu.SetText("");
    cboda.SetText("");
    cbomohoi.SetText("");
    cboan.SetText("");
    cbongu.SetText("");
    cbotheluc.SetText("");
    cbotinhthan.SetText("");
    //trieu chung benh
    memotrieuchung.SetText("");
    memoyeutotangbenh.SetText("");
    memocodia.SetText("");
    memodungtanduoc.SetText("");
    memodungdongduoc.SetText("");
    memobenhsu.SetText("");
    memoghichu.SetText("");
    //sinh hoa mau
    txtshmgot.SetText("");
    txtshmgpt.SetText("");
    txtshmggt.SetText("");
    txtbiltp.SetText("");
    txtbiltt.SetText("");
    txtchol.SetText("");
    txttrig.SetText("");
    txthdl.SetText("");
    txtldl.SetText("");
    txtgluo.SetText("");
    txtauric.SetText("");
    txtcreatinin.SetText("");
    txture.SetText("");
    memoboxung.SetText("");
    memochandoantuanh.SetText("");
    cboketluan.SetText("");
}
function deNgaplapChange(s, e) {
    createphieudichvu()
}
function createphieudichvu() {
    if (jo_GetSession("uId_Phieudichvu") == "" || jo_GetSession("uId_Phieudichvu") == null) {
        var txtSophieu =$("[id$='txtSoPhieu']");
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
                    txtSophieu.val(msg.d);
                }
            },
            error: onFail
        });
    }
}
function BackQuanLyKhachHang(s, e) {
    window.location.href = "../../OrangeVersion/Customer/CustomerList.aspx";
    return false;
}

function phongchange(s, e) {
    var item = ""
    item = ddlDMPhong.GetValue()+"$PHONG";
    ddlTrangthai.SetValue(SetTrangThaiByPhong(item))
}
function cboTrangthaiChange(s, e) {
    var item = ""
    item = ddlTrangthai.GetValue() + "$TT";
    ddlDMPhong.SetValue(SetTrangThaiByPhong(item))
}
function btnlammoiClick(s, e) {
    jo_RemoveSession("uId_Phieudichvu");
    jo_RemoveSession("uId_TrangthaiKH");
    ddlDMPhong.SetValue("98cab2b9-ff4c-4d25-ba8c-202aa0b854c2")
    ddlTrangthai.SetValue("c78d28b5-b837-48ea-b1f9-5c994de6b840")
    createphieudichvu();
    client_Phieuchitiet.Refresh();
    client_grid.UnselectRows(); 
    e.processOnServer = false;
}
function btndieutriClick(s, e) {
    pcthongtinkham.Hide();
    jo_RemoveSession("uId_Phieudichvu");
    jo_RemoveSession("uId_TrangthaiKH");
    ddlDMPhong.SetValue("98cab2b9-ff4c-4d25-ba8c-202aa0b854c2")
    ddlTrangthai.SetValue("c78d28b5-b837-48ea-b1f9-5c994de6b840")
    //client_Phieuchitiet.Refresh();
    createphieudichvu();
}
//enter key
function enter_txtmach(e) {
    if (e.KeyCode() == 13) {
        txthuyetap.Focus();
    }
}
function btnchuyenClick(s, e) {
    if (jo_GetSession("uId_Phieudichvu") == null || jo_GetSession("uId_Phieudichvu") == "") {
        alert("Hãy kê phiếu điều trị để chuyển thanh toán")
        e.processOnServer = false;
    }
}
function SelectPhieudieutri(uId_phieudichvu) {
    jo_CreateSession("uId_Phieudichvu", uId_phieudichvu);
    pcthongtinkham.Hide();
    client_Phieuchitiet.Refresh();
}
function btnkethuocClick(s, e) {
    if (jo_GetSession("uId_Phieudichvu1") == null || jo_GetSession("uId_Phieudichvu1") == "") {
        alert("Hãy chọn phiếu khám cần xử lý")
    }
    else {
        window.location.href = "../../OrangeVersion/Product/ExportProduct.aspx";
    }
}
function tablichsuchange(s, e) {
    var tabindex = s.GetActiveTabIndex();
    if (tabindex == 2) {
        pagedieutri.GetTab(0).SetVisible(false);
        pagedieutri.GetTab(1).SetVisible(false);
        btnluu.SetVisible(false);
        btndieutri.SetVisible(false);
        btnkethuoc.SetVisible(false);
        lblketluan.SetVisible(false);
        cboketluan.SetVisible(false);
        lblppdieutri.SetVisible(false)
        memoppdieutri.SetVisible(false);
        cb_Tinhtrangbenh.SetVisible(false);
        lbl_Tinhtrang.SetVisible(false);
    }
    else {
        btnluu.SetVisible(true);
        btndieutri.SetVisible(true);
        btnkethuoc.SetVisible(true);
        lblketluan.SetVisible(true);
        cboketluan.SetVisible(true);
        lblppdieutri.SetVisible(true)
        memoppdieutri.SetVisible(true);
        cb_Tinhtrangbenh.SetVisible(true);
        lbl_Tinhtrang.SetVisible(true);
    }
}

function tablistsuchange(s, e) {
    var tabindex = s.GetActiveTabIndex();
    if (tabindex == 1) {
        client_grid.SetEnabled(false);
        client_grid.Refresh();
        btnchuyen.SetEnabled(false);
        btnluu.SetEnabled(false);
        btndieutri.SetEnabled(false);
        btnkethuoc.SetEnabled(false);
    }
    else {
        client_grid.SetEnabled(true);
        btnchuyen.SetEnabled(true);
        btnluu.SetEnabled(true);
        btndieutri.SetEnabled(true);
        btnkethuoc.SetEnabled(true);
        client_grid.Refresh();
    }
}
function KetThucKham(uId_Phieudichvu,Tenbenhnhan) {
    if (confirm("Bạn có muốn kết thúc khám cho bệnh nhân " + Tenbenhnhan + " không?")) {
        var param_dt = "{'uId_Phieudichvu':'" + uId_Phieudichvu + "'}";
        var pageUrl = "../../../../Webservice/nano_websv_ProcessClinic.asmx/KetThucKhamBenh";
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
                    client_dgvDanhsachcho.Refresh();
                    grvdadieutri.Refresh();
                }
            },
            error: onFail
        });
    }
}