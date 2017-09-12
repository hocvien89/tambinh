<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AddChiendich_Phanhoi.aspx.vb" Inherits="NANO_SPA.AddChiendich_Phanhoi" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHiddenField" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        var last_value = null;
        function Onchanger(txt_Tenchuongtrinh) {
            if (cb_Khachhang.InCallback())
                last_value = txt_Tenchuongtrinh.GetValue().toString();
            else
                cb_Khachhang.PerformCallback(txt_Tenchuongtrinh.GetValue().toString());
        }
        function callbackCB(s, e) {
            if (last_value) {
                cb_Khachhang.PerformCallback(last_value);
                last_value = null;
            }
        }
        last_value = null;
        function Select_Khachhang(cb_Khachhang) {
            if (client_grid.InCallback())
                last_value = cb_Khachhang.GetValue().toString();
            else
                client_grid.PerformCallback(cb_Khachhang.GetValue().toString());
        }
        function OnEndCallback(s, e) {
            if (last_value) {
                client_grid.PerformCallback(last_value);
                last_value = null;
            }
        }
        last_value = null

        function Onchanger_grid(txt_Tenchuongtrinh_All) {
            if (dgv_Ds.InCallback())
                last_value = txt_Tenchuongtrinh_All.GetValue().toString();
            else
                dgv_Ds.PerformCallback(txt_Tenchuongtrinh_All.GetValue().toString());
        }

        function OnEndCallback_DS(s, e) {
            if (last_value) {
                dgv_Ds.PerformCallback(last_value);
                last_value = null;
            }
        }

    </script>
    <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" OnClick="btnQuaylai_Click" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>PHẢN HỒI CỦA KHÁCH HÀNG DÙNG THỬ SẢN PHẨM</p>
            </li>
        </ul>
    </div>
        <fieldset class="field_tt" style="width:98%">
            <legend><span style="font-weight: bold; color: green">Thông tin chi tiết</span></legend>
            <fieldset style="float:left; width:45%">
                <table class="info_table" style="float:left">
            <tbody>
                <tr>
                    <td class="info_table_td">Tên chương trình :</td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxComboBox ID="txt_Tenchuongtrinh" runat="server" ValueType="System.String" Width="464px" DropDownWidth="900px"
                            DropDownStyle="DropDown" ValueField="uId_ChiendichMarketing" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}-{2}" ClientInstanceName="txt_Tenchuongtrinh">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_ChiendichMarketing" Visible="false" />
                                <dx:ListBoxColumn FieldName="nv_Tenchiendich_vn" Caption="Tên chiến dịch" />
                                <dx:ListBoxColumn FieldName="d_Ngaybatdau" Caption="Ngày bắt đầu" />
                                <dx:ListBoxColumn FieldName="d_Ngayketthuc" Caption="Ngày kết thúc" />
                                </Columns>
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { Onchanger(s);}" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Khách hàng :</td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="cb_Khachhang" runat="server" ValueType="System.String" DropDownWidth="900px"
                            DropDownStyle="DropDown" ValueField="uId_Khachhang" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}-{2}" ClientInstanceName="cb_Khachhang">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_Khachhang" Visible="false" />
                                <dx:ListBoxColumn FieldName="v_Makhachang" Width="200px" Caption="Mã khách hàng" />
                                <dx:ListBoxColumn FieldName="nv_Hoten_vn" Width="400px" Caption="Họ tên" />
                                <dx:ListBoxColumn FieldName="v_DienthoaiDD" Width="200px" Caption="Điện thoại" />
                                </Columns>
                            <ClientSideEvents SelectedIndexChanged="Select_Khachhang" EndCallback="callbackCB" />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Ngày nhận :</td>
                    <td class="info_table_td">
                        <dx:aspxdateedit ID="de_Ngayphat"  EditFormat="DateTime" EditFormatString="dd/MM/yyyy" Width="170px" ReadOnly="true" runat="server"></dx:aspxdateedit>
                    </td>
                </tr>
                
               
                
                <tr>
                    <td class="info_table_td">Phản hồi :</td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxMemo ID="txt_Phanhoi" runat="server" Height="50px" Width="464px"></dx:ASPxMemo>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td" colspan="4">
                        <dx:aspxbutton ID="btn_Refresh" ClientInstanceName="btn_Refresh" runat="server" Text="Làm mới" Style="float: left" Image-Url="~/images/16x16/refresh.png"></dx:aspxbutton>
                        <dx:aspxbutton ID="btn_Add" ClientInstanceName="btn_Add" runat="server" Text="Phản hồi" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/add.png"></dx:aspxbutton>

                    </td>
                </tr>
                
            </tbody>
            </table>
                
            </fieldset>
            <fieldset style="float:right;width:51%">
                <table style="float:right;width:100%">
                    <tr>
                    <td >
                        
                            <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid"
                            AutoGenerateColumns="false" KeyFieldName="uId_Mathang" SettingsPager-Position="Bottom" Width="100%">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Mathang"
                                    Name="uId_Mathang">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="515px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên Mặt hàng" FieldName="nv_TenMathang_vn"
                                    Name="nv_TenMathang_vn">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsEditing Mode="Inline" />
                            <SettingsPager PageSize="15">
                            </SettingsPager>
                            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                            <SettingsBehavior ProcessSelectionChangedOnServer="true"  AllowFocusedRow="true" AllowMultiSelection="true"  
                                              ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true"  />
                            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                            <ClientSideEvents EndCallback="OnEndCallback" />
                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                </AlternatingRow>
                            </Styles>
                        </dx:ASPxGridView>
                       
                    </td>
                </tr>
                </table>
            </fieldset>
        </fieldset>
    
    <div style="padding-bottom:50px">
        <fieldset class="field_tt" style="margin:auto;width:98%">
            <div>
                <ul>
                    <li class="text_title">Chương trình :</li>
                    <li class="text_title" >
                        <dx:ASPxComboBox ID="cb_TenCT_Load" runat="server" ValueType="System.String" Width="280" DropDownWidth="900px"
                            DropDownStyle="DropDown" ValueField="uId_ChiendichMarketing" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}-{2}" ClientInstanceName="txt_Tenchuongtrinh_All">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_ChiendichMarketing" Visible="false" />
                                <dx:ListBoxColumn FieldName="nv_Tenchiendich_vn" Caption="Tên chiến dịch" />
                                <dx:ListBoxColumn FieldName="d_Ngaybatdau" Caption="Ngày bắt đầu" />
                                <dx:ListBoxColumn FieldName="d_Ngayketthuc" Caption="Ngày kết thúc" />
                                </Columns>
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { Onchanger_grid(s);}" />
                        </dx:ASPxComboBox>
                    </li>
                   
                </ul>
            </div>
        <dx:ASPxGridView ID="dgv_Ds" CssClass="grid_dm_dv" runat="server" ClientInstanceName="dgv_Ds"
                            AutoGenerateColumns="false" KeyFieldName="uId_ChiendichMarketing_Chitiet" SettingsPager-Position="Bottom" Width="99%">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_ChiendichMarketing_Chitiet"
                                    Name="uId_ChiendichMarketing_Chitiet">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Họ tên khách" FieldName="nv_Hoten_vn"
                                    Name="nv_Hoten_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Ngày tặng" FieldName="d_Ngaytang"
                                    Name="d_Ngaytang" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Ngày phản hồi" FieldName="d_Ngaydungthu"
                                    Name="d_Ngaydungthu" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="4" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Số DV dùng thử" FieldName="i_sl"
                                    Name="i_sl">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="5" Width="400px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Nội dung phản hồi" FieldName="nv_Phanhoi"
                                    Name="nv_Phanhoi">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsEditing Mode="Inline" />
                            <SettingsPager PageSize="15">
                            </SettingsPager>
                            <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
                            <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
                            <SettingsBehavior ProcessSelectionChangedOnServer="true"  AllowFocusedRow="true" AllowMultiSelection="true"  
                                              ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true"  />
                            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
                            <ClientSideEvents EndCallback="OnEndCallback_DS" />
                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                                </AlternatingRow>
                            </Styles>
                        </dx:ASPxGridView>
            </fieldset>
    </div>
</asp:Content>
