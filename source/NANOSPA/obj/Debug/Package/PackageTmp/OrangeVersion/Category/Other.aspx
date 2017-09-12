<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Other.aspx.vb" Inherits="NANO_SPA.Other" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        //Comment
        var _fieldName = '';
        function grid_RowDblClick(s, e) {
            var srcElement = e.htmlEvent.srcElement ? e.htmlEvent.srcElement : e.htmlEvent.target;
            _fieldName = srcElement.getAttribute('FieldName');
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ DANH MỤC KHÁC</p>
    </div>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_Other" runat="server" KeyFieldName="uId_Nguon" Width="100%" OnRowDeleting="Grid_Other_RowDeleting" OnRowInserting="Grid_Other_RowInserting"
            OnRowUpdating="Grid_Other_RowUpdating" OnCellEditorInitialize="Grid_Other_CellEditorInitialize">
            <Columns>
                <dx:GridViewDataColumn VisibleIndex="1" FieldName="uId_Nguon" Visible="false"
                    Name="uId_Nguon" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" Width="15%">
                </dx:GridViewDataColumn>
                <dx:GridViewDataComboBoxColumn Caption="Loại danh mục" VisibleIndex="1" FieldName="vType" Visible="true"
                    Name="v_Type" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" Width="15%">
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                    Caption="Tên danh mục" FieldName="nv_Nguon_vn" Width="35%">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Visible="false" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                     FieldName="nv_Nguon_en">
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
        <SettingsPager PageSize="15" Summary-Text="Trang {0}/{1} Tổng {2} Danh mục">
        </SettingsPager>
        <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
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
