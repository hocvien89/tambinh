<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="Security.aspx.vb" Inherits="NANO_SPA.Security" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
	 $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'b13e5a3d-8918-4ff4-859c-7db7d361bb5f'}";
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
        function grid_EndCallback(s, e) {

            if (s.cpShowError) {
                lberror.SetText(s.cpText);
            }
        }
        function ShowEditWindow() {
            document.getElementById("<%=lbl_thongbao.ClientID%>").innerHTML = "";
            pcAddNhanvien.Show();
            Grid_client.UnselectRows();
            Client_Chucnang_Nhanvien.Refresh();
        }
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                //Grid_nhanvien.GetRowValues(e.visibleIndex, 'uId_Nhanvien;', Getnhanvien);
                Grid_nhanvien.GetRowValues(e.visibleIndex, 'uId_Nhanvien;', setvalue);
                var hdfuIdmh = document.getElementById("<%=hdfuIdNhanvien.ClientID%>");
            }
        }
        function setvalue(values) {
            var hdfuIdmh = document.getElementById("<%=hdfuIdNhanvien.ClientID%>");
            hdfuIdmh.value = values[0];
            Client_Chucnang_Nhanvien.Refresh();
            var param_dt = "{'uId_Nhanvien':'" + values[0] + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadNhanvien";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCall,
                error: onFail
            });
            //Create  1 session uId_Dichvu_cd
            //jo_CreateSession("uId_Dichvu_cd", values[0]);
            //clientgrid_congdoan.Refresh();
        }
        function OnSuccessCall(msg) {
            if (msg.d != "") {
                Grid_client.Refresh();
                var defaultdata = msg.d.split("$");
                var lbl_Hoten = document.getElementById('<%=lbl_HotenNV.ClientID%>');
                    lbl_Hoten.innerHTML = ""
                    lbl_Hoten.innerHTML = " " + defaultdata[3] + " - " + defaultdata[2] + " ";
                }
            }
            function ClosePopup(s, e) {
                Grid_client.CollapseAll();
                pcAddNhanvien.Hide();
            }
            function grid_SelectionChanged(s, e) {
                document.getElementById("<%=lbl_thongbao.ClientID%>").innerHTML = "";
            if (!e.isSelected) {
                s.GetRowValues(e.visibleIndex, "uId_Chucnang;", GetSelectedDeletePhanquyen);
            } else
                s.GetRowValues(e.visibleIndex, "uId_Chucnang;", GetSelectedInsertPhanquyen);
        }
        function GetSelectedInsertPhanquyen(values) {
            var hdfuIdNv = document.getElementById("<%=hdfuIdNhanvien.ClientID%>").value;
            var param_dt = "{'uid_chucnang':'" + values[0] + "','uid_nhanvien':'" + hdfuIdNv + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/InertPhanquyen";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCallInsert,
                error: onFail
            });
            //Create  1 session uId_Dichvu_cd
            //jo_CreateSession("uId_Dichvu_cd", values[0]);
            //clientgrid_congdoan.Refresh();
        }
        function OnSuccessCallInsert(msg) {
            if (msg != "") {
                Client_Chucnang_Nhanvien.Refresh();
                Grid_client.Refresh();
                document.getElementById("<%=lbl_thongbao.ClientID%>").innerHTML = msg.d;
            }
        }

        function GetSelectedDeletePhanquyen(values) {
            var hdfuIdNv = document.getElementById("<%=hdfuIdNhanvien.ClientID%>").value;
            var param_dt = "{'uid_chucnang':'" + values[0] + "','uid_nhanvien':'" + hdfuIdNv + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/DeletePhanquyen";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCallDelete,
                error: onFail
            });
            //Create  1 session uId_Dichvu_cd
            //jo_CreateSession("uId_Dichvu_cd", values[0]);
            //clientgrid_congdoan.Refresh();
        }
        function OnSuccessCallDelete(msg) {
            if (msg != "") {
                Client_Chucnang_Nhanvien.Refresh();
                Grid_client.Refresh();
                document.getElementById("<%=lbl_thongbao.ClientID%>").innerHTML = msg.d;
            }
        }
        //them xoa tat ca chuc nang
        function Insert_All() {
            var hdfuIdNv = document.getElementById("<%=hdfuIdNhanvien.ClientID%>").value;
            var param_dt = "{'uid_nhanvien':'" + hdfuIdNv + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/InsertAllPhanquyen";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCallInsertAll,
                error: onFail
            });
        }
        function OnSuccessCallInsertAll(msg) {
            if (msg != "") {
                Grid_client.Refresh();
                Client_Chucnang_Nhanvien.Refresh();
                document.getElementById("<%=lbl_thongbao.ClientID%>").innerHTML = msg.d;
            }
        }
        function Delete_All() {
            var hdfuIdNv = document.getElementById("<%=hdfuIdNhanvien.ClientID%>").value;
            var param_dt = "{'uid_nhanvien':'" + hdfuIdNv + "'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/DeleteAllPhanquyen";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccessCallDeletetAll,
                error: onFail
            });
        }
        function OnSuccessCallDeletetAll(msg) {
            if (msg != "") {
                Grid_client.Refresh();
                Client_Chucnang_Nhanvien.Refresh();
                document.getElementById("<%=lbl_thongbao.ClientID%>").innerHTML = msg.d;
            }
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>PHÂN QUYỀN HỆ THỐNG</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Thông tin nhân viên</span></legend>
        <dx:ASPxGridView ID="Grid_Nhanvien" KeyFieldName="uId_Nhanvien" ClientInstanceName="Grid_nhanvien" AutoGenerateColumns="false" runat="server"
            SettingsPager-PageSize="17">
            <Columns>
                <dx:GridViewDataColumn FieldName="uId_Nhanvien" Visible="false" VisibleIndex="-1" Name="uId_Nhanvien">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Mã nhân viên" HeaderStyle-HorizontalAlign="Center" FieldName="v_Manhanvien" VisibleIndex="1"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="v_Manhanvien" Width="100px">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Tên Nhân viên" HeaderStyle-HorizontalAlign="Center" FieldName="nv_Hoten_vn" VisibleIndex="2"
                    Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Hoten_vn" Width="200px">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Ngày sinh" Visible="true" VisibleIndex="3" FieldName="d_Ngaysinh"
                    Settings-AutoFilterCondition="Contains" Width="100px" Name="d_Ngaysinh" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Chức vụ" Visible="true" VisibleIndex="4" FieldName="nv_Chucvu_vn"
                    Settings-AutoFilterCondition="Contains" Width="100px" Name="nv_Chucvu_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Địa chỉ" Visible="true" VisibleIndex="4" FieldName="nv_Diachi_vn"
                    Settings-AutoFilterCondition="Contains" Width="300px" Name="nv_Diachi_vn" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Số điện thoại" Visible="true" VisibleIndex="4" FieldName="v_Dienthoai"
                    Settings-AutoFilterCondition="Contains" Width="100px" Name="v_Dienthoai" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Địa chỉ Email" Visible="true" VisibleIndex="4" FieldName="v_Email"
                    Settings-AutoFilterCondition="Contains" Width="150px" Name="v_Email" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="Ngày vào làm" Visible="true" VisibleIndex="4" FieldName="d_Ngayvaolam"
                    Settings-AutoFilterCondition="Contains" Width="100px" Name="d_Ngayvaolam" HeaderStyle-HorizontalAlign="Center">
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Width="50px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Caption="Sửa" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <a id="popup" title="Thông tin Nhân viên" href='javascript:void(0)' onclick="return ShowEditWindow()">
                            <img src="../../../images/btn_Edit.png" /></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPopup>
                <EditForm Width="700px" />
            </SettingsPopup>
            <SettingsEditing Mode="Inline" />
            <SettingsPager PageSize="15" Summary-Text="Trang {0}/{1} ({2} Nhân viên)">
            </SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
            <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
    <asp:HiddenField ID="hdfuIdNhanvien" Value="" runat="server" />
    <asp:HiddenField ID="hdfuIdChucnang" Value="" runat="server" />
    <dx:ASPxPopupControl ID="pcAddNhanvien" runat="server" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAddNhanvien" Font-Size="25px"
        HeaderText="Phân quyền hệ thống" AllowDragging="True" PopupAnimationType="None">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); pcAddNhanvien.Focus(); }" CloseButtonClick="ClosePopup" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="1100px" Height="500px" Font-Size="12px">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server" Width="400px">
                            <asp:UpdatePanel ID="upNhanvien" runat="server">
                                <ContentTemplate>
                                    <fieldset class="field_tt" style="width: 1068px; height: auto; margin: auto">
                                        <legend><span style="font-weight: bold; color: green; font-size: 18px">
                                            <asp:Label ID="lbl_HotenNV" runat="server"></asp:Label>
                                        </span></legend>
                                        <div class="thongtin" style="width: 1068px; height: auto">
                                            <fieldset class="field_tt" style="width: 1050px; height: auto; margin: auto">
                                                <legend><span class="mathang" style="font-weight: bold; color: green; font-size: 16px">Quyền hạn</span></legend>
                                                <div style="float: left; width: 44%">
                                                    <dx:ASPxGridView ID="Grid_Chucnang" runat="server" KeyFieldName="uId_Chucnang" AutoGenerateColumns="false" Width="100%"
                                                        ClientInstanceName="Grid_client" SettingsText-GroupContinuedOnNextPage="(=>Trang sau)"
                                                        OnHtmlRowPrepared="Grid_Chucnang_HtmlRowPrepared">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="uId_Chucnang" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataCheckColumn FieldName="Check_Active" Caption="Kích hoạt" VisibleIndex="-1" Visible="false" CellStyle-HorizontalAlign="Center"
                                                                HeaderStyle-HorizontalAlign="Center" Width="20px">
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center">
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn FieldName="nv_Tenchucnang_vn" Caption="Chức năng" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Nhóm chức năng" FieldName="nv_Tenphanhe_vn" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsEditing Mode="Inline" />
                                                        <SettingsPager PageSize="10" NumericButtonCount="4" Summary-Text="Trang {0}/{1} ({2} Chức năng)"></SettingsPager>
                                                        <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" />
                                                        <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
                                                        <Styles>
                                                            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                            </AlternatingRow>
                                                            <GroupRow Font-Bold="true">
                                                            </GroupRow>
                                                        </Styles>
                                                        <ClientSideEvents EndCallback="grid_EndCallback" />
                                                    </dx:ASPxGridView>
                                                </div>

                                                <div style="float: right; width:53%">
                                                    <dx:ASPxGridView ID="Grid_Chucnang_Nhanvien" runat="server" KeyFieldName="uId_Chucnang" AutoGenerateColumns="false" Width="100%"
                                                        ClientInstanceName="Client_Chucnang_Nhanvien" CssClass="floatright">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="uId_Chucnang" Visible="false" VisibleIndex="-1"></dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="nv_Tenphanhe_vn" Caption="Nhóm chức năng" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Chức năng" FieldName="nv_Tenchucnang_vn" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsPager PageSize="10" NumericButtonCount="5" Summary-Text="Trang {0}/{1} ({2} Chức năng)"></SettingsPager>
                                                        <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />

                                                        <Styles>
                                                            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                                            </AlternatingRow>
                                                            <GroupRow Font-Bold="true"></GroupRow>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                </div>
                                            </fieldset>
                                    </fieldset>
                                    <div style="height: 10px; width: 100px"></div>
                                    </div>
                                        <div style="height: 20px; color: green; font-family: Arial; font: italic">
                                            <asp:Label ID="lbl_thongbao" Text="" runat="server"></asp:Label>
                                        </div>
                                    <div style="height: 10px; width: 100px"></div>
                                    <div style="height: 40px">
                                        <asp:Label ID="lbl_Import" runat="server" CssClass="error" Font-Size="16px" Text=""></asp:Label>
                                        <dx:ASPxButton ID="btn_Checkall" Image-Url="~/images/16x16/add.png" runat="server" Text="Thêm tất cả" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                            <ClientSideEvents Click="Insert_All" />
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btn_Uncheckall" Image-Url="~/images/btn_Delete.png" runat="server" Text="Xóa tất cả" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                            <ClientSideEvents Click="Delete_All" />
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btn_close" Image-Url="~/images/16x16/exit.png" runat="server" Text="Thoát" AutoPostBack="false" Style="float: left; margin-right: 8px">
                                            <ClientSideEvents Click="ClosePopup" />
                                        </dx:ASPxButton>
                                    </div>
                                    </fieldset>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
