<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Room.aspx.vb" Inherits="NANO_SPA.Room" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'1f61506a-ea78-42dc-938c-0fcfe3619c43'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH MỤC PHÒNG</p>
    </div>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_Room" runat="server" KeyFieldName="uId_Phong" Width="100%" OnCellEditorInitialize="Grid_Room_CellEditorInitialize"
            OnRowDeleting="Grid_Room_RowDeleting" OnRowInserting="Grid_Room_RowInserting" OnRowUpdating="Grid_Room_RowUpdating">
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="" FieldName="uId_Phong" Name="uId_Phong">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Tên phòng" VisibleIndex="1" FieldName="nv_Tenphong_vn" Width="200px"
                    Name="nv_Tenphong_vn" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                </dx:GridViewDataColumn>

                <dx:GridViewDataComboBoxColumn Caption="Tên cửa hàng" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Tencuahang_vn"
                    Visible="true" VisibleIndex="2" Name="nv_Tencuahang_vn" Width="300px"
                    PropertiesComboBox-IncrementalFilteringMode="StartsWith" PropertiesComboBox-DropDownStyle="DropDown">
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Thứ tự phòng" FieldName="i_Thutu" Width="">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Số khách tối đa" FieldName="i_Sokhachtoida" Width="">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="4" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Số điện thoại" FieldName="v_Dienthoai" Width="">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="4" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Màu nền" FieldName="v_Maunen" Width="">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Visible="true" VisibleIndex="4" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="Màu chữ" FieldName="v_Mauchu" Width="">
                </dx:GridViewDataColumn>

                <dx:GridViewCommandColumn Width="100px" VisibleIndex="5" Caption="Thêm" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
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
                <dx:GridViewCommandColumn VisibleIndex="5" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
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
