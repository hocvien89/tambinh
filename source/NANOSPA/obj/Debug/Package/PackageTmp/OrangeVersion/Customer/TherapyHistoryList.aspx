<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="TherapyHistoryList.aspx.vb" Inherits="NANO_SPA.TherapyHistoryLis" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
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
         //function btn_Baocao(s, e) {
         //    grid_Lieutrinh.Refresh();
         //}
         function grid_EndCallback(s, e) {

             if (s.cpShowError) {
                 lberror.SetText(s.cpText);
             }
         }
         function SelChanged(s, e) {
             if (!e.isSelected) {
             } else {
                 client_grid.GetRowValues(e.visibleIndex, 'uId_Khachhang;', OnGridSelectionComplete);
             }
         }
    </script>
      <div class="brest_crum">
        <ul>
            <li class="text_title">
                <dx:ASPxButton ID="btnback" runat="server" Image-Url="~/images/16x16/back.png" Image-AlternateText="Quay lại" ToolTip="Quay lại"></dx:ASPxButton>
            </li>
            <li>
                <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>BÁO CÁO LỊCH SỬ LIỆU TRÌNH</p>
            </li>
        </ul>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Điều kiện lọc</span></legend>
        <div style="height: 30px; width: 1070px; margin: auto">

            <ul>
          
                <li class="text_title" style="margin-left: 5px">Từ ngày: </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxDateEdit ID="Aspx_Tungay" runat="server" Width="85px" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                </li>
                <li class="text_title" style="margin-left: 5px">Đến ngày: </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxDateEdit ID="Aspx_Denngay" runat="server" Width="85px" EditFormat="Custom" Date="2014-10-15" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                </li>
               <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxCheckBox ID="chk_Khachhang" runat="server" Text="Khách hàng:" />
                </li>
                <li class="text_title"  style="margin-left: 5px">
                    <dx:ASPxComboBox  ID="cbo_Khachhang" runat="server" IncrementalFilteringMode="Contains" />
                </li>
               <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxCheckBox ID="chk_Dichvu" runat="server" Text="Dịch vụ:"  />
                </li>
                <li class="text_title" style="margin-left: 5px">
                    <dx:ASPxComboBox ID="cbo_Dichvu" runat="server" IncrementalFilteringMode="Contains" />
                </li>
                <li class="text_title">
                    <dx:ASPxButton ID="btn_Baocao" ClientInstanceName="btn_Baocao" Image-Url="~/images/16x16/filter.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="true"
                        runat="server" Text="Lọc" EnableClientSideAPI="true">
                        
                    </dx:ASPxButton>
                </li>
                <li class="text_title">
                    <dx:ASPxButton ID="btn_ExportExcel" Image-Url="~/images/16x16/export_excel.png" Height="20px" Style="bottom: 5px; position: relative" AutoPostBack="false"
                        runat="server" Text="Xuất Excel">
                    </dx:ASPxButton>
                </li>
            </ul>
        </div>
    </fieldset>
    <fieldset class="field" style="width: 98%; height: auto; margin: auto">
        <legend><span style="font-weight: bold; color: green;">Danh sách liệu trình </span></legend>
        <dx:ASPxGridView ID="Grid_Lieutrinh" runat="server" KeyFieldName="uId_Khachhang" AutoGenerateColumns="false"
            ClientInstanceName="grid_Lieutrinh" Width="100%" >
            <Columns>
                <dx:GridViewDataTextColumn FieldName="nv_Hoten_vn" Caption="Khách hàng" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="2" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="uId_Dichvu"  HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="-1" Visible="false" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="uId_Khachhang"  HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="-1" Visible="false" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Diachi_vn" Caption="Địa chỉ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="3" Visible="false" Width="150px"/>
                <dx:GridViewDataTextColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="3" CellStyle-ForeColor="Red" Width="80px" />
                <dx:GridViewDataTextColumn FieldName="v_Email" Caption="Email" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="0" Visible="false"  CellStyle-ForeColor="Blue" />
                <dx:GridViewDataTextColumn FieldName="v_Sophieu" Caption="Mã phiếu" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="4" Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Tendichvu_vn" Caption="Dịch vụ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="5" Width="200px">
                </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="nv_Tenchuongtrinh_vn" Caption="Chương trình KM" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="5" Width="200px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="f_Solan_Conlai" Caption="Số buổi còn lại" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="7" Width="50px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nv_Ghichu" Caption="Ghi chú" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="11"  Width="200px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="i_Lanthu" Caption="Lần thứ" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="6" Width="50px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="f_Solan" Caption="Tổng số lần" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="5" Width="30px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="d_Ngaydieutri" Caption="Ngày thực hiện" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="1" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy" Width="80px">
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="Nhanvien" Caption="Tên người thực hiện" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="10" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="dt_checkin" Visible="false" Caption="Giờ checkin" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="8" >
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="dt_checkout" Visible="false" Caption="Giờ checkout" HeaderStyle-HorizontalAlign="Center"
                    Settings-AutoFilterCondition="Contains" VisibleIndex="9" Width="30px">
                </dx:GridViewDataTextColumn>               
            </Columns>
       
            <SettingsPager PageSize="15">
            </SettingsPager>
           <ClientSideEvents EndCallback="grid_EndCallback" SelectionChanged="function(s, e) { SelChanged(s, e); }" />
              <Settings ShowFilterRow="True" />
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <ClientSideEvents SelectionChanged="function(s, e) { SelChanged(s, e); }" />
            <Styles>
                <AlternatingRow Enabled="True" BackColor="#EAFCFF">
                </AlternatingRow>
            </Styles>
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter_Data" GridViewID="Grid_Lieutrinh" runat="server"></dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
