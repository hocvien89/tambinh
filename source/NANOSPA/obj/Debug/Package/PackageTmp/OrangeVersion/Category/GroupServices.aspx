<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="GroupServices.aspx.vb" Inherits="NANO_SPA.GroupServices" %>

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
    <script src="../../bootstrap/js/MaskedEditFix.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'440c8557-58f8-4d20-9843-79ce795be8a5'}";
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
    </script>
    <div class="brest_crum">
        <asp:Table ID="tbtop" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell Width="30%">       <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ NHÓM DỊCH VỤ</p></asp:TableCell>
                <asp:TableCell Width="5%">Cửa hàng :</asp:TableCell>
                <asp:TableCell Width="30%">
                    <dx:ASPxComboBox ID="cmbCuahang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbCuahang_SelectedIndexChanged1"
                        IncrementalFilteringMode="StartsWith" TextField="nv_Tencuahang_vn" ValueField="uId_cuahang"
                        Width="400px" DropDownStyle="DropDown">
                    </dx:ASPxComboBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </div>
   <fieldset class="field_tt_right>" style="width: 98%; margin: auto; height: auto">
        <legend><span style="font-weight: bold; color: green;"></span></legend>
    <dx:ASPxGridView ID="dgvDev" KeyFieldName="uId_Nhomdichvu" runat="server" ClientInstanceName="client_grid" AutoGenerateColumns="true" Width="100%" OnRowUpdating="dgvDev_RowUpdating"
        OnRowDeleting="dgvDev_RowDeleting" OnCellEditorInitialize="dgvDev_CellEditorInitialize">
        <Columns>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center"
                Width="100px" Caption="" FieldName="uId_Nhomdichvu" Name="uId_Nhomdichvu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Mã nhóm"  VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                FieldName="vType" PropertiesComboBox-ClientInstanceName="vType">
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                HeaderStyle-HorizontalAlign="Center"
                Caption="Tên nhóm dịch vụ" FieldName="nv_TennhomDichvu_vn" Width="60%">
            </dx:GridViewDataColumn>
            <dx:GridViewCommandColumn Width="5%" VisibleIndex="3" Caption="Thêm" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                <CancelButton>
                    <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                </CancelButton>
                <UpdateButton>
                    <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                </UpdateButton>
                <NewButton Visible="true" Image-Url="../../images/btn_add.png" Image-AlternateText="Thêm">
                    <Image AlternateText="New" Url="../../images/btn_add.png"></Image>
                </NewButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewCommandColumn VisibleIndex="4" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                    <Image Url="~/images/btn_Delete.png"></Image>
                </DeleteButton>
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowFilterRow="true" ShowFilterRowMenu="true"/>
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="grid_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
       </fieldset>
</asp:Content>
