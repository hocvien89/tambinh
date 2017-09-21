<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ThuVoucher.aspx.vb" Inherits="NANO_SPA.ThuVoucher" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        var tt = null;
        function ck_TrangthaiChanger(s, e) {
            if (ck_Trangthai.GetChecked() == true) {
                lbl_Alert.SetValue('Danh sách Voucher chưa thu về');
                client_grid.PerformCallback('FALSE');
            }
            else {
                lbl_Alert.SetValue('Danh sách Voucher đã thu về');
                client_grid.PerformCallback('TRUE');
            }
        }
    </script>
   <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" OnClick="btnQuaylai_Click" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THU VOUCHER</p>
            </li>
        </ul>
    </div>
    <div style="clear:both">
        <fieldset class="field_tt" style="width:100%;margin:auto">
        <legend><span style="font-weight: bold; color: green">Thông tin Voucher</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">
                        Mã Voucher : 
                    </td>
                    <td class="info_table_td" style="float:left">
                        <dx:ASPxTextBox ID="txt_MaVoucher" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                    
                    <td class="info_table_td">Tên chương trình :</td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txt_Tenchuongtrinh" ReadOnly="true" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td">Mệnh giá :</td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txt_Menhgia" ReadOnly="true" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td">Ngày bắt đầu : </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="txt_Ngaybatdau" ReadOnly="true" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>    
                    </td>
                   
                </tr>
             
                
                <tr>
                     <td class="info_table_td">
                        Ngày kết thúc :
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="txt_Ngayketthuc" ReadOnly="true" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">Mã khách hàng</td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txt_MaKH" ReadOnly="true" runat="server" Width="170px"></dx:ASPxTextBox>    
                    </td>
                    <td class="info_table_td">
                        Tên khách hàng :
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txt_TenKH" ReadOnly="true" runat="server" Width="170px"></dx:ASPxTextBox>
                    </td>
                     <td class="info_table_td">Ngày phát :</td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="txt_Ngayphat" ReadOnly="true" EditFormat="DateTime" EditFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                    </td>
                </tr>
                
                <tr>
                   
                    <td  class="info_table_td" style="text-align:center">
                        <dx:ASPxButton ID="btn_Tim" ClientInstanceName="btn_Add" runat="server" Text="Kiểm tra" Style="float:right" Image-Url="~/images/16x16/filter.png"></dx:ASPxButton>
                    </td>
                    <td  class="info_table_td" style="text-align:center;float:left" >
                        <dx:ASPxButton ID="btn_Add" ClientInstanceName="btn_Add" runat="server" Text="Thu về" Style="float:right" Image-Url="~/images/16x16/add.png"></dx:ASPxButton>
                    </td>
                </tr>
                
            </tbody>
        </table>
            </fieldset>
        </div>
    <div style="text-align:center;padding-bottom:20px">
        <fieldset class="field_tt" style="width:100%;margin:auto">
             <legend><span style="font-weight: bold; color: green"> <dx:ASPxLabel ID="lbl_Alert" runat="server" ForeColor="Green" ClientInstanceName="lbl_Alert" Font-Bold="True"></dx:ASPxLabel></span></legend>
            <div>
                <ul>
                    <li  class="text_title"  >
                        <dx:ASPxCheckBox ID="ck_Trangthai" ClientInstanceName="ck_Trangthai" AutoPostBack="false" Text="Trạng thái voucher" runat="server">
                            <ClientSideEvents CheckedChanged="ck_TrangthaiChanger" />
                        </dx:ASPxCheckBox>
                    </li>
                </ul>
            </div>
        
       
    <dx:ASPxGridView ID="dgvDevexpress" CssClass="grid_dm_dv" runat="server" ClientInstanceName="client_grid"
        AutoGenerateColumns="false" KeyFieldName="uId_voucher"
        SettingsPager-Position="Bottom" Width="100%">
        <Columns>
            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="" FieldName="uId_voucher"
                Name="uId_voucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="1" Width="100px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Chương trình" FieldName="nv_Tenloaivoucher"
                Name="nv_Tenloaivoucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Width="100px" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Caption="Mã voucher" FieldName="v_Mavoucher"
                Name="v_Mavoucher">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                Width="100px" HeaderStyle-HorizontalAlign="Center" Caption="Mã khách hàng" FieldName="v_Makhachang"
                Name="v_Makhachang">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="150px" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center"
                Caption="Họ tên" FieldName="nv_Hoten_vn" Name="nv_Hoten_vn">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center"
                Caption="Số điện thoại" FieldName="v_DienthoaiDD" Name="v_DienthoaiDD" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="80px" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center"
                Caption="Ngày phát" FieldName="d_Ngayphat" Name="d_Ngayphat" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="80px" VisibleIndex="7" HeaderStyle-HorizontalAlign="Center"
                Caption="Ngày Thu" FieldName="d_Ngaythu" Name="d_Ngaythu" PropertiesTextEdit-DisplayFormatString="{0:dd/MM/yyyy}">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="80px" VisibleIndex="8" HeaderStyle-HorizontalAlign="Center"
                Caption="Mệnh giá" FieldName="f_Menhgia" Name="f_Menhgia">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Visible="true" Width="100px" VisibleIndex="9" HeaderStyle-HorizontalAlign="Center"
                Caption="Sử dụng" FieldName="nv_GioihanVOUCHER" Name="nv_GioihanVOUCHER">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsEditing Mode="Inline" />
        <SettingsPager PageSize="15">
        </SettingsPager>
        <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowColumnHeaders="true" />
        <ClientSideEvents EndCallback="OnEndCallback" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#EAFCFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
            </fieldset>
        </div>
</asp:Content>
