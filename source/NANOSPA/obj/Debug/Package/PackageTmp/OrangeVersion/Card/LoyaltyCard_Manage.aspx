<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="LoyaltyCard_Manage.aspx.vb" Inherits="NANO_SPA.Loyalty_Card" %>

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
    <script src="../../bootstrap/js/MaskedEditFix.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'5272133f-a89a-4185-a134-80652bda6836'}";
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
            var srcElement = e.htmlEvent.srcElement ? e.htmlEvent.srcElement : e.htmlEvent.target;
            //_fieldName = srcElement.getAttsribute('FieldName');
            s.StartEditRow(e.visibleIndex);
        }
        function grid_FocusedRowChanged(s, e) {
            if (s.cpIsEditing) {
                s.UpdateEdit();
            }
        }
        function jo_ThousanSereprate(id) {
            var textbox = id;
            id.value = jo_FormatMoney(id.value.replace(/,/g, ""));
            return false;
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

        function Select_Change(s, e) {
            if (!e.isSelected) {
            }
            else
                Grid_thekichhoat.GetRowValues(e.visibleIndex, 'uId_Khachhang;v_Mathekhachhang;uId_Thetichdiem;d_Ngaycap;d_Ngayhethan;uId_KH_The;d_Ngayden;Trangthai;b_Isdelete', OnGridSelectionComplete);
        }
        function OnGridSelectionComplete(values) {
            var txt_uidKHThe_an = document.getElementById('<%=txt_uidKHThe_an.ClientID%>');
            var txt_butonevent = document.getElementById('<%=txt_butonevent.ClientID%>');
            var hiddf_uIdKHThe = document.getElementById('<%=hiddf_uIdKHThe.ClientID%>');
            var lbl_Thongbao = document.getElementById('<%=lbl_Thongbao.ClientID%>');
            txt_mathe.SetText(values[1]);
            cbo_khachhang.SetValue(values[0]);
            cbo_loaithetichdiem.SetValue(values[2]);
            //cbo_theauto.setvalue(values[2]);
            Date_ngaykichhoat.SetValue(values[3]);
            Date_ngayhethan.SetValue(values[4]);
            //txt_diemtichluy.SetText(values[5]);
            //txt_diemhientai.SetText(values[6]);
            txt_uidKHThe_an.value = values[0];
            hiddf_uIdKHThe.value = values[5];
            chk_tichdiem.SetChecked(false);
            StyleChange(false);
            if (values[7] == "Tạm khóa") {
                btn_active.SetText("Mở Thẻ");
                txt_butonevent.value = "Mothe";
            }
            else if (values[7] == "Kích hoạt") {
                btn_active.SetText("Khóa Thẻ");
                txt_butonevent.value = "Khoathe";
            }
            lbl_Thongbao.innerHTML = "";
            //GetChuyedoidiem(values[2]);
        }
        // khong su dung ham nay
        function GetChuyedoidiem(dt) {
            var uId_Thetichdiem = dt
            var param_dt = "{'uId_Thetichdiem':'" + uId_Thetichdiem + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/Getchuyendoidiem";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        var defautdata = msg.d.split("$");
                        txt_sotienchuyen.SetValue(defautdata[0]);
                        txt_sodiemchuyen.SetValue(defautdata[1]);
                    }
                    else {
                        txt_sotienchuyen.SetValue('');
                        txt_sodiemchuyen.SetValue('');
                    }
                },
                error: onFail
            });
        }
        function Click_New(s, e) {
            var txt_uidKHThe_an = document.getElementById('<%=txt_uidKHThe_an.ClientID%>');
            var hiddf_uIdKHThe = document.getElementById('<%=hiddf_uIdKHThe.ClientID%>');
            var today = new Date()
            var dd = today.getDate();
            var MM = today.getMonth();
            var year = today.getFullYear();
            var Yearhan = year + 1;
            cbo_khachhang.SetText('');
            txt_mathe.SetText('');
            txt_uidKHThe_an.value = '';
            hiddf_uIdKHThe.value = '';
            cbo_khachhang.ShowDropDown();
            Date_ngaykichhoat.SetDate(new Date(year, MM, dd));
            Date_ngayhethan.SetDate(new Date(Yearhan, MM, dd));
        }
        function Check_Update(s, e) {
            var txt_uidKHThe_an = document.getElementById('<%=txt_uidKHThe_an.ClientID%>');
            if (txt_uidKHThe_an.value == "") {
                e.processOnServer = false
            }

        }
        function Check_Delete(s, e) {
            var txt_uidKHThe_an = document.getElementById('<%=txt_uidKHThe_an.ClientID%>');
            var msg = confirm("Bạn muốn xóa thẻ này?")
            if (txt_uidKHThe_an.value != "") {
                if (msg) {
                    return true
                }
                else {
                    e.processOnServer = false
                }
            }
            else {
                e.processOnServer = false
            }
        }
        function Select_Khachhang(s, e) {
            var txt_uidKHThe_an = document.getElementById('<%=txt_uidKHThe_an.ClientID%>');
            txt_uidKHThe_an.value = cbo_khachhang.GetSelectedItem().value;
        }

        function chk_TichdiemChange(s, e) {
            StyleChange(s.GetChecked());
        }

        function StyleChange(value) {
            txt_sodiem.SetEnabled(value);
            //radio_tichluy.SetEnabled(value);
            radio_cong.SetEnabled(value);
            radio_tru.SetEnabled(value);
            txt_noidung.SetEnabled(value);
            btn_update.SetEnabled(value);
        }
        //function Update_AutoAddPoint(s, e) {
        //    var uId_Thetichdiem = cbo_theauto.GetSelectedItem().value;
        //    var f_Giatri = txt_sotienchuyen.GetText();
        //    var i_Diem = txt_sodiemchuyen.GetText();
        //    if (f_Giatri > 0 & i_Diem > 0) {
        //        var param_dt = "{'uId_Thetichdiem':'"+uId_Thetichdiem+"','f_Giatri':'"+f_Giatri+"','i_Diem':'"+i_Diem+"'}";
        //        var pageUrl = "../../../../Webservice/nano_websv.asmx/Update_Addpoint";
        //        $.ajax({
        //            type: "POST",
        //            url: pageUrl,
        //            data: param_dt,
        //            contentType: "application/json; charset=utf-8",
        //            dataType: "json",
        //            async: false,
        //            success: function (msg) {
        //                if (msg.d !="") {
        //                    alert(msg.d);
        //                }
        //            },
        //            error: onFail
        //        });
        //    }
        //}

        //function Clear_Auto(s, e) {
        //    txt_sotienchuyen.SetText ('');
        //    txt_sodiemchuyen.SetText('');
        //    cbo_theauto.ShowDropDown();
        //}
        //function cbo_theautoChange(s, e) {
        //    var uId_Thetichdiem = cbo_theauto.GetSelectedItem().value;
        //    GetChuyedoidiem(uId_Thetichdiem);
        //}
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÝ THẺ THÀNH VIÊN</p>
    </div>
    <asp:HiddenField ID="hiddf_uIdKHThe" runat="server" />
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <fieldset class="field_tt_left" style="width: 46%; height: auto; float: left">
            <legend><span style="font-weight: bold; color: green">Thông tin khách hàng</span></legend>
            <table>
                <tr style="height: 38px">
                    <td style="width: 16%">Khách hàng</td>
                    <td style="width: 33%">
                        <dx:ASPxComboBox ID="cbo_Khachhang" runat="server" Width="170px" DropDownWidth="700px"
                            DropDownStyle="DropDown" ValueType="System.String" ValueField="uId_Khachhang" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0} - {1}" ClientInstanceName="cbo_khachhang">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_Khachhang" Visible="false" />
                                <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã khách hàng" />
                                <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Họ tên" />
                                <dx:ListBoxColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" />
                                <%--                                <dx:ListBoxColumn FieldName="d_Ngaysinh" Caption="Ngày sinh" />
                                <dx:ListBoxColumn FieldName="d_Ngayden" Visible="false" Caption="Ngày đến" />--%>
                            </Columns>
                            <ClientSideEvents SelectedIndexChanged="Select_Khachhang" />
                        </dx:ASPxComboBox>
                    </td>
                    <td>Mã thẻ:</td>
                    <td>
                        <dx:ASPxTextBox ID="txt_Mathe" runat="server" Width="180px" ClientInstanceName="txt_mathe" NullText="Mã tự sinh" EnableViewState="false"></dx:ASPxTextBox>
                    </td>
                </tr>
                <tr style="height: 38px">
                    <td>Loại thẻ:</td>
                    <td>
                        <dx:ASPxComboBox ID="cbo_Loaithetichdiem" runat="server" Width="170px" DropDownWidth="700px" EnableViewState="false"
                            DropDownStyle="DropDown" ValueType="System.String" ValueField="uId_Thetichdiem" IncrementalFilteringMode="StartsWith"
                            EnableCallbackMode="true" TextFormatString="{0}" ClientInstanceName="cbo_loaithetichdiem">
                            <Columns>
                                <dx:ListBoxColumn FieldName="nv_Tenthetichdiem" Caption="Tên loại thẻ" />
<%--                                <dx:ListBoxColumn FieldName="f_Diemkichhoat" Caption="Điểm kích hoạt" />--%>
                                <dx:ListBoxColumn FieldName="f_Diemkichhoat" Caption ="Tiền kích hoạt" />
                                <dx:ListBoxColumn FieldName="f_Uutien" Caption ="Mức ưu tiên" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 18%">Ngày kích hoạt</td>
                    <td style="width: 33%">
                        <dx:ASPxDateEdit ID="Date_Ngaykichhoat" runat="server" EditFormatString="dd/MM/yyyy" Width="180px" EnableViewState="false"
                            ClientInstanceName="Date_ngaykichhoat">
                        </dx:ASPxDateEdit>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_butonevent" Width="0px" Height="0px" CssClass="bigtext" runat="server" BorderStyle="None" ClientInstanceName="txt_uidkhthe" EnableViewState="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 38px">

                    <td style="width: 105px">Ngày hết hạn</td>
                    <td style="width: 33%">
                        <dx:ASPxDateEdit ID="Date_Ngayhethan" runat="server" EditFormatString="dd/MM/yyyy" Width="170px" EnableViewState="false"
                            ClientInstanceName="Date_ngayhethan">
                        </dx:ASPxDateEdit>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_uidKHThe_an" Width="0px" Height="0px" CssClass="bigtext" runat="server" BorderStyle="None"
                            ClientInstanceName="txt_uidkhthe" EnableViewState="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 38px">
                    <td colspan="4">
                        <div style="width: 70%; float: left">
                            <ul>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btn_AddNew" Text="Làm mới" runat="server" Image-Url="~/images/16x16/refresh.png" AutoPostBack="false" EnableViewState="false">
                                        <ClientSideEvents Click="Click_New" />
                                    </dx:ASPxButton>

                                </li>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btn_Active" Text="Lưu" runat="server" Image-Url="~/images/btn_Save.png" EnableViewState="false">
                                    </dx:ASPxButton>
                                </li>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btn_lock" Text="Khóa thẻ" runat="server"  ClientInstanceName="btn_active" Width="100px">
                                        <ClientSideEvents Click="Check_Update" />
                                    </dx:ASPxButton>
                                </li>
                                <li class="text_title">
                                    <dx:ASPxButton ID="btn_Delete" Text="Hủy thẻ" runat="server" Image-Url="~/images/btn_Delete.png">
                                        <ClientSideEvents Click="Check_Delete" />
                                    </dx:ASPxButton>
                                </li>
                            </ul>
                        </div>
                        <div style="text-align: center; width: 28%; float: right">
                            <dx:ASPxLabel ID="lbl_Thongbao" runat="server" Text="" CssClass="error" EnableViewState="false"></dx:ASPxLabel>
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
        <%--        <fieldset class="" style="width: 50%; float: right; height: auto">
            <table>
                <tr style="height: 38px">
                    <td style="width: 86px">Điểm tích lũy:</td>
                    <td style="width: 42%">
                        <dx:ASPxTextBox ID="txt_Diemtichluy" runat="server" ReadOnly="true"
                            ClientInstanceName="txt_diemtichluy"></dx:ASPxTextBox>
                    </td>
                    <td style="width: 86px">Điểm hiện tại:</td>
                    <td style="width: 186px">
                        <dx:ASPxTextBox ID="txt_Diemhientai" runat="server" ReadOnly="true" 
                            ClientInstanceName="txt_diemhientai"></dx:ASPxTextBox>
                    </td>
                </tr>
            </table>
        </fieldset>--%>
        <fieldset class="" style="width: 50%; float: right; height: 167px">
            <legend><span style="font-weight: bold; color: green">Tích lũy bằng tay 
                <dx:ASPxCheckBox ID="chk_Tichdiem" runat="server" ClientInstanceName="chk_tichdiem">
                    <ClientSideEvents CheckedChanged="chk_TichdiemChange" />
                </dx:ASPxCheckBox>
                    </span></legend>
            <table>
                <tr style="height: auto">
                    <td style="width: 86px">Số tiền:</td>
                    <td style="width: 26%">
                        <dx:ASPxTextBox ID="txt_Sodiem" runat="server" DisplayFormatString="{0:N0}" ClientInstanceName="txt_sodiem" EnableViewState="false"></dx:ASPxTextBox>
                    </td>
<%--                    <td style="width: 69px">Tích lũy:</td>--%>
                    <td style="width: 50px">
                        <dx:ASPxRadioButton ID="radio_Tichluy" Visible="false" runat="server" GroupName="Point" ClientInstanceName="radio_tichluy" EnableViewState="false"></dx:ASPxRadioButton>
                    </td>
                    <td style="width: 69px">Cộng tiền:</td>
                    <td style="width: 50px">
                        <dx:ASPxRadioButton ID="radio_Cong" runat="server" GroupName="Point" ClientInstanceName="radio_cong" EnableViewState="false"></dx:ASPxRadioButton>
                    </td>
                    <td style="width: 60px">Trừ tiền:</td>
                    <td style="width: 81px">
                        <dx:ASPxRadioButton ID="radio_Tru" runat="server" GroupName="Point" ClientInstanceName="radio_tru" EnableViewState="false"></dx:ASPxRadioButton>
                    </td>
                </tr>
                <tr style="height: auto">
                    <td>Nội dung:</td>
                    <td colspan="4">
                        <dx:ASPxTextBox ID="txt_Noidung" runat="server" Width="100%" EnableViewState="false" ClientInstanceName="txt_noidung"></dx:ASPxTextBox>
                    </td>
                    <td></td>
                    <td colspan="2" style="width: 100px">

                        <dx:ASPxButton ID="btn_Update" Text="Cập nhật" runat="server" Width="100px" AutoPostBack="false" ClientInstanceName="btn_update" Image-Url="~/images/btn_Edit.png">
                            <ClientSideEvents Click="Check_Update" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
         <%--<%--   <fieldset style="height: 89px">
                <legend><span style="font-weight: bold; color: green">Tự động tính điểm
                    <%--<dx:ASPxCheckBox ID="chk_AutoAddPoint" runat="server" ClientInstanceName="chk_autoaddpoint" Text="Tự động tính điểm" ForeColor="Green"></dx:ASPxCheckBox>
                </span></legend>
                <table id="tbl_AutoAddPoint" style="enable-background:accumulate"> 
                    <tr style="height:27px">
                        <td style="width: 88px">Áp dụng thẻ: </td>
                        <td>
                            <dx:ASPxComboBox ID="cbo_Theauto" runat="server" ClientInstanceName="cbo_theauto" Width="168px">
                                <ClientSideEvents SelectedIndexChanged="cbo_theautoChange" />
                            </dx:ASPxComboBox>
                        </td>
                        <td style="width: 55px; padding-left: 10px">Số tiền: </td>
                        <td>
                            <dx:ASPxTextBox ID="txt_Sotienchuyen" runat="server" ClientInstanceName="txt_sotienchuyen" Width="68px"
                                >
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 76px; padding-left: 10px">Chuyển đổi: </td>
                        <td>
                            <dx:ASPxTextBox ID="txt_Sodiemchuyen" runat="server" ClientInstanceName="txt_sodiemchuyen" Width="40px"></dx:ASPxTextBox>

                        </td>
                        <td style="padding-left: 10px">Điểm</td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <div style="width:100%;margin:auto; ">
                                <ul>
                                    <li class="text_title">
                                        <dx:ASPxButton ID="btn_NewAuto" runat="server" ClientInstanceName="btn_newauto" Text="Làm mới" Image-Url="~/images/16x16/refresh.png" AutoPostBack="false">
                                            <ClientSideEvents Click="Clear_Auto" />
                                        </dx:ASPxButton>
                                    </li>
                                    <li class="text_title">
                                        <dx:ASPxButton ID="btn_SaveAuto" runat="server" ClientInstanceName="btn_saveauto" Image-Url="~/images/btn_Save.png"
                                            Text="Lưu" AutoPostBack="false">
                                            <ClientSideEvents Click="Update_AutoAddPoint" />
                                        </dx:ASPxButton>
                                    </li>
                                    <li class="text_title">
                                        <dx:ASPxButton ID="btn_ListAuto" runat="server" ClientInstanceName="btn_listauto" Image-Url="~/images/16x16/page.png"
                                            AutoPostBack="false" Text="Danh sách">
                                            <ClientSideEvents Click="view_ListAddPoint" />
                                        </dx:ASPxButton>
                                    </li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>--%>
        </fieldset>
        <fieldset class="" style="width: 98%; margin: auto">
            <legend><span style="font-weight: bold; color: green">Danh sách thẻ kích hoạt</span></legend>
            <dx:ASPxGridView ID="Grid_Thekichhoat" runat="server" Width="100%" KeyFieldName="uId_KH_The" AutoGenerateColumns="false"
                ClientInstanceName="Grid_thekichhoat">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="uId_Khachhang" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="uId_KH_The" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="d_Ngayden" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Trangthai" Visible="true" VisibleIndex="6" Caption="Trạng thái" HeaderStyle-HorizontalAlign="Center"
                        Settings-AllowHeaderFilter="Default" Width="100px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="b_Isdelete" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                  <%--  <dx:GridViewDataTextColumn FieldName="f_Tongtichluy" Visible="true" VisibleIndex="4" Caption="Tổng tích lũy" Width="100px"
                        PropertiesTextEdit-DisplayFormatString="{0:N0}">
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn FieldName="f_Diemhientai" Visible="true" VisibleIndex="5" Caption="Số tiền hiện tại" Width="100px" PropertiesTextEdit-DisplayFormatString="{0:N0}"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="v_Makhachang" Visible="true" VisibleIndex="0" Caption="Mã khách hàng" HeaderStyle-HorizontalAlign="Center" Width="120px"
                        Settings-AutoFilterCondition="Contains" />
                    <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Visible="true" VisibleIndex="1" Caption="Họ tên" HeaderStyle-HorizontalAlign="Center" Width="200px" />
                    <dx:GridViewDataTextColumn FieldName="d_Ngayden" Visible="false" VisibleIndex="1" Caption="Ngày tham gia" HeaderStyle-HorizontalAlign="Center"
                        PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" />
                    <dx:GridViewDataTextColumn FieldName="v_Mathekhachhang" Visible="true" VisibleIndex="2" Caption="Mã thẻ" HeaderStyle-HorizontalAlign="Center" Width="160px" />
                    <dx:GridViewDataTextColumn FieldName="nv_Tenthetichdiem" Visible="true" VisibleIndex="2" Caption="Tên thẻ" HeaderStyle-HorizontalAlign="Center" Width="150px" />
                    <dx:GridViewDataTextColumn FieldName="d_Ngaycap" Visible="true" VisibleIndex="3" Caption="Ngày kích hoạt" HeaderStyle-HorizontalAlign="Center" Width="120px"
                        PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" />
                    <dx:GridViewDataTextColumn FieldName="d_Ngayhethan" Visible="true" VisibleIndex="3" Caption="Ngày hết hạn" HeaderStyle-HorizontalAlign="Center" Width="120px"
                        PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" />
                </Columns>
                <Templates>
                    <DetailRow>
                        <div style="padding: 3px 3px 2px 3px">
                            <dx:ASPxPageControl ID="PageC_Chitiet" runat="server" Width="100%" EnableCallBacks="true" Font-Size="16px">
                                <TabPages>
                                    <dx:TabPage Text="Chi tiết" Visible="true">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentContro" runat="server">
                                                <div class="Div_Grid" style="width: 89%; height: auto">
                                                    <dx:ASPxGridView ID="Grid_LichsuThe" runat="server" OnBeforePerformDataSelect="Grid_LichsuThe_BeforePerformDataSelect"
                                                        KeyFieldName="uId_Lichsutichdiem" Width="100%">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center"
                                                                FieldName="uId_KH_The" Visible="false" VisibleIndex="-1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Nhân viên" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn"
                                                                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="nv_Hoten_vn">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn Caption="Nội dung" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Noidung"
                                                                Visible="true" VisibleIndex="2" Settings-AllowAutoFilter="Default" Width="500px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Sự kiện" HeaderStyle-HorizontalAlign="Center" FieldName="luachon"
                                                                Visible="true" VisibleIndex="3" Settings-AllowAutoFilter="Default" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Ngày thực hiện" HeaderStyle-HorizontalAlign="Center" FieldName="d_Ngaythuchien"
                                                                Visible="true" VisibleIndex="4" Settings-AllowAutoFilter="Default" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" Width="100px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Số tiền" HeaderStyle-HorizontalAlign="Center" FieldName="f_Diem"
                                                                Visible="true" VisibleIndex="5" Settings-AllowAutoFilter="Default" PropertiesTextEdit-DisplayFormatString="{0:N0}" Width="68px">
                                                            </dx:GridViewDataTextColumn>
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
                <Settings ShowFilterRowMenu="true" ShowFilterRow="true" />
                <SettingsDetail ShowDetailRow="true" />
                <SettingsPager PageSize="10"></SettingsPager>
                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                    </AlternatingRow>
                </Styles>
                <ClientSideEvents SelectionChanged="function(s, e) { Select_Change(s, e); }" />
            </dx:ASPxGridView>
        </fieldset>
    </fieldset>
</asp:Content>
