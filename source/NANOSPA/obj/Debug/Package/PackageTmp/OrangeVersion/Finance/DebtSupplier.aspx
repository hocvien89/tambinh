<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DebtSupplier.aspx.vb" Inherits="NANO_SPA.Debtsupplier" %>

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
        function Chonphieunhap(uId_Phieunhap, uId_Nhacungcap, v_Maphieunhap, f_Tienno) {
            var hdfuId_Phieunhap = document.getElementById("<%=hdfuId_Phieunhap.ClientID%>");
            var hdfuId_Nhacungcap = document.getElementById("<%=hdfuId_Nhacungcap.ClientID%>");
            var hdfv_Maphieunhap = document.getElementById("<%=hdfv_Maphieunhap.ClientID%>");
            var hdfuId_Dmthuchi = document.getElementById("<%=hdfuId_Dmthuchi.ClientID%>");
            var hdff_Tienno = document.getElementById("<%=hdff_Tienno.ClientID%>");
            hdfuId_Phieunhap.value = uId_Phieunhap
            hdfuId_Nhacungcap.value = uId_Nhacungcap;
            hdfuId_Dmthuchi.value = "cee5edc6-769d-4d44-a3fb-24e2c4eb1175";
            hdff_Tienno.value = f_Tienno
            var lblSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
            var lblSotienno = document.getElementById("<%=lblSotienno.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            txtSotien.value = jo_FormatMoney(jo_IsString(f_Tienno));
            lblSotienno.innerHTML = jo_FormatMoney(jo_IsString(f_Tienno));
            txtGhichu.value = "Thanh toán công nợ NCC mã phiếu " + v_Maphieunhap;
            var param_dt = "{'headtext':'PTNCC'}";
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
                        hdfv_Maphieunhap.value = msg.d;
                    }
                },
                error: onFail
            });
            txtSotien.focus();
            return false;
        }
        function onkeyup_txtsotiennhan(id) {
            jo_ThousanSereprate(id);
        }
        function ClearText(s, e) {
            var hdfuId_Phieunhap = document.getElementById("<%=hdfuId_Phieunhap.ClientID%>");
            var hdfuId_Nhacungcap = document.getElementById("<%=hdfuId_Nhacungcap.ClientID%>");
            var hdfv_Maphieunhap = document.getElementById("<%=hdfv_Maphieunhap.ClientID%>");
            var hdfuId_Dmthuchi = document.getElementById("<%=hdfuId_Dmthuchi.ClientID%>");
            var hdff_Tienno = document.getElementById("<%=hdff_Tienno.ClientID%>");
            hdfuId_Phieunhap.value = ""
            hdfuId_Nhacungcap.value = "";
            hdfv_Maphieunhap.value = "";
            hdfuId_Dmthuchi.value = "";
            hdff_Tienno.value = ""
            var lblSophieu = document.getElementById("<%=lblSophieu.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
            var lblSotienno = document.getElementById("<%=lblSotienno.ClientID%>");
            var txtGhichu = document.getElementById("<%=txtGhichu.ClientID%>");
            lblSophieu.innerHTML = "P000000";
            txtSotien.value = "";
            lblSotienno.innerHTML = "0";
            txtGhichu.value = "";
        }
        function checkEmpty(s, e) {
            var hdfuId_Phieunhap = document.getElementById("<%=hdfuId_Phieunhap.ClientID%>");
            var hdff_Tiennomoi = document.getElementById("<%=hdff_Tiennomoi.ClientID%>");
            var lblSotienno = document.getElementById("<%=lblSotienno.ClientID%>");
            var txtSotien = document.getElementById("<%=txtSotien.ClientID%>");
            if (hdfuId_Phieunhap.value == "") {
                alert("Hãy chọn phiếu nợ cần thanh toán");
                e.processOnServer = false;
            }
            else {
                hdff_Tiennomoi.value = parseFloat(lblSotienno.innerHTML.replace(/,/g, "") - parseFloat(txtSotien.value.replace(/,/g, "")));
            }
        }
    </script>

    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THANH TOÁN CÔNG NỢ NHÀ CUNG CẤP</p>
    </div>
        <asp:HiddenField ID="hdfuId_Phieunhap" runat="server" />
    <asp:HiddenField ID="hdfuId_Nhacungcap" runat="server" />
    <asp:HiddenField ID="hdfv_Maphieunhap" runat="server" />
    <asp:HiddenField ID="hdfuId_Dmthuchi" runat="server" />
    <asp:HiddenField ID="hdff_Tienno" runat="server" />
    <asp:HiddenField ID ="hdff_Tiennomoi" runat="server" />
    <div style="margin: auto">
        <fieldset style="width: 98%">
            <legend><span style="font-weight: bold; color: green">Thông tin phiếu nợ nhà cung cấp</span></legend>
            <table class="info_table">
                <tbody>
                    <tr>
                        <td class="info_table_td">Số phiếu
                        </td>
                        <td class="info_table_td" style="width:150px">
                            <asp:Label ID="lblSophieu" Text="P0000000" runat="server"></asp:Label>
                        </td>
                        <td class="info_table_td">Ngày trả:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxDateEdit ID="deNgaytra" EditFormat="DateTime" Width="200px" EditFormatString="dd/MM/yyyy"
                                runat="server">
                            </dx:ASPxDateEdit>
                        </td>
                        <td class="info_table_td">Ghi chú:
                        </td>
                        <td rowspan="3" class="info_table_td">
                            <asp:TextBox runat="server" Width="355px" Height="73px" TextMode="MultiLine" CssClass="nano_textbox" ID="txtGhichu"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Số tiền nợ:
                        </td>
                        <td class="info_table_td">
                            <asp:Label ID="lblSotienno" Text="0" runat="server"></asp:Label>
                        </td>
                        <td class="info_table_td">Số tiền trả:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox runat="server" onkeyup="return onkeyup_txtsotiennhan(this)" Width="200px" CssClass="nano_textbox" ID="txtSotien"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="5">
                            <dx:ASPxButton ID="btnLuu" ClientInstanceName="btnLuu" Image-Url="~/images/16x16/save.png" AutoPostBack="true" 
                                Style="float: left; margin-left: 10px" runat="server" Text="Lưu" OnClick="btnLuu_Click">
                                <Image Url="~/images/16x16/save.png"></Image>
                                <ClientSideEvents Click="checkEmpty" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnIn" AutoPostBack="false" Visible="false" Image-Url="~/images/16x16/printer.png" Style="float: left; margin-left: 10px" ClientInstanceName="btnIn" runat="server" Text="In phiếu">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnClear" Image-Url="~/images/16x16/page_white.png" AutoPostBack="false" Style="float: left; margin-left: 10px" ClientInstanceName="btnClear" runat="server" Text="Làm mới">
                                <ClientSideEvents Click="ClearText" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
        <fieldset style="width: 98%">
            <legend><span style="font-weight: bold; color: green">Danh sách nợ nhà cung cấp</span></legend>
            <dx:ASPxGridView ID="dgvDevexpress" runat="server" ClientInstanceName="client_grid" OnDataBinding="dgvDevexpress_DataBinding"
                AutoGenerateColumns="false" KeyFieldName="uId_Nhacungcap" SettingsPager-PageSize="8"
                SettingsPager-Position="Bottom">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Nhacungcap"
                        Name="uId_Khachhang">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        Width="200px" HeaderStyle-HorizontalAlign="Center" Caption="Mã Nhà cung cấp" FieldName="v_Manhacungcap"
                        Name="v_Manhacungcap">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        Width="200px" HeaderStyle-HorizontalAlign="Center" Caption="Tên nhà cung cấp" FieldName="nv_Tennhacungcap_vn"
                        Name="nv_Tennhacungcap_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Địa chỉ" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn" Name="nv_Diachi_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                        Caption="Tổng tiền" FieldName="f_Tongtien" Name="f_Tongtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                        Caption="Đã trả" FieldName="f_Tongtra" Name="f_Tongtra" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                        Caption="Còn lại" FieldName="f_Tienno" CellStyle-ForeColor="Red" Name="f_Tienno" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <div style="padding: 3px 3px 2px 3px">
                            <dx:ASPxPageControl ID="pageControl" runat="server" Width="100%" EnableCallBacks="true">
                                <TabPages>
                                    <dx:TabPage Text="Phiếu nhập nợ" Visible="true">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <dx:ASPxGridView ID="dgvPhieuNoNCC" runat="server" OnBeforePerformDataSelect="dgvPhieuNoNCC_BeforePerformDataSelect"
                                                    KeyFieldName="uId_Phieunhap" Width="100%">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Số phiếu" FieldName="v_Maphieunhap"
                                                            Name="v_Maphieunhap">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Ngày lập" FieldName="d_Ngaynhap"
                                                            Name="d_Ngaynhap">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Tổng tiền" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                            FieldName="f_Tongtien" Name="f_Tongtien">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Đã thanh toán" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                            FieldName="f_Tongtienthuc" Name="f_Tongtienthuc">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Caption="Còn nợ" CellStyle-ForeColor="Red" PropertiesTextEdit-DisplayFormatString="{0:0,0}"
                                                            FieldName="f_Tienno" Name="f_Tienno">
                                                            <FooterCellStyle ForeColor="Red"></FooterCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                                            <DataItemTemplate>
                                                                <a id="popup" title="Chọn phiếu <%#Eval("v_Maphieunhap")%>" href='javascript:void(0)' onclick="return <%# String.Format("Chonphieunhap('{0}', '{1}', '{2}', '{3}')", Eval("uId_Phieunhap"), Eval("uId_Nhacungcap"), Eval("v_Maphieunhap"), Eval("f_Tienno")).ToString%>">
                                                                    <img src="../../../images/bub.png" /></a>
                                                            </DataItemTemplate>
                                                        </dx:GridViewDataColumn>
                                                    </Columns>
                                                    <Templates>
                                                        <DetailRow>
                                                            <div style="padding: 3px 3px 2px 3px">
                                                                <dx:ASPxGridView ID="dgvPhieuchitiet" runat="server" OnBeforePerformDataSelect="dgvPhieuchitiet_BeforePerformDataSelect"
                                                                    KeyFieldName="uId_Phieunhap_Chitiet" Width="100%">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="" FieldName="uId_Phieunhap_Chitiet" Name="uId_Phieunhap_Chitiet">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="Mã mặt hàng" FieldName="v_Mathang" Name="v_Mathang">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="Tên mặt hàng" FieldName="nv_TenMathang_vn" Name="nv_Tenmathang_vn">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="Đơn vị tính" FieldName="MADONVI" Name="f_Solan">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="Đơn giá" FieldName="f_Donggia" Name="f_Dongia" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="Thành tiền" FieldName="f_Thanhtien" Name="f_Thanhtien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
                                                                        </dx:GridViewDataTextColumn>
                                                                    </Columns>
                                                                    <Settings ShowFooter="true" />
                                                                </dx:ASPxGridView>
                                                            </div>
                                                        </DetailRow>
                                                    </Templates>
                                                    <SettingsDetail ShowDetailRow="true" />
                                                    <Settings ShowFooter="true" />
                                                    <TotalSummary>
                                                        <dx:ASPxSummaryItem FieldName="f_Tongtien" SummaryType="Sum" />
                                                        <dx:ASPxSummaryItem FieldName="f_Tongtienthuc" SummaryType="Sum" />
                                                        <dx:ASPxSummaryItem FieldName="f_Tienno" SummaryType="Sum" />
                                                    </TotalSummary>
                                                </dx:ASPxGridView>
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
                <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                <ClientSideEvents EndCallback="grid_EndCallback" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                    </AlternatingRow>
                </Styles>
            </dx:ASPxGridView>
        </fieldset>
    </div>
</asp:Content>
