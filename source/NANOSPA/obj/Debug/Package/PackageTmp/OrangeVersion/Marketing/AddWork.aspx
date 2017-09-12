<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AddWork.aspx.vb" Inherits="NANO_SPA.AddWork" %>

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
        function ddlTukhoa_SelectedIndexChanged(s, e) {
            var tag = jo_GetSession("tags");
            var tag_new = tag + "$" + ddlTukhoa.GetValue().toString();
            jo_CreateSession("tags", tag_new);
            client_Tukhoa.Refresh();
            ddlTukhoa.SetValue("");
            ddlTukhoa.Focus();
        }
        function ClearTextWork() {
            var txtGhichuCV = document.getElementById("<%=txtGhichuCV.ClientID()%>");
            txtGhichuCV.value = "";
            jo_CreateSession("tags", "");
            client_Tukhoa.Refresh();
            ddlTukhoa.Focus();
        }
        function ClearTextWork_Pop(s, e) {
            ClearTextWork();
        }
        function BackQuanLyKhachHang(s, e) {
            window.location.href = "../../OrangeVersion/Marketing/CustomerCare.aspx";
            return false;
        }
    </script>
    <div class="brest_crum">
        <dx:ASPxButton ID="btnQuaylai" Style="float: left; margin-right: 7px; margin-left: 5px" Image-Url="~/images/16x16/back.png" ClientInstanceName="btnQuaylai" AutoPostBack="false" runat="server" Text="Quay lại">
            <ClientSideEvents Click="BackQuanLyKhachHang" />
        </dx:ASPxButton>
        <asp:Literal ID="ltrTitleHeader" Text="THÊM CÔNG VIỆC MARKETING" runat="server"></asp:Literal>
    </div>
    <div style="clear: both"></div>
    <asp:UpdatePanel ID="upCongviec" runat="server">
        <ContentTemplate>
            <fieldset class="field_tt">
                <legend><span style="font-weight: bold; color: green">Công việc</span></legend>
                <table class="info_table">
                    <tr>
                        <td class="info_table_td" style="width: 423px">
                            <table class="info_table">
                                <tr>
                                    <td class="info_table_td">Họ tên:
                                    </td>
                                    <td class="info_table_td">
                                        <asp:TextBox ID="txtHotenKH" Enabled="false" AutoPostBack="false" onkeypress="return enter_txtHoten(event)" runat="server" Width="330px" CssClass="nano_textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info_table_td">Ngày làm:
                                    </td>
                                    <td class="info_table_td">
                                        <dx:ASPxDateEdit ID="deNgaylam" UseMaskBehavior="true" ClientInstanceName="deNgaylam" Width="330px" EditFormat="Custom"
                                            runat="server">
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info_table_td">Ghi chú:
                                    </td>
                                    <td class="info_table_td">
                                        <asp:TextBox ID="txtGhichuCV" TextMode="MultiLine" runat="server" Width="330px" Height="88px" CssClass="nano_textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <span class='error' id='Span1'></span>
                                        <asp:Literal ID="ltrErrorCV" runat="server"></asp:Literal>
                                        <asp:Literal ID="ltrSuccessCV" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="info_table_td">
                            <table class="info_table">
                                <tr>
                                    <td class="info_table_td" style="text-align: right">Từ khóa:
                                    </td>
                                    <td class="info_table_td">
                                        <dx:ASPxComboBox ID="ddlTukhoa" CallbackPageSize="10" ClientInstanceName="ddlTukhoa" DropDownStyle="DropDown" IncrementalFilteringMode="Contains" EnableCallbackMode="true" Height="25px" Width="400px" runat="server" ValueType="System.String">
                                            <ClientSideEvents SelectedIndexChanged="ddlTukhoa_SelectedIndexChanged" />
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info_table_td" rowspan="2" colspan="2">
                                        <dx:ASPxGridView ID="dgvTukhoa" runat="server" ClientInstanceName="client_Tukhoa" AutoGenerateColumns="false" OnRowDeleting="dgvTukhoa_RowDeleting"
                                            KeyFieldName="uId_Tags" SettingsPager-PageSize="3" SettingsPager-Position="Bottom">
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Tags"
                                                    Name="uId_Tags">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="Center" Caption="Từ khóa" FieldName="nv_TagName_vn"
                                                    Name="nv_TagName_vn">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image">
                                                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                                        <Image AlternateText="Xóa" Url="~/images/btn_Delete.png">
                                                        </Image>
                                                    </DeleteButton>
                                                </dx:GridViewCommandColumn>
                                            </Columns>
                                            <SettingsEditing Mode="Inline" />
                                            <SettingsPager PageSize="3">
                                            </SettingsPager>
                                            <Settings ShowGroupPanel="true" ShowColumnHeaders="true" />
                                            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                            <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged"/>
                                            <Styles>
                                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                </AlternatingRow>
                                            </Styles>
                                        </dx:ASPxGridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="info_table_td">
                            <dx:ASPxButton ID="btnOkCV" OnClick="btnOkCV_Click" Image-Url="~/images/btn_Save.png" ClientInstanceName="btOkCV" runat="server" Text="Lưu)" Style="float: left; margin-right: 8px">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnLammoiCV" runat="server" AutoPostBack="false" Image-Url="~/images/16x16/refresh.png" Text="Làm mới (F9)" Style="float: left; margin-right: 8px">
                                <ClientSideEvents Click="ClearTextWork_Pop" />
                            </dx:ASPxButton>
                        </td>
                        <td class="info_table_td"></td>
                    </tr>
                </table>
            </fieldset>
            <dx:ASPxGridView ID="dgvCongviec" runat="server" ClientInstanceName="client_dgvCongviec" OnRowDeleting="dgvCongviec_RowDeleting"
                AutoGenerateColumns="false" KeyFieldName="uId_Congviec" SettingsPager-PageSize="8"
                SettingsPager-Position="Bottom">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Congviec"
                        Name="uId_Congviec">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        Width="120px" HeaderStyle-HorizontalAlign="Center" Caption="Ngày làm" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy hh:mm}" FieldName="d_Ngay"
                        Name="d_Ngay">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Nhân viên làm" FieldName="nv_Hoten_vn"
                        Name="nv_Hoten_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Nối/Mở Rộng DV/SP" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                             <%# SplitTags_DV(Eval("Tags").ToString) %>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Nguồn biết đến" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <%# SplitTags(Eval("Tags").ToString) %>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Ghi chú" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" FieldName="nv_Noidung" Name="nv_Noidung">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image">
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
                    </dx:GridViewCommandColumn>
                </Columns>
                <SettingsDetail ShowDetailRow="false" />
                <SettingsEditing Mode="Inline" />
                <SettingsPager PageSize="15">
                </SettingsPager>
                <Settings ShowGroupPanel="true" ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                    </AlternatingRow>
                </Styles>
            </dx:ASPxGridView>
            <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="upCongviec" DisplayAfter="0" DynamicLayout="false">
                <ProgressTemplate>
                    <img alt="In progress..." src="../../images/progress.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
