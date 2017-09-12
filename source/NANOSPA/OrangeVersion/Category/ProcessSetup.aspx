<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ProcessSetup.aspx.vb" Inherits="NANO_SPA.ProcessSetup" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function phongchange(s, e) {
            chk_all.SetChecked(false)
            grv_quytrinh.Refresh();
        }
        var lastCountry = null;
        function OnCountryChanged(cbo_quytrinh) {
            chk_all.SetChecked(false)
            if (cbo_buoc.InCallback())
                lastCountry = cbo_quytrinh.GetValue().toString();
            else
                cbo_buoc.PerformCallback(cbo_quytrinh.GetValue().toString());
            grv_quytrinh.Refresh();
        }

        function buocchange(s, e) {
            chk_all.SetChecked(false)
            grv_quytrinh.Refresh();
        }

        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                grv_quytrinh.GetRowValues(e.visibleIndex, 'Code;uId_Phongban;uId_Step', OnGridSelectionComplete);
            }
        }

        function OnGridSelectionComplete(values) {
            cbo_phongban.SetValue(values[1]);
            cbo_quytrinh.SetValue(values[0]);
            OnCountryChanged(cbo_quytrinh);
            cbo_buoc.SetValue(values[2]);
        }

        //function grid_FocusedRowChanged(s, e) {
        //    if (s.cpIsEditing) {
        //        s.UpdateEdit();
        //    }
        //}
        function chkallChange(s, e) {
            grv_quytrinh.Refresh();
        }

        function btnsave_click(s, e) {
            var param_dt = "{'uId_Phongban':'"+cbo_phongban.GetSelectedItem().value+"','uId_Step':'"+cbo_buoc.GetSelectedItem().value+"'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/RootdetailInsert";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d != "") {
                        alert("Thêm quy trình thành công");
                        grv_quytrinh.Refresh();
                    }
                    else {
                        alert("Quy trình này đã được thêm");
                    }
                },
                error: onFail
            });
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THIẾT LẬP QUY TRÌNH</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green"></span></legend>
        <div style="width: 34%; margin: auto">
            <table class="info_table">
                <tr>
                    <td class="info_table_td">Quy trình: </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="cbo_Quytrinh" runat="server" ClientInstanceName="cbo_quytrinh" AutoPostBack="false" Width="250px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCountryChanged(s); }" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Phòng ban: </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="cbo_Phongban" runat="server" ClientInstanceName="cbo_phongban" Width="250px" EnableViewState="false">
                            <ClientSideEvents SelectedIndexChanged="phongchange" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>

                <tr>
                    <td class="info_table_td">Bước thực hiện: </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="cbo_Buoc" runat="server" ClientInstanceName="cbo_buoc" AutoPostBack="false" Width="250px"
                            OnCallback="cbo_Buoc_Callback">
                            <ClientSideEvents SelectedIndexChanged="buocchange" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <ul>
                            <li class="text_title">
                                <dx:ASPxButton ID="btn_New" runat="server" Text="Làm mới" ClientInstanceName="btn_new" Image-Url="~/images/16x16/refresh.png" AutoPostBack="false">
                                    <ClientSideEvents Click="btnnew_click" />
                                </dx:ASPxButton>
                            </li>
                            <li class="text_title">
                                <dx:ASPxButton ID="btn_Save" runat="server" Text="Lưu" ClientInstanceName="btn_save" Image-Url="~/images/16x16/save.png" AutoPostBack="false">
                                    <ClientSideEvents Click="btnsave_click" />
                                </dx:ASPxButton>
                            </li>
                            <%--                            <li class="text_title">
                                <dx:ASPxButton ID="btn_Search" runat="server" Text="Tìm" ClientInstanceName="btn_save" AutoPostBack="false">
                                    <ClientSideEvents Click="btnsave_Search" />
                                </dx:ASPxButton>
                            </li>--%>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <fieldset>
        <legend><span style="font-weight: bold; color: green"></span>
            <dx:ASPxCheckBox ID="chk_All" ClientInstanceName="chk_all" runat="server" Text="Tất cả">
                <ClientSideEvents CheckedChanged="chkallChange" />
            </dx:ASPxCheckBox>
        </legend>
        <dx:ASPxGridView ID="Grv_Quytrinh" runat="server" ClientInstanceName="grv_quytrinh" AutoGenerateColumns="false"
            KeyFieldName="ID" SettingsPager-PageSize="8" Width="100%" OnRowDeleting="Grv_Quytrinh_RowDeleting" >
            <Columns>
                <dx:GridViewDataTextColumn VisibleIndex="-1" Visible="false" FieldName="Code" />
                <dx:GridViewDataTextColumn VisibleIndex="-1" Visible="false" FieldName="uId_Phongban" />
                <dx:GridViewDataTextColumn VisibleIndex="-1" Visible="false" FieldName="uId_Step" />
                <dx:GridViewDataTextColumn Caption="Tên quy trình" FieldName="Process_Name" HeaderStyle-HorizontalAlign="Center"
                    CellStyle-HorizontalAlign="Left" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Phòng thực hiện" FieldName="nv_Tenphong_vn" HeaderStyle-HorizontalAlign="Center"
                    CellStyle-HorizontalAlign="Left" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Bước" FieldName="StepNumb" HeaderStyle-HorizontalAlign="Center"
                    CellStyle-HorizontalAlign="Left" VisibleIndex="4" Width="50px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Tên bước" FieldName="StepName" HeaderStyle-HorizontalAlign="Center"
                    CellStyle-HorizontalAlign="Left" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="4" Width="50px">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image AlternateText="Xóa" Url="~/images/btn_Delete.png">
                        </Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <%--            <ClientSideEvents SelectionChanged="function(s, e) { SelChanged(s, e); }" />--%>
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
</asp:Content>
