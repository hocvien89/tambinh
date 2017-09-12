<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="DM_Calamviec.aspx.vb" Inherits="NANO_SPA.DM_Calamviec" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        function cb_Calamviec_SelectedIndexChanged()
        {
            Grid_Calamviec.Refresh();
        }
        function grid_EndCallback() {
            cb_Nhanvien.PerformCallback();
        }
        function Calendar_SelectionChanged() {
            Grid_Calamviec.Refresh();
        }
        function d_Tungay_DateChanged() {
            cb_Nhanvien.PerformCallback();
        }
    </script>
     <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>DANH MỤC CA LÀM VIỆC</p>
    </div>
           <fieldset class="field_tt_left" style="width: 98%; height: 45px; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Điều kiện lọc</span></legend>
        <ul>
            <li class="text_title"> Ngày:</li>
            <li class ="text_title"> 
                <dx:ASPxDateEdit runat="server" DisplayFormatString="dd/MM/yyyy" ID="d_Tungay">
                   <ClientSideEvents DateChanged="d_Tungay_DateChanged" />
                </dx:ASPxDateEdit>
            </li>
            <li class="text_title">Trạng thái: </li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cb_Calamviec" DropDownStyle="DropDownList" SelectedIndex="0" runat="server" IncrementalFilteringMode="StartsWith">
                    <Items>
                        <dx:ListEditItem Text="Tất cả" Value="All" />
                        <dx:ListEditItem Text="CA 1" Value="1" />
                        <dx:ListEditItem Text="CA 2" Value="2" />
                        <dx:ListEditItem Text="OFF" Value="0" />
                    </Items>
                    <ClientSideEvents SelectedIndexChanged="cb_Calamviec_SelectedIndexChanged" />
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">Nhân viên:</li>
            <li class="text_title">
                <dx:ASPxComboBox ID="cb_Nhanvien" ClientInstanceName="cb_Nhanvien" DropDownStyle="DropDownList" runat="server"
                    ValueField="uId_Nhanvien" AutoPostBack="false" IncrementalFilteringMode="StartsWith" SelectedIndex="0" OnCallback="cb_Nhanvien_Callback">
                </dx:ASPxComboBox>
            </li>
            <li class="text_title">
                Ghi chú :
            </li>
            <li class="text_title">
                <dx:ASPxTextBox runat ="server" ID="txt_Ghichu" Width="180px"></dx:ASPxTextBox>
            </li>
            <li class="text_title">
                <dx:ASPxButton ID="btnAdd" Width="100px" OnClick="btnAdd_Click" Image-Url="~/images/16x16/add.png" Height="20px" Style="bottom: 5px; position: relative"
                    runat="server" Text="Thêm" AutoPostBack="false">
                </dx:ASPxButton>
            </li>
        </ul>

    </fieldset>
        <div>
           
            <div style="float:left;width:30%;vertical-align: top;padding-top:2px;padding-left:2px;">
                     <dx:ASPxCalendar runat="server" ID="Calendar" Width="300px" DayNameFormat="FirstLetter" Theme="Youthful" EnableMultiSelect="true" Rows="1">
                       <ClientSideEvents SelectionChanged ="Calendar_SelectionChanged"/>
                    </dx:ASPxCalendar>
<%--                     <dxwschs:ASPxDateNavigator Width="240px" ID="ASPxDateNavigator_Calamviec" Enabled="true" MasterControlID="Grid_Ca"  runat="server" Theme="Youthful">
                        <Properties DayNameFormat="Full"/>
                    </dxwschs:ASPxDateNavigator>--%>
            </div>
          <div style="float:left;width:69%">
                <fieldset class="field_tt_left" style="width: 98%; height: auto; margin: auto">
        <dx:ASPxGridView ID="Grid_Ca" runat="server" ClientInstanceName="Grid_Calamviec" KeyFieldName="uId_Nhanvien_Ca" Width="100%" OnRowDeleting="Grid_Ca_RowDeleting">
            <Columns>
                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="-1" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center"
                    Caption="" FieldName="uId_Nhanvien_Ca" Name="uId_Nhanvien_Ca">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Ngày làm việc" FieldName="d_Ngay" Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Nhân viên" FieldName="nv_Hoten_vn" Width="200px">
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Visible="true" VisibleIndex="0" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Trạng thái" FieldName="v_Calamviec" Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                    HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                    Caption="Ghi chú" FieldName="nv_Ghichu_vn" Width="200px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="5" Width="5%" Caption="Xóa" HeaderStyle-HorizontalAlign="Center" ButtonType="Image">
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
            <ClientSideEvents EndCallback="grid_EndCallback" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
    </fieldset>
          </div>
        
        </div>
  
</asp:Content>
