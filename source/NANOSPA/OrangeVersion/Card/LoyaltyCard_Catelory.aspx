<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="LoyaltyCard_Catelory.aspx.vb" Inherits="NANO_SPA.LoyaltyCard_Catelory" %>

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
    <script type="text/javascript">
		 $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'6dd1865e-1416-4632-a5c0-7716a0e89d26'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH MỤC THẺ THÀNH VIÊN</p>
    </div>
    <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_LoyaltyCard" runat="server" Width="100%" KeyFieldName="uId_Thetichdiem"
            OnRowInserting="Grid_LoyaltyCard_RowInserting" OnRowUpdating="Grid_LoyaltyCard_RowUpdating"
            OnRowDeleting="Grid_LoyaltyCard_RowDeleting">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="uId_Thetichdiem" Visible="false" VisibleIndex="-1">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="nv_Tenthetichdiem" Visible="true" VisibleIndex="2"
                    HeaderStyle-HorizontalAlign="Center" Caption="Tên loại thẻ" Name="uId_Tenthetichdiem" />
                <dx:GridViewDataColumn FieldName="v_Mathetichdiem" Visible="true" VisibleIndex="1"
                    HeaderStyle-HorizontalAlign="Center" Caption="Mã loại thẻ" Name="v_Mathetichdiem" >
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="f_Diemkichhoat" Visible="true" VisibleIndex="3" PropertiesTextEdit-DisplayFormatString="n0"
                    HeaderStyle-HorizontalAlign="Center" Caption="Tiền kích hoạt" Name="f_Diemkichhoat"  PropertiesTextEdit-DisplayFormatInEditMode="true"/>
                <dx:GridViewDataTextColumn FieldName="f_Sotiendoi" Visible="false" VisibleIndex="3" PropertiesTextEdit-DisplayFormatString="n0"
                    HeaderStyle-HorizontalAlign="Center" Caption="Tiền quy đổi" Name="f_Sotiendoi"  PropertiesTextEdit-DisplayFormatInEditMode="true"/>
                <dx:GridViewDataTextColumn FieldName="i_Sodiemdoi" Visible="false" VisibleIndex="3" PropertiesTextEdit-DisplayFormatString="n0"
                    HeaderStyle-HorizontalAlign="Center" Caption="Điểm Quy đổi" Name="i_Sodiemdoi"  PropertiesTextEdit-DisplayFormatInEditMode="true"/>
                <dx:GridViewDataTextColumn FieldName="f_Uutien" Visible="true" VisibleIndex="3" PropertiesTextEdit-DisplayFormatString="n0"
                    HeaderStyle-HorizontalAlign="Center" Caption="Mức ưu tiên" Name="f_Uutien"  PropertiesTextEdit-DisplayFormatInEditMode="true"/>
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
