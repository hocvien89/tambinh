<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Supplier.aspx.vb" Inherits="NANO_SPA.Supplier" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'572813c0-92de-44ac-b82a-1ac38d37d823'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH MỤC NHÀ CUNG CẤP</p>
    </div>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_Supplier" runat="server" KeyFieldName="uId_Nhacungcap" Width="100%" OnRowDeleting="Grid_Supplier_RowDeleting"
            OnRowInserting="Grid_Supplier_RowInserting" OnRowUpdating="Grid_Supplier_RowUpdating">
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="" FieldName="uId_Nhacungcap" Name="uId_Nhacungcap">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Mã nhà cung cấp" VisibleIndex="1" FieldName="v_Manhacungcap" Width="200px"
                    Name="v_Manhacungcap" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Tên nhà cung cấp" FieldName="nv_Tennhacungcap_vn" Width="">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Địa chỉ" FieldName="nv_Diachi_vn" Width="">
                </dx:GridViewDataColumn>

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
