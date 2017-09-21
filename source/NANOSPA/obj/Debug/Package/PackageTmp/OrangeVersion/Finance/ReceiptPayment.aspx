<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ReceiptPayment.aspx.vb" Inherits="NANO_SPA.ReceiptPayment" %>

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
    <link href="../../../../Css/jquery-ui.css" rel="stylesheet" />
    <script src="../../../../Js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>

    <script type="text/javascript">
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
            var param_dt = "{'uId_Chucnang':'1299aae8-aac4-4c3e-bef8-7d0236cf2cf0'}";
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
        });
        var _fieldName = '';
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
            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }

        }
        //Su kien khi chon 1 dong
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                client_grid.GetRowValues(e.visibleIndex, 'v_Maphieu;uId_Phieuthuchi', OnGridSelectionComplete);
            }
        }
        function cbKhachhang_SelectChange(s, e) {
            jo_CreateSession("uId_Khachhang", ddlNguoinop.GetValue("uId_Khachhang").toString());
        }
        function OnGridSelectionComplete(values) {
            var hdfXoa = document.getElementById("<%=hdfXoa.ClientID%>");
            var hdfMaphieu = document.getElementById("<%=hdfMaphieu.ClientID%>");
            hdfMaphieu.value = values[0];
            hdfXoa.value = values[1];
            jo_CreateSession("uId_Phieuthuchi", values[1]);
            var param_dt = "{'uId_Phieuthuchi':'" + values[1] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadPhieuthuchi";
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
                if (defaultdata[8] == "True") {
                    var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
                    var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
                    var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
                    deNgaylap.SetText(ConvertDateToDDMMYYY(defaultdata[2]));
                    txtMaphieu.value = defaultdata[0];
                    txtSotien.value = jo_FormatMoney(defaultdata[4]);
                    txtGhichu.value = defaultdata[3];
                    ddlDanhmuc.SetValue(defaultdata[1]);
                    ddlNguoinop.SetValue(defaultdata[6]);
                    ddlNguoilap.SetValue(defaultdata[7]);
                    txtMaphieu.SetRedOnly = true;
                }
                else {
                    var txt_Maphieuchi = document.getElementById("<%=txt_Maphieuchi.ClientID%>");
                    var txt_Tienchi = document.getElementById("<%=txt_Tienchi.ClientID%>");
                    var txt_Lydochi = document.getElementById("<%=txt_Lydochi.ClientID%>");
                    dte_ngaychi.SetText(ConvertDateToDDMMYYY(defaultdata[2]));
                    txt_Maphieuchi.value = defaultdata[0];
                    txt_Tienchi.value = jo_FormatMoney(defaultdata[4]);
                    txt_Lydochi.value = defaultdata[3];
                    cbo_khoanchi.SetValue(defaultdata[1]);
                    txt_nguoinhan.SetText(defaultdata[5]);
                    txt_nguoinhan.SetEnabled(false);
                    cbo_nguoilap.SetValue(defaultdata[7]);
                }
            }
        }
        function onFail(ex) {
            alert(ex._message + " fail");
            return false;
        }
        function ShowAddThuPopup(s, e) {
            ddlNguoinop.SetEnabled(true);
            ClearText();
          
            //var param_dt = "{'ddate':'" + deNgaylap.GetText() + "'sLoaiphieu':'PT'}";
            //var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateMaphieuthuchi";
            //$.ajax({
            //    type: "POST",
            //    url: pageUrl,
            //    data: param_dt,
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    async: false,
            //    success: function (msg) {
            //        if (msg.d != "") {
            //            txtMaphieu.value = msg.d;
            //        }
            //    },
            //    error: onFail
            //});
            jo_CreateSession("b_Thuchi", "1");
            ddlDanhmuc.PerformCallback();
            var lbNguoinop = document.getElementById("<%=lbNguoinop.ClientID%>");
            lbNguoinop.innerHTML = "Người nộp:";
            pcPhieuthuchi.Show();
            return false;
        }
        function ShowAddChiPopup(s, e) {
            ClearTextchi();
           
         
            //var param_dt = "{'ddate':'" + dte_ngaychi.GetText() + "','sLoaiphieu':'PC'}";
            //alert(param_dt);
            //var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateMaphieuthuchi";
            //$.ajax({
            //    type: "POST",
            //    url: pageUrl,
            //    data: param_dt,
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    async: false,
            //    success: function (msg) {
            //        if (msg.d != "") {
            //            txt_Maphieuchi.value = msg.d;
            //        }
            //    },
            //    error: onFail
            //});
            jo_CreateSession("b_Thuchi", "0");
            ddlDanhmuc.PerformCallback();
            pcPhieuchi.Show();
            return false;
        }
        function ShowEditPopup(b_Thuchi) {
            ddlNguoinop.SetEnabled(false);
            ClearText();
            if (b_Thuchi == "True") {
                jo_CreateSession("b_Thuchi", "1");
                pcPhieuthuchi.Show();
            }
            else {
                jo_CreateSession("b_Thuchi", "0");
                pcPhieuchi.Show();
            }

            return false;
        }
        function ShowDeletePopup(b_Thuchi) {
            ddlNguoinop.SetEnabled(false);
            var txt_lydoxoa = document.getElementById("<%=txt_lydoxoa.ClientID%>");
            var lbl_sucess = document.getElementById("<%=lbl_sucess.ClientID%>");

            if (b_Thuchi == "True") {
                lblxoaphieu.SetText("Thu");
            }
            else {
                lblxoaphieu.SetText("Chi");
            }
            lbl_sucess.innerHTML = "";
            txt_lydoxoa.value = "";
            txt_lydoxoa.focus();
            pcXoaphieu.Show();
            return false;
        }
        //CLEAR TEXT
        function ClearText() {
            jo_RemoveSession("uId_Phieuthuchi");
            jo_RemoveSession("uId_Khachhang");
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");;
            txtMaphieu.value = "";
            txtGhichu.value = "";
            txtSotien.value = "";
            deNgaylap.SetDate(new Date())
            ddlNguoinop.SetValue("");
            var error = document.getElementById("error");
            var success = document.getElementById("success");
            if (error != null)
                error.innerHTML = "";
            if (success != null)
                success.innerHTML = "";
            var txtMaphieu = document.getElementById("<%=txtMaphieu.ClientID%>");
            var param_dt = "{'ddate':'" + deNgaylap.GetText() + "','sLoaiphieu':'PT'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateMaphieuthuchi";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        txtMaphieu.value = msg.d;
                    }
                },
                error: onFail
            });
            ddlNguoinop.Focus();
        }

        function ClearTextchi(s,e) {
            jo_RemoveSession("uId_Phieuthuchi");
            jo_RemoveSession("uId_Khachhang");
            var txt_Lydochi = document.getElementById("<%=txt_Lydochi.ClientID%>");
            var txt_Tienchi = document.getElementById("<%=txt_Tienchi.ClientID%>");
            var txt_Maphieuchi = document.getElementById("<%=txt_Maphieuchi.ClientID%>");
            txt_Lydochi.value = "";
            txt_Tienchi.value = "";
            txt_nguoinhan.SetText('');
            dte_ngaychi.SetDate(new Date())
            var error = document.getElementById("error");
            var success = document.getElementById("success");
            if (error != null)
                error.innerHTML = "";
            if (success != null)
                success.innerHTML = "";     
            txt_nguoinhan.SetEnabled(true);
            var param_dt = "{'ddate':'" + dte_ngaychi.GetText() + "','sLoaiphieu':'PC'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateMaphieuthuchi";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        txt_Maphieuchi.value = msg.d;
                    }
                },
                error: onFail
            });
            ddlNguoinop.Focus();
        }
        function ClearText_Dev(s, e) {
            ClearText();
        }
        function ClosePopup(s, e) {
            pcPhieuthuchi.Hide();
            pcPhieuchi.Hide();
            pcXoaphieu.Hide();
            client_grid.Refresh();
            return false;
        }
        function onkeyup_txtSotien(id) {
            jo_ThousanSereprate(id);
            return false;
        }
        function InPhieu(s, e) {
            if (jo_GetSession("uId_Phieuthuchi") == null) {
                alert("Chưa chọn phiếu để in!");
            }
            else {
                pcPhieuthuchi.Hide();
                pcPhieuchi.Hide();
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthuchi/rp_Inphieuthuchi.aspx" width="850px" height="100%"></iframe>')
                 .dialog({
                     autoOpen: false,
                     modal: true,
                     height: 610,
                     width: 828,
                     title: "In phiếu",
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
        function btnok_xoa(s, e) {
            var hdfXoa = document.getElementById("<%=hdfXoa.ClientID%>");
            var hdfMaphieu = document.getElementById("<%=hdfMaphieu.ClientID%>");
            var txt_lydoxoa = document.getElementById("<%=txt_lydoxoa.ClientID%>");
            if (txt_lydoxoa.value == "") {
                alert("Hãy nhập vào lý do xóa phiếu!");
                txt_lydoxooaphieu.Focus();
                e.processOnServer = false;
            }
        }
        function chk_Khachhang_CheckedChanged() {
            ddlNguoinop.PerformCallback();
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÝ THU - CHI</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title">
                <dx:ASPxComboBox ID="ddlLoaiDM" CssClass="dateedit_ipad" ClientInstanceName="ddlLoaiDM" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" runat="server" ValueType="System.String">
                    <Items>
                        <dx:ListEditItem Selected="true" Value="2" Text="Tất cả" />
                        <dx:ListEditItem Value="1" Text="Phiếu thu" />
                        <dx:ListEditItem Value="0" Text="Phiếu chi" />
                    </Items>
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">Từ ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="deTuNgay" CssClass="dateedit_ipad" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                    runat="server">
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">Đến ngày: </li>
            <li class="text_title">
                <dx:ASPxDateEdit ID="deDenNgay" CssClass="dateedit_ipad" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                    runat="server">
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" CssClass="dateedit_ipad" OnClick="btnFilter_Click" Width="100px" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
            <li class="text_title li_ipad">
                <dx:ASPxButton ID="btnThemphieuthu" CssClass="btnphieuthu" AutoPostBack="false" Width="140px" Image-Url="~/images/16x16/door_in.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Thêm phiếu thu">
                    <ClientSideEvents Click="ShowAddThuPopup" />
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnThemphieuchi" CssClass="btnphieuthu" Width="140px" AutoPostBack="false" Image-Url="~/images/16x16/door_out.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Thêm phiếu chi">
                    <ClientSideEvents Click="ShowAddChiPopup" />
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" OnRowDeleting="dgvDevexpress_RowDeleting" OnDataBinding="dgvDevexpress_DataBinding" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Phieuthuchi;v_Maphieu"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieuthuchi"
                Name="uId_Phieuthuchi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="130px" HeaderStyle-HorizontalAlign="Center" Caption="Mã phiếu" FieldName="v_Maphieu"
                Name="v_Maphieu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="80px" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="d_Ngay"
                Name="d_Ngay">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Người nhận (nộp)" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_HoTenKH_vn" Name="nv_HoTenKH_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="70px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Số tiền" FieldName="f_Sotien" Name="f_Sotien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Lý do" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Lydo_vn" Name="nv_Lydo_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Danh mục" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tenthuchi_vn" Name="nv_Tenthuchi_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Width="80px" Caption="Thuộc loại" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Loaithuchi" Name="nv_Loaithuchi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Width="110px" Caption="Nhân viên lập" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                <DataItemTemplate>
                    <a id="popup" title="Sửa hồ sơ" href='javascript:void(0)' onclick="return ShowEditPopup('<%#Eval("b_ThuChi") %>')">
                        <img src="../../../images/btn_Edit.png" /></a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                <DataItemTemplate>
                    <a id="popup" title="Xóa" href='javascript:void(0)' onclick="return ShowDeletePopup('<%#Eval("b_ThuChi") %>')">
                        <img src="../../../images/btn_Delete.png" /></a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <%--  <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image">
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton>
                    <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                </UpdateButton>
                <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                    <Image AlternateText="Xóa" Url="~/images/btn_Delete.png">
                    </Image>
                </DeleteButton>

            </dx:GridViewCommandColumn>--%>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <%--        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />--%>
        <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxPopupControl ID="pcPhieuthuchi" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcPhieuthuchi"
        HeaderText="Thêm / Sửa phiếu thu chi" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcPhieuthuchi.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" Width="620px" Height="300px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <asp:UpdatePanel ID="upKhachhang" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Thông tin phiếu thu chi</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Mã phiếu: 
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtMaphieu" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Khoản:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlDanhmuc" ClientInstanceName="ddlDanhmuc" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">
                                                    <asp:Label ID="lbNguoinop" runat="server" Text="Người nộp:"></asp:Label>
                                                </td>
                                                <td class="info_table_td">
                                                    <ul>
                                                        <li style="float:left">     
                                                       <dx:ASPxComboBox ID="ddlNguoinop" OnCallback="ddlNguoinop_Callback" EnableCallbackMode="true" ClientInstanceName="ddlNguoinop" runat="server" CallbackPageSize="10"
                                                        IncrementalFilteringMode="Contains" ValueField="uId_Khachhang" ValueType="System.String" TextFormatString="{1} {3} {2} {0}"
                                                        Width="170px" DropDownStyle="DropDown">
                                                        <Columns>
                                                            <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã" />
                                                            <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Họ tên" />
                                                            <dx:ListBoxColumn FieldName="nv_Diachi_vn" Caption="Địa chỉ" />
                                                            <dx:ListBoxColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" />
                                                        </Columns>
                                                        <ClientSideEvents SelectedIndexChanged="cbKhachhang_SelectChange" />
                                                    </dx:ASPxComboBox> </li>
                                                        <li style="float:left"> <dx:ASPxCheckBox runat="server" ID="chk_Khachhang" Height="20px" Width="45px">
                                                            <ClientSideEvents CheckedChanged="chk_Khachhang_CheckedChanged" />
                                                                                </dx:ASPxCheckBox></li>
                                                    </ul>

                                                
                                                </td>
                                                <td class="info_table_td">Ngày lập:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="deNgaylap" ClientInstanceName="deNgaylap" Style="float: left; margin-right: 8px;" Width="200px" Height="25px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Số tiền: 
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txtSotien" onkeyup="return onkeyup_txtSotien(this)" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Người lập: 
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="ddlNguoilap" ClientInstanceName="ddlNguoilap" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Lý do:
                                                </td>
                                                <td class="info_table_td" colspan="3">
                                                    <asp:TextBox ID="txtGhichu" runat="server" TextMode="MultiLine" Width="483px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltrSuccess" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClearText_Dev" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btOK" OnClick="btOK_Click" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" runat="server" Text="Lưu" Style="float: left; margin-right: 8px">
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btn_Inphieu" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" ClientInstanceName="btn_inphieu" runat="server" Text="In phiếu" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="InPhieu" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btCancel" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopup" />
                                                        </dx:ASPxButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
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

    <dx:ASPxPopupControl ID="pcPhieuchi" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcPhieuchi"
        HeaderText="Thêm / Sửa phiếu chi" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcPhieuchi.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="620px" Height="300px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <asp:UpdatePanel ID="upChi" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green">Thông tin phiếu chi</span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Mã phiếu: 
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txt_Maphieuchi" Width="200px" runat="server" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Khoản:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="cbo_Khoanchi" ClientInstanceName="cbo_khoanchi" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">
                                                    <asp:Label ID="Label1" runat="server" Text="Người nhận:"></asp:Label>
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txt_Nguoinhan" runat="server" ClientInstanceName="txt_nguoinhan" Width="200"></dx:ASPxTextBox>
                                                </td>
                                                <td class="info_table_td">Ngày lập:
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxDateEdit ID="dte_Ngaychi" ClientInstanceName="dte_ngaychi" Style="float: left; margin-right: 8px;" Width="200px" Height="25px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                                        runat="server">
                                                    </dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Số tiền: 
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txt_Tienchi" onkeyup="return onkeyup_txtSotien(this)" runat="server" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Người lập: 
                                                </td>
                                                <td class="info_table_td">
                                                    <dx:ASPxComboBox ID="cbo_Nguoilap" ClientInstanceName="cbo_nguoilap" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="200px" ValueType="System.String" runat="server">
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Lý do:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txt_Lydochi" runat="server" TextMode="MultiLine" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Địa chỉ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txt_Diachi" runat="server" TextMode="MultiLine" Width="200px" CssClass="nano_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Literal ID="ltrChieror" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltrChisucess" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClearTextchi" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btn_OKChi" OnClick="btn_OKChi_Click" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOk" runat="server" Text="Lưu" Style="float: left; margin-right: 8px">
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="ASPxButton3" Image-Url="~/images/16x16/printer.png" AutoPostBack="false" ClientInstanceName="btn_inphieu" runat="server" Text="In phiếu" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="InPhieu" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="ASPxButton4" Image-Url="~/images/16x16/cancel.png" runat="server" Text="Thoát" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="ClosePopup" />
                                                        </dx:ASPxButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="upChi" DisplayAfter="0" DynamicLayout="false">
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
    <asp:HiddenField ID="hdfXoa" runat="server" Value="" />
    <asp:HiddenField ID="hdfMaphieu" runat="server" Value="" />
    <dx:ASPxPopupControl ID="pcXoaphieu" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcXoaphieu"
        HeaderText="Xóa phiếu" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcXoaphieu.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="300px" Height="130px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <asp:UpdatePanel ID="upXoa" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green"></span>
                                            <dx:ASPxLabel ClientInstanceName="lblxoaphieu" runat="server"></dx:ASPxLabel>
                                        </legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td">Lý do xóa thẻ: </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox ID="txt_lydoxoa" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="success">
                                                    <asp:Label ID="lbl_sucess" runat="server"></asp:Label>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="info_table_td" colspan="2">
                                                    <div style="width: 200px; height: 30px">
                                                        <dx:ASPxButton ID="btn_Xoaphieu" ClientInstanceName="btn_xoaphieu" runat="server" Image-Url="~/images/16x16/imagesok.png"
                                                            Text="Xóa" Style="float: left; margin-right: 8px" OnClick="btn_Xoaphieu_Click">
                                                            <ClientSideEvents Click="btnok_xoa" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btn_Canel" ClientInstanceName="btn_canel" runat="server" Image-Url="~/images/btn_Delete.png"
                                                            Text="Thoát" Style="float: left; margin-right: 8px" AutoPostBack="false">
                                                            <ClientSideEvents Click="ClosePopup" />
                                                        </dx:ASPxButton>

                                                    </div>


                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress3" AssociatedUpdatePanelID="upXoa" DisplayAfter="0" DynamicLayout="false">
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
</asp:Content>
