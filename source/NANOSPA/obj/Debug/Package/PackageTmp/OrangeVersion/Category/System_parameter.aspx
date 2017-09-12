<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="System_parameter.aspx.vb" Inherits="NANO_SPA.System_parameter" %>

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
            var param_dt = "{'uId_Chucnang':'cc8cb816-6b5a-4793-803f-b12657889bfe'}";
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
            pcAddNhanvien.Show();
            Grid_client.UnselectRows();
            Client_Chucnang_Nhanvien.Refresh();
        }
        function SelChanged(s, e) {
            if (!e.isSelected) {
            } else {
                //Grid_nhanvien.GetRowValues(e.visibleIndex, 'uId_Nhanvien;', Getnhanvien);
                //Grid_nhanvien.GetRowValues(e.visibleIndex, 'uId_Nhanvien;', setvalue);
            }
        }
        function DeleteImage() {
            document.getElementById('<%=img_Logo.ClientID%>').src = "";
            $("#<%=hdfLogo.ClientID%>").value = "";
        }
        function Upload() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                document.getElementById('<%=img_Logo.ClientID%>').src = fileUrl;
                document.getElementById('<%=hdfLogo.ClientID%>').value = fileUrl;;
            };
            finder.popup();
        }
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>CẤU HÌNH HỆ THỐNG</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Danh sách tham số</span></legend>
        <dx:ASPxPageControl ID="pageControl" runat="server" Width="100%" EnableCallBacks="true">
            <TabPages>
                <dx:TabPage Text="Cấu hình chung" Visible="true">
                    <ContentCollection>
                        <dx:ContentControl ID="ContentControl1" runat="server">
                            <div style="padding: 3px 3px  3px">
                                <fieldset class="field" style="width: 98%; height: auto; margin: auto">
                                    <legend><span style="font-weight: bold; color: green;">Logo</span>
                                    </legend>
                                    <asp:Image ID="img_Logo" Width="100px" Height="100px" runat="server"></asp:Image>
                                    <asp:HyperLink ID="asplink" runat="server" Text="Đổi ảnh" onclick="javascript: Upload()">
                                    </asp:HyperLink> |
                                    <asp:HyperLink ID="asplink_xoaanh" runat="server" Text="Xóa ảnh" onclick="javascript: DeleteImage()">
                                    </asp:HyperLink>
                                    <asp:HiddenField ID="hdfLogo" runat="server" />
                                    <dx:ASPxButton ID="bnLuuLogo" OnClick="bnLuuLogo_Click" Style="margin-top:5px;"  ClientInstanceName="btnDSNo" AutoPostBack="true" runat="server" Text="Lưu Logo">
                                        
                                    </dx:ASPxButton>
                                    <span class="error">(*) Lưu ý: ảnh này sẽ được in trên các phiếu thanh toán</span>
                                </fieldset>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Tham số" Visible="true">
                    <ContentCollection>
                        <dx:ContentControl ID="ContentControl4" runat="server">
                            <div style="padding: 3px 3px  3px">
                                <dx:ASPxGridView ID="Grid_ThamsoHethong" KeyFieldName="uId_Thamsohethong" ClientInstanceName="Grid_thamsohethong" AutoGenerateColumns="false" runat="server"
                                    SettingsPager-PageSize="17" OnRowDeleting="Grid_ThamsoHethong_RowDeleting" OnRowInserting="Grid_ThamsoHethong_RowInserting"
                                    OnRowUpdating="Grid_ThamsoHethong_RowUpdating">
                                    <Columns>
                                        <dx:GridViewDataColumn FieldName="uId_Thamsohethong" Visible="false" VisibleIndex="-1" Name="uId_thamsohethong">
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Tên biến" HeaderStyle-HorizontalAlign="Center" FieldName="v_Tenbien" VisibleIndex="1"
                                            Settings-AutoFilterCondition="Contains" Visible="true" Name="v_Tenbien" Width="15%">
                                        </dx:GridViewDataColumn>

                                        <dx:GridViewDataColumn Caption="Mô tả " HeaderStyle-HorizontalAlign="Center" FieldName="nv_Mota_vn" VisibleIndex="2"
                                            Settings-AutoFilterCondition="Contains" Visible="true" Name="nv_Hoten_vn" Width="30%">
                                        </dx:GridViewDataColumn>

                                        <dx:GridViewDataColumn Caption="Giá trị" Visible="true" VisibleIndex="3" FieldName="v_Giatri"
                                            Settings-AutoFilterCondition="Contains" Width="15%" Name="v_Giatri" HeaderStyle-HorizontalAlign="Center">
                                        </dx:GridViewDataColumn>

                                        <dx:GridViewDataColumn Caption="Số thứ tự" Visible="true" VisibleIndex="0" FieldName="i_STT"
                                            Settings-AutoFilterCondition="Contains" Width="10%" Name="i_STT" HeaderStyle-HorizontalAlign="Center"
                                            CellStyle-HorizontalAlign="Center" SortOrder="Ascending">
                                        </dx:GridViewDataColumn>

                                        <dx:GridViewDataColumn Caption="Trạng thái" Visible="true" VisibleIndex="4" FieldName="b_Hoatdong"
                                            Settings-AutoFilterCondition="Contains" Width="10%" Name="b_Hoatdong" HeaderStyle-HorizontalAlign="Center">
                                        </dx:GridViewDataColumn>

                                        <dx:GridViewCommandColumn Width="50px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Caption="Sửa"
                                            CellStyle-HorizontalAlign="Center" ButtonType="Image">
                                            <NewButton Image-Url="../../images/btn_add.png" Visible="true">
                                                <Image Url="../../images/btn_add.png" ToolTip="Thêm mới tham số hệ thống"></Image>
                                            </NewButton>
                                            <EditButton Image-Url="../../images/btn_Edit.png" Visible="true">
                                                <Image Url="../../images/btn_Edit.png" ToolTip="Sửa thông tin"></Image>
                                            </EditButton>
                                            <CancelButton Image-Url="../../images/16x16/back.png" Image-ToolTip="Quay lại"></CancelButton>
                                            <UpdateButton Image-Url="../../images/btn_Save.png" Image-ToolTip="Cập nhật"></UpdateButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewCommandColumn Width="50px" Visible="true" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Caption="Xóa" ButtonType="Image">
                                            <DeleteButton Visible="true">
                                                <Image Url="../../images/btn_Delete.png"></Image>
                                            </DeleteButton>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <SettingsPopup>
                                        <EditForm Width="700px" />
                                    </SettingsPopup>
                                    <SettingsEditing Mode="Inline" />
                                    <SettingsPager PageSize="14" Summary-Text="Trang {0}/{1} ({2} Tham số)">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
                                    <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                    <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                                    <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                    <Styles>
                                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                        </AlternatingRow>
                                        <CommandColumnItem Paddings-PaddingLeft="13px"></CommandColumnItem>
                                    </Styles>
                                </dx:ASPxGridView>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </fieldset>
</asp:Content>
