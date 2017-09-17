<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="BillingServices.aspx.vb" Inherits="NANO_SPA.BillingServices" %>

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
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script src="../../../../Js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
    <link href="../../../../Css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var tienthua = 0;
        var tienthua_Data=0;
        var img_url = '';
        var checkThanhtoan = 0
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
            $("#popupDiscount_PX").hide();
            if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
                btnKekhai_client.SetEnabled(true);
                btnThanhtoanthe_client.SetEnabled(false);
            } else {
                btnThanhtoanthe_client.SetEnabled(true);
                btnKekhai_client.SetEnabled(false);
            }
        });
        // load uu tien the tich diem
        function getuutientichdiem() {

            var param_dt = "{'uId_Khachhang':'" + jo_GetSession("uId_Khachhang") + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/GetMucuutienTTD";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        if (Number(msg.d) < 100) {
                            lbluutien.SetText(msg.d + " %");
                        }
                        else {
                            lbluutien.SetText(jo_FormatMoney(msg.d) +" VND");
                        }
                    }
                    else {

                    }
                },
                error: onFail
            });
        }
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
            cb_Loaithe.PerformCallback();
            if (s.cpIsUpdated == "update") {
                GetThongTinPhieu();
                s.cpIsUpdated = "";
            }
            if (s.cpIsUpdated == "No_Update")
            {
                alert("Phiếu đã thanh toán không thể sửa.");
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
        //b_goidichvu xac dinh dich vua lua chon la gi neu la goi dv se insert tat ca dich vu cua goi dv do
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
            txtSotiennhan.value = jo_FormatMoney(jo_IsString(parseFloat(lblConlai.innerHTML)));
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
            //lblTongtien.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) + parseFloat(hdfTienDV.value)));
            //txtGiamgiaPhieu.value = jo_FormatMoney((parseFloat(jo_IsString(txtGiamgiaPhieu.value.replace(/,/g, ""))) + (parseFloat(hdfGiamgiaDV.value) * parseFloat(hdfTienDV.value) / 100)).toString());
            //lblConlai.innerHTML = jo_FormatMoney(parseFloat(jo_IsString(lblTongtien.innerHTML.replace(/,/g, ""))) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")));
            //txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));          
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
               // Them thong tin cho box thanh toan
                //lblTongtien.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(hdfTienDV.value)));
                //txtGiamgiaPhieu.value = jo_FormatMoney((parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) - (parseFloat(hdfGiamgiaDV.value) * parseFloat(hdfTienDV.value) / 100)));
                //lblConlai.innerHTML = jo_FormatMoney((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, ""))));
                //txtSotiennhan.value = jo_FormatMoney(lblConlai.innerHTML);
                DeletePhieuDV();
                if (values[3] == "TAIKHOAN") {
                    $("#<%=btnCapthe.ClientID %>").css("display", "none");
                ddlNhomphieu.SetValue("1");
            }
        }
        }
        function ddlkythuatvien(s, e)
        {
           
        }
        function SavePhieuDV() {
            var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
            var hdfuIdDichvu = document.getElementById("<%=hdfuIdDichvu.ClientID %>");
            var hdfGiamgiaDV = document.getElementById("<%=hdfGiamgiaDV.ClientID%>");
            var ddlLoaithanhtoanvalue = ddlLoaithanhtoan.GetValue().toString();
            var ddlNhanvienvalue = ddlNhanvien.GetValue().toString();
        
            var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "$" + lbluutien.GetText() + "','d_Ngay':'" + deNgaylap.GetText() +
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
                    checknew = "New";
                    OnGridSelectionDSPhieuComplete(msg.d.split("$"));
                    client_Phieuchitiet.Refresh();
                    //pcnhanvien.Hide();
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
                    //client_Phieuchitiet.Refresh();
                    if (msg.d != "") {
                        OnGridSelectionDSPhieuComplete(msg.d.split("$"));
                    }
                    else {
                        ClearPhieuDichVu();
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
                var txtLydogiamgia = document.getElementById("<%=txtLydogiamgia.ClientID%>");
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var txtHH = document.getElementById("<%=txtHH.ClientID%>");
                var ddlNhomphieuvalue = ddlNhomphieu.GetValue().toString();
                var giamgia = 0;
                var f_Khachtra = lblConlai.innerHTML.replace(/,/g, "");
                var isVNDChecked = rbGiamgiaVND.GetChecked();
                var isphantramChecked = rbGiamgiaphantram.GetChecked();
                if (isVNDChecked) {
                    giamgia = txtGiamgiaPhieu.value.replace(/,/g, "");
                }
                if (isphantramChecked) {
                    giamgia = (parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) * parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) / 100);
                }
                var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "','d_Ngay':'" + deNgaylap.GetText() +
                    "','f_Tongtienthuc':'" + parseFloat(txtSotiennhan.value.replace(/,/g, "")) + "','tienthua':'" +
                    //lblTienthua.innerHTML.replace(/,/g, "") + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
                    tienthua_Data + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
                    "','f_Giamgia':'" + giamgia + "','uId_Nhanvien':'" + ddlNhanvienvalue + "','nv_Ghichu_vn':'" +
                    txtGhichu.value + "','HH':'" + txtHH.value + "','Id_Nhomphieu':'" + ddlNhomphieuvalue + "','f_Khachtra':'" + f_Khachtra + "','nv_Lydogiamgia':'" + txtLydogiamgia.value + "'}";
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
                        checkThanhtoan = 1;
                    },
                    error: onFail
                });
                client_dgvDsTheTT.Refresh();
                return false;
            }
        }
        function ClearPhieuDichVu(s, e) {
            checknew = "clear";
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
            deNgaylap.SetEnabled(true);
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
                        checkThanhtoan = 0;
                    }
                },
                error: onFail
            });
            var uId_Khachhang = jo_GetSession("uId_Khachhang")
            var lbthetichdiem = document.getElementById("<%=lbthetichdiem.ClientID%>");
            var param_dt = "{'uId_Khachhang':'" + uId_Khachhang + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/SelectName";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        lbthetichdiem.innerHTML = msg.d;
                    }
                },
                error: onFail
            });
            txtSotiennhan.value = 0;
            txtGiamgiaPhieu.value = 0;
            txtGhichu.value = "";
            lblTienthua.innerHTML =0;
            lblTongtien.innerHTML = 0;
            lblConlai.innerHTML = 0;
            txtHH.value = 0;
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
            //if (jo_GetSession("uId_Phieudichvu") == "" || jo_GetSession("uId_Phieudichvu") == null) {
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
            //}
        }
        //Show popup danh sach phieu
        function ShowDSPhieuWindow() {
            client_dgvDanhsachphieu.Refresh();
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
        
        function OnSuccessCall(msg) {
            if (msg.d != "") {
                var defaultdata = msg.d.split("$");
                var checktt = defaultdata[11];
                var txtSoPhieu = document.getElementById("<%=txtSoPhieu.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien.ClientID%>");
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                var txtLydogiamgia = document.getElementById("<%=txtLydogiamgia.ClientID%>");
                var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                var txtHH = document.getElementById("<%=txtHH.ClientID%>");
                var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
                txtSoPhieu.value = defaultdata[0];
                var date_ngaylap = new Date(defaultdata[1]);    
                deNgaylap.SetDate(date_ngaylap);
                //date_ngaylap.SetEnabled(false);
                lblTongtien.innerHTML = jo_FormatMoney(jo_IsString(defaultdata[6]));
                txtGiamgiaPhieu.value = jo_IsString(defaultdata[3]);
                txtLydogiamgia.value = defaultdata[12];
                if (Number(defaultdata[7]) < 100) {
                    lbluutien.SetText(defaultdata[7] + " %");
                    lblConlai.innerHTML = jo_FormatMoney(jo_IsString(parseFloat(defaultdata[6])) - parseFloat(defaultdata[3]) - parseFloat(Number(defaultdata[7]) * defaultdata[6] / 100));
                    var f_Thucthu = (jo_IsString(parseFloat(defaultdata[6])) - parseFloat(defaultdata[3]) - parseFloat(Number(defaultdata[7]) * defaultdata[6] / 100));
                    if (checktt == "True") {
                        checkThanhtoan = 1;
                        txtSotiennhan.value = lblConlai.innerHTML;
                        lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(defaultdata[6]) - parseFloat(defaultdata[3]) - parseFloat(defaultdata[2]) - parseFloat(txtSotiennhan.value) - parseFloat(lblConlai.innerHTML))));
                    }
                    else {
                        checkThanhtoan = 0;
                        txtSotiennhan.value = lblConlai.innerHTML;
                        lblTienthua.innerHTML = 0;
                    }

                    if (defaultdata[4] != null && defaultdata[4] != "") {
                        ddlLoaithanhtoan.SetValue(defaultdata[4]);
                    }
                    txtGhichu.value = defaultdata[8];
                    txtHH.value = defaultdata[9];
                    ddlNhomphieu.SetValue(defaultdata[10]);
                    btnThanhtoan.SetEnabled(true);
                    var tienthua = jo_IsString(parseFloat(lblTienthua.innerHTML.replace(/,/g, "")));
                    if (tienthua < 0) {
                        lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
                    }
                    else {
                        lblTienthuatext.innerHTML = "Tiền khách nợ:";
                    }
                }
                else {
                    lbluutien.SetText(jo_FormatMoney(defaultdata[7]) + " VND");
                    lblConlai.innerHTML = jo_FormatMoney(jo_IsString(parseFloat(defaultdata[6])) - parseFloat(defaultdata[3]) - parseFloat(Number(defaultdata[7])));
                    var f_Thucthu = (jo_IsString(parseFloat(defaultdata[6])) - parseFloat(defaultdata[3]) - parseFloat(Number(defaultdata[7])));
                    txt_Doanhthu.value = jo_FormatMoney(roundToTwo(f_Thucthu));
                    if (checktt == "True") {
                        checkThanhtoan = 1;
                        txtSotiennhan.value = lblConlai.innerHTML;
                        lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(defaultdata[6]) - parseFloat(defaultdata[3]) - parseFloat(defaultdata[2]) - parseFloat(txtSotiennhan.value))));
                    }
                    else {
                        checkThanhtoan = 0;
                        txtSotiennhan.value = lblConlai.innerHTML;
                        lblTienthua.innerHTML = 0;
                    }

                    if (defaultdata[4] != null && defaultdata[4] != "") {
                        ddlLoaithanhtoan.SetValue(defaultdata[4]);
                    }
                    
                    txtGhichu.value = defaultdata[8];
                    txtHH.value = defaultdata[9];
                    ddlNhomphieu.SetValue(defaultdata[10]);
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
        }
        //function Round
        function roundToTwo(num) {
            return +(Math.round(num + "e+2") + "e-2");
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
            lblTienthua.innerHTML = (jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, ""))-parseFloat(jo_IsString(values[1])) )))).replace(/-/g,"");
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
        function ShowHideGiamgia_PX() {
            $("#popupDiscount_PX").toggle();
        };
        $(function () {
            $('#div_Giamgia_PX').click(function (e) {
                e.stopPropagation();
            });
        });
        $('html').click(function () {
            $("#popupDiscount_PX").hide();
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
                lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, ""))   - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")))));
                txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
                lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")))));
                document.getElementById("span_giamgia").innerHTML = "VNĐ";
                txtGiamgiaPhieu.value = jo_FormatMoney(txtGiamgiaPhieu.value.replace(/,/g, ""));
            }
            if (isphantramChecked) {
                lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, ""))  - (parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) * parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) / 100))));
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
        function onkeyupd_usd(id)
        {
            jo_ThousanSereprate(id);
            var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
            //Tao moi ma khach hang
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var txtusd = document.getElementById("<%=txtusd.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var pageUrl = "../../../../Webservice/nano_websv.asmx/Get_Usd";
            $.ajax({
                type: "POST",
                url: pageUrl,
               
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        txtSotiennhan.value = jo_FormatMoney(msg.d * txtusd.value);
                        lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(msg.d * txtusd.value.replace(/,/g, ""))))).replace(/-/g, "");
                        tienthua_Data = (parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")));
                        if (tienthua_Data > 0) {
                            lblTienthuatext.innerHTML = "Tiền khách nợ:";
                        }
                        else {
                            lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
                        }
                    }
                },
                error: onFail
            });
        }
        function onkeyup_txtsotiennhan(id) {
            jo_RemoveSession("uId_Khachhang_Goidichvu_TT");
            jo_ThousanSereprate(id);
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext.ClientID%>");
            tienthua_Data =(parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, "")));
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, ""))))).replace(/-/g,"");
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
        //function Inphieu(s, e) {
        //    if (jo_GetSession("uId_Phieudichvu") == null) {
        //        alert("Chưa chọn phiếu để in!");
        //    }
        //    else {
        //        var $dialog = $('<div></div>')
        //         .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rp_Phieudichvu.aspx?Luachon=Thanhtoan" width="850px" height="100%"></iframe>')
        //         .dialog({
        //             autoOpen: false,
        //             modal: true,
        //             height: 634,
        //             width: 855.733,
        //             title: "In phiếu dịch vụ",
        //             buttons: {
        //                 "Close": function () { $dialog.dialog('close'); }
        //             },
        //             close: function (event, ui) {
        //             }
        //         });
        //        $dialog.dialog('open');
        //    }
        //    return false;
        //}

        function InPhieuchung(s, e) {
            if (jo_GetSession("uId_Phieudichvu") == null) {
                alert("Chưa chọn phiếu để in!");
            }
            else {
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthuchi/rp_InHoadontonghop.aspx?Luachon=Phieudv" width="850px" height="100%"></iframe>')
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
            client_dgvDanhsachphieuno.Refresh();
            pcDanhsachno.Show();
            return false;
        }
        function Thietlaplieutrinh(uId_Dichvu, uId_Dichvu_chitiet) {
            jo_CreateSession("uId_Dichvu_Dieutri", uId_Dichvu);
            jo_CreateSession("uId_Dichvu_chitiet", uId_Dichvu_chitiet);
            jo_RemoveSession("uId_QT_Dieutri");
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
            client_dgvDsTheTT.Refresh();
            pcDsTheTT.Show();
            return false;
        }
        function KeKhaiTT(s, e) {
            var txtSophieu = document.getElementById("<%=txtSoPhieu.ClientID %>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            var lblSophieuTT = document.getElementById("<%=lblSophieuTT.ClientID%>");
            var txtSotiennhanTT = document.getElementById("<%=txtSotiennhanTT.ClientID%>");
            var txt_Sotien = document.getElementById("<%=txtSotienTT_Pop.ClientID%>");
            var txt_Maso = document.getElementById("<%=txtMaSoTT_Pop.ClientID%>");
            txt_Maso.value = "";
            txt_Sotien.value = 0;
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
                    if (phieudata[11] == "True") {
                        var uId_Dichvu = cb_Loaithe.GetValue();
                        var param_dt = "{'uId_Phieudichvu':'" + jo_GetSession("uId_Phieudichvu") + "','uId_Dichvu':'" + uId_Dichvu + "'}";
                        var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinTheByDichvu";
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
                                    var txtGiatri = document.getElementById("<%=txtGiatri.ClientID%>");
                                    var txt_Tongtien = jo_FormatMoney(jo_IsString(defaultdata[2]));
                                    var txtMavach = document.getElementById("<%=txtMavach.ClientID%>");
                                    var ltr_Error = document.getElementById("<%=ltrError.ClientID%>");
                                    var ltr_Success = document.getElementById("<%=ltrSuccess.ClientID%>");
                                    txtMavach.value = "";
                                    txt_Tongtien_The.SetValue(txt_Tongtien);
                                    $("#div_Error").html("");
                                    $("#div_Sucess").html("");
                                    txt_Uudai.SetValue("0");
                                    var hdfDongiathe = document.getElementById("<%=hdfDongiathe.ClientID%>");
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
           <%-- var pageUrl2 = "../../../../Webservice/nano_websv.asmx/CreateNewCodeGDV";
            $.ajax({
                type: "POST",
                url: pageUrl2,

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    var txtMavach = document.getElementById("<%=txtMavach.ClientID%>");
                    txtMavach.value = msg.d;
                },
                error: onFail
            });--%>
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
        function SelChanged_dsthe2(s, e) {
            if (!e.isSelected) {
            } else {
                client_dgvDsTheTT2.GetRowValues(e.visibleIndex, 'uId_Khachhang_Goidichvu;f_Giatrigoi;vMaBarcode', OnGridSelectionDSTheComplete2);
            }
        }
        function OnGridSelectionDSTheComplete2(values) {
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

            //txtSotiennhan.value = lblConlai.innerHTML;
            //tienthua_Data = parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(jo_IsString(values[1]))
            //lblTienthua.innerHTML = (jo_FormatMoney(jo_IsString((parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(jo_IsString(values[1])))))).replace(/-/g, "");
            //ddlLoaithanhtoan.SetValue("01d16c43-7a03-49dc-afd2-39e79a1439f1");
            //var tienthua = jo_IsString(parseFloat(lblTienthua.innerHTML.replace(/,/g, "")));
            //if (tienthua_Data > 0) {
            //    lblTienthuatext.innerHTML = "Tiền khách nợ:";
            //}
            //else {
            //    lblTienthuatext.innerHTML = "Số dư tài khoản:";
            //}
        }
        function ddlLoaithanhtoan_SelectedIndex(s, e) {
            var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan.ClientID%>");
            if (ddlLoaithanhtoan.GetValue() == "163d42af-840f-4877-9c26-b079cde2a636") {
                btnKekhai_client.SetEnabled(true);
                btnThanhtoanthe_client.SetEnabled(false);
            }
            else if (ddlLoaithanhtoan.GetValue() == "2391e70e-951c-40db-a985-4ba41f888bf9") {
                var pageUrl_p = "../../../../Webservice/nano_websv.asmx/CheckTK";
                $.ajax({
                    type: "POST",
                    url: pageUrl_p,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (parseFloat(msg.d) > 0) {
                            if (parseFloat(msg.d) - parseFloat(lblConlai.innerHTML.replace(/,/g, "")) >= 0) {
                                txtSotiennhan.value = jo_IsString(parseFloat(lblConlai.innerHTML.replace(/,/g, "")));
                            }
                            else {
                                txtSotiennhan.value = jo_FormatMoney(jo_IsString(parseFloat(msg.d)));
                                lblTienthua.innerHTML = jo_FormatMoney(parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(msg.d));
                            }
                        }
                        else {
                            alert("Thẻ tài khoản không có tiền để thanh toán!");
                            ddlLoaithanhtoan.SetValue("43915768-694a-49b8-8db2-6332718db194");
                        }
                    }
                });
            }
            else {
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

        function InPhieuCSbau(s, e) {
            var uId_Khachhang = jo_GetSession("uId_Khachhang")
            var uId_dichvu = jo_GetSession("uId_Khachhang")
            var $dialog = $('<div></div>')
               .html('<iframe style="border: 0px; " src="../../../OrangeVersion/Report/Rp_web/rp_Customer/rpt_Mother.aspx?uId_khachhang=' + uId_Khachhang + '?uId_Dichvu=' + uId_dichvu + ' width="850px" height="100%"></iframe>')
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
        
        function InPhieuCSsausinh(s, e) {
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
        // Thay doi thuc thu
        function ShowTheTT_HT() {
            client_dgvDsTheTT2.Refresh();
            pcDsTheTT2.Show();
            return false;
        }
        function SelectPopupTheTT2() {
            pcDsTheTT2.Hide();
            return false;
        }
        function ddlHinhthucTT_Pop_SelectedIndexChanged() {
            if (ddlHinhthucTT_Pop.GetValue().toString() != "01D16C43-7A03-49DC-AFD2-39E79A1439F1")
            {
                var txt_Sotien = document.getElementById("<%=txtSotienTT_Pop.ClientID%>");
                var txt_Maso = document.getElementById("<%=txtMaSoTT_Pop.ClientID%>");
                txt_Maso.value = "";
                txt_Sotien.value = 0;
            }
        }
      
        function txtSotiennhanTT_keyup() {
            var txt_Sotien = document.getElementById("<%=txtSotiennhanTT.ClientID%>");
            var f_Sotien = txt_Sotien.value.replace(/,/g, "");
            txt_Sotien.value = jo_FormatMoney(f_Sotien);
        }
        function txt_Uudai_NumberChanged() {
            var f_Uudai = txt_Uudai.GetValue();
            var txt_Giatri = document.getElementById("<%=txtGiatri.ClientID%>");
            var f_Giatri = txt_Giatri.value.replace(/,/g, "");
            var f_Tienkhuyenmai = parseFloat(f_Uudai) * parseFloat(f_Giatri) / 100;
            var f_Tongtien = parseFloat(f_Giatri) + parseFloat(f_Tienkhuyenmai);
            txt_Tongtien_The.SetValue(jo_FormatMoney(f_Tongtien));
        }
        function cb_Loaithe_SelectedIndexChanged() {
            var uId_Dichvu = cb_Loaithe.GetValue();
            var param_dt = "{'uId_Phieudichvu':'" + jo_GetSession("uId_Phieudichvu") + "','uId_Dichvu':'" + uId_Dichvu + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinTheByDichvu";
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
                        var txtGiatri = document.getElementById("<%=txtGiatri.ClientID%>");
                        var txt_Tongtien = jo_FormatMoney(jo_IsString(defaultdata[2]));
                        txt_Tongtien_The.SetValue(txt_Tongtien);
                        txt_Uudai.SetValue("0");
                        var hdfDongiathe = document.getElementById("<%=hdfDongiathe.ClientID%>");
                        txtGiatri.value = jo_FormatMoney(jo_IsString(defaultdata[2]));
                        hdfDongiathe.value = defaultdata[2];
                        jo_CreateSession("uId_Dichvu_The", defaultdata[3]);
                    }
                }
            })
        };
        function btnAddSP_Show() {
            pc_Export_Product.Show();
        }
        function UpdatePhieuxuat(s, e) {
            var txtSophieu = document.getElementById("<%=txtMaphieu.ClientID %>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID %>");
            var ddlLoaithanhtoanvalue = ddlLoaithanhtoan_PX.GetValue().toString();
            var ddlKhoValue = ddlDMKho.GetValue().toString();
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu_PX.ClientID%>");
            var ddlNhanvienvalue = ddlNhanvien_PX.GetValue().toString();
            var txtGhichu = document.getElementById("<%=txtGhichu_PX.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua_PX.ClientID%>");
            var isVNDChecked = rbGiamgiaVND.GetChecked();
            var isphantramChecked = rbGiamgiaphantram.GetChecked();
            var lblTongtien = document.getElementById("<%=lblTongtien_PX.ClientID%>");
            var lblconlai = document.getElementById("<%=lblConlai_PX.ClientID%>");
            var giamgia = "0";
            if (isVNDChecked) {
                giamgia = txtGiamgiaPhieu.value.replace(/,/g, "");
            }
            if (isphantramChecked) {
                giamgia = (parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) * parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) / 100);
            }
            var param_dt = "{'v_Sophieu':'" + txtSophieu.value + "','d_Ngay':'" + deNgayxuat.GetText() + "','f_Tongtienthuc':'" +
                txtSotiennhan.value.replace(/,/g, "") + "','tienthua':'" + tienthua + "','uId_LoaiTT':'" + ddlLoaithanhtoanvalue +
                "','f_Giamgia':'" + giamgia + "','uId_Nhanvien':'" + ddlNhanvienvalue + "','nv_Ghichu_vn':'" + txtGhichu.value +
                "','uId_Kho':'" + ddlKhoValue + "','f_Khachtra':'" + lblconlai.innerHTML.replace(/,/g, "") + "','i_Sothang':'" + txtsothang.GetText() + "','f_Giathang':'" + txtdongiathang.GetText().replace(/,/g, "") + "','b_Kedon':'" + cbkchike.GetChecked() + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/UpdatePhieuxuat";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    alert(msg.d);
                    btnThanhtoan_PX.SetEnabled(false);
                },
                error: onFail
            });
            return false;
        }
        var uId_Mathang = "";
        function SaveDetail(s, e) {
            var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
             if (uId_Mathang != "") {
                 var param_dt = "{'v_MaMathang':'" + uId_Mathang + "','f_Soluong':'" + txtSoluong.value + "', 'MaDonVi':'" + ddlDonvi.GetValue().toString() + "'}";
                 var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieuxuatchitiet";
                 $.ajax({
                     type: "POST",
                     url: pageUrl,
                     data: param_dt,
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (msg) {
                         if (msg.d == "Success") {
                             grid_Phieuxuat_Chitiet.Refresh();
                             uId_Mathang = "";
                             txtSoluong.value = "1";
                             //txtbarcode.SetText("");
                             ddlMathang.SetText("");
                             // khong dung barcode 
                             ddlMathang.Focus();
                             ddlMathang.PerformCallback();
                             var pageUrl_px = "../../../../Webservice/nano_websv.asmx/LoadThongTinPhieuXuatChuaThanhToan";
                             $.ajax({
                                 type: "POST",
                                 url: pageUrl_px,
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 async: false,
                                 success: OnSuccessCall_Phieuxuat,
                                 error: onFail
                             });
                         } else {
                             alert(msg.d);
                         }
                     },
                     error: onFail
                 });
             }
             else {
                 alert("Chọn mặt thuốc");
                 ddlMathang.Focus();
             }
        }
        function OnSuccessCall_Phieuxuat(msg) {
            alert(msg.d);
            if (msg.d != "") {
                var defaultdata = msg.d.split("$");
                var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu.ClientID%>");
                var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
                 var lblConlai = document.getElementById("<%=lblConlai.ClientID%>");
                var lblTongtien = document.getElementById("<%=lblTongtien_PX.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID%>");
                txtdongiathang.SetText(jo_FormatMoney(defaultdata[0]));
                var lblTongtien = document.getElementById("<%=lblTongtien_PX.ClientID%>");
                var lblConlai = document.getElementById("<%=lblConlai_PX.ClientID%>");
                var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID%>");
                lblTongtien.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                txtSotiennhan.value = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                lblConlai.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                var lblTienthua = document.getElementById("<%=lblTienthua_PX.ClientID%>");
                  lblTienthua.innerHTML = "0";
                
                

            }
        }
        function cbTenvattu_SelectChange(s, e) {
            jo_CreateSession("MaVatTu", ddlMathang.GetValue().toString());
            ddlDonvi.PerformCallback();
        }
        function txtGiathangKey(s, e) {
            if (isNaN(txtdongiathang.GetText().replace(/,/g, ""))) {
                return false;
            }
            else {
                var lblTongtien = document.getElementById("<%=lblTongtien_PX.ClientID%>");
                  var lblConlai = document.getElementById("<%=lblConlai_PX.ClientID%>");
                  var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID%>");
                  lblTongtien.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                  txtSotiennhan.value = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                  lblConlai.innerHTML = jo_FormatMoney(parseFloat(txtdongiathang.GetText().replace(/,/g, "")) * parseFloat(txtsothang.GetText()));
                  var lblTienthua = document.getElementById("<%=lblTienthua_PX.ClientID%>");
                lblTienthua.innerHTML = "0";
            }
        }
        function btnLuu_PX(s, e) {
            var b_Check = cbkchike.GetChecked();
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu_PX.ClientID%>");
             var sPara = ddlDMKho.GetValue() + "$" + ddlNhanvien.GetValue() + "$" + txtMaphieu.value + "$" + deNgayxuat.GetText() + "$" + txtGhichu.value + "$" + b_Check;
             var param_dt = "{'sPara':'" + sPara + "'}";
             var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertPhieuxuat";
             $.ajax({
                 type: "POST",
                 url: pageUrl,
                 data: param_dt,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (msg) {
                     if (msg.d != "") {
                         var data = msg.d.split("$");
                         if (data[0] == "2" || data[0] == "3") {
                             alert(data[1]);
                             ddlMathang.PerformCallback();
                             //txtbarcode.Focus();
                             ddlMathang.Focus();
                             return false;
                         }
                     }
                 },
                 error: onFail
             });
        }
        function btnLammoiClick(s, e) {

            uId_Mathang = "";
            //txtbarcode.SetText("");
            //ddlMathang.SetText("");
            //ddlDonvi.SetText("");
            btnThanhtoan_PX.SetEnabled(true);
            ddlKhachhang.Focus();
            grid_Phieuxuat_Chitiet.Refresh();
            jo_RemoveSession("uId_Phieuxuat");
            e.processOnServer = false;
            Create_Maphieu();
            var lblTongtien = document.getElementById("<%=lblTongtien_PX.ClientID%>");
            var lblConlai = document.getElementById("<%=lblConlai_PX.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID%>");
               lblTongtien.innerHTML = "0";
               txtSotiennhan.value = "0";
               lblConlai.innerHTML = "0";
               txtdongiathang.SetText("0");
               var lblTienthua = document.getElementById("<%=lblTienthua.ClientID%>");
              lblTienthua.innerHTML = "0";
        }
        function Create_Maphieu() {
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
             var param_dt = "{'sPara':'PX'}";
             var pageUrl = "../../../../Webservice/nano_websv.asmx/CreatePhieunhapxuatCode";
             $.ajax({
                 type: "POST",
                 url: pageUrl,
                 data: param_dt,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (msg) {
                     txtMaphieu.value = msg.d;
                 },
                 error: onFail
             });
        }
        function ddlMathang_Selectchange(s, e) {
            uId_Mathang = ddlMathang.GetValue().toString();
            ddlDonvi.PerformCallback();
            ddlDonvi.Focus();
        }
        function enter_ddlDonvi(e) {
            if (e.keyCode == 13) {
                var txtSoluong = document.getElementById("<%=txtSoluong.ClientID%>");
                txtSoluong.focus();
                ddlDonvi.SetSelectedIndex(0);
                return false;
            }
        }
        function grid_EndCallback_PX(s, e) {
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
        function onkeyup_txtsotiennhan_PX(id) {
            jo_ThousanSereprate(id);
            var lblConlai = document.getElementById("<%=lblConlai_PX.ClientID%>");
            var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID%>");
            var lblTienthua = document.getElementById("<%=lblTienthua_PX.ClientID%>");
            var lblTienthuatext = document.getElementById("<%=lblTienthuatext_PX.ClientID%>");
            tienthua = parseFloat(lblConlai.innerHTML.replace(/,/g, "")) - parseFloat(txtSotiennhan.value.replace(/,/g, ""));
            lblTienthua.innerHTML = jo_FormatMoney(jo_IsString(tienthua)).replace(/-/g, "");
            if (tienthua < 0) {
                lblTienthuatext.innerHTML = "Tiền thừa trả khách:";
            }
            else {
                lblTienthuatext.innerHTML = "Tiền khách nợ:";
            }
        }
        function onkeyup_giamgia_PX() {
                 var lblTongtien = document.getElementById("<%=lblTongtien_PX.ClientID%>");
                 var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu_PX.ClientID%>");
                 var lblConlai = document.getElementById("<%=lblConlai_PX.ClientID%>");
                 var txtSotiennhan = document.getElementById("<%=txtSotiennhan_px.ClientID%>");
                 var lblTienthua = document.getElementById("<%=lblTienthua_PX.ClientID%>");
                 var isVNDChecked = rbGiamgiaVND_PX.GetChecked();
                 var isphantramChecked = rbGiamgiaphantram_PX.GetChecked();
                 if (isVNDChecked) {
                     lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")))));
                     txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
                     lblTienthua.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(lblConlai.innerHTML.replace(/,/g, ""))) - parseFloat(jo_IsString(txtSotiennhan.value))));
                     document.getElementById("span_giamgia").innerHTML = "VNĐ";
                 }
                 if (isphantramChecked) {
                     lblConlai.innerHTML = jo_FormatMoney(jo_IsString((parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) - (parseFloat(txtGiamgiaPhieu.value.replace(/,/g, "")) * parseFloat(lblTongtien.innerHTML.replace(/,/g, "")) / 100))));
                     txtSotiennhan.value = jo_FormatMoney(jo_IsString(lblConlai.innerHTML.replace(/,/g, "")));
                     lblTienthua.innerHTML = jo_FormatMoney((parseFloat(jo_IsString(lblConlai.innerHTML.replace(/,/g, ""))) - parseFloat(jo_IsString(txtSotiennhan.value))));
                     document.getElementById("span_giamgia").innerHTML = "%";
                 }
                 return false;
        }

        function rbGiamgiaVND_Check_PX(s, e) {
            var txtGiamgiaPhieu = document.getElementById("<%=txtGiamgiaPhieu_PX.ClientID%>");
             txtGiamgiaPhieu.value = 0;
             $("#popupDiscount_PX").hide();
             var isVNDChecked = rbGiamgiaVND_PX.GetChecked();
             var isphantramChecked = rbGiamgiaphantram_PX.GetChecked();
             if (isVNDChecked) {
                 document.getElementById("span_giamgia").innerHTML = "VNĐ";
             }
             if (isphantramChecked) {
                 document.getElementById("span_giamgia").innerHTML = "%";
             }
        }
          function InPhieuDongY(s, e) {
              if (jo_GetSession("uId_Phieuxuat") == null) {
                  alert("Chưa chọn phiếu để in!");
              }
              else {
                  var $dialog = $('<div></div>')
                   .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/Rp_Phieuthanhtoan_Dongy.aspx" width="850px" height="100%"></iframe>')
                   .dialog({
                       autoOpen: false,
                       modal: true,
                       height: 634,
                       width: 855.733,
                       title: "In phiếu thanh toán",
                       buttons: {
                           "Close": function () { $dialog.dialog('close'); }
                       },
                       close: function (event, ui) {
                       }
                   });
                  pc_Export_Product.Hide();
                  $dialog.dialog('open');
              }
              return false;
          }
          function InPhieuTayY(s, e) {
              if (jo_GetSession("uId_Phieuxuat") == null) {
                  alert("Chưa chọn phiếu để in!");
              }
              else {
                  var $dialog = $('<div></div>')
                   .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/Rp_Phieuthanhtoan_TayY.aspx" width="850px" height="100%"></iframe>')
                   .dialog({
                       autoOpen: false,
                       modal: true,
                       height: 634,
                       width: 855.733,
                       title: "In phiếu thanh toán",
                       buttons: {
                           "Close": function () { $dialog.dialog('close'); }
                       },
                       close: function (event, ui) {
                       }
                   });
                  pc_Export_Product.Hide();
                  $dialog.dialog('open');
              }
              return false;
          }
          function InitPopupMenuHandler(s, e) {
              var imgButton = document.getElementById("<%=btnInSudung.ClientID%>");
              ASPxClientUtils.AttachEventToElement(imgButton, 'contextmenu', OnPreventContextMenu);
          }
          function OnGridContextMenu(evt) {
              ASPxPopupMenuClientControl.ShowAtPos(evt.clientX + ASPxClientUtils.GetDocumentScrollLeft(), evt.clientY + ASPxClientUtils.GetDocumentScrollTop());
              return OnPreventContextMenu(evt);
          }
          function OnPreventContextMenu(evt) {
              return ASPxClientUtils.PreventEventAndBubble(evt);
          }
          function menuItemClick(s, e) {
              if (e.item.name == "INHDSUDUNG") {
                  In_HD_Sudung();
              }
              else {
                  In_HD_DonThuoc();
              }
          }
          function In_HD_Sudung() {
              var $dialog = $('<div></div>')
              .html('<iframe style="border: 0px; " src="../../OrangeVersion/Report/Rp_web/Rp_Clinic/Rp_Huongdansudung.aspx?" width="1000px" height="100%"></iframe>')
              .dialog({
                  autoOpen: false,
                  modal: true,
                  height: 634,
                  width: 1000,
                  title: "In hướng dẫn dùng thuốc",
                  buttons: {
                      "Close": function () { $dialog.dialog('close'); }
                  },
                  close: function (event, ui) {
                  }
              });
              $dialog.dialog('open');
          }
          function In_HD_DonThuoc() {
              if (jo_GetSession("uId_Phieuxuat") == null) {
                  alert("Bạn chưa kê đơn thuốc!");
              }
              else {
            var $dialog = $('<div></div>')
           .html('<iframe style="border: 0px; " src="../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Indonthuoc.aspx?" width="1000px" height="100%"></iframe>')
           .dialog({
               autoOpen: false,
               modal: true,
               height: 634,
               width: 1000,
               title: "In hướng dẫn",
               buttons: {
                   "Close": function () { $dialog.dialog('close'); }
               },
               close: function (event, ui) {
               }
           });
                  $dialog.dialog('open');
              }
          }
        // in phieu option Kham or thanh toan
          function InitPopupMenuHandler2(s, e) {
              var imgButton = document.getElementById("<%=btnIn.ClientID%>");
            ASPxClientUtils.AttachEventToElement(imgButton, 'contextmenu', OnPreventContextMenu);
        }
        function OnGridContextMenu(evt) {
            ASPxPopupMenuClientControl.ShowAtPos(evt.clientX + ASPxClientUtils.GetDocumentScrollLeft(), evt.clientY + ASPxClientUtils.GetDocumentScrollTop());
            return OnPreventContextMenu(evt);
        }
        function OnPreventContextMenu(evt) {
            return ASPxClientUtils.PreventEventAndBubble(evt);
        }
        function Test(s, e) {
            var x = ASPxClientUtils.GetEventX(e.htmlEvent);
            var y = ASPxClientUtils.GetEventY(e.htmlEvent);
            pmRowMenu.ShowAtPos(x, y);
            //pmRowMenu.Show();

        }
        function menuItemClick2(s, e) {
            if (e.item.name == "phieukham") {
                InPhieuKham();
            }
            else if (e.item.name == "thanhtoan") {
                InPhieuThanhToan();
            }
            else if (e.item.name == "dieutri") {
                InPhieuDieuTri();
            }
        }
        function InPhieuKham() {
            if (jo_GetSession("uId_Phieudichvu") == null) {
                alert("Chưa chọn phiếu để in!");
            }
            else if (checkThanhtoan === 0) {
                alert("Phiếu chưa được thanh toán");
            }
            else{
                var $dialog = $('<div></div>')
             .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Print.aspx?type=phieukham" width="850px" height="100%"></iframe>')
             .dialog({
                 autoOpen: false,
                 modal: true,
                 height: 634,
                 width: 855.733,
                 title: "In phiếu Khám",
                 buttons: {
                     "Close": function () { $dialog.dialog('close'); }
                 },
                 close: function (event, ui) {
                 }
             });
                $dialog.dialog('open');
                return false;
            }
        }
        function InPhieuThanhToan() {
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
                     title: "In phiếu thanh toán dịch vụ",
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
        //in don thuoc
        function InDonThuoc(s, e) {
            var donthuoc = jo_GetSession("uId_Phieuxuat")
            if (donthuoc = null) {
                alert("Hãy chọn đơn thuốc");
                return;
            }
            else {
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Print.aspx?type=donthuoc" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 855.733,
                     title: "In Đơn Thuốc",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                         pc_Export_Product.Show;
                     }
                 });
                pc_Export_Product.Hide();
                $dialog.dialog('open');
                
                return false;
            }
        }
        //in phieu dieu tri
        function InPhieuDieuTri(s, e) {
            var donthuoc = jo_GetSession("uId_Phieuxuat")
            if (donthuoc = null) {
                alert("Hãy chọn đơn thuốc");
                return;
            }
            else {
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Clinic/rp_Print.aspx?type=dieutri" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 634,
                     width: 855.733,
                     title: "In phiếu điều trị",
                     buttons: {
                         "Close": function () { $dialog.dialog('close'); }
                     },
                     close: function (event, ui) {
                         pc_Export_Product.Show;
                     }
                 });
                pc_Export_Product.Hide();
                $dialog.dialog('open');

                return false;
            }
        }
    </script>
    <div class="brest_crum">
        <dx:ASPxButton ID="btnQuaylai" Style="float: left; margin-right: 7px; margin-left: 5px" Image-Url="~/images/16x16/back.png" ClientInstanceName="btnQuaylai" AutoPostBack="false" runat="server" Text="Quay lại">
            <ClientSideEvents Click="BackQuanLyKhachHang" />
        </dx:ASPxButton>
        <asp:Literal ID="ltrTitleHeader" Text="THÊM PHIẾU DỊCH VỤ" runat="server"></asp:Literal>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin phiếu</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Số phiếu:
                    </td>
                    <td class="info_table_td">
                        <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtSoPhieu"></asp:TextBox>
                    </td>
                    <td class="info_table_td">Ngày lập:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deNgaylap" UseMaskBehavior="true" ClientInstanceName="deNgaylap" Width="200px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                            <ClientSideEvents DateChanged="deNgaplapChange" />
                        </dx:ASPxDateEdit>
                    </td>
                    <td rowspan="2" class="info_table_td hiddenipad">
                        <dx:ASPxButton ID="btnDSPhieu" Image-Url="~/images/16x16/page.png" AutoPostBack="false" ClientInstanceName="btnDSPhieu" runat="server" Text="Xem phiếu">
                            <ClientSideEvents Click="function(s, e) { ShowDSPhieuWindow(); }" />
                        </dx:ASPxButton>
                    </td>
                    <td rowspan="2" class="info_table_td hiddenipad">
                        <dx:ASPxButton ID="btnDSNo" Image-Url="~/images/16x16/money_dollar.png" ClientInstanceName="btnDSNo" AutoPostBack="false" runat="server" Text="Xem công nợ">
                            <ClientSideEvents Click="OpenPopupDSNo" />
                        </dx:ASPxButton>
                    </td>
                    <%-- jolieD --%>
                    <td rowspan="2" class="info_table_td hiddenipad">
                        <dx:ASPxButton ID="btnInphieuchung" Image-Url="~/images/16x16/printer.png" ClientInstanceName="btninphieuchung" AutoPostBack="false" runat="server" Text="In phiếu chung">
                            <ClientSideEvents Click="InPhieuchung" />
                        </dx:ASPxButton>
                    </td>
                    <%-- harumy --%>
    <%--                 <td rowspan="2" class="info_table_td hiddenipad">
                        <dx:ASPxButton ID="btnInphieuchung" Image-Url="~/images/16x16/printer.png" Visible="false" ClientInstanceName="btninphieuchung" AutoPostBack="false" runat="server" Text="Phiếu chăm sóc bầu">
                            <ClientSideEvents Click="InPhieuCSbau" />
                        </dx:ASPxButton>
                    </td>--%>
                    <td rowspan="2" class="info_table_td hiddenipad">
                        <dx:ASPxButton ID="btnInphieusausinh" Image-Url="~/images/16x16/printer.png" Visible="false" ClientInstanceName="btninphieuchung" AutoPostBack="false" runat="server" Text="Phiếu chăm sóc sau sinh">
                            <ClientSideEvents Click="InPhieuCSsausinh" />
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Khách hàng:
                    </td>
                    <td class="info_table_td">
                        <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtHoten"></asp:TextBox>
                    </td>
                    <td class="info_table_td">Nhân viên lập:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlNhanvien" ClientInstanceName="ddlNhanvien" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <div style="clear: both"></div>
    <div class="bill_infor">
        <fieldset class="field_dsphieu">
            <legend><span style="font-weight: bold; color: green">Danh sách dịch vụ</span></legend>
            <asp:HiddenField ID="hdfuIdDichvu" runat="server" />
            <asp:HiddenField ID="hdfGiamgiaDV" runat="server" />
            <asp:HiddenField ID="hdfTienDV" runat="server" />
            <dx:ASPxGridView ID="dgvDevexpress" runat="server" ClientInstanceName="client_grid" CssClass="grid_dm_dv"
                AutoGenerateColumns="false" OnDataBound="dgvDevexpress_DataBound" KeyFieldName="uId_Dichvu" SettingsPager-PageSize="8"
                SettingsPager-Position="Bottom">
                <Columns>
                    <dx:GridViewCommandColumn Width="30px" ShowSelectCheckbox="True" Visible="true" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Dichvu"
                        Name="uId_Dichvu">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="vType"
                        Name="vType">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Width="100px" Caption="Nhóm dịch vụ" FieldName="nv_TennhomDichvu_vn"
                        Name="nv_TennhomDichvu_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"
                        Name="nv_Tendichvu_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Width="70px" Caption="Giá" FieldName="f_Gia"
                        Name="f_Gia">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                        HeaderStyle-HorizontalAlign="Center" Caption="% Giảm" Width="50px" FieldName="f_phantramGiamgia"
                        Name="f_phantramGiamgia">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="50px" VisibleIndex="2" Visible="false" Caption="Số lần" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" FieldName="i_Solan_Dieutri" Name="i_Solan_Dieutri">
                    </dx:GridViewDataTextColumn>
                      <dx:GridViewDataTextColumn Width="100px" VisibleIndex="2" Visible="True" Caption="Số phút thực hiện" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" FieldName="f_Sophutthuchien" Name="f_Sophutthuchien">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsEditing Mode="Inline" />
                <SettingsPager PageSize="12">
                </SettingsPager>
                <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                    </AlternatingRow>
                    <GroupRow Font-Bold="true"></GroupRow>
                </Styles>
            </dx:ASPxGridView>
        </fieldset>
        <fieldset class="field_thanhtoan">
            <legend><span style="font-weight: bold; color: green">Thông tin thanh toán </span></legend>
            <div class="box_thanhtoan" style="min-height: 174px;">
                <dx:ASPxGridView ID="dgvPhieuchitiet" runat="server" ClientInstanceName="client_Phieuchitiet"
                    AutoGenerateColumns="false" KeyFieldName="uId_Phieudichvu_Chitiet;uId_Dichvu;nv_Tendichvu_vn" CssClass="grid_dm_dv" SettingsPager-PageSize="3"
                    SettingsPager-Position="Bottom" OnRowDeleting="dgvPhieuchitiet_RowDeleting" OnDataBinding="dgvPhieuchitiet_DataBinding" OnRowUpdating="dgvPhieuchitiet_RowUpdating" Width="100%">
                    <Columns>
                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                            Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Dichvu"
                            Name="uId_Dichvu">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"
                            Name="nv_Tendichvu_vn">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Lần đã ĐT" Width="70px" FieldName="i_SL_daDieutri"
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
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Thành tiền" Width="80px" FieldName="f_Thanhtien"
                            Name="f_Thanhtien">
                        </dx:GridViewDataTextColumn>

                      <%--  <dx:GridViewDataColumn Width="60px" FieldName="f_Giamgia" VisibleIndex="1" Caption="Giảm giá" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <%#Eval("f_Giamgia", "{0:0,0}")%>
                            </DataItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGiamgia" Width="60px" Text='<%# Eval("f_Giamgia")%>'
                                    runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </dx:GridViewDataColumn>--%>
                        <dx:GridViewDataComboBoxColumn FieldName="nv_Tenchuongtrinh_vn" Width="100px" Caption="CT Ưu đãi " VisibleIndex="1">
                               <EditItemTemplate>
                                <dx:ASPxComboBox ID="uId_Sale" runat="server"
                                    ValueField="uId_Sale"
                                    TextField="nv_Tenchuongtrinh_vn"   HeaderStyle-HorizontalAlign="Center" IncrementalFilteringMode="Contains" OnInit="uId_Sale_Init">
                                </dx:ASPxComboBox>
                            </EditItemTemplate>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="f_Giamgia_KM" Name="f_Giamgia_KM" Width="100px" Caption="Giá trị ưu đãi" VisibleIndex="1"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"
                           >
                          <PropertiesTextEdit DisplayFormatString="{0:0,0}"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                          <dx:GridViewDataTextColumn Visible="True" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Width="80px" Caption="Tặng buổi" FieldName="f_Sobuoitang"
                            Name="f_Sobuoitang" ReadOnly="false" >
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn Visible="True" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Width="130px" Caption="Tổng số buổi điều trị" FieldName="f_Solan"
                            Name="f_Solan"  >
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Thành tiền sau KM" Width="120px" FieldName="f_Tongtien"
                            Name="f_Tongtien">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                               <%--<a id="popup" title="In công đoạn" href='javascript:void(0)' onclick="return Thietlaplieutrinh('<%#Eval("uId_Dichvu") %>')">
                                    <img src="../../images/16x16/printer.png" /></a>--%>
                                <a id="popup2" title="In công đoạn" href='javascript:void(0)' onclick="return Incongdoan('<%#Eval("uId_Phieudichvu_Chitiet") %>')">
                                    <img src="../../images/16x16/printer.png" /></a>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)' onclick="return Thietlaplieutrinh('<%#Eval("uId_Dichvu") %>','<%#Eval("uId_Phieudichvu_Chitiet")  %>')">
                                    <img src="../../../images/bub.png" /></a>
<%--                                <a id="popup2" title="In công đoạn" href='javascript:void(0)' onclick="return Incongdoan('<%#Eval("uId_Phieudichvu_Chitiet") %>')">
                                    <img src="../../../images/bub.png" /></a>--%>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewCommandColumn VisibleIndex="5" Width="30px" ButtonType="Image">
                            <CancelButton>
                                <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                            </CancelButton>
                            <UpdateButton Visible="false">
                                <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                            </UpdateButton>
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Delete" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Delete">
                                    <Image AlternateText="Delete" Url="~/images/btn_Delete.png">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                    </Columns>
                    <SettingsEditing Mode="Inline" />
                    <SettingsPager PageSize="3">
                    </SettingsPager>
                    <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" HorizontalScrollBarMode="Visible" VerticalScrollBarMode="Auto"/>
                    <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                    <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                    <ClientSideEvents CustomButtonClick="OnCustomButtonClick" EndCallback="gridPhieuchitiet_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_chitiet(s, e); }" />
                    <Styles>
                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                        </AlternatingRow>
                    </Styles>
                    <SettingsText EmptyDataRow="Không có dịch vụ nào trong phiếu!" />
                </dx:ASPxGridView>
                <div class="box_huy" id="box_huy" style="display: none">
                    <span style="color: Red; margin-left: 45px">Phiếu đã thanh toán! Xin vui lòng cho biết lí do xóa</span>
                    <asp:TextBox ID="txtLidoxoa" Width="225px" placeholder="Nhập lí do xóa" CssClass="nano_textbox" runat="server"></asp:TextBox>
                    <dx:ASPxButton ID="btnLidoxoa" OnClick="btnLidoxoa_Click" Image-Url="~/images/btn_Delete.png" Style="float: right; margin-left: 10px; position: relative; bottom: 6px" ClientInstanceName="btnLidoxoa" runat="server" Text="Hủy">
                    </dx:ASPxButton>
                </div>
            </div>
            <div class="box_thanhtoan" style="min-height: 350px;">
              
                            <ul style="float:left">
                            <li class="text_title" style ="color:red">Ưu đãi TTV:</li>
                            <li class="text_title" style="padding-left:25px">
                                <dx:ASPxLabel runat="server" ID="lblUutien" ClientInstanceName="lbluutien" Width="30px"></dx:ASPxLabel>
                            </li>
                            <li class="text_title"   style ="color:red;padding-left:70px;">Mức thẻ hiện tại là :</li>
                            <li class="text_title" style ="color:green;font-weight:bold;">
                                <asp:Label ID="lbthetichdiem" runat="server" Text="Thẻ vàng" Width="60px"></asp:Label></li>
   
                          </ul>
                          
                        <ul style="float:left">
                            <li class="text_title">Tổng tiền:
                            </li>
                            <li class="text_title" style="padding-left:38px;">
                                <asp:Label ID="lblTongtien" runat="server" Text="0,000,000" Width="50px" ></asp:Label>
                            </li>
                            <li class="text_title" style="width:100px;padding-left:50px;">Tiền khách trả:
                            </li>
                            <li class="text_title" style="padding-left:18px">
                                    <asp:TextBox ID="txtusd" Width="50px"  CssClass="nano_textbox" placeholder="USD" onkeyup="return onkeyupd_usd(this)"  runat="server" Style="float:left"></asp:TextBox>
                            </li>
                            <li class="text_title">
                                      <asp:TextBox runat="server" Width="118px" onkeyup="return onkeyup_txtsotiennhan(this)" placeholder="VND" CssClass="nano_textbox" ID="txtSotiennhan" Style="float:left"></asp:TextBox>
                            </li>
                            <li class="text_title">
                                 <dx:ASPxButton ID="btnThanhtoanthe" Image-Url="~/images/16x16/card_discover_black.png" AutoPostBack="false" Width="95px" Style="float: left; margin-left:2px;padding-top:20px;" ClientInstanceName="btnThanhtoanthe_client" runat="server" Text="Thẻ">
                                     <ClientSideEvents Click="ShowTheTT" />
                                    </dx:ASPxButton>
                            </li>
                        </ul>
                        <ul style="float:left">
                            <li class="text_title">Giảm giá phiếu:
                            </li>
                            <li class="text_title" style="position: relative;padding-left:6px;">
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
                            </li>
                            <li class="text_title" style="padding-left:13px">
                                <asp:Label ID="lblTienthuatext" Text="Tiền thừa trả khách:" runat="server" Width="118px"></asp:Label>
                            </li>
                            <li class="text_title">
                                <asp:Label ID="lblTienthua" runat="server" Text="0,000,000"></asp:Label>
                            </li>
                        </ul>
                        <ul style="float:left">
<%--                            <li class="text_title">
                                <dx:ASPxLabel ID="lblTonthanhtoan" runat ="server" Text="Tổng thanh toán:" Font-Size="13px"></dx:ASPxLabel>
                            </li>--%>
                            <li class="text_title">
                                <asp:Label ID="lblTongthanhtoan" runat="server" Text="Tổng thanh toán" Width="94px"></asp:Label>
                            </li>
                            <li class="text_title" style="padding-left:2px;">
                                <asp:Label ID="lblConlai" runat="server" Text="0,000,000" Width="50px"></asp:Label>
                            </li>
                            <li class="text_title" style="padding-left:52px;">Hình thức TT:
                            </li>
                            <li class="text_title" style="padding-left:35px">
                                <dx:ASPxComboBox ID="ddlLoaithanhtoan" ClientInstanceName="ddlLoaithanhtoan" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="192px" runat="server" ValueType="System.String">
                                    <ClientSideEvents SelectedIndexChanged="ddlLoaithanhtoan_SelectedIndex" ButtonClick="loaddata"/>
                                </dx:ASPxComboBox>
                            </li>
                            <li class="text_title" style="padding-left:0px;">
                                <dx:ASPxButton ID="btnKekhaiHT" Image-Url="~/images/16x16/pencil_add.png" AutoPostBack="false" Style="float: left;" Width="95px" ClientInstanceName="btnKekhai_client" runat="server" Text="Kê khai">
                                    <ClientSideEvents Click="KeKhaiTT" />
                                </dx:ASPxButton>
                            </li>
                        </ul>
                        <ul style="float:left">
                            <li class="text_title">Lý do giảm giá:
                            </li>
                            <li  class="text_title" style="padding-left:5px">
                                <asp:TextBox TextMode="MultiLine" runat="server" Width="487px" Height="17px" CssClass="nano_textbox" ID="txtLydogiamgia"></asp:TextBox>
                            </li>
                        </ul>
                        <ul style="float:left">
                            <li class="text_title">Lý do khám:
                            </li>
                            <li  class="text_title" style="padding-left:5px">
                                <asp:TextBox TextMode="MultiLine" runat="server" Width="487px" Height="17px" CssClass="nano_textbox" ID="txtGhichu"></asp:TextBox>
                            </li>
                        </ul>
                   
                         <ul style="float:left;padding-left:300px;" >
                            <li class="text_title" style="text-align: right">
                                <asp:LinkButton ID="lbtReadmore" OnClientClick="return ReadMore()" runat="server" Text="Hiển thị thêm"></asp:LinkButton>
                            </li>
                        </ul>
                        <ul id="readmore" style="display: none;float:left;padding-left:100px;">
                            <li class="text_title">HH phiếu (%):
                            </li>
                            <li class="text_title">
                                <asp:TextBox runat="server" onkeyup="return onkeyup_giamgia()" Width="57px" CssClass="nano_textbox" ID="txtHH"></asp:TextBox>
                            </li>
                            <li class="text_title">Nhóm phiếu:
                            </li>
                            <li class="text_title" >
                                <dx:ASPxComboBox ID="ddlNhomphieu" ClientInstanceName="ddlNhomphieu" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="188px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                            </li>
                        </ul>
                        <ul style="float:left">
                            <li class="text_title">
                                <dx:ASPxButton ID="btnThanhtoan" Image-Url="~/images/16x16/coins_in_hand.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnThanhtoan" runat="server" Text="Thanh toán (F2)">
                                    <ClientSideEvents Click="UpdatePhieuDV" />
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="btnIn" AutoPostBack="false" Image-Url="~/images/16x16/printer.png" Style="float: left; margin-left: 10px" ClientInstanceName="btnIn" runat="server" Text="In (F4)">
                                    <%--<ClientSideEvents Click="Inphieu" />--%>
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="btnPhieumoi" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnPhieumoi" runat="server" Text="Phiếu mới (F9)">
                                    <ClientSideEvents Click="ClearPhieuDichVu" />
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="btnAddSP" Image-Url="~/images/16x16/medical.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnAddSP" runat="server" Text="Kê đơn thuốc">
                                    <ClientSideEvents Click="btnAddSP_Show" />
                                </dx:ASPxButton>
                                  <dx:ASPxButton ID="btnInSudung" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnInSudung" runat="server" Text="In hướng dẫn">
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="btnCapthe" Image-Url="~/images/16x16/card_front.png" ClientVisible="false" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnCapthe" runat="server" Text="Cấp thẻ">
                                    <ClientSideEvents Click="Capthe" />
                                </dx:ASPxButton>
                            </li>
                        </ul>
<%--                <table class="info_table">
                    <tbody>
                    </tbody>
                </table>--%>
            </div>
        </fieldset>
    </div>
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
                           <%-- <dx:ASPxButton ID="btnRefreshDSPhieu" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Tải lại" Style="float: left; margin-right: 8px">
                                <ClientSideEvents Click="Refresh_pcDanhsachphieu" />

                                <Image Url="~/images/16x16/refresh.png"></Image>
                            </dx:ASPxButton>--%>
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
                                            <Image AlternateText="Delete" Url="~/images/btn_Delete.png"/>
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
                                            <a id="popup" title="Thanh toán phiếu <%#Eval("v_Sophieu") %>" href='javascript:void(0)' onclick="return ClosePopup()">
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
                                <ClientSideEvents />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                                <SettingsText EmptyDataRow="Khách hàng không có phiếu nợ nào!" />
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
                            <div >
<%--                                <dx:ASPxButton ID="btn_Restart" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Tải lại">
                                    <ClientSideEvents Click="Refresh_DSTheTT" />
                                </dx:ASPxButton>--%>
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
                                        HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" Width="130px" FieldName="b_Kichhoat"
                                        Name="b_Kichhoat">
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
                                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged_dsthe(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                                <SettingsText EmptyDataRow="Khách hàng chưa mua thẻ thanh toán nào!" />
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
    <dx:ASPxPopupControl ID="pcDsTheTT2" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDsTheTT2"
        HeaderText="Danh sách thẻ" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcDsTheTT.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server">
                <dx:ASPxPanel ID="ASPxPanel6" runat="server" Width="900px" Height="370px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent7" runat="server">
                            <div style="clear: both"></div>
                            <div>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Visible="false" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Tải lại">
                                    <ClientSideEvents Click="Refresh_DSTheTT" />
                                </dx:ASPxButton>
                            </div>
                            <dx:ASPxGridView ID="DSTHE2" runat="server" OnDataBinding="dgvDsTheTT_DataBinding_DSTHE2" ClientInstanceName="client_dgvDsTheTT2"
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
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Chọn thẻ" href='javascript:void(0)' onclick="return SelectPopupTheTT2()">
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
                                <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_dsthe2(s, e); }" />
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
                                                <td class="info_table_td">Loại thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox runat="server" TextFormatString="{0}"  ID="cb_Loaithe" OnCallback="cb_Loaithe_Callback" ValueField="uId_Dichvu" ClientInstanceName="cb_Loaithe" Width="200px"> 
                                                        <Columns>
                                                            <dx:ListBoxColumn Caption="Tên thẻ" FieldName="nv_Tendichvu_vn"/>
                                                            <dx:ListBoxColumn Caption="Đơn giá" FieldName="f_Gia" /> 
                                                        </Columns>
                                                        <ClientSideEvents SelectedIndexChanged="cb_Loaithe_SelectedIndexChanged"/>
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td"> Seri thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtMavach"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Giá trị thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtGiatri"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td"> Ưu đãi :</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxSpinEdit runat="server" ID="txt_Uudai" ClientInstanceName="txt_Uudai" MinValue="0" MaxValue="100" Width="200px">
                                                        <ClientSideEvents NumberChanged="txt_Uudai_NumberChanged" />
                                                    </dx:ASPxSpinEdit>
                                                </td>
                                                <td class="info_table_td">Giá trị sử dụng :</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox runat="server" ID="txt_Tongtien_The" ClientInstanceName="txt_Tongtien_The" AutoPostBack="false" Width="200px"> </dx:ASPxTextBox>
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
                                                    <div id="div_Error">
                                                          <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                    </div>
                                                  
                                                    <div id="div_Sucess">
                                                         <asp:Literal ID="ltrSuccess" runat="server"></asp:Literal>
                                                    </div>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btLuuthe" Image-Url="~/images/btn_Save.png" ClientInstanceName="btLuuthe" OnClick="btLuuthe_Click" runat="server" Text="Lưu (F4)" Style="float: left; margin-right: 8px">
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
        HeaderText="Kê khai hình thức" AllowDragging="True" PopupAnimationType="None">
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
                                                    <asp:TextBox runat="server" Width="200px" onkeyup="return txtSotiennhanTT_keyup()"  CssClass="nano_textbox" ID="txtSotiennhanTT"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Hình thức TT:
                                                </td>
                                                <td class="info_table_td" colspan="2">
                                                    <dx:ASPxComboBox ID="ddlHinhthucTT_Pop" ClientInstanceName="ddlHinhthucTT_Pop" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String">
                                                        <ClientSideEvents SelectedIndexChanged="ddlHinhthucTT_Pop_SelectedIndexChanged" />
                                                    </dx:ASPxComboBox>
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
                                                    <ClientSideEvents Click="ShowTheTT_HT" />
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
    <dx:ASPxPopupControl ID="pcnhanvien" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcnhanvien"
        HeaderText="Kỹ thuật viên tư vấn" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcnhanvien.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server">
                <dx:ASPxPanel ID="ASPxPanel5" runat="server" Width="450px" Height="100px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent6" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div style="clear: both"></div>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Nhân viên</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Tên nhân viên :</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="cbokythuatvien" ClientInstanceName="cbokythuatvien" Width="200px" runat="server" ValueType="System.String">
                                                        
                                                    </dx:ASPxComboBox>
                                                    
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxButton ID="btnchon" AutoPostBack="false" Image-Url="~/images/btn_Detail.png" runat="server" Text="Chọn">
                                                        <ClientSideEvents Click="ddlkythuatvien" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="0" DynamicLayout="false">
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
       <dx:ASPxPopupControl ID="pc_Export_Product" runat="server" CloseAction="OuterMouseClick" Modal="True"
          PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pc_Export_Product"
          HeaderText="Export Product" AllowDragging="True" PopupAnimationType="None">
          <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                <dx:ASPxPanel ID="ASPxPanel7" runat="server" Width="1280px" Height="500px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent8" runat="server">
                                        <div class="brest_crum">
        <dx:ASPxButton ID="ASPxButton3" Visible="false" Style="float: left; margin-right: 7px; margin-left: 5px" Image-Url="~/images/16x16/back.png" ClientInstanceName="btnQuaylai" AutoPostBack="false" runat="server" Text="Quay lại">
            <ClientSideEvents Click="BackPhieuChoThanhToan" />
        </dx:ASPxButton>
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>KÊ ĐƠN THUỐC</p>
        </div>
        <div style="clear: both"></div>
        <div class="div_box">
            <fieldset class="field_tt" style="float:left; margin-right: 10px;min-height:150px">
                <legend><span style="font-weight: bold; color: green">Thông tin đơn thuốc</span></legend>
                <table class="info_table">
                    <tbody>
                        <tr>
                        <td class="info_table_td">Kho xuất:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlDMKho" ClientInstanceName="ddlDMKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td">Số đơn thuốc:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtMaphieu" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                    </tr>
                  <tr>
                        <td class="info_table_td">Bệnh nhân:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlKhachhang" EnableCallbackMode="true" ClientInstanceName="ddlKhachhang" runat="server" CallbackPageSize="10"
                                IncrementalFilteringMode="Contains" ValueField="uId_Khachhang" ValueType="System.String" TextFormatString="{0}-{1}-{2}-{3}"
                                Width="200px" DropDownWidth="500px" DropDownStyle="DropDown">
                                <Columns>
                                    <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã" />
                                    <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Họ tên" />
                                    <dx:ListBoxColumn FieldName="nv_Diachi_vn" Caption="Địa chỉ" />
                                    <dx:ListBoxColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" />
                                </Columns>
           <%--                     <ClientSideEvents SelectedIndexChanged="cbKhachhang_SelectChange" />--%>
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td">Ngày xuất:
                        </td>
                         <td class="info_table_td">
                            <dx:ASPxDateEdit ID="deNgayxuat" ClientInstanceName="deNgayxuat" Style="float: left; margin-right: 8px;" Width="100px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                runat="server">
                            </dx:ASPxDateEdit>
                            <dx:ASPxCheckBox ID="chkChike" ClientInstanceName="cbkchike" runat="server" Text="Chỉ kê"></dx:ASPxCheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Bác sĩ lập:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlNhanvien_PX" ClientInstanceName="ddlNhanvien_PX" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="200px" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                         <td class="info_table_td">Số thang:
                        </td>
                        <td class="info_table_td">
                           <dx:ASPxTextBox runat="server" ID="txtSothang"  onkeyup="txtGiathangKey()" ClientInstanceName="txtsothang" Width="200px" Text="1">
                           </dx:ASPxTextBox>
                        </td>        
                    </tr>
                    <tr>
                        <td class="info_table_td">Ghi chú:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtGhichu_PX" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td class="info_table_td"> Đơn giá thang</td>
                        <td class="info_table_td">
<%--                            <dx:ASPxCheckBox runat="server" ID="chkGia" ClientInstanceName="chkgia" style="float:left; padding-right:10px">
                                <ClientSideEvents CheckedChanged="chkgiachange" />
                            </dx:ASPxCheckBox>--%>
                            <dx:ASPxTextBox runat="server" onkeyup="txtGiathangKey()" Width="200px" Enabled="false" ClientInstanceName="txtdongiathang" style="float:left"  ID="txtDongiathang" MaskSettings-Mask="<0..9999999999g>">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td" colspan="4">
                            <dx:ASPxButton ID="btnClear" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 20px" ClientInstanceName="btnClear" runat="server" Text="Refresh">
                                <ClientSideEvents Click="btnLammoiClick" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnLuu" ClientInstanceName="btnLuu" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Save">
                                <ClientSideEvents Click="btnLuu_PX" />
                                <Image Url="~/images/16x16/save.png"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnDanhsach" Visible="false" ClientInstanceName="btnDanhsach" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Votes list product">
                                <Image Url="~/images/16x16/table.png"></Image>
                                <ClientSideEvents Click="ShowDSPopup" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
            <fieldset class="field_tt" style="min-height: 150px;float:left;">
                <legend><span style="font-weight: bold; color: green">Thông tin thanh toán</span></legend>
                <table class="info_table">
                    <tbody>
                        <tr>
                            <td class="info_table_td">Tổng tiền:
                            </td>
                            <td class="info_table_td">
                                <asp:Label ID="lblTongtien_PX" runat="server" Text="0,000,000"></asp:Label>
                            </td>
                            <td class="info_table_td">Số tiền nhận:
                            </td>
                            <td class="info_table_td">
                                <asp:TextBox ID="txtSotiennhan_px" onkeyup="return onkeyup_txtsotiennhan_PX(this)" Width="186px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_table_td">Giảm giá:
                            </td>
                            <td class="info_table_td" style="position: relative">
                                <div id="div_Giamgia_PX">
                                    <asp:TextBox runat="server" onkeyup="return onkeyup_giamgia_PX()" onfocus="ShowHideGiamgia_PX()" Width="57px" CssClass="nano_textbox" ID="txtGiamgiaPhieu_PX"></asp:TextBox>
                                    <span id="span1">VNĐ</span>
                                    <div id="popupDiscount_PX">
                                        <dx:ASPxRadioButton Style="float: left" ClientInstanceName="rbGiamgiaVND_PX" Checked="true" ID="rbGiamgiaVND_PX" runat="server" GroupName="rbthanhtoan" Text="VNĐ">
                                            <ClientSideEvents CheckedChanged="rbGiamgiaVND_Check_PX" />
                                        </dx:ASPxRadioButton>
                                        <dx:ASPxRadioButton ID="rbGiamgiaphantram_PX" Style="float: left" ClientInstanceName="rbGiamgiaphantram_PX" runat="server" Text="%" GroupName="rbthanhtoan">
                                            <ClientSideEvents CheckedChanged="rbGiamgiaVND_Check_PX" />
                                        </dx:ASPxRadioButton>
                                    </div>
                                </div>
                            </td>
                            <td class="info_table_td" style="width: 127px">
                                <asp:Label ID="lblTienthuatext_PX" Text="Tiền thừa trả khách:" runat="server"></asp:Label>
                            </td>
                            <td class="info_table_td">
                                <asp:Label ID="lblTienthua_PX" runat="server" Text="0,000,000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_table_td">Khách cần trả:
                            </td>
                            <td class="info_table_td">
                                <asp:Label ID="lblConlai_PX" runat="server" Text="0,000,000"></asp:Label>
                            </td>
                            <td class="info_table_td">Hình thức TT
                            </td>
                            <td class="info_table_td">
                                <dx:ASPxComboBox ID="ddlLoaithanhtoan_PX" ClientInstanceName="ddlLoaithanhtoan_PX" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="188px" runat="server" ValueType="System.String">
                                    <ClientSideEvents SelectedIndexChanged="ddlLoaithanhtoan_SelectedIndex" />
                                </dx:ASPxComboBox>
                            </td>
                            <%--<td>
                                <dx:ASPxButton ID="btnKekhai_client_PX" Image-Url="~/images/16x16/pencil_add.png" AutoPostBack="false" Style="float: left;" ClientInstanceName="btnKekhai_client" runat="server" Text="Kê khai">
                                    <ClientSideEvents Click="KeKhaiTT" />
                                </dx:ASPxButton>
                            </td>--%>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="info_table_td" colspan="4">
                                <dx:ASPxButton ID="btnThanhtoan_PX" ClientInstanceName="btnThanhtoan_PX" Image-Url="~/images/16x16/coins_in_hand.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Thanh toán">
                                    <Image Url="~/images/16x16/coins_in_hand.png"></Image>
                                    <ClientSideEvents Click="UpdatePhieuxuat" />
                                </dx:ASPxButton>
                              <dx:ASPxButton ID="btnInDonThuoc" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnInDonThuoc" runat="server" Text="In đơn thuốc" Visible="True">
                             <ClientSideEvents Click="InDonThuoc" />
                            </dx:ASPxButton>
                                <dx:ASPxButton ID="InPhieu_Dongy" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="InPhieu_PX_Client_DY" runat="server" Text="In phiếu đông y " Visible="true">
                                    <ClientSideEvents Click="InPhieuDongY" />
                                </dx:ASPxButton>
                                 <dx:ASPxButton ID="InPhieu_Tayy" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="InPhieu_PX_Client_TY" runat="server" Text="In phiếu tây y" Visible="false">
                                    <ClientSideEvents Click="InPhieuTayY" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </fieldset>
    </div>
    <div style="clear: both"></div>
    <asp:Panel ID="pnChitietphieu" runat="server">
        <fieldset class="field_tt">
            <legend><span style="font-weight: bold; color: green">Phiếu chi tiết</span></legend>
            <table class="info_table">
                <tbody>
                    <tr>
                        <td class="info_table_td">Thuốc:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlMathang" onkeypress="return enter_ddlMathang(event)" EnableCallbackMode="true" ClientInstanceName="ddlMathang" runat="server" CallbackPageSize="10"
                                IncrementalFilteringMode="Contains" ValueField="uId_Mathang" ValueType="System.String" TextFormatString="{0}-{1}"
                                Width="300px" CssClass="ddlMathang" DropDownWidth="500px" DropDownStyle="DropDown" OnCallback="ddlMathang_Callback">
                                <Columns>
                                    <dx:ListBoxColumn FieldName="v_MaMathang" Caption="Mã" Width="100%" />
                                    <dx:ListBoxColumn FieldName="nv_TenMathang_vn" Caption="Tên vật tư" Width="100%" />
                                    <dx:ListBoxColumn FieldName="tendonvi" Caption="Đơn vị (nhỏ nhất)" Width="90px" />
                                    <dx:ListBoxColumn FieldName="f_SL_Ton" Caption="Số lượng tồn" Width="70px" />
                                </Columns>
                                <ClientSideEvents SelectedIndexChanged="ddlMathang_Selectchange" />
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td td_0_ipad">Đơn vị:
                        </td>
                        <td class="info_table_td td_0_ipad">
                            <dx:ASPxComboBox ID="ddlDonvi" OnCallback="ddlDonvi_Callback" onkeypress="return enter_ddlDonvi(event)" ClientInstanceName="ddlDonvi" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="86px" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td td_0_ipad">Số lượng:
                        </td>
                        <td class="info_table_td td_0_ipad">
                            <asp:TextBox ID="txtSoluong" onkeypress="return enter_txtSoluong(event)" Text="1" runat="server" Width="43px" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td class="info_table_td td_0_ipad">
                            <dx:ASPxButton ID="btnLuuchitiet" ClientInstanceName="btnLuuchitiet" Image-Url="~/images/16x16/save.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Thêm mặt hàng">
                                <Image Url="~/images/16x16/add.png"></Image>
                                <ClientSideEvents Click="SaveDetail" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </asp:Panel>
    <fieldset  class="field_tt">
        <legend><span style="font-weight: bold; color: green">Danh sách thuốc</span></legend>
        <dx:ASPxGridView ID="grid_Phieuxuat_Chitiet" OnDataBinding="grid_Phieuxuat_Chitiet_DataBinding"  runat="server" CssClass="grid_dm_dv" ClientInstanceName="grid_Phieuxuat_Chitiet" OnRowDeleting="dgvDevexpress_RowDeleting"
        OnRowUpdating="dgvDevexpress_RowUpdating" AutoGenerateColumns="false" KeyFieldName="uId_Phieuxuat_Chitiet"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieuxuat_Chitiet"
                Name="uId_Phieuxuat_Chitiet">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn ReadOnly="true" Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên thuốc" FieldName="nv_TenMathang_vn"
                Name="nv_TenMathang_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="50px" HeaderStyle-HorizontalAlign="Center" ReadOnly="true" Caption="ĐVT" FieldName="tendonvi"
                Name="tendonvi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="60px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="120px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Đơn giá:" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <%--<dx:GridViewDataTextColumn Visible="true" Width="120px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Giảm giá:" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>--%>
            <dx:GridViewDataColumn Width="120px" FieldName="f_Giamgia" VisibleIndex="1" Caption="Giảm giá" CellStyle-HorizontalAlign="Right">
                <DataItemTemplate>
                    <%#Eval("f_Giamgia", "{0:0,0}")%>
                </DataItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtGiamgia" Width="113px" Text='<%# Eval("f_Giamgia") %>'
                        runat="server"></asp:TextBox>
                </EditItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Width="140px" Caption="Thành tiền" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Visible="true" Width="200px" Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Ghichu" Name="nv_Ghichu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="1" Width="40px" ButtonType="Image">
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton>
                    <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                </UpdateButton>
                <EditButton>
                    <Image AlternateText="Save" Url="~/images/btn_Edit.png" />
                </EditButton>
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="GridViewCommandColumnCustomButton1" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Delete">
                        <Image AlternateText="Delete" Url="~/images/btn_Delete.png">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowFooter="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <TotalSummary>
            <dx:ASPxSummaryItem DisplayFormat="Thành tiền: {0:0,0}" FieldName="f_Tongtien" SummaryType="Sum" />
        </TotalSummary>
        <ClientSideEvents EndCallback="grid_EndCallback_PX" RowDblClick="grid_RowDblClick" CustomButtonClick="OnCustomButtonClick" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    </fieldset>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
      <dx:ASPxPopupMenu ID="popMenu" runat="server" PopupElementID="btnInSudung" ClientInstanceName="pmRowMenu"   PopupHorizontalAlign="OutsideRight"  PopupVerticalAlign="TopSides"
            PopupAction="LeftMouseClick">
            <Items>
                <dx:MenuItem Text="In hướng dẫn sử dụng" Name="INHDSUDUNG"></dx:MenuItem>
                <dx:MenuItem Text="In đơn thuốc" Name="INHDHOADON"></dx:MenuItem>
            </Items>
            <ClientSideEvents Init="InitPopupMenuHandler" ItemClick="menuItemClick" />
            
        </dx:ASPxPopupMenu>
    <dx:ASPxPopupMenu ID="ASPxPopupMenu1" runat="server" PopupElementID="btnIn" ClientInstanceName="pmMenuIn"   PopupHorizontalAlign="OutsideRight"  PopupVerticalAlign="TopSides"
            PopupAction="LeftMouseClick">
            <Items>
                <dx:MenuItem Text="In phiếu khám" Name="phieukham"></dx:MenuItem>
                <dx:MenuItem Text="In phiếu thanh toán" Name="thanhtoan"></dx:MenuItem>
                <dx:MenuItem Text="In phiếu điều trị" Name="dieutri"></dx:MenuItem>
            </Items>
            <ClientSideEvents Init="InitPopupMenuHandler2" ItemClick="menuItemClick2" />
        </dx:ASPxPopupMenu>
</asp:Content>
