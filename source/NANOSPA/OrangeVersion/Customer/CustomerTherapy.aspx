<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CustomerTherapy.aspx.vb" Inherits="NANO_SPA.CustomerTherapy" %>


<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

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
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <script src="../../../../Js/jquery-1.4.4.min.js" type ="text/javascript"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
    <link href="../../../../Css/jquery-ui.css" rel="stylesheet" type="text/css" />   
    <script src="../../Js/Public/Public.js" type="text/javascript"></script>
    
    <script type="text/javascript">
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
    var ddlDichvuvalue = ddlDichvu.GetValue().toString();
    ckthucong.SetChecked(false);
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
       
        function onkeyupd_usd_2(id) {
            jo_ThousanSereprate(id);
        }


      function onkeyupd_usd_3(id) {

                jo_ThousanSereprate(id);
            }
      function onkeyupd_usd_4(id) {
                jo_ThousanSereprate(id);
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
    var param_dt = "{'uId_Phieudichvu_Chitiet':'" + ddlDichvu.GetValue().toString() + "','uId_Phieudichvu':'" + jo_GetSession("uId_Phieudichvu") + "'}";
    var pageUrl = "../../../../Webservice/nano_websv.asmx/Checkdichvu";

    $.ajax({
        type: "POST",
        url: pageUrl,
        data: param_dt,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: OncallSuccessCheck,
        error: onFail
    });
}
        function OncallSuccessCheck(msg)
        {
            var defaultdata = msg.d.split("$");
            var txtdichvuphu = document.getElementById("<%=txtdichvuphu.ClientID%>");
            var txttipphu = document.getElementById("<%=txttipphu.ClientID%>");
            var txtDVbinh = document.getElementById("<%=txtDVbinh.ClientID%>");
            var txttipchinh = document.getElementById("<%=txttipchinh.ClientID%>");
            txtdichvuphu.value = jo_FormatMoney(parseFloat(defaultdata[0].replace(/,/g, ""))*0.3);
            txtDVbinh.value = jo_FormatMoney(parseFloat(defaultdata[0].replace(/,/g, ""))*0.7);
            txttipchinh.value = jo_FormatMoney(parseFloat(defaultdata[1].replace(/,/g, ""))*0.5);
            txttipphu.value = jo_FormatMoney(parseFloat(defaultdata[1].replace(/,/g, ""))*0.5);
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
        alert("Vui lòng lưu quá trình điều trị trước khi kê khai nhân viên tư vấn");
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
        txtTendichvuTH.value = ddlDichvuvalue;
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
         .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rpt_Phieulieutrinh.aspx" width="850px" height="100%"></iframe>')
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
function cbo_Nhanvienphu_SelectedIndexChanged() {
    var uId_Nhanvien_phu = cbo_Nhanvienphu.GetValue();
    var txtdichvuphu = document.getElementById("<%=txtdichvuphu.ClientID%>");
    var txttipphu = document.getElementById("<%=txttipphu.ClientID%>");
    var txtDvchinh = document.getElementById("<%=txtDVbinh.ClientID%>");
    var txttipchinh = document.getElementById("<%=txttipchinh.ClientID%>");
    var txt_Tiendv_Chinh = txtDvchinh.value.replace(/,/g,"");
    var txt_Tiendv_Phu = txtdichvuphu.value.replace(/,/g,"");
    var txt_Tientip_Chinh = txttipchinh.value.replace(/,/g,"");
    var txt_Tientip_Phu = txttipphu.value.replace(/,/g,"");
    if (uId_Nhanvien_phu.toUpperCase() == "FD64D75F-13BC-4637-8BC7-A45674888D05")
    {
        txtDvchinh.value = jo_FormatMoney(parseFloat(txt_Tiendv_Chinh) +parseFloat(txt_Tiendv_Phu));
        txttipchinh.value = jo_FormatMoney(parseFloat(txt_Tientip_Chinh) + parseFloat(txt_Tientip_Phu));
        txtdichvuphu.value = 0;
        txttipphu.value = 0;
    }
}
// End region

    </script>
    <div class="brest_crum">
        <dx:ASPxButton ID="btnQuaylai" Style="float: left; margin-right: 7px; margin-left:s 5px" Image-Url="~/images/16x16/back.png" ClientInstanceName="btnQuaylai" AutoPostBack="false" runat="server" Text="Quay lại">
            <ClientSideEvents Click="BackTo" />
        </dx:ASPxButton>
        <p class="p_header">
            <i class="fa fa-newspaper-o fa-fw fa-1x"></i>THIẾT LẬP LIỆU TRÌNH DỊCH VỤ
            <asp:Label ID="ltrTitleHeader" Style="color: red; text-transform: uppercase; font-size: 16px" runat="server"></asp:Label>
        </p>
    </div>
    <fieldset class="field_phieudieutri" style="width: 24%; height: 255px">
        <legend><span style="font-weight: bold; color: green">Thông tin phiếu điều trị </span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td_dieutri">Họ tên:
                    </td>
                    <td class="info_table_td_dieutri">
                        <asp:Label ID="lblHotenKH" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td_dieutri">Số phiếu:
                    </td>
                    <td class="info_table_td_dieutri">
                        <asp:Label ID="lblSophieu" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td_dieutri">Đơn giá (đã chiết khấu):
                    </td>
                    <td class="info_table_td_dieutri">
                        <asp:Label ID="lblDongia" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td_dieutri">Số tiền đã TT:
                    </td>
                    <td class="info_table_td_dieutri">
                        <asp:Label ID="lblTiendaTT" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td_dieutri">Số tiền còn nợ:
                    </td>
                    <td class="info_table_td_dieutri">
                        <asp:Label Style="color: red" ID="lblTienno" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
<%--                    <td class="info_table_td_dieutri">Số tiền còn lại:
                    </td>--%>
                    <td class="info_table_td_dieutri">
                        <asp:Label Style="color: red" ID="lblConlai" Visible="false" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset class="field_quatrinhdieutri" style="width: 52%; margin-left: 5px; float: left; height: auto">
        <legend><span style="font-weight: bold; color: green">Quá trình điều trị </span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Dịch vụ điều trị:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlDichvu" ClientInstanceName="ddlDichvu" DropDownStyle="DropDown" OnSelectedIndexChanged="ddlDichvu_SelectedIndexChanged" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String">
                            <ClientSideEvents SelectedIndexChanged="ddlDichvu_SelectChange"  />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Ngày điều trị:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deNgaydt" UseMaskBehavior="true" ClientInstanceName="deNgaydt" Width="170px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Tổng lần điều trị
                    </td>
                    <td class="info_table_td">
                        <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtSolanDT"></asp:TextBox>
                    </td>
                    <td class="info_table_td" colspan="2">
                        <asp:Label ID="lblSoDVconlai" runat="server" Text="Còn lại: 00 lần điều trị" Font-Bold="true" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Lần điều trị thứ:
                    </td>
                    <td class="info_table_td">
                        <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtLanthu"></asp:TextBox>
                    </td>
                     <td class="info_table_td" >
                        <dx:ASPxCheckBox ID="chkDuocyeucau"  Visible="false" Style="color: red" AutoPostBack="false" Text="Được yêu cầu" runat="server">
                        </dx:ASPxCheckBox>
                    </td>
                    <td class="info_table_td" >
                        <dx:ASPxCheckBox ID="ckthucong"  ClientInstanceName="ckthucong" Visible="True" Style="color: red" AutoPostBack="false" Text="Kê thủ công" runat="server">
                        </dx:ASPxCheckBox>
                    </td>
                   
                </tr>
                <tr>
                    <td class="info_table_td">Nhân viên chính:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlNhanvienchinh" Visible="true" ClientInstanceName="ddlNhanvienchinh" DropDownStyle="DropDown" IncrementalFilteringMode="Contains" Height="25px" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                    </td>
                   <td class="info_table_td">
                       <asp:TextBox ID="txtDVbinh" placeholder="Tiền dịch vụ" Width="100px" CssClass="nano_textbox" runat="server" onkeyup=" return onkeyupd_usd_2(this)">
                       </asp:TextBox> </td>
                    <td class="info_table_td">
                         <asp:TextBox ID="txttipchinh" placeholder="Tiền Tip" Width="100px" CssClass="nano_textbox" runat="server"   onkeyup=" return onkeyupd_usd_2(this)"></asp:TextBox> </td>
                    
                </tr>
               
               <tr>
                    <td class="info_table_td">Nhân viên phụ 1:
                    </td>
                    <td class="info_table_td">
                          
                        <dx:ASPxComboBox ID="cbo_Nhanvienphu" ClientInstanceName="cbo_Nhanvienphu" Visible="true" runat="server" DropDownStyle="DropDown" IncrementalFilteringMode="Contains" ValueType="System.String" Height="25px"  AutoPostBack="false" Width="200px">
                            <ClientSideEvents SelectedIndexChanged="cbo_Nhanvienphu_SelectedIndexChanged" />
                        </dx:ASPxComboBox>
                    </td>
                     <td class="info_table_td">
                       <asp:TextBox ID="txtdichvuphu" placeholder="Tiền dịch vụ" Width="100px" CssClass="nano_textbox" runat="server"  onkeyup=" return onkeyupd_usd_2(this)"></asp:TextBox> </td>
                    <td class="info_table_td">
                         <asp:TextBox ID="txttipphu" placeholder="Tiền Tip" Width="100px" CssClass="nano_textbox" runat="server"  onkeyup=" return onkeyupd_usd_2(this)"></asp:TextBox> </td>
                    
               </tr>
                <%--                <tr>
                    <td class="info_table_td">Hình ảnh:
                    </td>
                    <td class="info_table_td" colspan="3">
                        <asp:TextBox ID="txtImgUrl" CssClass="nano_textbox" runat="server" Width="385px"></asp:TextBox>
                        <dx:ASPxButton ID="btnSelectImage" Style="float: right; position: relative; bottom: 5px; width: 104px" ClientInstanceName="btnSelectImage" runat="server" Text="Chọn ảnh" AutoPostBack="false">
                            <ClientSideEvents Click="Upload" />
                        </dx:ASPxButton>
                    </td>
                </tr>--%>
                <tr>
                    <td class="info_table_td">Ghi chú:
                    </td>
                    <td class="info_table_td" colspan="3">
                        <asp:TextBox ID="txtGHichu" Height="27px" TextMode="MultiLine" CssClass="nano_textbox" runat="server" Width="490px"></asp:TextBox>
                    </td>
                </tr>
           <tr>
               <td class="info_table_td">
                   Phòng đặt lịch :
               </td>
               <td class="info_table_td"> <dx:ASPxComboBox ID="cboPhong" runat="server" Width="200px" ClientInstanceName="cboPhong" ValueType="System.String"></dx:ASPxComboBox></td>
               
           </tr>
                <tr>
                    <td colspan="4" class="info_table_td">
                        <dx:ASPxButton ID="btnCheckIn" Image-Url="~/images/16x16/door_in.png" Visible="false" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnThanhtoan" runat="server" Text="Check in">
                            <ClientSideEvents Click="ShowCheckIn" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnLuu" OnClick="btnLuu_Click" Image-Url="~/images/16x16/save.png" AutoPostBack="true" Style="float: left; margin-left: 10px" ClientInstanceName="btnThanhtoan" runat="server" Text="Lưu (F2)">
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnPhieumoi" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnPhieumoi" runat="server" Text="Làm mới (F9)">
                            <ClientSideEvents Click="ClearText" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnChonanh" Image-Url="~/images/16x16/add.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnChonanh" runat="server" Text="Chọn ảnh">
                            <ClientSideEvents Click="Upload" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnVTTH" Image-Url="~/images/16x16/page.png"  AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnvtth" runat="server" Text="Kê VTTH" >
                            <ClientSideEvents Click="LoadPopVTTH" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnHuyDV" Image-Url="~/images/16x16/card_front.png" AutoPostBack="false" Style="float: left; margin-left: 10px" OnClick="btnHuyDV_Click" ClientInstanceName="btnvtth" runat="server" Text="Hủy dịch vụ" >
                            
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnIncongdoan" Image-Url="~/images/16x16/page.png" AutoPostBack="false" Visible="true" Style="float: left; margin-left: 10px" ClientInstanceName="btnincongdoan" runat="server" Text="In CĐ" >
                            <ClientSideEvents Click="Incongdoan" />
                        </dx:ASPxButton>
                  
                    </td>
                </tr>

            </tbody>
        </table>
    </fieldset>
    <%-- tao ra menu cac hinh anh --%>
    <fieldset style="margin-left: 5px; height: 255px; width: 18%; float: left">
        <legend><span style="font-weight: bold; color: green">Hình ảnh điều trị </span></legend>
        <dx:ASPxDataView ID="dtv_DieutriHinhanh" ClientInstanceName="dtv_DieutriHinhanh" runat="server" Width="200px" RowPerPage="2" ItemStyle-Width="60px" ItemStyle-Height="80px" Paddings-Padding="5px" ItemStyle-Paddings-Padding="5px">
            <ItemTemplate>
                <div id='<%# Eval("uId_Hinhanh_Congdoan").ToString() +"$"+ Eval("nv_Hinhanh_vn").ToString()%>' onclick="onClick(event)">
                    <table style="margin: 0 auto">
                        <tr>
                            <td>
                                <dx:ASPxImage ID="img_Congdoan" runat="server" ImageUrl='<%# Eval("nv_Hinhanh_vn")%>' ShowLoadingImage="true" Width="60px" Height="80px" ClientInstanceName="img_Congdoan">
                                </dx:ASPxImage>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </dx:ASPxDataView>
    </fieldset>
    <div style="clear: both"></div>
    <div class="dieutri_detail">
        <%-- tao ra lua chon phong giuong check in --%>
        <dx:ASPxPopupControl ID="pcCheckIn" runat="server" CloseAction="CloseButton" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcCheckIn"
            HeaderText="Check In" AllowDragging="True" PopupAnimationType="None">
            <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcCheckIn.Focus(); }" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                    <dx:ASPxPanel ID="ASPxPanel3" runat="server" Width="750px" Height="70px">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent4" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Phòng trống
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlPhong" AutoPostBack="true" ClientInstanceName="ddlPhong" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                                <td class="info_table_td">Giường trống
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlGiuong" ClientInstanceName="ddlGiuong" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </td>
                                                 <td class="info_table_td">
                                                    <dx:ASPxButton ID="btnCheckInInsert" OnClick="btnCheckin_Click" Image-Url="~/images/16x16/door_in.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnThanhtoan" runat="server" Text="Check in">
                                                        <ClientSideEvents Click ="CheckinTest" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Literal ID="ltrError1" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <%-- danh sach lieu trinh dieu tri --%>
        <dx:ASPxGridView ID="dgvLieutrinh" runat="server" ClientInstanceName="client_Lieutrinh"
            AutoGenerateColumns="false" KeyFieldName="uId_QT_Dieutri;i_Lanthu" SettingsPager-PageSize="8" OnRowDeleting="dgvLieutrinh_RowDeleting"
            SettingsPager-Position="Bottom">
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Dichvu"
                    Name="uId_Dichvu">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Width="80px" Caption="Lần điều trị" FieldName="i_Lanthu"
                    Name="i_Lanthu" SortOrder="Ascending">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Width="290px" Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"
                    Name="nv_Tendichvu_vn">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Caption="Ngày điều trị" Width="100px" FieldName="d_Ngaydieutri"
                    Name="d_Ngaydieutri">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Caption="Nhân viên chính" Width="250px" FieldName="nv_Hoten_vn"
                    Name="nv_Hoten_vn">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Width="70px" Caption="Lệ phí" FieldName="f_Lephi_DT"
                    Name="f_Lephi_DT">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Width="70px" Caption="Trạng thái" FieldName="nv_Tentrangthai_vn"
                    Name="nv_Tentrangthai_vn">
                </dx:GridViewDataTextColumn>
                
                <dx:GridViewDataTextColumn Visible="false" FieldName="uId_Phieudichvu_Chitiet"></dx:GridViewDataTextColumn>
                <%--                <dx:GridViewDataTextColumn Visible="true" Caption="Nhân viên phụ" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Width="200px"
                    FieldName="Nhanvienphu">
<%--                    <DataItemTemplate>
                        <ul class="enlarge">
                            <li>
                                <img src="<%# Eval("nv_Hinhanh") %>" width="150px" height="100px" alt="Dechairs" /><span><img src="<%# Eval("nv_Hinhanh") %>" alt="Deckchairs" /><br />
                                    Hình ảnh</span></li>
                        </ul>
                    </DataItemTemplate>--
                </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" Width="320px" Caption="Ghi chú" FieldName="nv_Ghichu"
                    Name="nv_Ghichu">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)' onclick="return SelectLieutrinh('<%#Eval("uId_QT_Dieutri") %>','<%#Eval("uId_Phieudichvu_Chitiet") %>')">
                            <img src="../../../images/bub.png" /></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewCommandColumn VisibleIndex="5" Width="30px" ButtonType="Image">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="Delete" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Delete">
                            <Image AlternateText="Delete" Url="~/images/btn_Delete.png">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsEditing Mode="Inline" />
            <SettingsPager PageSize="15">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
            <SettingsBehavior  ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents CustomButtonClick="OnCustomButtonClick" EndCallback="grid_EndCallback" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <dx:ASPxPopupControl ID="pcNhanvienphu" runat="server" CloseAction="CloseButton" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcNhanvienphu"
            HeaderText="Kê khai nhân viên phụ" AllowDragging="True" PopupAnimationType="None">
            <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcNhanvienphu.Focus(); }" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <dx:ASPxPanel ID="Panel1" runat="server" Width="500px" Height="370px">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent1" runat="server">
                                <asp:UpdatePanel ID="upKhachhang" runat="server">
                                    <ContentTemplate>
                                        <asp:Literal ID="ltrErrorPuPhieu" runat="server"></asp:Literal>
                                        <fieldset class="field_tt">
                                            <legend><span style="font-weight: bold; color: green">Thông tin</span></legend>
                                            <table class="info_table">
                                                <tr>
                                                    <td class="info_table_td">Tên dịch vụ:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtTendichvu"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td">Nhân viên:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxComboBox ID="ddlNhanvienphu" ClientInstanceName="ddlNhanvienphu" onkeypress="return enter_ddlNghenghiep(event)" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server"></dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td">Công đoạn:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxComboBox ID="ddlCongdoan" ClientInstanceName="ddlCongdoan" onkeypress="return enter_ddlNghenghiep(event)" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server"></dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td"></td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxButton ID="btnLuuCongdoan" OnClick="btnLuuCongdoan_Click" Image-Url="~/images/16x16/save.png" AutoPostBack="true" Style="float: left; margin-left: 10px" ClientInstanceName="btnLuuCongdoan" runat="server" Text="Lưu (F2)">
                                                            <Image Url="~/images/16x16/save.png"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát (ESC)" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopup" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <dx:ASPxGridView ID="dgvNhanvienphu" OnRowDeleting="dgvNhanvienphu_RowDeleting" runat="server" ClientInstanceName="client_dgvNhanvienphu"
                                            AutoGenerateColumns="false" KeyFieldName="uId_Congdoan;uId_Nhanvien_Phu;uId_QT_Dieutri" SettingsPager-PageSize="8"
                                            SettingsPager-Position="Bottom">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Width="270px" Caption="Tên nhân viên" FieldName="nv_Hoten_vn"
                                                    Name="nv_Hoten_vn">
                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Width="200px" Caption="Công đoạn" FieldName="nv_Tencongdoan_vn"
                                                    Name="nv_Tencongdoan_vn">
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
                                            <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                            <ClientSideEvents EndCallback="grid_EndCallback" />
                                            <Styles>
                                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                </AlternatingRow>
                                            </Styles>
                                        </dx:ASPxGridView>
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
        <dx:ASPxPopupControl ID="pcVTTH" runat="server" CloseAction="CloseButton" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcVTTH"
            HeaderText="Kê khai vật tư tiêu hao" AllowDragging="True" PopupAnimationType="None">
            <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcVTTH.Focus(); }" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="650px" Height="470px">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent2" runat="server">
                                <asp:UpdatePanel ID="upVTTH" runat="server">
                                    <ContentTemplate>
                                        <fieldset class="field_tt">
                                            <legend><span style="font-weight: bold; color: green">Thông tin vật tư</span></legend>
                                            <table class="info_table">
                                                <tr>
                                                    <td class="info_table_td">Dịch vụ:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <asp:TextBox ID="txtTendichvuTH" CssClass="nano_textbox" runat="server" Width="300px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td">Chọn kho:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxComboBox ID="cbKho" ClientInstanceName="cbKho" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="300px" ValueType="System.String" runat="server">
                                                            <ClientSideEvents SelectedIndexChanged="cbKho_SelectChange" />
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td">Tên vật tư:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxComboBox ID="cbTenvattu" ClientInstanceName="cbTenvattu" runat="server" OnCallback="cbTenvattu_Callback" Width="300px" DropDownWidth="550" DropDownStyle="DropDownList"
                                                            ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="Contains"
                                                            CallbackPageSize="30">
                                                            <Columns>
                                                                <dx:ListBoxColumn FieldName="nv_TenMathang_vn" Caption="Tên vật tư" Width="100%" />
                                                                <dx:ListBoxColumn FieldName="tendonvi" Caption="Đơn vị (nhỏ nhất)" Width="80px" />
                                                                <dx:ListBoxColumn FieldName="f_SL_Ton" Caption="Số lượng tồn" Width="70px" />
                                                            </Columns>
                                                            <ClientSideEvents SelectedIndexChanged="cbTenvattu_SelectChange" />
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td">Đơn vị:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxComboBox ID="cbDonvi" ClientInstanceName="cbDonvi" OnCallback="cbDonvi_Callback" onkeypress="return enter_ddlNghenghiep(event)" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="300px" ValueType="System.String" runat="server"></dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td">Số lượng:
                                                    </td>
                                                    <td class="info_table_td">
                                                        <asp:TextBox ID="txtSoluongTH" CssClass="nano_textbox" runat="server" Width="300px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="info_table_td"></td>
                                                    <td class="info_table_td">
                                                        <dx:ASPxButton ID="btnLuuVTTH" OnClick="btnLuuVTTH_Click" ClientInstanceName="btnLuuVTTH" Image-Url="~/images/16x16/save.png" AutoPostBack="true" Style="float: left; margin-left: 10px" runat="server" Text="Lưu">
                                                            <Image Url="~/images/16x16/save.png"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnCancelVTTH" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopupVTTH" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <dx:ASPxGridView ID="dgvVTTH" EnableCallBacks="false" runat="server" ClientInstanceName="client_dgvVTTH"
                                            AutoGenerateColumns="false" KeyFieldName="uId_QT_Dieutri;uId_Mathang;uId_Kho;madonvi" OnRowUpdating="dgvVTTH_RowUpdating" OnRowDeleting="dgvVTTH_RowDeleting" SettingsPager-PageSize="8"
                                            SettingsPager-Position="Bottom">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Caption="Tên vật tư" FieldName="nv_TenMathang_vn"
                                                    Name="nv_TenMathang_vn">
                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Width="70px" Caption="Đơn vị" FieldName="tendonvi"
                                                    Name="tendonvi">
                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Width="120px" Caption="Số lượng tiêu hao" FieldName="f_SLTieuhao"
                                                    Name="f_SLTieuhao">
                                                    <Settings AutoFilterCondition="Contains"></Settings>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="5" Width="30px" ButtonType="Image">
                                                    <CancelButton>
                                                        <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                                                    </CancelButton>
                                                    <UpdateButton Visible="true">
                                                        <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                                                    </UpdateButton>
                                                    <DeleteButton Visible="true">
                                                        <Image AlternateText="Delete" Url="~/images/btn_Delete.png" />
                                                    </DeleteButton>
                                                </dx:GridViewCommandColumn>
                                            </Columns>
                                            <SettingsEditing Mode="Inline" />
                                            <SettingsPager PageSize="10">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                            <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                            <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="gridVTTH_RowDblClick" />
                                            <Styles>
                                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                </AlternatingRow>
                                            </Styles>
                                        </dx:ASPxGridView>
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="upVTTH" DisplayAfter="0" DynamicLayout="false">
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
    </div>
    <%--popup phong to anh--%>
    <dx:ASPxPopupControl ID="pup_Phonganh" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pup_Phonganh"
        ShowHeader="false" AllowDragging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="450px" Height="470px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxImage ID="imag_pup" runat="server" ClientInstanceName="imag_pup" Width="340px" Height="440px" ImageAlign="Middle"></dx:ASPxImage>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxHyperLink ID="lik_Delete" runat="server" Text="Xóa ảnh" ClientInstanceName="lik_Delete">
                                                    <ClientSideEvents Click="lik_Deletecik" />
                                                </dx:ASPxHyperLink>
                                            </td>
                                        </tr>
                                    </table>

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
</asp:Content>
