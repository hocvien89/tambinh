<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Product.aspx.vb" Inherits="NANO_SPA.Product" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

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
    <script src="../../Js/Product/Product.js" type="text/javascript"></script>
    <script type="text/javascript">
        var idem = 0
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'d6f6c8a8-26c8-4f58-9b12-7b9016fe705c'}";
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


        function ShowAddWindow() {
            idem = 0;
            pcAddMathang.Show();
            ClearText();
            var txt_Tenmathang = document.getElementById("<%=txt_Tenmathang.ClientID%>");
            GetMavach(cboloaimavach.GetValue());
            txt_Tenmathang.focus();
        }
        function ShowAddWindowimport() {
            PcImportExcel.Show();
            document.getElementById("<%=lbl_Import.ClientID%>").innerHTML = ""
        }


        function OnGridSelectionComplete(values) {
            //Gan gia tri cho hidden field uId khachhang de sua thong tin khach hoac lam gi do
            var hdfuIdmh = document.getElementById("<%=hdfuIdMathang.ClientID%>");
            hdfuIdmh.value = values[0];
            var param_dt = "{'uId_Mathang':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/loadmathang";
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
            //jo_CreateSession("uId_Dichvu_cd", values[0]);
            //clientgrid_congdoan.Refresh();
        }
        function OnSuccessCall(msg) {
            if (msg.d != "") {
                var defaultdata = msg.d.split("$")
                var txt_Mamathang = document.getElementById('<%=txt_Mamathang.ClientID%>');
                var txt_Mavach = document.getElementById('<%=txt_Mavach.ClientID%>');
                var txt_Tenmathang = document.getElementById('<%=txt_Tenmathang.ClientID%>');
                var txt_Banle = document.getElementById('<%=txt_Banle.ClientID%>');
                var txt_Banlekhac = document.getElementById('<%=txt_Banlekhac.ClientID%>');
                var txt_Banbuonkhac = document.getElementById('<%=txt_Banbuonkhac.ClientID%>');
                var txt_Banbuon = document.getElementById("<%=txt_Banbuon.ClientID%>");
                var txt_Hanmucton = document.getElementById('<%=txt_Hanmucton.ClientID%>');
                var txt_Canhbaoton = document.getElementById('<%=txt_Canhbaoton.ClientID%>');
                var txt_CanhbaoHD = document.getElementById('<%=txt_CanhbaoHD.ClientID%>');
                var txt_Ghichu = document.getElementById('<%=txt_Ghichu.ClientID%>');
                var txt_tile21 = document.getElementById('<%=txt_tile21.ClientID%>');
                var txt_Tile32 = document.getElementById('<%=txt_Tile32.ClientID%>');
                var txt_DMGianhap = document.getElementById('<%=txt_DMGianhap.ClientID%>');
                var txt_DMGiaxuat = document.getElementById('<%=txt_DMGiaxuat.ClientID%>');
                txt_DMGianhap.value = defaultdata[19];
                txt_DMGiaxuat.value = defaultdata[20];
                Pcbo_Nhommathang.SetValue(defaultdata[0]);
                Pcbo_Loaimathang.SetValue(defaultdata[1]);
                Pcbo_Xuatxu.SetValue(defaultdata[2]);
                txt_Mamathang.value = defaultdata[3];
                if (defaultdata[4] == "") {
                    GetMavach(cboloaimavach.GetValue());
                }
                else {
                    txt_Mavach.value = defaultdata[4];
                }
                txt_Tenmathang.value = defaultdata[5];
                txt_Hanmucton.value = defaultdata[10];
                txt_Canhbaoton.value = defaultdata[11];
                txt_CanhbaoHD.value = defaultdata[12];
                txt_Ghichu.value = defaultdata[13];
                txt_Banle.value = jo_ThousanSereprates(defaultdata[6])
                txt_Banlekhac.value = jo_ThousanSereprates(defaultdata[7])
                txt_Banbuonkhac.value = jo_ThousanSereprates(defaultdata[8])
                txt_Banbuon.value = jo_ThousanSereprates(defaultdata[9])
                if (defaultdata[14] != "") {
                    Pcbo_Donvi1.SetValue(defaultdata[14])
                } else
                    Pcbo_Donvi1.SetValue("0")
                if (defaultdata[15] != "") {
                    Pcbo_Donvi2.SetValue(defaultdata[15])
                } else
                    Pcbo_Donvi2.SetValue("0")
                if (defaultdata[16] != "") {
                    Pcbo_Donvi3.SetValue(defaultdata[16])
                } else
                    Pcbo_Donvi3.SetValue("0")
                txt_tile21.value = defaultdata[17]
                txt_Tile32.value = defaultdata[18]
                document.getElementById('<%=lbl_.ClientID%>').innerHTML = "";
                callback.PerformCallback();
            }
            function onFail(ex) {
                alert(ex._message + " fail");
                return false;
            }
        }
        function ClearText() {
            var hdfuIdmh = document.getElementById("<%=hdfuIdMathang.ClientID%>");
            var txt_Mamathang = document.getElementById('<%=txt_Mamathang.ClientID%>');
            var txt_Mavach = document.getElementById('<%=txt_Mavach.ClientID%>');
            var txt_Tenmathang = document.getElementById('<%=txt_Tenmathang.ClientID%>');
            var txt_Banle = document.getElementById('<%=txt_Banle.ClientID%>');
            var txt_Banlekhac = document.getElementById('<%=txt_Banlekhac.ClientID%>');
            var txt_Banbuonkhac = document.getElementById('<%=txt_Banbuonkhac.ClientID%>');
            var txt_Banbuon = document.getElementById("<%=txt_Banbuon.ClientID%>");
            var txt_Hanmucton = document.getElementById('<%=txt_Hanmucton.ClientID%>');
            var txt_Canhbaoton = document.getElementById('<%=txt_Canhbaoton.ClientID%>');
            var txt_CanhbaoHD = document.getElementById('<%=txt_CanhbaoHD.ClientID%>');
            var txt_Ghichu = document.getElementById('<%=txt_Ghichu.ClientID%>');
            var txt_tile21 = document.getElementById('<%=txt_tile21.ClientID%>');
            var txt_Tile32 = document.getElementById('<%=txt_Tile32.ClientID%>');
            var lbl_thongbao = document.getElementById('<%=lbl_.ClientID%>');
            var txt_DMGianhap = document.getElementById('<%=txt_DMGianhap.ClientID%>');
            var txt_DMGiaxuat = document.getElementById('<%=txt_DMGiaxuat.ClientID%>');
            txt_DMGianhap.value = "";
            txt_DMGiaxuat.value = "";
            txt_Mamathang.value = "";
            txt_Mavach.value = "";
            hdfuIdmh.value = "";
            txt_Tenmathang.value = "";
            txt_Hanmucton.value = "";
            txt_Canhbaoton.value = "";
            txt_CanhbaoHD.value = "";
            txt_Ghichu.value = "";
            txt_Banle.value = "";
            txt_Banlekhac.value = "";
            txt_Banbuonkhac.value = "";
            txt_Banbuon.value = "";
            txt_tile21.value = "";
            txt_Tile32.value = "";
            Pcbo_Xuatxu.SetSelectedIndex(1);
            Pcbo_Nhommathang.SetSelectedIndex(1);
            Pcbo_Loaimathang.SetSelectedIndex(1);
            Pcbo_Donvi1.SetValue("0");
            Pcbo_Donvi2.SetValue("0");
            Pcbo_Donvi3.SetValue("0");
            lbl_thongbao.innerHTML = "";
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "";
            txt_Tenmathang.focus()
            //tao moi ma mat hang
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateNewProductCode";
            $.ajax({
                type: "POST",
                url: pageUrl,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        txt_Mamathang.value = msg.d;
                    }
                },
                error: onFail
            });
        }
        function ClearText_Dev(s, e) {
            ClearText();
        }
        function checkempty(s, e) {
            document.getElementById('<%=lbl_Tenmathang.ClientID%>').innerHTML = "";
            document.getElementById('<%=lbl_Hanmucton.ClientID%>').innerHTML = "";
            document.getElementById('<%=lbl_.ClientID%>').innerHTML = "";
            document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "";
            var txt_DMGianhap = document.getElementById('<%=txt_DMGianhap.ClientID%>');
            var txt_DMGiaxuat = document.getElementById('<%=txt_DMGiaxuat.ClientID%>');
            var txt_tile21 = document.getElementById('<%=txt_tile21.ClientID%>');
            var txt_Tile32 = document.getElementById('<%=txt_Tile32.ClientID%>');
            var txt_Canhbaoton = document.getElementById('<%=txt_Canhbaoton.ClientID%>');
            var txt_CanhbaoHD = document.getElementById('<%=txt_CanhbaoHD.ClientID%>');
            var txt_Banle = document.getElementById('<%=txt_Banle.ClientID%>');
            var txt_Banlekhac = document.getElementById('<%=txt_Banlekhac.ClientID%>');
            var txt_Banbuonkhac = document.getElementById('<%=txt_Banbuonkhac.ClientID%>');
            var txt_Banbuon = document.getElementById("<%=txt_Banbuon.ClientID%>");
            var txt_Tenmathang = document.getElementById('<%=txt_Tenmathang.ClientID%>');
            var txt_Hanmucton = document.getElementById('<%=txt_Hanmucton.ClientID%>');
            var soluong21 = document.getElementById('<%=txt_tile21.ClientID%>');
            var soluong32 = document.getElementById('<%=txt_Tile32.ClientID%>');
            if (txt_Tenmathang.value == "") {
                txt_Tenmathang.focus();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Dữ liệu không đầy đủ";
                document.getElementById('<%=lbl_Tenmathang.ClientID%>').innerHTML = "!";
                e.processOnServer = false;
            }
            else if (txt_Hanmucton.value == "" || isNaN(parseInt(txt_Hanmucton.value))) {
                txt_Hanmucton.value = "";
                txt_Hanmucton.focus();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Dữ liệu không đầy đủ hoặc sai kiểu";
                document.getElementById('<%=lbl_Hanmucton.ClientID%>').innerHTML = "!";
                e.processOnServer = false;
            }
            else if (Pcbo_Donvi1.GetSelectedItem().value == "0") {
                Pcbo_Donvi1.Focus();
                Pcbo_Donvi1.ShowDropDown();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Đơn vị 1 phải khác không!";
                e.processOnServer = false;
            }
            else if (Pcbo_Donvi2.GetSelectedItem().value != "0" & (soluong21.value == "" || isNaN(parseInt(soluong21.value)))) {
                soluong21.value = "";
                soluong21.focus();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Hãy điền giá trị quy đổi từ đơn vị 2 sang đơn vị 1";
                e.processOnServer = false;
            }
            else if (Pcbo_Donvi3.GetSelectedItem().value != "0" & (soluong32.value == "" || isNaN(parseInt(soluong32.value)))) {
                soluong32.value = "";
                soluong32.focus();
                document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Hãy điền giá trị quy đổi từ đơn vị 3 sang đơn vị 2";
                e.processOnServer = false;
            }
            else if (txt_CanhbaoHD.value != 0) {
                if (isNaN(parseInt(txt_CanhbaoHD.value))) {
                    txt_CanhbaoHD.value = "";
                    txt_CanhbaoHD.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_Canhbaoton.value != 0) {
                if (isNaN(parseInt(txt_Canhbaoton.value))) {
                    txt_Canhbaoton.value = "";
                    txt_Canhbaoton.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_Banle.value != 0) {
                if (isNaN(parseFloat(txt_Banle.value))) {
                    txt_Banle.value = "";
                    txt_Banle.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_Banlekhac.value != 0) {
                if (isNaN(parseInt(txt_Banlekhac.value))) {
                    txt_Banlekhac.value = "";
                    txt_Banlekhac.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_Banbuon.value != 0) {
                if (isNaN(parseInt(txt_Banbuon.value))) {
                    txt_Banbuon.value = "";
                    txt_Banbuon.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_Banbuonkhac.value != 0) {
                if (isNaN(parseInt(txt_Banbuonkhac.value))) {
                    txt_Banbuonkhac.value = "";
                    txt_Banbuonkhac.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_tile21.value != 0) {
                if (isNaN(parseInt(txt_tile21.value))) {
                    txt_tile21.value = "";
                    txt_tile21.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_Tile32.value != 0) {
                if (isNaN(parseInt(txt_Tile32.value))) {
                    txt_Tile32.value = "";
                    txt_Tile32.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_DMGianhap.value != 0) {
                if (isNaN(parseInt(txt_DMGianhap.value))) {
                    txt_DMGianhap.value = "";
                    txt_DMGianhap.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
            else if (txt_DMGiaxuat.value != 0) {
                if (isNaN(parseInt(txt_DMGiaxuat.value))) {
                    txt_DMGiaxuat.value = "";
                    txt_DMGiaxuat.focus();
                    document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Chỉ được nhập số!";
                    e.processOnServer = false;
                }
            }
}
// su kien enter tai cac textbox
function enter_txtTenmathang(e) {
    if (e.keyCode == 13) {
        var txt_Tenmathang = document.getElementById('<%=txt_Tenmathang.ClientID%>');
        var txt_Hanmucton = document.getElementById('<%=txt_Hanmucton.ClientID%>');
        if (txt_Tenmathang.value != "") {
            document.getElementById('<%=lbl_Tenmathang.ClientID%>').innerHTML = "";
            txt_Hanmucton.focus();
        } return false;
    }
}
function enter_txtHanmucton(e) {
    if (e.keyCode == 13) {
        var txt_Hanmucton = document.getElementById('<%=txt_Hanmucton.ClientID%>');
        if (txt_Hanmucton.value != "") {
            document.getElementById('<%=lbl_Hanmucton.ClientID%>').innerHTML = "";
            if (Pcbo_Donvi1.GetSelectedItem().value == "0") {
                Pcbo_Donvi1.Focus();
                Pcbo_Donvi1.ShowDropDown();
            }
            else
                document.getElementById('<%=txt_CanhbaoHD.ClientID%>').focus();
        } return false;
    }
}
function Select_Donvi1(s, e) {
    var txt_CanhbaoHD = document.getElementById('<%=txt_CanhbaoHD.ClientID%>');
    if (Pcbo_Donvi1.GetSelectedItem().value == "0") {
        document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "Đơn vị 1 phải khác không!";
        return false
    }
    else
        document.getElementById('<%=lbl_error.ClientID%>').innerHTML = "";
    txt_CanhbaoHD.focus();
    e.processOnServer = false;
}
function enter_txtCanhbaoHD(e) {
    if (e.keyCode == 13) {
        var txt_Mavach = document.getElementById('<%=txt_Mavach.ClientID%>');
        txt_Mavach.focus();
        return false;
    }
}
function enter_txtMavach(e) {
    var txt_Mavach = document.getElementById('<%=txt_Mavach.ClientID%>');
    if (e.keyCode == 13) {
        var txt_Tenmathang = document.getElementById('<%=txt_Tenmathang.ClientID%>');
        callback.PerformCallback();
        txt_Tenmathang.focus();
        return false;
    }
}
function enter_txtCanhbaoton(e) {
    if (e.keyCode == 13) {
        var txt_Ghichu = document.getElementById('<%=txt_Ghichu.ClientID%>');
        txt_Ghichu.focus();
        return false;
    }
}
function enter_txtGhichu(e) {
    if (e.keyCode == 13) {
        var txt_Banle = document.getElementById('<%=txt_Banle.ClientID%>');
        txt_Banle.focus();
        return false;
    }
}
function enter_txtBanle(e) {
    if (e.keyCode == 13) {
        var txt_Banbuon = document.getElementById('<%=txt_Banbuon.ClientID%>');
        txt_Banbuon.focus();
        return false;
    }
}
function enter_txtBanbuon(e) {
    if (e.keyCode == 13) {
        var txt_Banlekhac = document.getElementById('<%=txt_Banlekhac.ClientID%>');
        txt_Banlekhac.focus();
        return false;
    }
}
function enter_txtBanlekhac(e) {
    if (e.keyCode == 13) {
        var txt_Banbuonkhac = document.getElementById('<%=txt_Banbuonkhac.ClientID%>');
                txt_Banbuonkhac.focus();
                return false;
            }
        }
        function enter_txtBanbuonkhac(e) {
            if (e.keyCode == 13) {
                var txt_DMGianhap = document.getElementById('<%=txt_DMGianhap.ClientID%>');
        txt_DMGianhap.focus();
        return false;
    }
}
function enter_txtDMGianhap(e) {
    if (e.keyCode == 13) {
        var txt_DMGiaxuat = document.getElementById('<%=txt_DMGiaxuat.ClientID%>');
            txt_DMGiaxuat.focus();
            return false;
        }
    }
    function enter_txtDMGiaxuat(e) {
        if (e.keyCode == 13) {
            var btOK = document.getElementById('<%=btOK.ClientID%>');
            btOK.click();
            return false;
        }
    }
    function GetMavach(value) {
        var txt_Mavach = document.getElementById('<%=txt_Mavach.ClientID%>');
        var param_dt = "{'Luachon':'" + value + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/loadMavach";
        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                txt_Mavach.value = msg.d;
                //lblbarcode.SetText(msg.d);
                //callback.PerformCallback();
            },
            error: onFail
        });
    }
        function chkallChange(s, e) {
            if (chkall.GetChecked() == true) {
                chkall.SetChecked(true);
                grvinmavach.SelectRows();
                e.processOnServer=false
            }
            else {
                chkall.SetChecked(false);
                grvinmavach.UnselectRows();
                e.processOnServer=false
            }
        }
    

    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ DANH MỤC THUỐC</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">Nhóm thuốc: </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cbo_Nhommathang" DropDownStyle="DropDownList" runat="server" TextField="nv_Tennhommathang_vn"
                    ValueField="uId_Nhommathang" IncrementalFilteringMode="StartsWith" OnSelectedIndexChanged="cbo_Nhommathang_SelectedIndexChanged">
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">Loại thuốc:  </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cbo_Loaimathang" DropDownStyle="DropDownList" runat="server" TextField="nv_Tenloaimathang_vn"
                    ValueField="uId_Loaimathang" IncrementalFilteringMode="StartsWith" OnSelectedIndexChanged="cbo_Loaimathang_SelectedIndexChanged">
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc" AutoPostBack="false">
                    <ClientSideEvents Click="btnlocClick" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnThemmoi" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Thêm mới (F2)">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindow(); }" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnExportExcel" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false" Image-Url="~/images/Excel-icon.png"
                    runat="server" Text="Xuất Excel" OnClick="btnExportExcel_Click">
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnImportExcel" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false" Image-Url="~/images/Excel-icon.png"
                    runat="server" Text="Nhập Excel">
                    <ClientSideEvents Click="function(s, e) { ShowAddWindowimport(); }" />
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>

    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" ActiveTabIndex="0">
        <TabPages>
            <dx:TabPage Text="Danh sách thuốc">
                <ContentCollection>
                    <dx:ContentControl>
                        <fieldset class="field_tt_right>" style="width: 98%; margin: auto; height: auto">
                            <legend><span style="font-weight: bold; color: green;"></span></legend>
                            <dx:ASPxGridView ID="Grid_Mathang" KeyFieldName="uId_Mathang" ClientInstanceName="client_grid" AutoGenerateColumns="false" runat="server"
                                SettingsPager-PageSize="17" Width="100%">
                                <Columns>
                                    <dx:GridViewDataColumn FieldName="uId_Mathang" Visible="false" VisibleIndex="-1" Name="uId_Mathang">
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Mã thuốc" HeaderStyle-HorizontalAlign="Center" FieldName="v_MaMathang" VisibleIndex="1"
                                        Settings-AutoFilterCondition="Contains" Visible="true" Name="v_MaMathang" Width="150px">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Tên thuốc" HeaderStyle-HorizontalAlign="Center" FieldName="nv_TenMathang_vn" VisibleIndex="2"
                                        Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_TenMathang_vn" Width="300px">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Nhóm thuốc" Visible="true" VisibleIndex="3" FieldName="nv_Tennhommathang_vn"
                                        Settings-AutoFilterCondition="Contains" Width="250px" Name="nv_Tennhommathang_vn" HeaderStyle-HorizontalAlign="Center">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Loại thuốc" Visible="true" VisibleIndex="4" FieldName="nv_Tenloaimathang_vn"
                                        Settings-AutoFilterCondition="Contains" Width="230px" Name="nv_Tenloaimathang_vn" HeaderStyle-HorizontalAlign="Center">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataTextColumn Caption="Xuất xứ" Visible="true" VisibleIndex="5" FieldName="nv_Tenxuatxu_vn"
                                        Settings-AutoFilterCondition="Contains" Width="200px" Name="nv_Tenxuatxu_vn" HeaderStyle-HorizontalAlign="Center">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="40px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Caption="Sửa" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Thông tin thuốc" href='javascript:void(0)' onclick="return ShowEditWindow()">
                                                <img src="../../../images/btn_Edit.png" /></a>
                                        </DataItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="6" Width="40" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                            <Image Url="~/images/btn_Delete.png"></Image>
                                        </DeleteButton>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
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
                                                                            <td style="font-weight: bold">Hạn mức tồn: (Đơn vị 1)</td>
                                                                            <td><%# Eval("f_Hanmuc_Ton")%>  </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Số ngày cảnh báo tồn: </td>
                                                                            <td><%# Eval("i_Songaycanhbao_Ton")%> (Ngày)</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Số ngày cảnh báo hết hạn: </td>
                                                                            <td><%# Eval("i_Songaycanhbao_HethanSD")%> (Ngày)</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold">Ghi chú: </td>
                                                                            <td><%# Eval("nv_Ghichu_vn")%> </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div class="Div_Grid" style="width: 40%; float: right; padding: 5px; margin-right: 130px">
                                                                    <table cellpadding="2" cellspacing="3" style="border-collapse: collapse; width: 100%">
                                                                        <tr style="width: 200px">
                                                                            <td style="font-weight: bold">Hoa hồng bán lẻ: </td>
                                                                            <td style="width: 100px"><%# If((Eval("f_PhantramHH_KTV")) < 100, Eval("f_PhantramHH_KTV").ToString() + "%", Eval("f_PhantramHH_KTV", "{0:0,0}").ToString() + " (VND)")%>  </td>
                                                                        </tr>
                                                                        <tr style="width: 200px">
                                                                            <td style="font-weight: bold">Hoa hồng bán lẻ khác: </td>
                                                                            <td style="width: 100px"><%# If((Eval("f_PhantramHH_TVV")) < 100, Eval("f_PhantramHH_TVV").ToString() + "%", Eval("f_PhantramHH_TVV", "{0:0,0}").ToString() + " (VND)")%> </td>
                                                                        </tr>
                                                                        <tr style="width: 200px">
                                                                            <td style="font-weight: bold">Hoa hồng bán buôn: </td>
                                                                            <td style="width: 100px"><%# If((Eval("f_PhamtramHH_CTV")) < 100, Eval("f_PhamtramHH_CTV").ToString() + "%", Eval("f_PhamtramHH_CTV", "{0:0,0}").ToString() + " (VND)")%></td>
                                                                        </tr>
                                                                        <tr style="width: 200px">
                                                                            <td style="font-weight: bold">Hoa hồng bán buôn khác: </td>
                                                                            <td style="width: 100px"><%# If((Eval("f_PhantramHH_NV")) < 100, Eval("f_PhantramHH_NV").ToString() + "%", Eval("f_PhantramHH_NV", "{0:0,0}").ToString() + " (VND)")%> </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:TabPage>
                                                    <dx:TabPage Text="Định mức giá">
                                                        <ContentCollection>
                                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                                <div class="Div_Grid" style="width: 89%; height: auto">
                                                                    <dx:ASPxGridView ID="Grid_DinhMucGiaMathang" runat="server"
                                                                        KeyFieldName="uId_Dinhmuc_Giamathang" Width="100%" OnBeforePerformDataSelect="Grid_GiaMathang_BeforePerformDataSelect" OnCellEditorInitialize="Grid_DinhMucGiaMathang_CellEditorInitialize1"
                                                                        OnRowInserting="Grid_DinhMucGiaMathang_RowInserting" OnRowUpdating="Grid_DinhMucGiaMathang_RowUpdating" OnRowDeleting="Grid_DinhMucGiaMathang_RowDeleting">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center"
                                                                                FieldName="uId_Dinhmuc_Giamathang" Visible="false" VisibleIndex="-1">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Tên kho" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tenkho_vn"
                                                                                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="nv_Tenkho_vn">
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Giá nhập" HeaderStyle-HorizontalAlign="Center" FieldName="f_Gianhap"
                                                                                Visible="true" VisibleIndex="2" Settings-AllowAutoFilter="Default" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Biên độ nhập" HeaderStyle-HorizontalAlign="Center" FieldName="f_Biendo_Gianhap"
                                                                                Visible="true" VisibleIndex="3" Settings-AllowAutoFilter="Default" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Giá xuất" HeaderStyle-HorizontalAlign="Center" FieldName="f_Giaban"
                                                                                Visible="true" VisibleIndex="4" Settings-AllowAutoFilter="Default" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Biên độ xuất" HeaderStyle-HorizontalAlign="Center" FieldName="f_Biendo_Giaban"
                                                                                Visible="true" VisibleIndex="5" Settings-AllowAutoFilter="Default" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewCommandColumn Width="70px" VisibleIndex="6" Caption="Sửa" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                                                                                <CancelButton Visible="true">
                                                                                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                                                                                </CancelButton>
                                                                                <UpdateButton Visible="true">
                                                                                    <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                                                                                </UpdateButton>
                                                                                <EditButton Visible="true" Image-Url="../../images/btn_Edit.png" Image-AlternateText="Sửa">
                                                                                </EditButton>
                                                                                <NewButton Visible="true" Image-Url="../../images/btn_add.png" Image-AlternateText="Thêm"></NewButton>
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewCommandColumn Width="50px" Visible="true" VisibleIndex="8" ButtonType="Image" HeaderStyle-HorizontalAlign="Center" Caption="Xóa">
                                                                                <DeleteButton Visible="true" Image-Url="../../images/btn_Delete.png" Image-AlternateText="Xóa"></DeleteButton>
                                                                            </dx:GridViewCommandColumn>
                                                                        </Columns>
                                                                        <SettingsEditing Mode="Inline" />
                                                                        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                                                        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
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
                                <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
                                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                            </dx:ASPxGridView>
                            <dx:ASPxGridViewExporter ID="Export_Mathang" runat="server"></dx:ASPxGridViewExporter>
                        </fieldset>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Tạo mã vạch" Visible="true">
                <ContentCollection>
                    <dx:ContentControl>
                        <div style="float: left; width: 40%" class="container-fluid">
                            <dx:ASPxGridView ID="GrvInMavach" runat="server" AutoGenerateColumns="false" ClientInstanceName="grvinmavach"
                                KeyFieldName="uId_Mathang" Width="100%" Settings-ShowGroupButtons="true">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="true" Name="chkLuachon" VisibleIndex="1" >
                                        <HeaderTemplate>
                                            <dx:ASPxCheckBox ID="checkAll" runat ="server" ClientInstanceName="chkall" AutoPostBack="false">
                                                <ClientSideEvents CheckedChanged="chkallChange" />
                                            </dx:ASPxCheckBox>
                                        </HeaderTemplate>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="Mã thuốc" HeaderStyle-HorizontalAlign="Center" FieldName="v_MaMathang" VisibleIndex="1"
                                        Settings-AutoFilterCondition="Contains" Visible="true" Name="v_MaMathang" Width="150px">
                                        <Settings AutoFilterCondition="Contains"></Settings>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Tên thuốc" HeaderStyle-HorizontalAlign="Center" FieldName="nv_TenMathang_vn" VisibleIndex="2"
                                        Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_TenMathang_vn" Width="300px">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="Mã barcode" Visible="true" VisibleIndex="3" FieldName="v_MaBarcode"
                                        Settings-AutoFilterCondition="Contains" Width="50px" Name="v_MaBarcode" HeaderStyle-HorizontalAlign="Center">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <Settings ShowTitlePanel="true" ShowFilterRow="true" ShowFilterBar="Auto" />
                                <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
                            </dx:ASPxGridView>
                        </div>
                        <div style="float: left; width: 55%" class="container-fluid">
                            
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>            
                                    <dx:ASPxButton ID="btnTaoMavach" runat="server" AutoPostBack="false" ClientInstanceName="btntaomavach" OnClick="btnTaoMavach_Click" Text="Tạo mã vạch">
                            </dx:ASPxButton>                       
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
                                        <dx:ReportViewer ID="ReportViewer1" runat="server"></dx:ReportViewer>
                                                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
    <asp:HiddenField ID="hdfuIdMathang" Value="" runat="server" />
    <dx:ASPxPopupControl ID="pcAddMathang" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddMathang" Font-Size="25px"
        HeaderText="Thuốc" AllowDrgging="True" PopupAnimationType="None" AllowResize="false">
        <ContentStyle Paddings-Padding="0">
        </ContentStyle>
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcAddMathang.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="750px" Height="500px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server" Width="400px">
                            <asp:UpdatePanel ID="upMathang" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt" style="width: 720px; height: auto; margin: auto">
                                        <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                        <div class="thongtin" style="width: 729px; height: 416px">
                                            <fieldset class="field_tt" style="width: 706px; margin: auto">
                                                <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Thông tin thuốc</span></legend>
                                                <table class="info_table" style="font-size: 14px; margin: auto">
                                                    <tr>
                                                        <td class="info_table_td" style="font-size: 14px">Mã thuốc: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Mamathang" runat="server" Width="180px" onkeypress="return enter_txtTenmathang(event)"></asp:TextBox>
                                                        </td>

                                                        <td class="info_table_td" style="font-size: 14px; width: 100px">Mã vạch:  </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Mavach" runat="server" Width="56%" onkeypress="return enter_txtMavach(event)" Style="float: left; margin-right: 5px"></asp:TextBox>
                                                            <dx:ASPxComboBox ID="cboLoaimavach" runat="server" ClientInstanceName="cboloaimavach" SelectedIndex="0" Width="40%">

                                                                <Items>
                                                                    <dx:ListEditItem Text="Code 128" Value="128" />
                                                                    <dx:ListEditItem Text="EAN 13" Value="EAN" />
                                                                </Items>
                                                                <ClientSideEvents SelectedIndexChanged="cbomavachSelect" />
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Tên thuốc:(<a style="color: red">*</a>) </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Tenmathang" runat="server" Width="180px" onkeypress="return enter_txtTenmathang(event)"></asp:TextBox>
                                                            <asp:Label ID="lbl_Tenmathang" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>

                                                        <td class="info_table_td">Xuất xứ: </td>
                                                        <td class="info_table_td" style="height: 26px; width: 180px">
                                                            <dx:ASPxComboBox ID="Pcbo_Xuatxu" runat="server" Width="100%" DropDownStyle="DropDownList"
                                                                ClientInstanceName="Pcbo_Xuatxu" IncrementalFilteringMode="StartsWith" ValueType="System.String">
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Nhóm thuốc: </td>
                                                        <td class="info_table_td" style="height: 38px; width: 200px">
                                                            <dx:ASPxComboBox ID="Pcbo_Nhommathang" runat="server" Width="180px" DropDownStyle="DropDownList"
                                                                ClientInstanceName="Pcbo_Nhommathang" IncrementalFilteringMode="StartsWith" ValueType="System.String"
                                                                TextField="nv_Tennhommathang_vn" ValueField="uId_Nhommathang" SelectedIndex="0">
                                                            </dx:ASPxComboBox>
                                                        </td>

                                                        <td class="info_table_td">Loại thuốc: </td>
                                                        <td class="info_table_td" style="height: 38px; width: 200px">
                                                            <dx:ASPxComboBox ID="Pcbo_Loaimathang" runat="server" Width="100%" DropDownStyle="DropDownList"
                                                                ClientInstanceName="Pcbo_Loaimathang" IncrementalFilteringMode="StartsWith" ValueType="System.String"
                                                                TextField="nv_Tenloaimathang_vn" ValueField="uId_Loaimathang">
                                                            </dx:ASPxComboBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Hạn mức tồn:(<a style="color: red">*</a>)</td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Hanmucton" runat="server" Width="180px" placeholder="Số lượng theo đơn vị 1"
                                                                onkeypress="return enter_txtHanmucton(event)"></asp:TextBox>
                                                            <asp:Label ID="lbl_Hanmucton" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                        <td class="info_table_td">Cảnh báo tồn: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Canhbaoton" runat="server" Width="100%" placeholder="Số ngày cảnh báo tồn" onkeypress="return enter_txtCanhbaoton(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Cảnh báo hết hạn dùng: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_CanhbaoHD" runat="server" Width="180px" placeholder="Số ngày cảnh báo hết hạn" onkeypress="return enter_txtCanhbaoHD(event)"></asp:TextBox>
                                                        </td>
                                                        <td class="info_table_td">Ghi chú: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Ghichu" runat="server" Width="100%" onkeypress="return enter_txtGhichu(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <fieldset class="fied_tt" style="width: 330px; float: left">
                                                <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Quy đổi đơn vị</span></legend>
                                                <table class="info_table" style="font-size: 14px">
                                                    <tr>
                                                        <td class="info_table_td" style="width: 50px" colspan="2">Đơn vị 3
                                                        </td>
                                                        <td class="info_table_td" style="width: 50px" colspan="2">Đơn vị 2
                                                        </td>
                                                        <td class="info_table_td" style="width: 50px">Đơn vi 1<a style="color: red">*</a>
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td class="info_table_td" style="width: 60px; padding-left: 0px">
                                                            <dx:ASPxComboBox ID="Pcbo_Donvi3" runat="server" Width="60px" TextField="tendonvi" ValueField="madonvi"
                                                                DropDownStyle="DropDownList" ClientInstanceName="Pcbo_Donvi3">
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                        <td class="info_table_td" style="width: 60px">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Tile32" runat="server" placeholder="Tỉ lệ đổi"
                                                                Width="65px"></asp:TextBox>
                                                        </td>
                                                        <td class="info_table_td" style="width: 60px">
                                                            <dx:ASPxComboBox ID="Pcbo_Donvi2" runat="server" Width="60px" TextField="tendonvi" ValueField="madonvi"
                                                                DropDownStyle="DropDownList" ClientInstanceName="Pcbo_Donvi2">
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                        <td class="info_table_td" style="width: 60px">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_tile21" runat="server" placeholder="Tỉ lệ đổi"
                                                                Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td class="info_table_td" style="width: 60px">
                                                            <dx:ASPxComboBox ID="Pcbo_Donvi1" runat="server" Width="60px" TextField="tendonvi" ValueField="madonvi"
                                                                DropDownStyle="DropDownList" ClientInstanceName="Pcbo_Donvi1" ClientSideEvents-SelectedIndexChanged="Select_Donvi1">
                                                            </dx:ASPxComboBox>
                                                            <asp:Label ID="lbl_Donvi1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <fieldset class="fied_tt" style="width: 334px; float: right; margin: auto; padding: 5px 0px 5px 0px">
                                                <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Hoa hồng</span></legend>
                                                <table class="info_table" style="font-size: 14px">
                                                    <tr>
                                                        <td class="info_table_td">Bán lẻ: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Banle" runat="server" Width="60px"
                                                                placeholder="VND" PropertiesTextEdit-DisplayFormatString="{0:0,0}" onkeyup="return jo_ThousanSereprate(this)" onkeypress="return enter_txtBanle(event)"></asp:TextBox>
                                                        </td>
                                                        <td class="info_table_td">Bán lẻ khác: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Banlekhac" runat="server" Width="60px"
                                                                placeholder="VND" PropertiesTextEdit-DisplayFormatString="{0:0,0}" onkeyup="return jo_ThousanSereprate(this)" onkeypress="return enter_txtBanlekhac(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="info_table_td">Bán buôn: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Banbuon" runat="server" Width="60px"
                                                                placeholder="VND" PropertiesTextEdit-DisplayFormatString="{0:0,0}" onkeyup="return jo_ThousanSereprate(this)" onkeypress="return enter_txtBanbuon(event)"></asp:TextBox>
                                                        </td>
                                                        <td class="info_table_td">Bán buôn khác: </td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_Banbuonkhac" runat="server" Width="60px"
                                                                placeholder="VND" PropertiesTextEdit-DisplayFormatString="{0:0,0}" onkeyup="return jo_ThousanSereprate(this)" onkeypress="return enter_txtBanbuonkhac(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <fieldset class="fied_tt" style="width: 97%">
                                                <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Định mức giá chung</span></legend>
                                                <table class="info_table" style="font-size: 14px; float: left">
                                                    <tr>
                                                        <td class="info_table_td">Giá nhập:</td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_DMGianhap" runat="server" Width="100px"
                                                                placeholder="VND" PropertiesTextEdit-DisplayFormatString="{0:0,0}" onkeyup="return jo_ThousanSereprate(this)" onkeypress="return enter_txtDMGianhap(event)"></asp:TextBox>
                                                        </td>
                                                        <td class="info_table_td">Giá xuất:</td>
                                                        <td class="info_table_td">
                                                            <asp:TextBox CssClass="nano_textbox" ID="txt_DMGiaxuat" runat="server" Width="100px"
                                                                placeholder="VND" PropertiesTextEdit-DisplayFormatString="{0:0,0}" onkeyup="return jo_ThousanSereprate(this)" onkeypress="return enter_txtDMGiaxuat(event)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="float: right">
                                                    Chú ý: Mức giá được áp dung với tất cả các kho của
                                                    <br />
                                                    cửa hàng và tính đối với đơn vị 1!
                                                </div>
                                            </fieldset>
                                            <asp:Label ID="lbl_error" runat="server" CssClass="error"></asp:Label>
                                            <asp:Label ID="lbl_" runat="server" Width="200px" Height="24px" Font-Size="Medium" Font-Bold="true" ForeColor="Red" CssClass="lbl_Thongbao"></asp:Label>
                                        </div>
                                        <div class="pcmButton" style="width: 540px; height: 40px; float: left">
                                            <dx:ASPxButton ID="btOK" Image-Url="~/images/btn_Save.png" runat="server" Text="Lưu (F4)" AutoPostBack="false"
                                                Style="float: left; margin-right: 8px" ClientInstanceName="btOK">
                                                <ClientSideEvents Click="checkempty" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="ClearText_Dev" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btnInMavach" runat="server" Visible="false" AutoPostBack="false" Image-Url="~/images/16x16/printer.png" Text="In Mã vạch" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="CallPrint" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="ClosePopup" />
                                            </dx:ASPxButton>
                                            <div style="float: left">
                                                <asp:Label ID="lbl_Ghichu" runat="server" CssClass="error" Text="Mục * là bắt buộc nhập dữ liệu" float="left"></asp:Label>
                                            </div>

                                        </div>
                                        <div style="float: left; padding-right: 78px; width: 100px; margin: auto">
                                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100px" OnCallback="ASPxCallbackPanel1_Callback" ClientInstanceName="callback">
                                                <PanelCollection>
                                                    <dx:PanelContent>
                                                        <div id="divPrint">
                                                            <dx:ASPxImage ID="imgBarecode" runat="server" ClientInstanceName="imgbarcode" Visible="false" EnableViewState="false"></dx:ASPxImage>
                                                            <dx:ASPxLabel ID="lblBarecode" runat="server" ClientInstanceName="lblbarcode" Visible="false" EnableViewState="false"></dx:ASPxLabel>
                                                            <%--<dx:ASPxPageControl ID="pgecontrol" runat="server"></dx:ASPxPageControl>--%>
                                                        </div>
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxCallbackPanel>

                                        </div>

                                        </caption>
                                    </fieldset>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="upMathang" DisplayAfter="0" DynamicLayout="false">
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
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="350px" Height="150px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server" Width="300px">
                            <div style="width: 290px; height: 100px">
                                <fieldset class="field_tt" style="width: 335px; height: 60px; margin: auto">
                                    <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                    <div style="height: 52px; width: 300px">
                                        <asp:FileUpload ID="UploadFileExcel" runat="server" Width="335px" BorderStyle="Groove" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="chỉ được upload file .xls và xlsx"
                                            ValidationExpression="^(?!\..*)(?!.*\.\.)(?=.*[^.]$)([^\&quot;#%&*:<>?\\/{|}~]){1,123}\.(xlsx|xls)$" ControlToValidate="UploadFileExcel">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="link_Taiexcl_Mau" runat="server" Text="Excel mẫu" OnClick="link_Taiexcl_Mau_Click"></asp:LinkButton>
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
</asp:Content>
