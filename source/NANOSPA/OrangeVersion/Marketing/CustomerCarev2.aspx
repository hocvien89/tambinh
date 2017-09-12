<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="CustomerCarev2.aspx.vb" Inherits="NANO_SPA.CustomerCasev2" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
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

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>CHĂM SÓC KHÁCH HÀNG</p>
    </div>
    <fieldset class="field_tt" style="width: 98%; width:auto">
        <dx:ASPxPageControl ID="pcChamsockhachhang" runat="server" Width="99%">
            <TabPages>
                <dx:TabPage Text="Danh sách chăm sóc">
                    <ContentCollection>
                        <dx:ContentControl runat="server">

                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Khách hàng tiềm năng">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <div class="form-group" style="float: left;width: 30%">
                                <fieldset class="field_tt">
                                    <legend><span>Tùy chọn</span></legend>
                                    <table class="info_table">
                                        <tr>
                                            <td class="info_table_td">Trạng thái</td>
                                            <td class="info_table_td">
                                                <dx:ASPxComboBox ID="cboTrangthai" runat="server" Width="200px">
                                                    <Items>
                                                        <dx:ListEditItem Text="Đã gọi điện" Value="0" />
                                                        <dx:ListEditItem Text="Chưa chăm sóc" Value="1" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div class="form-group" style="float:left; width:68%; margin-left:10px">
                                <dx:ASPxGridView ID="Grv_KHTiemnag" runat="server" Width="100%">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Tên khách hàng"></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </div>

                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Khách hàng">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </fieldset>
</asp:Content>
