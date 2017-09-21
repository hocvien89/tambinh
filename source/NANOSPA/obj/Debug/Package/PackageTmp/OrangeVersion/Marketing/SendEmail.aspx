<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="SendEmail.aspx.vb" Inherits="NANO_SPA.SendEmail" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

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
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'edf44f30-d081-47d0-bc1d-32f4c8382579'}";
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
        function ShowPopup(s, e) {
            pcPop.Show();
            return false;
        }
        function HidePop(s, e) {
            pcPop.Hide();

        }
        function grid_SelectionChanged(s, e) {

        }

        function OnAllCheckedChanged(s, e) {
            client_grid.PerformCallback(s.GetChecked());
        }

        function OnPageCheckedChanged(s, e) {
            var indexes = client_grid.cpIndexesUnselected;
            var topVisibleIndex = client_grid.GetTopVisibleIndex();
            if (s.GetChecked()) {
                //Select All Rows On Page();
                for (var i = topVisibleIndex; i < topVisibleIndex + client_grid.cpPageSize; i++) {
                    if (indexes.indexOf(i) == -1)
                        client_grid.SelectRowOnPage(i, true);
                }
            }
            else
                //Deselect All Rows On Page();
                for (var i = topVisibleIndex; i < topVisibleIndex + client_grid.cpPageSize; i++) {
                    if (indexes.indexOf(i) == -1)
                        client_grid.SelectRowOnPage(i, false);
                }
        }

        function setGridHeaderCheckboxes(s, e) {
            //cbAll
            var indexes = client_grid.cpIndexesSelected;
            //cbAll.SetChecked(s.GetSelectedRowCount() == Object.size(indexes));

            //cbPage
            var allEnabledRowsOnPageSelected = true;
            var indexes = client_grid.cpIndexesUnselected;
            var topVisibleIndex = client_grid.GetTopVisibleIndex();
            for (var i = topVisibleIndex; i < topVisibleIndex + client_grid.cpPageSize; i++) {
                if (indexes.indexOf(i) == -1)
                    if (!client_grid.IsRowSelectedOnPage(i)) allEnabledRowsOnPageSelected = false;
            }
            cbPage.SetChecked(allEnabledRowsOnPageSelected);
        }

        function OnGridEndCallback(s, e) {
            setGridHeaderCheckboxes(s, e);
        }

        function OnGridSelectionChanged(s, e) {
            setGridHeaderCheckboxes(s, e);
        }

        Object.size = function (obj) {
            var size = 0, key;
            for (key in obj) {
                if (obj.hasOwnProperty(key)) size++;
            }
            return size;
        };
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>GỬI EMAIL</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin gửi</span></legend>
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <table class="info_table">
                    <tr>
                        <td class="info_table_td">Danh sách Email:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtSDT" AutoPostBack="false" runat="server" TextMode="MultiLine" Height="46px" Width="800px" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnShow" ClientInstanceName="btnShow" AutoPostBack="false" runat="server" Text="Chọn email">
                                <ClientSideEvents Click="ShowPopup" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Chủ đề:
                        </td>
                        <td class="info_table_td">
                            <asp:TextBox ID="txtChude" AutoPostBack="false" runat="server" Width="800px" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">Nội dung:
                        </td>
            
                        <td class="info_table_td">
                            <dx:ASPxHtmlEditor ID="htmleditor_noidung" runat="server">
                                <SettingsImageUpload UploadImageFolder="~/Uploads/images/">
                                    <ValidationSettings AllowedFileExtensions=".jpe,.jpeg,.jpg,.gif,.png" MaxFileSize="500000">
                                    </ValidationSettings>
                                </SettingsImageUpload>
                            </dx:ASPxHtmlEditor>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td"> <asp:Literal ID="lblFail" runat="server"></asp:Literal></td>
                        <td class="info_table_td">
                            <dx:ASPxButton ID="btnOk" OnClick="btnOk_Click" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOkCV" runat="server" Text="Gửi Email" Style="float: left; margin-right: 8px">
                            </dx:ASPxButton>
                              <dx:ASPxButton ID="btnClear" OnClick="btnClear_Click"  ClientInstanceName="btnClear" runat="server" Text="Xóa trắng" Style="float: left; margin-right: 8px">
                            </dx:ASPxButton>
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                </table>
                <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="up1"
                    DisplayAfter="0" DynamicLayout="false">
                    <ProgressTemplate>
                        <img alt="In progress..." src="../../images/progress.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <dx:ASPxPopupControl ID="pcPop" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcPop"
        HeaderText="Danh sách khách hàng" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcPop.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="900px" Height="370px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div style="clear: both"></div>
                            <dx:ASPxGridView ID="dgvDevexpress" Width="100%" runat="server" OnDataBound="grid_DataBound" ClientInstanceName="client_grid"
                                AutoGenerateColumns="false" KeyFieldName="uId_Khachhang;nv_Hoten_vn"
                                SettingsPager-Position="Bottom" OnCustomJSProperties="grid_CustomJSProperties">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Width="30px" VisibleIndex="0">
                                        <HeaderTemplate>
                                            <dx:ASPxCheckBox ID="cbAll" Visible="false" runat="server" ClientInstanceName="cbAll" ToolTip="Select all rows"
                                                BackColor="White" OnInit="cbAll_Init">
                                                <ClientSideEvents CheckedChanged="OnAllCheckedChanged" />
                                            </dx:ASPxCheckBox>
                                            <dx:ASPxCheckBox ID="cbPage" runat="server" ClientInstanceName="cbPage" ToolTip="Select all rows within the page">
                                                <ClientSideEvents CheckedChanged="OnPageCheckedChanged" />
                                            </dx:ASPxCheckBox>
                                        </HeaderTemplate>
                                    </dx:GridViewCommandColumn>
                                    <%--  <dx:GridViewCommandColumn Width="30px" ShowSelectCheckbox="True" Visible="true" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>--%>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Khachhang"
                                        Name="uId_Khachhang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã khách hàng" FieldName="v_Makhachang"
                                        Name="v_Makhachang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Tên khách hàng" FieldName="nv_Hoten_vn"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="90" VisibleIndex="2" Caption="Ngày sinh" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" FieldName="d_Ngaysinh" Name="d_Ngaysinh">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Địa chỉ" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" FieldName="nv_Diachi_vn" Name="nv_Diachi_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Điện thoại" Width="100px" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Email" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="v_Email" Name="v_Email">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ngày đến" Width="90" Settings-AutoFilterCondition="Contains"
                                        VisibleIndex="3" FieldName="d_Ngayden" Name="d_Ngayden" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="20">
                                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" VerticalScrollableHeight="200" VerticalScrollBarMode="Visible" />
                                <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                <ClientSideEvents SelectionChanged="OnGridSelectionChanged" EndCallback="OnGridEndCallback" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                </Styles>
                            </dx:ASPxGridView>
                            <dx:ASPxButton ID="btnHow" OnClick="btnGet_Click" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOkCV" runat="server" Text="Chọn khách hàng" Style="float: left; margin-right: 8px">
                                <ClientSideEvents Click="HidePop" />
                            </dx:ASPxButton>
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
