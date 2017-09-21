<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DMThuchi.aspx.vb" Inherits="NANO_SPA.DMThuchi" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             var param_dt = "{'uId_Chucnang':'b77cdcc0-d4df-4910-afad-0ae93911e9de'}";
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
         //Comment
         var _fieldName = '';
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH MỤC THU CHI</p>
    </div>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_DMThuchi" runat="server" KeyFieldName="uId_Thuchi" Width="100%" OnCellEditorInitialize="Grid_DMThuchi_CellEditorInitialize"
            OnRowDeleting="Grid_DMThuchi_RowDeleting" OnRowInserting="Grid_DMThuchi_RowInserting" OnRowUpdating="Grid_DMThuchi_RowUpdating">
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="" FieldName="uId_Thuchi" Name="uId_Thuchi">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Mã thu chi" VisibleIndex="1" FieldName="v_Mathuchi" Width="200px"
                    Name="v_Mathuchi" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Tên thu chi" FieldName="nv_Tenthuchi_vn" Width="60%">
                </dx:GridViewDataColumn>

                <dx:GridViewDataComboBoxColumn Caption="Loại" HeaderStyle-HorizontalAlign="Center" FieldName="b_Thuchi"
                    Visible="true" VisibleIndex="3" Name="b_Thuchi" Width="150px" CellStyle-HorizontalAlign="Center" PropertiesComboBox-ValueType="System.String"
                    PropertiesComboBox-IncrementalFilteringMode="StartsWith" PropertiesComboBox-DropDownStyle="DropDown">
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewCommandColumn Width="100px" VisibleIndex="3" Caption="Thêm" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                    <CancelButton>
                        <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                    </CancelButton>
                    <UpdateButton>
                        <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                    </UpdateButton>
                    <EditButton Visible="true" Image-Url="../../images/btn_Edit.png" Image-AlternateText="Sửa">
                    </EditButton>
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
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents EndCallback="grid_EndCallback" FocusedRowChanged="grid_FocusedRowChanged" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
</asp:Content>
