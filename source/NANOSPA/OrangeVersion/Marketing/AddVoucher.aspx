<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="AddVoucher.aspx.vb" Inherits="NANO_SPA.AddVoucher" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function dbclick(s, e) {
            s.GetRowValues(e.visibleIndex, 'uId_voucher;uId_Khachhang;v_Mavoucher;nv_Hoten_vn;d_Ngaybatdau;d_Ngayketthuc', OnGridSelectionComplete);
        }
        function OnGridSelectionComplete(values) {
           
            txt_Tenchuongtrinh.SetText(values[1].toString());
            txt_MaVoucher.SetText(values[2].toString());
            de_Ngaybatdau.SetText(values[4].toString());
            de_Ngayketthuc.SetText(values[5].toString());
            btn_Add.SetText('Sửa');
            client_grid.PerformCallback(values[0].toString());
        }
        function chkallChange(s, e) {


            txt_Khachhang.PerformCallback();

        }
    </script>
     <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" OnClick="btnQuaylai_Click" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>PHÁT VOUCHER</p>
            </li>
        </ul>
    </div>
    <div style="clear:both">
        <fieldset class="field_tt" style="margin:auto;width:100%">
        <legend><span style="font-weight: bold; color: green">Thông tin voucher</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Tên chương trình :</td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="txt_Tenchuongtrinh" runat="server" ValueType="System.String" DropDownWidth="900px"
                            DropDownStyle="DropDown" ValueField="uId_Loaivoucher" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}" ClientInstanceName="txt_Tenchuongtrinh" >
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_Loaivoucher" Visible="false" />
                                <dx:ListBoxColumn FieldName="nv_Tenloaivoucher" Caption="Loại Voucher" />
                                <dx:ListBoxColumn FieldName="d_Ngaybatdau" Caption="Ngày bắt đầu" />
                                <dx:ListBoxColumn FieldName="d_Ngayketthuc" Caption="Ngày kết thúc" />
                                <dx:ListBoxColumn FieldName="f_Menhgia" Caption="Mệnh giá" />
                                </Columns>
                        </dx:ASPxComboBox>
                    </td>
                     <td class="info_table_td">
                        Mã Voucher : 
                    </td>
                    <td class="info_table_td" style="float:left">
                        <dx:ASPxTextBox ID="txt_MaVoucher" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                     <td class="info_table_td">
                        Ngày phát:
                    </td>
                    <td class="info_table_td" style="float:left">
                        <dx:ASPxDateEdit ID="de_Ngayphat" runat="server"></dx:ASPxDateEdit>
                    </td>
                     <td class="info_table_td">
                        Ngày kết thúc:
                    </td>
                    <td class="info_table_td" style="float:left">
                        <dx:ASPxDateEdit ID="de_Ngayketthuc" runat="server"></dx:ASPxDateEdit>
                    </td>
                </tr> 
                   <tr>
                       <td>
                           KH Tiềm năng/ Hệ thống :
                       </td>
                       <td>
                            <dx:ASPxCheckBox ID="ck_Check" runat="server" AutoPostBack="false" ClientInstanceName="ck_check">
                             <ClientSideEvents CheckedChanged="chkallChange" />
                        </dx:ASPxCheckBox>
                       </td>
                          <td class="info_table_td">Tên khách hàng</td>
                    <td class="info_table_td">
                       
                        <dx:ASPxComboBox ID="txt_Khachhang" runat="server" ValueType="System.String" DropDownWidth="700px"
                            DropDownStyle="DropDown" ValueField="uId_Khachhang" IncrementalFilteringMode="Contains"
                            EnableCallbackMode="true" TextFormatString="{0}-{1}" ClientInstanceName="txt_Khachhang" OnCallback="txt_Khachhang_Callback">
                            <Columns>
                                <dx:ListBoxColumn FieldName="uId_Khachhang" Visible="false" />
                                <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã khách hàng" />
                                <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Họ tên" />
                                <dx:ListBoxColumn FieldName="Trangthai" Caption="Trạng thái" />
                                </Columns>
                            <ClientSideEvents SelectedIndexChanged="Select_Khachhang" />
                        </dx:ASPxComboBox>
                    </td>
                   </tr>
             
                <tr>
                    <td colspan="4" class="info_table_td" style="text-align:center">
                        <dx:ASPxButton ID="btn_Refresh" ClientInstanceName="btn_Refresh" runat="server" Text="Làm mới" Style="float: left;margin-left: 120px" Image-Url="~/images/16x16/refresh.png"></dx:ASPxButton>
                        <dx:ASPxButton ID="btn_Add" ClientInstanceName="btn_Add" runat="server" Text="Phát Voucher" Style="float: left;margin-left: 10px" Image-Url="~/images/16x16/add.png"></dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
            </fieldset>
        </div>
    <div style="padding-bottom:20px">
        <fieldset class="field_tt" style="margin:auto;width:100%">
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_voucher" OnRowDeleting="dgvDevexpress_RowDeleting"
        SettingsPager-Position="Bottom" OnRowUpdating="dgvDevexpress_RowUpdating">
        <Columns>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_voucher"
                Name="uId_voucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Width="150px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Mã voucher" FieldName="v_Mavoucher"
                Name="v_Mavoucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                Width="150px" HeaderStyle-HorizontalAlign="Center" Caption="Mã khách hàng" FieldName="v_Makhachang"
                Name="v_Makhachang">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"
                Caption="Họ tên" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center"
                Caption="Số điện thoại" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center"
                Caption="Ngày phát" FieldName="d_Ngayphat" Name="d_Ngayphat" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
            </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center"
                Caption="Ngày kết thúc" FieldName="d_Ngayketthuc" Name="d_Ngayketthuc" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center"
                Caption="Mệnh giá" FieldName="f_Menhgia" Name="f_Menhgia">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center"
                Caption="Sử dụng" FieldName="nv_GioihanVOUCHER" Name="nv_GioihanVOUCHER">
            </dx:GridViewDataTextColumn>
              <dx:GridViewCommandColumn Width="100px" VisibleIndex="7" Caption="Edit" ButtonType="Image" HeaderStyle-HorizontalAlign="Center">
                    <CancelButton>
                        <Image AlternateText="Cancel" Url="~/images/btn_Cancel.png" />
                    </CancelButton>
                    <UpdateButton>
                        <Image AlternateText="Save" Url="../../images/btn_Edit.png"></Image>
                    </UpdateButton>
                    <EditButton Visible="true" Image-Url="../../images/btn_Edit.png" Image-AlternateText="Sửa">
                    </EditButton>
                  
                </dx:GridViewCommandColumn>
            <dx:GridViewCommandColumn VisibleIndex="8" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
                    <DeleteButton Visible="true" Image-Url="~/images/btn_Delete.png" Image-AlternateText="Xóa">
                        <Image Url="~/images/btn_Delete.png"></Image>
                    </DeleteButton>
                </dx:GridViewCommandColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <SettingsBehavior AllowFocusedRow="true" AllowMultiSelection="true" ConfirmDelete="true" ColumnResizeMode="NextColumn" EnableCustomizationWindow="true" />
        <SettingsText ConfirmDelete="Bạn có muốn xóa không?" />
        <ClientSideEvents EndCallback="OnEndCallback" RowClick="dbclick"  />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
            </fieldset>
        </div>
</asp:Content>
