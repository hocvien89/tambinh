<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ConsultService.aspx.vb" Inherits="NANO_SPA.ConsultService" %>

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
    <script src="../../Js/ProcessClinic/consultservice.js" type="text/javascript"></script>
     <script src="../../Js/jquery-1.4.1.min.js" type="text/javascript"></script>
     <script type="text/javascript" src="../../../../Js/jquery-ui.min.js"></script>
    <script type="text/javascript">
        function Inphieu() {
            if (jo_GetSession("uId_Khachhang") == null) {
                alert("Bạn chưa chọn khách hàng !");
            } else {

                var $dialog = $('<div></div>')
                   .html('<iframe style="border: 0px; " src="../../OrangeVersion/Report/Rp_web/Rp_Phieuthuchi/rp_ConsultService.aspx?" width="1000px" height="100%"></iframe>')
                   .dialog({
                       autoOpen: false,
                       modal: true,
                       height: 634,
                       width: 1000,
                       title: "In phiếu",
                       buttons: {
                           "Close": function () { $dialog.dialog('close'); }
                       },
                       close: function (event, ui) {
                       }
                   });
                $dialog.dialog('open');
            }
                 
     }
        function In_HD_Sudung() {
            var $dialog = $('<div></div>')
            .html('<iframe style="border: 0px; " src="../../OrangeVersion/Report/Rp_web/Rp_Clinic/Rp_Huongdansudung.aspx?" width="1000px" height="100%"></iframe>')
            .dialog({
                autoOpen: false,
                modal: true,
                height: 634,
                width: 1000,
                title: "In hướng dẫn dùng thuốc",
                buttons: {
                    "Close": function () { $dialog.dialog('close'); }
                },
                close: function (event, ui) {
                }
            });
            $dialog.dialog('open');
        }

    </script>
    <style>
        #pendroom td {
            padding: 2px;
        }

        foatleft_td {
            float: left;
            padding-right: 10px;
        }
    </style>
    <div class="brest_crum">
        <dx:ASPxButton ID="btnQuaylai" Visible="false" Style="float: left; margin-right: 7px; margin-left: 5px" Image-Url="~/images/16x16/back.png" ClientInstanceName="btnQuaylai" AutoPostBack="false" runat="server" Text="Quay lại">
            <ClientSideEvents Click="BackQuanLyKhachHang" />
        </dx:ASPxButton>
        <asp:Literal ID="ltrTitleHeader" Text="THÊM PHIẾU DỊCH VỤ" runat="server"></asp:Literal>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Danh sách chờ</span></legend>
        <dx:ASPxPageControl ID="tabDSBenhnhan" runat="server" ClientInstanceName="tabdsbenhnhan" Width="100%">
            <TabPages>
                <dx:TabPage Text="Chờ khám" TabStyle-Font-Bold="true">
                    <ContentCollection>
                        <dx:ContentControl>
                            <dx:ASPxGridView ID="dgvDanhsachcho" runat="server" ClientInstanceName="client_dgvDanhsachcho" OnRowDeleting="dgvDanhsachcho_RowDeleting" AutoGenerateColumns="false" SettingsPager-PageSize="4"
                                KeyFieldName="uId_Phieudichvu;uId_Khachhang;uId_TrangthaiKH;uId_Trangthai;uId_Phong"
                                SettingsPager-Position="Bottom">
                                <Styles Header-BackColor="Khaki" Header-Font-Size="12" Header-Font-Bold="true"></Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phieudichvu"
                                        Name="uId_Phieudichvu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Phong"
                                        Name="uId_Phong">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="140px" Caption="Số phiếu" FieldName="v_Sophieu"
                                        Name="v_Sophieu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Tên bệnh nhân" FieldName="nv_Hoten_vn"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Điện thoại" FieldName="v_DienthoaiDD"
                                        Name="v_DienthoaiDD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Đang ở phòng" FieldName="nv_Tenphong_vn"
                                        Name="nv_Tenphong_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Trạng thái" FieldName="nv_Tentrangthai_vn"
                                        Name="nv_Tentrangthai_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu"
                                        Name="nv_Ghichu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày Lập" FieldName="d_Ngaylam"
                                        Name="d_Ngaylam">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ngày chuyển" FieldName="d_Ngaylam"
                                        Name="d_Ngaylam">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Điều trị" href='javascript:void(0)' onclick="return <%# String.Format("XuLyPhieuDichVu('{0}', '{1}','{2}','{3}','{4}','{5}')", Eval("uId_Phieudichvu"), Eval("uId_Khachhang"), Eval("uId_TrangthaiKH"), Eval("nv_Hoten_vn"), Eval("v_Sophieu"), Eval("d_Ngaylap")).ToString%>">
                                                <img src="../../../images/bub.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Kết thúc khám" href='javascript:void(0)'
                                                onclick="return <%# String.Format("KetThucKham('{0}','{1}')", Eval("uId_Phieudichvu"), Eval("nv_Hoten_vn")).ToString%>">
                                                <img src="../../images/16x16/door_out.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="4" Width="30px" Caption="" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                            <Image Url="~/images/btn_Delete.png"></Image>
                                        </DeleteButton>
                                    </dx:GridViewCommandColumn>
                                </Columns>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="4">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false"
                                    ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" EmptyDataRow="Không có phiếu khám cần xử lý!" />
                                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                    <GroupRow Font-Bold="true"></GroupRow>
                                </Styles>
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Đã khám">
                    <ContentCollection>
                        <dx:ContentControl>
                            <dx:ASPxGridView ID="GrvDadieutri" ClientInstanceName="grvdadieutri" runat="server" AutoGenerateColumns="false" KeyFieldName="uId_Khachhang">
                                <Styles Header-BackColor="Khaki" Header-Font-Size="12" Header-Font-Bold="true"></Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Width="140px" Caption="Mã bệnh nhân" FieldName="v_Makhachhang"
                                        Name="v_Makhachhang">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Tên bệnh nhân" FieldName="nv_Hoten_vn"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Điện thoại" FieldName="v_DienthoaiDD"
                                        Name="v_DienthoaiDD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Địa chỉ" FieldName="nv_Diachi_vn"
                                        Name="nv_Hoten_vn">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        HeaderStyle-HorizontalAlign="Center" Caption="Ghi chú" FieldName="nv_Ghichu"
                                        Name="nv_Ghichu">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <a id="popup" title="Chọn bệnh nhân" href='javascript:void(0)' onclick="return <%# String.Format("Lichsudieutri('{0}', '{1}')", Eval("uId_Khachhang"), Eval("nv_Hoten_vn")).ToString%>">
                                                <img src="../../../images/bub.png" /></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="4" Width="30px" Caption="" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                        <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                            <Image Url="~/images/btn_Delete.png"></Image>
                                        </DeleteButton>
                                    </dx:GridViewCommandColumn>
                                </Columns>
                                <SettingsEditing Mode="Inline" />
                                <SettingsPager PageSize="4">
                                </SettingsPager>
                                <Settings ShowFilterRow="true" ShowGroupPanel="false"
                                    ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                                <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" EmptyDataRow="Không có phiếu khám cần xử lý!" />
                                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                    </AlternatingRow>
                                    <GroupRow Font-Bold="true"></GroupRow>
                                </Styles>
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
            <ClientSideEvents ActiveTabChanged="tablistsuchange" />
        </dx:ASPxPageControl>
    </fieldset>
    <div style="clear: both"></div>
    <div class="bill_infor">
        <fieldset class="field_dsphieu">
            <legend><span style="font-weight: bold; color: green">Danh sách dịch vụ</span></legend>
            <asp:HiddenField ID="hdfuIdDichvu" runat="server" />
            <asp:HiddenField ID="hdfGiamgiaDV" runat="server" />
            <asp:HiddenField ID="hdfTienDV" runat="server" />
            <dx:ASPxGridView ID="dgvDevexpress" runat="server" Width="520px" ClientInstanceName="client_grid" CssClass="grid_dm_dv"
                AutoGenerateColumns="false" KeyFieldName="uId_Dichvu" OnDataBound="dgvDevexpress_DataBound"
                SettingsPager-Position="Bottom">
                <Styles Header-BackColor="Khaki" Header-Font-Size="12" Header-Font-Bold="true"></Styles>
                <Columns>
                    <dx:GridViewCommandColumn Width="30px" ShowSelectCheckbox="True" Visible="true" VisibleIndex="0" Name="chon">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Dichvu"
                        Name="uId_Dichvu">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                        Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="vType"
                        Name="vType">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Width="140px" Caption="Nhóm dịch vụ" FieldName="nv_TennhomDichvu_vn"
                        Name="nv_TennhomDichvu_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"
                        Name="nv_Tendichvu_vn">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="60px" VisibleIndex="1" Caption="Số lần" Settings-AutoFilterCondition="Contains"
                        HeaderStyle-HorizontalAlign="Center" FieldName="i_Solan_Dieutri" Name="i_Solan_Dieutri">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsEditing Mode="Inline" />
                <SettingsPager PageSize="1000">
                </SettingsPager>
                <Settings ShowFilterRow="true" ShowGroupPanel="false" VerticalScrollBarMode="Auto" VerticalScrollableHeight="350"
                    ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                <SettingsBehavior ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                    </AlternatingRow>
                    <GroupRow Font-Bold="true"></GroupRow>
                </Styles>
            </dx:ASPxGridView>
        </fieldset>
        <fieldset class="field_thanhtoan">
            <legend><span style="font-weight: bold; color: green">Thông tin phiếu </span></legend>
            <div class="box_thanhtoan">
                <table class="info_table">
                    <tbody>
                        <tr>
                            <td class="info_table_td">Ngày lập:
                            </td>
                            <td class="info_table_td">
                                <dx:ASPxDateEdit ID="deNgaylap" UseMaskBehavior="true" ClientInstanceName="deNgaylap" Width="160px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                                    runat="server">
                                    <ClientSideEvents DateChanged="deNgaplapChange" />
                                </dx:ASPxDateEdit>
                            </td>
                            <td class="info_table_td">Số phiếu:
                            </td>
                            <td class="info_table_td">
                                <asp:TextBox runat="server" Width="150px" CssClass="nano_textbox" ID="txtSoPhieu"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="info_table_td">Người bệnh:
                            </td>
                            <td class="info_table_td" colspan="2">
                                <asp:TextBox runat="server" Width="242px" CssClass="nano_textbox" ID="txtHoten"></asp:TextBox>
                            </td>
                            <td style="padding-left: 6px;">
                                <dx:ASPxButton ID="btnRefresh" Image-Url="~/images/top5.png" AutoPostBack="false" Style="float: left; margin-right: 8px" runat="server" Text="Điều trị">
                                    <ClientSideEvents Click="btnlammoiClick" />
                                </dx:ASPxButton>
                            </td>
                            <td class="info_table_td"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="box_thanhtoan" style="min-height: 174px;">
                <dx:ASPxGridView ID="dgvPhieuchitiet" runat="server" ClientInstanceName="client_Phieuchitiet"
                    AutoGenerateColumns="false" KeyFieldName="uId_Phieudichvu_Chitiet;uId_Dichvu;nv_Tendichvu_vn" CssClass="grid_dm_dv" SettingsPager-PageSize="8"
                    SettingsPager-Position="Bottom" OnRowDeleting="dgvPhieuchitiet_RowDeleting" OnDataBinding="dgvPhieuchitiet_DataBinding" OnRowUpdating="dgvPhieuchitiet_RowUpdating"
                    OnDataBound="dgvPhieuchitiet_DataBound">
                    <Styles Header-BackColor="Khaki" Header-Font-Size="12" Header-Font-Bold="true"></Styles>
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Visible="false" VisibleIndex="-2">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                            Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Dichvu"
                            Name="uId_Dichvu">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn"
                            Name="nv_Tendichvu_vn">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Width="80px" Caption="Tổng ĐT" ReadOnly="true" FieldName="f_Solan"
                            Name="f_Solan">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Width="80px" Caption="Thời gian" ReadOnly="true" FieldName="Thoigian"
                            Name="f_Solan">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Đã ĐT" Width="70px" ReadOnly="true" FieldName="i_SL_daDieutri"
                            Name="i_SL_daDieutri">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Giá" Width="70px" FieldName="f_Dongia"
                            Name="f_Dongia">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="SL" Width="50px" FieldName="f_Soluong"
                            Name="f_Soluong">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColumn Width="60px" Visible="false" FieldName="f_Giamgia" VisibleIndex="1" Caption="G.Giá" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <%#Eval("f_Giamgia", "{0:0,0}")%>
                            </DataItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGiamgia" Width="60px" Text='<%# Eval("f_Giamgia")%>'
                                    runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataTextColumn Visible="false" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="{0:0,0}" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Caption="Tiền" Width="70px" FieldName="f_Tongtien"
                            Name="f_Tongtien">
                        </dx:GridViewDataTextColumn>
                        <%--                        <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" FieldName="ChonPhieu">
                            <DataItemTemplate>
                                <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)' onclick="return Thietlaplieutrinh('<%#Eval("uId_Phieudichvu_Chitiet") %>')">
                                    <img src="../../../images/bub.png" /></a>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>--%>
                        <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ButtonType="Image" Caption="xóa">
                            <CancelButton>
                                <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                            </CancelButton>
                            <UpdateButton Visible="false">
                                <Image AlternateText="Save" Url="~/images/btn_Save.png" />
                            </UpdateButton>
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Delete" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Delete">
                                    <Image AlternateText="Delete" Url="~/images/btn_Delete.png">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                    </Columns>
                    <SettingsEditing Mode="Inline" />
                    <SettingsPager PageSize="3">
                    </SettingsPager>
                    <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                    <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                    <SettingsText ConfirmDelete="Bạn có muốn xóa không?" EmptyDataRow="Không có dịch vụ đã kê!" />
                    <ClientSideEvents CustomButtonClick="OnCustomButtonClick" EndCallback="gridPhieuchitiet_EndCallback" RowDblClick="grid_RowDblClick" FocusedRowChanged="grid_FocusedRowChanged" SelectionChanged="function(s, e) { SelChanged_chitiet(s, e); }" />
                    <Styles>
                        <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                        </AlternatingRow>
                    </Styles>
                </dx:ASPxGridView>
                <div class="box_huy" id="box_huy" style="display: none">
                    <span style="color: Red; margin-left: 45px">Phiếu đã thanh toán! Xin vui lòng cho biết lí do xóa</span>
                    <asp:TextBox ID="txtLidoxoa" Width="225px" placeholder="Nhập lí do xóa" CssClass="nano_textbox" runat="server"></asp:TextBox>
                    <dx:ASPxButton ID="btnLidoxoa" OnClick="btnLidoxoa_Click" Image-Url="~/images/btn_Delete.png" Style="float: right; margin-left: 10px; position: relative; bottom: 6px" ClientInstanceName="btnLidoxoa" runat="server" Text="Hủy">
                    </dx:ASPxButton>
                </div>
            </div>
            <table id="pendroom" style="position: relative; top: 8px">
                <tbody>
                    <tr>
                        <td class="info_table_td">Chuyển đến:
                        </td>
                        <td class="info_table_td">
                            <dx:ASPxComboBox ID="ddlDMPhong" ClientInstanceName="ddlDMPhong" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="130px" ValueType="System.String" runat="server">
                                <ClientSideEvents SelectedIndexChanged="phongchange" />
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td">Trạng thái:
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="ddlTrangthai" ClientInstanceName="ddlTrangthai" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Height="25px" Width="130px" ValueType="System.String" runat="server">
                                <ClientSideEvents SelectedIndexChanged="cboTrangthaiChange" />
                            </dx:ASPxComboBox>
                        </td>
                        <td class="info_table_td">Ngày chuyển: </td>
                        <td class="info_table_td">
                            <dx:ASPxDateEdit ID="Dat_Ngaychuyen" ClientInstanceName="Dat_ngaychuyen" runat="server" Width="110px"></dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr id="box_note">
                        <td class="info_table_td">Ghi chú chuyển:
                        </td>
                        <td class="info_table_td" colspan="5">
                            <asp:TextBox ID="txtNote" runat="server" Width="514px" CssClass="nano_textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="Tr1">
                        <td></td>
                        <td class="info_table_td" colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <dx:ASPxButton ID="btnChuyen" OnClick="btnChuyen_Click" ClientInstanceName="btnchuyen" Image-Url="~/images/door_in.png" Style="float: left; margin-right: 8px" runat="server" Text="Chuyển">
                                        <ClientSideEvents Click="btnchuyenClick" />
                                    </dx:ASPxButton>
                                   
                                     <dx:ASPxButton ID="btnIn" AutoPostBack="false" Visible="True" Image-Url="~/images/16x16/printer.png" Style="float: left; margin-left: 10px" ClientInstanceName="btnIn" runat="server" Text="In phiếu">
                                        <ClientSideEvents Click="Inphieu"/> 
                                    </dx:ASPxButton>
                                      <dx:ASPxButton ID="Print_HD" AutoPostBack="false" Visible="True" Image-Url="~/images/16x16/printer.png" Style="float: left; margin-left: 10px" ClientInstanceName="btnIn" runat="server" Text="In hướng dẫn">
                                        <ClientSideEvents Click="In_HD_Sudung"/> 
                                    </dx:ASPxButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </div>
    <div style="clear: both"></div>
    <dx:ASPxPopupControl ID="PcThongtinKham" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides" ClientInstanceName="pcthongtinkham" Font-Size="25px"
        HeaderText="Hồ sơ bệnh nhân" AllowDrgging="True" PopupAnimationType="None">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="1000px" Font-Size="12px">
                            <PanelCollection>
                                <dx:PanelContent ID="PanelContent1" runat="server" Width="100%">
                                    <fieldset class="field_tt">
                                        <legend><span style="font-weight: bold; color: green; font-size: 18px"></span></legend>
                                        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" ClientInstanceName="pagedieutri">
                                            <TabPages>
                                                <dx:TabPage Text="Biểu hiện chứng bệnh" Name="tabbieuhien">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <fieldset class="field_tt">
                                                                <table class="info_table" style="width: 100%">
                                                                    <tr>
                                                                        <td class="info_table_td" rowspan="3">
                                                                            <fieldset class="container-fluid">
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Triệu chứng lâm sàng</span></legend>
                                                                                <dx:ASPxMemo runat="server" ClientInstanceName="memotrieuchung" ID="memoTrieuchung" Height="246" Width="100%" HorizontalAlign="Left"></dx:ASPxMemo>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td class="info_table_td" rowspan="4">
                                                                            <fieldset class="container-fluid">
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Yếu tố tăng bệnh</span></legend>
                                                                                <dx:ASPxMemo runat="server" ClientInstanceName="memoyeutotangbenh" ID="memoYeutotangbenh" Height="345" HorizontalAlign="Left" Width="100%"></dx:ASPxMemo>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td class="info_table_td">
                                                                            <fieldset class="container-fluid">
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Cơ địa</span></legend>
                                                                                <dx:ASPxMemo runat="server" ClientInstanceName="memocodia" ID="memoCodia" Height="50" HorizontalAlign="Left" Width="100%"></dx:ASPxMemo>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="info_table_td">
                                                                            <fieldset>
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Đã dùng trị bệnh</span></legend>
                                                                                 <fieldset class="container-fluid">
                                                                                    <legend><span style="font-weight: bold; color: black; font-size: 14px">Đông dược</span></legend>
                                                                                    <dx:ASPxMemo runat="server" ClientInstanceName="memodungtanduoc" ID="memodungtanduoc" Height="50" HorizontalAlign="Left" Width="100%"></dx:ASPxMemo>
                                                                                </fieldset>
                                                                                <fieldset class="container-fluid">
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Tân dược:</span></legend>
                                                                                <dx:ASPxMemo runat="server" ClientInstanceName="memodungdongduoc" ID="memoDungdongduoc" Height="50" HorizontalAlign="Left" Width="100%"></dx:ASPxMemo>
                                                                            </fieldset>
                                                                            </fieldset>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="info_table_td">
                                                      
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="info_table_td">
                                                                            <fieldset class="container-fluid">
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Bệnh sử:</span></legend>
                                                                                <dx:ASPxMemo runat="server" ClientInstanceName="memobenhsu" ID="memoBenhsu" Height="50" HorizontalAlign="Left" Width="100%"></dx:ASPxMemo>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td class="info_table_td">
                                                                            <fieldset class="container-fluid">
                                                                                <legend><span style="font-weight: bold; color: black; font-size: 14px">Ghi chú</span></legend>
                                                                                <dx:ASPxMemo runat="server" ClientInstanceName="memoghichu" ID="memoGhichu" Height="50" HorizontalAlign="Left" Width="100%"></dx:ASPxMemo>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:TabPage>
                                            </TabPages>
                                            <TabPages>
                                                <dx:TabPage Text="Tình trạng cơ thể" Name="tabcothe">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <fieldset class="container-fluid" style="width: 43%; float: left; margin-right: 20px; min-height: 303px">
                                                                        <table class="info_table">
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Mạch: </td>
                                                                                <td class="info_table_td" colspan="7">
                                                                                    <dx:ASPxTextBox ID="txtMach" runat="server" Width="290px" ClientInstanceName="txtmach" onkeypress="return enter_txtmach(event)"></dx:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Huyết áp: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox ID="txtHuyetap" runat="server" ClientInstanceName="txthuyetap" CssClass="floatleft" Width="100px"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Tân dược đã uống trước:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox ID="txtHuyetapGio" runat="server" ClientInstanceName="txthuyetapgio" NullText="Giờ" Width="100px" CssClass="floatleft"></dx:ASPxTextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Lưỡi: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox ID="txtLuoichat" runat="server" ClientInstanceName="txtluoichat" CssClass="floatleft" Width="100px" NullText="chất"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Rêu:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox ID="txtLuoireu" runat="server" ClientInstanceName="txtluoireu" Width="100px" CssClass="floatleft"></dx:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Da: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboDa" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cboda" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Mồ hôi: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboMohoi" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cbomohoi" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Ăn: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboAn" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cboan" Width="100px"></dx:ASPxComboBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Ngủ: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboNgu" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cbongu" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Đại tiện: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboDaitien" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cbodaitien" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                                <td class="info_table_td" colspan="2">
                                                                                    <dx:ASPxTextBox ID="txtLandaitien" runat="server" CssClass="floatleft" Width="30px" ClientInstanceName="txtdaitienlan"></dx:ASPxTextBox>
                                                                                    <dx:ASPxLabel ID="lbl1" runat="server" Text="Lần/" CssClass="floatleft"></dx:ASPxLabel>
                                                                                    <dx:ASPxTextBox ID="txtDaitienngay" runat="server" ClientInstanceName="txtdaitienngay" CssClass="floatleft" Width="30px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxTextBox>
                                                                                    Ngày
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Tiểu tiện: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboTieutien" TextField="nv_Nguon_vn" ValueField="uId_Nguon" runat="server" ClientInstanceName="cbotieutien" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                                <td class="info_table_td" colspan="2">
                                                                                    <dx:ASPxTextBox ID="txtlantieutien" runat="server" CssClass="floatleft" Width="30px" ClientInstanceName="txttieutienlan"></dx:ASPxTextBox>
                                                                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lần/" CssClass="floatleft"></dx:ASPxLabel>
                                                                                    <dx:ASPxTextBox ID="txttieutienngay" runat="server" ClientInstanceName="txttieutienngay" CssClass="floatleft" Width="30px"></dx:ASPxTextBox>
                                                                                    Ngày
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Thể trạng: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboThetrang" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cbothetrang" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                                <td class="info_table_td" colspan="2">
                                                                                    <dx:ASPxTextBox ID="txtKg" runat="server" CssClass="floatleft" Width="30px" ClientInstanceName="txtkg"></dx:ASPxTextBox>
                                                                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text=" Kg/ " CssClass="floatleft"></dx:ASPxLabel>
                                                                                    <dx:ASPxTextBox ID="txtCm" runat="server" ClientInstanceName="txtcm" CssClass="floatleft" Width="30px"></dx:ASPxTextBox>
                                                                                    Cm
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Thể lực: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboTheluc" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cbotheluc" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Thần kinh: </td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxComboBox ID="cboTinhthan" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" ClientInstanceName="cbotinhthan" Width="100px"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                    <fieldset class="container-fluid" style="width: 48%; float: left">
                                                                        <legend><span style="font-weight: bold; color: green; font-size: 14px">Sinh hóa máu</span></legend>
                                                                        <table class="info_table">
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">GOT:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtSHMGOT" ClientInstanceName="txtshmgot"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">GPT:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtSMHGPT" ClientInstanceName="txtshmgpt"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">GGT:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtSHMGGT" ClientInstanceName="txtshmggt"></dx:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Bil_TP:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtBiltp" ClientInstanceName="txtbiltp"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Bil_TT:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtBiltt" ClientInstanceName="txtbiltt"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Chol:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtChol" ClientInstanceName="txtchol"></dx:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">TriG:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtTriG" ClientInstanceName="txttrig"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">HDL:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtdhl" ClientInstanceName="txthdl"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">LDL:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtLdl" ClientInstanceName="txtldl"></dx:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Gluo:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtGluo" ClientInstanceName="txtgluo"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">AUric:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" ID="txtAuric" ClientInstanceName="txtauric"></dx:ASPxTextBox>
                                                                                </td>
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" style="font-weight: bold">Creatinin:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" Style="float: left" ID="txtCreatinin" ClientInstanceName="txtcreatinin" Width="70%"></dx:ASPxTextBox>
                                                                                    <p style="float: left">/120</p>
                                                                                </td>
                                                                                <td class="info_table_td" style="font-weight: bold">Ure:</td>
                                                                                <td class="info_table_td">
                                                                                    <dx:ASPxTextBox runat="server" Style="float: left" ID="txtUre" ClientInstanceName="txture" Width="70%"></dx:ASPxTextBox>
                                                                                    <p style="float: left">/7,5</p>
                                                                                </td>
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" colspan="6" style="font-weight: bold">Thông tin bổ xung:</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" colspan="6">
                                                                                    <dx:ASPxMemo runat="server" Width="100%" Height="20px" ID="memoBoxung" ClientInstanceName="memoboxung"></dx:ASPxMemo>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" colspan="6" style="font-weight: bold">Nhằm hiển thị được kết quả mà bệnh nhân mang đến cho bác sĩ hoặc theo chỉ định của bác sĩ:</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="info_table_td" colspan="6">
                                                                                    <dx:ASPxMemo runat="server" Width="100%" Height="20px" ID="memoChandoantuanh" ClientInstanceName="memochandoantuanh"></dx:ASPxMemo>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:TabPage>
                                            </TabPages>
                                            <TabPages>
                                                <dx:TabPage Text="Lịch sử điều trị" Name="tabdieutri">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <dx:ASPxGridView Width="100%" ID="GrvHistory" OnHtmlRowPrepared="GrvHistory_HtmlRowPrepared" runat="server" ClientInstanceName="grvhistory" KeyFieldName="uId_Phieudichvu_Chitiet">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn Caption="Tên dịch vụ" FieldName="nv_Tendichvu_vn" HeaderStyle-HorizontalAlign="Center">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Ngày khám" FieldName="d_Ngaykham" HeaderStyle-HorizontalAlign="Center" />
                                                                    <dx:GridViewDataTextColumn Caption="Kết luận" FieldName="nv_Ghichu" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Trạng thái" FieldName="Trangthai" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="" FieldName="b_Tinhtrangbenh" Visible="false"></dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" FieldName="ChonPhieu" Caption="Bệnh lý">
                                                                        <DataItemTemplate>
                                                                            <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)' onclick="return Thietlaplieutrinh('<%#Eval("uId_Phieudichvu_Chitiet") %>')">
                                                                                <img src="../../../images/bub.png" /></a>
                                                                        </DataItemTemplate>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn Visible="false" Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" FieldName="ChonPhieu" Caption="Điều trị">
                                                                        <DataItemTemplate>
                                                                            <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)' onclick="return btndieutriClick()">
                                                                                <img src="../../../images/bub.png" /></a>
                                                                        </DataItemTemplate>
                                                                    </dx:GridViewDataColumn>
                                                                </Columns>
                                                                <Templates>
                                                                    <DetailRow>
                                                                        <dx:ASPxPageControl runat="server" ID="pclChitietDieutri" Width="100%">
                                                                            <TabPages>
                                                                                <dx:TabPage Text="Dịch vụ">
                                                                                    <ContentCollection>
                                                                                        <dx:ContentControl>
                                                                                            <dx:ASPxGridView ID="GrvHistoryChitiet" OnBeforePerformDataSelect="GrvHistoryChitiet_BeforePerformDataSelect" runat="server"
                                                                                                KeyFieldName="uId_Phieudichvu" Width="100%">
                                                                                                <Columns>
                                                                                                    <dx:GridViewDataTextColumn Visible="false" HeaderStyle-HorizontalAlign="Center"
                                                                                                        FieldName="uId_Phieudichvu_Chitiet" Name="uId_Phieudichvu_Chitiet">
                                                                                                    </dx:GridViewDataTextColumn>
                                                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                        Caption="Dịch vụ" FieldName="nv_Tendichvu_vn" Name="i_Lanthu">
                                                                                                    </dx:GridViewDataTextColumn>
                                                                                                    <dx:GridViewDataColumn Width="30px" VisibleIndex="4" CellStyle-HorizontalAlign="Center" FieldName="ChonPhieu" Caption="Điều trị">
                                                                                                        <DataItemTemplate>
                                                                                                            <a id="popup" title="Chọn dịch vụ" href='javascript:void(0)' onclick="SelectPhieudieutri('<%#Eval("uId_Phieudichvu")%>')">
                                                                                                                <img src="../../../images/bub.png" /></a>
                                                                                                        </DataItemTemplate>
                                                                                                    </dx:GridViewDataColumn>
                                                                                                </Columns>
                                                                                            </dx:ASPxGridView>
                                                                                        </dx:ContentControl>
                                                                                    </ContentCollection>
                                                                                </dx:TabPage>
                                                                                <dx:TabPage Text="Đơn thuốc">
                                                                                    <ContentCollection>
                                                                                        <dx:ContentControl>
                                                                                            <dx:ASPxGridView ID="grvDonthuoc" OnBeforePerformDataSelect="grvDonthuoc_BeforePerformDataSelect" runat="server"
                                                                                                KeyFieldName="uId_Phieuxuat_Chitiet" Width="100%">
                                                                                                <Columns>
                                                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                        Caption="Dược liệu" FieldName="nv_Tenmathang_vn" Name="nv_Tenmathang_vn">
                                                                                                    </dx:GridViewDataTextColumn>
                                                                                                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                        Caption="Số lượng" FieldName="f_Soluong" Name="f_Soluong">
                                                                                                    </dx:GridViewDataTextColumn>
                                                                                                       <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"
                                                                                                        Caption="Đơn vị" FieldName="MADONVI" Name="MADONVI">
                                                                                                    </dx:GridViewDataTextColumn>
                                                                                                </Columns>
                                                                                            </dx:ASPxGridView>
                                                                                        </dx:ContentControl>
                                                                                    </ContentCollection>
                                                                                </dx:TabPage>
                                                                            </TabPages>
                                                                        </dx:ASPxPageControl>
                                                                    </DetailRow>
                                                                </Templates>
                                                                <SettingsDetail ShowDetailRow="true" ShowDetailButtons="true" />
                                                            </dx:ASPxGridView>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:TabPage>
                                            </TabPages>
                                            <ClientSideEvents ActiveTabChanged="tablichsuchange" />
                                        </dx:ASPxPageControl>
                                        <div id="divChucnang" style="padding-left:5px;">
                                            <fieldset style="padding-left:10px;width:96%">
                                                <legend></legend>
                                                <ul>
                                                    <li class="text_title" style="padding-top:20px;float:left">  <dx:ASPxLabel runat="server" ClientInstanceName="lblketluan" ID="lblKetluuan" Text="Kết luận" Font-Bold="true"></dx:ASPxLabel> </li>
                                                    <li class="text_title">  <dx:ASPxTextBox runat="server" ID="cboKetluan" ClientInstanceName="cboketluan" Width="845px" Height="50px"></dx:ASPxTextBox> </li>
                                                </ul>
                                                <ul>
                                                    <li class="text_title" style="padding-top:10px;">    <dx:ASPxLabel runat="server" ClientInstanceName="lblppdieutri" ID="lblPPdieutri" Font-Bold="true" Text="PP điều trị" Width="45px"></dx:ASPxLabel></li>
                                                    <li class="text_title" style="padding-top:10px;"><dx:ASPxMemo runat="server" ClientInstanceName="memoppdieutri" ID="memoPPDieutri" Height="50px" Width="845px"></dx:ASPxMemo> </li>
                                                </ul>
                                                <ul>
                                                    <li class="text_title" style="padding-top:15px;">
                                                          <dx:ASPxLabel runat="server" Text="TT bệnh " ClientInstanceName="lbl_Tinhtrang" Font-Bold="true"  Style="float: left; margin-right: 10px" Width="50px"></dx:ASPxLabel>
                                                          <dx:ASPxComboBox ID="cb_Tinhtrangbenh" runat="server" TextField="nv_Nguon_vn" ValueField="uId_Nguon" Height="25px" ClientInstanceName="cb_Tinhtrangbenh" Width="200px"
                                                                                       IncrementalFilteringMode="Contains"  Style="float: left; margin-right: 10px">
                                                          </dx:ASPxComboBox>
                                                         <dx:ASPxButton ID="btnLuu" runat="server" Image-Url="~/images/16x16/add.png" AutoPostBack="false" ClientInstanceName="btnluu" Text="Lưu" OnClick="btnLuu_Click" Style="float: left; margin-right: 10px">
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnDieutri" runat="server" AutoPostBack="false" ClientInstanceName="btndieutri" Image-Url="~/images/16x16/save.png" Text="Điều trị" Style="float: left; margin-right: 10px">
                                                            <ClientSideEvents Click="btndieutriClick" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnKethuoc" runat="server" ClientInstanceName="btnkethuoc" AutoPostBack="false" Image-Url="~/images/16x16/medical.png" Text="Kê thuốc" Style="float: left; margin-right: 10px">
                                                            <ClientSideEvents Click="btnkethuocClick" />
                                                        </dx:ASPxButton></li>
                                                </ul>
                                            </fieldset>
                                           
                                        </div>
                                    </fieldset>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxPanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
