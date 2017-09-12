<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AddChiendich_Dungthu.aspx.vb" Inherits="NANO_SPA.AddChiendich_Dungthu" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHiddenField" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        var last_value = null;
        function Onchanger(txt_Tenchuongtrinh) {
            if (cb_Sanpham.InCallback())
                last_value = txt_Tenchuongtrinh.GetValue().toString();
            else
                cb_Sanpham.PerformCallback(txt_Tenchuongtrinh.GetValue().toString());
        }
        function endcallbackCb(s, e) {
            if (last_value) {
                cb_Sanpham.PerformCallback(last_value);
                last_value = null;
            }
        }
        var lastvalue = null
        function loadtag(cb_TagSP) {
            if (client_grid.InCallback())
                lastvalue = cb_TagSP.GetValue().toString();
            else
                client_grid.PerformCallback(cb_TagSP.GetValue().toString());
        }
        function OnEndCallback(s, e) {
            if (lastvalue) {
                client_grid.PerformCallback(lastvalue);
                lastvalue = null;
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

        function btn_NhapMoi_Click(s, e) {
            dgv_Ds.PerformCallback(txt_Tenchuongtrinh_All.GetValue().toString());
        }
        function chkallChange(s, e) {
         
                
                cb_Khachhang.PerformCallback();
    
        }

    </script>
         <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" OnClick="btnQuaylai_Click" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>PHÁT SẢN PHẨM</p>
            </li>
        </ul>
    </div>
    
  
    <div style="clear:both">
        <fieldset class="field_tt" style="width:100%;margin:auto">
            <legend><span style="font-weight: bold; color: green">Thông tin chi tiết</span></legend>
            <fieldset style="float:left; width:45%">
                <table class="info_table" style="float:left; width: 623px;">
            <tbody>
                <tr>
                    <td class="info_table_td">Tên chương trình :</td>
                    <td class="info_table_td" colspan="3">
                        <dx:ASPxComboBox ID="txt_Tenchuongtrinh" runat="server" ValueType="System.String" Width="455px" DropDownWidth="900px"
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
                  <td>
                      KH Tiềm năng/Hệ thống
                  </td>
                  <td>
                       <dx:ASPxCheckBox ID="ck_Trangthai" runat="server" ClientInstanceName="ck_Trangthai"  AutoPostBack="false">
                                   <ClientSideEvents CheckedChanged="chkallChange" />
                              </dx:ASPxCheckBox>
                  </td>
              </tr>
                <tr>
                    <td class="info_table_td">Khách hàng :</td>
                    <td class="info_table_td" style="width: 175px">
                  
                        <dx:ASPxComboBox ID="cb_Khachhang" runat="server" ValueType="System.String" DropDownWidth="900px"
                            DropDownStyle="DropDown" ValueField="uId_Khachhang" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}-{2}" ClientInstanceName="cb_Khachhang" OnCallback="cb_Khachhang_Callback">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_Khachhang" Visible="false" />
                                <dx:ListBoxColumn FieldName="v_Makhachang" Width="200px" Caption="Mã khách hàng" />
                                <dx:ListBoxColumn FieldName="nv_Hoten_vn" Width="400px" Caption="Họ tên" />
                                <dx:ListBoxColumn FieldName="Trangthai" Width="200px" Caption="Trạng thái" />
                                </Columns>
                            <ClientSideEvents SelectedIndexChanged="Select_Khachhang" />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Ngày phát :</td>
                    <td class="info_table_td">
                        <dx:aspxdateedit ID="de_Ngayphat"  EditFormat="DateTime" Width="170px" EditFormatString="dd/MM/yyyy" ReadOnly="true" runat="server"></dx:aspxdateedit>
                    </td>
                </tr>
                <tr>
                    <td class="info_table_td">Mặt hàng :</td>
                    <td class="info_table_td" >
                        <dx:ASPxComboBox ID="cb_Sanpham" runat="server" ValueType="System.String" Width="170px" 
                            DropDownStyle="DropDown" ValueField="uId_Mathang" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}" ClientInstanceName="cb_Sanpham">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_Mathang" Visible="false" />
                                <dx:ListBoxColumn FieldName="nv_TenMathang_vn" Caption="Tên dịch vụ" />
                                </Columns>
                            <ClientSideEvents EndCallback ="endcallbackCb" SelectedIndexChanged="function(s, e) { loadtag(s); }" />
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td"> Ngày kết thúc: </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="de_Ngayketthuc" runat="server" Width="170px"></dx:ASPxDateEdit>
                    </td>
                    
                </tr>
               
                <tr>
                    <td class="info_table_td" colspan="4">
                        <dx:aspxbutton ID="btn_Refresh" ClientInstanceName="btn_Refresh" runat="server" Text="Làm mới" Style="float: left;margin-left: 200px" Image-Url="~/images/16x16/refresh.png"></dx:aspxbutton>
                        <dx:aspxbutton ID="btn_Add" ClientInstanceName="btn_Add" runat="server" Text="Nhập mới" Style="float: left;margin-left: 10px; height: 28px;" Image-Url="~/images/16x16/add.png">
                            
                        </dx:aspxbutton>

                    </td>
                </tr>
               
            </tbody>
            </table>
            </fieldset>
            <fieldset style="float:right;width:675px">
                <table style="float:right;width:675px">
                <tr>
                    <td>
                        <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid"
                            AutoGenerateColumns="false" KeyFieldName="uId_Mathang" SettingsPager-Position="Bottom" Width="675px">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_Mathang"
                                    Name="uId_Mathang">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="515px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Tên Mặt hàng" FieldName="nv_TenMathang_vn"
                                    Name="nv_TenMathang_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn VisibleIndex="4" Visible="true" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                                        <Image Url="~/images/btn_Delete.png"></Image>
                                    </DeleteButton>
                                </dx:GridViewCommandColumn>
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
    </div>
    <div style="padding-bottom:20px">
        <fieldset class="field_tt" style="width:100%;margin:auto">
              <div style="height: 20px; width: 1070px; margin: auto">

            <ul>         
                    <li class="text_title">Chương trình :</li>
                    <li class="text_title" >
                        <dx:ASPxComboBox ID="cb_TenCT_Load" runat="server" ClientInstanceName="txt_Tenchuongtrinh_All" DropDownStyle="DropDown" DropDownWidth="900px" EnableCallbackMode="true" IncrementalFilteringMode="Contains" TextFormatString="{0}-{1}-{2}" ValueField="uId_ChiendichMarketing" ValueType="System.String" Width="280">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_ChiendichMarketing" Visible="false" />
                                <dx:ListBoxColumn Caption="Tên chiến dịch" FieldName="nv_Tenchiendich_vn" />
                                <dx:ListBoxColumn Caption="Ngày bắt đầu" FieldName="d_Ngaybatdau" />
                                <dx:ListBoxColumn Caption="Ngày kết thúc" FieldName="d_Ngayketthuc" />
                            </Columns>
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { Onchanger_grid(s);}" />
                        </dx:ASPxComboBox>
                    </li>
                  
                
            </ul>
        </div>
        <dx:ASPxGridView ID="dgv_Ds" CssClass="grid_dm_dv" runat="server" ClientInstanceName="dgv_Ds"
                            AutoGenerateColumns="false" SettingsPager-Position="Bottom" KeyFieldName="uId_ChiendichMarketing_Chitiet" OnRowDeleting="dgv_Ds_RowDeleting" OnRowUpdating="dgv_Ds_RowUpdating" Width="100%">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                                    Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_ChiendichMarketing_Chitiet"
                                    Name="uId_ChiendichMarketing_Chitiet">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Width="300px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Họ tên khách" FieldName="nv_Hoten_vn"
                                    Name="nv_Hoten_vn">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Ngày tặng" FieldName="d_Ngaytang"
                                    Name="d_Ngaytang" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Ngày kết thúc" FieldName="d_Ngayketthuc"
                                    Name="d_Ngayketthuc" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="4" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Số DV dùng thử" FieldName="i_sl"
                                    Name="i_sl">
                                </dx:GridViewDataTextColumn>
                     <dx:GridViewCommandColumn Width="100px" VisibleIndex="4" Caption="Edit" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                    <CancelButton>
                        <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                    </CancelButton>
                    <UpdateButton>
                        <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                    </UpdateButton>
                    <EditButton Visible="true" Image-Url="../../images/btn_Edit.png" Image-AlternateText="Sửa">
                    </EditButton>
                    
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
