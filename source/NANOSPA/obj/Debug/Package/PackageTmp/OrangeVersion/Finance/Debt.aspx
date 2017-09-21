<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Debt.aspx.vb" Inherits="NANO_SPA.Debt" %>

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
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
        <script type="text/javascript" src="../../../../Js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
    <link href="../../../../Css/jquery-ui.css" rel="stylesheet" />
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
            var param_dt = "{'uId_Chucnang':'f0e74106-04d7-4d86-ac79-7d3d6eccae55'}";
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
            dgvPhieudichvu.Refresh();
            dgvPhieuxuat.Refresh();
        });
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
        function Chonphieudichvu(uId_Phieudichvu, uId_Khachhang, v_Sophieu, f_Sotienno) {
            var hdfuId_Phieudichvu = document.getElementById("<%=hdfuId_Phieudichvu.ClientID%>");
            var hdfuId_Khachhang = document.getElementById("<%=hdfuId_Khachhang.ClientID%>");
            var hdfv_Sophieu = document.getElementById("<%=hdfv_Sophieu.ClientID%>");
            var hdfuId_Dmthuchi = document.getElementById("<%=hdfuId_Dmthuchi.ClientID%>");
            var hdff_Sotienno = document.getElementById("<%=hdff_Sotienno.ClientID%>");
            hdfuId_Phieudichvu.value = uId_Phieudichvu + "$PDV";
            hdfuId_Khachhang.value = uId_Khachhang;
            hdfuId_Dmthuchi.value = "cee5edc6-769d-4d44-a3fb-24e2c4eb1175";
            hdff_Sotienno.value = f_Sotienno
            var lblSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
            var lblSotienno = document.getElementById("<%=lblSotienno.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            txtSotien.value = jo_FormatMoney(jo_IsString(f_Sotienno));
            lblSotienno.innerHTML = jo_FormatMoney(jo_IsString(f_Sotienno));
            if (f_Sotienno == 0) {
                btnLuu.SetEnabled(false);
            }
            else {
                btnLuu.SetEnabled(true);
                txtGhichu.value = "Thanh toán công nợ phiếu dịch vụ " + v_Sophieu;
                var param_dt = "{'headtext':'PCN'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateTimeCode";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d != "") {
                            lblSophieu.innerHTML = msg.d;
                            hdfv_Sophieu.value = msg.d;
                        }
                    },
                    error: onFail
                });
                txtSotien.focus();
            }
            return false;
        }
        function Chonphieuxuat(uId_Phieuxuat, uId_Khachhang, v_Sophieuxuat, f_Sotienno) {
            var hdfuId_Phieudichvu = document.getElementById("<%=hdfuId_Phieudichvu.ClientID%>");
            var hdfuId_Khachhang = document.getElementById("<%=hdfuId_Khachhang.ClientID%>");
            var hdfv_Sophieu = document.getElementById("<%=hdfv_Sophieu.ClientID%>");
            var hdfuId_Dmthuchi = document.getElementById("<%=hdfuId_Dmthuchi.ClientID%>");
            var hdff_Sotienno = document.getElementById("<%=hdff_Sotienno.ClientID%>");
            hdfuId_Phieudichvu.value = uId_Phieuxuat+"$PX"
            hdfuId_Khachhang.value = uId_Khachhang;
            hdfuId_Dmthuchi.value = "cb74ca0b-0559-431e-8988-47a0275ae60b";
            hdff_Sotienno.value = f_Sotienno
            var lblSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
            var lblSotienno = document.getElementById("<%=lblSotienno.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            txtSotien.value = jo_FormatMoney(jo_IsString(f_Sotienno));
            lblSotienno.innerHTML = jo_FormatMoney(jo_IsString(f_Sotienno));
            if (f_Sotienno == 0) {
                btnLuu.SetEnabled(false);
            }
            else {
                btnLuu.SetEnabled(true);
                txtGhichu.value = "Thanh toán công nợ xuất " + v_Sophieuxuat;
                var param_dt = "{'headtext':'PCN'}";
                var pageUrl = "../../../../Webservice/nano_websv.asmx/CreateTimeCode";
                $.ajax({
                    type: "POST",
                    url: pageUrl,
                    data: param_dt,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (msg) {
                        if (msg.d != "") {
                            lblSophieu.innerHTML = msg.d;
                            hdfv_Sophieu.value = msg.d;
                        }
                    },
                    error: onFail
                });
                txtSotien.focus();
            }
            return false;
        }
        function onkeyup_txtsotiennhan(id) {
            jo_ThousanSereprate(id);
        }
        function ClearText(s, e) {
            var hdfuId_Phieudichvu = document.getElementById("<%=hdfuId_Phieudichvu.ClientID%>");
            var hdfuId_Khachhang = document.getElementById("<%=hdfuId_Khachhang.ClientID%>");
            var hdfv_Sophieu = document.getElementById("<%=hdfv_Sophieu.ClientID%>");
            var hdfuId_Dmthuchi = document.getElementById("<%=hdfuId_Dmthuchi.ClientID%>");
            var hdff_Sotienno = document.getElementById("<%=hdff_Sotienno.ClientID%>");
            hdfuId_Phieudichvu.value = ""
            hdfuId_Khachhang.value = "";
            hdfv_Sophieu.value = "";
            hdfuId_Dmthuchi.value = "";
            hdff_Sotienno.value = ""
            var lblSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
            var lblSotienno = document.getElementById("<%=lblSotienno.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            lblSophieu.innerHTML = "P000000";
            txtSotien.value = "";
            lblSotienno.innerHTML = "0";
            txtGhichu.value = "";
        }
        function InPhieuCongNo(value) {
            if (value=="") {
                alert("Chưa chọn phiếu để in!");
            }
            else {
                alert(value);
                jo_RemoveSession("uIdConNoThanhToan");
                jo_CreateSession("uIdConNoThanhToan", value);
                pcDSPhieucongnoTT.Hide();
                var $dialog = $('<div></div>')
                 .html('<iframe style="border: 0px; " src=" ../../OrangeVersion/Report/Rp_web/Rp_Phieuthanhtoan/rp_Phieudichvu.aspx?Luachon=Congno" width="850px" height="100%"></iframe>')
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

        function InphieuCongnoClick(s, e) {
            pcDSPhieucongnoTT.Show();
            grvdsCongnothanhtoan.Refresh();
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THU HỒI CÔNG NỢ</p>
    </div>
    <asp:HiddenField ID="hdfuId_Phieudichvu" runat="server" />
    <asp:HiddenField ID="hdfuId_Khachhang" runat="server" />
    <asp:HiddenField ID="hdfv_Sophieu" runat="server" />
    <asp:HiddenField ID="hdfuId_Dmthuchi" runat="server" />
    <asp:HiddenField ID="hdff_Sotienno" runat="server" />
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin trả nợ</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td td_0_ipad">Số phiếu
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <asp:Label ID="lblSophieu" Text="P0000000" runat="server"></asp:Label>
                    </td>
                    <td class="info_table_td td_0_ipad">Ngày trả:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <dx:ASPxDateEdit ID="deNgaytra" EditFormat="DateTime" Width="200px" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td td_0_ipad">Ghi chú:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <asp:TextBox runat="server" Width="355px" Height="24px" TextMode="MultiLine" CssClass="nano_textbox ddlMathang" ID="txtGhichu"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td td_0_ipad">Số tiền nợ:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <asp:Label ID="lblSotienno" Text="0" runat="server"></asp:Label>
                    </td>
                    <td class="info_table_td td_0_ipad">Số tiền nhận:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <asp:TextBox runat="server" onkeyup="return onkeyup_txtsotiennhan(this)" Width="200px" CssClass="nano_textbox" ID="txtSotien"></asp:TextBox>
                    </td>
                    <td class="info_table_td td_0_ipad">Loại hình TT:
                    </td>
                    <td class="info_table_td td_0_ipad">
                        <dx:ASPxComboBox ID="ddlLoaithanhtoan" CssClass="ddlMathang" ClientInstanceName="ddlLoaithanhtoan" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="357px" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="5">
                        <dx:ASPxButton ID="btnLuu" OnClick="btnLuu_Click" ClientInstanceName="btnLuu" Image-Url="~/images/16x16/save.png" AutoPostBack="true" Style="float: left; margin-left: 10px" runat="server" Text="Lưu">
                            <Image Url="~/images/16x16/save.png"></Image>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnIn" AutoPostBack="false" Visible="true" Image-Url="~/images/16x16/printer.png"  Style="float: left; margin-left: 10px" ClientInstanceName="btnIn" runat="server" Text="In phiếu">
                           <ClientSideEvents Click="InphieuCongnoClick" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnClear" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnClear" runat="server" Text="Làm mới">
                            <ClientSideEvents Click="ClearText" />
                        </dx:ASPxButton>
                       
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <dx:ASPxGridView ID="dgvDevexpress"  CssClass="grid_dm_dv" runat="server" OnDataBinding="dgvDevexpress_DataBinding" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_Khachhang" SettingsPager-PageSize="8"
        SettingsPager-Position="Bottom">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang"
                Name="uId_Khachhang">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã bệnh nhân" FieldName="v_Makhachang"
                Name="v_Makhachang">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Tên bệnh nhân" FieldName="nv_Hoten_vn"
                Name="nv_Hoten_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Địa chỉ" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn" Name="nv_Diachi_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Điện thoại" Width="100px" Settings-AutoFilterCondition="Contains"
                VisibleIndex="1" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Tổng tiền nợ" FieldName="f_CongnoKH" Name="f_CongnoKH" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Đã trả" FieldName="f_ThuchiKH" Name="f_ThuchiKH" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Còn lại" FieldName="f_CongnoCuoi" CellStyle-ForeColor="Red" Name="f_CongnoCuoi" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewBandColumn VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Trong đó">
                <Columns>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Width="100px" HeaderStyle-HorizontalAlign="Center"
                        Caption="Nợ DV" FieldName="f_CongnoDVKH" Name="f_CongnoDVKH" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                        Caption="Nợ SP" FieldName="f_CongnoSPKH" Name="f_CongnoSPKH" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>
        </Columns>
        <Templates>
            <DetailRow>
                <div style="padding: 3px 3px 2px 3px">
                    <dx:ASPxPageControl ID="pageControl" runat="server" Width="100%" EnableCallBacks="true">
                        <TabPages>
                            <dx:TabPage Text="Phiếu nợ dịch vụ" Visible="true">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl1" runat="server">
                                        <dx:ASPxGridView ID="dgvPhieudichvu" ClientInstanceName="dgvPhieudichvu" OnBeforePerformDataSelect="dgvPhieudichvu_BeforePerformDataSelect" runat="server"
                                            KeyFieldName="uId_Phieudichvu" Width="100%">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Số phiếu" FieldName="v_Sophieu"
                                                    Name="v_Sophieu">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="d_Ngay"
                                                    Name="d_Ngay">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Width="300px" Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu_vn"
                                                    Name="nv_Ghichu_vn">
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Tổng giá trị phiếu" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                    FieldName="Tonggiatri" Name="Tonggiatri">
                                                </dx:GridViewDataTextColumn>
                                                 <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán phiếu" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                    FieldName="f_Tongtienthuc" Name="f_Tongtienthuc">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán nợ" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                    FieldName="f_Dathanhtoan" Name="f_Dathanhtoan">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Còn nợ" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                    FieldName="f_Sotienno" Name="f_Sotienno">
                                                    <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" >
                                                    <DataItemTemplate>
                                                        <a id="popup" title="Chọn phiếu <%#Eval("v_Sophieu") %>" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieudichvu('{0}', '{1}', '{2}', '{3}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("v_Sophieu"), Eval("f_Sotienno")).ToString%>">
                                                            <img src="../../../images/bub.png" /></a>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Templates>
                                                <DetailRow>
                                                    <div style="padding: 3px 3px 2px 3px">
                                                        <dx:ASPxGridView ID="dgvPhieuchitiet" OnBeforePerformDataSelect="dgvPhieuchitiet_BeforePerformDataSelect" runat="server"
                                                            KeyFieldName="uId_Phieudichvu_Chitiet" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="" FieldName="uId_Phieudichvu" Name="uId_Phieudichvu">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="" FieldName="uId_Dichvu" Name="uId_Dichvu">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn" Name="nv_Tendichvu_vn">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Tổng S.Lần" FieldName="f_Solan" Name="f_Solan">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Đã ĐT" FieldName="i_SL_daDieutri" Name="i_SL_daDieutri">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Đơn giá" FieldName="f_Dongia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Giảm giá" FieldName="f_Giamgia" Name="f_Giamgia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                    Caption="Thành tiền" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </div>
                                                </DetailRow>
                                            </Templates>
                                            <SettingsDetail ShowDetailRow="true" />
                                            <Settings ShowFooter="true" />
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="f_Tongtienthuc" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem FieldName="f_Sotienno" SummaryType="Sum" />
                                            </TotalSummary>
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="Phiếu nợ sản phẩm" Visible="true">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl2" runat="server">
                                        <div style="padding: 3px 3px  3px">
                                            <dx:ASPxGridView ID="dgvPhieuxuat" ClientInstanceName="dgvPhieuxuat" OnBeforePerformDataSelect="dgvPhieuxuat_BeforePerformDataSelect" runat="server"
                                                KeyFieldName="uId_Phieuxuat" Width="100%">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                        Caption="Số phiếu" FieldName="v_Maphieuxuat" Name="v_Maphieuxuat">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                        Caption="Ngày xuất" FieldName="d_Ngayxuat" Name="d_Ngayxuat">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                        Caption="Tổng giá trị phiêu" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="Tonggiatri" Name="Tonggiatri">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                        Caption="Đã thanh toán nợ" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dathanhtoan" Name="f_Dathanhtoan">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                        Caption="Đã thanh toán phiếu" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongtienthuc" Name="f_Tongtienthuc">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" CellStyle-ForeColor="Red" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                        Caption="Còn nợ" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Sotienno" Name="f_Sotienno">
                                                        <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <a id="popup" title="Chọn phiếu <%#Eval("v_Maphieuxuat") %>" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieuxuat('{0}', '{1}', '{2}', '{3}')", Eval("uId_Phieuxuat"), Eval("uId_Khachhang"), Eval("v_Maphieuxuat"), Eval("f_Sotien")).ToString%>">
                                                                <img src="../../../images/bub.png" /></a>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <Templates>
                                                    <DetailRow>
                                                        <div style="padding: 3px 3px 2px 3px">
                                                            <dx:ASPxGridView ID="dgvPhieuxuatchitiet" OnBeforePerformDataSelect="dgvPhieuxuatchitiet_BeforePerformDataSelect" runat="server"
                                                                KeyFieldName="uId_Phieuxuat_Chitiet" Width="100%">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                        Caption="Tên hàng" FieldName="nv_TenMathang_vn" Name="nv_TenMathang_vn">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                        Caption="ĐVT" FieldName="nv_DVT_vn" Name="nv_DVT_vn">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                        Caption="Số lượng" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Soluong" Name="f_Soluong">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                        Caption="Đơn giá" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Dongia" Name="f_Dongia">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                        Caption="Giảm giá" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Giamgia" Name="f_Giamgia">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                        Caption="Tổng tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}" FieldName="f_Tongtien" Name="f_Tongtien">
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                    </DetailRow>
                                                </Templates>
                                                <SettingsDetail ShowDetailRow="true" />
                                                <Settings ShowFooter="true" />
                                                <TotalSummary>
                                                    <dx:ASPxSummaryItem FieldName="f_Tongtienthuc" SummaryType="Sum" />
                                                    <dx:ASPxSummaryItem FieldName="f_Sotien" SummaryType="Sum" />
                                                </TotalSummary>
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
        <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="grid_EndCallback" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDSPhieucongnoTT" Font-Size="25px"
        HeaderText="Khách hàng " AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" Width="600px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <fieldset class="field_tt">
                                <ul>
                                    <li class="text_title">Ngày thanh toán:</li>
                                    <li class="text_title">
                                        <dx:ASPxDateEdit runat="server" ID="dateNgay" DisplayFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                    </li>
                                </ul>
                            </fieldset>
                            <fieldset class="field_tt" style="width: 97%; margin: auto auto 10px">
                                <legend><span style="font-weight: bold; color: green; font-size: 18px">Thông tin đặt lịch ngày </span></legend>
                                <dx:ASPxGridView ID="GrvDanhsachCongno" ClientInstanceName="grvdsCongnothanhtoan" AutoGenerateColumns="false" runat="server" KeyFieldName="uId_Congno_Thanhtoan"
                                    Width="100%">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Khách hàng" FieldName="nv_Hoten_vn"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Điện thoại" FieldName="v_DienthoaiDD"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Số tiền thanh toán" FieldName="f_Sotien_Nolai"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <a id="popup" title="Chọn phiếu công nợ" href='javascript:void(0)' onclick="return <%# String.Format("InPhieuCongNo('{0}')", Eval("uId_Congno_Thanhtoan")).ToString%>">
                                                    <img src="../../../images/bub.png" /></a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsText EmptyDataRow="Đây là bệnh nhân mới!" />
                                </dx:ASPxGridView>
                            </fieldset>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
