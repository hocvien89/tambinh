<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AccountCard.aspx.vb" Inherits="NANO_SPA.AccountCard" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>


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
            var param_dt = "{'uId_Chucnang':'6b74ddf3-681d-4f9c-9320-764069867310'}";
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
            if (s.cpIsDelete_TheKH == "NO_DELETE") {
                alert("Bạn không có quyền xóa thẻ khách hàng.");
                s.cpIsDelete_TheKH = "";
            }
        }
        function Kichhoatthetaikhoan(uId_Khachhang_Goidichvu, v_Mathe, f_Sotien, d_NgayKT, f_Giatri) {
            jo_CreateSession("uId_Khachhang_Goidichvu", uId_Khachhang_Goidichvu);
            var txt_Mavach = document.getElementById("<%=txtMavach.ClientID%>");
            var txt_Sotien = document.getElementById("<%=txtGiatri.ClientID%>");
            txt_Sotien.value =  jo_FormatMoney(f_Sotien);
            txt_Tongtien_The.SetValue(jo_FormatMoney(f_Giatri));
            txt_Mavach.value = v_Mathe;
            //deNgayhethan.SetText(d_NgayKT);
            cb_Khachhang.PerformCallback();
            pcCapthe.Show();
        }
        function ClosePopup_The(s, e) {
            pcCapthe.Hide();
            client_grid.Refresh();
            return false;
        }
        function txt_Uudai_NumberChanged() {
            var f_Uudai = txt_Uudai.GetValue();
            var txt_Giatri = document.getElementById("<%=txtGiatri.ClientID%>");
            var f_Giatri = txt_Giatri.value.replace(/,/g, "");
            var f_Tienkhuyenmai = parseFloat(f_Uudai) * parseFloat(f_Giatri) / 100;
            var f_Tongtien = parseFloat(f_Giatri) + parseFloat(f_Tienkhuyenmai);
            txt_Tongtien_The.SetValue(jo_FormatMoney(f_Tongtien));
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ THẺ TÀI KHOẢN</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <ul>
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
             <li class="text_title">Trạng thái: </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cb_Trangthai" ValueType ="System.String" runat="server" SelectedIndex="0">
                   <Items>
                       <dx:ListEditItem Text="Tất cả" Value="ALL"/>
                       <dx:ListEditItem Text="Kích hoạt" Value="1" />
                       <dx:ListEditItem Text="Chưa kích hoạt" Value="0" />
                   </Items>
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnFilter" Width="100px" OnClick="btnFilter_Click" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Lọc">
                </dx:ASPxButton>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btn_ImportExcel" Image-Url="~/images/Excel-icon.png" OnClick="btn_ImportExcel_Click" ClientInstanceName="btnThemmoi" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                    runat="server" Text="Xuất Excel">
                </dx:ASPxButton>
            </li>
        </ul>
    </fieldset>
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid" 
        AutoGenerateColumns="false" KeyFieldName="uId_Khachhang_Goidichvu;uId_Khachhang" OnRowDeleting="dgvDevexpress_RowDeleting"
        SettingsPager-Position="Bottom" Width="100%">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang_Goidichvu"
                Name="uId_Khachhang_Goidichvu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Mã thẻ" FieldName="vMaBarcode"
                Name="vMaBarcode">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                Width="200px" HeaderStyle-HorizontalAlign="Center" Caption="Tên thẻ" FieldName="nv_Tendichvu_vn"
                Name="nv_Tendichvu_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Khách hàng" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn" Width="150px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Mã khách hàng" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" Width="100px" FieldName="v_Makhachang" Name="v_Makhachang">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Điện thoại" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                 HeaderStyle-HorizontalAlign="Center" Caption="Ngày cấp" FieldName="d_Ngaymua"
                Name="d_Ngaymua" Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                 HeaderStyle-HorizontalAlign="Center" Caption="Ngày hết hạn" FieldName="d_NgayKT"
                Name="d_NgayKT" Width="100px">
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Visible="True" Width="90px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Giá trị" FieldName="f_Sotien" Name="f_Sotien" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="90px" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                Caption="Giá trị sử dụng" FieldName="f_Giatrigoi" Name="f_Giatrigoi" PropertiesTextEdit-DisplayFormatString="{0:0,0}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Trạng thái" HeaderStyle-HorizontalAlign="Center" FieldName="b_Kichhoat"
                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="b_Kichhoat" Width="100px">
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Caption="Ngày kích hoạt" HeaderStyle-HorizontalAlign="Center" FieldName="d_NgayBD"
                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="d_NgayBD" Width="100px">
            </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn Caption="Khách hàng sử dụng thẻ" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn_Kichhoat"
                Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" Name="nv_Hoten_vn_Kichhoat" Width="200px">
            </dx:GridViewDataTextColumn>
<%--            <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image">
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton>
                    <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                </UpdateButton>
                <EditButton Visible="true">
                    <Image AlternateText="Edit" Url="~/images/btn_Edit.png"></Image>
                </EditButton>
            </dx:GridViewCommandColumn>--%>
              <dx:GridViewDataColumn Width="40px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate >
                        <a id="popup" title="Kích hoạt thẻ" href='javascript:void(0)' onclick="return <%# String.Format("Kichhoatthetaikhoan('{0}','{1}','{2}','{3}','{4}')", Eval("uId_Khachhang_Goidichvu"), Eval("vMaBarcode"), Eval("f_Sotien"), Eval("d_NgayKT"), Eval("f_Giatrigoi")).ToString%>">
                            <dx:ASPxImage runat="server" OnInit="Image_Init" ID="Image_Lock"></dx:ASPxImage>   
                        </a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            <dx:GridViewCommandColumn VisibleIndex="5" Width="30px" ButtonType="Image">
                <DeleteButton Visible="true">
                    <Image AlternateText="Delete" Url="~/images/btn_Delete.png" />
                </DeleteButton>
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" HorizontalScrollBarMode="Visible" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="grid_EndCallback" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="dgv_exporterThe" OnRenderBrick="dgv_exporterThe_RenderBrick" runat="server"></dx:ASPxGridViewExporter>
      <dx:ASPxPopupControl ID="pcCapthe" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcCapthe"
        HeaderText="Kích hoạt thẻ" AllowDragging="True" PopupAnimationType="None">
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
                                        <legend><span style="font-weight: bold; color: green">Kích hoạt thẻ tài khoản </span></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class="info_table_td"> Seri thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtMavach"></asp:TextBox>
                                                </td>
                                                <td class="info_table_td">Khách hàng:
                                                </td>
                                                <td class="info_table_td">
                                                  <dx:ASPxComboBox runat="server" ID="cb_Khachhang" ClientInstanceName="cb_Khachhang"  OnCallback="cb_Khachhang_Callback" TextFormatString="{1}" ValueField="uId_Khachhang" Width="200px" AutoPostBack="false">
                                                      <Columns>
                                                          <dx:ListBoxColumn Caption="Mã khách hàng" FieldName="v_Makhachang"/>
                                                          <dx:ListBoxColumn Caption="Họ tên" FieldName="nv_Hoten_vn" />
                                                      </Columns>
                                                  </dx:ASPxComboBox>
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
                                               <td class="info_table_td">Giá trị thẻ:
                                                </td>
                                                <td class="info_table_td">
                                                    <asp:TextBox runat="server" Width="200px" CssClass="nano_textbox" ID="txtGiatri"></asp:TextBox>
                                                </td>
                                                <td></td>
                                                 <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltrSuccess" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div class="pcmButton">
                                                        <dx:ASPxButton ID="btLuuthe" Image-Url="~/images/btn_Save.png" ClientInstanceName="btLuuthe" OnClick="btLuuthe_Click" runat="server" Text="Kích hoạt" Style="float: left; margin-right: 8px">
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
</asp:Content>
