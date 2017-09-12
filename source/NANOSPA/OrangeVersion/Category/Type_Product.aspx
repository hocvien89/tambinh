<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Type_Product.aspx.vb" Inherits="NANO_SPA.Type_Product" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             var param_dt = "{'uId_Chucnang':'4db08cf6-e5cc-4a1f-894c-7b3cdce22a21'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>QUẢN LÍ DANH MỤC LOẠI THUỐC</p>
    </div>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_TypeProduct" runat="server" KeyFieldName="uId_Loaimathang" Width="100%">
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                    Width="100px" Caption="" FieldName="uId_Loaimathang" Name="uId_Loaimathang">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Mã loại thuốc" VisibleIndex="1" FieldName="nv_Tenloaimathang_en"
                    Name="nv_Tenloaimathang_en" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" 
                    Caption="Tên loại thuốc" FieldName="nv_Tenloaimathang_vn" Width="60%">
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
